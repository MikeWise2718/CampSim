using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aiskwk.Map
{

    public enum VehicleInitialPlacement { zero, random };

    public class VehicleTrackMan : MonoBehaviour
    {
        public static VehicleTrackMan singleton = null;
        public VehicleTrack.VehicleTrackForm vehicleTrackForm = VehicleTrack.VehicleTrackForm.Links;
        public string startFilterDate = "";
        public string endFilterDate = "";
        [Range(1f, 100f)]
        public float consolidationDistance = 10.0f;

        public QmapMesh qmm;
        public List<VehicleTrack> vehicleTracks;

        public bool stopOnCollisions = true;
        public int vehicleCollisionCount = 0;
        public bool restartCollisionVehicles = false;
        public bool moveToLastCollision = false;
        public bool loadAllTracks = false;
        public bool unloadAllTracks = false;
        public VehicleInitialPlacement vehicleInitialPlacement = VehicleInitialPlacement.zero;

        public bool animationStopped = false;
        public float defTrackScale = 1.0f;
        public float trackScale = 1.0f;
        public float trackWidthScale = 2.0f;
        public int numTracksToDo = 3;

        public enum TrackScenario { SuncorMine, CycladesTrip };
        public TrackScenario trackScenario = TrackScenario.SuncorMine;

        string[] vehicleTrackNames = new string[]{
        "D10_5552","SH1006","MM_1001","D10_5559","D11_5678","SH1611",
        "D11_5675","SH1008",
        "D8_5315","D8_5317"
    };
        string[] vehicleTrackNamesSim = new string[]{
        "D10_5552","SH1006","MM_1001"
    };
        string[] sailboatTrackNames = new string[]{
        "Kykladen11/track_points",
        "Kykladen12/track_points",
        "Kykladen13/track_points",
        "Kykladen14/track_points",
        "Kykladen15/track_points",
        "Kykladen16/track_points",
        "Kykladen17/track_points",
        "Kykladen18/track_points",
        "Kykladen19/track_points",
        "Kykladen20/track_points",
        "Kykladen21/track_points",
        "Kykladen22/track_points",
        "Kykladen23/track_points"
    };
        string[] trackColors = new string[]{
        "green","yellow","cyan","crimsom",
        "purple","orange","pink","red","blue",
        "forestgreen","navyblue","crimsom","olive"
    };
        string[] trackNames = null;
        public string rootPath = "";
        public string trackPath = "";

        public List<string> registeredVehicleTracks = null;

        public List<Vehicle> vehicles = null;
        public List<VehicleCollision> vehicleCollisions = null;

        public void Init(QmapMesh qmesh, string rootPath, TrackScenario trackScenario)
        {
            this.qmm = qmesh;
            VehicleTrack.qmesh = qmesh;


            vehicles = new List<Vehicle>();
            vehicleCollisions = new List<VehicleCollision>();

            vehicleCollisionCount = 0;
            this.rootPath = rootPath;
            this.trackScenario = trackScenario;
            SetScenarioConstants();
        }
        public string[] randomThings = new string[] { "DumpTruck" };




        public void SetScenarioConstants()
        {
            switch (trackScenario)
            {
                case TrackScenario.CycladesTrip:
                    trackNames = sailboatTrackNames;
                    trackPath = rootPath + "CycladesTrip/";
                    defTrackScale = 2;
                    trackWidthScale = 200;
                    consolidationDistance = 3 * trackWidthScale;
                    vehicleInitialPlacement = VehicleInitialPlacement.zero;
                    stopOnCollisions = false;
                    randomThings = new string[] { "Sailboat100" };
                    break;
                case TrackScenario.SuncorMine:
                    startFilterDate = "2019-07-16 10:00:00.000";
                    endFilterDate = "2019-07-16 16:59:59.000";
                    trackNames = vehicleTrackNamesSim;
                    trackPath = rootPath + "SuncorMine/";
                    vehicleInitialPlacement = VehicleInitialPlacement.random;
                    consolidationDistance = 20.0f;
                    defTrackScale = 1;
                    stopOnCollisions = true;
                    //randomThings = new string[] { "DumpTruck", "Dozer1", "Dozer2", "Minehaul1", "Shovel1" };
                    randomThings = new string[] { "Crane_LIEBHERR_HS_Dragline",
                                              "Komatsu_830E-AC",
                                              "komatsu_d575",
                                              //"Komatsu_HM300",
                                            //"komatsu_PC1250",
                                            //"Komatsu_WA1200" 
                                        };
                    break;
            }
            trackScale = defTrackScale;
        }
        public void AddVehicle(Vehicle v)
        {
            Debug.Log("VehicleTrackMan adding v " + v.name);
            vehicles.Add(v);
        }
        public void CheckVehicleCollisions()
        {
            int n = vehicles.Count;
            for (int i = 0; i < n; i++)
            {
                var v1 = vehicles[i];
                if (v1.avaGo.activeSelf)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        var v2 = vehicles[j];
                        if (v2.avaGo.activeSelf)
                        {
                            var col = Vehicle.CheckCollision(v1, v2);
                            if (col != null)
                            {
                                vehicleCollisions.Add(col);
                                if (stopOnCollisions)
                                {
                                    //animationStopped = true;
                                    StopSimulation();
                                }
                                Debug.Log($"{v1.name} collided with {v2.name} dist:{col.Distance()}");
                                vehicleCollisionCount++;
                            }
                        }
                    }
                }
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            vehicleTracks = new List<VehicleTrack>(VehicleTrack.RegisterTracks(this, trackNames, trackColors));
            registeredVehicleTracks = VehicleTrack.GetRegisteredTracks();
        }
        public VehicleTrack GetFirstActiveTrack()
        {
            foreach (var vt in vehicleTracks)
            {
                if (vt.isActivated)
                {
                    return vt;
                }
            }
            return null;
        }

        public VehicleTrack GetAddVehichalTrack()
        {
            foreach (var vt in vehicleTracks)
            {
                if (vt.addVehicleTrack)
                {
                    return vt;
                }
            }
            return null;
        }

        public bool SetAddVehichleTrack(int idx)
        {
            var avtvt = vehicleTracks[idx];
            if (!avtvt.isActivated)
            {
                Debug.LogError($"Can't make non active vehicle track ({avtvt.name} to the addVehicleTrack");
                return false;
            }
            foreach (var vt in vehicleTracks)
            {
                var newstat = vt.index == idx;
                vt.MakeAddVehicleTrack(newstat);
            }
            return true;
        }

        public VehicleTrack GetLastActiveTrack()
        {
            VehicleTrack rv = null;
            foreach (var vt in vehicleTracks)
            {
                if (vt.isActivated)
                {
                    rv = vt;
                }
            }
            return rv;
        }
        public VehicleTrack GetNextActiveTrack(VehicleTrack vt)
        {
            var idx = vehicleTracks.IndexOf(vt);
            if (idx < 0) return null;
            idx++;
            if (idx >= vehicleTracks.Count) return null;
            var vtn = vehicleTracks[idx];
            while (!vtn.isActivated)
            {
                idx++;
                if (idx >= vehicleTracks.Count) return null;
                vtn = vehicleTracks[idx];
            }
            return vtn;
        }

        // Update is called once per frame
        VehicleTrack.VehicleTrackForm old_vehicleTrackForm = VehicleTrack.VehicleTrackForm.Nodes;
        float old_consolidationDistance = 1.0f;

        int updatecount = 0;

        public bool CheckChg()
        {
            var chg = old_vehicleTrackForm != vehicleTrackForm ||
                      old_consolidationDistance != consolidationDistance;
            if (updatecount == 0 || chg)
            {
                old_vehicleTrackForm = vehicleTrackForm;
                old_consolidationDistance = consolidationDistance;
            }
            return chg;
        }

        public IEnumerator LoadAllTracks()
        {
            int i = 0;
            foreach (var vt in vehicleTracks)
            {
                vt.ActivateTrack();
                i++;
                if (i >= 2) return null;
            }
            return null;
        }
        public void UnloadAllTracks()
        {
            int i = 0;
            foreach (var vt in vehicleTracks)
            {
                vt.DeleteTrack();
                i++;
                if (i >= 2) return;
            }
        }

        #region simulationTime
        public float simulationStartTime;
        public float simulationTime;
        public float simulationMarkedTime;
        public float vehicleSimulationTime;

        public bool simulationRunning = false;
        public bool testStartSimulation = false;
        public bool testStopSimulation = false;

        [Range(-10f, 10f)]
        public float simulationTimeOffset;
        // simulation code
        public void StartSimulation()
        {
            if (!simulationRunning)
            {
                simulationStartTime = Time.time;
                simulationRunning = true;
            }
        }
        public void StopSimulation()
        {
            simulationTimeOffset = 0;
            simulationRunning = false;
            simulationMarkedTime = Time.time;
        }
        public void RestartSimulation()
        {
            simulationRunning = true;
            simulationTimeOffset = 0;
            simulationMarkedTime = Time.time;
        }
        public void UpdateSimulationTime()
        {
            if (simulationRunning)
            {
                var deltat = Time.time - simulationMarkedTime;
                simulationTime += deltat;
                simulationMarkedTime = Time.time;
            }
            vehicleSimulationTime = GetSimulationTime();
        }
        public float GetSimulationTime()
        {
            var rv = simulationTime;
            if (!simulationRunning)
            {
                rv += simulationTimeOffset;
            }
            return rv;
        }
        #endregion
        public void ActivateNextTrack()
        {
            Debug.Log($"ActivateNextTrack len:{vehicleTracks.Count}");
            foreach (var vt in vehicleTracks)
            {
                if (!vt.isActivated)
                {
                    vt.ActivateTrack();
                    SetAddVehichleTrack(vt.index);
                    break;
                }
            }
        }

        public void AddRandomVehicleToFirstActiveTrack()
        {
            var vt = GetFirstActiveTrack();
            if (vt != null)
            {
                vt.AddRandomVehicle();
            }
            else
            {
                Debug.LogError("No tracks active");
            }
        }

        public void AddVehicleToFirstActiveTrack(string thing)
        {
            foreach (var vt in vehicleTracks)
            {
                if (vt.isActivated)
                {
                    vt.AddVehicle(thing);
                    break;
                }
            }
        }

        public void MoveToLastCollision()
        {
            if (vehicleCollisions.Count > 0)
            {
                var col = vehicleCollisions[vehicleCollisions.Count - 1];
                qmm.viewer.MoveToPosition(col.GetPosition());
            }
        }

        public void RestartThings()
        {
            if (vehicleCollisions.Count > 0)
            {
                var col = vehicleCollisions[vehicleCollisions.Count - 1];
                col.RestartVehicles();
                vehicleCollisions.Remove(col);
            }
            RestartSimulation();
        }
        public void ResetTime()
        {
            if (!simulationRunning)
            {
                simulationTimeOffset = 0;
            }
        }
        public void MoveInTime(float val = 1)
        {
            if (!simulationRunning)
            {
                simulationTimeOffset += val;
            }
        }

        void Update()
        {
            var chg = CheckChg();
            if (registeredVehicleTracks != null)
            {
                foreach (var vname in registeredVehicleTracks)
                {
                    var vtrk = VehicleTrack.Lookup(vname);
                    if (vtrk != null)
                    {
                        vtrk.UpdateState(chg);
                    }
                }
            }
            if (simulationRunning)
            {
                CheckVehicleCollisions();
            }
            if (moveToLastCollision)
            {
                MoveToLastCollision();
                moveToLastCollision = false;
            }
            if (restartCollisionVehicles)
            {
                RestartThings();
                restartCollisionVehicles = false;
            }
            if (loadAllTracks)
            {
                StartCoroutine(LoadAllTracks());
                loadAllTracks = false;
            }
            if (unloadAllTracks)
            {
                UnloadAllTracks();
                unloadAllTracks = false;
            }
            if (testStartSimulation)
            {
                RestartSimulation();
                testStartSimulation = false;
            }
            if (testStopSimulation)
            {
                StopSimulation();
                testStopSimulation = false;
            }
            UpdateSimulationTime();
            updatecount++;
        }
    }
}