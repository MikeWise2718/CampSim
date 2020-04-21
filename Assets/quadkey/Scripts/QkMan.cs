using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using Microsoft.MapPoint;
using System.Linq;

namespace Aiskwk.Map
{
    public enum ElevProvider { Bing }
    public enum MapProvider { AzureMaps, AzureSatelliteOnly, AzureSatelliteRoads, BingMaps, BingSatelliteOnly, BingSatelliteRoads, Altx , OpenStreetMaps}
    //public enum HeightTypeE { Constant, Random, SineWave, Fetched,FetchedAndZeroed,FetchedAndOriginZeroed }
    public enum HeightSource { Constant, Random, SineWave, Fetched, FetchedPlusLidar }
    public enum HeightAdjust { NoAdjust, Zeroed, OriginZeroed }
    public enum MapExtentTypeE { SnapToTiles, AsSpecified }
    public enum MeshSizeMethodE { NumTiles, TilesPerQk }
    public enum NormalAvgMethod { DoNothing, Avg, Norm1, Norm2, AlwaysUp, AlwaysUpLeft, Zero }

    [System.Serializable]
    public class QkMan
    {
        public LatLng ll1;
        public LatLng ll2;
        public LatLngBox llbox;
        public LatLngBox qllbox;

        public int levelOfDetail;
        public List<QkTile> qktiles = null;
        public Vector2Int nqk;
        public Vector2Int expectedTexSize;
        public Vector2Int expectedCroppedTexSize;
        public QmapMesh qmm;
        public string datamapname;
        public int pixelspertile;
        public MapProvider mapprov;


        public QkMan(QmapMesh qmm, string datamapname, MapProvider mapprov, LatLng ll1, LatLng ll2, int levelOfDetail, int pixelspertile = 256)
        {
            this.datamapname = datamapname;
            this.qmm = qmm;
            this.pixelspertile = pixelspertile;
            this.ll1 = ll1;
            this.ll2 = ll2;
            this.levelOfDetail = levelOfDetail;
            this.llbox = new LatLngBox(ll1, ll2, "llbox", levelOfDetail);
        }
        public QkMan(QmapMesh qmm, string datamapname, MapProvider mapprov, LatLngBox llbox, int pixelspertile = 256)
        {
            this.datamapname = datamapname;
            this.qmm = qmm;
            this.pixelspertile = pixelspertile;
            this.levelOfDetail = llbox.lod;
            this.llbox = llbox;
            this.ll1 = llbox.GetUpperLeft();
            this.ll2 = llbox.GetBottomRight();
        }

        public static string GetMapProvSubdirName(MapProvider maprov)
        {
            var rv = "";
            switch (maprov)
            {
                case MapProvider.AzureMaps:
                    {
                        rv = "azure/map";
                        break;
                    }
                case MapProvider.AzureSatelliteOnly:
                    {
                        rv = "azure/sat";
                        break;
                    }
                case MapProvider.AzureSatelliteRoads:
                    {
                        rv = "azure/satroads";
                        break;
                    }
                case MapProvider.OpenStreetMaps:
                    {
                        rv = "osm";
                        break;
                    }
                case MapProvider.Altx:
                    {
                        rv = "altx";
                        break;
                    }
                default:
                case MapProvider.BingMaps:
                    {
                        rv = "bing/map";
                        break;
                    }
                case MapProvider.BingSatelliteOnly:
                    {
                        rv = "bing/sat";
                        break;
                    }
                case MapProvider.BingSatelliteRoads:
                    {
                        rv = "bing/satroads";
                        break;
                    }
            }
            return rv;
        }

        string key = "IdbTbLfVZWE6B5pnqB-ybmzk5KbM_lyQeLtt_YusYNc";
        string msft = "microsoft.com";
        string bing = "ssl.ak.dynamic.tiles.virtualearth.net";
        string osm = "a.tile.openstreetmap.org";
        string altx = "gleapis.com";
        public string GetUri(string qkname)
        {
            var uri = "";
            switch (mapprov)
            {
                case MapProvider.AzureMaps:
                    {
                        TileSystem.QuadKeyToTileXY(qkname, out var tX, out var tY, out var lod);
                        uri = $"https://atlas.{msft}/map/tile/png?subscription-key={key}&api-version=1.0&layer=basic&style=main&zoom={lod}&x={tX}&y={tY}";
                        break;
                    }
                case MapProvider.AzureSatelliteOnly:
                    {
                        TileSystem.QuadKeyToTileXY(qkname, out var tX, out var tY, out var lod);
                        // Get map Imagery Tile - https://docs.microsoft.com/en-us/rest/api/maps/render/getmapimagerytile#mapimagerystyle
                        uri = $"https://atlas.{msft}/map/imagery/png?subscription-key={key}&api-version=1.0&style=satellite&zoom={lod}&x={tX}&y={tY}";
                        break;
                    }
                case MapProvider.AzureSatelliteRoads:
                    {
                        TileSystem.QuadKeyToTileXY(qkname, out var tX, out var tY, out var lod);
                        //uri = $"https://atlas.{msft}/map/imagery/png?subscription-key={key}&api-version=1.0&height=256&width=256&style=satellite_road_labels&zoom={lod}&x={tX}&y={tY}";
                        // https://docs.microsoft.com/en-us/rest/api/maps/render/getmapimage#staticmaplayer 
                        // https://docs.microsoft.com/bs-cyrl-ba/azure/azure-maps/supported-map-styles?view=azurermps-2.2.0 
                        uri = $"https://atlas.{msft}/map/static/png?subscription-key={key}&api-version=1.0&style=hybrid&zoom={lod}&x={tX}&y={tY}";
                        var layer = "layer";
                        var style = "hybrid";
                        var language = "en";
                        // can't seem to get this one working, so subsituting naked satellite pictures for now - seems tile rendering (using the "imagery" directory) doesn't support roads and labels, which is odd
                        //uri = $"https://atlas.{msft}/map/static/png?subscription-key={key}&api-version=1.0&layer={layer}&style={style}&zoom={lod}&center={center}&bbox={bbox}&height={height}&width={width}&language={language}&view={view}&pins={pins}&path={path}";
                        uri = $"https://atlas.{msft}/map/static/png?subscription-key={key}&api-version=1.0&layer={layer}&style={style}&zoom={lod}&language={language}";
                        uri = $"https://atlas.{msft}/map/imagery/png?subscription-key={key}&api-version=1.0&style=satellite&zoom={lod}&x={tX}&y={tY}";
                        break;
                    }
                case MapProvider.OpenStreetMaps:
                    {
                        TileSystem.QuadKeyToTileXY(qkname, out var tX, out var tY, out var lod);
                        uri = $"https://{osm}/{lod}/{tX}/{tY}.png";
                        break;
                    }
                case MapProvider.Altx:
                    {
                        TileSystem.QuadKeyToTileXY(qkname, out var tX, out var tY, out var lod);
                        var irnd = qut.GetRanInt(0, 3, "www");
                        uri = $"https://mt{irnd}.goo{altx}/vt/lyrs=y&hl=en&x={tX}&y={tY}&z={lod}";
                        break;
                    }
                case MapProvider.BingSatelliteRoads:
                    {
                        var irnd = qut.GetRanInt(0, 3, "www");
                        var vopts = "A,L,LA";
                        uri = $"https://t{irnd}.{bing}/comp/ch/{qkname}?mkt=en&it={vopts}&og=30&n=z";
                        break;
                    }
                case MapProvider.BingSatelliteOnly:
                    {
                        var irnd = qut.GetRanInt(0, 3, "www");
                        var vopts = "A";
                        uri = $"https://t{irnd}.{bing}/comp/ch/{qkname}?mkt=en&it={vopts}&og=30&n=z";
                        break;
                    }
                case MapProvider.BingMaps:
                    {
                        var irnd = qut.GetRanInt(0, 3, "www");
                        var vopts = "G,L,LA";
                        uri = $"https://t{irnd}.{bing}/comp/ch/{qkname}?mkt=en&it={vopts}&og=30&n=z";
                        break;
                    }

            }
            return uri;
        }


        async Task<bool> GetQuadkeyAsy(string qkname, string ppath, string scenename)
        {
            try
            {
                Debug.Log("GetQuadKeyAsy" + scenename + " lod:" + levelOfDetail + " qk:" + qkname);
                // https://t1.ssl.ak.dynamic.tiles.virtualearth.net/comp/ch/021230030212230?mkt=en&it=A,G,L,LA&og=30&n=z
                //
                //var uri = "https://t3.ssl.ak.dynamic.tiles.virtualearth.net/comp/ch/" + qkname + "?mkt=en&it=A,G,L,LA&og=30&n=z";
                var uri = GetUri(qkname);
                Debug.Log($"{uri}");
                using (var webRequest = UnityWebRequest.Get(uri))
                {
                    // Request and wait for the desired page.
                    webRequest.SendWebRequest();
                    while (!webRequest.isDone)
                    {
                        //yield return new WaitForSeconds(1000);
                        await Task.Delay(TimeSpan.FromSeconds(0.05f));
                        Debug.Log("   back from Task.Delay");
                    }

                    string[] pages = uri.Split('/');
                    int lastpage = pages.Length - 1;

                    if (webRequest.isNetworkError)
                    {
                        Debug.Log(pages[lastpage] + " - Error: " + webRequest.error);
                        return false;
                    }
                    else
                    {
                        Debug.Log(pages[lastpage] + " - Received  " + webRequest.downloadHandler.data.Length + " bytes");
                        //var dname = GetFullQkSubDir(scenename);
                        var dname = ppath;
                        var bytes = webRequest.downloadHandler.data;
                        var fname = dname + qkname + ".png";
                        QresFinder.EnsureExistenceOfDirectory(fname);
                        File.WriteAllBytes(fname, bytes);
                        Debug.Log("Wrote " + fname + " bytes:" + bytes.Length);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Exception in GetQuadkeyAsy ex:{ex.Message}");
            }
            return false;
        }
        public Texture2D LoadBitmap(string qd, string filePath, string ext)
        {
            filePath = qd + filePath;
            filePath = filePath.ToLower();
            if (!filePath.EndsWith(ext))
            {
                filePath = filePath + ext;
            }
            Texture2D tex = null;
            byte[] fileData;

            if (File.Exists(filePath))
            {
                var fi = new FileInfo(filePath);
                last_loaded_texsize = fi.Length;
                fileData = File.ReadAllBytes(filePath);
                tex = new Texture2D(2, 2);
                tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
            }
            Debug.Log("Loaded file " + filePath + " bytes" + last_loaded_texsize);
            return tex;
        }
        public Texture2D CombineTexHorz(Texture2D t1, Texture2D t2)
        {
            var nh = Mathf.Max(t1.height, t2.height);
            var nw = t1.width + t2.width;
            var t3 = new Texture2D(nw, nh);
            var c1 = t1.GetPixels();
            t3.SetPixels(0, 0, t1.width, t1.height, c1);
            var c2 = t2.GetPixels();
            t3.SetPixels(t1.width, 0, t2.width, t2.height, c2);
            t3.Apply();
            return t3;
        }
        public Texture2D CombineTexVert(Texture2D t1, Texture2D t2)
        {
            // t3 is t2 added below t1
            var nw = Mathf.Max(t1.width, t2.width);
            var nh = t1.height + t2.height;
            var t3 = new Texture2D(nw, nh);
            var c1 = t1.GetPixels();
            t3.SetPixels(0, 0, t1.width, t1.height, c1);
            var c2 = t2.GetPixels();
            t3.SetPixels(0, t1.height, t2.width, t2.height, c2);
            t3.Apply();
            return t3;
        }
        (int, int, int, int) CalcTrimTexBox(LatLngBox border, LatLngBox croparea)
        {
            var lod = levelOfDetail;
            var x = croparea.GetPixelUpperLeft(lod).x - border.GetPixelUpperLeft(lod).x;
            var y = croparea.GetPixelUpperLeft(lod).y - border.GetPixelUpperLeft(lod).y;
            var w = croparea.GetPixelBottomRight(lod).x - croparea.GetPixelUpperLeft(lod).x + 1;
            var h = croparea.GetPixelBottomRight(lod).y - croparea.GetPixelUpperLeft(lod).y + 1;
            return (x, y, w, h);
        }
        Texture2D TrimTexToLlbox(Texture2D t1, LatLngBox border, LatLngBox croparea)
        {
            // t3 is t2 added below t1
            if (!border.IsSubset(croparea))
            {
                Debug.LogError("crop area not subset border:" + border.ToString() + " croparea:" + croparea.ToString());
                return t1;
            }
            //var lod = levelOfDetail;
            //var x = croparea.GetPixelUpperLeft(lod).x - border.GetPixelUpperLeft(lod).x;
            //var y = croparea.GetPixelUpperLeft(lod).y - border.GetPixelUpperLeft(lod).y;
            //var w = croparea.GetPixelBottomRight(lod).x - croparea.GetPixelUpperLeft(lod).x + 1;
            //var h = croparea.GetPixelBottomRight(lod).y - croparea.GetPixelUpperLeft(lod).y + 1;
            var (x, y, w, h) = CalcTrimTexBox(border, croparea);
            var ny = t1.height - y - h;
            //Debug.Log("TrimTexToLlbox - x:"+x+" y:"+y+" w:"+w+" h:"+h+"   ny:"+ny);
            var pixels = t1.GetPixels(x, ny, w, h);// unity bitmap origins are lower left, quadkeys are upper left
            var t2 = new Texture2D(w, h);
            t2.SetPixels(pixels);
            return t2;
        }

        public QkTile tileul, tilebr;
        public Vector2Int numqkpix;
        //public LatLongMap llmap = null;

        public void CalcQuadKeys(bool limitQuadkeys = true)
        {
            bool verbose = false;
            if (verbose)
            {
                Debug.Log("CalcQuadKeys ll1:" + ll1 + " ll2:" + ll2 + "  lod:" + levelOfDetail);
            }

            tileul = QkTile.GetQktileFromLatLng(llbox.GetUpperLeft(), levelOfDetail);
            tilebr = QkTile.GetQktileFromLatLng(llbox.GetBottomRight(), levelOfDetail);
            qllbox = new LatLngBox(tileul.llul, tilebr.llbr, "qllbox", levelOfDetail);
            if (qmm == null)
            {
                Debug.LogError("qmm is null");
                return;
            }
            if (datamapname == "")
            {
                //Debug.Log("Initing llmap from LatLongBox");
                //qmm.llmap.InitMapFromLatLongBox(qllbox, levelOfDetail);
                qmm.llmap.InitMapFromLatLongBox(llbox, levelOfDetail);
            }
            else
            {
                Debug.Log("Initing llmap from datamapname:" + datamapname);
                qmm.llmap.InitMapFromSceneSel(datamapname, 0);
            }

            var nxx = (tilebr.pixbr.x - tileul.pixul.x);
            var nxy = (tilebr.pixbr.y - tileul.pixul.y);
            numqkpix = new Vector2Int(nxx, nxy);

            var nqkx = (numqkpix.x / this.pixelspertile) + 1;
            var nqky = (numqkpix.y / this.pixelspertile) + 1;
            if (limitQuadkeys)
            {
                if (nqkx > 20)
                {
                    Debug.LogWarning("QuadKey nqk.x>20 - clipped from " + nqkx);
                    nqkx = 20;
                }
                if (nqky > 20)
                {
                    Debug.LogWarning("QuadKey nqk.y>20 - clipped from " + nqky);
                    nqky = 20;
                }
            }
            nqk = new Vector2Int(nqkx, nqky);
            expectedTexSize = nqk * 256;
            var (x, y, w, h) = CalcTrimTexBox(qllbox, llbox);
            expectedCroppedTexSize = new Vector2Int(w, h);

            if (verbose)
            {
                Debug.Log("numpix.x:" + numqkpix.x + " y:" + numqkpix.y);
                Debug.Log("nqk.x:" + nqk.x + " y" + nqk.y);
            }

            // get the bitmaps in order from top to bottom, left to right
            qktiles = new List<QkTile>();
            var py = llbox.GetPixelUpperLeft(levelOfDetail).y;
            for (int iy = 0; iy < nqk.y; iy++)
            {
                var px = llbox.GetPixelUpperLeft(levelOfDetail).x;
                for (int ix = 0; ix < nqk.x; ix++)
                {
                    TileSystem.PixelXYToTileXY(px, py, out var tilex, out var tiley);
                    var qkname = TileSystem.TileXYToQuadKey(tilex, tiley, levelOfDetail);
                    if (verbose)
                    {
                        Debug.Log("qk" + qktiles.Count + " " + qkname + " px:" + px + " py:" + py);
                    }
                    var qktile = new QkTile(qkname);
                    qktiles.Add(qktile);
                    px += this.pixelspertile;
                }
                py += this.pixelspertile;
            }
            if (verbose)
            {
                var nqkf = qktiles.Count;
                Debug.Log("nqk:" + nqkf + "  nqk.x:" + nqk.x + "  nqk.y:" + nqk.y);
            }
        }



        string GetTexSubDir(string scenename)
        {
            var dirname = "scenemaps/" + GetMapProvSubdirName(mapprov) + "/" + scenename + "/texmap/" + levelOfDetail + "/";

            return dirname;
        }


        public void DeleteWebData(string scenename, MapProvider mapprov)
        {

            Debug.Log($"DeleteWebData for scenename:{scenename} mapprove:{mapprov.ToString()}");
            if (qrf == null) return;

            //var mprov = GetMapProvSubdirName(mapprov);
            //var ppath = $"{Application.persistentDataPath}/qkmaps/scenemaps/{mapprov}/{scenename}";
            //Directory.Delete(ppath, true);
            var ppath = qrf.PersistentPathName();
            var tpath = qrf.TempPathName();
            qut.CopyTextToClipboard($"persistent:\n{ppath}\ntemp:\n{tpath}");
#if UNITY_EDITOR_WIN
            var msg = $"Delete persistent and temp paths:\n\"{ppath}\"\n\"{tpath}\"\nPaths copied to clipboard";
            var ok1 = UnityEditor.EditorUtility.DisplayDialog("Deleting Persistent Path Data", msg, "Ok to delete", "Cancel");
            if (!ok1) return;
#endif
            if (Directory.Exists(ppath))
            {
                Directory.Delete(ppath, true);
                Debug.LogWarning($"Deleted {scenename} data stored in persistent path {ppath}");
            }
            else
            {
                Debug.LogWarning($"Persistent path {ppath} does not exist");
            }


            if (Directory.Exists(tpath))
            {
                Directory.Delete(tpath, true);
                Debug.LogWarning($"Deleted {scenename} data stored in temp path {tpath}");
            }
            else
            {
                Debug.LogWarning($"Temp path {tpath} does not exist");
            }
        }

        public string GetTexFileName(MapExtentTypeE mapextent)
        {
            var texname = "tex.png";
            if (mapextent == MapExtentTypeE.AsSpecified)
            {
                texname = "croppedtex.png";
            }
            return texname;
        }

        Texture2D vertex = null;
        Texture2D hortex = null;
        async Task<(bool, string, int)> GetWwwQktilesAndMakeTex(string scenename, string tpath, string ppath, bool execute = true)
        {
            Debug.Log($"GetWwwQktilesAndMakeTex scene - {scenename}");
            Debug.Log($"GetWwwQktilesAndMakeTex tpath - {tpath}");
            Debug.Log($"GetWwwQktilesAndMakeTex ppath - {ppath}");
            bool ok = false;
            string errmsg = "";
            var nBmRetrieved = 0;
            //var qkdir = GetFullQkSubDir(scenename);
            // Have to build it from top to bottom, left to right
            int iqk = 0;
            int nqktodo = nqk.x * nqk.y;
            bool getquadkeyok = false;
            bool hortexnull = true;
            vertex = null;
            hortex = null;
            try
            {
                for (int iy = 0; iy < nqk.y; iy++)
                {
                    Debug.Log($"hortex being assigned null iy:{iy}  nqk.y:{nqk.y}");
                    hortex = null;
                    for (int ix = 0; ix < nqk.x; ix++)
                    {
                        var qktile = qktiles[iqk];
                        if (execute)
                        {
                            Debug.Log($"iy:{iy} ix:{ix}  iqkk:{iqk}/{nqktodo}  {qktile}");
                            if (!File.Exists(tpath + qktile.name))
                            {
                                hortexnull = hortex == null && ix > 0;
                                if (hortexnull)
                                {
                                    Debug.LogWarning($"Calling GetQuadkeyAsy hortexnull:{hortexnull}  qktile.name:{qktile.name} ");
                                }
                                getquadkeyok = await GetQuadkeyAsy(qktile.name, tpath, scenename);
                                hortexnull = hortex == null && ix > 0;
                                if (hortexnull)
                                {
                                    Debug.LogWarning($"Back    GetQuadkeyAsy hortexnull:{hortexnull} getquadkeyok:{getquadkeyok}");
                                }
                            }
                            else
                            {
                                Debug.Log($"Found {tpath}{qktile}");
                            }
                            hortexnull = hortex == null && ix > 0;
                            if (hortexnull)
                            {
                                Debug.LogWarning($"Calling LoadBitmap hortexnull:{hortexnull}");
                            }
                            var tix = LoadBitmap(tpath, qktile.name, ".png");
                            hortexnull = hortex == null && ix > 0;
                            if (hortexnull)
                            {
                                Debug.LogWarning($"Back from LoadBitmap hortexnull:{hortexnull}");
                            }
                            if (ix == 0)
                            {
                                hortex = tix;
                            }
                            else
                            {
                                hortexnull = hortex == null && ix > 0;
                                if (hortexnull)
                                {
                                    Debug.LogWarning($"CombineTexHorz iy:{iy} ix:{ix} hortexnull:{hortexnull}  getquadkeyok:{getquadkeyok}");
                                }
                                hortex = CombineTexHorz(hortex, tix);
                                hortexnull = hortex == null && ix > 0;
                                if (hortexnull)
                                {
                                    Debug.LogWarning($"Back   TexHorz iy:{iy} ix:{ix} hortexnull:{hortexnull}");
                                }
                            }
                            iqk++;
                            nBmRetrieved++;
                        }
                    }
                    if (iy == 0)
                    {
                        if (execute)
                        {
                            vertex = hortex;
                        }
                    }
                    else
                    {
                        if (execute)
                        {
                            //Debug.Log($"CombineTexVert iy:{iy}");
                            vertex = CombineTexVert(hortex, vertex);// top to bottom
                                                                    //vertex = CombineTexVert(vertex, hortex);// bottom to top
                        }
                    }

                }
                if (execute)
                {
                    Debug.Log($"Finshed loading quadkeys - writing combined tex pngs");
                    byte[] vbytes = vertex.EncodeToPNG();
                    var fname1 = ppath + "tex.png";
                    QresFinder.EnsureExistenceOfDirectory(fname1);
                    File.WriteAllBytes(fname1, vbytes);

                    var t2 = TrimTexToLlbox(vertex, qllbox, llbox);
                    byte[] cbytes = t2.EncodeToPNG();
                    var fname2 = ppath + "croppedtex.png";
                    QresFinder.EnsureExistenceOfDirectory(fname2);
                    File.WriteAllBytes(fname2, cbytes);

                    ok = true;
                }
            }
            catch (Exception ex)
            {
                ok = false;
                errmsg = ex.Message;              
                Debug.LogError($"Error in GetWwwQktilesAndMakeTex ok:{ok} err:{errmsg}  nBmRetrieved:{nBmRetrieved}");// to insert
            }
            return (ok, errmsg, nBmRetrieved);
        }

        Texture2D sythesizeTex(MapExtentTypeE mapextent, string synthSpec)
        {
            var sw = new StopWatch();
            var sz = this.expectedTexSize;
            if (mapextent == MapExtentTypeE.AsSpecified)
            {
                sz = this.expectedCroppedTexSize;
            }
            var tex = new Texture2D(sz.x, sz.y);
            var cname = "goldenrod";
            if (qut.iscolorname(synthSpec)) cname = synthSpec;
            var npix = sz.x * sz.y;
            var clr = qut.GetColorByName(cname);
            //Debug.Log("clr:" + clr.ToString());
            //var colors = new Color[] { clr };// always gold? And causes an error
            var colors = Enumerable.Repeat<Color>(clr, npix).ToArray<Color>();
            tex.SetPixels(colors);
            tex.Apply();
            sw.Stop();
            Debug.Log($"Creating sythtex {synthSpec} took {sw.ElapSecs()} secs");
            return tex;
        }
        Texture2D CombineTextures(Texture2D t1, float f1, Texture2D t2, float f2)
        {
            var sw = new StopWatch();
            if (t1.width != t2.width || t1.height != t2.height)
            {
                Debug.LogError($"Texture size mismatch in CombineTextures t1:{t1.width},{t1.height}   t2:{t2.width},{t2.height}");
                return t1;
            }
            Debug.Log($"Combining textures t1:{t1.width},{t1.height}   t2:{t2.width},{t2.height}");
            var tex = new Texture2D(t1.width, t2.height);

            for (int y = 0; y < tex.height; y++)
            {
                for (int x = 0; x < tex.width; x++)
                {
                    var p1 = t1.GetPixel(x, y);
                    var p2 = t2.GetPixel(x, y);
                    var p3 = f1 * p1 + f2 * p2;
                    tex.SetPixel(x, y, p3);
                }
            }
            tex.Apply();
            sw.Stop();
            Debug.Log($"Creating CombinedTextures took {sw.ElapSecs()} secs");
            return tex;
        }


        QresFinder qrf = null;

        public long last_loaded_texsize = 0L;
        public async Task<(Texture2D, int)> GetTexAsy(string scenename, MapExtentTypeE mapextent, bool execute, bool forceload, QmapMesh.sythTexMethod synthTex, string synthSpec)
        {
            var nBmRetrieved = 0;
            var tfname = GetTexFileName(mapextent);
            var tfpath = "qkmaps/" + GetTexSubDir(scenename);
            qrf = new QresFinder(tfpath, tfname);
            var exists = qrf.Exists();
            var temppath = qrf.TempPathName();
            var perspath = qrf.PersistentPathName();
            Debug.Log($"GetTexAsy forceload:{forceload} exists:{exists}");
            if (forceload || !exists)
            {
                if (forceload)
                {
                    Debug.LogWarning($"Forceloading of {tfname} requires www bitmap fetching");
                }
                else
                {
                    Debug.LogWarning($"Non-existance of {tfname} determined in {perspath} requires www bitmap fetching");
                }
                var (ok, errmsg, nBm) = await GetWwwQktilesAndMakeTex(scenename, temppath, perspath, execute);
                if (!ok)
                {
                    return (null, nBm);
                }
                nBmRetrieved += nBm;
                qrf.Reload();
            }
            Texture2D tex = null;
            if (execute)
            {
                switch (synthTex)
                {
                    default:
                    case QmapMesh.sythTexMethod.Synth:
                        {
                            tex = sythesizeTex(mapextent, synthSpec);
                            break;
                        }
                    case QmapMesh.sythTexMethod.Hybrid:
                        {
                            var tex1 = sythesizeTex(mapextent, synthSpec);
                            var tex2 = qrf.GetTex();
                            tex = CombineTextures(tex1, 0.5f, tex2, 0.5f);
                            break;
                        }
                    case QmapMesh.sythTexMethod.Quadkeys:
                        {
                            tex = qrf.GetTex();
                            var sz = this.expectedTexSize;
                            if (mapextent == MapExtentTypeE.AsSpecified)
                            {
                                sz = this.expectedCroppedTexSize;
                            }
                            if ((sz.x != tex.width) || (sz.y != tex.height))
                            {
                                Debug.LogWarning($"Mapextent:{mapextent}");
                                Debug.LogWarning($"Expected tex size:{sz.x},{sz.y} but retrieved:{tex.width},{tex.height}");
                            }
                            break;
                        }
                }
            }
            return (tex, nBmRetrieved);
        }
    }
}