using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;
using Aiskwk.Dataframe;

namespace Aiskwk.Map
{
    public class Geotiff : MonoBehaviour
    {
        public static bool defaultGeotiffEnabledState = true;
        GeotiffMan gtm;
        QmapMesh qmm;
        bool old_geotifActive;
        public bool geotifActive;
        public bool dumpData;
        public int filtColStride = 10;
        public int filtRowStride = 10;
        public bool buildFilteredElevs;
        int index;

        public bool load;
        public bool isLoaded;
        public bool loadFailed;
        public bool loading = false;
        public LatLng ll1;
        public LatLng ll2;
        public LatLng ll3;
        public LatLng ll4;
        public Vector3 pbl;
        public Vector3 pbr;
        public Vector3 pul;
        public Vector3 pur;

        public float pmeany;
        public float elevmean;
        public string gname;
        public SimpleDf sdf = null;
        public void Init(GeotiffMan gtm, int index, int filtColStride = 10, int filtRowStride = 10)
        {
            this.load = false;
            this.loading = false;
            this.isLoaded = false;
            this.loadFailed = false;
            this.filtColStride = filtColStride;
            this.filtRowStride = filtRowStride;

            this.gtm = gtm;
            this.index = index;
            this.geotifActive = defaultGeotiffEnabledState;
            this.old_geotifActive = geotifActive;
            ll1 = new LatLng(gtm.latmin[index], gtm.lngmin[index]);
            ll2 = new LatLng(gtm.latmin[index], gtm.lngmax[index]);
            ll3 = new LatLng(gtm.latmax[index], gtm.lngmax[index]);
            ll4 = new LatLng(gtm.latmax[index], gtm.lngmin[index]);
            qmm = gtm.qmm;
            CalculateCornerPoints();
            gname = gtm.gnames[index];
            transform.position = (pbl + pbr + pur + pul) / 4;
            elevmean = (float)gtm.elevmean[index];
        }
        public void CalculateCornerPoints()
        {
            pbl = qmm.GetPosFromLatLng(ll1);
            pbr = qmm.GetPosFromLatLng(ll2);
            pur = qmm.GetPosFromLatLng(ll3);
            pul = qmm.GetPosFromLatLng(ll4);
            pmeany = (pbl.y + pbr.y + pul.y + pur.y) / 4;
        }
        // Start is called before the first frame update


        private void Load()
        {
            sdf = null;// delete any old ones
            var sw = new StopWatch();
            var fname = gtm.geotTiffPath + $"output/{gname}.csvc";
            var exists = System.IO.File.Exists(fname);
            Debug.Log($"Geotiff {fname} exists:{exists}");
            sdf = new SimpleDf();
            SimpleDf.SdfConsistencyLevel = SdfConsistencyLevel.none;
            StartCoroutine(sdf.ReadCsvYieldable(fname, quiet: true));
        }

        private async void LoadLidarDataAsync()
        {
            sdf = null;// delete any old ones
            var sw = new StopWatch();
            var fname = gtm.geotTiffPath + $"output/{gname}.csvc";
            var exists = System.IO.File.Exists(fname);
            Debug.Log($"Lidar file {fname} exists:{exists}");
            sdf = new SimpleDf();
            SimpleDf.SdfConsistencyLevel = SdfConsistencyLevel.none;
            var ok = await sdf.ReadCsvAwaitable(fname, quiet: true);
            if (ok)
            {
                //Debug.Log("ReadCsvAwaitable returned " + ok);
            }
        }
        int ncolGeotiff = 0;
        int nRowGeotiff = 0;
        int nColElevFilt;
        int nRowElevFilt;
        float filtXdist;
        float filtZdist;
        float filtRowDelta;
        float filtColDelta;
        string[,] elevComment;
        float[,] elevFilt;
        int[,] elevFiltCount;
        float xresGeotiff;
        float zresGeotiff;
        float avgEleVal;
        float minEleVal;
        float maxEleVal;

        public (int ncol, int nrow, int nfiltelevx, int nfiltelevz) GetElevFiltDimension()
        {
            return (ncolGeotiff, nRowGeotiff, nColElevFilt, nRowElevFilt);
        }
        public (float minElev, float maxElev, float avgElev) GetElevFiltStats()
        {
            return (minEleVal, maxEleVal, avgEleVal);
        }
        public (float xmin, float xmax, float zmin, float zmax) GetElevBox()
        {
            var xmin = pul.x;
            var xmax = pur.x;
            var zmin = pul.z;
            var zmax = pbl.z;
            return (xmin, xmax, zmin, zmax);
        }
        static Dictionary<string, int> oorErrors = new Dictionary<string, int>();

        public static void InitOorDict()
        {
            oorErrors = new Dictionary<string, int>();
        }
        static void addOorError(string id)
        {
            if (!oorErrors.ContainsKey(id))
            {
                oorErrors[id] = 0;
            }
            oorErrors[id] += 1;
        }
        public static void ReportOorErrors()
        {
            foreach (var key in oorErrors.Keys)
            {
                Debug.LogWarning($"There were {oorErrors[key]} {key} out-of-range errors");
            }
        }

        public void ClampColumnIdxs(string id, ref int iCol, ref int iRow)
        {
            if (iCol < 0 || nColElevFilt <= iCol)
            {
                //Debug.LogError($"{id} opps iCol:{iCol} out of range - nfiltelevx:{nColElevFilt}");
                iCol = Mathf.Max(0, iCol);
                iCol = Mathf.Min(iCol, nColElevFilt - 1);
                addOorError($"{name}-{id}-col");
            }
            if (iRow < 0 || nRowElevFilt <= iRow)
            {
                //Debug.LogError($"{id} opps iRow:{iRow} out of range - nfiltelevz:{nRowElevFilt}");
                iRow = Mathf.Max(0, iRow);
                iRow = Mathf.Min(iRow, nRowElevFilt - 1);
                addOorError($"{name}-{id}-row");
            }
        }
        public (Vector3 pos, Vector3 size, float elev) GetElevFiltPosition(int iCol, int iRow)
        {
            if (ncolGeotiff <= 0 || nRowGeotiff <= 0)
            {
                Debug.LogError($"GEFP opps nrow:{nRowGeotiff} ncol:{ncolGeotiff} - neither can be zero");
                return (Vector3.zero, Vector3.zero, 0);
            }
            ClampColumnIdxs("GEFP", ref iCol, ref iRow);
            var dx = (iCol + 0.5f) * filtColStride * (pur - pul) / ncolGeotiff;
            var dz = (iRow + 0.5f) * filtRowStride * (pbl - pul) / nRowGeotiff;
            var p = pul + dx + dz;
            var elev = elevFilt[iCol, iRow];
            var sx = filtColStride * Mathf.Abs(xresGeotiff);
            var sz = filtRowStride * Mathf.Abs(zresGeotiff);
            return (p, new Vector3(sx, elev, sz), elev);
        }
        public (int, int) GetIdx(float x, float z, bool clamp = false, string clampid = "")
        {
            var iCol = (int)((x - pul.x) / filtColDelta);
            var iRow = (int)((z - pbl.z) / filtRowDelta);
            if (clamp)
            {
                ClampColumnIdxs(clampid, ref iCol, ref iRow);
            }
            return (iCol, iRow);
        }
        public float GetElev(float x, float z, bool debug = false)
        {
            if (!isLoaded)
            {
                return 0;
            }
            var elev = avgEleVal;
            if (InRange(x, z))
            {
                var (iCol, iRow) = GetIdx(x, z, clamp: true, clampid: "GE");
                elev = elevFilt[iRow, iCol];
            }
            return elev;
        }
        public string GetElevCmt(float x, float z)
        {
            var rv = name + " not loaded";
            if (!isLoaded) return rv;
            rv = name + " out-of-range";
            if (InRange(x, z))
            {
                var (iCol, iRow) = GetIdx(x, z);
                if ((iCol < 0) || (nColElevFilt <= iCol) || (iRow < 0) || (nRowElevFilt <= iRow))
                {
                    var elev = GetElev(x, z);
                    var (iColNew, iRowNew) = GetIdx(x, z, clamp: true, clampid: "GE");
                    rv = name + $" elev:{elev} oor x:{x} z:{z} //  iCol:{iCol} iRow:{iRow}  new iCol:{iColNew} iRow:{iRowNew}";
                }
                else
                {
                    var elev = GetElev(x, z);
                    rv = name + $" elev:{elev} {elevComment[iRow, iCol]} // iCol:{iCol} iRow:{iRow}";
                }
            }
            return rv;
        }

        public bool InRange(float x, float z, bool debug = false)
        {
            var res = true;
            if (x < pul.x) res = false;
            if (pbl.x < x) res = false;
            if (z < pbl.z) res = false;
            if (pbr.z < z) res = false;
            if (debug)
            {
                Debug.Log($"Geotiff {name} -InRange - x:{x}  pul.x:{pul.x} pbl.x:{pbl.x}  res:{res}");
                Debug.Log($"Geotiff {name} -InRange - z:{z}  pbr.z:{pbr.z} pbl.z:{pbl.z}  res:{res}");
            }
            return res;
        }

        public void BuildFilteredElevs()
        {
            var sw = new StopWatch();
            if (sdf?.dfStatus != DfStatus.finished)
            {
                Debug.LogError("Sdf not loaded");
                return;
            }
            nRowGeotiff = sdf.GetInt("nrow", -1);
            ncolGeotiff = sdf.GetInt("ncol", -1);
            xresGeotiff = sdf.GetInt("xres", 1);
            zresGeotiff = sdf.GetInt("yres", 1);
            var nTotGeotiffValues = nRowGeotiff * ncolGeotiff;
            //Debug.Log($"BFE - nrowGeotiff:{nRowGeotiff} ncolGeotiff:{ncolGeotiff} nTotGeotiffValues:{nTotGeotiffValues} filtXstride:{filtColStride} filterz:{filtRowStride}");

            var elevs = sdf.GetDoubleCol("elev");
            nColElevFilt = (int)(Mathf.Ceil((ncolGeotiff * 1f) / filtColStride));
            //Debug.Log($"BFE - nColEleveFilt:{nColElevFilt}  ncolGeotiff:{ncolGeotiff}  filtColStride:{filtColStride}");
            nRowElevFilt = (int)(Mathf.Ceil((nRowGeotiff * 1f) / filtRowStride));
            //Debug.Log($"BFE - nRowEleveFilt:{nRowElevFilt}  nRowGeotiff:{nRowGeotiff}  filtRowStride:{filtRowStride}");
            filtXdist = pbl.x - pul.x;
            filtZdist = pbr.z - pbl.z;
            filtRowDelta = filtXdist / nColElevFilt;
            filtColDelta = filtZdist / nRowElevFilt;
            //Debug.Log($"BFE - nFiltElevX:{nColElevFilt}  filtXdist:{filtXdist}  filtXdelta:{filtRowDelta}");
            //Debug.Log($"BFE - nFiltElevZ:{nRowElevFilt}  filtZdist:{filtZdist}  filtZdelta:{filtColDelta}");
            elevComment = new string[nColElevFilt, nRowElevFilt];
            elevFilt = new float[nColElevFilt, nRowElevFilt];
            elevFiltCount = new int[nColElevFilt, nRowElevFilt];
            for (int i = 0; i < nTotGeotiffValues; i++)
            {
                var iCol = (i % ncolGeotiff) / filtColStride;
                var iRow = (i / ncolGeotiff) / filtRowStride;
                if (iCol >= nColElevFilt)
                {
                    Debug.LogError($"BFE opps iCol:{iCol} ge than nColElevFilt:{nColElevFilt}");
                }
                else if (iRow >= nRowElevFilt)
                {
                    Debug.LogError($"BFE opps iRow:{iRow} ge than nRowElevFilt:{nRowElevFilt}");
                }
                else
                {
                    elevFilt[iCol, iRow] += (float)elevs[i];
                    elevFiltCount[iCol, iRow]++;
                }
            }
            int zeroElevSumErrorCount = 0;
            minEleVal = float.MaxValue;
            maxEleVal = float.MinValue;
            var totelevsum = 0f;
            for (int iCol = 0; iCol < nColElevFilt; iCol++)
            {
                for (int iRow = 0; iRow < nRowElevFilt; iRow++)
                {
                    if (elevFiltCount[iCol, iRow] == 0)
                    {
                        Debug.LogError($"BFE opps - elevFiltCount==0 for iCol:{iCol} iRow:{iRow}");
                        zeroElevSumErrorCount++;
                    }
                    else
                    {
                        var elevsum = elevFilt[iCol, iRow];
                        elevFilt[iCol, iRow] = elevsum / elevFiltCount[iCol, iRow];
                        elevComment[iCol, iRow] = $"sum:{elevsum} cnt:{elevFiltCount[iCol, iRow]}";
                    }
                    minEleVal = Mathf.Min(minEleVal, elevFilt[iCol, iRow]);
                    maxEleVal = Mathf.Max(maxEleVal, elevFilt[iCol, iRow]);
                    totelevsum += elevFilt[iCol, iRow];
                }
            }
            avgEleVal = totelevsum / (nColElevFilt * nRowElevFilt);
            sw.Stop();
            //Debug.Log($"BFE - nfilterelevx:{nColElevFilt} nfilterelevy:{nRowElevFilt} elevavg:{avgEleVal} elap:{sw.ElapSecs()}");

            //Debug.Log($"pul {pul} Col,Row:{GetIdx(pul.x, pul.z)} elev:{GetElev(pul.x, pul.z)}");
            //Debug.Log($"pur {pur} Col,Row:{GetIdx(pur.x, pur.z)} elev:{GetElev(pur.x, pur.z)}");
            //Debug.Log($"pbl {pbl} Col,Row:{GetIdx(pbl.x, pbl.z)} elev:{GetElev(pbl.x, pbl.z)}");
            //Debug.Log($"pbr {pbr} Col,Row:{GetIdx(pbr.x, pbr.z)} elev:{GetElev(pbr.x, pbr.z)}");
        }
        public void DumpData()
        {
            var lst = new List<string>();
            for (int iCol = 0; iCol < nColElevFilt; iCol++)
            {
                for (int iRow = 0; iRow < nRowElevFilt; iRow++)
                {
                    var l = $"{iCol},{iRow},{elevFilt[iCol, iRow]},{elevFiltCount[iCol, iRow]},{elevComment[iCol, iRow]}";
                    lst.Add(l);
                }
            }
            var fname = name + ".txt";
            System.IO.File.WriteAllLines(fname, lst);
        }
        private void CheckFinishLoad()
        {
            if (loading)
            {
                if (sdf?.dfStatus == DfStatus.finished)
                {
                    var nrow = sdf.GetInt("nrow", -1);
                    var ncol = sdf.GetInt("ncol", -1);
                    var ntotvals = nrow * ncol;
                    var elevs = sdf.GetDoubleCol("elev");
                    var elevavg = elevs.Average();
                    //Debug.Log($"{sdf.name} nrow:{nrow} ncol:{ncol} totres:{nrow * ncol}");
                    //Debug.Log($"{sdf.name} has {sdf.Nrow()} rows and {sdf.Ncol()} cols - elev avg:{elevavg}");
                    if (ntotvals != sdf.Nrow())
                    {
                        Debug.LogError($"Number of expected values in {sdf.name} - {ntotvals} is not the same as the number of rows {sdf.Nrow()}");
                    }
                    else
                    {
                        //Debug.Log($"{sdf.name} contains correct number of values");
                    }
                    loading = false;
                    //Task.Run(() => LoadAsync());
                    BuildFilteredElevs();
                    gtm.Refresh();
                }
                else if (sdf?.dfStatus == DfStatus.erroredOutOfReading)
                {
                    Debug.LogError($"{sdf.name} errored out of reading");
                    loading = false;

                }
                isLoaded = true;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (geotifActive != old_geotifActive)
            {
                gtm.SetEnabledState(index, geotifActive);
                old_geotifActive = geotifActive;
            }
            if (load)
            {
                Task.Run(() => LoadLidarDataAsync());
                loading = true;
                load = false;
            }
            if (geotifActive && !isLoaded && !loading && !loadFailed)
            {
                loading = true;
                // Debug.Log($"Kicking off loading lidar data for {name}");
                Task.Run(() => LoadLidarDataAsync());
                gtm.loadingGeotiffs = true;
            }
            if (loading)
            {
                CheckFinishLoad();
            }
            if (buildFilteredElevs)
            {
                BuildFilteredElevs();
                buildFilteredElevs = false;
            }
            if (dumpData)
            {
                DumpData();
                dumpData = false;
            }
        }
    }
}