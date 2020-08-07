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

        public void DeleteStuff()
        {
        }


        public void InitializeValues()
        {
        }

        public void BaseInitialize(SceneSelE newregion)
        {
            Debug.Log($"DataFileMan.InitializeScene {newregion}");
            InitializeValues();
            curscene = newregion;
            InitializeGlbLlMap();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}