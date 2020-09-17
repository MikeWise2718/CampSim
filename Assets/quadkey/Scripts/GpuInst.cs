using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Aiskwk.Map
{
    public static class GpuInst
    {
        public static void SetColorNewMat(GameObject go, Color cclr)
        {
            var rend = go.GetComponent<Renderer>();
            var shader = Shader.Find("Standard");
            rend.material = new Material(shader);
            rend.material.enableInstancing = true;
            rend.material.color = cclr;
        }

        public static void SetColorNewMatTransparent(GameObject go, Color cclr)
        {
            var rend = go.GetComponent<Renderer>();
            var shader = Shader.Find("Standard");
            rend.material = new Material(shader);
            rend.material.enableInstancing = true;
            rend.material.SetColor("_Color", cclr);
            rend.material.SetFloat("_Mode", 2);
            rend.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            rend.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            rend.material.SetInt("_ZWrite", 0);
            rend.material.DisableKeyword("_ALPHATEST_ON");
            rend.material.EnableKeyword("_ALPHABLEND_ON");
            rend.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            rend.material.renderQueue = 3000;
            rend.material.color = cclr;
        }

        static GameObject gpuInstancing = null;
        static void AddToGpuInstances(GameObject newobj)
        {
            if (gpuInstancing == null)
            {
                gpuInstancing = new GameObject("GpuInstancing");
            }
            newobj.transform.parent = gpuInstancing.transform;
            gpuInstancing.SetActive(false);// to hide it
        }

        public class DictStringGameOject : Dictionary<string, GameObject> { }
        public class PrimDictMan
        {
            Dictionary<PrimitiveType, DictStringGameOject> pdict = new Dictionary<PrimitiveType, DictStringGameOject>();
            public PrimDictMan()
            {
                pdict.Add(PrimitiveType.Capsule, new DictStringGameOject());
                pdict.Add(PrimitiveType.Cylinder, new DictStringGameOject());
                pdict.Add(PrimitiveType.Cube, new DictStringGameOject());
                pdict.Add(PrimitiveType.Sphere, new DictStringGameOject());
                pdict.Add(PrimitiveType.Plane, new DictStringGameOject());
                pdict.Add(PrimitiveType.Quad, new DictStringGameOject());
            }
            public DictStringGameOject GetDict(PrimitiveType ptype)
            {
                return pdict[ptype];
            }
        }
        static PrimDictMan pdictman = new PrimDictMan();

        // Sphere

        static public GameObject GetShared(PrimitiveType ptype, string clr)
        {
            var pdict = pdictman.GetDict(ptype);
            var dictkey = "noclr";
            if (!pdict.ContainsKey(dictkey))
            {
                var sphgo = GameObject.CreatePrimitive(ptype);
                sphgo.name = $"Shared{ptype}-{dictkey}";
                AddToGpuInstances(sphgo);
                //var cclr = qut.GetColorByName(clr, alpha: 1);
                //SetColorNewMat(sphgo, cclr);
                pdict[dictkey] = sphgo;
                //           Debug.Log($"Created shared {ptype} of color {clr}  cclr:{cclr} pdict.Count:{pdict.Count}");
            }
            return pdict[dictkey];
        }

        static public GameObject GetSharedTransparent(PrimitiveType ptype, string clr)
        {
            var pdict = pdictman.GetDict(ptype);
            var dictkey = "noclr";
            if (!pdict.ContainsKey(dictkey))
            {
                var sphgo = GameObject.CreatePrimitive(ptype);
                sphgo.name = $"SharedTransparent{ptype}-{dictkey}";
                AddToGpuInstances(sphgo);
                var cclr = qut.GetColorByName(clr, alpha: 1);
                SetColorNewMatTransparent(sphgo, cclr);
                pdict[dictkey] = sphgo;
            }
            return pdict[dictkey];
        }

        static public GameObject GetShared(PrimitiveType ptype, string clr, float alpha)
        {
            var pdict = pdictman.GetDict(ptype);
            var dictkey = "noclr";
            if (!pdict.ContainsKey(dictkey))
            {
                var sphgo = GameObject.CreatePrimitive(ptype);
                sphgo.name = $"Shared{ptype}-{dictkey}";
                AddToGpuInstances(sphgo);
                //var cclr = qut.GetColorByName(clr, alpha: 1);
                //SetColorNewMat(sphgo, cclr);
                pdict[dictkey] = sphgo;
                //           Debug.Log($"Created shared {ptype} of color {clr}  cclr:{cclr} pdict.Count:{pdict.Count}");
            }
            return pdict[dictkey];
        }


        static MaterialPropertyBlock props = new MaterialPropertyBlock();
        static public Transform Instantiate(PrimitiveType ptype, string clr)
        {
            var sharedgo = GetShared(ptype, clr);
            Transform tform = UnityEngine.Object.Instantiate<Transform>(sharedgo.transform);
            var cclr = qut.GetColorByName(clr, alpha: 1);
            props.SetColor("_Color", cclr);

            var renderer = tform.GetComponent<MeshRenderer>();
            renderer.SetPropertyBlock(props);
            //renderer.material.shader = Shader.Find("transparent/diffuse");
            return tform;
        }

        static public Transform Instantiate(PrimitiveType ptype, string clr, float alpha)
        {
            GameObject sharedgo;
            if (alpha < 1)
            {
                sharedgo = GetSharedTransparent(ptype, clr);
            }
            else
            {
                sharedgo = GetShared(ptype, clr);
            }
            Transform tform = UnityEngine.Object.Instantiate<Transform>(sharedgo.transform);
            var cclr = qut.GetColorByName(clr, alpha: alpha);
            props.SetColor("_Color", cclr);
            //if (alpha < 1)
            //{
            //    //https://forum.unity.com/threads/access-rendering-mode-var-on-standard-shader-via-scripting.287002/
            //    //https://forum.unity.com/threads/standard-material-shader-ignoring-setfloat-property-_mode.344557/
            //    //https://forum.unity.com/threads/solved-materialpropertyblock-not-setting-blend-modes.628426/
            //    props.SetFloat("_Mode", 2);
            //    props.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            //    props.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            //    props.SetInt("_ZWrite", 0);
            //    //props.DisableKeyword("_ALPHATEST_ON");
            //    //props.EnableKeyword("_ALPHABLEND_ON");
            //    //props.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            //    //props.renderQueue = 3000;
            //}
            //else
            //{
            //    props.SetFloat("_Mode", 0);
            //}

            var renderer = tform.GetComponent<MeshRenderer>();
            renderer.SetPropertyBlock(props);
            return tform;
        }

        //static public GameObject GetSharedOld(PrimitiveType ptype, string clr)
        //{
        //    var pdict = pdictman.GetDict(ptype);
        //    var dictkey = clr;
        //    if (!pdict.ContainsKey(dictkey))
        //    {
        //        var sphgo = GameObject.CreatePrimitive(ptype);
        //        sphgo.name = $"Shared{ptype}-{dictkey}";
        //        AddToGpuInstances(sphgo);
        //        var cclr = qut.GetColorByName(clr, alpha: 1);
        //        SetColorNewMat(sphgo, cclr);
        //        pdict[dictkey] = sphgo;
        //        //           Debug.Log($"Created shared {ptype} of color {clr}  cclr:{cclr} pdict.Count:{pdict.Count}");
        //    }
        //    return pdict[dictkey];
        //}

        //static public Transform InstanciateOld(PrimitiveType ptype, string clr)
        //{
        //    var sharedgo = GetShared(ptype, clr);
        //    Transform tform = UnityEngine.Object.Instantiate<Transform>(sharedgo.transform);
        //    return tform;
        //}

        public static Transform CreateTform(PrimitiveType ptype, string name, Vector3 pt, Vector3 sz, string clr = "blue", float alf = 1, float rotx = 0, float roty = 0, float rotz = 0)
        {
            Transform tform = Instantiate(ptype, clr, alf);
            if (tform == null)
            {
                var sph = GameObject.CreatePrimitive(ptype);
                var clder = sph.GetComponent<Collider>();
                if (clder != null)
                {
                    clder.enabled = false;
                }
                var cclr = qut.GetColorByName(clr, alf);
                qut.SetColorOfGo(sph, cclr);
                tform = sph.transform;
            }
            tform.name = name;
            tform.transform.localScale = new Vector3(sz.x, sz.y, sz.z);
            tform.Rotate(rotx, roty, rotz);
            tform.transform.localPosition = pt;

            return tform;
        }

        public static GameObject CreateSphereGpu(string name, Vector3 pt, float size = 0.2f, string clr = "blue", float alf = 1)
        {
            var sz = new Vector3(size, size, size);
            var tform = CreateTform(PrimitiveType.Sphere, name, pt, sz, clr, alf);
            return tform.gameObject;
        }
        public static GameObject CreateCubeGpu(string name, Vector3 pt, float size = 0.2f, string clr = "blue", float alf = 1)
        {
            var sz = new Vector3(size, size, size);
            var tform = CreateTform(PrimitiveType.Cube, name, pt, sz, clr, alf);
            return tform.gameObject;
        }
        public static GameObject CreateCubeGpu(string name, Vector3 pt, Vector3 size, string clr = "blue", float alf = 1)
        {
            var tform = CreateTform(PrimitiveType.Cube, name, pt, size, clr, alf);
            return tform.gameObject;
        }


        // Cylinder
        public static GameObject CreateCylinderGpu(GameObject pargo, string name, Vector3 frpt, Vector3 topt, float size = 0.1f, string clr = "yellow", float alf = 1, float widratio = 1)
        {
            var cgo = CreateCylinderGpu(name, frpt, topt, size, clr, alf, widratio);
            if (pargo != null)
            {
                cgo.transform.parent = pargo.transform;
            }
            return cgo;
        }
        public static GameObject CreateCylinderGpu(string name, Vector3 frpt, Vector3 topt, float size = 0.1f, string clr = "yellow", float alf = 1, float widratio = 1)
        {
            var dst_div_2 = Vector3.Distance(frpt, topt) / 2;
            var dlt = topt - frpt;
            var dltxz = Mathf.Sqrt(dlt.x * dlt.x + dlt.z * dlt.z);
            var anglng = 180 * Mathf.Atan2(dltxz, dlt.y) / Mathf.PI;
            var anglat = 180 * Mathf.Atan2(dlt.x, dlt.z) / Mathf.PI;
            var pt = frpt + 0.5f * dlt;
            var sz = new Vector3(widratio * size, dst_div_2, size);

            var tform = CreateTform(PrimitiveType.Cylinder, name, pt, sz, clr, alf, anglng, anglat, 0);
            return tform.gameObject;
        }
        public static GameObject CreateCubeCylGpu(string name, Vector3 frpt, Vector3 topt, float size = 0.1f, string clr = "yellow", float alf = 1, float widratio = 1)
        {
            var dst_div_2 = Vector3.Distance(frpt, topt) / 2;
            var dlt = topt - frpt;
            var dltxz = Mathf.Sqrt(dlt.x * dlt.x + dlt.z * dlt.z);
            var anglng = 180 * Mathf.Atan2(dltxz, dlt.y) / Mathf.PI;
            var anglat = 180 * Mathf.Atan2(dlt.x, dlt.z) / Mathf.PI;
            var pt = frpt + 0.5f * dlt;
            var sz = new Vector3(widratio * size, dst_div_2, size);

            var tform = CreateTform(PrimitiveType.Cube, name, pt, sz, clr, alf, anglng, anglat, 0);
            return tform.gameObject;
        }

        public static GameObject CreateCapsuleGpu(string name, Vector3 frpt, Vector3 topt, float size = 0.1f, string clr = "yellow", float alf = 1)
        {
            var dst_div_2 = Vector3.Distance(frpt, topt) / 2;
            var dlt = topt - frpt;
            var dltxz = Mathf.Sqrt(dlt.x * dlt.x + dlt.z * dlt.z);
            var anglng = 180 * Mathf.Atan2(dltxz, dlt.y) / Mathf.PI;
            var anglat = 180 * Mathf.Atan2(dlt.x, dlt.z) / Mathf.PI;
            var pt = frpt + 0.5f * dlt;
            var sz = new Vector3(size, dst_div_2, size);

            var tform = CreateTform(PrimitiveType.Capsule, name, pt, sz, clr, alf, anglng, anglat, 0);
            return tform.gameObject;
        }


    }

}