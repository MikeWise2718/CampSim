﻿using System;
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
            var shader = Shader.Find("Diffuse");
            rend.material = new Material(shader);
            rend.material.enableInstancing = true;
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

        static MaterialPropertyBlock props = new MaterialPropertyBlock();
        static public Transform Instanciate(PrimitiveType ptype, string clr)
        {
            var sharedgo = GetShared(ptype, clr);
            Transform tform = UnityEngine.Object.Instantiate<Transform>(sharedgo.transform);
            var cclr = qut.GetColorByName(clr, alpha: 1);
            props.SetColor("_Color", cclr);

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
            Transform tform = Instanciate(ptype, clr);
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
            cgo.transform.parent = pargo?.transform;
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