using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UxUtils;
using Aiskwk.Map;
using Aiskwk.Dataframe;
using Microsoft.Win32;

namespace CampusSimulator
{

    public class CoordMapMan : MonoBehaviour
    {
        public SceneMan sman;
        public SceneSelE curscene;

        public LatLongMap glbllm;

        public bool showCoords;

        public void InitPhase0()
        {
        }

        public void InitializeGlbLlMap()
        {
            glbllm = new LatLongMap($"SceneMan.InitializeGlbLlMap(  ) with curscene:{curscene}");
            glbllm.InitMapFromSceneSelString(curscene.ToString(), sman.mpman.bespokespec?.llbox); // doesn't handle non-llmap scenes 
        }
        public (float x, float z) lltoxz(double lat, double lng)
        {
            if (glbllm == null)
            {
                Debug.LogError($"CoordMapMan.glbllm is null");
                return ((float)lng, (float)lat);
            }
            if (glbllm.maps == null)
            {
                Debug.LogError($"CoordMapMan.glbllm.mapps is null");
                return ((float)lng, (float)lat);
            }
            if (glbllm.maps.xmap == null)
            {
                Debug.LogError($"CoordMapMan.glbllm.maps.xmap is null");
                return ((float)lng, (float)lat);
            }
            if (glbllm.maps.zmap == null)
            {
                Debug.LogError($"CoordMapMan.glbllm.maps.zmap is null");
                return ((float)lng, (float)lat);
            }
            var x = (float)glbllm.maps.xmap.Map(lng, lat);
            var z = (float)glbllm.maps.zmap.Map(lng, lat);
            return (x, z);
        }

        public (double lat, double lng) xztoll(float x, float z)
        {
            if (glbllm == null)
            {
                Debug.LogError($"CoordMapMan.glbllm is null");
                return (x,z);
            }
            if (glbllm.maps == null)
            {
                Debug.LogError($"CoordMapMan.glbllm.mapps is null");
                return (x, z);
            }
            if (glbllm.maps.xmap == null)
            {
                Debug.LogError($"CoordMapMan.glbllm.maps.xmap is null");
                return (x, z);
            }
            if (glbllm.maps.zmap == null)
            {
                Debug.LogError($"CoordMapMan.glbllm.maps.zmap is null");
                return (x, z);
            }
            var lat = (float)glbllm.maps.latmap.Map(x,z);
            var lng = (float)glbllm.maps.lngmap.Map(x,z);
            return (lat,lng);
        }

        public void DeleteStuff()
        {
        }


        public void InitializeValues()
        {
            showCoords = false;
            oldShowCoords = false;
            sphereScale = 1;
            oldSphereScale = 1;
        }

        public void BaseInitialize(SceneSelE newregion)
        {
            Debug.Log($"DataFileMan.InitializeScene {newregion}");
            InitializeValues();
            curscene = newregion;
            InitializeGlbLlMap();
        }


        GameObject coordMakersGo = null;

        public void Destruct()
        {
            if (coordMakersGo!=null)
            {
                Destroy(coordMakersGo);
                coordMakersGo = null;
            }
        }
        public float sphereScale = 1;
        public void Construct()
        {
            //            var ska = glbllm.llbox.diagonalInMeters / 250;
            var ska = sphereScale;
            coordMakersGo = glbllm.mapcoord.MakeNativeCoordMarkers(ska: ska, clr: "yellow", wps: true);
            coordMakersGo.transform.parent = this.transform;
        }

        float oldSphereScale = 1;
        bool oldShowCoords = false;

        // Update is called once per frame
        void Update()
        {
            if (oldShowCoords!=showCoords || oldSphereScale!=sphereScale)
            {
                if (showCoords)
                {
                    Construct();
                }
                else
                {
                    Destruct();
                }
                oldShowCoords = showCoords;
            }

        }
    }
}