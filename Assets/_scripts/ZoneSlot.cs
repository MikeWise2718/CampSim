using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CampusSimulator
{
    public enum zslotstateE { available, welcome, reserved, inactive, donotpark, pleaseverfiy }
    public enum zslotPosE { center, front, back, left, right }

    public class ZoneSlot : MonoBehaviour
    {
        string matname(zslotstateE ss)
        {
            var path = "sign_materials/";
            switch (ss)
            {
                default:
                case zslotstateE.available: return path +"sign_available";
                case zslotstateE.welcome: return path + "sign_welcome";
                case zslotstateE.reserved: return path + "sign_reserved";
                case zslotstateE.inactive: return path + "sign_inactive";
                case zslotstateE.donotpark: return path + "sign_donotpark";
                case zslotstateE.pleaseverfiy: return path + "sign_pleaseverfiy";
            }
        }
        public Zone zone;
        public zslotstateE slotstate;
        public bool occupied;
        public Person person;
        public string persname;
        public string avatarname;
        public string nodename;
        public float avatarrotate;
        public bool slotreserved;
        public Vector3 frontvek;
        public Vector3 rsidevek;
        public Vector3 frontveknrm;
        public Vector3 rsideveknrm;
        public Rect persrect;
        public bool persrectok;
        public string fullname;

        public int instance = 0;

        public bool connected = false;

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
        public GameObject persgo;
        // Use this for initialization

        public void Initialize(Zone zone, int num, float x, float z, float ang, float width)
        {
            this.zone = zone;
            this.num = num;
            this.x = x;
            this.z = z;
            this.ang = ang;
            this.width = width;
            this.fullname = zone.name + "/" + this.name;
        }

        Rigidbody slotRigidBody;

        float slotlen = 1.0f;
        float slotwid = 1.0f;
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
            var zm = zone.zm;
            var slotformselector = zm.slotform;
            //Debug.Log("Generating slotform:" + slotformselector);
            bool createfloor = zm.showFloor;
            bool createparkbox = zm.showParkbox;
            bool createsign = zm.showSign;
            bool createnode = zm.showNode;
            bool createperson = zm.showPerson;
            if (createfloor)
            {
                floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
                floor.transform.parent = slotformgo.transform;
                floor.name = "floor";
                var floorwid = 1.0f;
                floorwid = zone.slot2slotdist;
                floor.transform.localScale = new Vector3(slotlen, 0.01f, floorwid);
                var crenderer = floor.GetComponent<Renderer>();
                crenderer.material.color = Color.gray;
                crenderer.material.shader = Shader.Find("Diffuse");
                //map.AddDrawingElement(new OnlineMapsDrawingRect(new Vector2(2, 2), new Vector2(1, 1), Color.green, 1,Color.blue));
                var clrdr = floor.GetComponent<Collider>();
                clrdr.enabled = false;
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
            if (createnode)
            {
                //var node = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                var cclr = (occupied ? "red" : "cyan");
                var node = GraphAlgos.GraphUtil.CreateMarkerSphere("node",Vector3.zero,clr:cclr);
                node.transform.parent = slotformgo.transform;
                //var rrenderer = node.GetComponent<Renderer>();
                //rrenderer.material.color = (occupied ? Color.red : Color.cyan);
            }

            if (createperson && occupied)
            {

                //var objPrefab = getpersgo(avatarname);
                //if (objPrefab==null)
                //{
                //    Debug.Log("Could not fetch obj " + avatarname+" for "+persname);
                //    return;
                //}
                //persgo = Instantiate<GameObject>(objPrefab);
                //var animator = persgo.GetComponent<Animator>();
                //animator.applyRootMotion = false;
                //var script = PersonMan.GetIdleScript(avatarname, persgo);
                //animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/"+script);

                persgo = person.LoadPersonGo("-ava-zs");
                var animator = persgo.GetComponent<Animator>();
                animator.applyRootMotion = false;
                var script = person.idleScript;
                person.perstate = PersonAniStateE.standing;

                animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/"+script);
                PersonMan.UnsyncAnimation(animator, script, "ZoneSlot");

                persgo.name = persname;
                persgo.transform.parent = slotformgo.transform;
                persgo.transform.position = slotformgo.transform.position;
                persgo.transform.rotation = slotformgo.transform.rotation;
                persgo.transform.Rotate(new Vector3(0, avatarrotate, 0));
                if (person.hasHololens)
                {
                    person.ActivateHololens(true);
                }
                if (person.hasCamera)
                {
                    person.AddCamera(persgo, "ZoneSlot CreateObjects");
                }
                if (person.grabbedMainCamera)
                {
                    person.GrabMainCamera();
                }
            }
            calcVeks();
            slotformgo.transform.position = new Vector3(x, 0, z);
            slotformgo.transform.rotation = Quaternion.Euler(0, ang + 90, 0);
        }

        Dictionary<string, GameObject> persdict = new Dictionary<string, GameObject>();
        GameObject getpersgo(string name)
        {
            if (!persdict.ContainsKey(name))
            {
                var realname = "People/" + name;
                var pogo = Resources.Load<GameObject>(realname);
                persdict[name] = pogo;
            }
            return persdict[name];
        }


        public void SetConnected()
        {
            //    Debug.Log(name + " now occupied by " + carname);
            connected = true;
        }

        public void Occupy(Person pers)
        {
            //    Debug.Log(name + " now occupied by " + carname);
            occupied = true;
            this.person = pers;
            this.persname = pers.personName;
            this.avatarname = pers.avatarName;
            this.avatarrotate = GraphAlgos.GraphUtil.GetRanFloat(0, 360);

            SetSlotState(zslotstateE.welcome);
            DeleteGos(); // makes sense to redo all the goes because the car has to be created
            CreateGos();
        }
        public void Vacate()
        {
            // Debug.Log(name + " vacated");
            occupied = false;
            slotreserved = false;
            this.persname = "";
            this.avatarname = "";
            SetSlotState(zslotstateE.available);
            DeleteGos(); // makes sense to redo all the goes because the car has to be destroyed
            CreateGos();
        }
        public bool Reserve()
        {
            if (occupied) return false;
            //Debug.Log(name + " reserved");
            SetSlotState(zslotstateE.reserved);
            //DeleteGos(); // no need to recreate goes
            //CreateGos();
            return true;
        }
        //public bool ReserveSlot()
        //{
        //    if (!occupied) return false;
        //    slotreserved = true;
        //    return true;
        //}
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
            return new Vector3(x, 0, z);
        }
        public Vector3 GetPosition(zslotPosE slotpos)
        {
            var rv = GetPosition();
            calcVeks();
            switch (slotpos)
            {
                default:
                case zslotPosE.center: break;
                case zslotPosE.front:
                    rv += frontvek;
                    break;
                case zslotPosE.back:
                    rv -= frontvek;
                    break;
                case zslotPosE.left:
                    rv -= rsidevek;
                    break;
                case zslotPosE.right:
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

        public void SetSlotState(zslotstateE state)
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
                Object.Destroy(slotformgo);
                slotformgo = null;
            }
        }
        public void CreateGos()
        {
            CreateObjects();
        }

        public void EmptyAndDestroy()
        {
            Object.Destroy(slotformgo);
            slotformgo = null;
        }
        // Update is called once per frame
    //    void Update()
    //    {
    //    }
    }
}