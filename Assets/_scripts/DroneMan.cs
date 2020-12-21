using System.Collections.Generic;
using UnityEngine;
using UxUtils;

namespace CampusSimulator
{

    public enum DroneSelectionMode { randommix, fixedmix }
    public enum DroneSelectionNumber { any = -0, phantom = 1, mavic = 2, deldrone = 3, matrice = 4 }

    public class DroneMan : MonoBehaviour
    {

        Dictionary<string, Drone> sernumLookup = new Dictionary<string, Drone>();

        public SceneMan sman = null;

        public int nvehs = 0;

        public List<BldDronePad> pads;


        public enum DroneModeE { none, full };
        public UxEnumSetting<DroneModeE> droneMode = new UxEnumSetting<DroneModeE>("DroneMode", DroneModeE.full);




        public (string dispavname, string avname, float scale, Vector3 rot, Vector3 tran) GetRandomAvatarDroneName(DroneSelectionMode dsm, DroneSelectionNumber dsn)
        {
            var irnd = (int)dsn;
            if (dsm == DroneSelectionMode.randommix)
            {
                irnd = GraphAlgos.GraphUtil.GetRanInt(4, "popbld") + 1;
            }
            //var phantomrot = new Vector3(0, 0, 0);
            var phantomrot = new Vector3(0, 90, 0);
            var phantomlift = new Vector3(0, 0.117f, 0);
            //var mavrot = new Vector3(0, 0, 90);
            var mavrot = (Quaternion.Euler(0, 0, 0)).eulerAngles;
            var mavlift = new Vector3(0, 0.074f, 0);
            var defrot = Vector3.zero;
            var deflift = Vector3.zero;
            switch (irnd)
            {
                default:
                case 1: return ("Phantom", "quadcopter", 3f, phantomrot, phantomlift);
                case 2: return ("Mavic", "DJI_Mavic_Air_2", 3f, mavrot, mavlift);
                case 3: return ("DelDrone", "Delivery_drone_v2", 1f, defrot, deflift);
                case 4: return ("Matrice", "matrice_600", 1f, defrot, deflift);
            }
        }


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