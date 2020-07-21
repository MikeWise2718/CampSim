using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibMan : MonoBehaviour
{
    public bool showText=true;
    public Vector3 org;
    public List<CalibMarker> markers = new List<CalibMarker>();
    // Start is called before the first frame update
    void Start()
    {
        showText = true;
    }


    public void AddCalibMarker(string name,double x, double y, double z,string clrname)
    {
        var go = new GameObject(name);
        go.transform.position = new Vector3((float)x, (float)y, (float)z);
        go.transform.parent = this.gameObject.transform;
        var bcs = go.AddComponent<CalibMarker>();
        bcs.Init(this, go,clrname);
        markers.Add(bcs);
    }
    public void RefreshGos()
    {
        //Debug.Log("CalibMan-RefreshGos markers:" + markers.Count);
        DeleteGos();
        CreateGos();
    }

    public void DeleteGos()
    {
        foreach( var m in markers)
        {
            m.DeleteGos();
        }
    }
    public void CreateGos()
    {
        foreach (var m in markers)
        {
            m.CreateGos();
        }
    }

}
