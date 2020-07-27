using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;
using System.Reflection;
using TMPro;
/// <summary>
/// GraphAlgos.cs  - This file contains static algoritms that we need in various places. 
/// </summary>

namespace Aiskwk.Map
{
    [System.Serializable]
    public struct Vector3d
    {
        public double x;
        public double y;
        public double z;
        public Vector3d(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    [System.Serializable]
    public struct Vector2d
    {
        public double x;
        public double y;
        public Vector2d(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class ColorInterpolator
    {
        Color clrhih = Color.red;
        Color clravg = Color.white;
        Color clrlow = Color.blue;
        readonly float valmin;
        readonly float valavg;
        readonly float valmax;
        public ColorInterpolator(float valmax, float valavg, float valmin)
        {
            this.valmin = valmin;
            this.valavg = valavg;
            this.valmax = valmax;
            if (valmin > valavg)
            {
                Debug.LogWarning($"Color Interpolator - valmin>valavg valmin:{valmin} valavg:{valavg}");
            }
            if (valavg > valmax)
            {
                Debug.LogWarning($"Color Interpolator - valavg>valmax valavg:{valavg} valmax:{valmax}");
            }
        }
        public void SetColors(Color clrhigh, Color clravg, Color clrlow)
        {
            this.clrhih = clrhigh;
            this.clravg = clravg;
            this.clrlow = clrlow;
        }
        public Color GetInterpColor(float val)
        {
            Color clr;
            if (val > valavg)
            {
                var interp = (valmax - val) / (valmax - valavg);
                clr = Color.Lerp(clrhih, clravg, interp);
            }
            else
            {
                var interp = (val - valmin) / (valavg - valmin);
                clr = Color.Lerp(clravg, clrlow, interp);
            }
            return clr;
        }
        public string GetInterpColorHex(float val)
        {
            var clr = GetInterpColor(val);
            var (clrhex, _) = qut.HexColor(clr);
            return clrhex;
        }
    }


    public class StopWatch
    {
        DateTime starttime;
        DateTime marktime;
        DateTime stoptime;
        TimeSpan elap;
        DateTime lastyieldedtime;
        TimeSpan yieldtime = new TimeSpan(0, 0, 0, 0, 300);
        public StopWatch(bool start=true)
        {
            if (start)
            {
                Start();
            }
        }
        public void SetYieldTime(TimeSpan yieldtime)
        {
            this.yieldtime = yieldtime;
        }
        public bool ElapfOverYieldTime()
        {
            Mark();
            var curyieldtimeforstep = marktime - lastyieldedtime;
            bool rv = (curyieldtimeforstep > yieldtime);
            if (rv)
            {
                lastyieldedtime = marktime;
            }
            return rv;
        }
        public void Start()
        {
            starttime = DateTime.Now;
            lastyieldedtime = starttime;
        }
        public void Stop()
        {
            stoptime = DateTime.Now;
            elap = stoptime - starttime;
        }
        public void Mark()
        {
            marktime = DateTime.Now;
            elap = marktime - starttime;
        }
        public TimeSpan Elap()
        {
            Mark();
            return elap;
        }
        public float Elapf()
        {
            //Mark();
            return (float) elap.TotalSeconds; 
        }
        public string ElapSecs(int decpt = 3)
        {
            var rv = elap.TotalSeconds.ToString("f" + decpt);
            return rv;
        }
    }

    public static class qut
    {
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
        public static int GetRanInt(int imin, int imax, string ranset = "")
        {
            var ranman = GetRanMan(ranset);
            var rv = imin + ranman.Next(imax - imin);
            return rv;
        }
        public static float GetRanFloat(float fmin = 0, float fmax = 1, string ranset = "")
        {
            var maxi = 1000000;// a million
            var ranman = GetRanMan(ranset);
            var i = ranman.Next(maxi);
            var rv = fmin + (i * (fmax - fmin) / maxi);
            return rv;
        }

        public static Color rgbbyte(int r, int g, int b, float alpha = 1)
        {
            return new Color(r / 255f, g / 255f, b / 255f, alpha);
        }
        static Dictionary<string, Color> colorTable = null;
        public static bool isColorName(string name)
        {
            if (colorTable == null)
            {
                InitColorTable();
            }
            return colorTable.ContainsKey(name);
        }
        static void InitColorTable()
        {
            colorTable = new Dictionary<string, Color>();
            // reds
            colorTable["r"] = 
            colorTable["red"] = new Color(1, 0, 0);
            colorTable["dr"] = new Color(0.5f, 0, 0);
            colorTable["crimsom"] = rgbbyte(220, 20, 60);
            colorTable["coral"] = rgbbyte(255, 127, 80);
            colorTable["firebrick"] = rgbbyte(178, 34, 34);
            colorTable["darkred"] = rgbbyte(139, 0, 0);
            colorTable["dirtyred"] = rgbbyte(117, 10, 10);
            colorTable["pink"] = new Color(1, 0.412f, 0.71f);
            colorTable["scarlet"] = new Color(1, 0.14f, 0.0f);
            // yellows
            colorTable["y"] = 
            colorTable["yellow"] = new Color(1, 1, 0);
            colorTable["dy"] = new Color(0.5f, 0.5f, 0);
            colorTable["lightyellow"] = new Color(1, 1, 0.5f);
            // oranges
            colorTable["orange"] = new Color(1, 0.5f, 0);
            colorTable["lightorange"] = new Color(1, 0.75f, 0);
            colorTable["darkorange"] = new Color(0.75f, 0.25f, 0);
            colorTable["brown"] = new Color(0.647f, 0.164f, 0.164f);
            colorTable["saddlebrown"] = new Color(0.545f, 0.271f, 0.075f);
            colorTable["darkbrown"] = new Color(0.396f, 0.263f, 0.129f);
            // greens
            colorTable["g"] =
            colorTable["green"] = new Color(0, 1, 0);
            colorTable["dg"] = new Color(0, 0.5f, 0);
            colorTable["olive"] = new Color(0.5f, 0.5f, 0f);
            colorTable["lightgreen"] = new Color(0.5f, 1f, 0.5f);
            colorTable["darkgreen"] = new Color(0, 0.5f, 0);
            colorTable["darkgreen1"] = new Color(0.004f, 0.196f, 0.125f);
            colorTable["forestgreen"] = new Color(0.132f, 0.543f, 0.132f);
            colorTable["limegreen"] = new Color(0.195f, 0.8f, 0.195f);
            colorTable["seagreen"] = new Color(0.33f, 1.0f, 0.62f);
            // cyans
            colorTable["c"] = 
            colorTable["cyan"] = new Color(0, 1, 1);
            colorTable["dc"] = new Color(0, 0.5f, 0.5f);
            colorTable["turquoise"] =
            colorTable["turquis"] = rgbbyte(64, 224, 208);
            colorTable["teal"] = rgbbyte(0, 128, 128);
            colorTable["aquamarine"] = rgbbyte(128, 255, 212);
            // blues
            colorTable["b"] = 
            colorTable["blue"] = new Color(0, 0, 1);
            colorTable["db"] = new Color(0, 0, 0.5f);
            colorTable["steelblue"] = new Color(0.27f, 0.51f, 0.71f);
            colorTable["lightblue"] = rgbbyte(173, 216, 230);
            colorTable["azure"] = rgbbyte(0, 127, 255);
            colorTable["skyblue"] = rgbbyte(135, 206, 235);
            colorTable["darkblue"] = new Color(0.0f, 0.0f, 0.500f);
            colorTable["navyblue"] = new Color(0.0f, 0.0f, 0.398f);
            // purples
            colorTable["m"] = 
            colorTable["magenta"] = new Color(1, 0, 1);
            colorTable["dm"] = 
            colorTable["purple"] = new Color(0.5f, 0, 0.5f);
            colorTable["violet"] = new Color(0.75f, 0, 0.75f);
            colorTable["indigo"] = rgbbyte(43, 34, 170);
            colorTable["deeppurple"] = new Color(0.4f, 0, 0.4f);
            colorTable["darkpurple"] = rgbbyte(48, 25, 52);
            colorTable["phlox"] = rgbbyte(223, 0, 255);
            colorTable["mauve"] = rgbbyte(224, 176, 255);
            colorTable["fuchsia"] = rgbbyte(255, 0, 255);
            colorTable["lilac"] = new Color(0.86f, 0.8130f, 1.0f);
            // whites and grays
            colorTable["w"] = 
            colorTable["white"] = new Color(1, 1, 1);
            colorTable["chinawhite"] = new Color(0.937f, 0.910f, 0.878f);
            colorTable["clear"] = Color.clear;
            colorTable["silver"] = rgbbyte(192, 192, 192);
            colorTable["lightgrey"] =
            colorTable["lightgray"] = rgbbyte(211, 211, 211);
            colorTable["slategray"] =
            colorTable["slategrey"] = rgbbyte(112, 128, 144);
            colorTable["darkslategray"] =
            colorTable["darkslategrey"] = rgbbyte(74, 85, 83);
            colorTable["darkgray"] =
            colorTable["darkgrey"] =
            colorTable["dimgray"] =
            colorTable["dimgrey"] = rgbbyte(105, 105, 105);
            colorTable["grey"] =
            colorTable["gray"] = rgbbyte(128, 128, 128);
            colorTable["blk"] = 
            colorTable["black"] = new Color(0, 0, 0);
        }
        static string[] dcolorseq = { "dr", "dg", "db", "dm", "dy", "dc" };
        static string[] colorseq = { "r", "g", "b", "m", "y", "c" };
        public static string GetColorBySeq(int idx, bool dark = true)
        {
            string name;
            if (dark)
            {
                name = dcolorseq[idx % dcolorseq.Length];
            }
            else
            {
                name = colorseq[idx % colorseq.Length];
            }
            return name;
        }
        public static Color GetColorByName(string name)
        {
            if (!isColorName(name))
            {
                Debug.LogError($"color {name} not defined in colortable");
                return Color.gray;
            }
            return colorTable[name];
        }
        public static Color GetColorByName(string name, float alpha = 0.4f)
        {
            var clr = GetColorByName(name);
            var rv = new Color(clr.r, clr.g, clr.b, alpha);
            return rv;
        }



        public static byte[] StringToByteArrayFastest(string hex)
        {
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }

        public static int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            //return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }
        public static Color rgbhex(string hexstr, float alpha = 1)
        {
            if (hexstr.Length > 6)
            {
                hexstr = hexstr.Remove(0, hexstr.Length - 6);
            }
            var bv = StringToByteArrayFastest(hexstr);
            return new Color(bv[0] / 255f, bv[1] / 255f, bv[2] / 255f, alpha);
        }
        public static (string hexval, float alpha) HexColor(Color clr)
        {
            var r = (int)(255.99 * clr.r);
            var g = (int)(255.99 * clr.g);
            var b = (int)(255.99 * clr.b);
            var rs = r.ToString("X2");
            var gs = g.ToString("X2");
            var bs = b.ToString("X2");
            var hexstr = $"#{rs}{gs}{bs}";
            return (hexstr, clr.a);
        }
 
        static Shader transShader = null;
        public static void SetColorOfGo(GameObject go, Color cclr)
        {
            var mat = go.GetComponent<Renderer>().material;
            mat.enableInstancing = true;
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


        public static Material SetColorNewMat(GameObject go, Color cclr)
        {
            var rend = go.GetComponent<Renderer>();
            var shader = Shader.Find("Diffuse");
            var mat = new Material(shader);
            rend.material = mat;
            rend.material.enableInstancing = true;
            rend.material.color = cclr;
            return mat;
        }

        public static void SetColorOfGo(GameObject go, string clrname, float alf = 1.0f)
        {
            SetColorOfGo(go, GetColorByName(clrname, alf));
        }
        public static GameObject CreateMarkerSphere(string name, Vector3 pt, float size = 0.2f, string clr = "blue", float alf = 1)
        {
            var sph = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            var clder = sph.GetComponent<Collider>();
            if (clder != null)
            {
                clder.enabled = false;
            }
            var cclr = GetColorByName(clr, alf);
            SetColorOfGo(sph, cclr);
            sph.name = name;
            sph.transform.localScale = new Vector3(size, size, size);
            sph.transform.localPosition = pt;

            return (sph);
        }


        public static GameObject Create4ptQuad(string qname, Vector3 pt0, Vector3 pt1, Vector3 pt2, Vector3 pt3, string clr = "blue", float alf = 1, bool onesided = false)
        {
            var go = new GameObject(qname);
            MeshRenderer meshRenderer = go.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

            MeshFilter meshFilter = go.AddComponent<MeshFilter>();

            Mesh mesh = new Mesh();
            Vector3[] vertices;
            int[] tris;
            Vector2[] uv;
            if (onesided)
            {
                vertices = new Vector3[] { pt0, pt1, pt2, pt3 };
                tris = new int[] { 0, 1, 2, 2, 1, 3 };
                uv = new Vector2[] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1) };
            }
            else
            {
                vertices = new Vector3[] { pt0, pt1, pt2, pt3, pt0, pt1, pt2, pt3 };
                tris = new int[] { 0, 1, 2, 2, 1, 3, 1 + 4, 0 + 4, 2 + 4, 1 + 4, 2 + 4, 3 + 4 };
                uv = new Vector2[] { 
                    new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1),
                    new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1),
                };
            }
            mesh.vertices = vertices;
            mesh.triangles = tris;
            mesh.uv = uv;
            mesh.RecalculateNormals();
            meshFilter.mesh = mesh;
            qut.SetColorOfGo(go, clr, alf);
            return go;
        }
        public static GameObject CreatePipe(string pname, Vector3 frpt, Vector3 topt, float size = 0.1f, string clr = "yellow", float alf = 1)
        {
            var cclr = GetColorByName(clr, alf);
            return CreatePipe(pname, frpt, topt, cclr, size);
        }

        public static GameObject CreatePipe(string pname, Vector3 frpt, Vector3 topt, Color cclr, float size = 0.1f)
        {
            var dst_div_2 = Vector3.Distance(frpt, topt) / 2;
            var dlt = topt - frpt;
            var dltxz = Mathf.Sqrt( dlt.x*dlt.x + dlt.z*dlt.z );
            var anglng = 180 * Mathf.Atan2(dltxz, dlt.y) / Mathf.PI;
            var anglat = 180 * Mathf.Atan2(dlt.x, dlt.z) / Mathf.PI;

            var pcyl = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            pcyl.name = pname;
            var clder = pcyl.GetComponent<Collider>();
            if (clder != null)
            {
                clder.enabled = false;
            }
            SetColorOfGo(pcyl, cclr);
            var tform = pcyl.transform;
            tform.localScale = new Vector3(size, dst_div_2, size);
            tform.Rotate(anglng, anglat, 0);
            tform.transform.localPosition = frpt + 0.5f * dlt;
            return pcyl;
        }

        public static TextMeshPro MakeTextGo(GameObject parpargo, string text, float yoff, float backoff = 0.01f, float sfak = 0.3f, Vector3 fvek = new Vector3(), string bkclr = "white", string txclr = "darkblue")
        {
            if (Vector3.Magnitude(fvek) == 0)
            {
                fvek = Vector3.forward;
            }
            if (Camera.main != null)
            {
                fvek = Camera.main.transform.forward;
            }
            var qlook = Quaternion.LookRotation(fvek);

            var tar = text.Split('\n');
            var txwid = 0;
            foreach (var s in tar)
            {
                txwid = Mathf.Max(txwid, s.Length);
            }
            var txheit = tar.Length * 2;
            var txtgo = new GameObject(parpargo.name + "-txt");
            //txtgo.transform.position = parpargo.transform.position;
            //txtgo.transform.SetParent( parpargo.transform,worldPositionStays: true);
            txtgo.transform.SetParent(parpargo.transform, worldPositionStays: false);

            var bgo = GameObject.CreatePrimitive(PrimitiveType.Quad);
            var mc = bgo.GetComponent<MeshCollider>();
            mc.convex = false;
            Component.Destroy(mc);
            bgo.name = parpargo.name + "-bck";
            bgo.transform.position = parpargo.transform.position;
            bgo.transform.localPosition += new Vector3(0, yoff, 0);

            bgo.transform.localPosition += fvek * backoff;
            bgo.transform.localScale = new Vector3(0.8f * txwid * sfak, (txheit + 0.8f) * sfak, sfak);
            bgo.transform.rotation = qlook;
            //pargo.transform.SetParent(parpargo.transform, true);
            //bgo.transform.parent = pargo.transform;
            bgo.transform.SetParent(txtgo.transform, worldPositionStays: true);
            SetColorOfGo(bgo, bkclr);

            var tgo = new GameObject(parpargo.name + "-tmp");
            tgo.transform.position = parpargo.transform.position;
            var tmp = tgo.AddComponent<TMPro.TextMeshPro>();
            //int linecount = text.Split('\n').Length;
            //tm.text = "<mark=#000000>"+text+"</mark>"; // this only works with an alpha of less than 1
            tmp.text = text;
            tmp.fontSize = 14;
            tmp.alignment = TMPro.TextAlignmentOptions.Center;
            tgo.transform.localScale = new Vector3(sfak, sfak, sfak);
            tgo.transform.rotation = qlook;
            tgo.transform.localPosition += new Vector3(0, yoff, 0);
            tgo.transform.SetParent(txtgo.transform, worldPositionStays: true); // otherwise we get a warning because of the RectTransform
            tmp.color = GetColorByName(txclr);
            tmp.alpha = 1.0f; // this has to stay at the end or it gets overwritten !!
            return tmp;
        }

        public static void CopyTextToClipboard(string textToCopy,string caller="",bool reportToLog=false)
        {
            TextEditor editor = new TextEditor
            {
                text = textToCopy
            };
            editor.SelectAll();
            editor.Copy();
            if (reportToLog)
            {
                Debug.Log($"{caller} copied {textToCopy.Length} characters to clipboard");
            }
        }
    }

}