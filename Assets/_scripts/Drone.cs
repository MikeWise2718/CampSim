using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CampusSimulator
{
    public class Drone : MonoBehaviour
    {
        DroneMan drman;
        public string vehicleId;
        public string formName;
        public string homeBld;
        public string homeNode;
        public string placeName;
        public string placeNode;
        public string waitPlaceNode;
        public int placeIdx;

        public void Empty()
        {
            DeleteGos();
        }
        public void AddVehicleDetails(DroneMan vm, string vehicleid, string formname)
        {
            this.drman = vm;
            this.vehicleId = vehicleid;
            this.formName = formname;
            this.vehgos = new List<GameObject>();
        }
        public void AssignHomeLocation(string placename, string placenode)
        {
            this.homeBld = placename;
            this.placeName = placename;

            this.homeNode = placenode;
            this.placeNode = placenode;
        }
        public void AssignCurLocation(string placename, string placenode)
        {
            this.placeName = placename;
            this.placeNode = placenode;
        }
        public bool InBuilding(string bname)
        {
            return placeName == bname;
        }
        public bool NotTravelingInBuilding(string bname)
        {
            var rv = (placeName == bname) && (placeNode != "traveling");
            return rv;
        }

        List<GameObject> vehgos;

        void ActuallyDestroyObjects()
        {
            if (vehgos == null)
            {
                Debug.Log("vehgos is null");
            }
            foreach (var go in vehgos)
            {
                Object.Destroy(go);
            }
        }


        public void CreateObjects()
        {
            vehgos = new List<GameObject>();
        }

        public void DeleteGos()
        {
            var nprs = vehgos.Count;
            ActuallyDestroyObjects();
            //   Debug.Log("Deleted "+nprs+" goes for Vehicle "+name);
        }
        public void CreateGos()
        {
            CreateObjects();
            var nprs = vehgos.Count;
            //   Debug.Log("Created " + nprs + " gos for Vehicle "+name);
        }
        //// Update is called once per frame
        //void Update()
        //{
        //}
    }
}
