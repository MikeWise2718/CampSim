using System.Collections.Generic;
using UnityEngine;
using UxUtils;

namespace CampusSimulator
{

    public class FlightVolMan : MonoBehaviour
    {

        Dictionary<string, FlightVol> nameLookup = new Dictionary<string, FlightVol>();

        public SceneMan sman = null;

        public int nvols = 0;
        public List<FlightVol> vols = new List<FlightVol>();


        public void InitPhase0()
        {
        }

        public void DelFlightVols()
        {
            var namelist = new List<string>(nameLookup.Keys);
            namelist.ForEach(name => DelFlightVol(name));
        }

        public void ModelInitiailze(SceneSelE newregion)
        {
        }

        public void ModelBuild()
        {
        }

        public void ModelBuildPostLinkCloud()
        {
        }

        public void RegisterDronePad(BldDronePad pad)
        {
        }


        public void DelFlightVol(string name)
        {
        }


        public void DeleteGos()
        {
        }
        public void CreateGos()
        {
        }
        public void RefreshGos()
        {
            DeleteGos();
            CreateGos();
        }
        // Use this for initialization
        //void Start()
        //{
        //}

        //// Update is called once per frame
        //void Update()
        //{

        //}
    }
}