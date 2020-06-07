using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;

public class InfoPanel : MonoBehaviour
{
    public SceneMan sman;
    VidcamMan vman;
    JourneyMan jman;
    GarageMan gman;
    LocationMan locman;
    Text sysText;
    Text simText;
    Text geoText;
    Text mscText;

    GameObject trackedObject = null;

    public void Init0()
    {
        LinkObjectsAndComponents();
        InitoInfoPanels();
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
        jman = sman.jnman;
        gman = sman.gaman;
        vman = sman.vcman;
        locman = sman.loman;

        ComplainIfNull(sman, "SceneMan", "sman");
        ComplainIfNull(jman, "JourneyMan", "jman");
        ComplainIfNull(gman, "GarageMan", "gman");
        ComplainIfNull(vman, "VidcamMan", "vman");


        sysText = transform.Find("SysText")?.GetComponent<Text>();
        simText = transform.Find("SimText")?.GetComponent<Text>();
        geoText = transform.Find("GeoText")?.GetComponent<Text>();
        mscText = transform.Find("MscText")?.GetComponent<Text>();

        
        //Debug.Log("assigned sysText and simText");
    }
    void InitoInfoPanels()
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

        trackedObject = vman.GetCurrentCamera()?.gameObject;

        var msg = $"{vman.lastcamset}\nJny:{jman.njnys} Sspn:{jman.nspawned} Fspn:{jman.nspawnfails}\n";

        smoothedDeltaTime += (Time.unscaledDeltaTime - smoothedDeltaTime) * 0.1f;
        float fps = 1.0f / smoothedDeltaTime;
        float msec = smoothedDeltaTime * 1000.0f;
        var simtime = Time.time.ToString("f1");
        var gcmem = (float)(System.GC.GetTotalMemory(false) / 1e6);
        var lod = sman.mpman.GetLod();
        string extext = $" {msec:0.0} ms\nlod:{lod} {fps:0.0} fps GC:{gcmem:0.0} mb";
        if (Aiskwk.Map.QmapMesh.isLoading)
        {
            var (isLoading, irupt, lodLoading, nbmLoaded, nbmToLoad, nelevBatchesLoaded, nelevBatchsToLoad) = sman.mpman.GetLoadingStatus();
            extext = $"\nlod:{lodLoading} Bitmaps:{nbmLoaded}/{nbmToLoad} Elev:{nelevBatchesLoaded}/{nelevBatchsToLoad}";
            if (irupt)
            {
                extext = $"IRPUT {extext}";
            }
        }
        var (refresh, totrefresh, _) = sman.GetRefreshStatus();
        msg += $"Upd:{updatecount} Sim:{simtime} {extext}";
        if (totrefresh)
        {
            msg += " TR";
        }
        else if (refresh)
        {
            msg += " R";
        }
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
            //txt += "Pos:" + pos.x.ToString("f2") + " " + pos.y.ToString("f2") + " " + pos.z.ToString("f2")+"\n";
            txt += $"Pos:{pos.x,4:f2} {pos.y,4:f2} {pos.z,4:f2}  vt2d:{sman.frman.visibilityTiedToDetectability.Get()}\n";
            //txt += "Fwd:" + fwd.x.ToString("f2") + " " + fwd.y.ToString("f2") + " " + fwd.z.ToString("f2");
            txt += $"Fwd:{fwd.x,4:f2} {fwd.y,4:f2} {fwd.z,4:f2}\n";
            sysText.text = txt;
        }
        if (locman!=null)
        {
            var loc = locman.GetLoc();
            var ori = locman.GetLocState();
            var gyr = locman.GetGyro();
            string txt="";
            txt += ori + $"\n{loc.x:f6} {loc.y:f1} {loc.z:f6}\n";
            txt += $"{gyr.w:f3} {gyr.x:f3} {gyr.y:f3} {gyr.z:f3}\n";
            geoText.text = txt;
        }
        var mmsg = "Reg:"+sman.curscene + "\n";
        mmsg += System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss zzz\n");
        mmsg += $"P:{sman.psman.GetPersonCount()} V:{sman.veman.GetVehicleCount()} "+
                $"B:{sman.bdman.GetBuildingCount()} BR:{sman.bdman.GetBroomCount()} VC:{sman.vcman.GetVidcamCount()}\n"+
                $"{GraphAlgos.GraphUtil.GetVersionString()}";
        mscText.text = mmsg;

    }
    private void Update()
    {
        UpdateInfoPanel();
    }
}
