using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;
using System.IO;

namespace Aiskwk.Map
{
    public class Version
    {
        public static string Number = "1.4.0";
        public static string DateVersioned = "2020-04-16-18-00-00";
    }

    [Serializable]
    public class LocSpecer
    {
        public string locW3wSpec = "sounds.foil.lake";
        public string locW3wlngLat = "";
        public string locW3wNearestPlace = "";
        public string locW3wErrorMsg = "";
        public float latkm = 2;
        public float lngkm = 2;
        public int lod = 15;
        public bool limitQuadkeys = true;
        public bool locW3wExecute = false;
        public bool locSpecTrialExecute = false;
        public string sizestring = "";
        public bool locSpecExecute = false;
        public QmapMan qm;
        public LocSpecer(QmapMan qm)
        {
            this.qm = qm;
            locSpecTrialExecute = false;
            locSpecExecute = false;
            locW3wExecute = false;
            limitQuadkeys = true;
        }
        public static bool IsMaybeValidW3W(string w3w)
        {
            var s = w3w.Split('.');
            var rv = s.Length == 3;
            return rv;
        }
        public async Task<(LatLng, string, string, bool, string)> W3Wrequest(string w3w, LatLng ll)
        {
            // API docs
            bool ok = false;
            string errmsg = "no error";
            string apikey = "VZWZ1PGA";
            var nearplace = "";

            // https://t1.ssl.ak.dynamic.tiles.virtualearth.net/comp/ch/021230030212230?mkt=en&it=A,G,L,LA&og=30&n=z
            //
            string w3wuri;
            if (w3w == "")
            {
                var llstr = ll.ToW3Wformat();
                w3wuri = $"https://api.what3words.com/v3/convert-to-3wa?coordinates={llstr}&key={apikey}";
            }
            else
            {
                w3wuri = $"https://api.what3words.com/v3/convert-to-coordinates?words={w3w}&key={apikey}";
            }
            using (var webRequest = UnityWebRequest.Get(w3wuri))
            {
                // Request and wait for the desired page.
                webRequest.SendWebRequest();
                while (!webRequest.isDone)
                {
                    //System.Threading.Thread.Sleep(50);// should probably do a yield or something
                    await Task.Delay(TimeSpan.FromSeconds(0.05f));
                    Debug.Log("   back from Thread.Sleep");
                }

                string[] pages = w3wuri.Split('/');
                int lastpage = pages.Length - 1;

                if (webRequest.isNetworkError)
                {
                    Debug.Log($"{pages[lastpage]} response code: {webRequest.responseCode} Error: {webRequest.error}");
                    ok = false;
                    errmsg = webRequest.error;
                }
                else if (webRequest.responseCode != 200)
                {
                    Debug.Log($"{pages[lastpage]} response code: {webRequest.responseCode} Error: {webRequest.error}");
                    ok = false;
                    errmsg = webRequest.error;
                }
                else
                {
                    Debug.Log($"{pages[lastpage]}  Received {webRequest.downloadHandler.data.Length} bytes");
                    var bytes = webRequest.downloadHandler.data;
                    var str = System.Text.Encoding.Default.GetString(bytes);
                    var jsonw3w = Aiskwk.SimpleJSON.JSON.Parse(str);
                    var coords = jsonw3w["coordinates"];
                    if (coords != "")
                    {
                        var lat = coords["lat"].AsDouble;
                        var lng = coords["lng"].AsDouble;
                        ll = new LatLng(lat, lng);
                    }
                    nearplace = jsonw3w["nearestPlace"];
                    if (w3w == "")
                    {
                        w3w = jsonw3w["words"];
                    }
                    ok = true;
                }
            }
            return (ll, w3w, nearplace, ok, errmsg);
        }
        public async Task<(LatLng, string, string, bool, string)> GetLatLngFromW3wApi(string w3w)
        {
            Debug.Log($"GetW3WfromW3Wapi:{w3w}");
            var rv = await W3Wrequest(w3w, null);
            return rv;
        }
        public async Task<(LatLng, string, string, bool, string)> GetW3wFromW3wApi(LatLng ll)
        {
            Debug.Log($"GetLatLngFromW3Wapi:{ll.ToW3Wformat()}");
            var rv = await W3Wrequest("", ll);
            return rv;
        }
        public async Task<(LatLng, string, string, bool, string)> GetLatLng()
        {
            return await GetLatLngFromW3wApi(locW3wSpec);
        }
        public async Task<(LatLngBox, string, string, bool, string)> GetLlbSpec()
        {
            LatLngBox llb = null;
            (var ll, var name, var nearplace, var ok, var errmsg) = await GetLatLng();
            if (ok)
            {
                llb = new LatLngBox(ll, latkm, lngkm, name, lod);
            }
            return (llb, name, nearplace, ok, errmsg);
        }
        public async void ExecuteW3wApi()
        {
            var (isValid, ll) = LatLng.IsValidLatLngString(locW3wlngLat);
            if (isValid)
            {
                var (_, w3w, np, ok, errmsg) = await GetW3wFromW3wApi(ll);
                locW3wErrorMsg = errmsg;
                if (ok)
                {
                    locW3wSpec = w3w;
                    locW3wNearestPlace = np;
                }
            }
            else if (locW3wSpec != "")
            {
                var (llnew, _, np, ok, errmsg) = await GetLatLngFromW3wApi(locW3wSpec);
                locW3wErrorMsg = errmsg;
                if (ok)
                {
                    locW3wlngLat = llnew.ToW3Wformat();
                    locW3wNearestPlace = np;
                }

            }
            locW3wExecute = false;
        }
        public async void Execute0(bool execute, bool forceload)
        {
            Debug.Log("Execute:" + execute);
            (var llbox, var locname, var nearplace, var ok, var errmsg) = await GetLlbSpec();
            if (ok)
            {
                //InitMeshW3w(locname, locnames, ll, w3wlatkm, w3wlngkm, w3wlod);
                (var qk, var nbm, var nel) = await qm.MakeMeshFromLlbox(locname, llbox, mapprov: qm.mapprov, execute: execute, forceload: forceload, limitQuadkeys: limitQuadkeys);
                var msg = $"Tiles:{nbm}  Elevblocks:{nel}";
                sizestring = msg;
                Debug.Log("Execute0 " + msg);
            }
        }
        public void Execute()
        {
            qm.ClearMesh();
            Execute0(execute: true, forceload: false);
            locSpecExecute = false;
        }
        public void TrialExecute()
        {
            Execute0(execute: false, forceload: true);
            locSpecTrialExecute = false;
        }
    }
    public class BespokeSpec
    {
        public string SceneName;
        public MapProvider mapProv;
        public MapExtentTypeE MapExtent;
        public int lod;
        public LatLng LatLng;
        public LatLngBox llbox;
        public double LatExtentKm;
        public double LngExtentKm;
        public Vector3 maprot;
        public Vector3 maptrans;
        public bool useElevationData;
        public BespokeSpec(string scenename, LatLng ll, double latkm, double lngkm, int lod = 16)
        {
            Init(scenename, ll, latkm, lngkm, lod);
        }
        public BespokeSpec(string scenename, double lat, double lng, double latkm, double lngkm, int lod = 16)
        {
            var ll = new LatLng(lat, lng);
            Init(scenename, ll, latkm, lngkm, lod);
        }
        void Init(string scenename, LatLng ll, double latkm, double lngkm, int lod)
        {
            SceneName = scenename;
            useElevationData = false;
            mapProv = MapProvider.AzureMaps;
            LatExtentKm = latkm;
            LngExtentKm = lngkm;
            MapExtent = MapExtentTypeE.AsSpecified;
            llbox = new LatLngBox(ll, latkm, lngkm, lod: lod);
        }

    }

    public class QmapMan : MonoBehaviour
    {
        public enum QmapModeE { None, MsftCampus, MsftCampusMapped, MsftCampusMappedHigh, MsftCampusMappedHigh19, Seattle, Seattle3, Seattle10, Cyclades, Horizon4, Horizon16, MtStHelens16, MtStHelens12, MtStHelens3, MtStHelens2, FortHills, Dozers, DozerSmall, DozersMedium, DozersMediumSim, Eb12, Eb12Mapped, Riggins, Tukwilla, MtFuji, Whistler, What3words, Bespoke }
        public QmapModeE qmapMode = QmapModeE.None;
        public GameObject rgo = null;
        public GameObject qkgo = null;
        public GameObject llgo = null;
        public string scenename;
        public string mapcoordname;
        public string descriptor;
        public LocSpecer locSpecer;
        public bool executeWhat3Words = false;
        public bool useElevationDataStart = true;
        public SceneScripter sceneScripter = null;

        public BespokeSpec bespoke;

        QmapMesh qmm = null;

        [Header("Providers")]
        public MapProvider mapprov;
        public ElevProvider elevprov;

        [Header("Files")]
        public bool deleteAllSceneData;

        // Start is called before the first frame update
        void Awake()
        {
            ConfigureSystemEnvironment();

        }

        void Start()
        {
            locSpecer = new LocSpecer(this);
            SetMode(qmapMode);
            lastQmapMode = qmapMode;
        }
        public void ClearMesh()
        {
            var qkgonull = qkgo == null;
            var llgonull = llgo == null;
            Debug.Log($"ClearMesh qkgonull:{qkgonull}  llgonull:{llgonull}");
            Destroy(qkgo);
            qkgo = null;
            Destroy(llgo);
            llgo = null;
        }

        public void ConfigureSystemEnvironment()
        {
            string hostName = System.Net.Dns.GetHostName().ToLower();
            Debug.Log($"hostname:{hostName}");
            if (hostName == "uxie")
            {
                trackFilePath = "d:/transfer/tracks/";
                gdalFilePath = "d:/transfer/gdal/";
            }
        }

        public async Task<(QmapMesh, int, int)> MakeMesh(string scenename, int lod, LatLng ll1, LatLng ll2, string mapcoordname = "", int tpqk = 4, float hmult = 1, MapProvider mapprov = MapProvider.BingSatelliteRoads, ElevProvider elevprov = ElevProvider.Bing)
        {
            var llbox = new LatLngBox(ll1, ll2, scenename, lod: lod);
            return await MakeMeshFromLlbox(scenename, llbox, mapcoordname: mapcoordname, tpqk: tpqk, hmult: hmult, mapprov: mapprov, elevprov: elevprov);
        }

        public async Task<(QmapMesh, int, int)> MakeMeshFromLlbox(string scenename, LatLngBox llbox, int tpqk = 4, float hmult = 1, string mapcoordname = "", MapExtentTypeE mapextent = MapExtentTypeE.SnapToTiles, MapProvider mapprov = MapProvider.BingSatelliteRoads, ElevProvider elevprov = ElevProvider.Bing, bool execute = true, bool forceload = false,
                                                               bool limitQuadkeys = true, QmapMesh.sythTexMethod synthTex = QmapMesh.sythTexMethod.Quadkeys,
                                                               HeightSource heitSource = HeightSource.Fetched, HeightAdjust heitAdjust = HeightAdjust.Zeroed) //, HeightTypeE heitType= HeightTypeE.FetchedAndZeroed)
        {

            var wpstays = false;
            Debug.Log($"QmapMan.MakeMeshFromLlbox scenename:{scenename} wpstays:{wpstays}");
            this.mapprov = mapprov;
            this.elevprov = elevprov;
            this.scenename = scenename;
            this.mapcoordname = mapcoordname;
            if (rgo != null)
            {
                Destroy(rgo);
                rgo = null;
            }
            rgo = new GameObject("rgo");
            rgo.transform.SetParent(this.transform, worldPositionStays: wpstays);
            qkgo = new GameObject("QmapMesh");
            qkgo.transform.SetParent(rgo.transform, worldPositionStays: wpstays);
            qkgo.transform.position = Vector3.zero;

            var qmmcomp = qkgo.AddComponent<QmapMesh>();
            qmmcomp.descriptor = $"{scenename} {llbox.lod} {mapprov} {mapextent}";
            qmmcomp.InitializeGrid(scenename, llbox, mapprov:mapprov, elevprov:elevprov, mapcoordname: mapcoordname);
            qmmcomp.secsPerQkTile = tpqk;
            qmmcomp.useElevationData = useElevationDataStart;
            qmmcomp.mapExtent = mapextent;
            qmmcomp.hmult = hmult;
            qmmcomp.synthTex = synthTex;
            qmmcomp.limitQuadkeys = limitQuadkeys;
            //qmmcomp.heightType = heitType;
            qmmcomp.heightSource = heitSource;
            qmmcomp.heightAdjust = heitAdjust;

            (var nbm, var nel) = await qmmcomp.GenerateGrid(execute, forceload, limitQuadkeys: limitQuadkeys);

            return (qmmcomp, nbm, nel);
        }
        string gdalFilePath = "c:/transfer/gdal/";
        string trackFilePath = "c:/transfer/tracks/";
        public async void SetMode(QmapModeE newmode)
        {
            //Debug.Log("SetMode:" + newmode);
            ClearMesh();
            useElevationDataStart = true;

            switch (newmode)
            {
                case QmapModeE.Bespoke:
                    {
                        useElevationDataStart = false;
                        (qmm, _, _) = await MakeMeshFromLlbox(bespoke.SceneName, bespoke.llbox, tpqk: 16, mapprov: bespoke.mapProv, mapextent: bespoke.MapExtent, limitQuadkeys: false);
                        var rotv = bespoke.maprot;
                        transform.localRotation = Quaternion.identity;
                        transform.Rotate(rotv.x, rotv.y, rotv.z);
                        transform.position = bespoke.maptrans;
                        Debug.Log($"Setting bespoke - transform:{bespoke.maptrans} rot:{rotv.y}");
                        qmm.nodefak = 1f;
                        break;
                    }
                case QmapModeE.None:
                    {
                        // do nothing
                        break;
                    }
                case QmapModeE.What3words:
                    {
                        // do nothing
                        break;
                    }
                case QmapModeE.MsftCampus:
                    {
                        var ll1 = new LatLng(47.646622, -122.139957, "MsftCampus ll1"); // msft campus
                        var ll2 = new LatLng(47.631792, -122.128826, "MsftCampus ll2");
                        (qmm, _, _) = await MakeMesh("msftcampus", 15, ll1, ll2, mapprov: mapprov);
                        break;
                    }
                case QmapModeE.MsftCampusMapped:
                    {
                        var ll1 = new LatLng(47.646622, -122.139957, "MsftCampus ll1"); // msft campus
                        var ll2 = new LatLng(47.631792, -122.128826, "MsftCampus ll2");
                        (qmm, _, _) = await MakeMesh("msftcampus", 15, ll1, ll2, mapcoordname: "MsftCoreCampus", mapprov: mapprov);
                        break;
                    }
                case QmapModeE.MsftCampusMappedHigh:
                    {
                        var ll1 = new LatLng(47.646622, -122.139957, "MsftCampus ll1"); // msft campus
                        var ll2 = new LatLng(47.631792, -122.128826, "MsftCampus ll2");
                        (qmm, _, _) = await MakeMesh("msftcampus", 18, ll1, ll2, mapcoordname: "MsftCoreCampus", tpqk: 4, mapprov: mapprov);
                        break;
                    }
                case QmapModeE.MsftCampusMappedHigh19:
                    {
                        var ll1 = new LatLng(47.646622, -122.139957, "MsftCampus ll1"); // msft campus
                        var ll2 = new LatLng(47.631792, -122.128826, "MsftCampus ll2");
                        (qmm, _, _) = await MakeMesh("msftcampus", 19, ll1, ll2, mapcoordname: "MsftCoreCampus", tpqk: 2, mapprov: mapprov);
                        break;
                    }
                case QmapModeE.Cyclades:
                    {
                        //var llmid = new LatLng(36.674545, 25.271239, "Cyclades mid");
                        var llmid = new LatLng(36.801411, 25.271239, "Cyclades mid");
                        var llbox = new LatLngBox(llmid, 110, 170, lod: 12);
                        useElevationDataStart = true;
                        Viewer.viewerDefaultRotation = new Vector3(0, 90, 0);
                        Viewer.viewerDefaultPosition = new Vector3(0, 0, 0);
                        Viewer.ViewerCamPositionDefaultValue = ViewerCamPosition.FloatBehind;
                        (qmm, _, _) = await MakeMeshFromLlbox("cyclades", llbox, tpqk: 16, hmult: 3, mapprov: mapprov, limitQuadkeys: false);
                        var vtm = gameObject.AddComponent<VehicleTrackMan>();
                        vtm.Init(qmm, trackFilePath, VehicleTrackMan.TrackScenario.CycladesTrip);
                        sceneScripter = gameObject.AddComponent<SceneScripter>();
                        sceneScripter.Init(SceneScenario.Cyclades, vtm);
                        qmm.addViewer = true;
                        var dirlight = FindObjectOfType<Light>();
                        if (dirlight != null)
                        {
                            dirlight.transform.localRotation = Quaternion.Euler(50, -100, 0);
                        }
                        break;
                    }
                case QmapModeE.Seattle:
                    {
                        var llmid = new LatLng(47.619992, -122.3373495, "Seattle mid");
                        var llbox = new LatLngBox(llmid, 25.17, 14.84, lod: 12);
                        useElevationDataStart = true;
                        Viewer.viewerDefaultRotation = new Vector3(0, 90, 0);
                        Viewer.viewerDefaultPosition = new Vector3(0, 0, 0);
                        Viewer.ViewerCamPositionDefaultValue = ViewerCamPosition.FloatBehind;

                        //(qmm,_,_) = await MakeMeshBox("seattle", llbox,tpqk:16,hmult:10, mapprov: mapprov);
                        (qmm, _, _) = await MakeMeshFromLlbox("seattle", llbox, tpqk: 16, hmult: 10, mapprov: mapprov, synthTex: QmapMesh.sythTexMethod.Quadkeys);
                        var tpcomp = qmm.gameObject.GetComponent<TrilinesDeco>();
                        if (tpcomp != null)
                        {
                            tpcomp.showDeco = false;
                        }
                        qmm.addViewer = true;
                        break;
                    }
                case QmapModeE.Seattle10:
                    {
                        var llmid = new LatLng(47.619992, -122.3373495, "Seattle mid");
                        var llbox = new LatLngBox(llmid, 10, 10, lod: 13);
                        (qmm, _, _) = await MakeMeshFromLlbox("seattle", llbox, tpqk: 16, hmult: 10, mapprov: mapprov);
                        qmm.addViewer = true;
                        break;
                    }
                case QmapModeE.Seattle3:
                    {
                        //useElevationDataStart = false;
                        Viewer.viewerDefaultRotation = new Vector3(0, 90, 0);
                        Viewer.viewerDefaultPosition = new Vector3(0, 0, 0);
                        Viewer.ViewerCamPositionDefaultValue = ViewerCamPosition.FloatBehind;
                        var llmid = new LatLng(47.619992, -122.3373495, "Seattle mid");
                        var llbox = new LatLngBox(llmid, 3, 3, lod: 18);
                        //(qmm,_,_) = await MakeMeshFromLlbox("seattle", llbox, tpqk: 16, hmult: 2, mapprov: mapprov, heitType: HeightTypeE.FetchedAndOriginZeroed, heitSource:HeightSource.Fetched, heitAdjust: HeightAdjust.OriginZeroed, limitQuadkeys: false);
                        (qmm, _, _) = await MakeMeshFromLlbox("seattle", llbox, tpqk: 16, hmult: 2, mapprov: mapprov, heitSource: HeightSource.Fetched, heitAdjust: HeightAdjust.OriginZeroed, limitQuadkeys: false);
                        qmm.addMeshColliders = true;
                        qmm.AddMeshColliders();
                        qmm.addViewer = true;
                        break;
                    }
                case QmapModeE.FortHills:
                    {
                        var ll1 = new LatLng(57.404272, -111.670935, "FortHills ll1"); // suncor fort hills
                        var ll2 = new LatLng(57.180913, -111.272580, "FortHills ll2");
                        (qmm, _, _) = await MakeMesh("forthills", 12, ll1, ll2, mapprov: mapprov);
                        var trkman = gameObject.AddComponent<VehicleTrackMan>();
                        trkman.Init(qmm, trackFilePath, VehicleTrackMan.TrackScenario.SuncorMine);
                        break;
                    }
                case QmapModeE.Dozers:
                    {
                        var llmid = new LatLng(57.01, -111.375, "Dozers llmid");
                        var llbox = new LatLngBox(llmid, 4.453, 6.666, "dozerbox", lod: 15);
                        Debug.Log("dozers-llbox llmid:" + llbox.midll.ToString());
                        Debug.Log("dozers-llbox llmid:" + llbox.midll.ToString());
                        Viewer.viewerDefaultRotation = new Vector3(0, 90, 0);
                        Viewer.viewerDefaultPosition = new Vector3(0, 0, 0);
                        Viewer.ViewerCamPositionDefaultValue = ViewerCamPosition.FloatBehind;
                        //(qmm,_,_) = await MakeMeshFromLlbox("dozers", llbox, tpqk: 16, hmult: 5, mapprov: mapprov, heitType: HeightTypeE.FetchedAndOriginZeroed, heitSource: HeightSource.Fetched, heitAdjust: HeightAdjust.OriginZeroed);
                        (qmm, _, _) = await MakeMeshFromLlbox("dozers", llbox, tpqk: 16, hmult: 3, mapprov: mapprov, heitSource: HeightSource.FetchedPlusLidar, heitAdjust: HeightAdjust.NoAdjust);
                        var geoman = gameObject.AddComponent<GeotiffMan>();
                        qmm.nodefak = 0.2f;
                        geoman.Init(qmm, gdalFilePath);
                        geoman.showMediumGeosTiffs12 = true;
                        var trkman = gameObject.AddComponent<VehicleTrackMan>();
                        trkman.Init(qmm, trackFilePath, VehicleTrackMan.TrackScenario.SuncorMine);
                        qmm.addViewer = true;
                        break;
                    }
                case QmapModeE.DozersMediumSim:
                case QmapModeE.DozersMedium:
                    {
                        var llmid = new LatLng(57.0056037, -111.3581390, "Dozers Medium llmid");
                        var llbox = new LatLngBox(llmid, 1.0, 1.0, "dozermediumbox", lod: 19);
                        //Debug.Log("dozers-med-llbox llmid:" + llbox.midll.ToString());
                        Viewer.viewerDefaultRotation = new Vector3(0, 90, 0);
                        Viewer.viewerDefaultPosition = new Vector3(0, 0, 0);
                        Viewer.ViewerCamPositionDefaultValue = ViewerCamPosition.FloatBehind;
                        var geoman = gameObject.AddComponent<GeotiffMan>();
                        var trkman = gameObject.AddComponent<VehicleTrackMan>();
                        (qmm, _, _) = await MakeMeshFromLlbox("dozersmedium", llbox, tpqk: 8, hmult: 1, mapextent: MapExtentTypeE.AsSpecified, mapprov: mapprov, heitSource: HeightSource.FetchedPlusLidar, limitQuadkeys: false);
                        qmm.nodefak = 1f;
                        geoman.Init(qmm, gdalFilePath, 4, 4, initShowDecos: false);
                        geoman.showMediumGeosTiffs2 = true;
                        trkman.Init(qmm, trackFilePath, VehicleTrackMan.TrackScenario.SuncorMine);
                        if (newmode == QmapModeE.DozersMediumSim)
                        {
                            sceneScripter = gameObject.AddComponent<SceneScripter>();
                            sceneScripter.Init(SceneScenario.SuncorDozers, trkman);
                        }
                        qmm.addViewer = true;
                        break;
                    }
                case QmapModeE.DozerSmall:
                    {
                        var llmid = new LatLng(57.0056037, -111.3581390, "Dozers  Smallllmid");
                        var llbox = new LatLngBox(llmid, 0.5, 0.5, "dozersmallbox", lod: 19);
                        Debug.Log("dozers-small-llbox llmid:" + llbox.midll.ToString());
                        Viewer.viewerDefaultRotation = new Vector3(0, 90, 0);
                        Viewer.viewerDefaultPosition = new Vector3(0, 0, 0);
                        Viewer.ViewerCamPositionDefaultValue = ViewerCamPosition.FloatBehind;
                        var geoman = gameObject.AddComponent<GeotiffMan>();
                        var trkman = gameObject.AddComponent<VehicleTrackMan>();
                        (qmm, _, _) = await MakeMeshFromLlbox("dozerssmall", llbox, tpqk: 10, hmult: 5, mapprov: mapprov);
                        qmm.nodefak = 1f;
                        geoman.Init(qmm, gdalFilePath, 4, 4);
                        geoman.showMediumGeosTiffs2 = true;
                        trkman.Init(qmm, trackFilePath, VehicleTrackMan.TrackScenario.SuncorMine);
                        qmm.addViewer = true;
                        break;
                    }
                case QmapModeE.Horizon4:
                    {
                        var llmid = new LatLng(57.338920, -111.750198, "CNRL Horizon llmid");
                        var llbox = new LatLngBox(llmid, 4.0, 4.0, "horizonbox", lod: 17);
                        Debug.Log("Horizon-llbox llmid:" + llbox.midll.ToString());
                        Viewer.viewerAvatarDefaultValue = ViewerAvatar.Minehaul1;
                        Viewer.ViewerCamPositionDefaultValue = ViewerCamPosition.FloatBehind;
                        Viewer.ViewerControlDefaultValue = ViewerControl.Velocity;
                        Viewer.viewerDefaultPosition = new Vector3(155.30f, 64.06f, -9.77f);
                        Viewer.viewerDefaultRotation = new Vector3(0, -90, 0);
                        (qmm, _, _) = await MakeMeshFromLlbox("horizon", llbox, tpqk: 16, hmult: 1, mapprov: mapprov, limitQuadkeys: false);
                        qmm.nodefak = 1f;
                        break;
                    }
                case QmapModeE.Horizon16:
                    {
                        var llmid = new LatLng(57.338920, -111.750198, "CNRL Horizon llmid");
                        var llbox = new LatLngBox(llmid, 16.0, 16.0, "horizonbox", lod: 15);
                        Debug.Log("Horizon-llbox llmid:" + llbox.midll.ToString());
                        Viewer.viewerAvatarDefaultValue = ViewerAvatar.Minehaul1;
                        Viewer.ViewerCamPositionDefaultValue = ViewerCamPosition.FloatBehind;
                        Viewer.ViewerControlDefaultValue = ViewerControl.Velocity;
                        Viewer.viewerDefaultPosition = new Vector3(164.62f, 64.06f, -235.97f);
                        Viewer.viewerDefaultRotation = new Vector3(0, -90, 0);
                        (qmm, _, _) = await MakeMeshFromLlbox("horizon", llbox, tpqk: 16, hmult: 1, mapprov: mapprov, limitQuadkeys: false);
                        qmm.nodefak = 1f;
                        break;
                    }
                case QmapModeE.MtStHelens16:
                    {
                        var llmid = new LatLng(46.198428, -122.188841, "MtStHellens16llmid");
                        var llbox = new LatLngBox(llmid, 16.0, 16.0, "MtStHellens16 box", lod: 15);
                        Debug.Log("MtStHellens16-llbox llmid:" + llbox.midll.ToString());
                        Viewer.viewerAvatarDefaultValue = ViewerAvatar.Rover;
                        Viewer.ViewerCamPositionDefaultValue = ViewerCamPosition.FloatBehind;
                        Viewer.ViewerControlDefaultValue = ViewerControl.Velocity;
                        (qmm, _, _) = await MakeMeshFromLlbox("mtsthelens", llbox, tpqk: 16, hmult: 1, mapextent: MapExtentTypeE.AsSpecified, mapprov: mapprov, limitQuadkeys: false);
                        qmm.nodefak = 1f;
                        qmm.addViewer = true;
                        break;
                    }
                case QmapModeE.MtStHelens12:
                    {
                        var llmid = new LatLng(46.198428, -122.188841, "MtStHellensllmid");
                        var llbox = new LatLngBox(llmid, 12.0, 12.0, "MtStHellens box", lod: 16);
                        Debug.Log("MtStHellens-llbox llmid:" + llbox.midll.ToString());
                        Viewer.viewerAvatarDefaultValue = ViewerAvatar.Rover;
                        Viewer.ViewerCamPositionDefaultValue = ViewerCamPosition.FloatBehind;
                        Viewer.ViewerControlDefaultValue = ViewerControl.Velocity;
                        (qmm, _, _) = await MakeMeshFromLlbox("mtsthelens", llbox, tpqk: 16, hmult: 1, mapextent: MapExtentTypeE.AsSpecified, mapprov: mapprov, limitQuadkeys: false);
                        qmm.nodefak = 0.2f;
                        qmm.addViewer = true;
                        break;
                    }
                case QmapModeE.MtStHelens3:
                    {
                        var llmid = new LatLng(46.198428, -122.188841, "MtStHellens3llmid");
                        var llbox = new LatLngBox(llmid, 3.0, 3.0, "MtStHellens3 box", lod: 17);
                        Debug.Log("MtStHellens3-llbox llmid:" + llbox.midll.ToString());
                        Viewer.viewerAvatarDefaultValue = ViewerAvatar.Rover;
                        Viewer.ViewerCamPositionDefaultValue = ViewerCamPosition.FloatBehind;
                        Viewer.ViewerControlDefaultValue = ViewerControl.Velocity;
                        (qmm, _, _) = await MakeMeshFromLlbox("mtsthelens", llbox, tpqk: 16, hmult: 1, mapextent: MapExtentTypeE.AsSpecified, mapprov: mapprov, limitQuadkeys: false);
                        qmm.nodefak = 0.2f;
                        var tpcomp = qmm.gameObject.GetComponent<TriPointDeco>();
                        if (tpcomp != null)
                        {
                            tpcomp.showDeco = false;
                        }
                        qmm.addViewer = true;
                        break;
                    }
                case QmapModeE.MtStHelens2:
                    {
                        var llmid = new LatLng(46.198428, -122.188841, "MtStHellens3llmid");
                        var llbox = new LatLngBox(llmid, 3.0, 3.0, "MtStHellens3 box", lod: 19);
                        Debug.Log("MtStHellens3-llbox llmid:" + llbox.midll.ToString());
                        Viewer.viewerAvatarDefaultValue = ViewerAvatar.Rover;
                        Viewer.ViewerCamPositionDefaultValue = ViewerCamPosition.FloatBehind;
                        Viewer.ViewerControlDefaultValue = ViewerControl.Velocity;
                        (qmm, _, _) = await MakeMeshFromLlbox("mtsthelens", llbox, tpqk: 16, hmult: 1, mapextent: MapExtentTypeE.AsSpecified, mapprov: mapprov, limitQuadkeys: false);
                        qmm.nodefak = 0.2f;
                        break;
                    }
                case QmapModeE.Riggins:
                    {
                        var llmid = new LatLng(45.412219, -116.328921, "Riggins");
                        var llbox = new LatLngBox(llmid, 10.0, 10.0, "Riggins box", lod: 15);
                        Debug.Log("riggins-llbox llmid:" + llbox.midll.ToString());
                        (qmm, _, _) = await MakeMeshFromLlbox("riggins", llbox, tpqk: 16, hmult: 1, mapprov: mapprov);
                        //var qcm = InitMesh("dozers", "", 15, ll1, ll2, 16, 10, mapprov: mapprov);
                        qmm.nodefak = 0.2f;
                        break;
                    }
                case QmapModeE.Eb12:
                    {
                        var ll1 = new LatLng(49.996606, 8.674300, "Eb12 ll1"); // EB12 in Germany
                        var ll2 = new LatLng(49.987100, 8.687557, "Eb12 ll2");
                        (qmm, _, _) = await MakeMesh("eb12", 16, ll1, ll2, tpqk: 2, hmult: 10, mapprov: mapprov);
                        break;
                    }
                case QmapModeE.Eb12Mapped:
                    {
                        var ll1 = new LatLng(49.996606, 8.674300, "Eb12 ll1"); // EB12 in Germany
                        var ll2 = new LatLng(49.987100, 8.687557, "Eb12 ll2");
                        (qmm, _, _) = await MakeMesh("eb12", 16, ll1, ll2, mapcoordname: "Eb12", mapprov: mapprov);
                        break;
                    }
                case QmapModeE.Tukwilla:
                    {
                        var ll1 = new LatLng(47.461414, -122.262566, "Tukwila ll1"); // Tukwila
                        var ll2 = new LatLng(47.453419, -122.253639, "Tukwila ll2");
                        (qmm, _, _) = await MakeMesh("tukwila", 16, ll1, ll2, mapprov: mapprov);
                        break;
                    }
                case QmapModeE.MtFuji:
                    {
                        var ll1 = new LatLng(35.450153, 138.603933, "MtFuji ll1"); // MtFuji
                        var ll2 = new LatLng(35.296752, 138.874443, "MtFuji ll2");
                        (qmm, _, _) = await MakeMesh("mtfuji", 14, ll1, ll2, tpqk: 8, mapprov: mapprov);
                        qmm.nodefak = 0.5f;
                        break;
                    }
                case QmapModeE.Whistler:
                    {
                        var ll1 = new LatLng(50.229914, -122.859530, "Whistler ll1"); // Whistler
                        var ll2 = new LatLng(50.029914, -123.2595303, "Whistler ll2");
                        (qmm, _, _) = await MakeMesh("whistler", 14, ll1, ll2, tpqk: 4, mapprov: mapprov);
                        qmm.nodefak = 0.5f;
                        break;
                    }
                    // 49.996606, 8.674300
            }

        }
        //public void InitMeshW3w(string w3w,string name,LatLng ll,float latkm,float lngkm,int lod)
        //{
        //    var llbox = new LatLngBox(ll, latkm, lngkm, name, lod:lod);
        //    (qmm,_,_) = MakeMeshFromLlbox(name,llbox, 16, 10, mapprov: mapprov);
        //}

        QmapModeE lastQmapMode = QmapModeE.None;
        // Update is called once per frame
        void Update()
        {
            if (lastQmapMode != qmapMode)
            {
                SetMode(qmapMode);
                lastQmapMode = qmapMode;
            }
            if (locSpecer.locSpecExecute)
            {
                locSpecer.Execute();
            }
            if (locSpecer.locSpecTrialExecute)
            {
                locSpecer.TrialExecute();
            }
            if (locSpecer.locW3wExecute)
            {
                Debug.Log("so ExecuteW3wApi");
                locSpecer.ExecuteW3wApi();
            }
            if (deleteAllSceneData)
            {
                Debug.Log("Deleting all scene data");
                if (qmm != null)
                {
                    qmm.deleteSceneData = true;
                }
                deleteAllSceneData = false;
            }
        }

    }
}