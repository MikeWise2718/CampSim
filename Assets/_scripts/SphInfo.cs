using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aiskwk.Map;


[System.Serializable]
public struct TextureCoord
{
    public float u;
    public float v;
    public TextureCoord(float u, float v)
    {
        this.u = u;
        this.v = v;
    }
}

[System.Serializable]
public struct MeshCoord
{
    public int i;
    public int j;
    public MeshCoord(int i, int j)
    {
        this.i = i;
        this.j = j;
    }
}

[System.Serializable]
public class SphNodeInfo
{
    public MeshCoord meshCoord;
    public Vector3 vertCoord;
    public TextureCoord textureCoord;

}

public class SphInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public LatLng latLng = null;
    public SphNodeInfo nodeInfo = null;
    public MapCoordPoint mapPoint = null;

    public static SphInfo DoInfoSphere(GameObject parent, string sname, Vector3 pos, float ska, string color, LatLng ll = null)
    {
        var sph = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sph.name = sname;
        sph.transform.parent = parent.transform;
        sph.transform.position = pos;
        sph.transform.localScale = new Vector3(ska, ska, ska);
        GraphAlgos.GraphUtil.SetColorOfGo(sph, color);
        var spi = sph.AddComponent<SphInfo>();
        spi.latLng = ll;
        spi.nodeInfo = null;
        return spi;
    }

    //void Start()
    //{

    //}


    //// Update is called once per frame
    //void Update()
    //{

    //}
}
