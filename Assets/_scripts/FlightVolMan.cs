using System.Collections.Generic;
using UnityEngine;
using UxUtils;

namespace CampusSimulator
{

    public class FlightVolMan : MonoBehaviour
    {

        Dictionary<string, FlightVol> nameLookup = new Dictionary<string, FlightVol>();

        public SceneMan sman = null;

        public List<FlightVol> vols = new List<FlightVol>();

        public UxSettingBool gridVols = new UxSettingBool("gridVols", false);
        public UxSettingBool tranVols = new UxSettingBool("tranVols", false);


        public void InitPhase0()
        {
        }

        public void DelFlightVols()
        {
            sman.Lgg($"DeleteFlightVols called nvols:{vols.Count}", "red");
            var namelist = new List<string>(nameLookup.Keys);
            namelist.ForEach(name => DelFlightVol(name));
            nameLookup = new Dictionary<string, FlightVol>();
            vols = new List<FlightVol>();
        }

        public void MakeNewFlightVol(string fvname,string filename)
        {
            var go = new GameObject(fvname);
            go.transform.SetParent(this.transform, worldPositionStays: false);
            var fv = go.AddComponent<FlightVol>();
            fv.Init(this,filename);
            vols.Add(fv);
            nameLookup[fvname] = fv;
        }

        public void ModelInitiailze(SceneSelE newregion)
        {
            nameLookup = new Dictionary<string, FlightVol>();
            vols = new List<FlightVol>();
            sman.Lgg($"ModelInitialize {newregion} nvols:{vols.Count}","red");
            switch (newregion)
            {
                case SceneSelE.MsftB19focused:
                case SceneSelE.MsftB121focused:
                case SceneSelE.MsftCoreCampus:
                case SceneSelE.Seatac:
                    {
                        MakeNewFlightVol("SeattleB", "FlightVols/seattleclassb.geojson");
                        break;
                    }
            }
            InitializeValues();
        }
        public void InitializeValues()
        {
            gridVols.GetInitial(false);
            tranVols.GetInitial(false);
        }

        public void ToggleFvGrid()
        {
            var curstat = !gridVols.Get();
            gridVols.SetAndSave(curstat);
            CreateGos();
        }
        public void ToggleFvTran()
        {
            var curstat = !tranVols.Get();
            tranVols.SetAndSave(curstat);
            CreateGos();
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
            var fv = nameLookup[name];
            fv.Delete();
            Destroy(fv.gameObject);
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