﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;
using System.Runtime.InteropServices;

public class InfoPanel : MonoBehaviour
{
    public SceneMan sman;
    UiMan uiman;
    VidcamMan vman;
    JourneyMan jman;
    GarageMan gman;
    LocationMan locman;

    Text sysText;
    Text simText;
    Text geoText;
    Text mscText;

    GameObject trackedObject = null;
    Aiskwk.Map.Viewer viewer = null;

    public void Init0()
    {
        LinkObjectsAndComponents();
        InitoInfoPanels();
    }

    public Text GetComp<Text>(GameObject go,string cname,string caller="")
    {
        var ngo = transform.Find(cname);
        if (ngo == null)
        {
            Debug.LogWarning($"Cloud not find component named {cname} in {caller}");
            return default(Text);
        }
        return ngo.GetComponent<Text>();// there is a warning that this is not a Unity component, but it works, so it must be?
    }

    public void LinkObjectsAndComponents()
    {
        uiman = sman.uiman;
        jman = sman.jnman;
        gman = sman.gaman;
        vman = sman.vcman;
        locman = sman.loman;

        var tgo = this.gameObject;
        sysText = GetComp<Text>(tgo, "SysText", "InfoPanel");
        simText = GetComp<Text>(tgo, "SimText", "InfoPanel");
        geoText = GetComp<Text>(tgo, "GeoText", "InfoPanel");
        mscText = GetComp<Text>(tgo, "MscText", "InfoPanel");
        //sysText = transform.Find("SysText")?.GetComponent<Text>();
        //simText = transform.Find("SimText")?.GetComponent<Text>();
        //geoText = transform.Find("GeoText")?.GetComponent<Text>();
        //mscText = transform.Find("MscText")?.GetComponent<Text>();


        //Debug.Log("assigned sysText and simText");
    }

    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
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

    float lastCountSaveTime;
    int savecnt = 0;
    (int nexist,int nenabled) CountColliders()
    {
        var collid = GameObject.FindObjectsOfType<Collider>();
        //if (Time.time - lastCountSaveTime > 5 && savecnt==0)
        //{
        //    var collidlist = new List<string>();
        //    int i = 0;
        //    foreach (var c in collid)
        //    {
        //        var eflag = "";
        //        if (c.enabled)
        //        {
        //            eflag = "enabled";
        //        }
        //        var line = $"{i} - {c.name}  - {eflag}";
        //        collidlist.Add(line);
        //        i++;
        //    }
        //    GraphAlgos.GraphUtil.writeListToFile(collidlist, "collidlist.txt");
        //    lastCountSaveTime = Time.time;
        //    savecnt++;
        //}
        var nenabled = 0;
        foreach (var c in collid)
        {
            if (c.enabled)
            {
                nenabled++;
            }
        }

        var ncolliders = collid.Length;
        return (ncolliders,nenabled);
    }

    float smoothedDeltaTime = 0.0f;
    int updatecount;
    float lastupdate=-1;
    void UpdateInfoPanel()
    {
        if (Time.time - lastupdate < 0.33f) return;

        var curcam = vman.GetCurrentCamera();
        trackedObject = null;
        if (curcam != null)
        {
            trackedObject = curcam.gameObject;
        }
        if (viewer==null)
        {
            viewer = FindObjectOfType<Aiskwk.Map.Viewer>();
        }

        var msg = $"{vman.lastcamset} VPK:{Aiskwk.Map.Viewer.ViewerProcessKeys}\n";
        msg += $"Jny:{jman.njnys} Sspn:{jman.nspawned} Fspn:{jman.nspawnfails}\n";

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
        var (gogen, _, _) = sman.lcman.GetNodeLinkCounts();
        msg += $"Upd:{updatecount} Sim:{simtime} {extext}";
        if (totrefresh)
        {
            msg += $" TR {gogen+1}";
        }
        else if (refresh)
        {
            msg += $" R {gogen}";
        }
        else
        {
            msg += $" {sman.lastRefreshTime:f3}";
        }
        simText.text = msg;
        updatecount++;

        if (trackedObject!=null)
        {
            var pos = Vector3.zero;
            var rot = Vector3.zero;
            if (trackedObject!=null)
            {
                pos = trackedObject.transform.position;
            }
            var fwd = Vector3.zero;
            var txtyang = "";;
            if (viewer!=null)
            {
                txtyang = $" yang:{viewer.bodyPlaneRotation.eulerAngles.y:f1}";
            }
            string txt = "";
            string txtalt = "";
            string txtpancam = "";
            if (viewer!=null)
            {
                txtalt = $" AB:{viewer.altbase} A:{viewer.altitude:f1}";
                var vcc = viewer.carriageControlOn;
                var npcams = viewer.carriageMons.Count;
                txtpancam = $"ncam:{npcams} - ";
                for(int i=0; i<npcams; i++)
                {
                    var mon = viewer.carriageMons[i];
                    var activecode = "?";
                    try
                    {
                        var disp = Display.displays[mon-1];
                        activecode = disp.active ? "A" : "D";
                    }
                    catch (System.Exception) { }
                    txtpancam += $" {mon}:{activecode}";
                }
                var cc = viewer.carriageControlOn ? "cc" : "  ";
                txtpancam = $"{txtpancam}:{cc}\n";
            }
            //txt += "Pos:" + pos.x.ToString("f2") + " " + pos.y.ToString("f2") + " " + pos.z.ToString("f2")+"\n";
            txt += $"Pos:{pos.x,4:f2} {pos.y,4:f2} {pos.z,4:f2}{txtalt}\n";
            txt += txtpancam;
            //txt += "Fwd:" + fwd.x.ToString("f2") + " " + fwd.y.ToString("f2") + " " + fwd.z.ToString("f2");
            txt += $"Fwd:{fwd.x,4:f2} {fwd.y,4:f2} {fwd.z,4:f2}{txtyang}\n";
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
        var mmsg = $"Reg:{sman.curscene} - {gogen}\n";
        var (ncolliders,nenabled) = CountColliders();
        mmsg += System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss zzz\n");
        mmsg += $"P:{sman.psman.GetPersonCount()} V:{sman.veman.GetVehicleCount()} "+
                $"B:{sman.bdman.GetDestinationBuildingCount()}/{sman.bdman.GetAllBuildingsCount()} BR:{sman.bdman.GetBroomCount()} VC:{sman.vcman.GetVidcamCount()} C:{nenabled}/{ncolliders}\n"+
                $"{GraphAlgos.GraphUtil.GetVersionString()}";
        mscText.text = mmsg;

        geoText.text = $"{sman.lasthitname}\n{jman.journeyToShadow}";

    }
    private void Update()
    {
        UpdateInfoPanel();
    }
}
