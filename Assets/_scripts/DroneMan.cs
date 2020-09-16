using System.Collections.Generic;
using UnityEngine;
using UxUtils;

namespace CampusSimulator
{

    public class DroneMan : MonoBehaviour
    {

        Dictionary<string, Drone> sernumLookup = new Dictionary<string, Drone>();

        public SceneMan sman = null;

        public int nvehs = 0;

        public List<BldDronePad> pads;


        public enum DroneModeE { none, full };
        public UxEnumSetting<DroneModeE> droneMode = new UxEnumSetting<DroneModeE>("DroneMode", DroneModeE.full);

        public void InitPhase0()
        {
        }

        public void DeleteDroneInfra()
        {
            DelDrones();
            pads = null;
        }

        public void ModelInitiailze(SceneSelE newregion)
        {
            pads = new List<BldDronePad>();
        }

        public void ModelBuild()
        {
        }

        public void ModelBuildPostLinkCloud()
        {
            var grc = sman.lcman.GetGraphCtrl();
            grc.regman.NewNodeRegion("msft-drones", "purple", saveToFile: true);

            var flyheight = 10f;

            var bmaxheight = 0f;
            foreach (var bs in sman.bdman.bldspecs)
            {
                var bcen = bs.GetCenterTop();
                var mapheight = sman.mpman.GetHeight(bcen.x,bcen.z);
                var bheight = mapheight + bcen.y;
                if (bmaxheight < bheight)
                {
                    bmaxheight = bheight;
                }
            }
            //if (flyheight<bmaxheight) somehow the buildings are too high....
            //{
            //    flyheight = bmaxheight;
            //}

            var padmax = 0f;
            foreach (var pad in pads)
            {
                var padnode = grc.GetNode(pad.padNodeName);
                if (padmax < padnode.pt.y)
                {
                    padmax = padnode.pt.y;
                }
            }
            if (flyheight < padmax)
            {
                flyheight = padmax;
            }
            flyheight = flyheight + 16;
            sman.Lgg($"Drone Flightheight:{flyheight} bldmax:{bmaxheight} padmax:{padmax}","green");
            foreach (var pad in pads)
            {
                // this should really be a pad method - adding a high node
                var padnode = grc.GetNode(pad.padNodeName);
                pad.padHighName = $"{pad.padNodeName}-high";
                grc.AddNodePtxyz(pad.padHighName, padnode.pt.x, flyheight, padnode.pt.z);
                grc.AddLinkByNodeName(pad.padNodeName, pad.padHighName,GraphAlgos.LinkUse.droneway);
            }

            var n = pads.Count;
            for(int i=0; i<pads.Count; i++)
            {
                var pad1 = pads[i];
                for (int j = i+1; j < pads.Count; j++)
                {
                    var pad2 = pads[j];
                    grc.AddLinkByNodeName(pad1.padHighName, pad2.padHighName,GraphAlgos.LinkUse.droneway);
                }
            }
            grc.regman.SetRegion("default");
        }

        public void RegisterDronePad(BldDronePad pad)
        {
            pads.Add(pad);
        }


        public void DelDrones()
        {
            //  Debug.Log("DelVehicles called");
            var namelist = new List<string>(sernumLookup.Keys);
            namelist.ForEach(name => DelDrone(name));
        }
        public void DelDrone(string name)
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