using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;

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
        public enum LocSpecerSource {  What3words, AzureMaps }
        public LocSpecerSource locSpecerSource = LocSpecerSource.What3words;
        public string locSpec = "sounds.foil.lake";
        public string loclngLat = "";
        public string locNearestPlace = "";
        public string locErrorMsg = "";
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
        public (string,bool,string) GetUri(string locspec,LatLng ll)
        {
            var ok = false;
            var requri = "";
            string w3wapikey = "VZWZ1PGA";
            string azumapkey = "IdbTbLfVZWE6B5pnqB-ybmzk5KbM_lyQeLtt_YusYNc";
            string errmsg = "";
            if (locspec == "")
            {
                var llstr = ll.ToRequestformat();
                requri = "https:" + $"//api.what3words.com/v3/convert-to-3wa?coordinates={llstr}&key={w3wapikey}";
                ok = true;
            }
            else
            {
                if (IsMaybeValidW3W(locspec))
                {
                    requri = "https:" + $"//api.what3words.com/v3/convert-to-coordinates?words={locspec}&key={w3wapikey}";
                    ok = true;
                }
                else
                {
                    requri = "https:" + $"//atlas.microsoft.com/search/address/json?api-version=1.0&query={locspec}&subscription-key={azumapkey}";
                    ok = true;
                }
            }
            return (requri,ok,errmsg);
        }
        public async Task<(string outstring, bool reqok, string errmsg)> W3Wrequest(string requri)
        {
            bool reqisok = false;
            string errmsg = "no error";
            string outstring = "";
            using (var webRequest = UnityWebRequest.Get(requri))
            {
                // Request and wait for the desired page.
                webRequest.SendWebRequest();
                while (!webRequest.isDone)
                {
                    //System.Threading.Thread.Sleep(50);// should probably do a yield or something
                    await Task.Delay(TimeSpan.FromSeconds(0.05f));
                    Debug.Log("   back from Thread.Sleep");
                }

                string[] pages = requri.Split('/');
                int lastpage = pages.Length - 1;

                if (webRequest.isNetworkError)
                {
                    Debug.Log($"{pages[lastpage]} response code: {webRequest.responseCode} Error: {webRequest.error}");
                    reqisok = false;
                    errmsg = webRequest.error;
                }
                else if (webRequest.responseCode != 200)
                {
                    Debug.Log($"{pages[lastpage]} response code: {webRequest.responseCode} Error: {webRequest.error}");
                    reqisok = false;
                    errmsg = webRequest.error;
                }
                else
                {
                    Debug.Log($"{pages[lastpage]}  Received {webRequest.downloadHandler.data.Length} bytes");
                    var bytes = webRequest.downloadHandler.data;
                    outstring = System.Text.Encoding.Default.GetString(bytes);
                    reqisok = true;
                }
            }
            return (outstring, reqisok, errmsg);
        }

        public async Task<(LatLng ll, string w3w, string nearplace, bool ok, string errmsg)> W3Wrequest(string locspec, LatLng ll)
        {
            // API docs
            bool ok = false;

            var nearplace = "";
            var oll = ll;
            var olocspec = locspec;
            var outstring = "";

            // https://t1.ssl.ak.dynamic.tiles.virtualearth.net/comp/ch/021230030212230?mkt=en&it=A,G,L,LA&og=30&n=z
            //
            var (requri,uriok,errmsg) = GetUri(locspec, ll);
            var reqok = false;
            if (uriok)
            {
                (outstring, reqok, errmsg) = await W3Wrequest(requri);
            }
            if (reqok)
            { 
                    var json = Aiskwk.SimpleJSON.JSON.Parse(outstring);
                    Debug.Log($"jsonw3w");
                    var coords = json["coordinates"];
                    var res = json["results"];
                    if (coords.Count > 0)
                    {
                        //Debug.Log("In w3w");
                        var lat = coords["lat"].AsDouble;
                        var lng = coords["lng"].AsDouble;
                        oll = new LatLng(lat, lng);
                    }
                    if (res.Count>0)
                    {
                        //Debug.Log("In azuremaps");
                        var pos = res[0]["position"];
                        var lat = pos["lat"].AsDouble;
                        var lng = pos["lon"].AsDouble;
                        oll = new LatLng(lat, lng);
                    }
                    nearplace = json["nearestPlace"];
                    if (locspec == "")
                    {
                        olocspec = json["words"];
                    }
                    ok = true;
            }
            return (oll, olocspec, nearplace, ok, errmsg);
        }
        //public async Task<(LatLng ll, string w3w, string nearplace, bool ok, string errmsg)> oldW3Wrequest(string locspec, LatLng ll)
        //{
        //    // API docs
        //    bool ok = false;
        //    string errmsg = "no error";

        //    var nearplace = "";
        //    var oll = ll;
        //    var olocspec = locspec;

        //    // https://t1.ssl.ak.dynamic.tiles.virtualearth.net/comp/ch/021230030212230?mkt=en&it=A,G,L,LA&og=30&n=z
        //    //
        //    string requri = GetUri(locspec,ll);

        //    using (var webRequest = UnityWebRequest.Get(requri))
        //    {
        //        // Request and wait for the desired page.
        //        webRequest.SendWebRequest();
        //        while (!webRequest.isDone)
        //        {
        //            //System.Threading.Thread.Sleep(50);// should probably do a yield or something
        //            await Task.Delay(TimeSpan.FromSeconds(0.05f));
        //            Debug.Log("   back from Thread.Sleep");
        //        }

        //        string[] pages = requri.Split('/');
        //        int lastpage = pages.Length - 1;

        //        if (webRequest.isNetworkError)
        //        {
        //            Debug.Log($"{pages[lastpage]} response code: {webRequest.responseCode} Error: {webRequest.error}");
        //            ok = false;
        //            errmsg = webRequest.error;
        //        }
        //        else if (webRequest.responseCode != 200)
        //        {
        //            Debug.Log($"{pages[lastpage]} response code: {webRequest.responseCode} Error: {webRequest.error}");
        //            ok = false;
        //            errmsg = webRequest.error;
        //        }
        //        else
        //        {
        //            Debug.Log($"{pages[lastpage]}  Received {webRequest.downloadHandler.data.Length} bytes");
        //            var bytes = webRequest.downloadHandler.data;
        //            var oustring = System.Text.Encoding.Default.GetString(bytes);
        //            var jsonw3w = Aiskwk.SimpleJSON.JSON.Parse(oustring);
        //            var coords = jsonw3w["coordinates"];
        //            if (coords != "")
        //            {
        //                var lat = coords["lat"].AsDouble;
        //                var lng = coords["lng"].AsDouble;
        //                oll = new LatLng(lat, lng);
        //            }
        //            nearplace = jsonw3w["nearestPlace"];
        //            if (locspec == "")
        //            {
        //                olocspec = jsonw3w["words"];
        //            }
        //            ok = true;
        //        }
        //    }
        //    return (oll, olocspec, nearplace, ok, errmsg);
        //}
        public async Task<(LatLng ll, string w3w, string nearplace, bool ok, string errmsg)> GetLLfromLocspec(string locspec)
        {
            Debug.Log($"GetLLfromLocspec:{locspec}");
            var rv = await W3Wrequest(locspec, null);
            return rv;
        }
        public async Task<(LatLng ll, string w3w, string nearplace, bool ok, string errmsg)> GetLocspecFromLL(LatLng ll)
        {
            Debug.Log($"GetLocspecFromLL:{ll.ToRequestformat()}");
            var rv = await W3Wrequest("", ll);
            return rv;
        }
        public async Task<(LatLng ll, string w3w, string nearplace, bool ok, string errmsg)> GetLatLng()
        {
            return await GetLLfromLocspec(locSpec);
        }
        public async Task<(LatLngBox llbox, string w3w, string nearplace, bool ok, string errmsg)> GetLlbSpec()
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
            var (isValid, ll) = LatLng.IsValidLatLngString(loclngLat);
            if (isValid)
            {
                var (_, w3w, np, ok, errmsg) = await GetLocspecFromLL(ll);
                locErrorMsg = errmsg;
                if (ok)
                {
                    locSpec = w3w;
                    locNearestPlace = np;
                }
            }
            else if (locSpec != "")
            {
                var (llnew, _, np, ok, errmsg) = await GetLLfromLocspec(locSpec);
                locErrorMsg = errmsg;
                if (ok)
                {
                    loclngLat = llnew.ToRequestformat();
                    locNearestPlace = np;
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

    public enum QkCoordSys {  UserWc, QkWc };

    public class MappingPoint
    {
        public double lat;
        public double lng;
        public double userwc_x;
        public double userwc_z;
        public MappingPoint(double lat,double lng,double x,double z)
        {
            this.lat = lat;
            this.lng = lng;
            this.userwc_x = x;
            this.userwc_z = z;
        }
        public string Fmt()
        {
            var fll = "f6";
            var fxz = "f1";
            var s = "ll:"+lat.ToString(fll)+","+lng.ToString(fll)+"  x:"+userwc_x.ToString(fxz)+" z:"+userwc_z.ToString(fxz);
            return s;
        }
    }
    public class BespokeSpec
    {
        public string sceneName;
        public MapProvider mapProv;
        public ElevProvider eleProv;
        public MapExtentTypeE mapExtent;
        public int lod;
        public LatLng LatLng;
        public LatLngBox llbox;
        public double LatExtentKm;
        public double LngExtentKm;
        public double LatOffsetKm;
        public double LngOffsetKm;
        public Vector3 mapscale;
        public Vector3 maprot;
        public Vector3 maptrans;
        public bool useElevationData;
        public bool useFlatTris;
        public bool frameQuadkeys;
        public bool triPoints;
        public bool triLines;
        public bool meshPoints;
        public bool coordPoints;
        public bool extentPoints;
        public int nodesPerQuadKey;
        public float hmult;
        public bool useViewer;
        public ViewerState viewHome;
        public List<MappingPoint> mappoints= new List<MappingPoint>();
        public BespokeSpec(string scenename, LatLng ll, double latkm, double lngkm, double latoffkm, double lngoffkm, int lod = 16, int nodesPerQuadKey = 16)
        {
            Init(scenename, ll, latkm, lngkm, latoffkm, lngoffkm, lod, nodesPerQuadKey);
        }
        public BespokeSpec(string scenename, double lat, double lng, double latkm, double lngkm,double latoffkm,double lngoffkm, int lod = 16, int nodesPerQuadKey = 16)
        {
            var ll = new LatLng(lat, lng);
            Init(scenename, ll, latkm, lngkm,latoffkm,lngoffkm, lod, nodesPerQuadKey);
        }
        void Init(string scenename, LatLng ll, double latkm, double lngkm,double latoffkm,double lngoffkm, int lod, int nodesPerQuadKey = 16)
        {
            sceneName = scenename;
            useElevationData = false;
            useFlatTris = false;
            frameQuadkeys = false;
            mapProv = MapProvider.BingSatelliteLabels;
            eleProv = ElevProvider.BingElev;
            LatExtentKm = latkm;
            LngExtentKm = lngkm;
            LatOffsetKm = latoffkm;
            LngOffsetKm = lngoffkm;
            mapExtent = MapExtentTypeE.AsSpecified;
            llbox = new LatLngBox(ll, latkm, lngkm, lod: lod);
            maprot = Vector3.zero;
            maptrans = Vector3.zero;
            mapscale = Vector3.one;
            this.nodesPerQuadKey = nodesPerQuadKey;
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
        public bool useFlatTrisStart = false;
        public bool frameQuadkeysStart = false;
        public SceneScripter sceneScripter = null;

        public BespokeSpec bespoke;

        public QmapMesh qmm = null;
        public LatLngBox llbox = null;

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
            //SetMode(qmapMode); probably don't need to do this?
        }
        public void ClearMesh()
        {
            var qkgonull = qkgo == null;
            var llgonull = llgo == null;
            //Debug.Log($"ClearMesh qkgonull:{qkgonull}  llgonull:{llgonull}");
            if (qkgo != null)
            {
                Destroy(qkgo);
                qkgo = null;
            }
            if (llgo != null)
            {
                Destroy(llgo);
                llgo = null;
            }
        }

        public void ConfigureSystemEnvironment()
        {
            string hostName = System.Net.Dns.GetHostName().ToLower();
            if (hostName == "absol")
            {
                Debug.Log($"hostname :{hostName} - setting tracknames");
                trackFilePath = "d:/transfer/tracks/";
                gdalFilePath = "d:/transfer/gdal/";
            }
        }

        public async Task<(QmapMesh, int, int)> MakeMesh(string scenename, int lod, LatLng ll1, LatLng ll2, string mapcoordname = "", int tpqk = 4, float hmult = 1, MapProvider mapprov = MapProvider.BingSatelliteLabels, ElevProvider elevprov = ElevProvider.BingElev)
        {
            llbox = new LatLngBox(ll1, ll2, scenename, lod: lod);
            return await MakeMeshFromLlbox(scenename, llbox, mapcoordname: mapcoordname, tpqk: tpqk, hmult: hmult, mapprov: mapprov, elevprov: elevprov);
        }
        static int mmcnt = 0;
        static int mmreentrycnt = 0;
        public async Task<(QmapMesh qmm, int nbmloaded, int nelloaded)> MakeMeshFromLlbox(string scenename, LatLngBox llbox, int tpqk = 4, float hmult = 1, string mapcoordname = "", MapExtentTypeE mapextent = MapExtentTypeE.SnapToTiles, MapProvider mapprov = MapProvider.BingSatelliteLabels, ElevProvider elevprov = ElevProvider.BingElev, bool execute = true, bool forceload = false,
                                                               bool limitQuadkeys = true, QmapMesh.sythTexMethod synthTex = QmapMesh.sythTexMethod.Quadkeys,
                                                               HeightSource heitSource = HeightSource.Fetched, HeightAdjust heitAdjust = HeightAdjust.Zeroed
                                                               ) //, HeightTypeE heitType= HeightTypeE.FetchedAndZeroed)
        {

            var wpstays = false;
            //Debug.Log($"QmapMan.MakeMeshFromLlbox mmcnt:{mmcnt} scenename:{scenename} wpstays:{wpstays} position:{this.transform.position}");
            if (mmreentrycnt > 0)
            {
                Debug.LogWarning($"MakeMesh reentry count greater zero:{mmreentrycnt} - total callss:{mmcnt} exiting early");
                return (null, 0, 0);
            }
            mmcnt++;
            mmreentrycnt++;
            this.llbox = llbox;
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
            //qkgo.transform.position = Vector3.zero;
            //Debug.Log("Adding qmmcomp");
            var qmmcomp = qkgo.AddComponent<QmapMesh>();
            qmmcomp.descriptor = $"{scenename} {llbox.lod} {mapprov} {mapextent}";
            qmmcomp.addViewer = true;
            qmmcomp.InitializeGrid(scenename, llbox, mapprov: mapprov, elevprov: elevprov, mapcoordname: mapcoordname);
            //Debug.Log("back from qmmcomp.InitializeGrid");
            qmmcomp.secsPerQkTile = tpqk;
            qmmcomp.useElevationData = useElevationDataStart;
            qmmcomp.flatTriangles = useFlatTrisStart;
            qmmcomp.mapExtent = mapextent;
            qmmcomp.hmult = hmult;
            qmmcomp.synthTex = synthTex;
            qmmcomp.limitQuadkeys = limitQuadkeys;
            //qmmcomp.heightType = heitType;
            qmmcomp.heightSource = heitSource;
            qmmcomp.heightAdjust = heitAdjust;
            //Debug.Log("Calling qmmcomp.GenerateGrid");

            (var nbm, var nel) = await qmmcomp.GenerateGrid(execute, forceload, limitQuadkeys: limitQuadkeys);
            mmreentrycnt--;
            //Debug.Log($"QmapMan.MakeMeshFromLlbox setting frameQuadkeysStart:{frameQuadkeysStart}");
            return (qmmcomp, nbm, nel);
        }
        public void SetFrameQuadKey(bool onoff)
        {
            //Debug.Log($"QmapMan.SetFrameQuadKey:{onoff}");
            if (qmm == null)
            {
                Debug.LogError($"QmapMan.SetFrameQuadKey  - qmm is null");
            }
            var decocomp = qmm.GetComponent<FrameQuadkeysDeco>();
            if (decocomp != null)
            {
                decocomp.showDeco = onoff;
            }
            else
            {
                Debug.LogError($"QmapMan.SetFrameQuadKey  - decocomp is null");
            }
        }

        public void SetTrilines(bool onoff)
        {
            //Debug.Log($"QmapMan.SetTrilines:{onoff}");
            if (qmm==null)
            {
                Debug.LogError($"QmapMan.SetTrilines  - qmm is null");
            }
            var decocomp = qmm.GetComponent<TrilinesDeco>();
            if (decocomp != null)
            {
                decocomp.showDeco = onoff;
            }
            else
            {
                Debug.LogError($"QmapMan.SetTrilines  - decocomp is null");
            }
        }


        public void SetTriPoints(bool onoff)
        {
            //Debug.Log($"QmapMan.SetTriPoints:{onoff}");
            if (qmm == null)
            {
                Debug.LogError($"QmapMan.SetTriPoints  - qmm is null");
            }
            var decocomp = qmm.GetComponent<TriPointDeco>();
            if (decocomp != null)
            {
                decocomp.showDeco = onoff;
            }
            else
            {
                Debug.LogError($"QmapMan.SetTriPoints  - decocomp is null");
            }
        }

        public void SetMeshPoints(bool onoff)
        {
            //Debug.Log($"QmapMan.MeshPoints:{onoff}");
            if (qmm == null)
            {
                Debug.LogError($"QmapMan.SetMeshPoints  - qmm is null");
            }
            var decocomp = qmm.GetComponent<MeshNodesDeco>();
            if (decocomp != null)
            {
                decocomp.showDeco = onoff;
            }
            else
            {
                Debug.LogError($"QmapMan.MeshPoints  - decocomp is null");
            }
        }

        public void SetCoordPoints(bool onoff)
        {
            //Debug.Log($"QmapMan.CoordPoints:{onoff}");
            if (qmm == null)
            {
                Debug.LogError($"QmapMan.SetCoordPoints  - qmm is null");
            }
            var decocomp = this.qmm.GetComponent<CoordDefiningNodesDeco>();
            if (decocomp != null)
            {
                decocomp.showDeco = onoff;
            }
            else
            {
                Debug.LogError($"QmapMan.CoordPoints  - decocomp is null");
            }
        }

        public void SetExtentPoints(bool onoff)
        {
            //Debug.Log($"QmapMan.CoordPoints:{onoff}");
            if (qmm == null)
            {
                Debug.LogError($"QmapMan.SetExtentPoints  - qmm is null");
            }
            var decocomp = this.qmm.GetComponent<ExtendDefiningNodesDeco>();
            if (decocomp != null)
            {
                decocomp.showDeco = onoff;
            }
            else
            {
                Debug.LogError($"QmapMan.ExtentPoints  - decocomp is null");
            }
        }
        public void DeleteQmm()
        {
            ClearMesh();
            if (qmm != null)
            {
                qmm.DisposeOfThings();
                qmm.InitGomflst();
                Destroy(qmm);
                qmm = null;
            }
        }
        string gdalFilePath = "c:/transfer/gdal/";
        string trackFilePath = "c:/transfer/tracks/";
        public async Task<(int nbmloaded,int nelloaded)> SetModeAndMakeMesh(QmapModeE newmode,bool forceload=false)
        {
            Debug.LogWarning("SetMode:" + newmode);
            var nbm = 0;
            var nel = 0;
            useElevationDataStart = true;
            useFlatTrisStart = false;
            DeleteQmm();
            var zvek = Vector3.zero;
            var rrot = new Vector3(0, 90, 0);
            ViewerState dfv = new ViewerState();

            switch (newmode)
            {
                case QmapModeE.Bespoke:
                    {
                        Debug.Log($"Setting QmapModeE.bespoke for {bespoke.sceneName}");
                        useElevationDataStart = bespoke.useElevationData;
                        frameQuadkeysStart = bespoke.frameQuadkeys;
                        useFlatTrisStart = bespoke.useFlatTris;
                        var tpqk = bespoke.nodesPerQuadKey;
                        (qmm, nbm, nel) = await MakeMeshFromLlbox(bespoke.sceneName, bespoke.llbox, tpqk: tpqk, mapprov: bespoke.mapProv, mapextent: bespoke.mapExtent, limitQuadkeys: false, hmult:bespoke.hmult,forceload:forceload  );
                        //Debug.Log($"Back from makemeshfromLlbox ptcnt:{bespoke.mappoints.Count}");
                        if (bespoke.mappoints.Count > 0)
                        {
                            foreach (var pt in bespoke.mappoints)
                            {
                                //Debug.Log($"   qmm.AddUserPoint " + pt.Fmt());
                                qmm.AddUserMapPoint(pt.lat, pt.lng, pt.userwc_x, pt.userwc_z);
                            }
                            qmm.FinishMapPoints();
                        }
                        transform.localScale = bespoke.mapscale;
                        transform.localRotation = Quaternion.identity;
                        var rotv = bespoke.maprot;
                        transform.Rotate(rotv.x, rotv.y, rotv.z);
                        transform.position = bespoke.maptrans;
                        qmm.nodefak = 1f;
                        qmm.addViewer = bespoke.useViewer;
                        qmm.viewHome = bespoke.viewHome;
                        SetFrameQuadKey(bespoke.frameQuadkeys);
                        SetTrilines(bespoke.triLines);
                        SetTriPoints(bespoke.triPoints);
                        SetMeshPoints(bespoke.meshPoints);
                        SetCoordPoints(bespoke.coordPoints);
                        SetExtentPoints(bespoke.extentPoints);
                        qmm.CalcYaLLmap();
                        qmm.RegenerateViewer();
                        if (qmm.addViewer || true)
                        {
                            var viewer = GameObject.FindObjectOfType<Viewer>();
                            if (viewer == null)
                            {
                                Debug.LogError("Cound not find viewer for initial position adjustment");
                            }
                            else
                            {
                                viewer.ReAdjustViewerInitialPosition();
                            }
                        }
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
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;
                        break;
                    }
                case QmapModeE.MsftCampusMapped:
                    {
                        var ll1 = new LatLng(47.646622, -122.139957, "MsftCampus ll1"); // msft campus
                        var ll2 = new LatLng(47.631792, -122.128826, "MsftCampus ll2");
                        (qmm, _, _) = await MakeMesh("msftcampus", 15, ll1, ll2, mapcoordname: "MsftCoreCampus", mapprov: mapprov);
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;
                        break;
                    }
                case QmapModeE.MsftCampusMappedHigh:
                    {
                        var ll1 = new LatLng(47.646622, -122.139957, "MsftCampus ll1"); // msft campus
                        var ll2 = new LatLng(47.631792, -122.128826, "MsftCampus ll2");
                        (qmm, _, _) = await MakeMesh("msftcampus", 18, ll1, ll2, mapcoordname: "MsftCoreCampus", tpqk: 4, mapprov: mapprov);
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;
                        break;
                    }
                case QmapModeE.MsftCampusMappedHigh19:
                    {
                        var ll1 = new LatLng(47.646622, -122.139957, "MsftCampus ll1"); // msft campus
                        var ll2 = new LatLng(47.631792, -122.128826, "MsftCampus ll2");
                        (qmm, _, _) = await MakeMesh("msftcampus", 19, ll1, ll2, mapcoordname: "MsftCoreCampus", tpqk: 2, mapprov: mapprov);
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;
                        break;
                    }
                case QmapModeE.Cyclades:
                    {
                        //var llmid = new LatLng(36.674545, 25.271239, "Cyclades mid");
                        var llmid = new LatLng(36.801411, 25.271239, "Cyclades mid");
                        var llbox = new LatLngBox(llmid, 110, 170, lod: 12);
                        useElevationDataStart = true;
                        useFlatTrisStart = false;
                        dfv = new ViewerState(zvek, rrot, ViewerAvatar.QuadCopter,ViewerCamConfig.FloatBehind);

                        (qmm, _, _) = await MakeMeshFromLlbox("cyclades", llbox, tpqk: 16, hmult: 3, mapprov: mapprov, limitQuadkeys: false);
                        var vtm = gameObject.AddComponent<VehicleTrackMan>();
                        vtm.Init(qmm, trackFilePath, VehicleTrackMan.TrackScenario.CycladesTrip);
                        sceneScripter = gameObject.AddComponent<SceneScripter>();
                        sceneScripter.Init(SceneScenario.Cyclades, vtm);
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;
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
                        useFlatTrisStart = false;


                        dfv = new ViewerState(zvek, rrot, ViewerAvatar.Rover, ViewerCamConfig.FloatBehind);



                        //(qmm,_,_) = await MakeMeshBox("seattle", llbox,tpqk:16,hmult:10, mapprov: mapprov);
                        (qmm, _, _) = await MakeMeshFromLlbox("seattle", llbox, tpqk: 16, hmult: 10, mapprov: mapprov, synthTex: QmapMesh.sythTexMethod.Quadkeys);
                        var tpcomp = qmm.gameObject.GetComponent<TrilinesDeco>();
                        if (tpcomp != null)
                        {
                            tpcomp.showDeco = false;
                        }
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;

                        break;
                    }
                case QmapModeE.Seattle10:
                    {
                        var llmid = new LatLng(47.619992, -122.3373495, "Seattle mid");
                        var llbox = new LatLngBox(llmid, 10, 10, lod: 13);
                        (qmm, _, _) = await MakeMeshFromLlbox("seattle", llbox, tpqk: 16, hmult: 10, mapprov: mapprov);
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;
                        break;
                    }
                case QmapModeE.Seattle3:
                    {

                        dfv = new ViewerState(zvek, rrot, ViewerAvatar.QuadCopter, ViewerCamConfig.FloatBehind);

                        var llmid = new LatLng(47.619992, -122.3373495, "Seattle mid");
                        var llbox = new LatLngBox(llmid, 3, 3, lod: 18);
                        //(qmm,_,_) = await MakeMeshFromLlbox("seattle", llbox, tpqk: 16, hmult: 2, mapprov: mapprov, heitType: HeightTypeE.FetchedAndOriginZeroed, heitSource:HeightSource.Fetched, heitAdjust: HeightAdjust.OriginZeroed, limitQuadkeys: false);
                        (qmm, _, _) = await MakeMeshFromLlbox("seattle", llbox, tpqk: 16, hmult: 2, mapprov: mapprov, heitSource: HeightSource.Fetched, heitAdjust: HeightAdjust.OriginZeroed, limitQuadkeys: false);
                        qmm.addMeshColliders = true;
                        qmm.AddMeshColliders();
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;

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


                        dfv = new ViewerState(zvek, rrot, ViewerAvatar.QuadCopter, ViewerCamConfig.FloatBehind);


                        //(qmm,_,_) = await MakeMeshFromLlbox("dozers", llbox, tpqk: 16, hmult: 5, mapprov: mapprov, heitType: HeightTypeE.FetchedAndOriginZeroed, heitSource: HeightSource.Fetched, heitAdjust: HeightAdjust.OriginZeroed);
                        (qmm, _, _) = await MakeMeshFromLlbox("dozers", llbox, tpqk: 16, hmult: 3, mapprov: mapprov, heitSource: HeightSource.FetchedPlusLidar, heitAdjust: HeightAdjust.NoAdjust);
                        var geoman = gameObject.AddComponent<GeotiffMan>();
                        qmm.nodefak = 0.2f;
                        geoman.Init(qmm, gdalFilePath);
                        geoman.showMediumGeosTiffs12 = true;
                        var trkman = gameObject.AddComponent<VehicleTrackMan>();
                        trkman.Init(qmm, trackFilePath, VehicleTrackMan.TrackScenario.SuncorMine);
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;

                        break;
                    }
                case QmapModeE.DozersMediumSim:
                case QmapModeE.DozersMedium:
                    {
                        var llmid = new LatLng(57.0056037, -111.3581390, "Dozers Medium llmid");
                        var llbox = new LatLngBox(llmid, 1.0, 1.0, "dozermediumbox", lod: 19);
                        //Debug.Log("dozers-med-llbox llmid:" + llbox.midll.ToString());


                        dfv = new ViewerState(zvek, rrot, ViewerAvatar.QuadCopter, ViewerCamConfig.FloatBehind);


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
                        qmm.viewHome = dfv;

                        break;
                    }
                case QmapModeE.DozerSmall:
                    {
                        var llmid = new LatLng(57.0056037, -111.3581390, "Dozers  Smallllmid");
                        var llbox = new LatLngBox(llmid, 0.5, 0.5, "dozersmallbox", lod: 19);
                        Debug.Log("dozers-small-llbox llmid:" + llbox.midll.ToString());

                        dfv = new ViewerState(zvek, rrot, ViewerAvatar.QuadCopter, ViewerCamConfig.FloatBehind);

                        var geoman = gameObject.AddComponent<GeotiffMan>();
                        var trkman = gameObject.AddComponent<VehicleTrackMan>();
                        (qmm, _, _) = await MakeMeshFromLlbox("dozerssmall", llbox, tpqk: 10, hmult: 5, mapprov: mapprov);
                        qmm.nodefak = 1f;
                        geoman.Init(qmm, gdalFilePath, 4, 4);
                        geoman.showMediumGeosTiffs2 = true;
                        trkman.Init(qmm, trackFilePath, VehicleTrackMan.TrackScenario.SuncorMine);
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;

                        break;
                    }
                case QmapModeE.Horizon4:
                    {
                        var llmid = new LatLng(57.338920, -111.750198, "CNRL Horizon llmid");
                        var llbox = new LatLngBox(llmid, 4.0, 4.0, "horizonbox", lod: 17);
                        Debug.Log("Horizon-llbox llmid:" + llbox.midll.ToString());

                        dfv = new ViewerState(zvek, rrot, ViewerAvatar.QuadCopter, ViewerCamConfig.FloatBehind);


                        (qmm, _, _) = await MakeMeshFromLlbox("horizon", llbox, tpqk: 16, hmult: 1, mapprov: mapprov, limitQuadkeys: false);
                        qmm.nodefak = 1f;
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;

                        break;
                    }
                case QmapModeE.Horizon16:
                    {
                        var llmid = new LatLng(57.338920, -111.750198, "CNRL Horizon llmid");
                        var llbox = new LatLngBox(llmid, 16.0, 16.0, "horizonbox", lod: 15);
                        Debug.Log("Horizon-llbox llmid:" + llbox.midll.ToString());

                        var pos = new Vector3(155.30f, 64.06f, -9.77f); ;
                        dfv = new ViewerState(pos, rrot, ViewerAvatar.Minehaul1, ViewerCamConfig.FloatBehind, ViewerControl.Velocity);



                        (qmm, _, _) = await MakeMeshFromLlbox("horizon", llbox, tpqk: 16, hmult: 1, mapprov: mapprov, limitQuadkeys: false);
                        qmm.nodefak = 1f;
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;

                        break;
                    }
                case QmapModeE.MtStHelens16:
                    {
                        var llmid = new LatLng(46.198428, -122.188841, "MtStHellens16llmid");
                        var llbox = new LatLngBox(llmid, 16.0, 16.0, "MtStHellens16 box", lod: 15);
                        Debug.Log("MtStHellens16-llbox llmid:" + llbox.midll.ToString());


                        dfv = new ViewerState(zvek, rrot, ViewerAvatar.Rover, ViewerCamConfig.FloatBehind, ViewerControl.Velocity);


                        (qmm, _, _) = await MakeMeshFromLlbox("mtsthelens", llbox, tpqk: 16, hmult: 1, mapextent: MapExtentTypeE.AsSpecified, mapprov: mapprov, limitQuadkeys: false);
                        qmm.nodefak = 1f;
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;
                        break;
                    }
                case QmapModeE.MtStHelens12:
                    {
                        var llmid = new LatLng(46.198428, -122.188841, "MtStHellensllmid");
                        var llbox = new LatLngBox(llmid, 12.0, 12.0, "MtStHellens box", lod: 16);
                        Debug.Log("MtStHellens-llbox llmid:" + llbox.midll.ToString());

                        dfv = new ViewerState(zvek, rrot, ViewerAvatar.Rover, ViewerCamConfig.FloatBehind, ViewerControl.Velocity);


                        (qmm, _, _) = await MakeMeshFromLlbox("mtsthelens", llbox, tpqk: 16, hmult: 1, mapextent: MapExtentTypeE.AsSpecified, mapprov: mapprov, limitQuadkeys: false);
                        qmm.nodefak = 0.2f;
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;
                        break;
                    }
                case QmapModeE.MtStHelens3:
                    {
                        var llmid = new LatLng(46.198428, -122.188841, "MtStHellens3llmid");
                        var llbox = new LatLngBox(llmid, 3.0, 3.0, "MtStHellens3 box", lod: 17);
                        Debug.Log("MtStHellens3-llbox llmid:" + llbox.midll.ToString());

                        dfv = new ViewerState(zvek, rrot, ViewerAvatar.Rover, ViewerCamConfig.FloatBehind, ViewerControl.Velocity);

                        (qmm, _, _) = await MakeMeshFromLlbox("mtsthelens", llbox, tpqk: 16, hmult: 1, mapextent: MapExtentTypeE.AsSpecified, mapprov: mapprov, limitQuadkeys: false);
                        qmm.nodefak = 0.2f;
                        var tpcomp = qmm.gameObject.GetComponent<TriPointDeco>();
                        if (tpcomp != null)
                        {
                            tpcomp.showDeco = false;
                        }
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;
                        break;
                    }
                case QmapModeE.MtStHelens2:
                    {
                        var llmid = new LatLng(46.198428, -122.188841, "MtStHellens3llmid");
                        var llbox = new LatLngBox(llmid, 3.0, 3.0, "MtStHellens3 box", lod: 19);
                        Debug.Log("MtStHellens3-llbox llmid:" + llbox.midll.ToString());

                        dfv = new ViewerState(zvek, rrot, ViewerAvatar.Rover, ViewerCamConfig.FloatBehind, ViewerControl.Velocity);


                        (qmm, _, _) = await MakeMeshFromLlbox("mtsthelens", llbox, tpqk: 16, hmult: 1, mapextent: MapExtentTypeE.AsSpecified, mapprov: mapprov, limitQuadkeys: false);
                        qmm.nodefak = 0.2f;
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;
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
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;
                        break;
                    }
                case QmapModeE.Eb12:
                    {
                        var ll1 = new LatLng(49.996606, 8.674300, "Eb12 ll1"); // EB12 in Germany
                        var ll2 = new LatLng(49.987100, 8.687557, "Eb12 ll2");
                        (qmm, _, _) = await MakeMesh("eb12", 16, ll1, ll2, tpqk: 2, hmult: 10, mapprov: mapprov);
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;
                        break;
                    }
                case QmapModeE.Eb12Mapped:
                    {
                        var ll1 = new LatLng(49.996606, 8.674300, "Eb12 ll1"); // EB12 in Germany
                        var ll2 = new LatLng(49.987100, 8.687557, "Eb12 ll2");
                        (qmm, _, _) = await MakeMesh("eb12", 16, ll1, ll2, mapcoordname: "Eb12", mapprov: mapprov);
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;
                        break;
                    }
                case QmapModeE.Tukwilla:
                    {
                        var ll1 = new LatLng(47.461414, -122.262566, "Tukwila ll1"); // Tukwila
                        var ll2 = new LatLng(47.453419, -122.253639, "Tukwila ll2");
                        (qmm, _, _) = await MakeMesh("tukwila", 16, ll1, ll2, mapprov: mapprov);
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;
                        break;
                    }
                case QmapModeE.MtFuji:
                    {
                        var ll1 = new LatLng(35.450153, 138.603933, "MtFuji ll1"); // MtFuji
                        var ll2 = new LatLng(35.296752, 138.874443, "MtFuji ll2");
                        (qmm, _, _) = await MakeMesh("mtfuji", 14, ll1, ll2, tpqk: 8, mapprov: mapprov);
                        qmm.nodefak = 0.5f;
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;
                        break;
                    }
                case QmapModeE.Whistler:
                    {
                        var ll1 = new LatLng(50.229914, -122.859530, "Whistler ll1"); // Whistler
                        var ll2 = new LatLng(50.029914, -123.2595303, "Whistler ll2");
                        (qmm, _, _) = await MakeMesh("whistler", 14, ll1, ll2, tpqk: 4, mapprov: mapprov);
                        qmm.nodefak = 0.5f;
                        qmm.addViewer = true;
                        qmm.viewHome = dfv;
                        break;
                    }
                    // 49.996606, 8.674300
            }
            lastQmapMode = qmapMode;
            return (nbm, nel);
        }
        //public void InitMeshW3w(string w3w,string name,LatLng ll,float latkm,float lngkm,int lod)
        //{
        //    var llbox = new LatLngBox(ll, latkm, lngkm, name, lod:lod);
        //    (qmm,_,_) = MakeMeshFromLlbox(name,llbox, 16, 10, mapprov: mapprov);
        //}

        bool enableInspectorManimpulation = false;
        QmapModeE lastQmapMode = QmapModeE.None;
        // Update is called once per frame
        void Update()
        {
            if (enableInspectorManimpulation)
            {
                if (lastQmapMode != qmapMode)
                {
                    SetModeAndMakeMesh(qmapMode);
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
}