using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UxUtils;
using Aiskwk.Map;

namespace CampusSimulator
{
    public class MapMan : MonoBehaviour
    {
        SceneMan sman;

        GameObject qmapgo;
        QmapMan qmapman;
 
        public float xdistkm = 1;
        public float zdistkm = 3;
        public float hmult;
        public int lod = 16;
        public Vector3 maptrans;
        public Vector3 maprot;
        public bool useElevations = false;
        public bool useViewer = false;

        public double maplng = -122.134216;
        public double maplat = 47.639217;
        public float mapscale = 1;
        public float roty2 = 0;


        public enum MapVisualsE {  MapOn, MapOff }
        public UxEnumSetting<MapVisualsE> mapVisiblity = new UxEnumSetting<MapVisualsE>("MapVisuals",MapVisualsE.MapOn);
        #region Map Visuals
        public void RealizeMapVisuals()
        {
            var mapviz = mapVisiblity.Get();
            var active = mapviz == MapVisualsE.MapOn;
            //Debug.Log("RealizeMapVisuals " + mapviz+" active:"+active);
            qmapgo?.SetActive(active);
        }
        #endregion Map Visuals

        // Use this for initialization
        void Awake()
        {
            var sm = FindObjectOfType<SceneSetupMan>();
            if (sm==null)
            {
                Debug.Log("In MapMan.Awake Could not find object of type SceneSetupMan");
            }
        }

        void CreateQmap()
        {
            qmapgo = new GameObject("QmapMan");
            qmapgo.transform.SetParent(this.transform, worldPositionStays: false);
            qmapman = qmapgo.AddComponent<QmapMan>();
            RealizeQmap();
        }
        void RealizeQmap()
        {
            Debug.Log("QmapMan.RealizeQmap");
            RealizeMapVisuals();
            qmapman.qmapMode = QmapMan.QmapModeE.Bespoke;
            var fak = 2*0.4096f;
            //qmapman.bespoke = new BespokeSpec(lastregionset.ToString(), maplat,maplng, fak*zscale, fak*xscale,lod:17 );
            qmapman.bespoke = new BespokeSpec(lastregionset.ToString(), maplat,maplng, fak*zdistkm, fak*xdistkm,lod:lod );
            qmapman.bespoke.useElevationData = useElevations;
            qmapman.bespoke.hmult = hmult;
            qmapman.bespoke.useViewer = useViewer;
            qmapman.bespoke.maptrans = maptrans;
            qmapman.bespoke.maprot = new Vector3(0,this.roty2,0);
            var ska = 1 / mapscale;
            qmapman.bespoke.mapscale = new Vector3(ska, ska, ska);
            //qmapman.bespoke.maprot = new Vector3(0, 0, 0);
            qmapman.SetMode(qmapman.qmapMode);
            Debug.Log("RealizeQmap done");
        }

        void Initialize()
        {
            if (qmapgo == null)
            {
                CreateQmap();
            }
            else
            {
                RealizeQmap();
            }
        }
        void SetMeshCollider(bool enable)
        {
            Debug.Log("Qmap funciton SetMeshCollider - Not implemented yet");
        }
        public void TurnOffMeshCollider()
        {
            SetMeshCollider(enable:false);
        }
        public void TurnOnMeshCollider()
        {
            SetMeshCollider(enable: true);
        }
        SceneSelE lastregionset = SceneSelE.None;
        public void SetScene(SceneSelE newregion)
        {
            mapVisiblity.GetInitial();
            //Debug.Log("SetRegion for mapman " + newregion);
            RealizeMapVisuals();
            if (newregion == lastregionset)
            {
                Debug.LogWarning("Region " + newregion + " already set");
                return;
            }
            maprot = Vector3.zero;
            maptrans = Vector3.zero;
            useElevations = false;
            useViewer = true;
            int defaultlod = 19;
            mapscale = 3.2f;
            maprot = Vector3.zero;
            maptrans = Vector3.zero;
            roty2 = -90;
            hmult = 1;
            Viewer.viewerDefaultPosition = Vector3.zero;
            Viewer.viewerDefaultRotation = Vector3.zero;
            Viewer.viewerAvatarDefaultValue = ViewerAvatar.CapsuleMan;
            Viewer.ViewerCamPositionDefaultValue = ViewerCamPosition.FloatBehind;
            Viewer.ViewerControlDefaultValue = ViewerControl.Velocity;
            switch (newregion)
            {
                default:
                case SceneSelE.MsftRedwest:
                    maplat = 47.659377;
                    maplng = -122.140189;
                    mapscale = 3.2f;
                    maprot = new Vector3(0, 71.1f, 0);
                    maptrans = new Vector3(-6 - 1970.0f + 4, 0, 17 - 1122.0f - 16);
                    xdistkm = 1;
                    zdistkm = 1;
                    lod = defaultlod;
                    Viewer.viewerDefaultPosition = new Vector3(-2035.2f, 3.8f, -1173.5f);
                    Viewer.viewerDefaultPosition = new Vector3(21.895f, 163.310f, 0.475f);
                    break;
                case SceneSelE.MsftB19focused:
                    maplat = 47.639217;
                    maplng = -122.134216;
                    mapscale = 3.2f;
                    maprot = new Vector3(0, 71.1f, 0);
                    maptrans = new Vector3(-6, 0, 17);
                    xdistkm = 1;
                    zdistkm = 2;
                    lod = defaultlod;
                    Viewer.viewerDefaultPosition = new Vector3(-451.5f, 3f, 98.3f);
                    Viewer.viewerDefaultPosition = new Vector3(30f, -60f, 0);
                    //case "Ms_c_B19_raspipole":
                    //    campos = new Vector3(-451.5f, 3f, 98.3f);
                    //    camrotate = new Vector3(30f, -60f, 0);
                    break;
                case SceneSelE.Eb12:
                    // better with google maps
                    maplat = 49.993311;
                    maplng =  8.678343;
                    mapscale = 3.2f;
                    maprot = new Vector3(0,-90, 0);
                    xdistkm = 1;
                    zdistkm = 1;
                    lod = defaultlod;
                    break;
                case SceneSelE.Tukwila:
                    // better with google maps
                    maplat = 47.456970; 
                    maplng = -122.258825;
                    mapscale = 3.2f;
                    xdistkm = 1;
                    zdistkm = 1;
                    lod = defaultlod;
                    break;
                case SceneSelE.MsftDublin:
                    maplat = 53.268998;
                    maplng = -6.196680;
                    xdistkm = 2;
                    zdistkm = 1;
                    lod = defaultlod;
                    mapscale = 3.2f;
                    break;
                case SceneSelE.MsftCoreCampus:
                    maplat = 47.639217;
                    maplng = -122.134216;
                    mapscale = 3.2f;
                    maprot = new Vector3(0, 71.1f, 0);
                    maptrans = new Vector3(-6, 0, 17);
                    xdistkm = 2;
                    zdistkm = 6;
                    lod = defaultlod;
                    break;
                case SceneSelE.Seattle:
                    maplat = 47.619992;
                    maplng = -122.3373495;
                    mapscale = 3.2f;
                    maprot = Vector3.zero;
                    maptrans = Vector3.zero;
                    xdistkm = 14.84f / (2*0.4096f);
                    zdistkm = 25.17f / (2*0.4096f);
                    hmult = 10;
                    lod = 12;
                    useElevations = true;
                    useViewer = true;
                    mapscale = 1f;
                    roty2 = 0;
                    break;
                case SceneSelE.MtStHelens:
                    maplat = 46.198428;
                    maplng = -122.188841;
                    mapscale = 3.2f;
                    maprot = Vector3.zero;
                    maptrans = Vector3.zero;
                    xdistkm = 12;
                    zdistkm = 12;
                    lod = 15;
                    useElevations = true;
                    useViewer = true;
                    mapscale = 1f;
                    roty2 = 0;
                    Viewer.viewerAvatarDefaultValue = ViewerAvatar.Rover;
                    mapscale = 1f;
                    break;
                case SceneSelE.Riggins:
                    maplat = 45.412219;
                    maplng = -116.328921;
                    mapscale = 3.2f;
                    maprot = Vector3.zero;
                    maptrans = Vector3.zero;
                    xdistkm = 10;
                    zdistkm = 10;
                    lod = 15;
                    useElevations = true;
                    useViewer = true;
                    mapscale = 1f;
                    roty2 = 0;
                    mapscale = 1f;
                    break;
                    //        var llmid = new LatLng(45.412219, -116.328921, "Riggins");
                    //        var llbox = new LatLngBox(llmid, 10.0, 10.0, "Riggins box", lod: 15);
                    //        Debug.Log("riggins-llbox llmid:" + llbox.midll.ToString());
                    //        (qmm, _, _) = await MakeMeshFromLlbox("riggins", llbox, tpqk: 16, hmult: 1, mapprov: mapprov);
                    //        //var qcm = InitMesh("dozers", "", 15, ll1, ll2, 16, 10, mapprov: mapprov);
                    //        qmm.nodefak = 0.2f;
                    break;

            }
            transform.localRotation = Quaternion.identity;
            transform.Rotate(maprot.x, maprot.y, maprot.z);
            transform.position = maptrans;
            transform.localScale = new Vector3(mapscale, mapscale, mapscale);
            lastregionset = newregion;
            Debug.Log($"MapMap Set Position - trans:{maptrans} rot:{maprot}");
            Initialize();
        }
    }
}