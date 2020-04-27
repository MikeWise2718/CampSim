using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System;
using System.IO;
using Aiskwk.Dataframe;

namespace Aiskwk.Map
{
    public class location
    {
        public double latitude;
        public double longitude;
    }
    // https://dev.virtualearth.net/REST/v1/Elevation/Bounds?bounds=47.631619,-122.140502,47.647349,-122.128143&rows=2&cols=2&key=Ap8ePtxraOI9aCkW5J-h2c-QG4JpQozZ8KOK3ayrwc0uvMUt6g0wdz7GIFmLLz8v&
    public enum EarthHightModelE { sealevel, elipsoid };


    public class ElevCsvMaker
    {
        List<string> lines;
        readonly int ncol;
        readonly int decpt;
        public ElevCsvMaker(int ncol, int decpt)
        {
            lines = new List<string>();
            this.ncol = ncol;
            this.decpt = decpt;
        }

        public static (bool, string, List<float>) ParseElevsFromString(string inputstring)
        {
            var elevs = new List<float>();
            string elestring = "\"elevations\":[";
            var errmsg = "no error";
            int idx = inputstring.IndexOf(elestring);
            if (idx >= 0)
            {
                string elevationListStr = inputstring.Substring(idx + elestring.Length);
                idx = elevationListStr.IndexOf(']');

                if (idx > 0)
                {
                    elevationListStr = elevationListStr.Substring(0, idx);

                    //Split the comma delimited list into doubles.
                    char[] parm = { ',' };
                    string[] result = elevationListStr.Split(parm);

                    //Add the strings to the list.
                    foreach (string dbl in result)
                    {
                        elevs.Add(float.Parse(dbl));
                    }
                }
                else
                {
                    errmsg = "Format Error on input string";
                    return (false, errmsg, elevs);
                }
            }
            else
            {
                errmsg = "No elevations found";
                return (false, errmsg, elevs);
            }
            return (true, errmsg, elevs);
        }
        private (bool, string, List<string>) MakeCsvList(int blknum, double latmin, double latmax, List<float> elevs)
        {
            // error checking
            if (ncol <= 0) return (false, "ncol<=0", null);
            var nelevs = elevs.Count;
            if (nelevs <= 0) return (false, "nelevs<=0", null);
            var ismult = ((nelevs % ncol) == 0);
            if (!ismult) return (false, "nelevs not a multiple of ncols", null);
            if (decpt < 0) return (false, "decimal points less than zero", null);

            if (blknum == 0)
            {
                var head = "row,blknum,idx,blklatmin,blklatmax";
                for (int i = 0; i < ncol; i++) head += "," + "V" + i;
                lines.Add(head);
            }
            var nrows = nelevs / ncol;
            var fmt = "F" + decpt;
            var iel = 0;
            var ofs = lines.Count - 1;
            for (int i = 0; i < nrows; i++)
            {
                var currow = ofs + i;
                var l = currow.ToString() + "," + blknum.ToString() + "," + i.ToString() + "," + latmin.ToString("f6") + "," + latmax.ToString("f6");
                for (int j = 0; j < ncol; j++)
                {
                    l += "," + elevs[iel].ToString(fmt);
                    iel++;
                }
                lines.Add(l);
            }
            return (true, "", lines);
        }

        public void AddStr(int blocknum, double latmin, double latmax, string str)
        {
            (var ok1, var errmsg1, var elevlst) = ParseElevsFromString(str);
            if (ok1)
            {
                MakeCsvList(blocknum, latmin, latmax, elevlst);
            }
        }

        public void WriteOut(string fname)
        {
            try
            {
                QresFinder.EnsureExistenceOfDirectory(fname);
                File.WriteAllLines(fname, lines);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.ToString());
            }
        }
    }

    public class QmapElevation : MonoBehaviour
    {
        // Start is called before the first frame update

        // Format the URI from a list of locations.
        // Based on https://www.codeproject.com/Articles/1250521/Getting-Elevation-Data-from-a-Bing-Map

        string scenename;
        ElevProvider elevprov;
        int nrow;
        int ncol;
        int lod;
        LatLngBox llb;
        EarthHightModelE model;
        MapExtentTypeE mapextent;
        MapProvider mapprov;

        public void InitElevs(string scenename, ElevProvider elevprov, MapExtentTypeE mapextent, EarthHightModelE model, int nrow, int ncol, LatLngBox llb)
        {
            //Debug.Log("InitElevs mapextent:" + mapextent+" nrow:"+nrow+" ncol:"+ncol); 
            this.elevprov = elevprov;
            this.scenename = scenename;
            this.mapprov = MapProvider.BingSatelliteRoads;// the only one with elevations
            this.nrow = nrow;
            this.ncol = ncol;
            this.llb = llb;
            this.lod = llb.lod;
            this.model = model;
            this.mapextent = mapextent;
            heights = new List<float>();
        }
        string bingKey = "Ap8ePtxraOI9aCkW5J-h2c-QG4JpQozZ8KOK3ayrwc0uvMUt6g0wdz7GIFmLLz8v";

        string url = "https://dev.virtualearth.net/REST/v1/Elevation/Bounds?bounds={0},{1},{2},{3}&rows={4}&cols={5}&key={6}";
        // docs: https://docs.microsoft.com/en-us/bingmaps/rest-services/elevations/get-elevations



        //string rdirroot = "Assets/Resources/";

        string GetElevReqName(string tpath, int iblk)
        {
            var rfname = tpath + "elevdata_req" + iblk.ToString() + ".txt";
            return rfname;
        }
        string GetEleBlkPathFileName(string tpath, int iblk)
        {
            var rfname = tpath + "elevdata" + iblk + ".txt";
            return rfname;
        }

        public string GetEleCsvSubDir(string scenename, MapProvider mapprov)
        {
            var suffix = "qk";
            if (mapextent == MapExtentTypeE.AsSpecified)
            {
                suffix = "as";
            }
            var nrowcol = $"elev/{nrow}-{ncol}{suffix}";
            var dirname = $"scenemaps/{QkMan.GetMapProvSubdirName(mapprov)}/{scenename}/{nrowcol}/";
            return dirname;
        }



        string GetElevCsvFullName(string ppath)
        {
            var fname = ppath + "eledata" + ".csv";
            return fname;
        }

        public (bool, string, double, double) GetWwwUri(LatLngBox llb, int nrow, int ncol, int iblk, int maxrowinblk)
        {
            var cursrow = iblk * maxrowinblk;
            var curerow = cursrow + maxrowinblk - 1;
            if (curerow > (nrow - 1)) curerow = nrow - 1;
            Debug.Log($"   GetWwwUri cursrow:{cursrow}  curerow:{curerow}");
            if (cursrow >= nrow)
            {
                Debug.LogError("cursrow>=nrow  currow:" + cursrow + " nrow:" + nrow);
                return (false, "", 0, 0);
            }
            var nrowsinblock = curerow - cursrow + 1;
            var pctmin = ((double)cursrow) / nrow;
            var pctmax = ((double)curerow) / nrow;
            var latmin = llb.minll.lat + pctmin * llb.extent.lat;
            var latmax = llb.minll.lat + pctmax * llb.extent.lat;
            int nrowstofetch = nrowsinblock;
            if (nrowsinblock == 1)
            {
                // have to retrieve more than one row
                latmax += 0.0000001;
                nrowstofetch++;
            }
            //Debug.Log("Geturi cursrow:" + cursrow + " curerow:" + curerow + "  nrowsinblock:" + nrowsinblock+" nrowstofetch:"+nrowstofetch);
            var uri = String.Format(url, latmin, llb.minll.lng, latmax, llb.maxll.lng, nrowstofetch, ncol, bingKey);
            return (true, uri, latmin, latmax);
        }
        public static int nblktodo;
        public static int nblkdone;

        async Task<(bool, string, int)> GetWwwElevDataAsync(string tpath, string ppath, bool execute = true)
        {
            Debug.Log($"GetElevDataAsy - llb:{llb.ToString()} nrow:{nrow} ncol:{ncol}");
            var ok = true;
            var errmsg = "";
            ElevCsvMaker csvmaker = new ElevCsvMaker(ncol, decpt: 1);

            int maxElevationsPerRequest = 1024; // https://docs.microsoft.com/en-us/bingmaps/rest-services/elevations/get-elevations
            int maxrowinblk = (maxElevationsPerRequest / ncol); // floor is what happens
            if (maxrowinblk <= 0)
            {
                errmsg = $"Error ncol:{ncol} great than Bing Elevation Api Max Request:{maxElevationsPerRequest}";
                return (false, errmsg, 0);
            }
            int nblk = nrow / maxrowinblk;
            if (nrow % maxrowinblk != 0) nblk += 1;// get the leftovers
            //Debug.Log($"Stats nrow:{nrow} maxrowinblk:{maxrowinblk} nblk:{nblk}");
            int nretrieved = 0;
            nblktodo = nblk;
            nblkdone = 0;

            for (int iblk = 0; iblk < nblk; iblk++)
            {
                //var uri = String.Format(url, llb.latmin, llb.lngmin, llb.latmax, llb.lngmax, nrow, ncol, bingKey);
                (var uriok, var uri, var blklatmin, var blklatmax) = GetWwwUri(llb, nrow, ncol, iblk, maxrowinblk);
                if (!uriok) break;
                if (execute)
                {
                    var rfname = GetElevReqName(tpath, iblk);
                    QresFinder.EnsureExistenceOfDirectory(rfname);
                    File.WriteAllText(rfname, uri);
                    Debug.Log($"Wrote {rfname} bytes:{uri.Length}");
                    using (var webRequest = UnityWebRequest.Get(uri))
                    {
                        // Request and wait for the desired page.
                        var wr = webRequest.SendWebRequest();
                        while (!webRequest.isDone)
                        {
                            await Task.Delay(TimeSpan.FromSeconds(0.05f));
                            Debug.Log("   back from Task.Delay");
                        }

                        string[] uriarray = uri.Split('/');
                        int urilast = uriarray.Length - 1;

                        if (webRequest.isNetworkError)
                        {
                            errmsg = uriarray[urilast] + " - Error: " + webRequest.error;
                            return (false, errmsg, nretrieved);
                        }
                        Debug.Log($"{uriarray[urilast]} - Received  {webRequest.downloadHandler.data.Length} bytes");
                        var fname = GetEleBlkPathFileName(tpath, iblk);
                        QresFinder.EnsureExistenceOfDirectory(fname);
                        var bytes = webRequest.downloadHandler.data;
                        var str = System.Text.Encoding.Default.GetString(bytes);
                        ok = str.Contains("\"statusCode\":200");
                        if (ok)
                        {
                            csvmaker.AddStr(iblk, blklatmin, blklatmax, str);
                        }
                        else
                        {
                            errmsg = $"See {fname} for error message";
                            Debug.LogError(errmsg);
                        }
                        File.WriteAllBytes(fname, bytes);
                        Debug.Log($"Wrote {fname} bytes:{bytes.Length} ok:{ok}  nretrieved:{nretrieved}");
                    }
                }
                nblkdone++;
                nretrieved++;
            }


            //var csvfname = GetElevCsvFullName();
            var csvfname = GetElevCsvFullName(ppath);
            QresFinder.EnsureExistenceOfDirectory(csvfname);
            csvmaker.WriteOut(csvfname);
            return (ok, errmsg, nretrieved);
        }
        QresFinder qrf = null;

        public List<float> heights = new List<float>();
        public async Task<(bool, int)> RetrieveElevations(bool execute = true, bool forceload = false)
        {
            var ok = true;
            string errmsg = "";
            var nretrieved = 0;
            if (heights.Count > 0) return (ok, nretrieved);

            var efname = "eledata.csv";
            var efpath = "qkmaps/" + GetEleCsvSubDir(scenename, mapprov);
            qrf = new QresFinder(elevprov, scenename, lod, efpath, efname, loadData:false);
            (ok, errmsg) = GetElevdataFromQresFinder(qrf);
            var ppath = qrf.GetPersistentPathName();
            var tpath = qrf.GetTempPathName();
            if (forceload || !ok)
            {
                Debug.LogWarning(errmsg);
                Debug.LogWarning("Trying to retrieve heights from web");
                //(ok,errmsg) = GetElevdataSync();
                (ok, errmsg, nretrieved) = await GetWwwElevDataAsync(tpath, ppath, execute);
                if (!ok)
                {
                    Debug.LogError(errmsg);
                }
                else
                {
                    qrf.Reload();
                    (ok, errmsg) = GetElevdataFromQresFinder(qrf);// try again
                    if (!ok)
                    {
                        Debug.LogError(errmsg);
                    }
                }
            }
            return (ok, nretrieved);
        }


        public (bool, string) ProcessDf(SimpleDf df)
        {
            var ok = true;
            var errmsg = "";
            var rheights = new List<float>();
            var vsum = 0f;
            var icnt = 0;
            var nc = df.Ncol();
            var nr = df.Nrow();
            var icolstart = df.ColIdx("V0");

            for (int irow = 0; irow < nr; irow++)
            {
                for (int icol = icolstart; icol < nc; icol++)
                {
                    var v = df.GetFltColRow(icol, irow);
                    rheights.Add(v);
                    vsum += v;
                    icnt++;
                }
            }
            ok = true;
            var vavg = vsum / icnt;
            //Debug.Log($"Got {icnt} values average:{vavg}");
            heights = rheights;
            return (ok, errmsg);
        }

        public (bool, string) GetElevdataFromCsvFile(string fname)
        {

            bool ok = false;
            var errmsg = "no error";
            if (!File.Exists(fname))
            {
                heights = new List<float>(); ;
                errmsg = $"File {fname} does not exist";
                return (ok, errmsg);
            }
            var df = new SimpleDf();
            df.ReadCsv(fname);
            return ProcessDf(df);
        }
        public void DeleteElevData(string scenename, MapProvider mapprov)
        {

            Debug.Log($"DeleteElevData for scenename:{scenename} mapprove:{mapprov.ToString()}");
            if (qrf == null) return;

            //var mprov = GetMapProvSubdirName(mapprov);
            //var ppath = $"{Application.persistentDataPath}/qkmaps/scenemaps/{mapprov}/{scenename}";
            //Directory.Delete(ppath, true);
            var ppath = qrf.GetPersistentPathName();
            var tpath = qrf.GetTempPathName();

#if UNITY_EDITOR_WIN
            var msg = $"Delete Elevation persistent and temp paths:\n\"{ppath}\"\n\"{tpath}\"\nPaths copied to clipboard";
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

        public (bool, string) GetElevdataFromQresFinder(QresFinder qrf)
        {
            if (!qrf.CheckCsvExistence())
            {
                return (false, "Qrf could not find data");
            }
            qrf.LoadIfNeeded();
            var text = qrf.GetText();
            var textar = text.Split('\n');
            var df = new SimpleDf();
            df.ReadCsv(new List<string>(textar));
            var rv = ProcessDf(df);
            return rv;
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}