﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UxUtils;
using Aiskwk.Map;
using System.Runtime.InteropServices;

namespace CampusSimulator
{
    public class MapMan : MonoBehaviour
    {
        public SceneMan sman;

        GameObject qmapgo;
        QmapMan qmapman;
 
        public double xdistkm = 1;
        public double zdistkm = 3;
        public double xoffkm = 0;
        public double zoffkm = 0;

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
            if (qmapgo != null)
            {
                qmapgo.SetActive(active);
            }
        }
        #endregion Map Visuals


        public UxEnumSetting<MapProvider> reqMapProv = new UxEnumSetting<MapProvider>("MapProvider", MapProvider.BingSatelliteLabels);
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

        public UxSetting<double> custom_maplat = new UxSetting<double>("custom_lat", 51.476852);
        public UxSetting<double> custom_maplng = new UxSetting<double>("custom_lng", 0);
        public UxSetting<double> custom_latkm = new UxSetting<double>("custom_latkm", 1);
        public UxSetting<double> custom_lngkm = new UxSetting<double>("custom_lngkm", 1);

        public UxSetting<float> mapScale = new UxSetting<float>("mapScale", 1);
        public UxSettingVector3 mapRot= new UxSettingVector3("mapRot", Vector3.zero);
        public UxSettingVector3 mapTrans = new UxSettingVector3("mapTrans", Vector3.zero);

        //public UxSettingBool HasLLmap = new UxSettingBool("hasLLmap", false);
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
        public Vector3 GetHeightVector3(Vector3 p)
        {
            if (qmapman == null || qmapman.qmm == null) return Vector3.zero;
            var oy = p.y;
            var np = new Vector3(p.x, 0, p.z);
            var (v, _, _) = qmapman.qmm.GetWcMeshPosProjectedAlongYnew(np,cliptocorners:true);
            var nv = new Vector3(v.x, v.y + oy, v.z);
            return nv;
        }


        public void DeleteQmap()
        {
            if (qmapman!=null)
            {
                qmapman.DeleteQmm();
            }
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
            qmapman.bespoke = new BespokeSpec(lastsceneset.ToString(), maplat,maplng, zdistkm, xdistkm,zoffkm,xoffkm,lod:lod,nodesPerQuadKey:npqk );

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
            qmapman.bespoke.viewHome = viewHome;
            qmapman.bespoke.maptrans = maptrans;
            qmapman.bespoke.maprot = new Vector3(0,this.roty2,0);
            var ska = 1 / mapscale;
            qmapman.bespoke.mapscale = new Vector3(ska, ska, ska);
            //qmapman.bespoke.maprot = new Vector3(0, 0, 0);
            qmapman.bespoke.mappoints = new List<MappingPoint>();
            if (sman != null && sman.glbllm != null)
            {
                if (hasLLmap)
                {
                    // copy the mapcoords from our predefined map
                    var mapdata = sman.glbllm.mapcoord?.mapdata;
                    if (mapdata != null)
                    {
                        foreach (var p in mapdata)
                        {
                            qmapman.bespoke.mappoints.Add(new MappingPoint(p.lat, p.lng, p.x, p.z));
                            //Debug.Log($"ptcnt:{qmapman.bespoke.mappoints.Count}");
                        }
                    }
                }
                else
                {
                    var llm = sman.glbllm;
                    //llm.mapcoord.AddRowLatLng(47.640490, -122.133797, -149.1, 0.2);
                    var llb = qmapman.bespoke.llbox;
                    var llmd = llb.GetMidPoint();
                    var llbl = llb.GetBottomLeft();
                    var llur = llb.GetUpperRight();
                    var llbr = llb.GetBottomRight();
                    var llul = llb.GetUpperLeft();
                    var w = llb.extentMeters1.x/2;
                    var h = llb.extentMeters1.y/2;
                    llm.mapcoord.AddRowLatLng( llmd.lat, llmd.lng, 0,0);
                    llm.mapcoord.AddRowLatLng( llbl.lat, llbl.lng, -w, -h);
                    llm.mapcoord.AddRowLatLng( llur.lat, llur.lng, w, h);
                    llm.mapcoord.AddRowLatLng( llbr.lat, llbr.lng, w, -h);
                    llm.mapcoord.AddRowLatLng( llul.lat, llul.lng, -w, h);
                    llm.CalcRegressionMaps();
                }
            }
            var (nbm,nel) = await qmapman.SetMode(qmapman.qmapMode);
            sman.PostMapLoadSetScene(); // this has to go after the await
            if (nbm>0 || nel>0)
            {
                // if we loaded bitmaps we need to redraw everything from scratch
                sman.RequestRefresh("RealizeQmap", totalrefresh: true);
            }

            //Debug.Log("RealizeQmap done");
            //Debug.Log($"bespoke ptcnt:{qmapman.bespoke.mappoints.Count}");
        }

           public (int,int) EstimateNumFilesInFetch(string scenename,MapProvider mapprov, ElevProvider elprov, LatLng ll,float latkm,float lngkm,int lod,int ntpq)
        {
            var llbox = new LatLngBox(ll, latkm, lngkm, lod: lod);
            var (nqkx, nqky) = llbox.GetTileSize();
            var nbm = nqkx * nqky;
            var nel = nqkx * ntpq * nqky * ntpq / 500;
            //(var _, var nbm, var nel) = await qmapman.MakeMeshFromLlbox(scenename, llbox, mapprov: mapprov, elevprov:elprov, execute: false, forceload: false, limitQuadkeys: false);
            return (nbm, nel);
        }
        QmapMesh GetQmm(string caller="",bool complain=true)
        {
            if (qmapman != null)
            {
                if (qmapman.qmm != null)
                {
                    return qmapman.qmm;
                }
            }
            if (complain)
            {
                Debug.LogWarning($"MapMan - qmm is null - caller:{caller}");
            }
            return null;
        }
        public LatLongMap GetLatLongMapQk(QkCoordSys coordsys)
        {
            var qmm = GetQmm();
            if (qmm!=null)
            {
                var llm = qmm.GetLatLongMap(coordsys);
                return llm;

            }
            return null;
        }

        public LatLongMap GetLatLongMap()
        {
            var llm1 = sman.glbllm;
            var llm = llm1;
            var llm2 = sman.glbllm;
            if (!sman.mpman.hasLLmap)
            {
                llm2 = sman.mpman.GetLatLongMapQk(QkCoordSys.QkWc);
                llm = llm2;
            }
            //Debug.Log($"llm1 {llm1.initmethod}");
            //Debug.Log($"llm2 {llm2.initmethod}");
            //Debug.Log($"sman.mpman.hasLLmap {sman.mpman.hasLLmap}");
            //Debug.Log($"final llm {llm.initmethod}");
            return llm;
        }

        public void SetMapPovider(MapProvider map)
        {
            Debug.Log($"SetMapProvider:{map}");
            reqMapProv.SetAndSave(map);
            var qmm = GetQmm("SetMapPovider");
            if (qmm != null)
            {
                qmapman.mapprov = map;
                qmapman.bespoke.mapProv = map;
                qmm.mapprov = map;
            }
        }
        public void SetEleProvider(ElevProvider ele)
        {
            //Debug.Log($"SetEleProvider:{ele}");
            reqEleProv.SetAndSave(ele);
            var qmm = GetQmm("SetEleProvider");
            if (qmm != null)
            {
                qmapman.elevprov = ele;
                qmapman.bespoke.eleProv = ele;
                qmm.elevprov = ele;
            }
        }
        public void SetUseElevations(bool neweleval)
        {
            useElevations.SetAndSave(neweleval);
            var qmm = GetQmm("SetUseElevations");
            if (qmm != null)
            {
                qmapman.useElevationDataStart = neweleval;
                qmm.useElevationData = neweleval;
            }
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
            var qmm = GetQmm("SetLod");
            if (qmm != null)
            {
                qmm.levelOfDetail = newlod;
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
            var qmm = GetQmm("SetHmult");
            if (qmm != null)
            {
                qmm.hmult = newhmult;
            }
        }
        public void SetFlatTris(bool flattris)
        {
            flatTris.SetAndSave(flattris);
            qmapman.useFlatTrisStart = flattris;
            var qmm = GetQmm("SetFlatTris");
            if (qmm != null)
            {
                qmm.flatTriangles = flattris;
            }
        }

        public LatLngBox GetLlbox()
        {
            var qmm = GetQmm("SetFlatTris");
            if (qmm != null)
            {
                return qmm.stats.llbox;
            }
            else
            {
                return null;
            }
        }
        public QkmeshStatistics GetQkmeshStatistics()
        {
            var qmm = GetQmm("GetQkmeshStatistics");
            if (qmm != null)
            {
                return qmm.stats;
            }
            else
            {
                return null;
            }
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


        public GameObject AddLine(string lname, Vector3 pt1, Vector3 pt2,RmLinkFormE lnform=RmLinkFormE.pipe, float lska = 1.0f, float nska = 1.0f, string lclr = "red", string nclr = "", int omit = -1, float widratio = 1, bool wps = true, bool frag=false)
        {
            if (qmapman == null || qmapman.qmm == null) return null;
            var frm = lnform.ToString();
            GameObject lgo;
            if (frag)
            {
                lgo = qmapman.qmm.qtt.AddFragLine(lname, pt1, pt2,frm, lska, nska, lclr, nclr, omit, widratio, wps);
            }
            else
            {
                lgo = qmapman.qmm.qtt.AddStraightLine(lname, pt1, pt2, frm, lska, nska, lclr, nclr, omit, widratio, wps);
            }
            return lgo;
        }
        public GameObject AddLine(GameObject parent,string lname, Vector3 pt1, Vector3 pt2, RmLinkFormE lnform=RmLinkFormE.pipe, float lska = 1.0f, float nska = 1.0f, string lclr = "red", string nclr = "", int omit = -1, float widratio = 1, bool wps = true, bool frag = false)
        {
            if (qmapman == null || qmapman.qmm == null) return null;
            var frm = lnform.ToString();
            GameObject lgo;
            if (frag)
            {
                lgo = qmapman.qmm.qtt.AddFragLine(parent, lname, pt1, pt2, frm, lska, nska, lclr, nclr, omit, widratio, wps);
            }
            else
            {
                lgo = qmapman.qmm.qtt.AddStraightLine(parent, lname, pt1, pt2, frm, lska, nska, lclr, nclr, omit, widratio, wps);
            }
            return lgo;
        }


        public void EraseMapsFromDisk()
        {
            Debug.Log("Erasing Scene Maps from disk");
            qmapman.qmm.EraseSceneDataFromDisk();
        }
        public async void LoadMaps(bool forceload)
        {
            Debug.Log("Loading Scene Maps");
            QkMan.nbmLoaded = 0;
            QmapElevation.nblkdone = 0;
            qmapman.bespoke.lod = lod;
            qmapman.bespoke.llbox.lod = lod;
            qmapman.bespoke.nodesPerQuadKey = npqk;
            await qmapman.SetMode(qmapman.qmapMode,forceload:forceload);
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

        ViewerState viewHome;

        public void SetSceneDefaults(SceneSelE newscene)
        {
            maprot = Vector3.zero;
            maptrans = Vector3.zero;
            useElesForNow = false;
            useViewer = true;
            lod = 14;
            mapscale = 3.2f;
            maprot = Vector3.zero;
            maptrans = Vector3.zero;
            roty2 = -90;
            maplat = 51.476852;
            maplng = 0;
            //hmultForNow = 1;
            npqk = 8;// Was 16
            hasLLmap = false;
            isCustomizable = false;
            xdistkm = 1;
            zdistkm = 1;
 
            viewHome = new ViewerState(Vector3.zero, Vector3.zero, ViewerAvatar.QuadCopter, ViewerCamPosition.FloatBehind, ViewerControl.Velocity);

            switch (newscene)
            {
                default:
                case SceneSelE.MsftCoreCampus:
                    maplat = 47.639217;
                    maplng = -122.134216;
                    mapscale = 3.2f;
                    maprot = new Vector3(0, 71.1f, 0);
                    maptrans = new Vector3(-6, 0, 17);
                    xdistkm = 2;
                    zdistkm = 5;
                    //lod = defaultlod;
                    hasLLmap = true;
                    isCustomizable = false;

                    viewHome.viewerAvatarValue = ViewerAvatar.QuadCopter;
                    viewHome.viewerPosition = new Vector3(-451.5f, 3f, 98.3f);
                    viewHome.viewerRotation = new Vector3(0, -60, 0);
                    break;
                case SceneSelE.MsftB121focused:
                    //maplat = 47.639217;
                    //maplng = -122.134216;
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

                    viewHome.viewerAvatarValue = ViewerAvatar.QuadCopter;
                    viewHome.viewerPosition = new Vector3(-778, 10f, -524);
                    viewHome.viewerRotation = new Vector3(0, -40, 0);
                    isCustomizable = false;
                    break;
                case SceneSelE.MsftB19focused:
                    //maplat = 47.639217;
                    //maplng = -122.134216;
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

                    viewHome.viewerAvatarValue = ViewerAvatar.QuadCopter;
                    viewHome.viewerPosition = new Vector3(-451.5f, 3f, 98.3f);
                    viewHome.viewerRotation = new Vector3(0, -60, 0);

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

                    viewHome.viewerAvatarValue = ViewerAvatar.QuadCopter;
                    viewHome.viewerPosition = new Vector3(-2035.2f, 3.8f, -1173.5f);
                    viewHome.viewerRotation = new Vector3(0, 163.310f, 0);

                    isCustomizable = false;
                    hasLLmap = true;
                    break;
                case SceneSelE.MsftMountainView:
                    maplat = 37.411770;
                    maplng = -122.071381;
                    mapscale = 1;
                    xdistkm = 6;
                    zdistkm = 5;
                    lod = 15;
                    roty2 = 0;// this value aligns buildings to map (uses lat-lng coords)
                    hasLLmap = false;
                    isCustomizable = false;

                    viewHome.viewerAvatarValue = ViewerAvatar.QuadCopter;

                    break;
                case SceneSelE.Eb12small:
                case SceneSelE.Eb12:
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

                    viewHome.viewerAvatarValue = ViewerAvatar.QuadCopter;


                    break;
                case SceneSelE.TukSouCen:
                    maplat = 47.456970;
                    maplng = -122.258825;
                    mapscale = 3.2f;
                    xdistkm = 1;
                    zdistkm = 1;
                    lod = 18;
                    //roty2 = 0;// this value aligns buildings to map (uses lat-lng coords)
                    roty2 = -90; // this value aligns pipes to map (uses x-z coords)
                    hasLLmap = true;
                    isCustomizable = false;
                    viewHome.viewerAvatarValue = ViewerAvatar.QuadCopter;
                    viewHome.viewerRotation = new Vector3(0, -90, 0);


                    break;
                case SceneSelE.Seattle:
                    maplat = 47.608439;
                    maplng = -122.340765;
                    mapscale = 1;
                    maprot = Vector3.zero;
                    maptrans = Vector3.zero;
                    //xdistkm = 14.84f / (2 * 0.4096f);
                    //zdistkm = 25.17f / (2 * 0.4096f);
                    xdistkm = 6;
                    zdistkm = 8;
                    lod = 14;
                    //hmultForNow = 10;
                    useElesForNow = true;
                    useViewer = true;
                    mapscale = 1f;
                    roty2 = 0;
                    //nodesPerQuadKey = 8;
                    //vviewerAvatarDefaultValue = ViewerAvatar.QuadCopter;
                    viewHome.viewerAvatarValue = ViewerAvatar.QuadCopter;

                    hasLLmap = false;
                    isCustomizable = false;
                    break;
                case SceneSelE.SanFrancisco:
                    maplat = 37.774900;
                    maplng = -122.419400;
                    mapscale = 1;
                    xdistkm = 2;
                    zdistkm = 2;
                    lod = 18;
                    roty2 = 0;// this value aligns buildings to map (uses lat-lng coords)
                    hasLLmap = false;
                    isCustomizable = false;

                    viewHome.viewerAvatarValue = ViewerAvatar.QuadCopter;

                    break;
                case SceneSelE.Frankfurt:
                    maplat = 50.110465;
                    maplng = 8.6815720;
                    mapscale = 1;
                    xdistkm = 3;
                    zdistkm = 2;
                    lod = 17;
                    roty2 = 0;// this value aligns buildings to map (uses lat-lng coords)
                    hasLLmap = false;
                    isCustomizable = false;
                    //vviewerDefaultRotation = new Vector3(0, 0, 0);
                    //vviewerAvatarDefaultValue = ViewerAvatar.QuadCopter;
                    viewHome.viewerAvatarValue = ViewerAvatar.QuadCopter;

                    break;
                case SceneSelE.MsftDublin:
                    maplat = 53.268998;
                    maplng = -6.196680;
                    xdistkm = 2;
                    zdistkm = 1;
                    lod = 16;
                    mapscale = 3.2f;
                    hasLLmap = true;
                    isCustomizable = false;
                    //vviewerAvatarDefaultValue = ViewerAvatar.QuadCopter;
                    viewHome.viewerAvatarValue = ViewerAvatar.QuadCopter;
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

                    viewHome.viewerAvatarValue = ViewerAvatar.Rover;
                    viewHome.viewerPosition = new Vector3(0, -60, 0);

                    mapscale = 1f;
                    isCustomizable = false;
                    hasLLmap = false;
                    break;
                case SceneSelE.Custom:
                    maplat = 48.5126;
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
                    viewHome.viewerAvatarValue = ViewerAvatar.QuadCopter;
                    hasLLmap = false;
                    break;
                case SceneSelE.HiddenLakeLookout:
                    maplat = 48.5126;
                    maplng = -121.2357;
                    maprot = Vector3.zero;
                    maptrans = Vector3.zero;
                    xdistkm = 10;
                    zdistkm = 10;
                    lod = 14;
                    useElesForNow = true;
                    useViewer = true;
                    roty2 = 0;
                    mapscale = 1f;
                    viewHome.viewerAvatarValue = ViewerAvatar.QuadCopter;
                    hasLLmap = false;
                    isCustomizable = false;
                    break;
                case SceneSelE.TeneriffeMtn:
                    maplat = 47.501632;
                    maplng = -121.708343;
                    maprot = Vector3.zero;
                    maptrans = Vector3.zero;
                    xdistkm = 10;
                    zdistkm = 10;
                    lod = 14;
                    useElesForNow = true;
                    useViewer = true;
                    roty2 = 0;
                    mapscale = 1f;
                    viewHome.viewerAvatarValue = ViewerAvatar.QuadCopter;
                    hasLLmap = false;
                    isCustomizable = false;
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
                    viewHome.viewerAvatarValue = ViewerAvatar.QuadCopter;
                    hasLLmap = false;
                    isCustomizable = false;
                    break;
            }

        }
        public void GetInitials()
        {
            modeSetCount.GetInitial(0);

            lod = levelOfDetail.GetInitial(lod);
            Debug.Log($"mapman.GetSceneModeDependentInitialPersistentSettings levelOfDetail:{levelOfDetail.Get()}");
            npqk = numNodesPerQktile.GetInitial(npqk);
            address = inputAddress.GetInitial("");
            maplat = custom_maplat.GetInitial(maplat);// Greenwich
            maplng = custom_maplng.GetInitial(maplng);
            zdistkm = custom_latkm.GetInitial(zdistkm);
            xdistkm = custom_lngkm.GetInitial(xdistkm);

            mapscale = mapScale.GetInitial(mapscale);
            maprot = mapRot.GetInitial(maprot);
            maptrans = mapTrans.GetInitial(maptrans);

            //HasLLmap.GetInitial(false);
            locIsCustomizable.GetInitial(false);

            mapVisiblity.GetInitial(MapVisualsE.MapOn);
            reqEleProv.GetInitial(ElevProvider.BingElev);
            reqMapProv.GetInitial(MapProvider.BingSatelliteLabels);
            useElevations.GetInitial(true);

            frameQuadkeys.GetInitial(false);
            viewerBreadCrumbs.GetInitial(false);
            triPoints.GetInitial(false);
            nodeMarkers.GetInitial(false);
            meshGrid.GetInitial(false);
            meshPoints.GetInitial(false);
            coordPoints.GetInitial(false);
            extentPoints.GetInitial(false);

            flatTris.GetInitial(false);
            hmult.GetInitial();

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

        SceneSelE lastsceneset = SceneSelE.None;
        public void InitializeScene(SceneSelE newscene)
        {
            Debug.Log($"MapMan.InitializeScene: {newscene}");
            if (newscene == lastsceneset)
            {
                Debug.LogWarning("MapMan.SetScene - Region " + newscene + " already set");
                //return;
            }
            SetSceneDefaults(newscene);
            GetInitials();


            maplat = custom_maplat.Get();
            maplng = custom_maplng.Get();
            zdistkm = custom_latkm.Get();
            xdistkm = custom_lngkm.Get();
            if (zdistkm <= 0) zdistkm = 1f;// backstop, this should never really hapen
            if (xdistkm <= 0) xdistkm = 1f;

            mapscale = mapScale.Get();
            maprot = mapRot.Get();
            maptrans = mapTrans.Get();

            //hasLLmap = HasLLmap.Get();
            isCustomizable = locIsCustomizable.Get();

            transform.localRotation = Quaternion.identity;
            transform.Rotate(maprot.x, maprot.y, maprot.z);
            transform.position = maptrans;
            transform.localScale = new Vector3(mapscale, mapscale, mapscale);
            lastsceneset = newscene;
            Debug.Log($"MapMan.SetScene {newscene} - lod:{lod} scale:{mapscale} rot:{maprot} trans:{maptrans} ");
        }

        public void SetScene(SceneSelE newscene)
        {
            Debug.Log($"MapMan.SetScene: {newscene}");
            RealizeMapVisuals();
            Initialize();
        }

        public void SaveSceneState()
        {

        }


    }
}