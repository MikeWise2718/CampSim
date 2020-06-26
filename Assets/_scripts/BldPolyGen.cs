using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aiskwk.Map;
using UnityEngine.UIElements;
using System.Text;
using System.Linq;
using UnityEngine.AI;

public enum BldPolyGenForm { pipes, walls, wallsmesh }
public class BldPolyGen
{

    private List<Vector3> outline;
    private BldPolyGenForm genform;
    private float wallheight = 1f;
    private float wallalf = 1f;
    private string wallclr;

    public BldPolyGen()
    {
        outline = new List<Vector3>();
    }

    public void AddOutlinePoint(Vector3 pt)
    {
        outline.Add(pt);
    }
    public void AddOutlinePoint(float x,float y, float z)
    {
        outline.Add(new Vector3(x,y,z));
    }

    List<Vector3> ptsbuf=null;
    List<int> tribuf=null;
    List<Vector2> uvbuf = null;
    int iseg;

    public void StartAccumulatingSegments()
    {
        ptsbuf = new List<Vector3>();
        tribuf = new List<int>();
        uvbuf = new List<Vector2>();
        iseg = 0;
    }
    public void NormalizeUvbuf()
    {
        var newuvbuf = new List<Vector2>();
        var nseg = uvbuf.Count / 2;
        for (int i = 0; i < nseg; i++ )
        {
            Vector2 v2 = uvbuf[i];
            var newv2 = new Vector2(v2.x / nseg, v2.y);
            newuvbuf.Add(newv2);
        }
        uvbuf = newuvbuf;
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
        ptsbuf.Add(pt0);
        ptsbuf.Add(pt1);
        ptsbuf.Add(pt2h);
        ptsbuf.Add(pt3h);

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
            ptsbuf.Add(pt0);
            ptsbuf.Add(pt1);
            ptsbuf.Add(pt2h);
            ptsbuf.Add(pt3h);

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

    public GameObject GetAccumulatedMesh(string meshname)
    {
        var go = new GameObject(meshname);
        MeshRenderer meshRenderer = go.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        MeshFilter meshFilter = go.AddComponent<MeshFilter>();

        Mesh mesh = new Mesh();
        mesh.vertices = ptsbuf.ToArray();
        mesh.triangles = tribuf.ToArray();
        NormalizeUvbuf();
        mesh.uv = null;
        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;
        qut.SetColorOfGo(go, wallclr, wallalf);
        var ntris = tribuf.Count / 3;
        Debug.Log($"mesh has {ptsbuf.Count} vertices and {ntris} triangles");
        return go;
    }

    public GameObject GenCylinderBuilding(string name, Vector3 cen, int nseg, float radius, float height=1, float ripple=0,string clr="indigo",float alf=1)
    {
        var go = new GameObject(name);
        this.wallheight = height;
        this.wallalf = alf;
        this.wallclr = clr;
        for (int i = 0; i < nseg; i++)
        {
            var angdeg = (360f*i) / nseg;
            var ang = Mathf.PI * angdeg / 180;
            //Debug.Log($"i:{i} angdeg:{angdeg}  ang:{ang}");
            var x = radius * Mathf.Sin(ang)  + cen.x;
            var ripoff = ripple * Mathf.Sin(ang);
            var y = cen.y + ripoff*ripoff;
            var z = radius * Mathf.Cos(ang)  + cen.z;
            AddOutlinePoint(x, y, z);
        }
        Generate(go);
        return go;
    }


    public void SetGenForm(BldPolyGenForm genform)
    {
        this.genform = genform;
    }


    //public static GameObject CreatePipe(string pname, Vector3 frpt, Vector3 topt, float size = 0.1f, string clr = "yellow", float alf = 1)

    public GameObject Create4ptQuad(string qname, Vector3 pt0, Vector3 pt1, Vector3 pt2, Vector3 pt3, string clr = "blue",float alf=1, bool onesided = false )
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
            tris = new int[] { 0,1,2, 2,1,3, 1+4,0+4,2+4, 1+4,2+4,3+4 };
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

    public GameObject CreateForm(string frmname,Vector3 pt0, Vector3 pt1,float height)
    {
        GameObject rv=null;
        switch (genform)
        {
            default:
            case BldPolyGenForm.walls:
                {
                    var pt2 = new Vector3(pt0.x, height, pt0.z);
                    var pt3 = new Vector3(pt1.x, height, pt1.z);
                    rv = Create4ptQuad(frmname, pt0, pt1, pt2, pt3, clr: wallclr, alf: wallalf);
                    break;
                }
            case BldPolyGenForm.pipes:
                {
                    rv = qut.CreatePipe(frmname, pt0, pt1, clr: wallclr,size:height, alf:wallalf);
                    break;
                }
        }
        return rv;
    }
    public void Generate(GameObject parent)
    {
        switch (genform)
        {
            case BldPolyGenForm.pipes:
                {
                    GenerateBySegment(parent,wallheight);
                    break;
                }
            case BldPolyGenForm.walls:
                {
                    GenerateBySegment(parent,wallheight);
                    break;
                }
            case BldPolyGenForm.wallsmesh:
                {
                    GenerateBySegment(parent,wallheight,asmesh:true);
                    break;
                }
        }
    }

    public void GenerateBySegment(GameObject parent,float height,bool asmesh=false)
    {
        if (outline.Count <= 1)
        {
            Debug.LogError("BldPolyGenForm can not generate with less than two points");
            return;
        }
        if (asmesh)
        {
            StartAccumulatingSegments();
        }
        int i1 = 0;
        int i2 = i1 + 1;
        int nsegdone = 0;
        while (nsegdone<outline.Count)
        {
            var pt1 = outline[i1];
            var pt2 = outline[i2];
            var pname = $"seg-{i1}";
            if (!asmesh)
            {
                var go = CreateForm(pname, pt1, pt2, height);
                go.transform.parent = parent.transform;
            }
            else
            {
                AddSegment(pt1, pt2,height,onesided:false);
            }
            i1 = i2;
            i2 = i1 + 1;
            if (i2 == outline.Count) i2 = 0;
            nsegdone++;
        }
        if (asmesh)
        {
            var go = GetAccumulatedMesh("accumesh");
            go.transform.parent = parent.transform;
        }
    }
}
