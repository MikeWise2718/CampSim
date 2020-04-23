using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Aiskwk.Dataframe;


namespace Aiskwk.Map
{
    public class GeotiffMan : MonoBehaviour
    {
        public bool loadingGeotiffs;
        public bool showAll;
        public bool showMediumGeosTiffs1;
        public bool showMediumGeosTiffs2;
        public bool showMediumGeosTiffs12;
        public bool hideAll;
        public bool showDecos;
        public QmapMesh qmm;
        public string geotTiffPath;
        public string tiffListName;
        public SimpleDf df;
        public int ngeos = 0;
        public int nloading = 0;
        public int filtColStride = 10;
        public int filtRowStride = 10;
        GameObject geoRoot = null;
        ShowGeotiffFrames sgf = null;
        public List<Geotiff> geotiffs = null;
        public List<string> fnames = null;
        public List<string> gnames = null;
        public List<bool> activecol = null;
        public List<double> lngmin = null;
        public List<double> lngmax = null;
        public List<double> latmin = null;
        public List<double> latmax = null;
        public List<double> elevmean = null;

        public void Init(QmapMesh qmesh, string rootPath, int filtColStride = 10, int filtRowStride = 10, bool initShowDecos = true)
        {
            this.qmm = qmesh;
            this.geotTiffPath = rootPath;
            this.tiffListName = rootPath + "geotifflist.csv";
            this.showDecos = initShowDecos;
            df = new SimpleDf();
            df.ReadCsv(tiffListName);
            geotiffs = new List<Geotiff>();
            //Debug.Log(df.InfoStr());
            //Debug.Log(df.InfoClassStr());
            fnames = df.GetStringCol("filename");
            lngmin = df.GetDoubleCol("lngmin");
            lngmax = df.GetDoubleCol("lngmax");
            latmin = df.GetDoubleCol("latmin");
            latmax = df.GetDoubleCol("latmax");
            elevmean = df.GetDoubleCol("meanelev");
            gnames = df.MakeNewStringCol("gnames", "");
            activecol = df.MakeNewBoolCol("active", Geotiff.defaultGeotiffEnabledState);
            this.filtColStride = filtColStride;
            this.filtRowStride = filtRowStride;
            ngeos = df.Nrow();
            geoRoot = new GameObject("Geotiffs");
            for (var idx = 0; idx < ngeos; idx++)
            {
                var fname = fnames[idx];
                if (fname.IndexOf('.') > 0)
                {
                    fname = fname.Split('.')[0];
                }
                gnames[idx] = fname;
                var gotgo = new GameObject(gnames[idx]);
                var gt = gotgo.AddComponent<Geotiff>();
                geotiffs.Add(gt);
                gt.Init(this, idx, filtColStride, filtRowStride);
                gotgo.transform.parent = geoRoot.transform;
            }
            sgf = qmm.AddCompTemp<ShowGeotiffFrames>(df);
            sgf.showDeco = showDecos;
            sgf.InitGeotiff(this);
            Debug.Log($"GeottiffMan - Read {ngeos} geotiff rows from {geotTiffPath}");
        }
        public void Refresh()
        {
            sgf.Refresh();
        }
        public Geotiff GetGeotiff(int index)
        {
            return geotiffs[index];
        }

        public bool GetActiveStat(int idx)
        {
            var rv = activecol[idx];
            return rv;
        }
        public void SetEnabledState(int idx, bool requested_state, bool updateFgos = true)
        {
            if (activecol[idx] != requested_state)
            {
                activecol[idx] = requested_state;
                geotiffs[idx].gameObject.SetActive(requested_state);
                geotiffs[idx].geotifActive = requested_state;
                if (updateFgos)
                {
                    sgf.UpdateFgos();
                }
            }
        }

        public (float minElev, float maxElev, float avgElev) GetElevFiltStats()
        {
            var minElev = float.MaxValue;
            var avgElev = 0f;
            var avgElevSum = 0f;
            var maxElev = float.MinValue;
            var gtcount = 0;
            foreach (var geo in geotiffs)
            {
                if (geo.geotifActive)
                {
                    var (gminElev, gmaxElev, gavgElev) = geo.GetElevFiltStats();
                    minElev = Mathf.Min(minElev, gminElev);
                    maxElev = Mathf.Max(maxElev, gmaxElev);
                    avgElevSum += gavgElev;
                    gtcount++;
                }
            }
            if (gtcount > 0)
            {
                avgElev = avgElevSum / gtcount;
            }
            return (minElev, maxElev, avgElev);
        }

        public (float xmin, float xmax, float zmin, float zmax) GetElevBox()
        {
            var xmin = float.MaxValue;
            var xmax = float.MinValue;
            var zmin = float.MaxValue;
            var zmax = float.MinValue;
            foreach (var geo in geotiffs)
            {
                if (geo.geotifActive)
                {
                    var (gxmin, gxmax, gzmin, gzmax) = geo.GetElevBox();
                    xmin = Mathf.Min(xmin, gxmin);
                    xmax = Mathf.Max(xmax, gxmax);
                    zmin = Mathf.Min(zmin, gzmin);
                    zmax = Mathf.Max(zmax, gzmax);
                }
            }
            return (xmin, xmax, zmin, zmax);
        }

        public bool InRange(float x, float z, bool debug = false)
        {
            if (geotiffs != null)
            {
                foreach (var geo in geotiffs)
                {
                    if (geo.geotifActive)
                    {
                        if (geo.InRange(x, z, debug)) return true;
                    }
                }
            }
            return false;
        }
        public (bool isin, float elev) GetElev(float x, float z, bool debug = false)
        {
            foreach (var geo in geotiffs)
            {
                if (geo.geotifActive)
                {
                    if (geo.InRange(x, z, debug))
                    {
                        var elev = geo.GetElev(x, z, debug);
                        return (true, elev);
                    }
                }
            }
            return (false, 0);
        }

        public string GetElevCmt(float x, float z)
        {
            foreach (var geo in geotiffs)
            {
                if (geo.geotifActive)
                {
                    if (geo.InRange(x, z))
                    {
                        var cmt = geo.GetElevCmt(x, z);
                        return cmt;
                    }
                }
            }
            return "nothing in range";
        }
        public void SetAllStatus(bool requested_state, string exception = "")
        {
            //Debug.Log("SAS:" + stat);
            for (int idx = 0; idx < ngeos; idx++)
            {
                var newstate = requested_state;
                var gname = gnames[idx];
                if (exception.IndexOf(gname) >= 0)
                {
                    newstate = !requested_state;
                }
                SetEnabledState(idx, newstate, updateFgos: false);
            }
            //Debug.Log("SAS - nchg:" + nchg);
            sgf.UpdateFgos();
        }

        void CheckIfStillLoading()
        {
            int nlocloading = 0;
            foreach (var geo in geotiffs)
            {
                if (geo.loading)
                {
                    nlocloading++;
                }
            }
            nloading = nlocloading;
            if (nloading == 0)
            {
                loadingGeotiffs = false;
                qmm.regenMesh = true;
            }
        }

        int updateCnt = 0;
        float lastTimeChecked = 0;
        void Update()
        {

            if (showAll)
            {
                SetAllStatus(true);
                showAll = false;
            }
            if (hideAll)
            {
                SetAllStatus(false);
                hideAll = false;
            }
            if (showMediumGeosTiffs1)
            {
                SetAllStatus(false, "be_09240927");
                showMediumGeosTiffs1 = false;
            }
            if (showMediumGeosTiffs2)
            {
                SetAllStatus(false, "be_09240927|be_09240922");
                //SetAllStatus(false, "be_09240934|be_09240935");
                showMediumGeosTiffs2 = false;
            }
            if (showMediumGeosTiffs12)
            {
                SetAllStatus(false, "|be_09240935|be_09240926|be_09240923|" +
                                    "|be_09240934|be_09240927|be_09240922|" +
                                    "|be_09240933|be_09240928|be_09240921|" +
                                    "|be_09240932|be_09240929|be_09240920|"
                                    );

                showMediumGeosTiffs12 = false;
            }
            if (loadingGeotiffs)
            {
                if (Time.time - lastTimeChecked > 1.0)
                {
                    CheckIfStillLoading();
                    lastTimeChecked = Time.time;
                }
            }
            updateCnt++;
        }
    }
}