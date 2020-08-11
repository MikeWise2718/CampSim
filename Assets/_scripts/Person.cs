using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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
        public float scale;
        public Vector3 rotate;


        public void SetVisiblity(bool visstat)
        {
            isVisible = visstat;
        }
        public bool GetVisiblity()
        {
            return isVisible;
        }



        public void AddPrsDetails(PersonMan pm,PersonMan.GenderE gender,string persname,string avatartype,string avatarname, PersonMan.empStatusE empstat,bool hasHololens=false, float ska = 1, float xrot = 0, float yrot = 0, float zrot = 0)
        {
            this.pm = pm;
            this.bm = pm.sman.bdman;
            this.personGender = gender;
            this.personName = persname;
            this.avatarType = avatartype;
            this.avatarName = avatarname;
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
            this.rotate = new Vector3( xrot,yrot,zrot );
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
            var broom = bm.GetBroom(this.placeRoom);
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

        public GameObject CreatePersonGo(string callerSuffix)
        {
            var dirname = "People";
            var ispeople = true;
            if (avatarType!="Person")
            {
                dirname = avatarType;
                ispeople = false;
            }
            var pfab = GraphAlgos.GraphUtil.GetUniResPrefab(dirname, avatarName);
            var ipogo = Instantiate<GameObject>(pfab);// there is no global pogo at this point
            ipogo.name = "instance";
            ipogo.transform.localScale = new Vector3(scale, scale, scale);
            ipogo.transform.localRotation *= Quaternion.Euler( rotate );
            var pogo = new GameObject();
            ipogo.transform.parent = pogo.transform;
            //var animator = pogo.GetComponent<Animator>();
            //animator.applyRootMotion = false;
            //animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PersonIdle");
            if (ispeople)
            {
                persGo = ipogo.AddComponent<PersonGo>();
                persGo.Init(this);
                height = persGo.GetPersonHeight();
                if (this.hasHololens)
                {
                    AddHololens();
                }
            }
            pogo.name = this.name + callerSuffix;
            lastpogo = pogo;
            return pogo;
        }

        public GameObject CreatePersonGoOld(string callerSuffix)
        {
            var dirname = "People";
            var ispeople = true;
            if (avatarType != "Person")
            {
                dirname = avatarType;
                ispeople = false;
            }
            var pfab = GraphAlgos.GraphUtil.GetUniResPrefab(dirname, avatarName);
            var pogo = Instantiate<GameObject>(pfab);// there is no global pogo at this point
            pogo.name = "instance";
            pogo.transform.localScale = new Vector3(scale, scale, scale);
            pogo.transform.localRotation *= Quaternion.Euler(rotate);
            //var animator = pogo.GetComponent<Animator>();
            //animator.applyRootMotion = false;
            //animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/PersonIdle");
            if (ispeople)
            {
                persGo = pogo.AddComponent<PersonGo>();
                persGo.Init(this);
                height = persGo.GetPersonHeight();
                if (this.hasHololens)
                {
                    AddHololens();
                }
            }
            pogo.name = this.name + callerSuffix;
            lastpogo = pogo;
            return pogo;
        }

        public GameObject GetPogo(string callerSuffix,bool createpogo=false,bool resetposition=false)
        {
            if (createpogo)
            {
                return CreatePersonGo(callerSuffix);
            }
            if (resetposition)
            {
                lastpogo.transform.position = Vector3.zero;
                lastpogo.transform.localRotation = Quaternion.identity;
                persGo.Init(this);
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




        public void DeleteGos()
        {
            PersonGo pgo;
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
            //Debug.Log("Entered AddCamera ");
            if (pergo)
            {

               // Debug.Log("AddCamera adding camera for " + pergo.name+" caller:"+caller);
                followCamGo = new GameObject(name + "-cam");
                var offset = new Vector3(0, 1.9f, -0.5f);
                var quatrot = pergo.transform.localRotation;
                followCamGo.transform.localRotation = pergo.transform.localRotation;
                followCamGo.transform.position = pergo.transform.position + quatrot*offset;// have to rotate offset as the pergo is already rotated
                followCamGo.transform.parent = pergo.transform;

                //Debug.Log("pergo pos:" + pergo.transform.position.ToString("f3") + " offset:" + offset.ToString("f3"));
                var fcamcomp = followCamGo.AddComponent<Camera>();
                fcamcomp.targetDisplay = 2;
                hasCamera = true;
                if (grabbedMainCamera)
                {
                    var vcman = pm.sman.vcman;
                    vcman.SetMainCameraToCam(fcamcomp);
                    Camera.main.transform.parent = pergo.transform;
                }
            }
            else
            {
                Debug.Log("AddCamera called with null GameObject - caller:"+caller);
            }
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
