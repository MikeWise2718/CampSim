using System.Collections.Generic;
using UnityEngine;
using UxUtils;

namespace CampusSimulator
{

    public class VehicleMan : MonoBehaviour
    {

        Dictionary<string, Vehicle> plateLookup = new Dictionary<string, Vehicle>();
        List<string> vehplates = new List<string>(); // maintain a sorted list of Vehicles with destinations
        List<string> wtd_vehplates = new List<string>(); // maintain a sorted weighted list of Vehicles with destinations


        public SceneMan sman = null;

        public int nvehs = 0;


        public enum VehModeE { none, full };
        public UxEnumSetting<VehModeE> bldMode = new UxEnumSetting<VehModeE>("VehicleMode", VehModeE.full);

        public void InitializeScene(SceneSelE newregion)
        {
        }

        public void SetScene(SceneSelE newregion)
        {
        }
        readonly string[] countyCodes =
        {
            "A", "B","C", "D", "E","F","G","H","I","J",
            "K","L","M","N","O","P","Q","R","S",
            "T", "U","V", "W", "X","Y","Z",
            "AD","AN","CO","DO","FN","FY","GA","GT","IS","PO","SA",
            "SJ","WA"
        };

        public string GenRandomPlate()
        {
            int maxiter = 10;
            int iter = 0;
            while (iter < maxiter)
            {
                var fpart = GraphAlgos.GraphUtil.GetRanListEntry(countyCodes);
                var lpart = GraphAlgos.GraphUtil.GetRanInt(9000)+1000;
                var platename = fpart + "-" + lpart;
                if (!plateLookup.ContainsKey(platename))
                {
                    return platename;
                }
            }
            return "could not find free license plate number for id";
        }
        public string GenRandomFormName()
        {
            int maxranint = 30;
            if (sman.legacyStatus)
            {
                maxranint = sman.maxLegacyCarGen;
            }
            var cidx = GraphAlgos.GraphUtil.GetRanInt(maxranint) + 1;
            return "Car" + cidx.ToString("D3");              
        }

        public static GameObject LoadCarGo(GameObject pargo,string carformname)
        {
            var objPrefab = GraphAlgos.GraphUtil.GetUniResPrefab("Cars", carformname);
            var cargo = Instantiate<GameObject>(objPrefab);
            cargo.transform.parent = pargo.transform;
            cargo.transform.position = pargo.transform.position + cargo.transform.position;
            cargo.transform.rotation = pargo.transform.rotation;
            cargo.transform.Rotate(new Vector3(0, 90, 0));
            cargo.transform.Translate(new Vector3(0, 0, -0.4f));
            return cargo;
        }

        //public List<Vehicle> GetPeopleInVehicle(Building bld)
        //{
        //    var rv = new List<Vehicle>();
        //    foreach(var per in plateLookup.Values)
        //    {
        //        if (per.InBuilding(bld.name))
        //        {
        //            rv.Add(per);
        //        }
        //    }
        //    Debug.Log("There are " + rv.Count + " people in bld " + bld.name);
        //    return rv;
        //}


        public Vehicle MakeVehicle()
        {
            var veplate = GenRandomPlate();
            var formname = GenRandomFormName();

            var pgo = new GameObject(veplate);
            pgo.transform.position = Vector3.zero;
            pgo.transform.parent = this.transform;
            var pers = pgo.AddComponent<Vehicle>();
            pers.AddVehicleDetails(this,veplate,formname);
            AddVehicleToCollection(pers); /// has to be afterwards because of the sorted names for journeys
            return pers;
        }
        public void DelVehicles()
        {
          //  Debug.Log("DelVehicles called");
            var namelist = new List<string>(plateLookup.Keys);
            namelist.ForEach(name => DelVehicle(name));
        }
        public void DelVehicle(string name)
        {
          //  Debug.Log("Deleting Vehicle " + name);
            //var go = GameObject.Find(name);

            var pers = plateLookup[name];
            nvehs--;
            plateLookup.Remove(name);
        }
        public Vehicle GetVehicle(string name)
        {
            if (!plateLookup.ContainsKey(name))
            {
                Debug.Log("Bad Vehicle lookup:" + name);
                return null;
            }
            return plateLookup[name];
        }
        public void AddVehicleToCollection(Vehicle Vehicle)
        {
            if (plateLookup.ContainsKey(Vehicle.name))
            {
                Debug.Log("Tried to add duplicate Vehicle:" + Vehicle.name);
                return;
            }
            plateLookup[Vehicle.name] = Vehicle;
            nvehs++;
            //Debug.Log("Added bld " + Vehicle.name);
        }


        public List<string> GetVehicleList()
        {
            return vehplates;
        }
        public int GetVehicleCount()
        {
            return plateLookup.Count;
        }
        public bool IsVehicleName(string pname)
        {
            var rv =  plateLookup.ContainsKey(pname);
            return rv;
        }

        public void DeleteGos()
        {
            foreach (var bname in plateLookup.Keys)
            {
                plateLookup[bname].DeleteGos();
            }
        }
        public void CreateGos()
        {
            foreach (var bname in plateLookup.Keys)
            {
                plateLookup[bname].CreateGos();
            }
        }
        public void RefreshGos()
        {
            DeleteGos();
            CreateGos();
        }
        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}