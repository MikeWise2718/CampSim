using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aiskwk.Map;
using UnityEngine.UIElements;
using System.Text;
using System.Linq;

public enum BldPolyGenForm { pipes, walls }
public class BldPolyGen
{

    private List<Vector3> outline;
    private BldPolyGenForm genform;
    private float height = 1f;
    private float alf = 1f;
    private string clr;

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

    public GameObject GenCircle(string name, Vector3 cen, int nseg, float radius, float height=1, float ripple=0,string clr="indigo",float alf=1)
    {
        var go = new GameObject(name);
        this.height = height;
        this.alf = alf;
        this.clr = clr;
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
            tris = new int[] { 0, 1, 2, 2, 1, 3, 1 + 4, 0 + 4, 2 + 4, 1 + 4, 2 + 4, 3 + 4 };
            uv = new Vector2[] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1) };
        }
        mesh.vertices = vertices;
        mesh.triangles = tris;
        mesh.uv = uv;
        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;
        qut.SetColorOfGo(go, clr, alf);
        return go;
    }

    public GameObject CreateForm(string frmname,Vector3 pt0, Vector3 pt1)
    {
        GameObject rv=null;
        switch (genform)
        {
            case BldPolyGenForm.pipes:
                {
                    var pt2 = new Vector3(pt0.x, height, pt0.z);
                    var pt3 = new Vector3(pt1.x, height, pt1.z);
                    rv = Create4ptQuad(frmname, pt0, pt1, pt2, pt3, clr: clr, alf: alf);
                    break;
                }
            case BldPolyGenForm.walls:
                {
                    rv = qut.CreatePipe(frmname, pt0, pt1, clr: clr, alf:alf);
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
                    GenerateBySegment(parent);
                    break;
                }
            case BldPolyGenForm.walls:
                {
                    GenerateBySegment(parent);
                    break;
                }
        }
    }

    public void GenerateBySegment(GameObject parent)
    {
        if (outline.Count <= 1)
        {
            Debug.LogError("BldPolyGenForm can not generate with less than two points");
            return;
        }

        int i1 = 0;
        int i2 = i1 + 1;
        int nsegdone = 0;
        while (nsegdone<outline.Count)
        {
            var pt1 = outline[i1];
            var pt2 = outline[i2];
            var pname = $"seg-{i1}";
            var go = CreateForm(pname, pt1, pt2);
            go.transform.parent = parent.transform;
            i1 = i2;
            i2 = i1 + 1;
            if (i2 == outline.Count) i2 = 0;
            nsegdone++;
        }
    }
}
