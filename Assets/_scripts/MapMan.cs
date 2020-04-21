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

        public int config = 0;
        GameObject rmapgo;
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

        public bool qmap;

        bool old_qmap;

        public enum MapVisualsE {  MapOn, MapOff }
        //public MapVisualsE mapVisuals = MapVisualsE.MapOn;
        public UxEnumSetting<MapVisualsE> mapVisiblity = new UxEnumSetting<MapVisualsE>("MapVisuals",MapVisualsE.MapOn);
        #region Map Visuals
        public void RealizeMapVisuals()
        {
            var mapviz = mapVisiblity.Get();
            var active = mapviz == MapVisualsE.MapOn;
            //Debug.Log("RealizeMapVisuals " + mapviz+" active:"+active);
            if (rmapgo==null)
            {
                Debug.Log("mapgo null");
                return;
            }
            rmapgo.SetActive(active);
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
            sman = FindObjectOfType<SceneMan>();
            var initscene = SceneMan.GetInitialSceneOption();
            //Debug.Log("MapMan awake - now setting "+initscene);
            rmapgo = GameObject.Find("Map");
            SetScene(initscene);

            qmap = true;
            old_qmap = !qmap;

            CreateQmap();
            //Initialize();
        }

        void CreateQmap()
        {
            qmapgo = new GameObject("QmapMan");
            qmapgo.transform.SetParent(this.transform, worldPositionStays: true);
            qmapman = qmapgo.AddComponent<QmapMan>();
            RealizeQmap();
        }
        void RealizeQmap()
        {
            Debug.Log("QmapMan.RealizeQmap");
            qmapgo.SetActive(qmap);
            qmapman.qmapMode = QmapMan.QmapModeE.Bespoke;
            var fak = 2*0.4096f;
            //qmapman.bespoke = new BespokeSpec(lastregionset.ToString(), maplat,maplng, fak*zscale, fak*xscale,lod:17 );
            qmapman.bespoke = new BespokeSpec(lastregionset.ToString(), maplat,maplng, fak*zdistkm, fak*xdistkm,lod:lod );
            qmapman.bespoke.useElevationData = useElevations;
            qmapman.bespoke.hmult = hmult;
            qmapman.bespoke.useViewer = useViewer;
            qmapman.bespoke.maptrans = maptrans;
            qmapman.bespoke.maprot = new Vector3(0,-90,0);
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
                Debug.Log("Region " + newregion + " already set");
                return;
            }
            maprot = Vector3.zero;
            maptrans = Vector3.zero;
            int defaultlod = 19;
            switch (newregion)
            {
                default:
                case SceneSelE.MsftRedwest:
                    maplat = 47.659377;
                    maplng = -122.140189;
                    maprot = new Vector3(0, 71.1f, 0);
                    maptrans = new Vector3(-6 - 1970.0f + 4, 0, 17 - 1122.0f - 16);
                    config = 1;
                    xdistkm = 1;
                    zdistkm = 1;
                    lod = defaultlod;
                    break;
                case SceneSelE.MsftB19focused:
                    maplat = 47.639217;
                    maplng = -122.134216;
                    maprot = new Vector3(0, 71.1f, 0);
                    maptrans = new Vector3(-6, 0, 17);
                    config = 0;
                    xdistkm = 1;
                    zdistkm = 2;
                    lod = defaultlod;
                    break;
                case SceneSelE.Eb12:
                    // better with google maps
                    maplat = 49.993311;
                    maplng =  8.678343;
                    maprot = new Vector3(0,-90, 0);
                    maptrans = Vector3.zero;
                    config = 1;
                    xdistkm = 1;
                    zdistkm = 1;
                    lod = defaultlod;
                    break;
                case SceneSelE.Tukwila:
                    // better with google maps
                    maplat = 47.456970; 
                    maplng = -122.258825;
                    maprot = Vector3.zero;
                    maptrans = Vector3.zero;
                    config = 1;
                    xdistkm = 1;
                    zdistkm = 1;
                    lod = defaultlod;
                    break;
                case SceneSelE.Seattle:

                    //var llmid = new LatLng(47.619992, -122.3373495, "Seattle");
                    //var llbox = new LatLngBox(llmid, 25.17, 14.84, lod: 12);
                    //useElevationDataStart = true;
                    //Viewer.viewerDefaultRotation = new Vector3(0, 90, 0);
                    //Viewer.viewerDefaultPosition = new Vector3(0, 0, 0);
                    //Viewer.ViewerCamPositionDefaultValue = ViewerCamPosition.FloatBehind;

                    // better with google maps
                    maplat = 47.619992;
                    maplng = -122.3373495;
                    maprot = Vector3.zero;
                    maptrans = Vector3.zero;
                    config = 1;
                    xdistkm = 14.84f / (2*0.4096f);
                    zdistkm = 25.17f / (2*0.4096f);
                    hmult = 10;
                    lod = 12;
                    useElevations = true;
                    useViewer = true;
                    break;
                case SceneSelE.MsftDublin:
                    maplat = 53.268998;
                    maplng = -6.196680;
                    config = 0;
                    xdistkm = 2;
                    zdistkm = 1;
                    lod = defaultlod;
                    break;
                case SceneSelE.MsftCoreCampus:
                    maplat = 47.639217;
                    maplng = -122.134216;
                    maprot = new Vector3(0, 71.1f, 0);
                    maptrans = new Vector3(-6, 0, 17);
                    config = 0;
                    xdistkm = 2;
                    zdistkm = 6;
                    lod = defaultlod;
                    break;
            }
            transform.localRotation = Quaternion.identity;
            transform.Rotate(maprot.x, maprot.y, maprot.z);
            transform.position = maptrans;
            lastregionset = newregion;
            Initialize();
        }
        void Start()
        {
        }
        void Update()
        {
            if (qmap != old_qmap)
            {
                //Debug.Log($"Toggling qmap:{qmap}");
                RealizeQmap();
                old_qmap = qmap;
            }
        }
    }
}