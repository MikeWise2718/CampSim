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

        public void MakeNewFlightVol(string fvname,string filename)
        {
            var go = new GameObject(fvname);
            go.transform.SetParent(this.transform, worldPositionStays: false);
            var fv = go.AddComponent<FlightVol>();
            fv.Init(this,filename);
            vols.Add(fv);
        }

        public void ModelInitiailze(SceneSelE newregion)
        {
            switch (newregion)
            {
                case SceneSelE.Seatac:
                    {
                        MakeNewFlightVol("SeattleB", "FlightVols/seattleclassb.geojson");
                        break;
                    }
            }
        }
        BldPolyGen bpg;
        public void ModelBuild()
        {
            var doflightvols = true;

            if (doflightvols)
            {
                var pgvd = new PolyGenVekMapDel(sman.mpman.GetHeightVector3);
                bpg = new BldPolyGen();
                var llm = sman.mpman.GetLatLongMap();
                //var osmbs = bpg.GenBuildingsInRegion(osmroot, waysdflst, linksdflist, nodesdflist, pgvd: pgvd, llm: llm);
            }
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
            foreach (var fv in vols)
            {
                fv.DeleteGos();
            }
        }
        public void CreateGos()
        {
            foreach(var fv in vols)
            {
                fv.CreateGos();
            }
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