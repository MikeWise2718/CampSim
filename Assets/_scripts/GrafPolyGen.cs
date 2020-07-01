using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aiskwk.Map;
using UnityEngine.UIElements;
using System.Text;
using System.Linq;
using UnityEngine.AI;
using System.Data.Common;
using System.Diagnostics.PerformanceData;

public enum PolyGenForm { pipes, walls, wallsmesh, tesselate }
public class GrafPolyGen
{
    public static int reverseOpps = 0;
    public static int reverses = 0;

    private List<(int id, Vector3 pt)> poutline;
    private PolyGenForm genform;
    private float wallheight = 1f;
    private float wallalf = 1f;
    private string wallclr;



    public GrafPolyGen()
    {
        poutline = new List<(int id, Vector3 pt)>();
    }

    public void AddOutlinePoint(int id, Vector3 pt)
    {
        poutline.Add((id, pt));
    }
    public void AddOutlinePoint(int id, float x, float y, float z)
    {
        poutline.Add((id, new Vector3(x, y, z)));
    }
    public void SetOutline(List<Vector3> ptlist)
    {
        poutline = new List<(int id, Vector3 pt)>();
        int id = 0;
        foreach (var pt in ptlist)
        {
            poutline.Add((id++, pt));
        }
    }
    List<(int id, Vector3 pt)> ptsbuf = null;
    List<int> tribuf = null;
    List<Vector2> uvbuf = null;
    int iseg;

    public void StartAccumulatingSegments()
    {
        ptsbuf = new List<(int id, Vector3 pt)>();
        tribuf = new List<int>();
        uvbuf = new List<Vector2>();
        iseg = 0;
    }
    public void NormalizeUvbuf()
    {
        var newuvbuf = new List<Vector2>();
        var nseg = uvbuf.Count / 2;
        for (int i = 0; i < nseg; i++)
        {
            Vector2 v2 = uvbuf[i];
            var newv2 = new Vector2(v2.x / nseg, v2.y);
            newuvbuf.Add(newv2);
        }
        uvbuf = newuvbuf;
    }
    public void PlotTri(GameObject parent, Vector3 pt1, Vector3 pt2, Vector3 pt3, string txt, float height, string clr)
    {
        pt1 = new Vector3(pt1.x, height, pt1.z);
        pt2 = new Vector3(pt2.x, height, pt2.z);
        pt3 = new Vector3(pt3.x, height, pt3.z);
        var pcen = (pt1 + pt2 + pt3) / 3;
        pt1 = Vector3.Lerp(pt1, pcen, 0.2f);
        pt2 = Vector3.Lerp(pt2, pcen, 0.2f);
        pt3 = Vector3.Lerp(pt3, pcen, 0.2f);
        var mgo1 = qut.CreateMarkerSphere("marker1", pt1, clr: clr);
        mgo1.transform.parent = parent.transform;
        var mgo2 = qut.CreateMarkerSphere("marker2", pt2, clr: clr);
        mgo2.transform.parent = parent.transform;
        var mgo3 = qut.CreateMarkerSphere("marker2", pt3, clr: clr);
        mgo3.transform.parent = parent.transform;
        var pgo1 = qut.CreatePipe("pipe_1", pt1, pt2, clr: clr);
        pgo1.transform.parent = parent.transform;
        var pgo2 = qut.CreatePipe("pipe_2", pt2, pt3, clr: clr);
        pgo2.transform.parent = parent.transform;
        var pgo3 = qut.CreatePipe("pipe_3", pt3, pt1, clr: clr);
        pgo3.transform.parent = parent.transform;
    }
    public void PlotOutline(GameObject parent, List<(int id, Vector3 pt)> outline, string centxt, float height, string clr)
    {
        Vector3 lstpt = Vector3.zero;
        Vector3 fstpt = Vector3.zero;
        int i = 0;
        Vector3 psum = Vector3.zero;
        foreach (var p in outline)
        {
            var pt = new Vector3(p.pt.x, height, p.pt.z);
            if (i == 0)
            {
                fstpt = pt;
            }
            psum += pt;

            var mgo = qut.CreateMarkerSphere("marker-id:" + p.id, pt, clr: clr);
            mgo.transform.parent = parent.transform;
            var txt = p.id.ToString();
            var txgo = qut.MakeTextGo(mgo, txt, yoff: 0.2f, sfak: 0.1f);
            if (i > 0)
            {
                var pgo = qut.CreatePipe("pipe_" + i, lstpt, pt, clr: clr);
                pgo.transform.parent = parent.transform;
            }
            lstpt = pt;
            i++;
        }
        if (i > 0)
        {
            var pcen = psum / i;
            var mgo = qut.CreateMarkerSphere("cen", pcen, size: 0.05f, clr: clr);
            mgo.transform.parent = parent.transform;
            var txgo = qut.MakeTextGo(mgo, centxt, yoff: 0.1f, sfak: 0.1f);
        }
        if (i > 2)
        {
            var pgo = qut.CreatePipe("pipe_" + i, fstpt, lstpt, clr: "blk");
            pgo.transform.parent = parent.transform;
        }
    }

    public void AddSegment(Vector3 pt0, Vector3 pt1, float height, bool onesided = true)
    {
        var pt2h = new Vector3(pt0.x, height, pt0.z);
        var pt3h = new Vector3(pt1.x, height, pt1.z);
        int pcnt = ptsbuf.Count;
        var idx0 = pcnt;
        var idx1 = pcnt + 1;
        var idx2 = pcnt + 2;
        var idx3 = pcnt + 3;
        ptsbuf.Add((idx0, pt0));
        ptsbuf.Add((idx1, pt1));
        ptsbuf.Add((idx2, pt2h));
        ptsbuf.Add((idx3, pt3h));

        tribuf.Add(idx0);
        tribuf.Add(idx1);
        tribuf.Add(idx2);
        tribuf.Add(idx2);
        tribuf.Add(idx1);
        tribuf.Add(idx3);

        if (!onesided)
        {
            pcnt = ptsbuf.Count;
            idx0 = pcnt;
            idx1 = pcnt + 1;
            idx2 = pcnt + 2;
            idx3 = pcnt + 3;

            ptsbuf.Add((idx0, pt0));
            ptsbuf.Add((idx1, pt1));
            ptsbuf.Add((idx2, pt2h));
            ptsbuf.Add((idx3, pt3h));

            tribuf.Add(idx1);
            tribuf.Add(idx0);
            tribuf.Add(idx2);
            tribuf.Add(idx1);
            tribuf.Add(idx2);
            tribuf.Add(idx3);
        }
        uvbuf.Add(new Vector2(iseg - 1, 0));
        uvbuf.Add(new Vector2(iseg - 1, 1));
        uvbuf.Add(new Vector2(iseg, 0));
        uvbuf.Add(new Vector2(iseg, 1));
        iseg++;
    }

    public void GenBld(GameObject parent,string bldname,float height, int levels, string clr,float alf=1,bool plotTesselation=false,bool dowalls=true,bool dofloors=true,bool doroof=true,float ptscale=1)
    {
        bool onesided = false;
        var wps = false;
        var bldgo = new GameObject(bldname);
        var ska = 1/ptscale;
        //bldgo.transform.localScale = new Vector3(ska, ska, ska);
        if (dowalls)
        {
            SetGenForm(PolyGenForm.wallsmesh);
            var wname = $"{bldname}-walls";
            var walgo = GenMesh(wname, height: height, clr: clr, alf: alf, plotTesselation: plotTesselation, onesided: onesided);
            walgo.transform.localScale = new Vector3(ska, ska, ska);
            walgo.transform.SetParent(bldgo.transform,worldPositionStays:wps);
        }
        if (doroof)
        {
            SetGenForm(PolyGenForm.tesselate);
            var rname = $"{bldname}-roof";
            var rufgo = GenMesh(rname, height: height, clr: clr, alf: alf, plotTesselation: plotTesselation, onesided: onesided);
            rufgo.transform.localScale = new Vector3(ska, ska, ska);
            rufgo.transform.SetParent(bldgo.transform, worldPositionStays: wps);
        }
        if (dofloors)
        {
            for(int i=0; i<levels; i++)
            {
                var fname = $"{bldname}-levvel-{i}";
                var fheit = levels<2 ? 0 : (i*height / (levels-1));
                var flrgo = GenMesh(fname, height: fheit, clr: clr, alf: alf, plotTesselation: plotTesselation, onesided: onesided);
                flrgo.transform.localScale = new Vector3(ska, ska, ska);
                flrgo.transform.SetParent(bldgo.transform, worldPositionStays: wps);
            }
        }
        bldgo.transform.position = GetCenter();
        bldgo.transform.SetParent(parent.transform, worldPositionStays: true);
    }

    public Vector3 GetCenter()
    {
        var rv = Vector3.zero; ;
        var ptsum = Vector3.zero;
        if (poutline.Count > 0)
        {
            foreach (var p in poutline)
            {
                ptsum += p.pt;
            }
            rv = ptsum / poutline.Count;
        }
        return rv;
    }
    public Vector3 GetCenter(float y)
    {
        var cen = GetCenter();
        var nrv = new Vector3(cen.x, y, cen.z);
        return nrv;
    }

    Vector3[] GetPtsBufArray()
    {
        var rv = new Vector3[ptsbuf.Count];
        int i = 0;
        foreach (var p in ptsbuf)
        {
            rv[i++] = p.pt;
        }
        return rv;
    }
    public GameObject GetAccumulatedMesh(string meshname)
    {
        var go = new GameObject(meshname);
        var meshRenderer = go.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        var meshFilter = go.AddComponent<MeshFilter>();

        var mesh = new Mesh();
        mesh.vertices = GetPtsBufArray();
        mesh.triangles = tribuf.ToArray();
        NormalizeUvbuf();
        mesh.uv = null;
        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;
        qut.SetColorOfGo(go, wallclr, wallalf);
        var ntris = tribuf.Count / 3;
        //Debug.Log($"mesh has {ptsbuf.Count} vertices and {ntris} triangles");
        return go;
    }

    public void GenCylinderOutline(Vector3 cen, int nseg, float radius, float ripple = 0)
    {
        for (int i = 0; i < nseg; i++)
        {
            var angdeg = (360f * i) / nseg;
            var ang = Mathf.PI * angdeg / 180;
            //Debug.Log($"i:{i} angdeg:{angdeg}  ang:{ang}");
            var x = radius * Mathf.Sin(ang) + cen.x;
            var ripoff = ripple * Mathf.Sin(ang);
            var y = cen.y + ripoff * ripoff;
            var z = radius * Mathf.Cos(ang) + cen.z;
            AddOutlinePoint(i, x, y, z);
        }
    }

    public void GenStarOutline(Vector3 cen, int nseg, float rad1, float rad2, float ripple = 0)
    {
        for (int i = 0; i < nseg; i++)
        {
            var radius = rad1;
            if (i % 2 == 0)
            {
                radius = rad2;
            }
            var angdeg = (360f * i) / nseg;
            var ang = Mathf.PI * angdeg / 180;
            //Debug.Log($"i:{i} angdeg:{angdeg}  ang:{ang}");
            var x = radius * Mathf.Sin(ang) + cen.x;
            var ripoff = ripple * Mathf.Sin(ang);
            var y = cen.y + ripoff*ripoff;
            var z = radius * Mathf.Cos(ang) + cen.z;
            AddOutlinePoint(i, x, y, z);
        }
    }

    public void GenCrossOutline(Vector3 cen, float radius, float ripple = 0)
    {
        var o2 = new List<Vector2>() {
            new Vector2(-3, -1), new Vector2(-3, +1), new Vector2(-1, +1),
            new Vector2(-1, +3), new Vector2(+1, +3), new Vector2(+1, +1),
            new Vector2(+3, +1), new Vector2(+3, -1), new Vector2(+1, -1),
            new Vector2(+1, -3), new Vector2(-1, -3), new Vector2(-1, -1),
        };
        for (int i = 0; i < o2.Count; i++)
        {
            var pt = o2[i];
            AddOutlinePoint(i, pt.y + cen.x, 0 + cen.y, pt.x + cen.z);
        }
    }

    public GameObject GenMesh(string name, float height = 1, string clr = "indigo", float alf = 1, bool plotTesselation = false, bool onesided=false)
    {
        var go = new GameObject(name);
        var pos = GetCenter(height);
        go.transform.position = pos;
        this.wallheight = height;
        this.wallalf = alf;
        this.wallclr = clr;
        Generate(go, plotTesselation,onesided:onesided);
        return go;
    }

    public void SetGenForm(PolyGenForm genform)
    {
        this.genform = genform;
    }

    public void SetHeight(float height)
    {
        this.wallheight = height;
    }

    public GameObject Create4ptQuad(string qname, Vector3 pt0, Vector3 pt1, Vector3 pt2, Vector3 pt3, string clr = "blue", float alf = 1, bool onesided = false)
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

    public GameObject CreateForm(string frmname, Vector3 pt0, Vector3 pt1, float height)
    {
        GameObject rv;
        switch (genform)
        {
            default:
            case PolyGenForm.walls:
                {
                    var pt2 = new Vector3(pt0.x, height, pt0.z);
                    var pt3 = new Vector3(pt1.x, height, pt1.z);
                    rv = Create4ptQuad(frmname, pt0, pt1, pt2, pt3, clr: wallclr, alf: wallalf);
                    break;
                }
            case PolyGenForm.pipes:
                {
                    rv = qut.CreatePipe(frmname, pt0, pt1, clr: wallclr, size: height, alf: wallalf);
                    break;
                }
        }
        return rv;
    }
    public void Generate(GameObject parent, bool plotTesselation,bool onesided=false)
    {
        switch (genform)
        {
            case PolyGenForm.pipes:
                {
                    GenerateBySegment(parent, wallheight,onesided:onesided);
                    break;
                }
            case PolyGenForm.walls:
                {
                    GenerateBySegment(parent, wallheight, onesided: onesided);
                    break;
                }
            case PolyGenForm.wallsmesh:
                {
                    GenerateBySegment(parent, wallheight, asmesh: true, onesided: onesided);
                    break;
                }
            case PolyGenForm.tesselate:
                {
                    TessleateYup(parent, wallheight, plotTesselation: plotTesselation, onesided:onesided);
                    break;
                }
        }
    }
    static int moduloInc(int i, int inc, int n)
    {
        var inew = i + inc;
        if (inew < 0) inew += n;
        if (inew >= n) inew -= n;
        return inew;
    }
    public static (float val, int idx) FindLargestCrossProductYcomponent(List<(int id, Vector3 pt)> ptlist)
    {
        var cpvalmax = float.MinValue;
        var cpvalmaxidx = -1;
        for (int i = 0; i < ptlist.Count; i++)
        {
            var i0 = moduloInc(i, -1, ptlist.Count);
            var i1 = i;
            var i2 = moduloInc(i, +1, ptlist.Count);

            var v0 = ptlist[i0].pt;
            var v1 = ptlist[i1].pt;
            var v2 = ptlist[i2].pt;
            var cv1 = v0 - v1;
            var cv2 = v2 - v1;
            var cpval = Vector3.Cross(cv2, cv1).y;
            if (cpval > cpvalmax)
            {
                cpvalmax = cpval;
                cpvalmaxidx = i;
            }
        }
        return (cpvalmax, cpvalmaxidx);
    }

    public static float CalcAreaWithYup(List<(int id, Vector3 pt)> ptlist)
    {
        // discussion: https://stackoverflow.com/a/1165943/3458744
        // returns a positive area if the points are anti-clockwise in the x-z plane with y pointed up and LHS (i.e. Unity conventions)
        if (ptlist.Count == 0) return 0f;
        //Debug.Log($"CalcArea pts:{ptlist.Count}");
        var sum = 0f;
        var fstpt = ptlist[0].pt;
        var lstpt = fstpt;
        for (int i = 1; i < ptlist.Count; i++)
        {
            var pt = ptlist[i].pt;
            sum += (pt.x-lstpt.x)*(pt.z+lstpt.z);
            lstpt = pt;
        }
        sum +=  (fstpt.x-lstpt.x)*(fstpt.z+lstpt.z);
        var area = sum / 2;
        return area;
    }
    public static float CalcAreaWithYup(List<Vector3> ptlist)
    {
        // discussion: https://stackoverflow.com/a/1165943/3458744
        // returns a positive area if the points are anti-clockwise in the x-z plane with y pointed up and LHS (i.e. Unity conventions)
        if (ptlist.Count == 0) return 0f;
        //Debug.Log($"CalcArea pts:{ptlist.Count}");
        var sum = 0f;
        var fstpt = ptlist[0];
        var lstpt = fstpt;
        for (int i = 1; i < ptlist.Count; i++)
        {
            var pt = ptlist[i];
            sum += (pt.x - lstpt.x) * (pt.z + lstpt.z);
            lstpt = pt;
        }
        sum += (fstpt.x - lstpt.x) * (fstpt.z + lstpt.z);
        var area = sum / 2;
        return area;
    }


    public static (float val, int idx) FindSmallestPositiveCrossProductYcomponent(List<(int id,Vector3 pt)> ptlist,bool dbout=false)
    {
        // find the index of the middle point of the smallest convex triangle to slice off
        var cpvalmin = float.MaxValue;
        var cpvalminidx = -1;
        if (dbout)
        {
            Debug.Log($"FSPCP pts:{ptlist.Count}");
        }
        for (int i = 0; i < ptlist.Count; i++)
        {
            var i0 = moduloInc(i, -1, ptlist.Count);
            var i1 = i;
            var i2 = moduloInc(i, +1, ptlist.Count);

            var v0 = ptlist[i0].pt;
            var v1 = ptlist[i1].pt;
            var v2 = ptlist[i2].pt;
            var cv1 = v0 - v1;
            var cv2 = v2 - v1;
            var cpval = Vector3.Cross(cv2, cv1).y;
            if (dbout)
            {
                var cv1s = cv1.ToString("f3");
                var cv2s = cv2.ToString("f3");
                var cpiszero = cpval == 0;
                var id = ptlist[i1].id;
                Debug.Log($"    i:{i} id:{id} cpval:{cpval} cpiszero:{cpiszero}  cv1:{cv1s} cv2:{cv2s}");
            }
            if (cpval <= 0) continue; // cpval is negative is triangle is concave
            if (cpval < cpvalmin)
            {
                cpvalmin = cpval;
                cpvalminidx = i;
            }
        }
        if (dbout)
        {
            Debug.Log($"FSPCP cpvalmin:{cpvalmin} idx:{cpvalminidx}");
        }
        return (cpvalmin, cpvalminidx);
    }

    GameObject GetLevParent(GameObject parent,int lev)
    {
        var go = new GameObject($"lev-{lev}");
        go.transform.parent = parent.transform;
        return go;
    }
    float mindiff = float.MaxValue;
    bool ArePtsEq(Vector3 v1,Vector3 v2,float eps)
    {
        var diff = Mathf.Abs(v1.x - v2.x) + Mathf.Abs(v1.z - v2.z);
        if (diff<mindiff)
        {
            mindiff = diff;
        }
        var rv = diff < eps;
        return rv;
    }

    public List<(int id, Vector3 pt)> RemoveAdjacentEquals(List<(int id, Vector3 pt)> inlist,float eps)
    {
        var outlist = new List<(int id, Vector3 pt)>();
        var npt = inlist.Count;
        for(int i0=0; i0<npt; i0++)
        {
            var i1 = moduloInc(i0, +1, npt);
            var v0 = inlist[i0].pt;
            var v1 = inlist[i1].pt;
            if (!ArePtsEq(v0,v1,eps))
            {
                outlist.Add(inlist[i0]);
            }
        }
        return outlist;
    }

    public GameObject TessleateYup(GameObject parent,float height,bool onesided=false, bool plotTesselation = false)
    {
        int lev = 0;
        var eps = 1e-3f;

        int starcnt = poutline.Count;
        var woutline = RemoveAdjacentEquals(poutline,eps);
        if (poutline.Count < 3)
        {
            Debug.LogError($"Not enough distinct points:{woutline.Count} to tesselate - count before dup removeal:{poutline.Count}");
            return null;
        }
        var area = CalcAreaWithYup(woutline);
        var dbheight = height + 0.5f;
        int iclr = 0;
        if (plotTesselation)
        {
            var centxt = "Area:" + area.ToString("f2");
            var clr = qut.GetColorBySeq(iclr++);
            var levpar = GetLevParent(parent, lev++);
            PlotOutline(levpar, woutline, centxt, dbheight, clr);
            dbheight += 2;
        }
        reverseOpps++;
        if (area==0)
        {
            Debug.LogWarning("Cannot tesselate zero area polygong - terminating tesselation");
            var go1 = GetAccumulatedMesh("accumesh");
            go1.transform.parent = parent.transform;
            return go1;
        }
        else if (area<0)
        {
            reverses++;
            Debug.Log($"Reversing point order to make points CCW - new area:{area}");
            woutline = new List<(int id, Vector3 pt)>(woutline.Reverse<(int id, Vector3 pt)>());
            area = CalcAreaWithYup(woutline);
            if (plotTesselation)
            {
                var centxt = "Rev Area:" + area.ToString("f2");
                var clr = qut.GetColorBySeq(iclr++);
                var levpar = GetLevParent(parent, lev++);
                PlotOutline(levpar, woutline, centxt, dbheight, clr);
                dbheight += 2;
            }
            Debug.Log($"new area:{area}");
        }
        var (maxval, maxidx) = FindSmallestPositiveCrossProductYcomponent(woutline);
        //var (maxval, maxidx) = FindLargestCrossProductYcomponent(woutline);
        StartAccumulatingSegments();
        var fmaxidx = maxidx;


        while (true)
        {
            var i0 = moduloInc(maxidx, -1, woutline.Count);
            var i1 = maxidx;
            var i2 = moduloInc(maxidx, +1, woutline.Count);
            var v0 = woutline[i0].pt;
            //var id0 = woutline[i0].id;
            var v1 = woutline[i1].pt;
            //var id1 = woutline[i1].id;
            var v2 = woutline[i2].pt;
            //var id2 = woutline[i2].id;
            //if (ArePtsEq(v0, v1, eps))
            //{
            //    //Debug.Log($"Removing {woutline[i1].id} as v0=v1");
            //    woutline.RemoveAt(i1);
            //    continue;
            //}
            //if (ArePtsEq(v1, v2, eps))
            //{
            //    //Debug.Log($"Removing {woutline[i1].id} as v1=v2");
            //    woutline.RemoveAt(i1);
            //    continue;
            //}
            var w0 = new Vector3(v0.x, height, v0.z);
            var w1 = new Vector3(v1.x, height, v1.z);
            var w2 = new Vector3(v2.x, height, v2.z);
            if (plotTesselation)
            {
                var clr = qut.GetColorBySeq(iclr++);
                var levpar = GetLevParent(parent, lev++);
                var centxt = "Remove pt:" + woutline[i1].id;
                PlotOutline(levpar, woutline, centxt,   dbheight, clr);
                dbheight += 2;
                Debug.Log($"Slicing out {maxidx} val:{maxval} ptsleft:{woutline.Count}");

                PlotTri(levpar, v0, v1, v2, "", height, clr);
                var v1s = v1.ToString("f3");
                Debug.Log($"Removing at {i1} - v1:{v1s} woutline.Count:{woutline.Count}");
            }
            woutline.RemoveAt(i1);
            var pidx = ptsbuf.Count;
            ptsbuf.Add((i0,w0));
            ptsbuf.Add((i1,w1));
            ptsbuf.Add((i2,w2));
            tribuf.Add(pidx);
            tribuf.Add(pidx + 1);
            tribuf.Add(pidx + 2);
            if (!onesided)
            {
                pidx = ptsbuf.Count;
                ptsbuf.Add((i0,w0));
                ptsbuf.Add((i1,w1));
                ptsbuf.Add((i2,w2));
                tribuf.Add(pidx);
                tribuf.Add(pidx + 2);
                tribuf.Add(pidx + 1);
            }
            if (woutline.Count < 3) break; // done
            //(maxval, maxidx) = FindLargestCrossProductYcomponent(woutline);

            (maxval, maxidx) = FindSmallestPositiveCrossProductYcomponent(woutline);
            if (maxidx<0)
            {
                var remarea = CalcAreaWithYup(woutline);
                var remfrac = Mathf.Abs(remarea / area);
                if (remfrac < 0.001f)
                {
                    //this happens when the remaining points have zero area
                    // not sure it should really happen
                    break;
                }
                var curcnt = woutline.Count;
                Debug.LogError($"{parent.name} Error in teslation  startcount:{starcnt} current:{curcnt} remarea:{remarea:g3} remfrac:{remfrac:g4}");
                (maxval, maxidx) = FindSmallestPositiveCrossProductYcomponent(woutline, dbout: true);
                Debug.LogError($"{parent.name} Tesselate maxidx is -1 - breaking tesselation  startarea:{area:g3} fmaxidx:{fmaxidx}");
                break;
            }
        }
        var go = GetAccumulatedMesh("accumesh");
        go.transform.parent = parent.transform;
        return go;
    }

    public void GenerateBySegment(GameObject parent,float height,bool asmesh=false, bool onesided=false)
    {
        if (poutline.Count <= 1)
        {
            Debug.LogError("BldPolyGenForm can not generate with less than two points");
            return;
        }
        if (asmesh)
        {
            StartAccumulatingSegments();
        }
        var woutline = new List<(int id, Vector3 pt)>(poutline);
        var area = CalcAreaWithYup(woutline);
        if (area < 0)
        {
            Debug.Log($"Reversing point order to make points CCW - new area:{area}");
            woutline = new List<(int id, Vector3 pt)>(woutline.Reverse<(int id, Vector3 pt)>());
            area = CalcAreaWithYup(woutline);
            Debug.Log($"new area:{area}");
        }

        int i1 = 0;
        int i2 = i1 + 1;
        int nsegdone = 0;
        while (nsegdone< woutline.Count)
        {
            var pt1 = woutline[i1].pt;
            var pt2 = woutline[i2].pt;
            var pname = $"seg-{i1}";
            if (!asmesh)
            {
                var go = CreateForm(pname, pt1, pt2, height);
                go.transform.parent = parent.transform;
            }
            else
            {
                AddSegment(pt1, pt2,height,onesided:onesided);
            }
            i1 = i2;
            i2 = i1 + 1;
            if (i2 == woutline.Count) i2 = 0;
            nsegdone++;
        }
        if (asmesh)
        {
            var go = GetAccumulatedMesh("accumesh");
            go.transform.parent = parent.transform;
        }
    }
}
