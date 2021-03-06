﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphAlgos;
using System.ComponentModel.Design.Serialization;
using UnityEngine.UIElements;
using Aiskwk.Map;

namespace CampusSimulator
{
    public enum BirdFormE { none, sphere, longsphere, hummingbird, person,dog, car,drone,drone2,drone3,drone4,heli }
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
        public float birdscale = 1;
        public bool lookatpoint = true;
        public bool flatlookatpoint = false;

        public PathPos pathpos = null;
        public Weg pathweg = null;
        public float wegdistance = 0;
        public Guid wegguid = Guid.Empty;
        public string swegguid = Guid.Empty.ToString();
        public int cntgp = 0;
        public Vector3 moveoffset = new Vector3(0.3f, -1.45f, 0);

        static public GameObject birdgoes = null;
        public Person person = null;
        public GameObject birdgo=null;

        Path path = null;

        public bool IsRunning() { return (BirdState == BirdStateE.running); }
        public bool IsAtStart() { return (BirdState == BirdStateE.atstart); }
        public bool IsAtGoal() { return (BirdState == BirdStateE.atgoal); }

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

        (Vector3 pt,bool fragable,LinkUse lu) GetPathPoint(float gpprdist,bool setpathpos=true)
        {
            var fragable = false;
            if (path == null) return (Vector3.zero,fragable,LinkUse.legacy);
            PathPos pp = path.MovePositionAlongPath(gpprdist);
            fragable = pp.weg.link.IsFragable();
            var lu = pp.weg.link.usetype;
            if (setpathpos)
            {
                pathpos = pp;
                pathweg = pp.weg;
                wegguid = pp.weg.id;
                swegguid = wegguid.ToString();
                wegdistance = pp.wegDistSoFar;
                cntgp++;
            }
            var yval = pp.pt.y;
            if (fragable)
            {
            //    sman.Lgg($"before curpt:{curpt}","amber");
                yval = sman.mpman.GetHeight(pp.pt.x, pp.pt.z);
            //    sman.Lgg($"after  curpt:{curpt}", "light green");
            }
            var pt = new Vector3(pp.pt.x, yval + BirdFlyHeight, pp.pt.z);

            //var pt = new Vector3(pp.pt.x, pp.pt.y + BirdFlyHeight, pp.pt.z);
            //var pt = new Vector3(pp.pt.x, pp.pt.y + 0, pp.pt.z);
            return (pt,fragable,lu);
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
                case BirdFormE.heli:
                    {
                        var objPrefab = Resources.Load<GameObject>("obj3d/bell412spinning");
                        birdformgo = Instantiate<GameObject>(objPrefab);
                        var s = sman.trman.dronescalemodelnumber.Get();
                        if (birdscale > 0)
                        {
                            s *= birdscale;
                        }
                        birdformgo.transform.localScale = new Vector3(s, s, s);
                        birdformgo.transform.localRotation = currot;
                        birdformgo.transform.localPosition = curpos;
                        movingAnimationScript = "";
                        restingAnimationScript = "";
                        BirdFlyHeight = 100f;
                        birdgo.name = "Bell";
                        break;
                    }
                case BirdFormE.drone:
                    {
                        var objPrefab = Resources.Load<GameObject>("obj3d/quadcopterspinning");
                        birdformgo = Instantiate<GameObject>(objPrefab);
                        var s = sman.trman.dronescalemodelnumber.Get();
                        if (birdscale > 0)
                        {
                            s *= birdscale;
                        }
                        birdformgo.transform.localScale = new Vector3(s, s, s);
                        birdformgo.transform.localRotation = currot;
                        birdformgo.transform.localPosition = curpos;
                        movingAnimationScript = "";
                        restingAnimationScript = "";
                        BirdFlyHeight = 10f;
                        birdgo.name = "Phantom";
                        break;
                    }
                case BirdFormE.drone2:
                    {
                        var objPrefab = Resources.Load<GameObject>("obj3d/DJI_Mavic_Air_2spinning");
                        birdformgo = Instantiate<GameObject>(objPrefab);
                        var s = 0.01f*sman.trman.dronescalemodelnumber.Get();
                        if (birdscale > 0)
                        {
                            s *= birdscale;
                        }
                        birdformgo.transform.localScale = new Vector3(s, s, s);
                        birdformgo.transform.localRotation = currot*Quaternion.Euler(-90,0,0);
                        birdformgo.transform.localPosition = curpos;
                        movingAnimationScript = "";
                        restingAnimationScript = "";
                        BirdFlyHeight = 10f;
                        birdgo.name = "Mavic2";
                        break;
                    }
                case BirdFormE.drone3:
                    {
                        var objPrefab = Resources.Load<GameObject>("obj3d/delivery_drone_v2spinning");
                        birdformgo = Instantiate<GameObject>(objPrefab);
                        var s = 0.01f * sman.trman.dronescalemodelnumber.Get();
                        if (birdscale > 0)
                        {
                            s *= birdscale;
                        }
                        birdformgo.transform.localScale = new Vector3(s, s, s);
                        birdformgo.transform.localRotation = currot * Quaternion.Euler(-90, 0, 0);
                        birdformgo.transform.localPosition = curpos;
                        movingAnimationScript = "";
                        restingAnimationScript = "";
                        BirdFlyHeight = 10f;
                        birdgo.name = "DelDrone";
                        break;
                    }
                case BirdFormE.drone4:
                    {
                        var objPrefab = Resources.Load<GameObject>("obj3d/matrice_600spinning");
                        birdformgo = Instantiate<GameObject>(objPrefab);
                        //var s = 0.01f * sman.trman.dronescalemodelnumber.Get();
                        var s = sman.trman.dronescalemodelnumber.Get();
                        if (birdscale > 0)
                        {
                            s *= birdscale;
                        }
                        birdformgo.transform.localScale = new Vector3(s, s, s);
                        //birdformgo.transform.localRotation = currot * Quaternion.Euler(-90, 0, 0);
                        birdformgo.transform.localRotation = currot;
                        birdformgo.transform.localPosition = curpos;
                        movingAnimationScript = "";
                        restingAnimationScript = "";
                        BirdFlyHeight = 10f;
                        birdgo.name = "Matrice600";
                        break;
                    }
                case BirdFormE.dog:
                    {
                        var objPrefab = Resources.Load<GameObject>("dogs/shepherd");
                        birdformgo = Instantiate<GameObject>(objPrefab);
                        var s = 0.01f * sman.trman.peoplescalemodelnumber.Get();
                        if (birdscale > 0)
                        {
                            s *= birdscale;
                        }
                        birdformgo.transform.localScale = new Vector3(s, s, s);
                        birdformgo.transform.localRotation = currot;// * Quaternion.Euler(-90, 0, 0);
                        birdformgo.transform.localPosition = curpos;
                        movingAnimationScript = "";
                        restingAnimationScript = "";
                        //BirdFlyHeight = 10f;
                        birdgo.name = "Shepard";
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
                            //birdformgo = person.CreatePersonGo("-ava-bc");// bird journey person
                            birdformgo = person.GetPogo("-ava-bc",createpogo:true,resetposition:false,moving:true);// bird journey person
                            if (person.hasHololens)
                            {
                                person.ActivateHololens(true);
                            }
                        }
                        else
                        {
                            var resname = birdresourcename;
                            if (birdresourcename!="" && !birdresourcename.StartsWith("people"))
                            {
                                resname = $"people/{birdresourcename}";
                            }
                            var objPrefab = Resources.Load<GameObject>(resname);
                            if (objPrefab==null)
                            {
                                objPrefab = Resources.Load<GameObject>("people/girl004");
                            }
                            birdformgo = Instantiate<GameObject>(objPrefab);
                        }
                        var s = sman.trman.peoplescalemodelnumber.Get();
                        if (birdscale>0)
                        {
                            s *= birdscale;
                        }
                        birdformgo.transform.localScale = new Vector3(s, s, s);
                        //if (lookatpoint)
                        //{
                        birdformgo.transform.localRotation = currot;
                        //}
                        //var noise = GraphAlgos.GraphUtil.GetRanFloat(0, 0.6f,"jnygen");
                        birdformgo.transform.localPosition = curpos + moveoffset;
                        //BirdFlyHeight = 1.5f;
                        birdgo.name = birdresourcename;
                        movingAnimationScript = "Animations/PersonWalk";
                        restingAnimationScript = "Animations/PersonIdle";
                        if (person!=null)
                        {
                            if (person.isdronelike)
                            {
                                movingAnimationScript = "";
                                restingAnimationScript = "";
                            }
                        }
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
                        var s = sman.trman.vehiclescalemodelnumber.Get();
                        birdformgo.transform.localScale = new Vector3(s, s, s);
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
        public void StartAnimation()
        {
            SetAnimationScript();
        }
        public void StopAnimation()
        {
            ClearAimationScript();
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
        public bool dragMarkerSphere = true;
        GameObject draggo;
        string dragclr = "red";
        void MoveBirdGos(float deltatime)
        {
            rundist += BirdSpeedFactor*BirdSpeed*deltatime; // deltaTime is time to complete last frame
            bool fragable;
            LinkUse lu1;
            (curpt,fragable,lu1) = GetPathPoint(rundist,setpathpos:true);
            var delt = curpt - lastcurpt;
            if (deltatime > 0)
            {
                birdVelVek = delt / deltatime;
            }
            birdgo.transform.localPosition += delt;
            if (lookatpoint)
            {
                var (curlookpt,_,lu2) = GetPathPoint(rundist + lookaheadtime + deltatime, setpathpos: false);
                if (lu1==LinkUse.stairs || lu2 == LinkUse.stairs || flatlookatpoint)
                {
                    var flatlookpt = new Vector3(curlookpt.x, curpt.y, curlookpt.z);
                    if (flatlookpt.magnitude > 0.1f)
                    {
                        birdgo.transform.LookAt(flatlookpt);
                    }
                }
                else
                {
                    birdgo.transform.LookAt(curlookpt);
                }
            }
            if (dragMarkerSphere)
            {
                if (draggo == null)
                {
                    draggo = GraphAlgos.GraphUtil.CreateMarkerSphere("dragsphere", curpt, clr: dragclr);
                }
                else
                {
                    dragclr = "blue";
                    var yval = curpt.y - BirdFlyHeight;
                    if (fragable)
                    {
                        dragclr = "blue";
                        yval = sman.mpman.GetHeight(curpt.x, curpt.z);
                    }
                    var dragpt = new Vector3(curpt.x, yval, curpt.z);
                    draggo.transform.position = dragpt;
                    GraphAlgos.GraphUtil.SetColorOfGo(draggo, dragclr);
                }
            }

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
        public string lastscript = "";
        void SetAnimationScript()
        {
            if (movingAnimationScript != "")
            {
                var acomp = birdformgo.GetComponentInChildren<Animator>();
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
                        lastscript = script;
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
                    Debug.LogWarning($"Could not find animator on birdformgo for script:{movingAnimationScript}");
                }
            }
        }
        void ClearAimationScript()
        {
            if (birdformgo == null)
            {
                sman.LggWarning("birdformgo is null in BirdCtrl.ClearAnimationScript");
                return;
            }
            var acomp = birdformgo.GetComponentInChildren<Animator>();
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
            InitValues();
        }
        public PathPos GetBirdPos()
        {
            return pathpos;
        }
        #endregion

        void InitValues()
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
            InitValues();
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
