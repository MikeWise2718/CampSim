using System.Collections.Generic;
using UnityEngine;
using Aiskwk.Map;
using System.Linq;
using System.Security.Cryptography;
using UnityEditorInternal;

public delegate Vector3 PolyGenVekMapDel(Vector3 v);
public enum PolyGenForm { pipes, walls, wallsmesh, tesselate }
public class GrafPolyGen
{
    public static int reverseOpps = 0;
    public static int reverses = 0;

    private List<(int id, Vector3 pt)> _poutline;
    private PolyGenForm genform;
    private float wallheight = 1f;
    private float wallalf = 1f;
    private string wallclr;
    private List<(int id, Vector3 pt)> ptsbuf = null;
    private List<int> tribuf = null;
    private List<Vector2> uvbuf = null;
    private int iseg;

    public GrafPolyGen()
    {
        _poutline = new List<(int id, Vector3 pt)>();
        InitLists();
    }

    public void InitLists()
    {
        ptsbuf = new List<(int id, Vector3 pt)>();
        tribuf = new List<int>();
        uvbuf = new List<Vector2>();
        iseg = 0;
    }

    public void AddOutlinePoint(int id, float x, float y, float z)
    {
        _poutline.Add((id, new Vector3(x, y, z)));
    }
    public void SetOutline(List<Vector3> ptlist)
    {
        _poutline = new List<(int id, Vector3 pt)>();
        int id = 0;
        foreach (var pt in ptlist)
        {
            _poutline.Add((id++, pt));
        }
    }
    public List<(int id, Vector3 pt)> GetOutline()
    {
        var rv = new List<(int id, Vector3 pt)>(_poutline);
        return rv;
    }

    public void StartAccumulatingSegments()
    {
        InitLists();
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
            mgo.transform.SetParent(parent.transform,worldPositionStays:true);
            var txt = p.id.ToString();
            var txgo = qut.MakeTextGo(mgo, txt, yoff: 0.2f, sfak: 0.3f);
            if (i > 0)
            {
                var pgo = qut.CreatePipe("pipe_" + i, lstpt, pt, clr: clr);
                pgo.transform.SetParent( parent.transform, worldPositionStays:true );
            }
            lstpt = pt;
            i++;
        }
        if (i > 0)
        {
            var pcen = psum / i;
            var mgo = qut.CreateMarkerSphere("cen", pcen, size: 0.05f, clr: clr);
            mgo.transform.SetParent(parent.transform, worldPositionStays: true);
            qut.MakeTextGo(mgo, centxt, yoff: 0.1f, sfak: 0.1f);
        }
        if (i > 2)
        {
            var pgo = qut.CreatePipe("pipe_" + i, fstpt, lstpt, clr: "blk");
            pgo.transform.SetParent(parent.transform, worldPositionStays: true);
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

    public GameObject GenBld(GameObject parent,OsmBldSpec bs, string clr,float alf=1,bool plotTesselation=false,bool dowalls=true,bool dofloors=true,bool doroof=true,bool dosock=true,float ptscale=1,PolyGenVekMapDel pgvd=null)
    {
        bool onesided = false;
        var wps = true;
        var bldgo = new GameObject(bs.osmname);
        var ska = 1/ptscale;
        var ptcen = bs.GetCenterBottom();
        var probept = new Vector3(ptcen.x, 0, ptcen.z);
        var mappt = pgvd(probept);
        var mapheit = mappt.y;
        if (bs.shortname == "BldRWB")
        {
            Debug.Log("Here I am");
        }
        //bldgo.transform.localScale = new Vector3(ska, ska, ska);
        if (dowalls)
        {
            //Debug.Log($"GenPolyGen.GenBld doing walls for {bldname}");

            StartAccumulatingSegments();
            SetGenForm(PolyGenForm.wallsmesh);
            var wname = $"{bs.osmname}-walls";
            PolyGenVekMapDel npgvd = delegate (Vector3 v) { return Yoffset(v, mapheit); };
            var walgo = GenMesh(wname, height: bs.height, clr: clr, alf: alf, plotTesselation: false, onesided: onesided,pgvd: npgvd);
            walgo.transform.localScale = new Vector3(ska, ska, ska);
            walgo.transform.SetParent(bldgo.transform,worldPositionStays:wps);
        }
        if (doroof)
        {
            //Debug.Log($"GenPolyGen.GenBld doing roof for {bldname}");
            StartAccumulatingSegments();
            SetGenForm(PolyGenForm.tesselate);
            var rname = $"{bs.osmname}-roof";
            var rclr = "darkgreen";
            var rufgo = GenMesh(rname, height: mapheit+bs.height, clr: rclr, alf: alf, plotTesselation: plotTesselation, onesided: onesided,pgvd: null);
            rufgo.transform.localScale = new Vector3(ska, ska, ska);
            rufgo.transform.SetParent(bldgo.transform, worldPositionStays: wps);
        }
        if (dofloors)
        {
            for (int i=1; i<=bs.levels; i++)
            {
                //Debug.Log($"GenPolyGen.GenBld doing floor {i} for {bldname}");
                StartAccumulatingSegments();
                SetGenForm(PolyGenForm.tesselate);
                var fname = $"{bs.osmname}-level-{i}";
                //var fheit = bs.levels<2 ? 0 : (i*bs.height / bs.levels);
                var y = bs.GetFloorHeight(i)+mapheit;
                var flrgo = GenMesh(fname, height: y, clr: clr, alf: alf, plotTesselation: plotTesselation, onesided: onesided, pgvd: null);
                flrgo.transform.localScale = new Vector3(ska, ska, ska);
                flrgo.transform.SetParent(bldgo.transform, worldPositionStays: wps);
            }
        }
        //bldgo.transform.position = GetCenter();
        bldgo.transform.position = Vector3.zero;
        bldgo.transform.SetParent(parent.transform, worldPositionStays: true);
        return bldgo;
    }
    public Vector3 FloorHeight(Vector3 v, OsmBldSpec osmbs, int floor, float mapheit)
    {
        var y = osmbs.GetFloorHeight(floor);
        var rv = new Vector3(v.x, y+mapheit, v.z);
        return rv;
    }

    public Vector3 Yoffset(Vector3 v, float mapheit)
    {
        var rv = new Vector3(v.x, v.y + mapheit, v.z);
        return rv;
    }

    public Vector3 GetCenter()
    {
        var rv = Vector3.zero; ;
        var ptsum = Vector3.zero;
        if (_poutline.Count > 0)
        {
            foreach (var p in _poutline)
            {
                ptsum += p.pt;
            }
            rv = ptsum / _poutline.Count;
        }
        return rv;
    }
    public Vector3 GetCenter(float y)
    {
        var cen = GetCenter();
        var nrv = new Vector3(cen.x, y, cen.z);
        return nrv;
    }

    Vector3[] GetPtsBufArray(PolyGenVekMapDel pgvd = null)
    {
        var rv = new Vector3[ptsbuf.Count];
        int i = 0;
        if (pgvd == null)
        {
            foreach (var p in ptsbuf)
            {
                rv[i++] = p.pt;
            }
        }
        else
        {
            foreach (var p in ptsbuf)
            {
                rv[i++] = pgvd(p.pt);// mapman heights added to points
            }
        }
        return rv;
    }
    public GameObject GetAccumulatedMesh(string meshname, PolyGenVekMapDel pgvd = null)
    {
        var go = new GameObject(meshname);
        var meshRenderer = go.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        var meshFilter = go.AddComponent<MeshFilter>();

        var mesh = new Mesh();
        mesh.vertices = GetPtsBufArray(pgvd);
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

    public void GenCrossOutline(Vector3 cen, float radius)
    {
        var r2 = radius;
        var r1 = 1f;
        var o2 = new List<Vector2>() {
            new Vector2(-r2, -r1), new Vector2(-r2, +r1), new Vector2(-r1, +r1),
            new Vector2(-r1, +r2), new Vector2(+r1, +r2), new Vector2(+r1, +r1),
            new Vector2(+r2, +r1), new Vector2(+r2, -r1), new Vector2(+r1, -r1),
            new Vector2(+r1, -r2), new Vector2(-r1, -r2), new Vector2(-r1, -r1),
        };
        for (int i = 0; i < o2.Count; i++)
        {
            var pt = o2[i];
            AddOutlinePoint(i, pt.y + cen.x, 0 + cen.y, pt.x + cen.z);
        }
    }

    public GameObject GenMesh(string name, float height = 1, string clr = "indigo", float alf = 1, bool plotTesselation = false, bool onesided=false,PolyGenVekMapDel pgvd=null)
    {
        var go = new GameObject(name);
        var pos = GetCenter(height);
        go.transform.position = pos;
        this.wallheight = height;
        this.wallalf = alf;
        this.wallclr = clr;
        Generate(go, plotTesselation,onesided:onesided, pgvd:pgvd);
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
    public void Generate(GameObject parent, bool plotTesselation,bool onesided=false,PolyGenVekMapDel pgvd=null)
    {
        switch (genform)
        {
            case PolyGenForm.pipes:
                {
                    GenerateBySegment(parent, wallheight,onesided:onesided, pgvd:pgvd);
                    break;
                }
            case PolyGenForm.walls:
                {
                    GenerateBySegment(parent, wallheight, onesided: onesided, pgvd: pgvd);
                    break;
                }
            case PolyGenForm.wallsmesh:
                {
                    GenerateBySegment(parent, wallheight, asmesh: true, onesided: onesided, pgvd: pgvd);
                    break;
                }
            case PolyGenForm.tesselate:
                {
                    TesselateYup(parent, wallheight, plotTesselation: plotTesselation, onesided:onesided, pgvd: pgvd);
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
    public class LineSegment2xz
    {

        // stole this from here: https://stackoverflow.com/a/37406831/3458744

        public Vector3 from;
        public Vector3 toto;
        public Vector3 delta;

        public LineSegment2xz(Vector3 from, Vector3 toto)
        {
            this.from = from;
            this.toto = toto;
            this.delta = toto - from;
        }


        public (bool itdid, Vector3 intersectionPoint, float t, float u) TryIntersect(LineSegment2xz other)
        {
            var p = from;
            var q = other.from;
            var qmp = q - p;
            //var r = Delta;
            //var s = other.Delta;
            var r = delta;
            var s = other.delta;

            // t = (q - p) × s / (r × s)
            // u = (q - p) × r / (r × s)

            var denom = r.x*s.z - r.z*s.x;
            var intersectionPoint = Vector3.zero;
            var t = 0f;
            var u = 0f;

            if (denom == 0)
            {
                // lines are collinear or parallel
                t = float.NaN;
                u = float.NaN;
                return (false, intersectionPoint, t, u);
            }

            t = (qmp.x*s.z - qmp.z*s.x) / denom;
            u = (qmp.x*r.z - qmp.z*r.x) / denom;

            if (t <= 0 || t >= 1 || u <= 0 || u >= 1)
            {
                // line segments do not intersect within their ranges
                return (false, intersectionPoint, t, u);
            }

            intersectionPoint = p + r*t;
            return (true, intersectionPoint, t, u);
        }

    }
    static bool IntersectsItself(List<(int id, Vector3 pt)> ptlist)
    {
        var lseglist = new List<LineSegment2xz>();
        int npt = ptlist.Count;
        for(int i=0; i<npt-1; i++)
        {
            var p0 = ptlist[i].pt;
            var p1 = ptlist[i+1].pt;
            var ls = new LineSegment2xz(p0, p1);
            lseglist.Add(ls);
        }
        lseglist.Add(new LineSegment2xz(ptlist[ npt-1 ].pt, ptlist[ 0 ].pt));

        // try all pairs to see if they intersect
        for (int i=0; i<npt; i++)
        {
            var lsi = lseglist[i];
            var idi = ptlist[i].id;
            for (int j=i+1; j<npt; j++)
            {
                var lsj = lseglist[j];
                var idj = ptlist[j].id;
                var (isect, _, t,u) = lsi.TryIntersect(lsj);
                //Debug.Log($"      TryIntersect i:{i}({idi}-{idi+1})  j:{j}({idj}-{idj+1}) isect:{isect}  t:{t}  u:{u}");
                if (isect)
                {
                    return isect;
                }
            }
        }
         return false;
    }

    // Compute barycentric coordinates (u, v, w) for
    // point p with respect to triangle (a, b, c)
    // https://gamedev.stackexchange.com/questions/23743/whats-the-most-efficient-way-to-find-barycentric-coordinates
    static Vector3 Barycentric(Vector3 p, Vector3 a, Vector3 b, Vector3 c)
    {
        Vector3 v0 = b - a, v1 = c - a, v2 = p - a;
        var d00 = Vector3.Dot(v0, v0);
        var d01 = Vector3.Dot(v0, v1);
        var d11 = Vector3.Dot(v1, v1);
        var d20 = Vector3.Dot(v2, v0);
        var d21 = Vector3.Dot(v2, v1);
        var denom = d00 * d11 - d01 * d01;
        if (denom == 0) denom = 1;
        var v = (d11 * d20 - d01 * d21) / denom;
        var w = (d00 * d21 - d01 * d20) / denom;
        var u = 1.0f - v - w;
        var rv = new Vector3(v, w, u);
        return rv;
    }

    static (bool isInside,Vector3 bc) PointInsideTriangle(Vector3 p, Vector3 a, Vector3 b, Vector3 c)
    {
        var bc = Barycentric(p, a, b, c);
        if (bc.x < 0 || 1 < bc.x) return (false, bc);
        if (bc.y < 0 || 1 < bc.y) return (false, bc);
        if (bc.z < 0 || 1 < bc.z) return (false, bc);
        return (true,bc);
    }
    static bool CheckAllOtherPointsOutsideTriangle(List<(int id, Vector3 pt)> ptlist, int i0, int i1, int i2, bool dbout = true)
    {
        var v0 = ptlist[i0].pt;
        var v1 = ptlist[i1].pt;
        var v2 = ptlist[i2].pt;
        for (int i = 0; i < ptlist.Count; i++)
        {
            if (i == i0 || i == i1 || i == i2) continue;
            var v = ptlist[i].pt;
            var (isInside,bc) = PointInsideTriangle(v, v0, v1, v2);
            //if (dbout && isInside)
            //if (isInside)
            //{
            //    Debug.Log($"CheckAllOtherPointsOutsideTriangle Point inside {i1} - rejecting");
            //}
            if (isInside) return false;
        }
        return true;
    }
    public static (float val, int idx) FindSmallestPositiveCrossProductYcomponent(GameObject parent, List<(int id,Vector3 pt)> ptlist,bool dbout=false)
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
                var ok = CheckAllOtherPointsOutsideTriangle(ptlist, i0, i1, i2, dbout: dbout);
                if (!ok)
                {
                    //Debug.Log($"{parent.name} point {i} offsides");
                    continue;
                }
                cpvalmin = cpval;
                cpvalminidx = i;
            }

            // need to make sure all the other points fall outside of the v0-v1-v2 triangle now
        }
        if (dbout)
        {
            Debug.Log($"FSPCP cpvalmin:{cpvalmin} idx:{cpvalminidx}");
        }
        return (cpvalmin, cpvalminidx);
    }

    GameObject GetLevParent(GameObject parent,int lev,float height)
    {
        var go = new GameObject($"lev-{lev}");
        go.transform.position = new Vector3(0, height, 0);
        go.transform.SetParent( parent.transform, worldPositionStays:true );
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
    void AddTesselatedTriangle(Vector3 w0,Vector3 w1,Vector3 w2, int i0, int i1, int i2, bool onesided)
    {
        //Debug.Log($"ATT: w0:{w0:f2} w1:{w1:f2} w2:{w2:f2}  i0:{i0} i1:{i1} i2:{i2} onsided:{onesided}");
        var pidx = ptsbuf.Count;
        ptsbuf.Add((i0, w0));
        ptsbuf.Add((i1, w1));
        ptsbuf.Add((i2, w2));
        tribuf.Add(pidx);
        tribuf.Add(pidx + 1);
        tribuf.Add(pidx + 2);
        if (!onesided)
        {
            pidx = ptsbuf.Count;
            ptsbuf.Add((i0, w0));
            ptsbuf.Add((i1, w1));
            ptsbuf.Add((i2, w2));
            tribuf.Add(pidx);
            tribuf.Add(pidx + 2);
            tribuf.Add(pidx + 1);
        }

    }
    public GameObject TesselateYup(GameObject parent,float height,bool onesided=false, bool plotTesselation = false, PolyGenVekMapDel pgvd = null)
    {
        var eps = 1e-3f;
        int lev = 0;

        int starcnt = _poutline.Count;
        var woutline = RemoveAdjacentEquals( GetOutline(),eps);
        //if (parent.name.StartsWith("Microsoft Cafe 16"))
        //{
        //    Debug.Log("Have a coffee");
        //}
        if (_poutline.Count < 3)
        {
            Debug.LogError($"Error tesselating building {parent.name}");
            Debug.LogError($"Not enough distinct points:{woutline.Count} to tesselate - count before dup removal:{_poutline.Count}");
            return null;
        }
        var area = CalcAreaWithYup(woutline);
        var dbheight = height + 0.5f;
        int iclr = 0;
        if (plotTesselation)
        {
            var centxt = $"Lev:{lev} Area:{area:f2}";
            var clr = qut.GetColorBySeq(iclr++);
            var levpar = GetLevParent(parent, lev++, dbheight);
            PlotOutline(levpar, woutline, centxt, dbheight, clr);
            dbheight += 2;
        }
        reverseOpps++;
        if (area==0)
        {
            Debug.LogWarning("Cannot tesselate zero area polygon - terminating tesselation");
            var go1 = GetAccumulatedMesh("accumesh",pgvd);
            go1.transform.SetParent( parent.transform, worldPositionStays:true );
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
                var centxt = $"Lev:{lev} Rev Area:{area:f2}";
                var clr = qut.GetColorBySeq(iclr++);
                var levpar = GetLevParent(parent, lev++, dbheight);
                PlotOutline(levpar, woutline, centxt, dbheight, clr);
                dbheight += 2;
            }
            Debug.Log($"new area:{area}");
        }
        var (maxval, maxidx) = FindSmallestPositiveCrossProductYcomponent(parent,woutline);
        StartAccumulatingSegments();
        var fmaxidx = maxidx;

        int iter = 0;
        int maxiter = woutline.Count+10;
        int iwarn = 0;
        var isect = IntersectsItself(woutline);
        if (isect && iwarn == 0)
        {
            Debug.LogWarning($"{parent.name} woutline lev:{lev} intersects itself in Tesselate iter:{iter} woutline.count:{woutline.Count}");
            iwarn++;
        }
        while (true && iter<maxiter)
        {
            if (plotTesselation)
            {
                Debug.Log($"Starting lev:{lev} with woutline.Count:{woutline.Count}");
            }
            //else
            //{
            //    Debug.Log($"woutline lev:{lev} does not intersect itself in Tesselate iter:{iter} woutline.count:{woutline.Count}");
            //}
            var i0 = moduloInc(maxidx, -1, woutline.Count);
            var i1 = maxidx;
            var i2 = moduloInc(maxidx, +1, woutline.Count);
            var v0 = woutline[i0].pt;
            var v1 = woutline[i1].pt;
            var v2 = woutline[i2].pt;
            var w0 = new Vector3(v0.x, height, v0.z);
            var w1 = new Vector3(v1.x, height, v1.z);
            var w2 = new Vector3(v2.x, height, v2.z);
            if (plotTesselation)
            {
                var clr = qut.GetColorBySeq(iclr++);
                var centxt = $"Lev:{lev} Remove pt:{woutline[i1].id}";
                var levpar = GetLevParent(parent, lev, dbheight);
                PlotOutline(levpar, woutline, centxt,   dbheight, clr);
                dbheight += 2;
                var maxidxid = woutline[maxidx].id;
                Debug.Log($"Slicing out {maxidx}({maxidxid}) val:{maxval} ptsleft:{woutline.Count}");

                PlotTri(levpar, v0, v1, v2, "", height, clr);
                var v1s = v1.ToString("f3");
                Debug.Log($"Removing at {i1} - v1:{v1s} woutline.Count:{woutline.Count}");
                lev++;
            }
            woutline.RemoveAt(i1);
            AddTesselatedTriangle( w0,w1,w2, i0,i1,i2, onesided );
            if (woutline.Count < 3) break; // done

            (maxval, maxidx) = FindSmallestPositiveCrossProductYcomponent(parent,woutline);
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
                (maxval, maxidx) = FindSmallestPositiveCrossProductYcomponent(parent,woutline, dbout: true);
                Debug.LogError($"{parent.name} Tesselate maxidx is -1 - breaking tesselation  startarea:{area:g3} fmaxidx:{fmaxidx}");
                break;
            }
            iter++;
        }
        var go = GetAccumulatedMesh("accumesh",pgvd);
        go.transform.parent = parent.transform;
        return go;
    }

    public void GenerateBySegment(GameObject parent,float height,bool asmesh=false, bool onesided=false,PolyGenVekMapDel pgvd=null)
    {
        if (_poutline.Count <= 1)
        {
            Debug.LogError("BldPolyGenForm can not generate with less than two points");
            return;
        }
        if (asmesh)
        {
            StartAccumulatingSegments();
        }
        var woutline = GetOutline(); ;
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
            //if (pgvd!=null)
            //{
            //    pt1 = pgvd(pt1);
            //    pt2 = pgvd(pt2);
            //}
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
            var go = GetAccumulatedMesh("accumesh",pgvd);
            go.transform.parent = parent.transform;
        }
    }
}
