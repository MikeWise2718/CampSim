using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphAlgos;

namespace CampusSimulator
{
    public enum JourneyEnd { disappear, restart, reverse }

    public class Journey : MonoBehaviour
    {

        // Start is called before the first frame update
        private JourneyMan jman = null;
        public int nlegs { get { return legs.Count; } }
        public List<Leg> legs = null;
        public List<string> legdesc = new List<string>();
        public PathCtrl pathctrl;
        public BirdCtrl birdctrl;
        public JourneyEnd journeyEnd=JourneyEnd.disappear;
        public int jindex = 0;
        public int legindex = 0;
        public Leg currentleg = null;
        public JourneyStatE status = JourneyStatE.NotStarted;
        public float createtime;
        public float starttime;
        public float finishedtime;
        public float failedtime;
        public float journeyelap;
        //public GameObject jgo;
        public string description;
        public bool birdrectvisible;
        public Rect birdrect;
        public Person person;
        public Vehicle vehicle;
        public float failedSecsToDestroy;
        public float finishSecsToDestroy;
        public float startSecsToDelay;

        public Journey frontjny = null;
        public float frontdist = 0;
        public Journey backjny = null;
        public float backdist = 0;
        public int njnysOnWeg = 0;
        public float jnyTime = 0;
        public bool pullViewer = false;

        public bool IsRunning()
        {
            var rv = false;
            if (status == JourneyStatE.Started || 
                status == JourneyStatE.AlmostFinished) rv = true;
            return rv;
        }


        public void InitJourney(JourneyMan jman, Person pers, Vehicle vehi,BldRoom br1,BldRoom br2, string description, float finsecs = 5, float starsecs = 3,string jorg="")
        {
            this.jman = jman;
            jindex = jman.curjidx++;
            //jgo = new GameObject();
            this.description = description;
            //this.description = description;
            name = "j" + jindex.ToString("D3") +" " + this.description;
            transform.parent = jman.transform;
            legs = new List<Leg>();
            //pathctrl = jgo.AddComponent<PathCtrl>();
            pathctrl = gameObject.AddComponent<PathCtrl>();
            pathctrl.SetSceneMan(jman.sman);
            //birdctrl = jgo.AddComponent<BirdCtrl>();
            birdctrl = gameObject.AddComponent<BirdCtrl>();
            birdctrl.sman = jman.sman;
            createtime = Time.time;
            person = pers;
            vehicle = vehi;
            if (jman.sman.fastMode)
            {
                startSecsToDelay = Mathf.Min(starsecs,1.2f);
                finishSecsToDestroy = Mathf.Min(finsecs,1.2f);
            }
            else
            {
                startSecsToDelay = starsecs;
                finishSecsToDestroy = finsecs;
            }
            failedSecsToDestroy = 10;
            if (person != null)
            {
                person.journey = this;
            }
            status = JourneyStatE.WaitingToStart;
            jnyTime = Time.time;
            jman.LogJourney(this,br1,br2);
        }

        public void StartLeg(int legidx)
        {
            //jman.sman.Log("StartLeg legidx:" + legidx);
            if (legidx >= nlegs)
            {
                if (journeyEnd == JourneyEnd.disappear)
                {
                    finishedtime = Time.time;
                    journeyelap = finishedtime - starttime;
                    status = JourneyStatE.AlmostFinished;
                    if (person != null)
                    {
                        person.PersonStateStartUntraveling("", "");
                    }
                }
                else
                {
                    if (legidx != 0)
                    {
                        jman.sman.Lgg($"Jouney {name} restarting");
                        StartLeg(0);
                    }
                    else
                    {
                        jman.sman.LggError("No legs in journey");
                    }    
                }
                return;
            }
            if (legidx > 0 && currentleg.form == BirdFormE.car)
            {
                var sm = jman.gm.GetSlot(currentleg.enode);
                if (sm == null) return; // can happen if we delete nodes
                //sm.Occupy(currentleg.formname);
                sm.VehicleOccupy(currentleg.vehicle);
            }
            if (person != null)
            {
                if (person.grabbedMainCamera)
                {
                    Camera.main.transform.parent = null; // unattach the main cam to avoid Unity deleting main cam and freaking out
                }
            }
            legindex = legidx;
            currentleg = legs[legidx];
            //Debug.Log("calling GenAstarPath");
            pathctrl.GenAstarPath(currentleg.snode, currentleg.enode, currentleg.capneed);
            //pathctrl.GenAstarPath(currentleg.snode, currentleg.enode, LcCapType.anything);
            if (pathctrl.status != PathCtrl.PathStatusE.AstarOk)
            {
                jman.sman.LggWarning("Path status:"+pathctrl.status+" looking for path from "+currentleg.snode+" to "+currentleg.enode);
                return;
            }
            currentleg.dist = pathctrl.PathLength;
            currentleg.distcount = pathctrl.PathCount;
            birdctrl.person = this.person;
            //Debug.Log("Setting bird path");
            birdctrl.SetBirdPath(pathctrl.path);
            birdctrl.birdresourcename = currentleg.formname;
            birdctrl.birdscale = currentleg.skafak;
            birdctrl.lookatpoint = currentleg.lookatpt;
            birdctrl.flatlookatpoint = currentleg.flatlookatpt;
            birdctrl.moveoffset = new Vector3(currentleg.xoff, birdctrl.moveoffset.y, birdctrl.moveoffset.z);
            birdctrl.BirdForm = currentleg.form;
            birdctrl.rundist = currentleg.lambstart * pathctrl.path.pathLength;
             //Debug.Log("set birdresourcename to:"+currentleg.formname+" legidx:"+legidx);
            //jman.sman.RefreshRegionManGos();
            birdctrl.StartBird();
            birdctrl.SetSpeed(currentleg.vel);

            if (currentleg.form == BirdFormE.car)
            {
                var sm = jman.gm.GetSlot(currentleg.snode);
                if (sm == null) return; // can happen if we delete nodes
                sm.Vacate();
            }
        }
        public void NextLeg()
        {
            StartLeg(legindex + 1);
        }
        public void StartJourney()
        {

            starttime = Time.time;
            StartLeg(0);
            if (person != null)
            {
                person.PersonStateStartTraveling();
                var starnode = currentleg.snode;
                if (jman.bm.IsRoomlike(starnode))
                {
                    jman.bm.VacateNode(starnode, person);
                }
                else if (jman.zm.IsSlot(starnode))
                {
                    jman.zm.VacateSlot(starnode, person);
                }
            }
            if (pathctrl.status != PathCtrl.PathStatusE.AstarOk)
            {
                jman.sman.LggWarning("Failed to find path from start to dest for starting leg");
                status = JourneyStatE.Failed;
                failedtime = Time.time;
            }
            else
            {
                status = JourneyStatE.Started;
            }
        }
        public void FinishJourney()
        {
            if (person != null)
            {
                var enddest = currentleg.enode;
                person.PersonStateFinishTraveling();
                if (jman.zm.IsSlot(enddest))
                {
                    jman.zm.OccupySlot(enddest, person);
                }
                else
                {
                    var broom = jman.bm.GetAssociatedRoom(enddest);
                    if (broom)
                    {
                        jman.bm.OccupyNode(enddest, person);
                    }
                    else
                    {
                        var bpad = jman.bm.GetAssociatedPad(enddest);
                        if (bpad)
                        {
                            jman.bm.OccupyNode(enddest, person);
                        }

                    }
                }
            }
            status = JourneyStatE.Finished;
            // sman.Lgg("--Journey "+jgo.name+" took " + journeyelap + " secs");
        }
        public void AddLeg(Leg leg)
        {
            legdesc.Add(leg.ToString());
            legs.Add(leg);
        }
        //void Start()
        //{

        //}
        float lastUpdatedLoggedTime = 0;
        float updateLogInterval = 1;
        public void UpdatePosition()
        {
            if (jman.logJourneys)
            {
                PathPos pos = birdctrl.GetBirdPos();
                if (IsRunning() && (Time.time - lastUpdatedLoggedTime) > updateLogInterval)
                {
                    jman.sman.Lgg($"Jny:{name} position:{pos.pt:f1}");
                    lastUpdatedLoggedTime = Time.time;
                }
            }
        }
        //// Update is called once per frame
        void Update()
        {
            UpdatePosition();
        }

    }

}