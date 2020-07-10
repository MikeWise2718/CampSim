using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aiskwk.Dataframe;

namespace Aiskwk.Map
{
    public enum SceneScenario { None, Cyclades, SuncorDozers }

    public class SceneScripter : MonoBehaviour
    {
        public SceneScenario scenario = SceneScenario.None;
        public bool started = false;
        public bool fattracks = false;
        VehicleTrackMan vtm;
        bool running = false;
        // Start is called before the first frame update
        //void Start()
        //{

        //}

        public void Init(SceneScenario scenario, VehicleTrackMan vtm)
        {
            this.scenario = scenario;
            this.vtm = vtm;
        }

        bool tracksLoaded = false;
        public void SetScale()
        {
            if (fattracks)
            {
                vtm.trackScale = vtm.defTrackScale * 10;
                vtm.consolidationDistance = 3 * vtm.trackScale;
            }
            else
            {
                vtm.trackScale = vtm.defTrackScale;
                vtm.consolidationDistance = 3 * vtm.trackScale;

            }
            Debug.Log("Set cd in SceneScenario.SetScale:" + vtm.consolidationDistance);
        }

        public IEnumerator LoadTracks()
        {
            if (!tracksLoaded)
            {
                SetScale();
                tracksLoaded = true;
                foreach (var trk in vtm.vehicleTracks)
                {
                    SimpleDf.SdfConsistencyLevel = SdfConsistencyLevel.none;
                    trk.activate = true;
                    trk.ActivateTrack();
                    yield return null;
                }
            }
        }
        public IEnumerator RefreshTracks()
        {
            Debug.Log("RefreshTracks");
            foreach (var trk in vtm.vehicleTracks)
            {
                trk.DeleteTrack();
                StartCoroutine(trk.PlotStaticTrack());
                yield return new WaitForSeconds(0.2f);
                break;
            }
        }

        public void AddVehicles()
        {
            Debug.Log("AddVehicles");
            foreach (var trk in vtm.vehicleTracks)
            {
                trk.AddPreferedVehicles();
            }
        }


        int TracksNotLoaded()
        {
            var rv = 0;
            foreach (var trk in vtm.vehicleTracks)
            {
                if (trk.GetSdf() == null)
                {
                    rv++;
                }
            }
            return rv;
        }

        bool lastStarted = false;
        bool lastFatTracks = false;
        int otnl = 0;
        bool waitingForLoading = false;

        void Update()
        {
            if (lastStarted != started)
            {
                running = started;
                if (!tracksLoaded)
                {
                    otnl = TracksNotLoaded();
                    StartCoroutine(LoadTracks());
                    waitingForLoading = true;
                }
            }
            if (waitingForLoading)
            {
                var tnl = TracksNotLoaded();
                if (TracksNotLoaded() == 0)
                {
                    Debug.Log($"WFL: Tracks are loaded time:{Time.time} - now adding vehicles");
                    waitingForLoading = false;
                    AddVehicles();
                    vtm.stopOnCollisions = false;
                    vtm.StartSimulation();
                }
                else if (tnl != otnl)
                {
                    Debug.Log($"WFL: Tracks not loaded:{tnl} time:{Time.time}");
                }
                otnl = tnl;
            }
            if (fattracks != lastFatTracks)
            {
                SetScale();
                StartCoroutine(RefreshTracks());
                lastFatTracks = fattracks;
            }
        }
    }
}