using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;
using System.Reflection;

/// <summary>
/// GraphAlgos.cs  - This file contains static algoritms that we need in various places. 
/// </summary>




[System.Serializable]
public struct LegVector3d
{
    public double x;
    public double y;
    public double z;
    public LegVector3d(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

[System.Serializable]
public struct LegVector2d
{
    public double x;
    public double y;
    public LegVector2d(double x, double y)
    {
        this.x = x;
        this.y = y;
    }
}


namespace GraphAlgos
{
    public static class glt
    {
        public static DateTime GetLinkerTime(this Assembly assembly, TimeZoneInfo target = null)
        {
            var filePath = assembly.Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;

            var buffer = new byte[2048];

            //            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            //                stream.Read(buffer, 0, 2048);
            using (var stream = new FileStream(filePath, FileMode.Open))
                stream.Read(buffer, 0, 2048);

            var offset = BitConverter.ToInt32(buffer, c_PeHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(buffer, offset + c_LinkerTimestampOffset);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var linkTimeUtc = epoch.AddSeconds(secondsSince1970);

            var tz = target ?? TimeZoneInfo.Local;
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(linkTimeUtc, tz);

            return localTime;
        }
    }


    public class GraphUtil
    {
        static Dictionary<string, GameObject> uniresdict = new Dictionary<string, GameObject>();
        public static GameObject GetUniResPrefab(string dname,string name)
        {
            if (!uniresdict.ContainsKey(name))
            {
                var realname = name;
                if (dname != "")
                {
                    if (!dname.EndsWith("/")) dname += "/";
                    realname = dname + name;
                }
                var go = Resources.Load<GameObject>(realname);
                var clder = go.GetComponent<Collider>();
                if (clder!=null)
                {
                    clder.enabled = false;
                }
                var rigid = go.GetComponent<Rigidbody>();
                if (rigid != null)
                {
                    rigid.isKinematic = true;
                }

                uniresdict[name] = go;
            }
            return uniresdict[name];
        }

        //static System.Random ranman = new System.Random(1234);
        static Dictionary<string, int> ranseedset = new Dictionary<string, int>()
        {
            { "popbld",1234 },
            { "jnygen",1234 },
        };
        static Dictionary<string, System.Random> ransetdict = new Dictionary<string, System.Random>();
        static System.Random GetRanMan(string ranset)
        {
            if (!ransetdict.ContainsKey(ranset))
            {
                if (!ranseedset.ContainsKey(ranset))
                {
                    ranseedset[ranset] = 1234;
                }
                ransetdict[ranset] = new System.Random(ranseedset[ranset]);
            }
            return ransetdict[ranset];
        }
        public static string GetRanListEntry(string[] list,string ranset="")
        {
            var ranman = GetRanMan(ranset);
            var i = ranman.Next(list.Length);
            return list[i];
        }
        public static string GetRanListEntry(string[] list, float[] weights, string ranset = "")
        {
            if (list.Length!=weights.Length)
            {
                Debug.Log("Lists of unequal length - probably a mistake");
            }
            var wsum = weights.Sum();
            var f = GetRanFloat(0,wsum);
            var runsum = weights[0];
            for(int i=0; i<weights.Length; i++)
            {
                if (f < runsum) return list[i];
                if (i==weights.Length-1) return list[i];
                runsum += weights[i + 1];
            }
            // can't get here
            return list[0];
        }
        public static bool FlipBiasedCoin(float coinbias=0.5f, string ranset = "")
        {
            // FlipBiasedCoin of 0.1 returns true 10 percent of the time
            var maxi = 1000000;// a million
            var ranman = GetRanMan(ranset);
            var i = ranman.Next(maxi);
            var threshold = maxi * coinbias;
            return (i < threshold);
        }
        public static int GetRanInt(int maxint, string ranset = "")
        {
            var ranman = GetRanMan(ranset);
            return ranman.Next(maxint);
        }
        public static bool FlipCoin( string ranset = "")
        {
            return FlipBiasedCoin();
        }
        public static float GetRanFloat(float fmin=0,float fmax=1, string ranset = "")
        {
            var maxi = 1000000;// a million
            var ranman = GetRanMan(ranset);
            var i = ranman.Next(maxi);
            var rv = fmin + (i*(fmax-fmin)/maxi);
            return rv;
        }
        static string colornames = "red,pink,darkorange,orange,lightorange,brown,saddlebrown,darkbrown,olive,darkgreen,forestgreen,seagreen,limegreen,darkblue,navyblue,steelblue," +
                                   "blue,green,magenta,lilac,purple,yellow,lightyellow,cyan,black,white,clear,silver,lightgray,lightgrey,gray,grey,dirtyred,darkred"+
                                   "crimsom,firebrick,deeppurple,violet,darkpurple,muave,phlox,lilac";
        public static bool iscolorname(string name)
        {
            return (colornames.IndexOf(name) >= 0);
        }
        public static Color rgbbyte(int r, int g, int b, float alpha = 1)
        {
            return new Color(r / 255f, g / 255f, b / 255f, alpha);
        }
        public static Color getcolorbyname(string name, float alpha = 0.4f)
        {
            // this is a hack that voids a wierd error message about constants not being available
            switch (name)
            {
                case "red": return (new Color(1, 0, 0, alpha));
                case "crimsom": return rgbbyte(220, 20, 60, alpha);
                case "firebrick": return rgbbyte(178, 34, 34, alpha);
                case "darkred": return rgbbyte(139, 0, 0, alpha);
                case "dirtyred": return rgbbyte(117, 10, 10, alpha);
                case "pink": return (new Color(1, 0.412f, 0.71f, alpha));
                case "scarlet": return (new Color(1, 0.14f, 0.0f, alpha));
                case "orange": return (new Color(1, 0.5f, 0, alpha));
                case "lightorange": return (new Color(1, 0.75f, 0, alpha));
                case "darkorange": return (new Color(0.75f, 0.25f, 0, alpha));
                case "brown": return (new Color(0.647f, 0.164f, 0.164f, alpha));
                case "saddlebrown": return (new Color(0.545f, 0.271f, 0.075f, alpha));
                case "darkbrown": return (new Color(0.396f, 0.263f, 0.129f, alpha));
                case "olive": return (new Color(0.5f, 0.5f, 0f, alpha));
                case "darkgreen1": return (new Color(0.004f, 0.196f, 0.125f, alpha));
                case "darkgreen": return (new Color(0.012f, 0.296f, 0.225f, alpha));
                case "forestgreen": return (new Color(0.132f, 0.543f, 0.132f, alpha));
                case "seagreen": return (new Color(0.33f, 1.0f, 0.62f, alpha));
                case "limegreen": return (new Color(0.195f, 0.8f, 0.195f, alpha));
                case "steelblue": return (new Color(0.27f, 0.51f, 0.71f, alpha));
                case "lightblue": return rgbbyte(173,216,230);
                case "darkblue": return new Color(0.0f, 0.0f, 0.500f);
                case "navyblue": return new Color(0.0f, 0.0f, 0.398f);
                case "blue": return (new Color(0, 0, 1, alpha));
                case "green": return (new Color(0, 1, 0, alpha));
                case "magenta": return (new Color(1, 0, 1, alpha));
                case "violet": return (new Color(0.75f, 0, 0.75f, alpha));
                case "purple": return (new Color(0.5f, 0, 0.5f, alpha));
                case "deeppurple":return (new Color(0.4f, 0, 0.4f, alpha));
                case "darkpurple": return rgbbyte(48, 25, 52);
                case "phlox": return rgbbyte(223, 0, 255);
                case "mauve": return rgbbyte(224,176, 255);
                case "lilac": return new Color(0.86f, 0.8130f, 1.0f, alpha);
                case "lightyellow": return (new Color(1, 1, 0.5f, alpha));
                case "yellow": return (new Color(1, 1, 0, alpha));
                case "cyan": return (new Color(0, 1, 1, alpha));
                case "black": return (new Color(0, 0, 0, alpha));
                case "white": return (new Color(1, 1, 1, alpha));
                case "chinawhite": return new Color(0.937f, 0.910f, 0.878f, alpha);
                case "clear": return Color.clear;
                case "silver": return rgbbyte(192, 192, 192, alpha);
                case "lightgrey":
                case "lightgray": return rgbbyte(211, 211, 211, alpha);
                case "slategray":
                case "slategrey": return rgbbyte(112, 128, 144, alpha);
                case "darkslategray":
                case "darkslategrey": return rgbbyte(74, 85, 83, alpha);
                case "darkgray":
                case "darkgrey":
                case "dimgray":
                case "dimgrey": return rgbbyte(105, 105, 105, alpha);
                case "grey":
                case "gray":
                default:
                    return (new Color(128, 128, 128, alpha));
            }
        }
        static Shader transShader = null;
        public static void SetColorOfGo(GameObject go, Color cclr)
        {
            var mat = go.GetComponent<Renderer>().material;
            //            var matrend = pcyl.GetComponent<Renderer>();
            if (cclr.a < 1f)
            {
                if (transShader == null)
                {
                    transShader = Shader.Find("Transparent/Diffuse");
                }
                if (transShader != null)
                {
                    mat.shader = transShader;
                }
            }
            mat.SetColor("_Color", cclr);
        }
        public static void SetColorOfGo(GameObject go, string clrname,float alf=1.0f)
        {
            SetColorOfGo(go, getcolorbyname(clrname,alf));
        }
        public static GameObject CreateMarkerSphere(string name, Vector3 pt, float size = 0.2f, string clr = "blue", float alf = 1)
        {
            var sph = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            var cclr = getcolorbyname(clr, alf);
            SetColorOfGo(sph, cclr);
            sph.name = name;
            sph.transform.localScale = new Vector3(size, size, size);
            sph.transform.localPosition = pt;
            var clder = sph.GetComponent<Collider>();
            if (clder != null)
            {
                clder.enabled = false;
            }
            return (sph);
        }
        public static GameObject CreateMarkerCube(string name, Vector3 pt, float size = 0.2f, string clr = "blue", float alf = 1)
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var cclr = getcolorbyname(clr, alf);
            SetColorOfGo(cube, cclr);
            cube.name = name;
            cube.transform.localScale = new Vector3(size, size, size);
            cube.transform.localPosition = pt;
            var clder = cube.GetComponent<Collider>();
            if (clder != null)
            {
                clder.enabled = false;
            }
            return (cube);
        }


        public static GameObject CreatePipe(string pname, Vector3 frpt, Vector3 topt, float size = 0.1f, string clr = "yellow", float alf = 1)
        {
            var dst_div_2 = Vector3.Distance(frpt, topt) / 2;
            var dlt = topt - frpt;
            var dltxz = Mathf.Sqrt(dlt.x * dlt.x + dlt.z * dlt.z);
            var anglng = 180 * Mathf.Atan2(dltxz, dlt.y) / Mathf.PI;
            var anglat = 180 * Mathf.Atan2(dlt.x, dlt.z) / Mathf.PI;

            var pcyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            pcyl.name = pname;
            var cclr = getcolorbyname(clr, alf);
            SetColorOfGo(pcyl, cclr);
            pcyl.transform.localScale = new Vector3(size, dst_div_2, size);
            pcyl.transform.Rotate(anglng, anglat, 0);
            pcyl.transform.localPosition = frpt + 0.5f * dlt;
            var clder = pcyl.GetComponent<Collider>();
            if (clder != null)
            {
                clder.enabled = false;
            }
            //UnityEngine.Object.Destroy(clder);
            return (pcyl);
        }

        //public static GameObject CreateLine(string pname, Vector3 frpt, Vector3 topt, float size = 0.1f, string clr = "yellow", float alf = 1)
        //{
        //    // need to create a gameobject, store these values, and call Debug.DrawLine on render
        //    var cclr = getcolorbyname(clr, alf);
        //    Debug.DrawLine(frpt, topt, cclr);
        //}

        public static GameObject CreateFlatPipe(string pname, Vector3 frpt, Vector3 topt, float size = 0.1f, string clr = "yellow", float alf = 1)
        {
            var dist_div_2 = Vector3.Distance(frpt, topt) / 2;
            var dlt = topt - frpt;
            var dltxz = Mathf.Sqrt(dlt.x * dlt.x + dlt.z * dlt.z);
            var anglng = 180 * Mathf.Atan2(dltxz, dlt.y) / Mathf.PI;
            var anglat = 180 * Mathf.Atan2(dlt.x, dlt.z) / Mathf.PI;
            var go = new GameObject();
            var lr = go.AddComponent<LineRenderer>();
            lr.SetPosition(0, frpt);
            lr.SetPosition(1, topt);
            lr.startWidth = 0.1f;
            lr.endWidth = 0.1f;
            var cclr = getcolorbyname(clr, alf);
            SetColorOfGo(go, cclr);
            go.transform.localScale = new Vector3(size, dist_div_2, size);
            go.transform.Rotate(anglng, anglat, 0);
            go.transform.localPosition = frpt + 0.5f * dlt;

            return (go);
        }
        public static string LeadZeroFloat(float f,int nleft,int nright)
        {
            var rv = f.ToString("F" + nright);
            var lzs = (nleft + 1 + nright) - rv.Length;
            if (lzs > 0)
            {
                rv = new string('0', lzs) + rv;
            }
            return rv;
        }
        public static float GetAngLatDegrees(Vector3 frpt, Vector3 topt)
        {
            var dlt = topt - frpt;
            var anglat = 180 * Mathf.Atan2(dlt.x, dlt.z) / Mathf.PI;
            return (anglat);
        }
        public static float GetAngLngDegrees(Vector3 frpt, Vector3 topt)
        {
            var dlt = topt - frpt;
            var dltxz = Mathf.Sqrt(dlt.x * dlt.x + dlt.z * dlt.z);
            var anglng = 180 * Mathf.Atan2(dltxz, dlt.y) / Mathf.PI;
            return (anglng);
        }
        public enum FltTextImplE {TextMesh, GUIText, TextPro};
        public static FltTextImplE fltTextImpl = FltTextImplE.TextPro;
        public static void addFloatingTextStatic(GameObject go, Vector3 pt, string text, string colorname, float yrot = 0, float yoff = 0)
        {
            switch (fltTextImpl)
            {
                default:
                case FltTextImplE.TextMesh:
                    {
                        var tm = go.AddComponent<TextMesh>();
                        int linecount = text.Split('\n').Length;
                        tm.text = text;
                        tm.fontSize = 12;
                        tm.anchor = TextAnchor.UpperCenter;
                        float sfak = 0.1f;
                        tm.transform.localScale = new Vector3(sfak, sfak, sfak);
                        tm.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
                        //tm.transform.Rotate(0, yrot, 0);
                        tm.transform.localPosition = pt + new Vector3(0, sfak * yoff + linecount * 0.25f, 0);
                        tm.transform.parent = go.transform;
                        tm.color = GraphUtil.getcolorbyname(colorname);
                        break;
                    }
                case FltTextImplE.GUIText:
                    {
                        Vector2 worldPoint = Camera.main.WorldToScreenPoint(go.transform.position);
                        GUI.Label(new Rect(worldPoint.x - 100, (Screen.height - worldPoint.y) - 50, 200, 100), text);
                        break;
                    }
                case FltTextImplE.TextPro:
                    {
                        var tm = go.AddComponent<TMPro.TextMeshPro>();
                        int linecount = text.Split('\n').Length;
                        //tm.text = "<mark=#000000>"+text+"</mark>"; // this only works with an alpha of less than 1
                        tm.text = text;
                        tm.fontSize = 12;
                        tm.alignment = TMPro.TextAlignmentOptions.Center;
                        float sfak = 0.1f;
                        tm.transform.localScale = new Vector3(sfak, sfak, sfak);
                        //var fwd = Camera.main.transform.forward;
                        //fwd.y = 0.0f;
                        //tm.transform.rotation = Quaternion.LookRotation(fwd);
                        tm.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
                        //tm.transform.Rotate(0, yrot, 0);
                        tm.transform.localPosition = pt + new Vector3(0, sfak * yoff + linecount * 0.25f, 0);
                        tm.transform.parent = go.transform;
                        tm.color = GraphUtil.getcolorbyname(colorname);
                        tm.alpha = 1.0f; // this has to stay at the end or it gets overwritten !!
                        break;
                    }
            }
        }
        public static double FindClosestLambClampedTo01(Vector3 pt, Vector3 p1, Vector3 p2)
        {
            //CreateMarkerSphere("pt", pt, 1, "red");
            //CreateMarkerSphere("p1", p1, 1, "green");
            //CreateMarkerSphere("p2", p2, 1, "blue");
            //Debug.Log("pt(red):"+pt+" p1(green):"+p1+" p2(blue):"+p2);
            var lamb = FindClosestLambUnclamped(pt, p1, p2);
            var clamb = Math.Min(1, Math.Max(0, lamb));
            //Debug.Log("lamb:" + lamb + " clamb:" + clamb);
            return (clamb);
        }
        public static double FindClosestLambUnclamped(Vector3 pt, Vector3 p1, Vector3 p2)
        {
            var dlt = p2 - p1;
            var ndlt = Vector3.Normalize(dlt);
            var vp = pt - p1;
            var lamb = (double)Vector3.Dot(vp, ndlt)/(double)Vector3.Magnitude(dlt);
            //Debug.Log("dlt(p2-p1):"+dlt.ToString("f4")+" vp(pt-p1):"+vp+" lamb(dot):"+lamb);
            //Debug.Log("mag(dlt):" + Vector3.Magnitude(dlt) + "  mag(ndlt):"+Vector3.Magnitude(ndlt));
            //var lamb = Vector3.Dot(vp, dlt) / (dlt.x * dlt.x + dlt.y * dlt.y + dlt.z * dlt.z);
            return (lamb);
        }
        public static float FindClosestLambUnclampedOld(Vector3 pt, Vector3 p1, Vector3 p2)
        {
            var dlt = p2 - p1;
            var vp = pt - p1;
            //var lamb = Vector3.Dot(vp, dlt) / Mathf.Sqrt(dlt.x * dlt.x + dlt.y * dlt.y + dlt.z * dlt.z);
            var lamb = Vector3.Dot(vp, dlt) / (dlt.x * dlt.x + dlt.y * dlt.y + dlt.z * dlt.z);
            return (lamb);
        }
        public static LinkedList<string> loglist = null;
        public static void Log(string msg)
        {
            if (loglist != null)
            {
                loglist.AddFirst(msg);
            }
            else
            {
                Debug.Log(msg);
            }
        }
        static System.Random rangen = new System.Random();
        public static float NextFloat(float minf = 0, float maxf = 1)
        {
            var diff = maxf - minf;
            var nxf = (float)rangen.NextDouble();
            var rv = diff * nxf + minf;
            return (rv);
        }
        public static void writeListToFile(List<string> llist, string filename)
        {
            string[] llar = llist.ToArray<string>();
            System.IO.File.WriteAllLines(filename, llar);
        }
        public static string Clipboard
        {
            get { return GUIUtility.systemCopyBuffer; }
            set { GUIUtility.systemCopyBuffer = value; }
        }
        public static void AddToClipboard( string line )
        {
            var inclip = Clipboard;
            if (inclip.Length > 0)
            {
                Clipboard = inclip + "\n" + line;
            }
            else
            {
                Clipboard = line;
            }
        }
        public static Renderer FindFirstRenderer(GameObject go)
        {
            var ren = go.GetComponent<Renderer>();
            if (!ren)
            {
                var nch = go.transform.childCount;
                Transform gocht = null;
                for(var i = 0; i<nch; i++)
                {
                    gocht = go.transform.GetChild(i);
                    ren = gocht.GetComponent<Renderer>();
                    if (ren) return ren;
                }
                if (nch==1)// if there was only one child recurs
                {
                    var nchch = gocht.transform.childCount;
                    Transform gochcht = null;
                    for (var i = 0; i < nchch; i++)
                    {
                        gochcht = gocht.transform.GetChild(i);
                        ren = gochcht.GetComponent<Renderer>();
                        if (ren) return ren;
                    }
                }
                return null;
            }
            return ren;
        }
        public static bool IsInFrontOfMainCamera(GameObject go,Camera cam)
        {
            var rv = true;
            var ren = FindFirstRenderer(go);
            if (cam==null)
            {
                cam = Camera.main;
            }

            Vector3 maintogovek = ren.bounds.center - cam.transform.position;
            rv = Vector3.Dot(maintogovek, cam.transform.forward) > 0;
           
            return rv;
        }
        public static GameObject GetPart(GameObject root,string partname)
        {
            var trn = root.transform;
            var parar = partname.Split('/');
            for(var i=0; i<parar.Length; i++)
            {
                trn = trn.Find(parar[i]);
                if (!trn)
                {
                    Debug.Log("Counld not find "+partname+" in "+root.name+" failed on part:"+parar[i]+" i:"+i);
                    return null;
                }
            }
            return trn.gameObject;
        }
        public static Rect GUIRectWithObject(GameObject go,Camera cam)
        {
            var ren = FindFirstRenderer(go);
            if (!ren)
            {
                Debug.Log(go.name + " has no renderer in GraphUtil.GUIRectWithhObject");
                return new Rect();
            }
            Vector3 cen = ren.bounds.center;
            Vector3 ext = ren.bounds.extents;
            Vector2[] extentPoints = new Vector2[8]
             {
               WorldToGUIPoint(new Vector3(cen.x-ext.x, cen.y-ext.y, cen.z-ext.z),cam),
               WorldToGUIPoint(new Vector3(cen.x+ext.x, cen.y-ext.y, cen.z-ext.z),cam),
               WorldToGUIPoint(new Vector3(cen.x-ext.x, cen.y-ext.y, cen.z+ext.z),cam),
               WorldToGUIPoint(new Vector3(cen.x+ext.x, cen.y-ext.y, cen.z+ext.z),cam),
               WorldToGUIPoint(new Vector3(cen.x-ext.x, cen.y+ext.y, cen.z-ext.z),cam),
               WorldToGUIPoint(new Vector3(cen.x+ext.x, cen.y+ext.y, cen.z-ext.z),cam),
               WorldToGUIPoint(new Vector3(cen.x-ext.x, cen.y+ext.y, cen.z+ext.z),cam),
               WorldToGUIPoint(new Vector3(cen.x+ext.x, cen.y+ext.y, cen.z+ext.z),cam)
             };
            Vector2 min = extentPoints[0];
            Vector2 max = extentPoints[0];
            foreach (Vector2 v in extentPoints)
            {
                min = Vector2.Min(min, v);
                max = Vector2.Max(max, v);
            }
            return new Rect(min.x, min.y, max.x - min.x, max.y - min.y);
        }
        public static bool ClipToCameraBox(GameObject go,float clipdist=100,Camera cam=null)
        {
            var ren = FindFirstRenderer(go);
            if (!ren)
            {
                Debug.Log(go.name + " has no renderer in GraphUtil.ClipToCameraBox");
                return false;
            }
            Vector3 cen = ren.bounds.center;
            var mcam = cam;
            if (cam == null)
            {
                mcam = Camera.main;
            }
            var v1 = cen - mcam.transform.position;
            var dist = Vector3.Dot(v1, mcam.transform.forward);
            //Debug.Log(go.name + " dist to main cam " + dist);
            if (dist < 0)
            {
                 return false;
            }
            if (dist > clipdist)
            {
                return false;
            }
            return true;
        }

        public static List<string> HierarchyDescToText(GameObject go,string prefix)
        {
            var slist = new List<string>();
            var msg = prefix+go.name;
            var chiprefix = msg + "/";
            var renderer = go.GetComponent<Renderer>();
            if (renderer != null)
            {
                msg += ", m:" + renderer.material.name;
            }
            slist.Add(msg);
            var got = go.transform;
            for(var i=0; i<got.childCount; i++)
            {
                var chigo = got.GetChild(i).gameObject;
                var chislist = HierarchyDescToText(chigo,chiprefix);
                slist.AddRange(chislist);
            }
            return slist;
        }




        public static bool ClipToScreen(Rect rect)
        {
            if (rect.xMax < 0) return false;
            if (rect.yMax < 0) return false;
            if (rect.xMin > Screen.width) return false;
            if (rect.yMin > Screen.height) return false;
            if ((rect.xMax - rect.xMin) > Screen.width) return false;
            if ((rect.yMax - rect.yMin) > Screen.height) return false;
            return true;
        }

        public static Vector2 WorldToGUIPoint(Vector3 world,Camera cam=null)
        {
            if (cam==null)
            {
                cam = Camera.main;
            }
            Vector2 screenPoint = cam.WorldToScreenPoint(world); // Camera.current?
            screenPoint.y = (float)Screen.height - screenPoint.y;
            return screenPoint;
        }

        private static Texture2D _staticRectTexture;
        private static GUIStyle _staticRectStyle;

        // Note that this function is only meant to be called from OnGUI() functions.
        public static void GUIDrawRectFill(Rect position, Color color,float linwid = 1)
        {
            if (_staticRectTexture == null)
            {
                _staticRectTexture = new Texture2D(1, 1);
            }

            if (_staticRectStyle == null)
            {
                _staticRectStyle = new GUIStyle();
            }

            _staticRectTexture.SetPixel(0, 0, color);
            _staticRectTexture.Apply();
            _staticRectStyle.normal.background = _staticRectTexture;
            GUI.Box(position, GUIContent.none, _staticRectStyle);
        }


        public static void GUIDrawRectFrame(Rect position, Color color, Color textcolor, float linwid = 1, string topLabel ="",string BotLabel = "",int txsize=25)
        {
            var nrect1 = new Rect(position.xMin, position.yMin, position.width, linwid);
            GUIDrawRectFill(nrect1, color);
            var nrect2 = new Rect(position.xMin, position.yMax, position.width, linwid);
            GUIDrawRectFill(nrect2, color);
            var nrect3 = new Rect(position.xMin, position.yMin, linwid, position.height);
            GUIDrawRectFill(nrect3, color);
            var nrect4 = new Rect(position.xMax, position.yMin, linwid, position.height);
            GUIDrawRectFill(nrect4, color);
            if (topLabel!="")
            {
                var txrect = new Rect(position.xMin, position.yMin, txsize*topLabel.Length, txsize);
                var style = new GUIStyle();
                //style.fontStyle = FontStyle.Bold;
                style.fontSize = txsize;
                style.normal.textColor = textcolor;
                GUI.Label(txrect, topLabel,style);
            }
            if (BotLabel != "")
            {
                var txrect = new Rect(position.xMin, position.yMax - txsize, txsize* BotLabel.Length, txsize);
                var style = new GUIStyle();
                //style.fontStyle = FontStyle.Bold;
                style.fontSize = txsize;
                style.alignment = TextAnchor.LowerLeft;
                style.normal.textColor = textcolor;
                GUI.Label(txrect, BotLabel, style);
            }
        }


        static string _verstring = "2020.06.22.1";
        static DateTime _buildDate=DateTime.UtcNow;
        private static void getsysdata()
        {
            string sysver = "";
            if (_verstring == "")
            {
                try
                {
                    sysver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    _buildDate = Assembly.GetExecutingAssembly().GetLinkerTime();
                }
                catch(Exception ex)
                {
                    sysver = ex.Message;
                }
                //_buildDate = BuildtimeInfo.DateTimeString();
                _verstring = sysver.ToString();
            }
        }
        public static string GetVersionString()
        {
            getsysdata();
            return (_verstring);
        }
        public static bool CheckVersionString()
        {
            var ok = true;
#if UNITY_EDITOR
            var msg = "";
            var sar = _verstring.Split('.');
            while(true)
            {
                if (sar.Length < 3)
                {
                    msg = $"_verstring \"{_verstring}\" does not have enough components:{sar.Length}";
                    ok = false;
                    break;
                }
                var yyfok = int.TryParse(sar[0], out var yy);
                var mmfok = int.TryParse(sar[1], out var mm);
                var ddfok = int.TryParse(sar[2], out var dd);
                if (!yyfok || !mmfok || !ddfok)
                {
                    msg = $"_verstring \"{_verstring}\" format error - yyfok:{yyfok}  mmfok:{mmfok}  ddfok:{ddfok}";
                    ok = false;
                    break;
                }
                var yyvok = yy == DateTime.Now.Year;
                var mmvok = mm == DateTime.Now.Month;
                var ddvok = dd == DateTime.Now.Day;
                if (!yyvok || !mmvok || !ddvok)
                {
                    msg = $"_verstring \"{_verstring}\" value error - yyvok:{yyvok}  mmvok:{mmvok}  ddfok:{ddvok}";
                    ok = false;
                    break;
                }
                break;
            }
            if (!ok)
            {
                Debug.LogError(msg);
            }
#endif
            return ok;
        }
        public static string GetBuildDate()
        {
            getsysdata();
            return (_buildDate.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        public static void SaveCameraShotTimeSpan(Camera vcamera,int w,int h, string path, string name, DateTime start, bool quiet = false)
        {
            TimeSpan ts = DateTime.UtcNow - start;
            name = name + ts.TotalSeconds.ToString("f3");// this is not right... needs zero padding in front
            SaveCameraShot(vcamera,w,h, path, name, quiet);
        }
        public static void SaveCameraShot(Camera vcamera,int w,int h, string path,string name, bool adddatetime=true,bool addtimespan=false,bool quiet=false)
        {
            // https://forum.unity.com/threads/how-to-save-manually-save-a-png-of-a-camera-view.506269/
            if (!(path.EndsWith("\\") || path.EndsWith("/")))
            {
                path += "/";
            }

            System.IO.Directory.CreateDirectory(path );
            var fname = path + name +".jpg";
            if (adddatetime)
            {
                fname = path + name + DateTime.Now.ToString("yyyyMMdd-HHmmss_fff") + ".jpg";
            }

            if (!quiet)
            {
                Debug.Log("Base dir:" + System.AppDomain.CurrentDomain.BaseDirectory);
                Debug.Log("Persistent data path:" + Application.persistentDataPath);
            }
            var savett = vcamera.targetTexture;
            var rtex = new RenderTexture( w,h, 24);
            vcamera.targetTexture = rtex;
            var currentRT = RenderTexture.active;
            RenderTexture.active = vcamera.targetTexture;

            vcamera.Render();
           
            Texture2D image = new Texture2D(w, h);
            image.ReadPixels(new Rect(0, 0, w, h), 0, 0);
            image.Apply();
            RenderTexture.active = currentRT;

            var bytes = image.EncodeToJPG();
            UnityEngine.Object.Destroy(image);
            if (!quiet)
            {
                Debug.Log("Saving image to:"+fname+" bytes:" + bytes.Length);
            }
            System.IO.File.WriteAllBytes(fname, bytes);
            var fi = new System.IO.FileInfo(fname);
            if (!quiet)
            {
                Debug.Log("Full name:" + fi.FullName + " bytes:" + fi.Length);
            }

            vcamera.targetTexture = savett;
        }

        public static void SaveScreenShotOld(Camera vcamera, string path, string name, bool adddatetime = true, bool quiet = false)
        {
            // https://forum.unity.com/threads/how-to-save-manually-save-a-png-of-a-camera-view.506269/
            if (!(path.EndsWith("\\") || path.EndsWith("/")))
            {
                path += "/";
            }

            System.IO.Directory.CreateDirectory(path);
            var fname = path + name + ".jpg";
            if (adddatetime)
            {
                fname = path + name + DateTime.Now.ToString("yyyyMMdd-HHmmss_fff") + ".jpg";
            }
            if (!quiet)
            {
                Debug.Log("Base dir:" + System.AppDomain.CurrentDomain.BaseDirectory);
                Debug.Log("Persistent data path:" + Application.persistentDataPath);
            }
            var d = Display.displays[0];
            var w = Screen.width;
            var h = Screen.height;
            w = 871;
            h = 1189;

            Texture2D image = new Texture2D(w, h);
            image.ReadPixels(new Rect(0, 0, w, h), 0, 0);
            image.Apply();

            var bytes = image.EncodeToJPG();
            UnityEngine.Object.Destroy(image);
            if (!quiet)
            {
                Debug.Log("Saving image to:" + fname + " bytes:" + bytes.Length);
            }
            System.IO.File.WriteAllBytes(fname, bytes);
            ScreenCapture.CaptureScreenshot(fname+".png");
        }

        public static void SaveScreenShot( string path, string name, bool adddatetime = true, bool quiet = false)
        {
            if (!(path.EndsWith("\\") || path.EndsWith("/")))
            {
                path += "/";
            }

            System.IO.Directory.CreateDirectory(path);
            var fname = path + name + ".jpg";
            if (adddatetime)
            {
                fname = path + name + DateTime.Now.ToString("yyyyMMdd-HHmmss_fff") + ".png";
            }
            if (!quiet)
            {
                Debug.Log("Base dir:" + System.AppDomain.CurrentDomain.BaseDirectory);
                Debug.Log("Persistent data path:" + Application.persistentDataPath);
            }
            ScreenCapture.CaptureScreenshot(fname);
        }
    }
}