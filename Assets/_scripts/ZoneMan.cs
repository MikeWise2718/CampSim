using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UxUtils;

namespace CampusSimulator
{

    public class ZoneMan : MonoBehaviour
    {

        Dictionary<string, Zone> zonelookup = new Dictionary<string, Zone>();
        Dictionary<string, ZoneSlot> slotlookup = new Dictionary<string, ZoneSlot>();

        public SceneMan sman;

        //public SlotFormE slotform = SlotFormE.FullNoBox;

        public VidcamMan vman = null;

        public bool showFloor = false;
        public bool showParkbox = false;
        public bool showSign = false;
        public bool showNode = false;
        public bool showPerson = false;


        bool oldShowFloor = false;
        bool oldShowParkbox = false;
        bool oldShowSign = false;
        bool oldShowNode = false;
        bool oldShowPerson = false;
        public List<ZoneSlot> GetZoneSlots()
        {
            return new List<ZoneSlot>(slotlookup.Values);
        }
        public List<Zone> GetZones()
        {
            return new List<Zone>(zonelookup.Values);
        }

        public List<Zone> GetZones(string buildingName)
        {
            var rv = new List<Zone>();
            var zones = GetZones();
            foreach( var zone in zones)
            {
                if (zone.bld.name == buildingName)
                {
                    rv.Add(zone);
                }
            }
            return rv;
        }

        public void RotateSlotForm()
        {
            var oldsf = slotform;
            var sf = slotform.Get();
            switch (sf)
            {
                case zSlotFormE.Full: slotform.Set(zSlotFormE.FullNoBox); break;
                case zSlotFormE.FullNoBox: slotform.Set(zSlotFormE.SignPerson); break;
                case zSlotFormE.SignPerson: slotform.Set(zSlotFormE.PersonFloor); break;
                case zSlotFormE.PersonFloor: slotform.Set(zSlotFormE.Person); break;
                case zSlotFormE.Person: slotform.Set(zSlotFormE.Node); break;
                case zSlotFormE.Node: slotform.Set(zSlotFormE.Empty); break;
                case zSlotFormE.Empty: slotform.Set(zSlotFormE.Full); break;
            }
            InterpretSlotForm();
            Debug.Log("Old slotform-"+oldsf+"  New slotform - " + slotform);
        }
        public void InterpretSlotForm()
        {
            showFloor = false;
            showParkbox = false;
            showSign = false;
            showNode = false;
            showPerson = false;
            switch (slotform.Get())
            {
                case zSlotFormE.Full:
                    showFloor = true;
                    showParkbox = true;
                    showSign = true;
                    showPerson = true;
                    break;
                case zSlotFormE.SignPerson:
                    showFloor = true;
                    showSign = true;
                    showPerson = true;
                    break;
                case zSlotFormE.PersonFloor:
                    showPerson = true;
                    showFloor = false; // don't want this at the moment
                    break;
                case zSlotFormE.Person:
                    showPerson = true;
                    break;
                case zSlotFormE.Node:
                    showNode = true;
                    showFloor = true;
                    break;
                case zSlotFormE.Empty:
                    break;
            }
        }

        static List<string> slotFormOptions = new List<string>(System.Enum.GetNames(typeof(zSlotFormE)));
        public UxEnumSetting<zSlotFormE> slotform = new UxEnumSetting<zSlotFormE>("ZoneSlotVisuals",zSlotFormE.PersonFloor);

        public void RealizeSlotForm(string inisval)
        {
            slotform.Set(inisval);
            InterpretSlotForm();
            //Debug.Log("Set zone slotform to " + slotform);
            RefreshGos();
            sman.RequestRefresh("ZoneMan-RealizeSlotForm");
        }

        public void ModelInitialize(SceneSelE newregion)
        {
            InitializeValues();
        }

        public void InitializeValues()
        {
            slotform.GetInitial();
        }

        public void ModelBuild()
        {
            InterpretSlotForm();
            DelZones();
            switch (sman.curscene)
            {
                case SceneSelE.MsftB19focused:
                case SceneSelE.MsftB33focused:
                case SceneSelE.MsftB121focused:
                    MakeZones("Ms-B19");
                    break;
                case SceneSelE.MsftRedwest:
                    MakeZones("Ms-Redw");
                    break;
                case SceneSelE.Eb12small:
                case SceneSelE.Eb12:
                    MakeZones("Eb12");
                    break;
                default:
                    break;
            }
        }

        public bool IsSlot(string destnode)
        {
            return slotlookup.ContainsKey(destnode);
        }

        public void OccupySlot(string destnode,Person person)
        {
            if (!IsSlot(destnode))
            {
                Debug.Log("bad dest node - is not a zone slot:" + destnode);
            }
            var slot = slotlookup[destnode];
            slot.Occupy(person);
            person.AssignCurLocation(person.placeBld, slot.zone.name, slot.nodename);
        }

        public void VacateSlot(string vacnode, Person person)
        {
            if (!IsSlot(vacnode))
            {
                Debug.Log("bad dest node - is not a zone slot:" + vacnode);
            }
            var slot = slotlookup[vacnode];
            slot.Vacate();
            person.AssignCurLocation(person.placeBld,vacnode, vacnode);
        }
        public void CreateZoneLinks(string zname, string walknode)
        {
            //Debug.Log("CreateZoneLinks");
            var zm = GameObject.FindObjectOfType<ZoneMan>();
            var zone = zm.GetZone(zname);
            if (zone == null)
            {
                Debug.Log("Zone " + zname + " not found in CreateZoneLinks");
                return;
            }
            var lc = GameObject.FindObjectOfType<LinkCloudMan>();
            var lclc = lc.GetGraphCtrl();
            lclc.SetCurUseType(GraphAlgos.LinkUse.walkwaynoshow);

            int nslots = zone.slotnames.Count;
            var pslotnodename = new string[nslots];
            var pslotpos = new Vector3[nslots];
            for (int i = 0; i < nslots; i++)
            {
                pslotnodename[i] = zone.SlotNameNode(i);
                //Debug.Log("Connecting " + walknode + " to " + pslotnodename[i]);
                zone.SetConnected(pslotnodename[i]);
                lclc.AddLinkByNodeName(walknode, pslotnodename[i], GraphAlgos.LinkUse.walkwaynoshow);
            }

        }
        public void MakeZones(string filtername)
        {
            var zarlst = Zone.GetZoneNames(filtername);
            zarlst.ForEach(zname => MakeZone(zname));
        }
        public void MakeZone(string name)
        {
            var go = new GameObject(name);
            go.transform.parent = this.transform;
            var zar = go.AddComponent<Zone>();
            AddZone(zar);
            zar.AddSlots(this);
        }
        public void DelZone(string name)
        {
            //Debug.Log("Deleting Zone " + name);
            //var go = GameObject.Find(name);
            var zar = zonelookup[name];
            zar.Empty(); // destroys game object as well
            zonelookup.Remove(name);
            Destroy(zar.gameObject);
        }
        public void DelZones()
        {
    //        Debug.Log("DelZones called");
            var namelist = new List<string>(zonelookup.Keys);
            namelist.ForEach(name => DelZone(name));
        }
        public Zone GetZone(string name)
        {
            if (!zonelookup.ContainsKey(name))
            {
                Debug.Log("Bad Zone lookup - not found:" + name);
                return null;
            }
            return zonelookup[name];
        }
        public void AddZone(Zone zone)
        {
            if (zonelookup.ContainsKey(zone.name))
            {
                Debug.Log("Tried to add duplicate zone:" + zone.name);
                return;
            }
            //Debug.Log("Adding zone " + zone.name+" to lookup");
            zonelookup[zone.name] = zone;
        }
        public ZoneSlot GetSlot(string nodename)
        {
            if (!slotlookup.ContainsKey(nodename))
            {
                Debug.Log("Bad slot lookup - nodename not found:" + nodename);
                return null;
            }
            return slotlookup[nodename];
        }
        public void AddSlot(ZoneSlot zsm)
        {
            if (slotlookup.ContainsKey(zsm.nodename))
            {
                Debug.Log("Tried to add duplicate slot with nodename:" + zsm.nodename);
                return;
            }
            slotlookup[zsm.nodename] = zsm;
        }
        public void RemoveSlot(ZoneSlot gsm)
        {
            if (!slotlookup.ContainsKey(gsm.nodename))
            {
                Debug.Log("Tried to remove non-existent slot with nodename:" + gsm.nodename);
                return;
            }
            slotlookup.Remove(gsm.nodename);
        }
        // Use this for initialization

        public ZoneSlot GetClosestAvailableSlot(Vector3 position,float maxgaragedist=250)
        {
            float mindist = 9e10f;
            ZoneSlot minslot = null;
            foreach( var zone in zonelookup.Values)
            {
                if (Vector3.Distance(position,zone.GetPosition())< maxgaragedist)
                {
                    var sm = zone.GetClosestAvailableSlot(position);
                    if (sm!=null)
                    {
                        float d = Vector3.Distance(position, sm.GetPosition());
                        if (d<mindist)
                        {
                            mindist = d;
                            minslot = sm;
                        }
                    }
                }
            }
            return minslot;
        }
        public ZoneSlot GetClosestFreeSlot(Vector3 position,float maxzonedistance=250)
        {
            float mindist = 9e10f;
            ZoneSlot minslot = null;
            foreach (var grg in zonelookup.Values)
            {
                if (Vector3.Distance(position, grg.GetPosition()) < maxzonedistance)
                {
                    var sm = grg.GetClosestFreePerson(position);
                    if (sm != null)
                    {
                        float d = Vector3.Distance(position, sm.GetPosition());
                        if (d < mindist)
                        {
                            mindist = d;
                            minslot = sm;
                        }
                    }
                }
            }
            return minslot;
        }

        public void DeleteGos()
        {
            foreach (var gname in zonelookup.Keys)
            {
                zonelookup[gname].DeleteGos();
            }
        }
        public void CreateGos()
        {
            foreach (var gname in zonelookup.Keys)
            {
                zonelookup[gname].CreateGos();
            }
        }
        public void RefreshGos()
        {
            DeleteGos();
            CreateGos();
        }
        void Start()
        {
            // SetRegion(RegionSelE.MsftCoreCampus);
            sman = FindObjectOfType<SceneMan>();
            vman = sman.vcman;
            slotform.SetAndSave(zSlotFormE.PersonFloor);
        }
        // Update is called once per frame
        void Update()
        {
            if ( 
                oldShowFloor != showFloor ||
                 oldShowParkbox != showParkbox ||
                 oldShowSign != showSign ||
                 oldShowNode != showNode ||
                 oldShowPerson != showPerson)
            {
                DeleteGos();
                CreateGos();
                oldShowFloor = showFloor;
                oldShowParkbox = showParkbox;
                oldShowSign = showSign;
                oldShowNode = showNode;
                oldShowPerson = showPerson;                
            }

        }

    }
}