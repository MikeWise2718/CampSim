using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CampusSimulator
{
    public class SpatialMapperMan : MonoBehaviour
    {

        // Use this for initialization
        //void Start()
        //{

        //}
        GameObject smgo = null;
        GameObject GetSpatialMapper()
        {
            if (smgo != null) return smgo;
            smgo = GameObject.Find("Spatial Mapping");
            if (smgo == null)
            {
                SceneMan.Log("Could not find SpatialMapper GameObject");
                return null;
            }
            SceneMan.Log("Found SpatialMapper GameObject");
            Debug.Log("Found SpatialMapper GameObject");
            return smgo;
        }
        public void SetSpatialMapping(bool onoff)
        {
            var smgo = GetSpatialMapper();
            if (smgo == null) return;
            // var sm = smgo.GetComponent<SpatialMapping>();
            SceneMan.Log("Found Spatial Mapping Component");
            Debug.Log("Found Spatial Mapping Component");
            //  sm.MappingEnabled = onoff;
            //  sm.DrawVisualMeshes = onoff;
            SceneMan.Log("Spatial Mapping " + onoff);
            Debug.Log("Spatial Mapping " + onoff);
        }
#if USE_SPATIALMAPPER
        public void ChangeSpatialExtent(float val)
        {
            var smgo = GetSpatialMapper();
            var smr = smgo.GetComponent<UnityEngine.XR.WSA.SpatialMappingRenderer>();

            var hbe = smr.halfBoxExtents;
            var newhbe = hbe + new Vector3(val, val, val);
            smr.halfBoxExtents = newhbe;
            RegionMan.Log("Spatial Mapping halfBoxExtents set to :" + newhbe);
            Debug.Log("Spatial Mapping halfBoxExtents set to :" + newhbe);
        }

        public UnityEngine.XR.WSA.SpatialMappingBase.LODType NextLodVal(UnityEngine.XR.WSA.SpatialMappingBase.LODType oldlod, int incval)
        {
            var newlodp1 = oldlod;
            var newlodm1 = oldlod;
            switch (oldlod)
            {
                case UnityEngine.XR.WSA.SpatialMappingBase.LODType.High:
                    {
                        newlodm1 = UnityEngine.XR.WSA.SpatialMappingBase.LODType.Medium;
                        break;
                    }
                case UnityEngine.XR.WSA.SpatialMappingBase.LODType.Medium:
                    {
                        newlodp1 = UnityEngine.XR.WSA.SpatialMappingBase.LODType.High;
                        newlodm1 = UnityEngine.XR.WSA.SpatialMappingBase.LODType.Low;
                        break;
                    }
                case UnityEngine.XR.WSA.SpatialMappingBase.LODType.Low:
                    {
                        newlodp1 = UnityEngine.XR.WSA.SpatialMappingBase.LODType.Medium;
                        break;
                    }
            }

            var newlod = (incval < 0 ? newlodm1 : newlodp1);
            return newlod;
        }
        public void ChangeSpatialDetail(int val)
        {
            var smgo = GetSpatialMapper();
            var smr = smgo.GetComponent<UnityEngine.XR.WSA.SpatialMappingRenderer>();

            var lod = smr.lodType;
            var newlod = NextLodVal(lod, val);
            smr.lodType = newlod;
            RegionMan.Log("Spatial Mapping Lod Changed old:" + lod + "  new:" + newlod);
            Debug.Log("Spatial Mapping Lod Changed old:" + lod + "  new:" + newlod);
        }
#else
        public void ChangeSpatialExtent(float val)
        {
        }
        public void ChangeSpatialDetail(int val)
        {
        }
#endif
        // Update is called once per frame
        //void Update()
        //{

        //}
    }
}