using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphAlgos;

namespace CampusSimulator
{

    public enum RouteSpecMethod { BldRoomToBldRoom }
    public class RouteSpec
    {
        JourneySpecMan jm;
        public RouteSpecMethod routeSpecMethod;
        public string bld1name;
        public string bld1room;
        public string bld2name;
        public string bld2room;
        public RouteSpec(JourneySpecMan jm, RouteSpecMethod routeSpecMethod, string b1name, string b1room, string b2name, string b2room, string personname)
        {
            this.jm = jm;
            this.routeSpecMethod = routeSpecMethod;
            this.bld1name = b1name;
            this.bld1room = b1room;
            this.bld2name = b2name;
            this.bld1room = b2room;
        }
        public RouteSpec(JourneySpecMan jm)
        {
            this.jm = jm;
            var ss = RouteSpec.GetDefault();
            SetOnString(ss);
        }

        public RouteSpec(JourneySpecMan jm, string serialstring)
        {
            this.jm = jm;
            SetOnString(serialstring);
        }
        public void SetOnString(string serialstring)
        {
            var ms = new string[] { JourneySpecMan.GetMinorSep() };
            var sar = serialstring.Split(ms, System.StringSplitOptions.None);
            if (sar.Length < 6 || sar[0] != "#Route")
            {
                jm.jnman.sman.LggError($"Bad serialstring for RouteSpec:'{serialstring}'");
                this.routeSpecMethod = RouteSpecMethod.BldRoomToBldRoom;
                this.bld1name = "";
                this.bld1room = "";
                this.bld2name = "";
                this.bld2room = "";
                return;
            }
            var ok1 = RouteSpecMethod.TryParse(sar[1], out this.routeSpecMethod);
            if (!ok1)
            {
                routeSpecMethod = RouteSpecMethod.BldRoomToBldRoom;
            }
            this.bld1name = sar[2];
            this.bld1room = sar[3];
            this.bld2name = sar[4];
            this.bld2room = sar[5];
        }
        public static string GetDefault()
        {
            var ms = JourneySpecMan.GetMinorSep();
            var rsm = RouteSpecMethod.BldRoomToBldRoom;
            var rv = $"#Route{ms}{rsm}{ms}{"Bld33"}{ms}{"lobby"}{ms}{"Bld34"}{ms}{"lobby"}";
            return rv;
        }

        public string SerialString()
        {
            var ms = JourneySpecMan.GetMinorSep();
            var rv = $"#Route{ms}{routeSpecMethod}{ms}{bld1name}{ms}{bld1room}{ms}{bld2name}{ms}{bld2room}";
            return rv;
        }
    }
    public enum JourneyMethod { walkjour, autojour, flyjour, dronejour }
    public class JourneyPrincipalSpec
    {
        JourneySpecMan jm;
        public JourneyMethod journeyMethod;
        public string pname;
        public string avatar;
        public JourneyPrincipalSpec(JourneySpecMan jm, JourneyMethod journeyMethod, string pname, string avatar)
        {
            this.jm = jm;
            this.journeyMethod = journeyMethod;
            this.pname = pname;
            this.avatar = avatar;
        }
        public JourneyPrincipalSpec(JourneySpecMan jm)
        {
            this.jm = jm;
            var ss = JourneyPrincipalSpec.GetDefault();
            SetOnString(ss);
        }
        public JourneyPrincipalSpec(JourneySpecMan jm, string serialstring)
        {
            this.jm = jm;
            SetOnString(serialstring);
        }
        public void SetOnString(string serialstring)
        { 
            var ms = new string[] { JourneySpecMan.GetMinorSep() };
            var sar = serialstring.Split(ms, System.StringSplitOptions.None);
            if (sar.Length<4 || sar[0]!="#Prince")
            {
                jm.jnman.sman.LggError($"Bad serialstring for JourneyPrincipalSpec:'{serialstring}'");
                this.journeyMethod = JourneyMethod.walkjour;
                this.pname = "";
                this.avatar = "";
                return;
            }
            var ok1 = JourneyMethod.TryParse(sar[1], out this.journeyMethod);
            if (!ok1)
            {
                journeyMethod = JourneyMethod.walkjour;
            }
            this.pname = sar[2];
            this.avatar = sar[3];
        }
        public string SerialString()
        {
            var ms = JourneySpecMan.GetMinorSep();
            var rv = $"#Prince{ms}{journeyMethod}{ms}{pname}{ms}{avatar}";
            return rv;
        }
        public static string GetDefault()
        {
            var ms = JourneySpecMan.GetMinorSep();
            var jm = JourneyMethod.walkjour;
            var rv = $"#Prince{ms}{jm}{ms}{"Jane"}{ms}{"People/Businesswoman001"}";
            return rv;
        }

    }
    public class ActionSpec
    {
        JourneySpecMan jm;
        public JourneyEnd journeyEnd;
        public bool quitAtDest;
        public string thingToDo;

        public ActionSpec(JourneySpecMan jm, JourneyEnd journeyEnd, bool quitAtDest, string thingToDo)
        {
            this.jm = jm;
            this.journeyEnd = journeyEnd;
            this.quitAtDest = quitAtDest;
            this.thingToDo = thingToDo;
        }
        public ActionSpec(JourneySpecMan jm)
        {
            this.jm = jm;
            var ss = GetDefault();
            SetOnString(ss);
        }
        public ActionSpec(JourneySpecMan jm, string serialstring)
        {
            this.jm = jm;
            SetOnString(serialstring);
        }
        public void SetOnString( string serialstring)
        { 
            var ms = new string[] { JourneySpecMan.GetMinorSep() };
            var sar = serialstring.Split(ms,System.StringSplitOptions.None);
            if (sar.Length < 4)
            {
                jm.jnman.sman.LggError($"Bad serialstring for ActionSpec:'{serialstring}'");
                this.journeyEnd = JourneyEnd.disappear;
                this.quitAtDest = false;
                this.thingToDo = "";
                return;
            }
            var ok1 = JourneyEnd.TryParse(sar[1], out this.journeyEnd );
            if (!ok1)
            {
                journeyEnd = JourneyEnd.disappear;
            }
            var s2low = sar[2].ToLower();
            if (s2low == "")
            {
                quitAtDest = false;
            }
            else if (s2low.StartsWith("quit"))
            {
                quitAtDest = true;
            }
            else
            {
                var ok2 = bool.TryParse(sar[2], out this.quitAtDest);
                if (!ok2)
                {
                    quitAtDest = false;
                }
            }
            this.thingToDo = sar[3];
        }

        public string SerialString()
        {
            var ms = JourneySpecMan.GetMinorSep();
            var qad = quitAtDest ? "QuitAtDest" : "";
            var rv = $"#Action{ms}{journeyEnd}{ms}{qad}{ms}{thingToDo}";
            return rv;
        }

        public static string GetDefault()
        {
            var ms = JourneySpecMan.GetMinorSep();
            var jem = JourneyEnd.disappear;
            var qad = "";
            var thingtodo = "";
            var rv = $"#Action{ms}{jem}{ms}{qad}{ms}{thingtodo}";
            return rv;
        }

    }

    public enum JourneySpecMethod {rpa }
    public class JourneySpec
    {
        JourneySpecMan jm;
        public string jouneyId;
        public string displayName;
        public JourneySpecMethod journeySpecMethod;
        public RouteSpec routeSpec;
        public JourneyPrincipalSpec princeSpec;
        public ActionSpec actionSpec;
        public JourneySpec(JourneySpecMan jm,string displayName,RouteSpec routeSpec,JourneyPrincipalSpec princeSpec,ActionSpec actionSpec)
        {
            this.jm = jm;
            jouneyId = jm.GetNewJourneyId();
            this.displayName = displayName;
            this.journeySpecMethod = JourneySpecMethod.rpa;
            this.routeSpec = routeSpec;
            this.princeSpec = princeSpec;
            this.actionSpec = actionSpec;
        }

        public JourneySpec(JourneySpecMan jm)
        {
            this.jm = jm;
            SetOnString("");
        }

        public JourneySpec(JourneySpecMan jm, string serialstring)
        {
            this.jm = jm;
            SetOnString(serialstring);
        }
        public void SetOnString(string serialstring)
        { 
            var mjs = new string[] { JourneySpecMan.GetMajorSep() };
            jouneyId = jm.GetNewJourneyId();
            if (serialstring=="")
            {
                journeySpecMethod = JourneySpecMethod.rpa;
                displayName = jouneyId;
                routeSpec = new RouteSpec(jm);
                princeSpec = new JourneyPrincipalSpec(jm);
                actionSpec = new ActionSpec(jm);
                return;
            }
            var sar = serialstring.Split(mjs, System.StringSplitOptions.None);
            if (sar.Length < 5 || sar[0]!="#JourneySpec")
            {
                jm.jnman.sman.LggError($"Bad serialstring for JourneySpec:'{serialstring}'");
                journeySpecMethod = JourneySpecMethod.rpa;
                this.displayName = "";
                this.routeSpec = new RouteSpec(jm, "");
                this.princeSpec = new JourneyPrincipalSpec(jm,"");
                this.actionSpec = new ActionSpec(jm,"");
                return;
            }

            this.journeySpecMethod = JourneySpecMethod.rpa;
            this.displayName = sar[1];
            this.routeSpec = new RouteSpec(jm, sar[2]);
            this.princeSpec = new JourneyPrincipalSpec(jm,sar[3]);
            this.actionSpec = new ActionSpec(jm,sar[4]);
        }

        public string SerialString()
        {
            var mjs = JourneySpecMan.GetMajorSep();
            var rrs = routeSpec.SerialString();
            var pps = princeSpec.SerialString();
            var aas = actionSpec.SerialString();
            var rv = $"#JourneySpec{mjs}{journeySpecMethod}{mjs}{rrs}{mjs}{pps}{mjs}{aas}";
            return rv;
        }
    }

    public class JourneySpecMan
    {
        public JourneyMan jnman;
        Dictionary<string, JourneySpec> journeySpecs;
        int numAlloced = 0;
        public JourneySpecMan(JourneyMan jnman)
        {
            this.jnman = jnman;
            Init();
        }
        public void DeleteJourneySpecs()
        {
            Init();
        }
        public void Init()
        {
            journeySpecs = new Dictionary<string, JourneySpec>();
            numAlloced = 0;
        }

        public string GetNewJourneyId()
        {
            var rv = $"jnyspec{numAlloced:d3}";
            numAlloced++;
            return rv;
        }
        public static string GetMinorSep()
        {
            return ":";
        }
        public static string GetMajorSep()
        {
            return "|";
        }
        public (bool,string) AddJourneySpec(JourneySpec journeySpec)
        {
            var jid = journeySpec.jouneyId;
            if (journeySpecs.ContainsKey(jid))
            {
                return (false, $"AddJourneySpec - Duplicate JourneyID{jid}");
            }
            journeySpecs[journeySpec.jouneyId] = journeySpec;
            return (true, "");
        }
        public void DelJourneySpec(JourneySpec journeySpec)
        {
            var jid = journeySpec.jouneyId;
            if (journeySpecs.ContainsKey(jid))
            {
                journeySpecs.Remove(jid);
            }
        }

    }


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
        public void SetFreeze(bool freezeValue)
        {
            if (birdctrl != null)
            {
                if (freezeValue)
                {
                    birdctrl.StartAnimation();
                }
                else
                {
                    birdctrl.StopAnimation();
                }
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