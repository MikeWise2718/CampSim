using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;

public class InfoPanel : MonoBehaviour
{
    SceneMan sman;
    VidcamMan vman;
    JourneyMan jman;
    GarageMan gman;
    LocationMan locman;
    Text sysText;
    Text simText;
    Text geoText;
    Text mscText;

    GameObject trackedObject = null;

    // Start is called before the first frame update
    void Start()
    {
        LinkObjectsAndComponents();
        Init();
    }

    public void ComplainIfNull(object oman,string tname,string oname)
    {
        if (oman==null)
        {
            Debug.LogError($"{oname} of type {tname} is null");
        }
    }
    public void LinkObjectsAndComponents()
    {
        sman = FindObjectOfType<SceneMan>();
        jman = FindObjectOfType<JourneyMan>();
        gman = FindObjectOfType<GarageMan>();
        vman = FindObjectOfType<VidcamMan>();
        ComplainIfNull(sman, "SceneMan", "sman");
        ComplainIfNull(jman, "JourneyMan", "jman");
        ComplainIfNull(gman, "GarageMan", "gman");
        ComplainIfNull(vman, "VidcamMan", "vman");

        trackedObject = Camera.main?.gameObject;


        sysText = transform.Find("SysText")?.GetComponent<Text>();
        simText = transform.Find("SimText")?.GetComponent<Text>();
        geoText = transform.Find("GeoText")?.GetComponent<Text>();
        mscText = transform.Find("MscText")?.GetComponent<Text>();

        locman = FindObjectOfType<LocationMan>();

        //Debug.Log("assigned sysText and simText");
    }
    void Init()
    {

        var arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        sysText.font = arial;
        sysText.fontSize = 24;
        sysText.alignment = TextAnchor.MiddleLeft;
        sysText.verticalOverflow = VerticalWrapMode.Overflow;

        simText.font = arial;
        simText.fontSize = 24;
        simText.alignment = TextAnchor.MiddleLeft;
        simText.verticalOverflow = VerticalWrapMode.Overflow;

        geoText.font = arial;
        geoText.fontSize = 24;
        geoText.alignment = TextAnchor.MiddleLeft;
        geoText.verticalOverflow = VerticalWrapMode.Overflow;

        mscText.font = arial;
        mscText.fontSize = 24;
        mscText.alignment = TextAnchor.MiddleLeft;
        mscText.verticalOverflow = VerticalWrapMode.Overflow;
    }


    float smoothedDeltaTime = 0.0f;
    int updatecount;
    float lastupdate=-1;
    void UpdateInfoPanel()
    {
        if (Time.time - lastupdate < 0.25f) return;

        var msg = vman.lastcamset + "\n";
        msg += "Jny:" + jman.njnys + " Sspn:"+jman.nspawned+" Fspn:"+jman.nspawnfails+"\n";

        smoothedDeltaTime += (Time.unscaledDeltaTime - smoothedDeltaTime) * 0.1f;
        float fps = 1.0f / smoothedDeltaTime;
        float msec = smoothedDeltaTime * 1000.0f;
        var simtime = Time.time.ToString("f1");
        var gcmem = (float)(System.GC.GetTotalMemory(false) / 1e6);
        string fpstext = string.Format(" {0:0.0} ms\n {1:0.0} fps GC:{2:0.0} mb", msec, fps,gcmem);
        msg += "Upd:" + updatecount+" Sim:"+simtime+" "+fpstext;
        simText.text = msg;
        updatecount++;

        if (trackedObject!=null)
        {
            var pos = Vector3.zero;
            if (trackedObject!=null)
            {
                pos = trackedObject.transform.position;
            }
            var fwd = Vector3.zero;
            if (Camera.main != null)
            {
                fwd = Camera.main.transform.forward;
            }
            string txt = "";
            txt += "Pos:" + pos.x.ToString("f2") + " " + pos.y.ToString("f2") + " " + pos.z.ToString("f2")+"\n";
            txt += "Fwd:" + fwd.x.ToString("f2") + " " + fwd.y.ToString("f2") + " " + fwd.z.ToString("f2");
            sysText.text = txt;
        }
        if (locman!=null)
        {
            var loc = locman.GetLoc();
            var ori = locman.GetLocState();
            var gyr = locman.GetGyro();
            string txt="";
            txt += ori + "\n" + 
                    loc.x.ToString("F6") +" " + loc.y.ToString("F1") +" "+ loc.z.ToString("F6") + "\n";
            txt += gyr.w.ToString("F3") + " " + gyr.x.ToString("F3") + " " + gyr.y.ToString("F3") + " " + gyr.z.ToString("F3") + "\n";
            geoText.text = txt;
        }
        var mmsg = "Reg:"+sman.curscene + "\n";
        mmsg += System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss zzz\n");
        mmsg += "P:" + sman.psman.GetPersonCount()+ " V:" + sman.veman.GetVehicleCount()+
                " B:"+sman.bdman.GetBuildingCount() + " BR:" + sman.bdman.GetBroomCount() + " VC:" + sman.vcman.GetVidcamCount();
        mscText.text = mmsg;

    }
    private void Update()
    {
        UpdateInfoPanel();
    }
}
