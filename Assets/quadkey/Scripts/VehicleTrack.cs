using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aiskwk.Dataframe;

namespace Aiskwk.Map
{
    [Serializable]
    public class VehicleTrack : MonoBehaviour
    {

        public VehicleTrackMan vtm;
        public string vehicleTrackName;
        public string clr;
        public string rootname;
        public string fullcsvname;
        public float maxTrackTime;
        public float minTrackTime;
        public int minTrackIdx;
        public int maxTrackIdx;
        public int totalTrackIdx;
        public bool activate;
        public bool addVehicleTrack = false;
        public bool addDumpTruck = false;
        public bool addDozer1 = false;
        public bool addDozer2 = false;
        public bool addMinehaul1 = false;
        public bool addShovel1 = false;
        public bool addRover = false;
        public bool addSailboat1 = false;
        public bool addSailboat100 = false;
        public float avaSecpersec = 10f;
        public float avaSize = 10f;
        public bool isActivated = false;
        bool old_activate;
        bool old_addVehicleTrack;
        SimpleDf sdf;
        GameObject vehgo;

        public int nnodes = 0;
        public int nlinks = 0;

        public int index;

        public enum VehicleTrackForm { Nodes, Links, NodesAndLinks }
        public static float consolidationDistance = 0.1f;
        public VehicleTrack()
        {
        }
        static GameObject trgo = null;
        public void Init(VehicleTrackMan tracks, int idx, string newname, string clr)
        {
            if (trgo == null)
            {
                trgo = new GameObject("Tracks");
            }
            this.index = idx;
            this.transform.parent = trgo.transform;
            this.vtm = tracks;
            this.rootname = newname;
            this.clr = clr;
            this.old_activate = false;
            this.activate = false;
            this.vehgo = null;
            MakeAddVehicleTrack(false);
            SetVehicleTrackName();
        }

        public void SetVehicleTrackName()
        {
            if (activate)
            {
                this.vehicleTrackName = rootname + " " + this.activate.ToString() + "  " + this.clr;
            }
            else
            {
                this.vehicleTrackName = rootname;
            }
        }
        public static List<string> GetRegisteredTracks()
        {
            var rv = new List<string>(dozyTrackLookup.Keys);
            return rv;
        }
        static Layer tracklayer;
        static GameObject trackParent;
        static Layer vehiclelayer;
        static GameObject vehicleParent;
        public static VehicleTrack[] RegisterTracks(VehicleTrackMan dtm, string[] tracknames, string[] colors)
        {
            var ln = tracknames.Length;
            var rv = new VehicleTrack[ln];
            for (int idx = 0; idx < ln; idx++)
            {
                var iclr = idx % colors.Length;
                var newname = tracknames[idx];
                var newclr = colors[iclr];
                var vtrkgo = new GameObject(newname);
                var vtrk = vtrkgo.AddComponent<VehicleTrack>();
                vtrk.Init(dtm, idx, newname, newclr);
                rv[idx] = vtrk;
                dozyTrackLookup[newname] = vtrk;
            }
            tracklayer = dtm.qmm.layerman.AddLayer("tracks");
            trackParent = tracklayer.gameObject;
            vehiclelayer = dtm.qmm.layerman.AddLayer("vehicles");
            vehicleParent = vehiclelayer.gameObject;
            return rv;
        }
        public static VehicleTrack Lookup(string dozername)
        {
            if (!dozyTrackLookup.ContainsKey(dozername)) return null;
            return dozyTrackLookup[dozername];
        }
        public static QmapMesh qmesh;


        static Dictionary<string, VehicleTrack> dozyTrackLookup = new Dictionary<string, VehicleTrack>();

        public void MakeAddVehicleTrack(bool status)
        {
            this.addVehicleTrack = status;
            this.old_addVehicleTrack = status;
        }

        public void ResolveFullCsvName()
        {
            fullcsvname = vtm.trackPath + vehicleTrackName + ".csv";
        }
        public static GameObject GetDozyTrackParent()
        {
            if (trackParent == null)
            {
                trackParent = new GameObject("Tracks");
            }
            return trackParent;
        }
        bool isdozertrack = true;

        public void Load(string startFilterDate, string endFilterDate)
        {
            try
            {
                ResolveFullCsvName();
                Debug.Log("Load  " + fullcsvname);
                sdf = new SimpleDf();
                sdf.comment = clr;
                sdf.CheckConsistency("Before Load");
                sdf.preferedType["Id"] = SdfColType.dflong;
                sdf.preferedType["Timestamp"] = SdfColType.dfdatetime;
                sdf.preferedFormat["Timestamp"] = "yyyy-MM-dd HH:mm:ss.fff";
                sdf.preferedType["time"] = SdfColType.dfdatetime;
                sdf.preferedFormat["time"] = "yyyy/MM/dd HH:mm:ss.fff";
                sdf.preferedSubstitute["time"] = ("+00", "");
                sdf.ReadCsv(fullcsvname, quiet: false);
                Debug.Log($"Read {sdf.InfoStr()}");
                Debug.Log($"Cols: {sdf.InfoClassStr()}");
                Debug.Log($"Copying {sdf.InfoStr()}");
                var test = false;
                if (test)
                {
                    testsdf(sdf, startFilterDate, endFilterDate);
                }
                var tcolname = "Timestamp";
                isdozertrack = true;
                if (sdf.ColumnExists("time"))
                {
                    tcolname = "time";
                    isdozertrack = false;
                }
                sdf.KeepColumns(new string[] { "Id", "Timestamp", "x", "y", "time", "X", "Y" });
                sdf = SimpleDf.SortOnColumn(sdf, tcolname);
                if (isdozertrack)
                {
                    var blst = sdf.GetBoolFilter("Timestamp", startFilterDate, endFilterDate);
                    sdf = SimpleDf.Subset(sdf, "df", blst);
                }
                else
                {
                    sdf.RenameColumn("X", "x");
                    sdf.RenameColumn("Y", "y");
                }
                sdf.FloatTimeFromDateString(tcolname, "Elaptime");
                sdf.preferedFormat["Elaptime"] = "f2";
                test = true;
                if (test)
                {
                    //sdf.WriteCsv("transformed_df.csv");
                }
                var nrow = sdf.Nrow();
                if (nrow == 0)
                {
                    Debug.LogWarning("No rows in df " + fullcsvname);
                    sdf = null;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("Exception in DozerTracks.Load:" + ex.ToString());
            }
        }

        void testsdf(SimpleDf sdf, string startFilterDate, string endFilterDate)
        {
            sdf.OutputDebugInfoStatStr();
            var tdf = SimpleDf.Copy(sdf, "tdf");
            Debug.Log($"Copying completed");
            Debug.Log($"Copied {tdf.InfoStr()}");
            Debug.Log($"Cols: {tdf.InfoClassStr()}");
            Debug.Log($"Cols: {tdf.InfoInversionsStr()}");
            tdf.KeepColumns(new string[] { "Id", "Timestamp", "x", "y" });
            //tdf = SimpleDf.SortOnColumn(tdf, "Timestamp", descend:true, quiet: false);	
            tdf.preferedFormat["Timestamp"] = "yyyy-MM-dd HH:mm:ss.fff";
            var tblst = tdf.GetBoolFilter("Timestamp", startFilterDate, endFilterDate);
            tdf = SimpleDf.Subset(tdf, "tdf", tblst);
            tdf.MakeNewFloatCol("testcol", 0.0f, 3.14f);
            tdf.FloatTimeFromDateString("Timestamp", "Elaptime");
            tdf.preferedFormat["Elaptime"] = "f2";
            tdf.WriteCsv("testcsvname.csv");
        }

        public IEnumerator PlotStaticTrack()
        {
            var sw = new StopWatch();
            ResolveFullCsvName();
            Debug.Log("Plot  " + vehicleTrackName);
            //if (dozgo != null)
            //{
            //    DeleteTrack();
            //}
            vehgo = new GameObject(vehicleTrackName + "_tracks");
            vehgo.transform.parent = trackParent.transform;
            var lngcol = sdf.GetDoubleCol("x");
            var latcol = sdf.GetDoubleCol("y");
            var skalink = vtm.trackScale * 0.5f; // meters
            var skawid = vtm.trackWidthScale;
            var skanode = vtm.trackScale * 0.57f; // meters
            nnodes = 0;
            nlinks = 0;
            var nrow = sdf.Nrow();
            if (nrow == 0)
            {
                Debug.LogError("Plot Static Track - no rows in track df " + fullcsvname);
                yield break;
            }
            Debug.Log("Plotting " + vehicleTrackName + " consolidationDistance:" + vtm.consolidationDistance + "  trackscale:" + vtm.trackScale);
            var ll0 = new LatLng(latcol[0], lngcol[0]);
            (var pos0, _, _) = qmesh.GetQkWcMeshPosFromLatLng(ll0);
            var dolinks = vtm.vehicleTrackForm == VehicleTrackForm.Links || vtm.vehicleTrackForm == VehicleTrackForm.NodesAndLinks;
            var donodes = vtm.vehicleTrackForm == VehicleTrackForm.Nodes || vtm.vehicleTrackForm == VehicleTrackForm.NodesAndLinks;
            for (var i = 0; i < nrow; i++)
            {
                var ptname = "pt" + i;
                var ppname = "pp" + i;
                if (ptname == "pt21632")
                {
                    Debug.Log("pt:" + ptname);
                }
                var ll = new LatLng(latcol[i], lngcol[i]);
                (var pos, _, _) = qmesh.GetQkWcMeshPosFromLatLng(ll);
                if (Vector3.Distance(pos0, pos) > vtm.consolidationDistance)
                {
                    if (donodes)
                    {
                        QsphInfo.DoInfoSphereSlim(vehgo, ptname, pos, skanode, clr, ll);
                        nnodes++;
                    }
                    if (dolinks)
                    {
                        var cclr = qut.GetColorByName(clr);
                        var frac = i * 1.0f / nrow;
                        var nclr = Color.Lerp(cclr, Color.white, frac);
                        //var pipe = qut.CreatePipe(ppname, pos0, pos, nclr, skalink);
                        //var pipe = GpuInst.CreateCylinderGpu(ppname, pos0, pos, skalink, clr);
                        var pipe = vtm.qmm.qtt.AddFragLine(ppname, pos0, pos, "pipe", skalink, lclr: clr, widratio: skawid,wps:true);
                        pipe.transform.parent = vehgo.transform;
                        nlinks++;
                    }
                    pos0 = pos;
                }
                if (sw.ElapfOverYieldTime())
                {
                    //Debug.Log($"Plot Static Track yielding on {i} of {nrow} after {sw.ElapSecs()} secs");
                    yield return null;
                }
            }
            sw.Stop();
            Debug.Log($"Plot static track plotted {nnodes} nodes and {nlinks} links in {sw.ElapSecs()} secs");
            yield return null;
        }



        public void DeleteTrack()
        {
            if (vehgo != null)
            {
                Debug.Log("Deleteing " + vehicleTrackName + " track");
                UnityEngine.Component.Destroy(vehgo);
                vehgo = null;
            }
        }

        public void SetupTrackTimes()
        {
            var fcol = sdf.GetFloatCol("Elaptime");
            var (fmin, imin, fmax, imax) = sdf.GetMinMax<float>(fcol);
            //minTrackTime = fmin / avaSecpersec;
            minTrackTime = fmin;
            minTrackIdx = imin;
            //maxTrackTime = fmax / avaSecpersec;
            maxTrackTime = fmax;
            maxTrackIdx = imax;
            totalTrackIdx = sdf.Nrow();
            Debug.Log($"Track {name} mintime:{minTrackTime} maxtime:{maxTrackTime} imin:{minTrackIdx} imax:{maxTrackIdx} nrow:{totalTrackIdx} avaSecpersec:{avaSecpersec}");
        }

        public float GetRandomTrackTime()
        {
            var rv = qut.GetRanFloat(minTrackTime, maxTrackTime, "tracktimes");
            Debug.Log($"GetRandomTrackTime - min:{minTrackTime}  max:{maxTrackTime}  ran:{rv}");
            return rv;
        }

        public void ActivateTrack()
        {
            Debug.Log("Calling Load");
            if (sdf == null)
            {
                SimpleDf.SdfConsistencyLevel = SdfConsistencyLevel.none;
                Load(vtm.startFilterDate, vtm.endFilterDate);
                SetupTrackTimes();
                Debug.Log("Loaded track " + sdf.name);
            }
            if (sdf != null)
            {
                Debug.Log("Calling PlotStaticTrack");
                StartCoroutine(PlotStaticTrack());
            }
            isActivated = true;
            vtm.StartSimulation();
        }

        public void UpdateState(bool forceupdate)
        {
            if (forceupdate || old_activate != activate)
            {
                if (activate)
                {
                    ActivateTrack();
                }
                else
                {
                    DeleteTrack();
                }
                old_activate = activate;
                SetVehicleTrackName();
            }
        }

        static Dictionary<string, int> vcount = new Dictionary<string, int>();
        static int VehCount(string avatartype)
        {
            if (!vcount.ContainsKey(avatartype))
            {
                vcount[avatartype] = 0;
            }
            vcount[avatartype]++;
            return vcount[avatartype];
        }
        public void AddVehicle(string thing)
        {
            var n = VehCount(thing);
            var vname = $"{thing}_{n}";
            var vgo = new GameObject(vname);
            var v = vgo.AddComponent<Vehicle>();
            v.Init(this, sdf, vehicleParent, thing, Time.time, avaSecpersec);
            vtm.AddVehicle(v);
            vehicleLst.Add(v);
            Debug.Log($"Adding vehicle {vname} to track {name}");
        }
        public SimpleDf GetSdf()
        {
            return sdf;
        }
        public void AddRandomVehicle()
        {
            var thing = vtm.randomThings[qut.GetRanInt(0, vtm.randomThings.Length)];
            AddVehicle(thing);
        }
        public void AddShovel()
        {
            AddVehicle("Crane_LIEBHERR_HS_Dragline");
        }
        public void AddMineTruck()
        {
            AddVehicle("Komatsu_830E-AC");
        }
        public void AddDozer()
        {
            AddVehicle("komatsu_d575");
        }

        public void AddPreferedVehicles()
        {
            Debug.Log("AddPreferedVehicles for:" + name);
            var flet = name.ToLower()[0];
            switch (flet)
            {
                case 'd':
                    {
                        AddDozer();
                        AddDozer();
                        AddDozer();
                        break;
                    }
                default:
                case 'm':
                    {
                        AddMineTruck();
                        AddMineTruck();
                        AddMineTruck();
                        AddMineTruck();
                        AddMineTruck();
                        break;
                    }
                case 's':
                    {
                        AddShovel();
                        break;
                    }
            }
        }


        public void CheckIfAddingThing(string thing, ref bool bvar)
        {
            if (bvar)
            {
                bvar = false;
                if (!activate)
                {
                    Debug.LogWarning("Activate track first");
                }
                else
                {
                    AddVehicle(thing);
                }
            }
        }

        public List<Vehicle> vehicleLst = new List<Vehicle>();

        private void Update()
        {
            CheckIfAddingThing("DumpTruck", ref addDumpTruck);
            CheckIfAddingThing("Dozer1", ref addDozer1);
            CheckIfAddingThing("Dozer2", ref addDozer2);
            CheckIfAddingThing("Minehaul1", ref addMinehaul1);
            CheckIfAddingThing("Shovel1", ref addShovel1);
            CheckIfAddingThing("Rover", ref addRover);
            CheckIfAddingThing("Sailboat1", ref addSailboat1);
            CheckIfAddingThing("Sailboat100", ref addSailboat100);
            if (!old_addVehicleTrack && addVehicleTrack)
            {
                Debug.Log($"MakeAddVehicleTrack triggered for {name} idx:{index}");
                if (!vtm.SetAddVehichleTrack(index))
                {
                    MakeAddVehicleTrack(false);
                }
            }
        }
    }
}