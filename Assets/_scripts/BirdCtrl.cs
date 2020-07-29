using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphAlgos;

namespace CampusSimulator
{
    public enum BirdFormE { none, sphere, longsphere, hummingbird, person,car,drone }
    public enum BirdStateE { dormant, atstart, running, atgoal, stopped }

    public class BirdCtrl : MonoBehaviour
    {

        public SceneMan sman;
        public float rundist = 0;
        public float lookaheadtime;
        public Vector3 curpt = Vector3.zero;
        private Vector3 lastcurpt = Vector3.zero;

        public BirdFormE birdform = BirdFormE.none;
        public BirdFormE lastbirdform = BirdFormE.none;
        public bool birdStopped = false;
        public float lastBirdSpeed;
        public float initBirdSpeed;
        public float BirdSpeed;
        public float BirdSpeedFactor = 1.0f;
        public float BirdFlyHeight = 1.5f;
        public Vector3 birdVelVek;
        public BirdStateE BirdState;
        public GameObject birdformgo=null;
        public int gogeninst = 0;
        public string movingAnimationScript = "";
        public string restingAnimationScript = "";
        public int birdformidx = 1;
        public string birdresourcename = "";

        public PathPos pathpos = null;
        public Weg pathweg = null;
        public string spathweg = "";
        public float wegdistance = 0;
        public Guid wegguid = Guid.Empty;
        public string swegguid = Guid.Empty.ToString();
        public int cntgp = 0;

        static public GameObject birdgoes = null;
        public Person person = null;
        public GameObject birdgo=null;

        Path path = null;

        public bool isRunning() { return (BirdState == BirdStateE.running); }
        public bool isAtStart() { return (BirdState == BirdStateE.atstart); }
        public bool isAtGoal() { return (BirdState == BirdStateE.atgoal); }

        public BirdFormE BirdForm
        {
            set
            {
                birdform = value;
                RefreshBirdGos();
            }
        }

        public void SetBirdPath(Path path,bool stopbird=false)
        {
            this.path = path;
            curpt = Vector3.zero;
            lastcurpt = Vector3.zero;
            rundist = 0;
            if (stopbird)
            {
                if (BirdState == BirdStateE.running)
                {
                    initBirdSpeed = BirdSpeed;
                    BirdSpeed = 0;
                }
                BirdState = BirdStateE.atstart;
            }
        }

        public GameObject GetBirdFormGoForFrames()
        {
            var bgo = birdformgo;
            var rendgo = bgo;
            if (birdform == BirdFormE.person)
            {
                if (rendgo == null)
                {
                    Debug.Log("rendgo and bgo are null");
                    return null;
                }
                var rendgot = rendgo.transform.Find("H_DDS_LowRes");
                if (rendgot == null)
                {
                    Debug.Log("rendgot is null");
                    return null;
                }
                rendgo = rendgot.gameObject;
            }
            return rendgo;
        }

        Vector3 GetPathPoint(float gpprdist,bool curpos=true)
        {
            if (path == null) return Vector3.zero;
            var pp = path.MovePositionAlongPath(gpprdist);
            if (curpos)
            {
                pathpos = pp;
                pathweg = pp.weg;
                spathweg = pathweg.frNode.name + " to " + pathweg.toNode.name;
                wegguid = pp.weg.id;
                swegguid = wegguid.ToString();
                wegdistance = pp.wegDistSoFar;
                cntgp++;
            }
            
            var pt = new Vector3(pp.pt.x, pp.pt.y + BirdFlyHeight, pp.pt.z);
            return pt;
        }
        void CreateBirdFormGos()
        {
            if (birdgoes==null)
            {
                birdgoes = new GameObject();
                birdgoes.name = "Birds";
                birdgoes.transform.parent = sman.rgo.transform;
            }
            if (birdformgo!=null)
            {
                Destroy(birdformgo);
                birdformgo = null;
            }
            var curpos = birdgo.transform.position;
            var currot = birdgo.transform.localRotation;
            switch (birdform)
            {
                case BirdFormE.sphere:
                    {
                        birdformgo = GraphUtil.CreateMarkerSphere("sphere", Vector3.zero, size: 0.3f, clr: "yellow");
                        birdformgo.transform.localRotation = currot;
                        birdformgo.transform.localPosition = curpos;
                        movingAnimationScript = "";
                        restingAnimationScript = "";
                        //BirdFlyHeight = 1.5f;
                        birdgo.name = "Sphere";
                        break;
                    }
                case BirdFormE.longsphere:
                    {
                        birdformgo = GraphUtil.CreateMarkerSphere("sphere", Vector3.zero, size: 0.2f, clr: "yellow");
                        var nosept = new Vector3(0, 0, 0.1f);

                        var gonose = GraphUtil.CreateMarkerSphere("nose", nosept, size: 0.1f, clr: "red");
                        gonose.transform.parent = birdformgo.transform;

                        birdformgo.transform.localScale = new Vector3(0.25f, 0.25f, 0.5f); // somehow adding the nose made the sphere bigger ??
                        birdformgo.transform.localRotation = currot;
                        birdformgo.transform.localPosition = curpos;
                        movingAnimationScript = "";
                        restingAnimationScript = "";
                        //BirdFlyHeight = 1.5f;
                        //                        birdformgo.transform.Rotate(90, 0, 0);
                        birdgo.name = "Olive";
                        break;
                    }
                default:
                case BirdFormE.hummingbird:
                    {
                        var objPrefab = Resources.Load<GameObject>("hummingbird");
                        birdformgo = Instantiate<GameObject>(objPrefab);
                        var s = 0.5e-3f;
                        birdformgo.transform.localScale = new Vector3(s, s, s);
                        birdformgo.transform.localRotation = currot;
                        birdformgo.transform.localPosition = curpos;
                        movingAnimationScript = "";
                        restingAnimationScript = "";
                        //BirdFlyHeight = 1.5f;
                        birdgo.name = "Bird";
                        break;
                    }
                case BirdFormE.drone:
                    {
                        var objPrefab = Resources.Load<GameObject>("obj3d/quadcopterspinning");
                        birdformgo = Instantiate<GameObject>(objPrefab);
                        var s = sman.stman.scalemodelnumber.Get()*100;
                        birdformgo.transform.localScale = new Vector3(s, s, s);
                        birdformgo.transform.localRotation = currot;
                        birdformgo.transform.localPosition = curpos;
                        movingAnimationScript = "";
                        restingAnimationScript = "";
                        //BirdFlyHeight = 1.5f;
                        birdgo.name = "Phantom";
                        break;
                    }
                case BirdFormE.person:
                    {
                        //if (birdresourcename=="")
                        //{
                        //    birdresourcename = "girl004";
                        //}
                        if (person)
                        {
                            birdformgo = person.LoadPersonGo("-ava-bc");
                            if (person.hasHololens)
                            {
                                person.ActivateHololens(true);
                            }
                        }
                        else
                        {
                            var objPrefab = Resources.Load<GameObject>("people/girl004");
                            birdformgo = Instantiate<GameObject>(objPrefab);
                        }
                        var s = sman.stman.scalemodelnumber.Get();
                        birdformgo.transform.localScale = new Vector3(s, s, s);
                        birdformgo.transform.localRotation = currot;
                        //var noise = GraphAlgos.GraphUtil.GetRanFloat(0, 0.6f,"jnygen");
                        var newpos = new Vector3(curpos.x+0.3f, curpos.y - 1.55f, curpos.z);
                        birdformgo.transform.localPosition = newpos;
                        movingAnimationScript = "Animations/PersonWalk";
                        restingAnimationScript = "Animations/PersonIdle";
                        //BirdFlyHeight = 1.5f;
                        birdgo.name = birdresourcename;
                        if (person)
                        {
                            if (person.hasCamera)
                            {
                                person.AddCamera(birdformgo, "BirdCtrl CreateBirdFormGos");
                            }
                            if (person.grabbedMainCamera)
                            {
                                person.GrabMainCamera();
                            }
                        }
                        break;
                    }
                case BirdFormE.car:
                    {
                        //Debug.Log("Loading car resourcename:" + birdresourcename);
                        if (birdresourcename == "")
                        {
                            birdresourcename = "car001";
                        }
                        //var objPrefab = Resources.Load<GameObject>("Cars/"+birdresourcename);
                        //birdformgo = Instantiate<GameObject>(objPrefab);
                        birdformgo = VehicleMan.LoadCarGo(birdgo,birdresourcename);
                        //var s = 1.0f;
                        //birdformgo.transform.localScale = new Vector3(s, s, s);
                        birdformgo.transform.localRotation = currot;
                        var noise = GraphAlgos.GraphUtil.GetRanFloat(0, 0.5f, "jnygen");
                        var newpos = new Vector3(curpos.x+1.2f+noise, curpos.y - 1.55f, curpos.z);
                        birdformgo.transform.localPosition += newpos;
                        movingAnimationScript = "";
                        restingAnimationScript = "";
                        //BirdFlyHeight = 1.5f;
                        birdgo.name = birdresourcename;
                        if (person)
                        {
                            if (person.hasCamera)
                            {
                                person.AddCamera(birdformgo, "BirdCtrl CreateBirdFormGos");
                            }
                            if (person.grabbedMainCamera)
                            {
                                person.GrabMainCamera();
                            }
                        }
                        break;
                    }
            }
//            birdformgo.transform.parent = birdgo.transform;
            birdformgo.transform.SetParent(birdgo.transform, true);// should be false....

            lastbirdform = birdform;
        }
        public void NextForm()
        {
            switch(birdform)
            {
                case BirdFormE.car:
                    birdform = BirdFormE.sphere;
                    break;
                case BirdFormE.person:
                    birdform = BirdFormE.car;
                    break;
                case BirdFormE.hummingbird:
                    birdform = BirdFormE.person;
                    break;
                case BirdFormE.sphere:
                    birdform = BirdFormE.longsphere;
                    break;
                case BirdFormE.longsphere:
                    birdform = BirdFormE.hummingbird;
                    break;
            }
        }
        public void startAnimation()
        {

        }
        public void AdjustBirdHeight(float factor)
        {
            BirdFlyHeight *= factor;
        }
        public void CreateBirdGos(bool reset=true)
        {
            if (path == null) return;
            if (birdgo == null)
            {
                birdgo = new GameObject("Bird");
                gogeninst++;
            }

            CreateBirdFormGos();
            //birdgo.transform.parent = sman.rgo.transform;
            birdgo.transform.parent = birdgoes.transform;

            if (reset)
            {
                ResetBird();
            }
            lastcurpt = curpt;

            //Debug.Log("lp curpt:" + curpt+"  lastcurpt:"+lastcurpt);
        }
        void SetAtGoal()
        {
            if (BirdState == BirdStateE.atgoal) return;
            birdStopped = true;
            BirdState = BirdStateE.atgoal;
            initBirdSpeed = BirdSpeed;
            BirdSpeed = 0;
            SetAnimationScript();
        }
        void MoveBirdGos(float deltatime)
        {
            rundist += BirdSpeedFactor*BirdSpeed*deltatime; // deltaTime is time to complete last frame
            curpt = GetPathPoint(rundist);
            var curlookpt = GetPathPoint(rundist + lookaheadtime + deltatime,curpos:false);
            var delt = curpt - lastcurpt;
            if (deltatime > 0)
            {
                birdVelVek = delt / deltatime;
            }
            birdgo.transform.localPosition += delt;
            birdgo.transform.LookAt(curlookpt);
            lastcurpt = curpt;
            SetAnimationScript();
            

            // stop bird if past point
            if (rundist >= path.pathLength)
            {
                SetAtGoal();
            } 
            //Debug.Log("lp delt:" + delt + "  curpt:" + curpt + " lastcurpt:" + lastcurpt);
        }
        void DeleteBirdGos()
        {
            if(birdgo!=null)
            {
                Destroy(birdgo);
                birdgo = null;
            }
        }
        #region bird commands
        public void RefreshBirdGos()
        {
            DeleteBirdGos();
            CreateBirdGos();
        }
        public void ResetBird()
        {
            rundist = 0;
            MoveBirdGos(0);
            birdStopped = true;
            BirdState = BirdStateE.atstart;
            SetAnimationScript();
        }
        public void PauseBird()
        {
            birdStopped = true;
            BirdState = BirdStateE.stopped;
            BirdSpeed = 0;
            SetAnimationScript();
        }
        public void UnPauseBird()
        {
            StartBird();
        }
        string lastscript = "";
        void SetAnimationScript()
        {
            if (movingAnimationScript != "")
            {
                var acomp = birdformgo.GetComponent<Animator>();
                if (acomp != null)
                {
                    acomp.applyRootMotion = false;
                    var script = restingAnimationScript;
                    if (BirdState == BirdStateE.running && BirdSpeedFactor > 0.2f)
                    {
                        script = movingAnimationScript;
                    }
                    if (script != lastscript)
                    {
                        acomp.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(script);
                        PersonMan.UnsyncAnimation(acomp, script, "BirdCtrl");
                        //acomp.Play(script, 0, GraphAlgos.GraphUtil.GetRanFloat(0, 1));// unsync the animations for birdctrl

                    }
                    if (person)
                    {
                        person.perstate = PersonAniStateE.walking;
                    }
                    //Debug.Log("animationScript:" + movingAnimationScript + " loaded");
                }
                else
                {
                    Debug.Log("Could not find animatior component on birdformgo");
                }
            }
        }
        void ClearAimationScript()
        {
            var acomp = birdformgo.GetComponent<Animator>();
            if (acomp != null)
            {
                acomp.applyRootMotion = false;
                acomp.runtimeAnimatorController = null;
            }
            lastscript = "";
        }
        public void StartBird()
        {
            //Debug.Log("StartBird called");
            birdStopped = false;
            BirdSpeed = initBirdSpeed;
            if (BirdSpeed==0)
            {
                BirdSpeed = 1; // this should not happen
            }
            BirdState = BirdStateE.running;
            SetAnimationScript();
        }
        public void SetSpeed(float newspeed)
        {
            BirdSpeed = newspeed;
        }
        public void AdjustSpeed(float factor, float minspeed = 0)
        {
            BirdSpeed *= factor;
            if (BirdSpeed <= minspeed)
            {
                BirdSpeed = minspeed;
            }
        }
        public void DeleteBirdGosAndInit()
        {
            if (birdgo != null)
            {
                // need to delete old bird form or it will hang around
                Destroy(birdgo);
                birdgo = null;
            }
            initValues();
        }
        public PathPos GetBirdPos()
        {
            return pathpos;
        }
        #endregion

        void initValues()
        {
            BirdSpeed = 0;
            BirdFlyHeight = 1.5f;
            lookaheadtime = 1.1f;
            initBirdSpeed = 1;
            rundist = 0;
            curpt = Vector3.zero;
            birdform = BirdFormE.person;
            birdStopped = true;
            BirdState = BirdStateE.dormant;
            //Debug.Log("birdctrl initValues called");
        }
        void Start()
        {
            initValues();
            //Debug.Log("birdctrl starts called");
        }
        // Update is called once per frame
        void Update()
        {
            if (birdgo != null)
            {
                if (birdform != lastbirdform)
                {
                    CreateBirdFormGos();
                }
                MoveBirdGos(Time.deltaTime);
            }
        }
    }
}
