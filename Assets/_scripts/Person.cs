using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace CampusSimulator
{
    public enum PersonStateE { fixedPerson, freeToTravel, WaitingToTravel, Traveling, Untraveling }
    public class Person : MonoBehaviour
    {
        PersonMan pm=null;
        BuildingMan bm = null;
        public PersonMan.GenderE personGender;
        public string personName = "";
        public string avatarType = "";
        public string avatarName = "";
        public string avatarNameMoving = "";
        public PersonStateE personState=PersonStateE.freeToTravel;
        public string idleScript = "";
        public string danceScript = "";
        public string walkScript = "";
        public string homeBld = "";
        public string homeRoom = "";
        public string homeNode = "";
        public float homeRotate = 0;
        public string placeBld = "";
        public string placeRoom = "";
        public string placeNode = "";
        public int roomPlaceIdx= 0;
        public bool roomPlaceFixed = false;
        public GameObject roomPogo;
        public bool toggleHololens = false;
        public bool toggleCamera = false;
        public bool toggleMainCamera = false;
        public bool grabbedMainCamera =false;
        public bool sendOnJourney = false;
        public GameObject followCamGo=null;
        public bool hasCamera=false;
        public bool hasHololens = false;
        public GameObject hololensGo = null;
        public PersonGo persGo=null;
        public float height=1.8f;
        public PersonMan.empStatusE empStatus;
        public Journey journey = null;
        public bool flagged = false;
        public PersonAniStateE perstate = PersonAniStateE.standing;
        public bool isVisible = true;
        public bool isdronelike = false;
        public float scale;
        public Vector3 rotate;
        public Vector3 tran;


        public void SetVisiblity(bool visstat)
        {
            isVisible = visstat;
        }
        public bool GetVisiblity()
        {
            return isVisible;
        }



        public void AddPrsDetails(PersonMan pm,PersonMan.GenderE gender,string persname,string avatartype,string avatarname, PersonMan.empStatusE empstat,bool hasHololens, float ska,Vector3 rot, Vector3 trans)
        {
            this.pm = pm;
            this.bm = pm.sman.bdman;
            this.personGender = gender;
            this.personName = persname;
            this.avatarType = avatartype;
            this.avatarName = avatarname;
            this.avatarNameMoving = avatarname;
            this.idleScript = "";
            this.walkScript = "";
            this.danceScript = "";
            this.placeBld = "";
            this.placeNode = "";
            this.perstate = PersonAniStateE.standing;
            this.homeBld = "";
            this.homeRoom = "";
            this.homeNode = "";
            this.empStatus = empstat;
            this.hasHololens = hasHololens;
            this.scale = ska;
            this.rotate = rot;
            this.tran = trans;
            //this.prsgos = new List<GameObject>();
        }

        public Building GetBuilding()
        {
            var bld = bm.GetBuilding(this.placeBld);
            return bld;
        }
        public void AssignHomeLocation( string bldname, string roomname, string nodename, bool homeRoomPlacefixed = false,float homeRotate=0)
        {
            this.roomPlaceFixed = homeRoomPlacefixed;
            this.homeBld = bldname;
            this.homeRoom = roomname;
            this.homeNode = nodename;
            this.homeRotate = homeRotate;

            this.placeBld = bldname;
            this.placeRoom = roomname;
            this.placeNode = nodename;
            var broom = bm.GetBroom(this.placeRoom,expectFailure:true);
            if (broom==null)
            {
                var bpad = bm.GetBpad(this.placeRoom);
                if (bpad==null)
                {
                    Debug.LogError($"Person.AssignHomeLocation error lookin up placeRoom:{placeRoom}");
                    return;
                }
            }
            bm.AssociateNodeWithRoom(placeNode, broom);
        }
        public bool IsInHomeBuilding()
        {
            return placeBld == homeBld;
        }
        public bool IsInHomeRoom()
        {
            return placeBld == homeBld && placeRoom==homeRoom;
        }
        public bool UseFixedPlace()
        {
            return IsInHomeRoom() && roomPlaceFixed;
        }

        public enum BodyPart { body, head, rightIndexFinger,leftIndexFinger }

        public GameObject GetBodyPart(BodyPart part)
        {
            if (persGo == null) return null;
            return persGo.GetBodyPart(part);
        }

        GameObject lastpogo;

        public GameObject CreatePersonGo(string callerSuffix, bool moving = false)
        {
            var dirname = "People";
            var ispeople = true;
            if (avatarType != "Person")
            {
                dirname = avatarType;
                ispeople = false;
            }
            var avatarNameUse = (moving ? avatarNameMoving : avatarName);
            //SceneMan.Lggg($"Loading {avatarNameUse}  scale:{scale}","pink");
            //if (scale>1)
            //{
            //    SceneMan.Lggg($"  scale>1", "pink");
            //}
            var pfab = GraphAlgos.GraphUtil.GetUniResPrefab(dirname, avatarNameUse);
            var ipogo = Instantiate<GameObject>(pfab);// there is no global pogo at this point
            ipogo.name = "instance";
            ipogo.transform.localScale = new Vector3(scale, scale, scale);
            ipogo.transform.localRotation *= Quaternion.Euler(rotate);
            ipogo.transform.position = tran;
            var pogo = new GameObject();
            ipogo.transform.SetParent(pogo.transform, worldPositionStays: false);
            //var animator = pogo.GetComponent<Animator>();
            //animator.applyRootMotion = false;
            //animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PersonIdle");
            if (ispeople)
            {
                persGo = ipogo.AddComponent<PersonGo>();
                persGo.Init(this, lastpogo);
                height = persGo.GetPersonHeight();
                if (this.hasHololens)
                {
                    AddHololens();
                }
            }
            pogo.name = this.name + callerSuffix;

            var cc = pogo.AddComponent<CapsuleCollider>();
            cc.center = new Vector3(0, 0.9f, 0);
            cc.radius = 0.25f;
            cc.height = 1.8f;

            lastpogo = pogo;
            return pogo;
        }



        public GameObject GetPogo(string callerSuffix,bool createpogo=false,bool resetposition=false,bool moving=false)
        {
            if (createpogo)
            {
                var pogo = CreatePersonGo(callerSuffix,moving:moving);
                return pogo;
            }
            if (resetposition)
            {
                lastpogo.transform.position = Vector3.zero;
                lastpogo.transform.localRotation = Quaternion.identity;
                persGo.Init(this, lastpogo);
                persGo = null;
            }
            return lastpogo;
        }


        public string GetWaitNodeName()
        {
            if (IsInHomeRoom() && roomPlaceFixed)
            {
                return homeNode;
            }
            //
            var broom= bm.GetBroom(this.placeRoom);
            return broom.roomNodeName;
        }

        public void AssignCurLocation(string bldname, string roomname,string nodename)
        {
            this.placeBld = bldname;
            this.placeRoom = roomname;
            this.placeNode = nodename;
            if (IsInHomeRoom() && roomPlaceFixed)
            {
                this.placeNode = this.homeNode;
            }
        }
        public bool InBuilding(string bname)
        {
            return placeBld == bname;
        }
        public bool NotTravelingInBuilding(string bname)
        {
            var rv = (placeBld == bname) && (personState == PersonStateE.freeToTravel);
            return rv;
        }

        public void PersonStateStartWaitingToTravel()
        {
            personState = PersonStateE.WaitingToTravel;
        }
        public void PersonStateFinishTraveling()
        {
            personState = PersonStateE.freeToTravel;
        }
        public void PersonStateStartUntraveling(string placename, string placenode)
        {
            personState = PersonStateE.Untraveling;
            this.placeBld = placename;
            this.placeNode = placenode;
        }
        public void PersonStateStartTraveling()
        {
            personState = PersonStateE.Traveling;
            placeNode = "traveling";
        }

        public BldRoom GetCurrentRoom()
        {
            BldRoom rv = null;
            if (bm.IsRoom(placeRoom))
            {
                rv = bm.GetBroom(placeRoom);
            }
            return rv;
        }

        public BldDronePad GetCurrentPad()
        {
            BldDronePad rv = null;
            if (bm.IsPad(placeRoom))
            {
                rv = bm.GetBpad(placeRoom);
            }
            return rv;
        }





        public void DeleteGos()
        {
            // PersonGo pgo;
            // delete persongo
        }
        public void CreateGos()
        {
            // create persongo
            //this.persGo = LoadPersonGo("-ava-br");
        }
        int updatecount = 0;

        public void AddCamera(GameObject pergo,string caller)
        {
            // Not using these at the moment so turned off

            //Debug.Log("Entered AddCamera ");
            //if (pergo)
            // {

            //   // Debug.Log("AddCamera adding camera for " + pergo.name+" caller:"+caller);
            //    followCamGo = new GameObject(name + "-cam");
            //    var offset = new Vector3(0, 1.9f, -0.5f);
            //    var quatrot = pergo.transform.localRotation;
            //    followCamGo.transform.localRotation = pergo.transform.localRotation;
            //    followCamGo.transform.position = pergo.transform.position + quatrot*offset;// have to rotate offset as the pergo is already rotated
            //    followCamGo.transform.parent = pergo.transform;

            //    //Debug.Log("pergo pos:" + pergo.transform.position.ToString("f3") + " offset:" + offset.ToString("f3"));
            //    var fcamcomp = followCamGo.AddComponent<Camera>();
            //    fcamcomp.targetDisplay = 8;
            //    hasCamera = true;
            //    if (grabbedMainCamera)
            //    {
            //        var vcman = pm.sman.vcman;
            //        vcman.SetMainCameraToCam(fcamcomp);
            //        Camera.main.transform.parent = pergo.transform;
            //    }
            //}
            //else
            //{
            //    Debug.Log("AddCamera called with null GameObject - caller:"+caller);
            //}
        }
        public void DelCamera()
        {
            if (hasCamera)
            {
                Destroy(followCamGo);
                followCamGo = null;
                hasCamera = false;
            }
        }
        public string grabLastCamSet = "";
        public void GrabMainCamera()
        {
            var vcman = pm.sman.vcman;
            if (!followCamGo)
            {
                AddNewCamera("GrabMainCamera");
            }
            var followCam = followCamGo.GetComponent<Camera>();
            grabLastCamSet = vcman.lastcamset;
            vcman.SetMainCameraToCam(followCam);
            Camera.main.transform.parent = followCamGo.transform.parent.transform;
            //Debug.Log("GrabMainCamera - followCamGo Parent is " + followCamGo.transform.parent.name);
            //Camera.main.transform.parent = personGo.transform;
            Camera.main.transform.localRotation = followCam.transform.localRotation;
            grabbedMainCamera = true;
        }
        public void AddNewCamera(string fromwhere)
        {
            if (!hasCamera)
            {
                AddCamera(persGo.gameObject, fromwhere);
            }
        }
        public void ReleaseMainCamera()
        {
            var vcman = pm.sman.vcman;
            Camera.main.transform.parent = null;
            vcman.SetMainCameraToVcam(grabLastCamSet);
            grabbedMainCamera = false;
        }
        public void AddHololens()
        {
            var prefabgo = Resources.Load<GameObject>("Models/HololensCylinder");
            hololensGo = Instantiate<GameObject>(prefabgo);
            hololensGo.transform.localRotation = persGo.transform.localRotation;
            hololensGo.transform.Rotate(new Vector3(0, -90, 0));
            var hloffset = persGo.GetHoloLensOffset();
            hololensGo.transform.position = persGo.transform.position + hloffset;
            var partname = persGo.GetHeadPartPath();
            //Debug.Log("Getting hlparent for " + name+" avatarname:"+avatarName+" partname:"+partname);
            var hlparent = GraphAlgos.GraphUtil.GetPart(persGo.gameObject, partname);
            if (!hlparent)
            {
                Debug.LogError("AddHololens - Head Part not found for "+this.personName);
                return;
            }
            //Debug.Log("hlparent found:" + hlparent.name);
            hololensGo.name = "HoloLens";
            hololensGo.SetActive(false);
            hololensGo.transform.parent = hlparent.transform;
        }
        public void DelHololens()
        {
            Destroy(hololensGo);
        }
        public void ActivateHololens(bool activeval)
        {
            if (!hololensGo)
            {
                Debug.Log(personName + " Hololens is null");
                return;
            }
            var partname = persGo.GetHeadPartPath();
            var hlparent = GraphAlgos.GraphUtil.GetPart(persGo.gameObject,partname);
            var hlgo = hlparent.transform.Find("HoloLens");
            if (!hlgo)
            {
                Debug.Log("Could not find HoloLens for " + personName);
                return;
            }
            hlgo.gameObject.SetActive(activeval);
            //Debug.Log("activated " + personName + " hololens");
        }
        // Update is called once per frame

        void Update()
        {
            //if (name=="Cathy Ray")
            //{
            //    Debug.Log("Cathy " + updatecount);
            //}
            if (toggleHololens)
            {
                if (!hasHololens)
                {
                    ActivateHololens(true);
                    hasHololens = true;
                }
                else
                {
                    ActivateHololens(false);
                    hasHololens = false;
                }
                toggleHololens = false;
            }
            if (toggleCamera)
            {
                if (!followCamGo)
                {
                    AddNewCamera("Person Update");
                }
                else
                {
                    DelCamera();
                }
                toggleCamera = false;
            }
            if (sendOnJourney)
            {
                pm.sman.jnman.AddPersonJourney(this);
                sendOnJourney = false;
            }
            if (toggleMainCamera)
            {
                var vcman = pm.sman.vcman;
                if (!grabbedMainCamera)
                {
                    GrabMainCamera();
                }
                else
                {
                    ReleaseMainCamera();
                }
                toggleMainCamera = false;
            }
            updatecount++;
        }
    }
}
