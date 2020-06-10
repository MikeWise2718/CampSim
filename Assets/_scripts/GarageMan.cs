using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UxUtils;

namespace CampusSimulator
{

    public class GarageMan : MonoBehaviour
    {

        Dictionary<string, Garage> garagelookup = new Dictionary<string, Garage>();
        Dictionary<string, GarageSlot> slotlookup = new Dictionary<string, GarageSlot>();

        public SceneMan sman;

        //public SlotFormE slotform = SlotFormE.FullNoBox;

        public VidcamMan vman = null;

        public bool showFloor = false;
        public bool showParkbox = false;
        public bool showSign = false;
        public bool showNode = false;
        public bool showRaspi = false;
        public bool showCam = false;
        public bool showCar = false;

        public bool toggleGarageDefinitionMarkers = false;
        public bool garageDefinitionMarkersShown = false;

        public float carRectLineWidth = 1f;
        public Color carRectColor = Color.yellow;

        bool oldShowFloor = false;
        bool oldShowParkbox = false;
        bool oldShowSign = false;
        bool oldShowNode = false;
        bool oldShowRaspi = false;
        bool oldShowCam = false;
        bool oldShowCar = false;

        public List<GarageSlot> GetGarageSlots()
        {
            return new List<GarageSlot>(slotlookup.Values);
        }

        public void RotateSlotForm()
        {
            var oldsf = slotform;
            var sf = slotform.Get();
            switch (sf)
            {
                case SlotFormE.Full: slotform.Set(SlotFormE.FullNoBox); break;
                case SlotFormE.FullNoBox: slotform.Set(SlotFormE.PiSignCar); break;
                case SlotFormE.PiSignCar: slotform.Set(SlotFormE.CarFloor); break;
                case SlotFormE.CarFloor: slotform.Set(SlotFormE.Car); break;
                case SlotFormE.Car: slotform.Set(SlotFormE.Node); break;
                case SlotFormE.Node: slotform.Set(SlotFormE.Empty); break;
                case SlotFormE.Empty: slotform.Set(SlotFormE.Full); break;
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
            showRaspi = false;
            showCam = false;
            showCar = false;
            switch (slotform.Get())
            {
                case SlotFormE.Full:
                    showFloor = true;
                    showParkbox = true;
                    showRaspi = true;
                    showSign = true;
                    showCar = true;
                    showCam = true;
                    break;
                case SlotFormE.PiSignCar:
                    showFloor = true;
                    showRaspi = true;
                    showSign = true;
                    showCar = true;
                    break;
                case SlotFormE.CarFloor:
                    showCar = true;
                    showFloor = true;
                    break;
                case SlotFormE.Car:
                    showCar = true;
                    break;
                case SlotFormE.NodeFloor:
                    showNode = true;
                    showFloor = true;
                    break;
                case SlotFormE.Node:
                    showNode = true;
                    break;
                case SlotFormE.Empty:
                    break;
            }
        }

        #region SlotForm Visuals
        static List<string> slotFormOptions = new List<string>(System.Enum.GetNames(typeof(SlotFormE)));
        public UxEnumSetting<SlotFormE> slotform = new UxEnumSetting<SlotFormE>("SlotVisuals",SlotFormE.Full);

        public void RealizeSlotForm(string inisval)
        {
            slotform.Set(inisval);
            InterpretSlotForm();
            //Debug.Log("Set slotform to " + slotform);
            RefreshGos();
            sman.RequestRefresh("GarageMan-RealizeSlotForm");
        }
        #endregion SlotForm Visuals

        public void SetScene(SceneSelE newregion)
        {
            slotform.GetInitial();
            InterpretSlotForm();
            DelGarages();
            switch (newregion)
            {
                case SceneSelE.MsftDublin:
                    MakeGarages("MsDub");
                    break;
                case SceneSelE.MsftRedwest:
                case SceneSelE.MsftCoreCampus:
                case SceneSelE.MsftB19focused:
                    MakeGarages("MsGarage");
                    break;
                case SceneSelE.Eb12small:
                case SceneSelE.Eb12:
                    MakeGarages("Eb12");
                    break;
                default:
                case SceneSelE.None:
                    break;
            }
        }


        public void SetScenePostLinkCloud(SceneSelE newregion)
        {
            PopulateGaragesWithVehicles();
        }
        public void MakeGarages(string filtername)
        {
            var garlst = Garage.GetGarageNames(filtername);
            garlst.ForEach(item => MakeGarage(item));
        }
        public Garage CreateGarage(string name)
        {
            var go = new GameObject(name);
            go.transform.parent = this.transform;
            var gar = go.AddComponent<Garage>();
            gar.Initialize(this);
            return gar;
        }
        public void MakeGarage(string name)
        {
            // This makes a garage, but also makes a parent/child in the case that that is needed
            var gname = name;
            var nar = name.Split('/');
            Garage garp = null;
            bool subgarage = nar.Length == 2;
            if (subgarage)
            {
                garp = GetGarage(nar[0],expectfailure:true);
                if (garp==null)
                {
                    garp = CreateGarage(nar[0]);
                    AddGarageToLookup(garp);
                }
                gname = nar[1];
            }
            Garage garc = CreateGarage(gname);
            if (subgarage)
            {
                garp.AddChild(garc);
            }
            AddGarageToLookup(garc);
            garc.AddSlots();
        }

        public void PopulateGaragesWithVehicles()
        {
            var grglst = new List<Garage>(garagelookup.Values);
            grglst.ForEach(grg => grg.PopulateGarageWithVehicles());
        }
        public void DelGarage(string name)
        {
            //Debug.Log("Deleting garage " + name);
            //var go = GameObject.Find(name);
            var gar = garagelookup[name];
            gar.Empty(); // destroys game object as well
            garagelookup.Remove(name);
            Destroy(gar.gameObject);
        }
        public void DelGarages()
        {
    //        Debug.Log("DelGarages called");
            var namelist = new List<string>(garagelookup.Keys);
            namelist.ForEach(name => DelGarage(name));
        }
        public Garage GetGarage(string name,bool expectfailure=false)
        {
            if (!garagelookup.ContainsKey(name))
            {
                if (!expectfailure)
                {
                    Debug.Log("Bad garage lookup - not found:" + name);
                }
                return null;
            }
            return garagelookup[name];
        }
        public bool IsGarage(string name)
        {
            return garagelookup.ContainsKey(name);
        }
        public void AddGarageToLookup(Garage garage)
        {
            if (garagelookup.ContainsKey(garage.fullname))
            {
                Debug.Log("Tried to add duplicate garage:" + garage.fullname);
                return;
            }
            garagelookup[garage.fullname] = garage;
        }
        public GarageSlot GetSlot(string nodename)
        {
            if (!slotlookup.ContainsKey(nodename))
            {
                Debug.Log("Bad slot lookup - nodename not found:" + nodename);
                return null;
            }
            return slotlookup[nodename];
        }
        public void AddSlot(GarageSlot gsm)
        {
            if (slotlookup.ContainsKey(gsm.nodename))
            {
                Debug.Log("Tried to add duplicate slot with nodename:" + gsm.nodename);
                return;
            }
            slotlookup[gsm.nodename] = gsm;
        }
        public void RemoveSlot(GarageSlot gsm)
        {
            if (!slotlookup.ContainsKey(gsm.nodename))
            {
                Debug.Log("Tried to remove non-existent slot with nodename:" + gsm.nodename);
                return;
            }
            slotlookup.Remove(gsm.nodename);
        }
        // Use this for initialization

        public GarageSlot GetClosestAvailableSlot(Vector3 position,float maxgaragedist=100)
        {
            float mindist = 9e10f;
            GarageSlot minslot = null;
            foreach( var grg in garagelookup.Values)
            {
                if (Vector3.Distance(position,grg.GetPosition())< maxgaragedist)
                {
                    var sm = grg.GetClosestAvailableSlot(position);
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
        public GarageSlot GetClosestFreeCar(Vector3 position,float maxgaragedist=100)
        {
            float mindist = 9e10f;
            GarageSlot minslot = null;
            foreach (var grg in garagelookup.Values)
            {
                if (Vector3.Distance(position, grg.GetPosition()) < maxgaragedist)
                {
                    var sm = grg.GetClosestFreeCar(position);
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
            foreach (var gname in garagelookup.Keys)
            {
                garagelookup[gname].DeleteGos();
            }
        }
        public void CreateGos()
        {
            foreach (var gname in garagelookup.Keys)
            {
                garagelookup[gname].CreateGos();
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
            vman = sman.vcman;
        }
        // Update is called once per frame
        void Update()
        {
            if ( 
                oldShowFloor != showFloor ||
                 oldShowParkbox != showParkbox ||
                 oldShowSign != showSign ||
                 oldShowNode != showNode ||
                 oldShowRaspi != showRaspi ||
                 oldShowCam != showCam ||
                 oldShowCar != showCar)
            {
                DeleteGos();
                CreateGos();
                oldShowFloor = showFloor;
                oldShowParkbox = showParkbox;
                oldShowSign = showSign;
                oldShowNode = showNode;
                oldShowRaspi = showRaspi;
                oldShowCam = showCam;
                oldShowCar = showCar;                
            }

            if (toggleGarageDefinitionMarkers)
            {
                garageDefinitionMarkersShown = !garageDefinitionMarkersShown;
                toggleGarageDefinitionMarkers = false;
            }

        }

    }
}