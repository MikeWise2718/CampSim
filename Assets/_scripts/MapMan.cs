using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UxUtils;
using Aiskwk.Map;

namespace CampusSimulator
{
    public class MapMan : MonoBehaviour
    {
        public SceneMan sman;

        GameObject qmapgo;
        QmapMan qmapman;
 
        public double xdistkm = 1;
        public double zdistkm = 3;

        public int lod = 16;
        public int npqk = 16;
        public Vector3 maptrans;
        public Vector3 maprot;
        public bool useElesForNow = false;
        public bool useViewer = false;
        public bool hasLLmap = false;
        public bool isCustomizable = false;

        public double maplng = -122.134216;
        public double maplat = 47.639217;
        public float mapscale = 1;
        public float roty2 = 0;
        public string address = "";


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


        public UxEnumSetting<MapProvider> reqMapProv = new UxEnumSetting<MapProvider>("MapProvider", MapProvider.BingSatelliteRoads);
        // todo - think we can eliminate MapPRovider and 
        #region MapProvider
        static List<string> mapProviderOptions = new List<string>(System.Enum.GetNames(typeof(MapProvider)));
        static string initialMapProviderKey = "MapProvider";
        //public static List<string> GetMapProviderList()
        //{
        //    return mapProviderOptions;
        //}
        public static string GetMapProviderString(int ival)
        {
            return mapProviderOptions[ival];
        }
        public static MapProvider GetMapProviderEnum(string sval)
        {
            MapProvider enumval;
            System.Enum.TryParse<MapProvider>(sval, true, out enumval);
            return enumval;
        }
        public static MapProvider GetInitialMapProvider()
        {
            var einival = MapProvider.BingMaps; // default scene
            if (PlayerPrefs.HasKey(initialMapProviderKey))
            {
                var inival = PlayerPrefs.GetString(initialMapProviderKey, "");
                einival = GetMapProviderEnum(inival);
            }
            return einival;
        }
        public static void SetInitialMapProvider(string inisval)
        {
            PlayerPrefs.SetString(initialMapProviderKey, inisval);
        }
        #endregion MapProvider


        public List<string> GetMapProviderList()
        {
            var rv = reqMapProv.GetOptionsAsList();
            return rv;
        }

        public UxEnumSetting<ElevProvider> reqEleProv = new UxEnumSetting<ElevProvider>("ElevProvider", ElevProvider.BingElev);
        #region ElevProvider
        static List<string> eleProvOptions = new List<string>(System.Enum.GetNames(typeof(ElevProvider)));
        static string initialElevProviderKey = "ElevProvider";
        public static List<string> GetElevProviderList()
        {
            return eleProvOptions;
        }
        public static string GetElevProviderString(int ival)
        {
            return eleProvOptions[ival];
        }
        public static ElevProvider GetElevProviderEnum(string sval)
        {
            ElevProvider enumval;
            System.Enum.TryParse<ElevProvider>(sval, true, out enumval);
            return enumval;
        }
        public static ElevProvider GetInitialElevProvider()
        {
            var einival = ElevProvider.BingElev; // default scene
            if (PlayerPrefs.HasKey(initialElevProviderKey))
            {
                var inival = PlayerPrefs.GetString(initialElevProviderKey, "");
                einival = GetElevProviderEnum(inival);
            }
            return einival;
        }
        public static void SetInitialElevProvider(string inisval)
        {
            PlayerPrefs.SetString(initialElevProviderKey, inisval);
        }
        #endregion ElevProvider

        public UxSetting<int> modeSetCount = new UxSetting<int>("ModeSetCount", 0);
        public UxSetting<int> numNodesPerQktile = new UxSetting<int>("NumNodesPerQktile", 4);
        public UxSetting<int> levelOfDetail = new UxSetting<int>("levelOfDetail", 14);
        public UxSettingBool InstantMapSettingsChange = new UxSettingBool("InstantMapSettingsChange", true);
        public UxSettingBool useElevations = new UxSettingBool("UseElevations", true);

        public UxSettingBool flatTris = new UxSettingBool("FlatTris", false);
        public UxSettingBool frameQuadkeys = new UxSettingBool("quadKeyFraming", false);
        public UxSettingBool viewerBreadCrumbs = new UxSettingBool("viewerBreadCrumbs", false);
        public UxSettingBool triPoints = new UxSettingBool("triPoints", false);
        public UxSettingBool nodeMarkers = new UxSettingBool("nodeMarkers", false);
        public UxSettingBool meshGrid = new UxSettingBool("meshGrid", false);
        public UxSettingBool meshPoints = new UxSettingBool("meshPoints", false);
        public UxSettingBool coordPoints = new UxSettingBool("coordPoints", false);
        public UxSettingBool extentPoints = new UxSettingBool("extentPoints", false);
        public UxSetting<string> inputAddress = new UxSetting<string>("inputAddress", "");

        public UxSetting<double> custom_maplat = new UxSetting<double>("custom_lat", 51.476852);// Greenwich
        public UxSetting<double> custom_maplng = new UxSetting<double>("custom_lng", 0);
        public UxSetting<double> custom_latkm = new UxSetting<double>("custom_latkm", 1);
        public UxSetting<double> custom_lngkm = new UxSetting<double>("custom_lngkm", 1);

        public UxSetting<float> mapScale = new UxSetting<float>("mapScale", 1);
        public UxSettingVector3 mapRot= new UxSettingVector3("mapRot", Vector3.zero);
        public UxSettingVector3 mapTrans = new UxSettingVector3("mapTrans", Vector3.zero);

        public UxSettingBool HasLLmap = new UxSettingBool("hasLLmap", false);
        public UxSettingBool locIsCustomizable = new UxSettingBool("locIsCustomizable", false);

        //Viewer.viewerDefaultPosition = Vector3.zero;
        //    Viewer.viewerDefaultRotation = Vector3.zero;
        //    Viewer.viewerAvatarDefaultValue = ViewerAvatar.CapsuleMan;
        //    Viewer.ViewerCamPositionDefaultValue = ViewerCamPosition.FloatBehind;
        //    Viewer.ViewerControlDefaultValue = ViewerControl.Velocity;

        public UxSettingVector3 viewerPosition = new UxSettingVector3("viewerPosition", Vector3.zero);
        public UxSettingVector3 viewerRotation = new UxSettingVector3("viewerRotation", Vector3.zero);
        public UxEnumSetting<ViewerAvatar> viewerAvatar = new UxEnumSetting<ViewerAvatar>("viewerAvatar", ViewerAvatar.QuadCopter);
        public UxEnumSetting<ViewerCamPosition> viewerCamPosition = new UxEnumSetting<ViewerCamPosition>("viewerCamPosition", ViewerCamPosition.FloatBehind);
        public UxEnumSetting<ViewerControl> viewerControl = new UxEnumSetting<ViewerControl>("viewerControl", ViewerControl.Velocity);

        public UxSetting<float> hmult = new UxSetting<float>("Hmult", 1f );

        public void GetSceneModeDependentInitialPersistentSettings()
        {
            modeSetCount.GetInitial();

            lod = levelOfDetail.GetInitial();
            npqk = numNodesPerQktile.GetInitial();
            address = inputAddress.GetInitial();
            maplat = custom_maplat.GetInitial();
            maplng = custom_maplng.GetInitial();
            zdistkm = custom_latkm.GetInitial();
            xdistkm = custom_lngkm.GetInitial();

            mapScale.GetInitial();
            mapRot.GetInitial();
            mapTrans.GetInitial();

            HasLLmap.GetInitial();
            locIsCustomizable.GetInitial();

            numNodesPerQktile.GetInitial();

            mapVisiblity.GetInitial();
            reqEleProv.GetInitial();
            reqMapProv.GetInitial();
            useElevations.GetInitial();

            frameQuadkeys.GetInitial();
            viewerBreadCrumbs.GetInitial();
            triPoints.GetInitial();
            nodeMarkers.GetInitial();
            meshGrid.GetInitial();
            meshPoints.GetInitial();
            coordPoints.GetInitial();
            extentPoints.GetInitial();

            flatTris.GetInitial();
            hmult.GetInitial();

            viewerPosition.GetInitial();
            viewerRotation.GetInitial();
            viewerAvatar.GetInitial();
            viewerCamPosition.GetInitial();
            viewerControl.GetInitial();
        }

        public void InitPhase0()
        {
        }


        // Use this for initialization

        public float GetHeight(float x,float z)
        {
            if (qmapman == null || qmapman.qmm==null) return 0;
            var p = new Vector3(x, 0, z);
            var (v, _, _) = qmapman.qmm.GetWcMeshPosProjectedAlongYnew(p);
            return v.y;
        }

        void CreateQmap()
        {
            qmapgo = new GameObject("QmapMan");
            qmapman = qmapgo.AddComponent<QmapMan>();
            RealizeQmap();
        }
        async void RealizeQmap()
        {
            //Debug.LogWarning($"QmapMan.RealizeQmap lod:{lod}");
            qmapgo.transform.parent = null;// we need to set this to force the next transformation to occur
            qmapgo.transform.SetParent(this.transform, worldPositionStays: false);
            RealizeMapVisuals();
            qmapman.qmapMode = QmapMan.QmapModeE.Bespoke;
            //var fak = 2*0.4096f;
            //qmapman.bespoke = new BespokeSpec(lastregionset.ToString(), maplat,maplng, fak*zscale, fak*xscale,lod:17 );
            qmapman.bespoke = new BespokeSpec(lastregionset.ToString(), maplat,maplng, zdistkm, xdistkm,lod:lod,nodesPerQuadKey:npqk );

            qmapman.bespoke.mapProv = reqMapProv.Get();
            qmapman.bespoke.eleProv = reqEleProv.Get();
            qmapman.bespoke.hmult = hmult.Get();
            qmapman.bespoke.useElevationData = useElevations.Get();
            qmapman.bespoke.useFlatTris = flatTris.Get();
            qmapman.bespoke.frameQuadkeys = frameQuadkeys.Get();
            qmapman.bespoke.triLines = meshGrid.Get();
            qmapman.bespoke.triPoints = triPoints.Get();
            qmapman.bespoke.meshPoints = meshPoints.Get();
            qmapman.bespoke.coordPoints = coordPoints.Get();
            qmapman.bespoke.extentPoints = extentPoints.Get();
            qmapman.bespoke.useViewer = true;
            qmapman.bespoke.maptrans = maptrans;
            qmapman.bespoke.maprot = new Vector3(0,this.roty2,0);
            var ska = 1 / mapscale;
            qmapman.bespoke.mapscale = new Vector3(ska, ska, ska);
            //qmapman.bespoke.maprot = new Vector3(0, 0, 0);
            qmapman.bespoke.mappoints = new List<MappingPoint>();
            if (hasLLmap)
            {
                var mapdata = sman?.glbllm?.mapcoord?.mapdata;
                if (mapdata != null)
                {
                    foreach (var p in mapdata)
                    {
                        qmapman.bespoke.mappoints.Add(new MappingPoint(p.lat, p.lng, p.x, p.z));
                        //Debug.Log($"ptcnt:{qmapman.bespoke.mappoints.Count}");
                    }
                }
            }
            var (nbm,nel) = await qmapman.SetMode(qmapman.qmapMode);
            if (nbm>0 || nel>0)
            {
                // if we loaded bitmaps we need to redraw everything from scratch
                sman.RequestRefresh("RealizeQmap", totalrefresh: true);
            }
            //Debug.Log("RealizeQmap done");
            //Debug.Log($"bespoke ptcnt:{qmapman.bespoke.mappoints.Count}");
        }

        //public (LatLngBox, string, string, bool, string) GetLlbSpec()
        //{
        //    LatLngBox llb = null;
        //    (var ll, var name, var nearplace, var ok, var errmsg) = await GetLatLng();
        //    if (ok)
        //    {
        //        llb = new LatLngBox(ll, latkm, lngkm, name, lod);
        //    }
        //    return (llb, name, nearplace, ok, errmsg);
        //}


        public (int,int) EstimateNumFilesInFetch(string scenename,MapProvider mapprov, ElevProvider elprov, LatLng ll,float latkm,float lngkm,int lod,int ntpq)
        {
            var llbox = new LatLngBox(ll, latkm, lngkm, lod: lod);
            var (nqkx, nqky) = llbox.GetTileSize();
            var nbm = nqkx * nqky;
            var nel = nqkx * ntpq * nqky * ntpq / 500;
            //(var _, var nbm, var nel) = await qmapman.MakeMeshFromLlbox(scenename, llbox, mapprov: mapprov, elevprov:elprov, execute: false, forceload: false, limitQuadkeys: false);
            return (nbm, nel);
        }

        public void SetMap(MapProvider map)
        {
            Debug.Log($"SetMap:{map}");
            reqMapProv.SetAndSave(map);
            //qmapman.mapprov = map;
            qmapman.qmm.mapprov = map;
        }
        public void SetEle(ElevProvider ele)
        {
            reqEleProv.SetAndSave(ele);
            //qmapman.elevprov = ele;
            qmapman.qmm.elevprov = ele;
        }
        public void SetUseElevations(bool neweleval)
        {
            useElevations.SetAndSave(neweleval);
            qmapman.useElevationDataStart = neweleval;
            qmapman.qmm.useElevationData = neweleval;
        }
        public void SetLatLngAndExtent(string lookupaddress,double lat,double lng,double latkm,double lngkm)
        {
            inputAddress.SetAndSave(lookupaddress);
            custom_maplat.SetAndSave(lat);
            custom_maplng.SetAndSave(lng);
            custom_latkm.SetAndSave(latkm);
            custom_lngkm.SetAndSave(lngkm);
            address = lookupaddress;
            maplat = lat;
            maplng = lng;
            xdistkm = lngkm;
            zdistkm = latkm;
            var ll = new LatLng(lat, lng);
            var llbox = new LatLngBox(ll, latkm, lngkm, lod:lod);
            qmapman.bespoke.llbox = llbox;
            //Debug.LogWarning($"mman.SetLatLngAndExtent SetAndSave: lookupaddress:{lookupaddress}");
            //Debug.Log($"mman.SetLatLngAndExtent: lat:{lat} lng:{lng} latkm:{latkm} lngkm:{lngkm}");
        }
        public void SetLod(int newlod)
        {
            levelOfDetail.SetAndSave(newlod);
            if (newlod < 0) newlod = 0;
            if (newlod > 19) newlod = 19;
            Debug.Log($"mman.SetLod:{newlod}");
            lod = newlod;
            if (qmapman?.qmm != null)
            {
                qmapman.qmm.levelOfDetail = newlod;
            }
        }
        public void SetNtqk(int newntqk)
        {
            numNodesPerQktile.SetAndSave(newntqk);
            if (newntqk < 1) newntqk = 1;
            if (newntqk > 20) newntqk = 20;
            Debug.Log($"mman.SetNtqk:{newntqk}");
            npqk = newntqk;
            qmapman.qmm.secsPerQkTile = newntqk;
        }

        public void SetHmult(float newhmult)
        {
            hmult.SetAndSave(newhmult);
            if (qmapman.qmm != null)
            {
                qmapman.qmm.hmult = newhmult;
            }
        }
        public void SetFlatTris(bool flattris)
        {
            flatTris.SetAndSave(flattris);
            qmapman.useFlatTrisStart = flattris;
            if (qmapman.qmm != null)
            {
                qmapman.qmm.flatTriangles = flattris;
            }
        }

        public LatLngBox GetLlbox()
        {
            var rv = qmapman.qmm.stats.llbox;
            return rv;
        }
        public QkmeshStatistics GetQkmeshStatistics()
        {
            var rv = qmapman?.qmm?.stats;
            return rv;
        }

        public void SetQuadkeyFraming(bool onoff)
        {
            //Debug.Log($"MapMan.SetQuadKeyFraming:{onoff}");
            frameQuadkeys.SetAndSave(onoff);
            if (qmapman != null)
            {
                qmapman.SetFrameQuadKey(onoff);
            }
        }

        public void SetViewerBreadCrumbs(bool onoff)
        {
            viewerBreadCrumbs.SetAndSave(onoff);
            //qmapman.frameQuadkeysStart = onoff;
            //qmapman.qmm. = onoff;
        }
        public void SetMeshGrid(bool onoff)
        {
            //Debug.Log($"MapMan.SetTrilines:{onoff}");
            meshGrid.SetAndSave(onoff);
            if (qmapman != null)
            {
                qmapman.SetTrilines(onoff);
            }
        }

        public void SetTriPoints(bool onoff)
        {
            //Debug.Log($"MapMan.SetTriPoints:{onoff}");
            triPoints.SetAndSave(onoff);
            if (qmapman != null)
            {
                qmapman.SetTriPoints(onoff);
            }
        }
        public void SetMeshPoints(bool onoff)
        {
            //Debug.Log($"MapMan.SetMeshPoints:{onoff}");
            meshPoints.SetAndSave(onoff);
            if (qmapman != null)
            {
                qmapman.SetMeshPoints(onoff);
            }
        }
        public void SetCoordPoints(bool onoff)
        {
            //Debug.Log($"MapMan.SetCoordPoints:{onoff}");
            coordPoints.SetAndSave(onoff);
            if (qmapman != null)
            {
                qmapman.SetCoordPoints(onoff);
            }
        }
        public void SetExtentPoints(bool onoff)
        {
            //Debug.Log($"MapMan.SetExtentPoints:{onoff}");
            extentPoints.SetAndSave(onoff);
            if (qmapman != null)
            {
                qmapman.SetExtentPoints(onoff);
            }
        }


        public GameObject AddLine(string lname, Vector3 pt1, Vector3 pt2, float lska = 1.0f, float nska = 1.0f, string lclr = "red", string nclr = "", int omit = -1, float widratio = 1, bool wps = true, bool frag=false)
        {
            if (qmapman == null || qmapman.qmm == null) return null;
            GameObject lgo;
            if (frag)
            {
                lgo = qmapman.qmm.qtt.AddFragLine(lname, pt1, pt2, lska, nska, lclr, nclr, omit, widratio, wps);
            }
            else
            {
                lgo = qmapman.qmm.qtt.AddStraightLine(lname, pt1, pt2, lska, nska, lclr, nclr, omit, widratio, wps);
            }
            return lgo;
        }
        public GameObject AddLine(GameObject parent,string lname, Vector3 pt1, Vector3 pt2, float lska = 1.0f, float nska = 1.0f, string lclr = "red", string nclr = "", int omit = -1, float widratio = 1, bool wps = true, bool frag = false)
        {
            if (qmapman == null || qmapman.qmm == null) return null;
            GameObject lgo;
            if (frag)
            {
                lgo = qmapman.qmm.qtt.AddFragLine(parent, lname, pt1, pt2, lska, nska, lclr, nclr, omit, widratio, wps);
            }
            else
            {
                lgo = qmapman.qmm.qtt.AddStraightLine(parent, lname, pt1, pt2, lska, nska, lclr, nclr, omit, widratio, wps);
            }
            return lgo;
        }


        public void DeleteMaps()
        {
            Debug.Log("Deleting Scene Maps");
            qmapman.qmm.DeleteSceneData();
        }
        public async void LoadMaps()
        {
            Debug.Log("Loading Scene Maps");
            QkMan.nbmLoaded = 0;
            QmapElevation.nblkdone = 0;
            qmapman.bespoke.lod = lod;
            qmapman.bespoke.llbox.lod = lod;
            qmapman.bespoke.nodesPerQuadKey = npqk;
            await qmapman.SetMode(qmapman.qmapMode,forceload:true);
        }
        public (bool isLoading,bool irupt,int lodLoading,int nbmLoaded,int nbmToLoad,int nelevBatchesLoaded, int nelevBatchsToLoad) GetLoadingStatus()
        {
            var isLoading = qmapman.qmm == null;
            var irupt = Aiskwk.Map.QkMan.interruptLoading;
            var nbmLoaded = QkMan.nbmLoaded;
            var nbmToLoad = QkMan.nbmToLoad;
            var lodLoading = QkMan.lodLoading;
            var nelevBatchesLoaded = QmapElevation.nblkdone;
            var nelevBatchsToLoad = QmapElevation.nblktodo;
            return (isLoading, irupt,lodLoading, nbmLoaded, nbmToLoad, nelevBatchesLoaded, nelevBatchsToLoad);
        }

        public (string, string,string, string, string, string,string,string) GetGeoDataStoragePaths()
        {
            var s1 = "pers path";
            var s2 = "pers info";
            var s3 = "pers elev";
            var s4 = "pers info blah blah";
            var s5 = "temp path";
            var s6 = "temp info";
            var s7 = "temp elev";
            var s8 = "temp info blah blah blah";
            var qmm = qmapman.qmm;
            if (qmm != null)
            {
                var qrfbitm = qmm.qkm.GetTexQrf(qmm.mapprov,qmm.scenename, qmm.mapExtent,qmm.levelOfDetail,loadData:false);
                var efname = "eledata.csv";
                var efpath = "qkmaps/" + qmapman.qmm.qmapElev.GetEleCsvSubDir(qmm.scenename, qmm.mapprov);
                var (nrowx, ncolz) = qmm.qmapElev.GetGridSize();
                var qrfelev = new QresFinder(qmm.elevprov, qmm.scenename,nrowx,ncolz,efpath,efname, loadData: false);
                s1 = qrfbitm.GetPersistentPathName();
                s2 = qrfbitm.GetPersistentFileData();
                s3 = qrfelev.GetPersistentPathName();
                s4 = qrfelev.GetPersistentFileData();

                s5 = qrfbitm.GetTempPathName();
                s6 = qrfbitm.GetTempFileData();
                s7 = qrfelev.GetTempPathName();
                s8 = qrfelev.GetTempFileData();

                var qkk = qmapman.qmm.qkm;
                s6 += $" {qkk.nqk.x}*{qkk.nqk.y}={qkk.nqk.x * qkk.nqk.y}";
                //Debug.Log($"s1:{s1}");
                //Debug.Log($"s2:{s2}");
                //Debug.Log($"s3:{s3}");
                //Debug.Log($"s4:{s4}");
                //Debug.Log($"s5:{s5}");
                //Debug.Log($"s6:{s6}");
            }
            return (s1,s2,s3,s4,s5,s6,s7,s8);
        }
        public int GetLod()
        {
            var rv = 0;
            if (qmapman!=null && qmapman.qmm!=null)
            {
                rv = qmapman.qmm.levelOfDetail;
            }
            return rv;
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
        // Scene Parameters
        // Fixed - set in select and never changed:
        //    sceneselector
        //    mapscale
        //    maprot
        //    maptrans
        //    hasLLmap
        //    Viewerinitiilzation settins
        // Sometimes Customizable - if iscusomizable==true can be changed can be overridden by useraction
        //    lng
        //    lat
        //    latkm
        //    lngkm
        // Customizable - can be overridden by user actions:
        //    scenename
        //    lod
        //    ntpq
        //

        SceneSelE lastregionset = SceneSelE.None;
        public void SetScene(SceneSelE newregion)
        {
            Debug.Log($"MapMan.SetRegion: {newregion}");
            GetSceneModeDependentInitialPersistentSettings();


            RealizeMapVisuals();
            if (newregion == lastregionset)
            {
                Debug.LogWarning("MapMan.SetScene - Region " + newregion + " already set");
                //return;
            }
            maprot = Vector3.zero;
            maptrans = Vector3.zero;
            useElesForNow = false;
            useViewer = true;
            int defaultlod = levelOfDetail.Get();
            lod = defaultlod;
            mapscale = 3.2f;
            maprot = Vector3.zero;
            maptrans = Vector3.zero;
            roty2 = -90;
            //hmultForNow = 1;
            npqk = numNodesPerQktile.Get();// Was 16
            hasLLmap = false;
            isCustomizable = false;
            var vviewerDefaultPosition = Vector3.zero;
            var vviewerDefaultRotation = Vector3.zero;
            var vviewerAvatarDefaultValue = ViewerAvatar.CapsuleMan;
            var vviewerCamPositionDefaultValue = ViewerCamPosition.FloatBehind;
            var vviewerControlDefaultValue = ViewerControl.Velocity;

            var msc = modeSetCount.Get();
            if (msc == 0)
            {
                switch (newregion)
                {
                    default:
                    case SceneSelE.MsftB19focused:
                        maplat = 47.639217;
                        maplng = -122.134216;
                        mapscale = 3.2f;
                        maprot = new Vector3(0, 71.1f, 0);
                        maptrans = new Vector3(-6, 0, 17);
                        //xdistkm = 1;
                        //zdistkm = 2;
                        xdistkm = 2;
                        zdistkm = 3;
                        //nodesPerQuadKey = 4;
                        lod = 16;
                        hasLLmap = true;
                        vviewerAvatarDefaultValue = ViewerAvatar.QuadCopter;
                        vviewerDefaultPosition = new Vector3(-451.5f, 3f, 98.3f);
                        vviewerDefaultRotation = new Vector3(0, -60, 0);
                        isCustomizable = false;
                        break;
                    case SceneSelE.MsftRedwest:
                        maplat = 47.659377;
                        maplng = -122.140189;
                        mapscale = 3.2f;
                        maprot = new Vector3(0, 71.1f, 0);
                        maptrans = new Vector3(-6 - 1970.0f + 4, 0, 17 - 1122.0f - 16);
                        xdistkm = 1;
                        zdistkm = 1;
                        vviewerAvatarDefaultValue = ViewerAvatar.QuadCopter;
                        vviewerDefaultPosition = new Vector3(-2035.2f, 3.8f, -1173.5f);
                        vviewerDefaultRotation = new Vector3(0, 163.310f, 0);
                        isCustomizable = false;
                        hasLLmap = true;
                        break;
                    case SceneSelE.Eb12small:
                    case SceneSelE.Eb12:
                        // better with google maps
                        maplat = 49.993311;
                        maplng = 8.678343;
                        mapscale = 3.2f;
                        //nodesPerQuadKey = 8;
                        maprot = new Vector3(0, -90, 0);
                        xdistkm = 1;
                        zdistkm = 1;
                        lod = 15;
                        hasLLmap = true;
                        isCustomizable = false;
                        vviewerAvatarDefaultValue = ViewerAvatar.QuadCopter;
                        vviewerDefaultPosition = new Vector3(0, 0, 0);
                        vviewerDefaultRotation = new Vector3(0, 0, 0);
                        break;
                    case SceneSelE.Tukwila:
                        // better with google maps
                        maplat = 47.456970;
                        maplng = -122.258825;
                        mapscale = 3.2f;
                        xdistkm = 1;
                        zdistkm = 1;
                        //lod = defaultlod;
                        hasLLmap = true;
                        isCustomizable = false;
                        break;
                    case SceneSelE.MsftDublin:
                        maplat = 53.268998;
                        maplng = -6.196680;
                        xdistkm = 2;
                        zdistkm = 1;
                        //lod = defaultlod;
                        mapscale = 3.2f;
                        hasLLmap = true;
                        isCustomizable = false;
                        vviewerAvatarDefaultValue = ViewerAvatar.QuadCopter;
                        break;
                    case SceneSelE.MsftCoreCampus:
                        maplat = 47.639217;
                        maplng = -122.134216;
                        mapscale = 3.2f;
                        maprot = new Vector3(0, 71.1f, 0);
                        maptrans = new Vector3(-6, 0, 17);
                        xdistkm = 2;
                        zdistkm = 6;
                        //lod = defaultlod;
                        hasLLmap = true;
                        isCustomizable = false;
                        vviewerAvatarDefaultValue = ViewerAvatar.QuadCopter;
                        vviewerDefaultPosition = new Vector3(-451.5f, 3f, 98.3f);
                        vviewerDefaultRotation = new Vector3(0, -60, 0);
                        break;
                    case SceneSelE.Seattle:
                        maplat = 47.619992;
                        maplng = -122.3373495;
                        mapscale = 3.2f;
                        maprot = Vector3.zero;
                        maptrans = Vector3.zero;
                        xdistkm = 14.84f / (2 * 0.4096f);
                        zdistkm = 25.17f / (2 * 0.4096f);
                        lod = 12;
                        //hmultForNow = 10;
                        useElesForNow = true;
                        useViewer = true;
                        mapscale = 1f;
                        roty2 = 0;
                        //nodesPerQuadKey = 8;
                        vviewerAvatarDefaultValue = ViewerAvatar.QuadCopter;
                        hasLLmap = false;
                        isCustomizable = false;
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
                        useElesForNow = true;
                        useViewer = true;
                        roty2 = 0;
                        vviewerAvatarDefaultValue = ViewerAvatar.Rover;
                        vviewerDefaultPosition = new Vector3(0, -60, 0);
                        //vviewerDefaultRotation = new Vector3(0,  90, 0); // bug only zero rotation works at the moment
                        vviewerDefaultRotation = new Vector3(0, 0, 0);
                        mapscale = 1f;
                        isCustomizable = false;
                        hasLLmap = false;
                        break;
                    case SceneSelE.Custom:
                        maplat = 45.412219;
                        maplng = -116.328921;
                        mapscale = 3.2f;
                        maprot = Vector3.zero;
                        maptrans = Vector3.zero;
                        xdistkm = 10;
                        zdistkm = 10;
                        lod = 13;
                        useElesForNow = true;
                        useViewer = true;
                        roty2 = 0;
                        mapscale = 1f;
                        isCustomizable = true;
                        vviewerAvatarDefaultValue = ViewerAvatar.QuadCopter;
                        hasLLmap = false;
                        break;
                    case SceneSelE.Riggins:
                        maplat = 45.412219;
                        maplng = -116.328921;
                        maprot = Vector3.zero;
                        maptrans = Vector3.zero;
                        xdistkm = 10;
                        zdistkm = 10;
                        lod = 14;
                        useElesForNow = true;
                        useViewer = true;
                        roty2 = 0;
                        mapscale = 1f;
                        vviewerAvatarDefaultValue = ViewerAvatar.QuadCopter;
                        hasLLmap = false;
                        isCustomizable = false;
                        break;
                }
                mapScale.SetAndSave(mapscale);
                mapRot.SetAndSave(maprot);
                mapTrans.SetAndSave(maptrans);
                HasLLmap.SetAndSave(hasLLmap);
                custom_maplat.SetAndSave(maplat);
                custom_maplng.SetAndSave(maplng);
                custom_latkm.SetAndSave(zdistkm);
                custom_lngkm.SetAndSave(xdistkm);
                viewerPosition.SetAndSave(vviewerDefaultPosition);
                viewerRotation.SetAndSave(vviewerDefaultRotation);
                viewerAvatar.SetAndSave(vviewerAvatarDefaultValue);
                viewerCamPosition.SetAndSave(vviewerCamPositionDefaultValue);
                viewerControl.SetAndSave(vviewerControlDefaultValue);
                levelOfDetail.SetAndSave(lod);
                locIsCustomizable.SetAndSave(isCustomizable);
            }

            Viewer.viewerDefaultPosition = viewerPosition.Get();
            Viewer.viewerDefaultRotation = viewerRotation.Get();
            Viewer.viewerAvatarDefaultValue = viewerAvatar.Get();
            Viewer.ViewerCamPositionDefaultValue = viewerCamPosition.Get();
            Viewer.ViewerControlDefaultValue = viewerControl.Get();

            maplat = custom_maplat.Get();
            maplng = custom_maplng.Get();
            zdistkm = custom_latkm.Get();
            xdistkm = custom_lngkm.Get();
            if (zdistkm <= 0) zdistkm = 1f;// backstop, this should never really hapen
            if (xdistkm <= 0) xdistkm = 1f;

            mapscale = mapScale.Get();
            maprot = mapRot.Get();
            maptrans = mapTrans.Get();

            hasLLmap = HasLLmap.Get();
            isCustomizable = locIsCustomizable.Get();

            modeSetCount.SetAndSave(msc + 1);
            transform.localRotation = Quaternion.identity;
            transform.Rotate(maprot.x, maprot.y, maprot.z);
            transform.position = maptrans;
            transform.localScale = new Vector3(mapscale, mapscale, mapscale);
            lastregionset = newregion;
            Debug.Log($"MapMan.SetScene {msc} {newregion} - lod:{lod} scale:{mapscale} rot:{maprot} trans:{maptrans} ");
            Initialize();
        }
    }
}