using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CampusSimulator
{
    public enum slotstateE { available, welcome, reserved, inactive, donotpark, pleaseverfiy,car_reserved,car_free,slot_reserved,slot_free }
    public enum slotPosE { center, front, back, left, right }

    public class GarageSlot : MonoBehaviour
    {
        string matname(slotstateE ss)
        {
            var path = "sign_materials/";
            switch (ss)
            {
                default:
                case slotstateE.available: return path +"sign_available";
                case slotstateE.welcome: return path + "sign_welcome";
                case slotstateE.reserved: return path + "sign_reserved";
                case slotstateE.inactive: return path + "sign_inactive";
                case slotstateE.donotpark: return path + "sign_donotpark";
                case slotstateE.pleaseverfiy: return path + "sign_pleaseverfiy";
                case slotstateE.car_free: return path + "sign_car_free";
                case slotstateE.car_reserved: return path + "sign_car_reserved";
                case slotstateE.slot_free: return path + "sign_slot_free";
                case slotstateE.slot_reserved: return path + "sign_slot_reserved";
            }
        }
        public string slotname { get; set; }
        public slotstateE slotstate;
        public bool occupied;
        public string carformname;
        public string nodename;
        public bool carreserved;
        public Vector3 frontvek;
        public Vector3 rsidevek;
        public Vector3 frontveknrm;
        public Vector3 rsideveknrm;
        public Rect carrect;
        public bool carrectok;
        public string group;
        public int groupnum;
        public int instance = 0;
        public string fullname;

        public bool connectedToGrid = false;

        public int num;
        public float x, z;
        public float ang;
        public float width;

        //public GameObject slot;
        public GameObject slotformgo;
        public GameObject floor;
        public GameObject parkbox;
        public GameObject raspibox;
        public GameObject sign;
        public GameObject cargo;
        public Garage garage;
        public Vehicle vehicle;
        // Use this for initialization


        public void Initialize(Garage garage, int num, float x, float z, float ang, float width,string group)
        {
            this.garage = garage;
            this.num = num;
            this.x = x;
            this.z = z;
            this.ang = ang;
            this.width = width;
            this.group = group;
            this.fullname = garage.name + "/" + this.name;
            this.slotstate = slotstateE.slot_free;
        }

        Rigidbody slotRigidBody;

        float slotlen = 6.2f;
        float slotwid = 2.0f;
        float slothit = 2.0f;
        //float rad2deg = 180f / Mathf.PI;
        float deg2rad = Mathf.PI / 180f;

        public void CreateObjects()
        {
            // have to defer
            //Debug.Log("start slot");

            if (slotformgo != null)
            {
                DeleteGos();
                //Debug.Log("opps slotformgo should be null:" + slotformgo.name);
            }

            this.slotformgo = new GameObject(name + "_formgo_" + instance);
            instance++;
            slotformgo.transform.parent = this.transform;
            var gm = garage.gm;
            var slotformselector = gm.slotform;
            //Debug.Log("Generating slotform:" + slotformselector);
            bool createfloor = gm.showFloor;
            bool createparkbox = gm.showParkbox;
            bool createsign = gm.showSign;
            bool createnode = gm.showNode;
            bool createraspi = gm.showRaspi;
            bool createcam = gm.showCam;
            createcam = false; // this is a performance killer as it creates very very many cameras - turning off for now
            bool createcar = gm.showCar;
            if (createfloor)
            {
                floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
                floor.transform.parent = slotformgo.transform;
                floor.name = "floor";
                var floorwid = 2.0f;
                floorwid = garage.slot2slotdist;
                floor.transform.localScale = new Vector3(slotlen, 0.01f, floorwid);
                var crenderer = floor.GetComponent<Renderer>();
                crenderer.material.color = Color.gray;
                crenderer.material.shader = Shader.Find("Diffuse");
                var clrdr = floor.GetComponent<Collider>();
                clrdr.enabled = false;
                //map.AddDrawingElement(new OnlineMapsDrawingRect(new Vector2(2, 2), new Vector2(1, 1), Color.green, 1,Color.blue));
            }
            if (createparkbox)
            {
                parkbox = GameObject.CreatePrimitive(PrimitiveType.Cube);
                parkbox.transform.parent = slotformgo.transform;
                parkbox.transform.localScale = new Vector3(slotlen, slothit, slotwid);
                parkbox.transform.position = new Vector3(0f, 0.9f, 0f);
                parkbox.name = "parkbox";
                var pbrenderer = parkbox.GetComponent<Renderer>();
                pbrenderer.material.color = new Color(0.5f, 0.5f, 0.5f, 0.5f); // transparent gray
                pbrenderer.material.shader = Shader.Find("Transparent/Diffuse");
                var clrdr = parkbox.GetComponent<Collider>();
                clrdr.enabled = false;
            }
            if (createsign)
            {
                sign = GameObject.CreatePrimitive(PrimitiveType.Cube);
                sign.transform.parent = slotformgo.transform;
                sign.name = "sign";
                sign.transform.localScale = new Vector3(0.1f, 0.5f, 1f);
                //        sign.transform.rotation = Quaternion.Euler(0, 90, 0);
                sign.transform.position = new Vector3(slotlen / 2, 1.2f, 0);
                SetSlotState(slotstate);
                var clrdr = sign.GetComponent<Collider>();
                clrdr.enabled = false;
            }
            if (createraspi)
            {
                raspibox = GameObject.CreatePrimitive(PrimitiveType.Cube);
                raspibox.transform.parent = slotformgo.transform;
                raspibox.name = "raspibox";
                raspibox.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                raspibox.transform.position = new Vector3(slotlen / 2, 0.62f, 0);
                var rrenderer = raspibox.GetComponent<Renderer>();
                rrenderer.material.color = Color.white;
                var clrdr = raspibox.GetComponent<Collider>();
                clrdr.enabled = false;
            }
            if (createcam)
            {
                // this is wrong
                // see this: https://gamedev.stackexchange.com/questions/57841/creating-multiple-instances-of-a-camera-at-run-time

                //var original = GameObject.FindWithTag("MainCamera");
                //var cam = (Camera)Camera.Instantiate(
                //    original.GetComponent<Camera>(),
                //    raspibox.transform.position,
                //    Quaternion.FromToRotation(Vector3.forward, Vector3.left));
                //cam.name = "raspicam";

                var camgo = new GameObject("raspicam");
                var cam = camgo.AddComponent<Camera>();
                cam.transform.position = raspibox.transform.position;
                cam.transform.rotation = Quaternion.FromToRotation(Vector3.forward, Vector3.left);
                cam.transform.parent = raspibox.transform;
                cam.fieldOfView = 30f;
                cam.nearClipPlane = 0.1f; // 10 cm
                cam.targetDisplay = 8;
            }
            if (createnode)
            {
                //var node = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                var clr = (occupied ? "red" : "cyan");
                var node = GraphAlgos.GraphUtil.CreateMarkerSphere("slotnode", Vector3.zero,size:0.5f, clr: clr);
                node.transform.parent = slotformgo.transform;
                var rrenderer = node.GetComponent<Renderer>();
                //rrenderer.material.color = (occupied ? Color.red : Color.cyan);
                var clrdr = node.GetComponent<Collider>();
                clrdr.enabled = false;
            }

            if (createcar && occupied)
            {
                //carname = "hummingbird";
                // carname = "Car003";
                //var objPrefab = getcargo(carformname);
                //cargo = Instantiate<GameObject>(objPrefab);
                cargo = VehicleMan.LoadCarGo(slotformgo, carformname);
                neutercargo(cargo);
                //cargo.transform.parent = slotformgo.transform;
                //cargo.transform.position = slotformgo.transform.position + cargo.transform.position;
                //cargo.transform.rotation = slotformgo.transform.rotation;
                //cargo.transform.Rotate(new Vector3(0, 90, 0));
                //cargo.transform.Translate(new Vector3(0, 0, -0.4f));
            }
            calcVeks();
            var y = gm.sman.mpman.GetHeight(x, z);
            slotformgo.transform.position = new Vector3(x, y, z);
            slotformgo.transform.rotation = Quaternion.Euler(0, ang + 90, 0);
        }
        void neuterwheel(GameObject cargo,string wename)
        {
            var wegot = cargo.transform.Find(wename);
            if (!wegot) return;
            var wego = wegot.gameObject;
            var cldr = wego.GetComponent<WheelCollider>();
            if (!cldr) return;
            cldr.enabled = false;
            var rigid = wego.GetComponent<Rigidbody>();
            rigid.isKinematic = true;
            Destroy(cldr);
            Destroy(rigid);
        }
        void neutercargo(GameObject cargo)
        { 
            var cldr = cargo.GetComponent<MeshCollider>();
            if (!cldr) return;
            cldr.enabled = false;
            Destroy(cldr);
            neuterwheel(cargo, "Wheel_Front_L");
            neuterwheel(cargo, "Wheel_Front_R");
            neuterwheel(cargo, "Wheel_Rear_L");
            neuterwheel(cargo, "Wheel_Rear_R");
        }
        //static Dictionary<string, GameObject> cardict = new Dictionary<string, GameObject>();
        //GameObject getcargo(string name)
        //{
        //    if (!cardict.ContainsKey(name))
        //    {
        //        //Debug.Log("since not in dict loading " + name);
        //        var realname = "Cars/" + name;
        //        var cargo = (GameObject)Resources.Load(realname);
        //        cardict[name] = cargo;
        //        //Debug.Log("stored " + name + " in dict:" + cardict.Count);
        //    }
        //    return cardict[name];
        //}


        public void SetConnectedToGrid()
        {
            connectedToGrid = true;
        }
        public void VehicleOccupy(Vehicle vehicle)
        {
            //    Debug.Log(name + " now occupied by " + carname);
            occupied = true;
            this.vehicle = vehicle; 
            this.carformname = vehicle.formName;
            this.carreserved = false; // give up cars
            SetSlotState(slotstateE.car_free);
            DeleteGos(); // makes sense to redo all the goes because the car has to be created
            CreateGos();
        }
        public void Vacate()
        {
            // Debug.Log(name + " vacated");
            occupied = false;
            carreserved = false;
            this.carformname = "";
            this.vehicle = null;
            SetSlotState(slotstateE.slot_free);
            DeleteGos(); // makes sense to redo all the goes because the car has to be destroyed
            CreateGos();
        }
        public bool ReserveSlot()
        {
            if (occupied) return false;
            //  Debug.Log(name + " reserved");
            SetSlotState(slotstateE.slot_reserved);
            //DeleteGos(); // no need to recreate goes
            //CreateGos();
            return true;
        }
        public bool UnReserveSlot()
        {
            if (occupied) return false;
            //  Debug.Log(name + " reserved");
            SetSlotState(slotstateE.slot_free);
            //DeleteGos(); // no need to recreate goes
            //CreateGos();
            return true;
        }
        public bool ReserveCar()
        {
            if (!occupied) return false;
            SetSlotState(slotstateE.car_reserved);
            carreserved = true;
            return true;
        }
        public bool UnReserveCar()
        {
            if (!occupied) return false;
            SetSlotState(slotstateE.car_free);
            carreserved = true;
            return true;
        }
        void calcVeks()
        {
            frontvek = slotformgo.transform.TransformVector(new Vector3(slotlen / 2, 0, 0));
            frontveknrm = Vector3.Normalize(frontvek);
            rsidevek = Quaternion.Euler(0, 90, 0) * frontveknrm;
            rsideveknrm = Vector3.Normalize(rsidevek);
            rsidevek = (slotwid / 2) * rsideveknrm;
        }
        public Vector3 GetPosition()
        {
            if (slotformgo != null)
            {
                return slotformgo.transform.position;
            }
            var y = this.garage.gm.sman.mpman.GetHeight(x, z);
            return new Vector3(x, y, z);
        }
        public Vector3 GetPosition(slotPosE slotpos)
        {
            var rv = GetPosition();
            calcVeks();
            switch (slotpos)
            {
                default:
                case slotPosE.center: break;
                case slotPosE.front:
                    rv += frontvek;
                    break;
                case slotPosE.back:
                    rv -= frontvek;
                    break;
                case slotPosE.left:
                    rv -= rsidevek;
                    break;
                case slotPosE.right:
                    rv += rsidevek;
                    break;
            }
            return rv;
        }
        public Vector3 GetPosition1(float ang, float distfak)
        {
            var rv = GetPosition();
            ang *= deg2rad;
            calcVeks();
            var s = Mathf.Sin(ang);
            var c = Mathf.Cos(ang);
            rv += distfak * (c * frontveknrm + s * rsideveknrm);
            return rv;
        }
        public Vector3 GetPosition2(float ang1, float len1, float ang2, float len2)
        {
            var rv = GetPosition();
            ang1 *= deg2rad;
            calcVeks();
            var s1 = Mathf.Sin(ang1);
            var c1 = Mathf.Cos(ang1);
            rv += len1 * (c1 * frontveknrm + s1 * rsideveknrm);
            var s2 = Mathf.Sin(ang2);
            var c2 = Mathf.Cos(ang2);
            rv += len2 * (c2 * frontveknrm + s2 * rsideveknrm);
            return rv;
        }

        public void SetSlotState(slotstateE state)
        {
            var mname = matname(state);
            Material newmat = Resources.Load(mname, typeof(Material)) as Material;
            slotstate = state;
            //Debug.Log("matname:"+mname+"newmat:" + newmat.ToString());
            if (sign != null)
            {
                var srenderer = sign.GetComponent<Renderer>();
                srenderer.material = newmat;
                srenderer.material.mainTextureScale = new Vector2(1f, 1f);
            }
        }
        public void DeleteGos()
        {
            if (slotformgo != null)
            {
                //       Debug.Log("Destroying " + slotformgo.name);
                UnityEngine.Object.Destroy(slotformgo);
                slotformgo = null;
            }
        }
        public void CreateGos()
        {
            CreateObjects();
        }


        //private void OnGUI()
        //{
        //    if (garage.gm.showCarRects)
        //    {
        //        //GUI.Label(carrect, "Hello World!");
        //        if (carrectok)
        //        {
        //            GraphAlgos.GraphUtil.GUIDrawRectFrame(carrect, garage.gm.carRectColor, linwid: garage.gm.carRectLineWidth);
        //        }
        //    }
        //}
        public void EmptyAndDestroy()
        {
            Object.Destroy(slotformgo);
            slotformgo = null;
        }
        // Update is called once per frame
        //void Update()
        //{
        //    //if (garage.gm.showCarRects)
        //    //{
        //    //    if (slotformgo != null)
        //    //    {
        //    //        if (cargo != null)
        //    //        {
        //    //            carrect = GraphAlgos.GraphUtil.GUIRectWithObject(cargo);
        //    //            carrectok = GraphAlgos.GraphUtil.ClipToScreen(carrect);
        //    //            if (carrectok)
        //    //            {
        //    //                var cmt = carname + " parked in " + garage.name;
        //    //                cmt += " Sc w,h:" + Screen.width + "," + Screen.height;
        //    //                garage.gm.vman.AddFoundLabel("car", carrect, cmt);
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //}
    }
}