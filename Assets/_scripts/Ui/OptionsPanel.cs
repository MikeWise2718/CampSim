using CampusSimulator;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class OptionsPanel : MonoBehaviour
{
    public SceneMan sman;
    UiMan uiman;

    GameObject visualPanelGo;
    VisualsPanel visualsPanel;
    GameObject mapSetGo;
    MapSetPanel mapSetPanel;
    GameObject framePanelGo;
    FramePanel framePanel;
    GameObject fireFlyPanelGo;
    FireFlyPanel fireFlyPanel;
    GameObject buildingsPanelGo;
    BuildingsPanel buildingsPanel;
    GameObject generalPanelGo;
    GeneralPanel generalPanel;
    GameObject logPanelGo;
    LogPanel logPanel;
    GameObject helpPanelGo;
    HelpPanel helpPanel;
    GameObject aboutPanelGo;
    AboutPanel aboutPanel;

    bool inited = false;

    public delegate void Initer();
    public delegate void SetAndSaver(bool closing=true);

    Dictionary<TabState, GameObject> panDict = null;
    Dictionary<TabState, (Button but, string tit)> butDict = null;
    Dictionary<TabState, Initer> initDict = null;
    Dictionary<TabState, SetAndSaver> setAndSaveDict = null;

    public string enableString = "Visuals,MapSet,Frames,FireFly,Buildings,General,Log,Help,About";

    Dictionary<string, string> tooltip = new Dictionary<string, string> {
        {"Visuals","Visual Base Settings" },
        {"MapSet","Map Settings\nThere are a lot of them" },
        {"Frames","Frame parameters for image recognition labeling" },
        {"FireFly","FireFly related parameters" },
        {"Buildings","Building related parameters" },
        {"General","General parameters" },
        {"Log","Log messages (i.e. errors, warnings, timings, etc)" },
        {"Help","Help information\nincluding command line parameters" },
        {"About","Version and System Information" },
    };

    public enum TabState { Visuals,MapSet,FireFly,Frames,Buildings,General,Log,Help,About }
    TabState tabstate;
    // Start is called before the first frame update
    public void Init0()
    {
        uiman = sman.uiman;

        //ttDict = new Dictionary<string, GameObject>();
        panDict = new Dictionary<TabState, GameObject>();
        butDict = new Dictionary<TabState, (Button, string)>();
        initDict = new Dictionary<TabState, Initer>();
        setAndSaveDict = new Dictionary<TabState, SetAndSaver>();

        //Debug.Log("Options Panel Start:"+name);
        visualPanelGo = transform.Find("VisualsPanel").gameObject;
        visualsPanel = visualPanelGo.GetComponent<VisualsPanel>();
        mapSetGo = transform.Find("MapSetPanel").gameObject;
        mapSetPanel = mapSetGo.GetComponent<MapSetPanel>();
        framePanelGo = transform.Find("FramePanel").gameObject;
        framePanel = framePanelGo.GetComponent<FramePanel>();
        fireFlyPanelGo = transform.Find("FireFlyPanel").gameObject;
        fireFlyPanel = fireFlyPanelGo.GetComponent<FireFlyPanel>();
        buildingsPanelGo = transform.Find("BuildingsPanel").gameObject;
        buildingsPanel = buildingsPanelGo.GetComponent<BuildingsPanel>();
        generalPanelGo = transform.Find("GeneralPanel").gameObject;
        generalPanel = generalPanelGo.GetComponent<GeneralPanel>();
        logPanelGo = transform.Find("LogPanel").gameObject;
        logPanel = logPanelGo.GetComponent<LogPanel>();
        helpPanelGo = transform.Find("HelpPanel").gameObject;
        helpPanel = helpPanelGo.GetComponent<HelpPanel>();
        aboutPanelGo = transform.Find("AboutPanel").gameObject;
        aboutPanel = aboutPanelGo.GetComponent<AboutPanel>();

        panDict[TabState.Visuals] = visualsPanel.gameObject;
        panDict[TabState.MapSet] = mapSetPanel.gameObject;
        panDict[TabState.Frames] = framePanel.gameObject;
        panDict[TabState.FireFly] = fireFlyPanel.gameObject;
        panDict[TabState.Buildings] = buildingsPanel.gameObject;
        panDict[TabState.General] = generalPanel.gameObject;
        panDict[TabState.Log] = logPanel.gameObject;
        panDict[TabState.Help] = helpPanel.gameObject;
        panDict[TabState.About] = aboutPanel.gameObject;


        initDict[TabState.Visuals] = delegate { visualsPanel.InitVals(); };
        initDict[TabState.MapSet] = delegate { mapSetPanel.InitVals(); };
        initDict[TabState.Frames] = delegate { framePanel.InitVals(); };
        initDict[TabState.FireFly] = delegate { fireFlyPanel.InitVals(); };
        initDict[TabState.Buildings] = delegate { buildingsPanel.InitVals(); };
        initDict[TabState.General] = delegate { generalPanel.InitVals(); };
        initDict[TabState.Log] = delegate { logPanel.FillLogPanel(); };
        initDict[TabState.Help] = delegate { helpPanel.FillHelpPanel(); };
        initDict[TabState.About] = delegate { aboutPanel.FillAboutPanel(); };

        setAndSaveDict[TabState.Visuals] = delegate { visualsPanel.SetVals(true); };
        setAndSaveDict[TabState.MapSet] = delegate { mapSetPanel.SetVals(true); };
        setAndSaveDict[TabState.Frames] = delegate { framePanel.SetVals(true); };
        setAndSaveDict[TabState.FireFly] = delegate { fireFlyPanel.SetVals(true); };
        setAndSaveDict[TabState.Buildings] = delegate { buildingsPanel.SetVals(true); };
        setAndSaveDict[TabState.General] = delegate { generalPanel.SetVals(true); };

        DestroyFixedButtons();

        inited = true;
    }
    public void FindAndDestroy(string targetname)
    {
        var tran = transform.Find(targetname);
        if (tran!=null)
        {
            Destroy(tran.gameObject);
            //var butcomp = tran.GetComponent<Button>();
            //Destroy(butcomp.gameObject);
            //Debug.Log($"Destroyed {targetname}");
        }
    }
    public void DestroyFixedButtons()
    {
        FindAndDestroy("VisualsTabButton");
        FindAndDestroy("MapSetTabButton");
        FindAndDestroy("FramesTabButton");
        FindAndDestroy("FireFlyTabButton");
        FindAndDestroy("BuildingsTabButton");
        FindAndDestroy("GeneralTabButton");
        FindAndDestroy("HelpTabButton");
        FindAndDestroy("AboutTabButton");
    }

    public Button MakeOneButton(string bname,int x,int y,int w,int h,string txt,string tip="")
    {

        var bgo = DefaultControls.CreateButton(new DefaultControls.Resources());
        bgo.name = bname;
        var butt = bgo.GetComponentInChildren<Button>();
        var btxt = bgo.GetComponentInChildren<Text>();
        btxt.text = txt;
        btxt.fontSize = 18;
        var recttrans = butt.GetComponent<RectTransform>();
        var pos = new Vector3(x, y, 0);
        recttrans.SetPositionAndRotation(pos, Quaternion.identity);
        recttrans.sizeDelta = new Vector2(w, h);

        bgo.transform.SetParent(this.transform,worldPositionStays:false);

        if (tip != "")
        {
            uiman.ttman.WireUpToolTip(bgo, txt, tip);
        }
        return butt;          
    }
    public void DestroyButtons()
    {
        foreach (var (but, tit) in butDict.Values)
        {
            if (but != null)
            {
                Destroy(but);
            }
        }
        butDict = new Dictionary<TabState, (Button but, string tit)>();
    }
    public void MakeNewButtons()
    {
        DestroyButtons();

        var buttxtarr = enableString.Split(',');

        var nbut = buttxtarr.Length;
        var h = 48;
        var w = 110;
        var gap = 10;
        var twid = nbut*w + (nbut-1)*gap;

        //var x = -460;
        var x = -twid/2;
        var y = 680;

        //sman.Lgg(enableString,"yellow");
        //sman.Lgg($"butt: nbut:{nbut} twid:{twid} x:{x} y:{y}", "cyan");
        foreach (var buttxt in buttxtarr)
        {
            var bname = buttxt + "Button";
            var buttip = "";
            if (tooltip.ContainsKey(buttxt))
            {
                buttip = tooltip[buttxt];
            }
            var butt = MakeOneButton(bname, x, y, w, h, buttxt,buttip);
            var ok = System.Enum.TryParse<TabState>(buttxt, out var te);
            if (!ok)
            {
                sman.LggError($"Could not parse {buttxt} as TabState enum");
                continue;
            }
            butDict[te] = (butt, buttxt);
            butt.onClick.AddListener(delegate { SetTabState(te); });
            x += w + gap;
        }
    }

    public void SetProcs(TabState ts,Initer initer,SetAndSaver setAndSaver)
    {
        initDict[ts] = initer;
        setAndSaveDict[ts] = setAndSaver;
    }

    public void SetTabState(TabState newstate)
    {
        tabstate = newstate;
        SyncOptionsTabState();
    }
    public void SyncOptionsTabState()
    {
        if (!inited) return; // not initialized yet

        foreach (var ts in panDict.Keys)
        {
            var gob = panDict[ts];
            gob.SetActive(tabstate == ts);
        }
        foreach (var ts in butDict.Keys)
        { 
            var (but, tit) = butDict[ts];
            uiman.stapan.SetButtonColor(but, "lightgray", tabstate == ts, tit);
        }

        if (initDict.ContainsKey(tabstate))
        {
            initDict[tabstate]();
        }
    }
    public void ChangingOptionsDialog(bool isOpening)
    {
        if (isOpening)
        {
            SyncOptionsTabState();
        }
        else
        {
            if (setAndSaveDict.ContainsKey(tabstate))
            {
                setAndSaveDict[tabstate](closing:true);
            }
        }
    }

    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
        enableString = "Visuals,MapSet,FireFly,Frames,Buildings,General,Log,Help,About";
        switch (curscene)
        {
            case SceneSelE.MsftB19focused:
                {
                    enableString = "Visuals,MapSet,Frames,Buildings,General,Log,Help,About";
                    break;
                }
            case SceneSelE.TeneriffeMtn:
                {
                    enableString = "FireFly,Visuals,MapSet,Frames,Buildings,General,Log,Help,About";
                    break;
                }

        }
        MakeNewButtons();

        SyncOptionsTabState();
    }
    public void OptionsTabToggle()
    {
        SyncOptionsTabState();
    }
    // Update is called once per frame
    //void Update()
    //{

    //}
}
