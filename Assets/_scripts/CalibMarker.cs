using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibMarker : MonoBehaviour
{
    // Start is called before the first frame update
    public CalibMan cman;
    Vector3 screenmid;
    void Start()
    {
        //Debug.Log("Hello - starting "+name);
        screenmid = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    }


    public Vector3 worldPt;
    public Vector3 normWorldPt;
    public Vector3 screenPt;
    public Vector3 normScreenPt;
    Vector3 lastwpt;
    Vector3 lastspt;

    string clrname;
    GameObject go;

    GameObject sgo=null;

    public void Init(CalibMan cman,GameObject go,string clrname)
    {
        this.cman = cman;
        this.go = go;
        this.clrname = clrname;
    }
    string fmtpt(Vector3 pt, int decpt)
    {
        var fmt = "f" + decpt;
        var s = pt.x.ToString(fmt) + " " + pt.y.ToString(fmt) + " " + pt.z.ToString(fmt);
        return s;
    }
    public void MakeTextGo(string text,float yoff,float backoff=0.01f,float sfak=0.3f)
    {
        var tar = text.Split('\n');
        var txwid = 0;
        foreach(var s in tar)
        {
            txwid = Mathf.Max(txwid, s.Length);
        }
        var txheit = tar.Length;

        var bgo = GameObject.CreatePrimitive(PrimitiveType.Quad);
        bgo.name = name + "-bck";
        bgo.transform.position = sgo.transform.position;
        bgo.transform.localPosition += new Vector3(0, yoff, 0);
        bgo.transform.localPosition += Camera.main.transform.forward * backoff;
        bgo.transform.localScale = new Vector3( 0.8f*txwid*sfak, (txheit+0.8f)*sfak, sfak );
        bgo.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        bgo.transform.parent = sgo.transform;
        GraphAlgos.GraphUtil.SetColorOfGo(bgo, "white");

        var tgo = new GameObject(name + "-tmp");
        tgo.transform.position = sgo.transform.position;
        var tm = tgo.AddComponent<TMPro.TextMeshPro>();
        int linecount = text.Split('\n').Length;
        //tm.text = "<mark=#000000>"+text+"</mark>"; // this only works with an alpha of less than 1
        tm.text = text;
        tm.fontSize = 14;
        tm.alignment = TMPro.TextAlignmentOptions.Center;
        tgo.transform.localScale = new Vector3(sfak, sfak, sfak);
        tgo.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        tgo.transform.localPosition += new Vector3(0, yoff, 0);
        tgo.transform.SetParent(sgo.transform);
        tm.color = GraphAlgos.GraphUtil.GetColorByName("darkblue");
        tm.alpha = 1.0f; // this has to stay at the end or it gets overwritten !!

    }
    public void CreateGos()
    {
        sgo = GraphAlgos.GraphUtil.CreateMarkerSphere(name, go.transform.position, clr: clrname, size: 0.4f);
        sgo.transform.parent = go.transform;
        if (cman.showText)
        {
            UpdateCoords();
            var text = name + "\n" + "wp:" + fmtpt(normWorldPt,3);
            text = name;
            MakeTextGo(text, yoff: 0.5f);
        }
    }
    public void DeleteGos()
    {
        Destroy(sgo);
        sgo = null;
    }
    public void UpdateCoords()
    {
        worldPt = transform.position;
        screenPt = Vector3.zero;
        normScreenPt = Vector3.zero;
        if (Camera.main != null)
        {
            screenPt = Camera.main.WorldToScreenPoint(worldPt);
            normScreenPt = Camera.main.WorldToScreenPoint(worldPt) - screenmid;
        }
        normWorldPt = worldPt - cman.org;
        var dist = Vector3.Distance(screenPt, lastspt);
        if (dist > 0.1)
        {
            lastwpt = worldPt;
            //if (updatecount > 0)
            //{
            //    //Debug.Log(name+"  wpt:" + fmtpt(worldPt, 2) + "  scn:" + fmtpt(screenPt, 3)+"  normscn:"+fmtpt(normScreenPt, 3));
            //}
            lastspt = screenPt;
        }
    }
//    int updatecount = 0;
//    void Update()
//    {
////        updatecount++;
//    }
}
