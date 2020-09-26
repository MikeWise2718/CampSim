using CampusSimulator;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UxUtils;

public class OptionsPanel : MonoBehaviour
{
    public SceneMan sman;
    UiMan uiman;

    VisualsPanel visualsPanel;
    MapSetPanel mapSetPanel;
    FramePanel framePanel;
    FireFlyPanel fireFlyPanel;
    BuildingsPanel buildingsPanel;
    GeneralPanel generalPanel;
    OsmPanel osmPanel;
    LogPanel logPanel;
    HelpPanel helpPanel;
    AboutPanel aboutPanel;

    bool inited = false;

    public delegate void Initer();
    public delegate void SetAndSaver(bool closing = true);
    public delegate void SetTabStater(TabState te);

    Dictionary<TabState, GameObject> panDict = null;
    Dictionary<TabState, (Button but, string tit)> butDict = null;
    Dictionary<TabState, Initer> initDict = null;
    Dictionary<TabState, SetAndSaver> setAndSaveDict = null;

    public UxEnumSetting<TabState> initialSceneTabState = new UxEnumSetting<TabState>("OptionsLastTabUsed", TabState.Visuals);

    public string enableString = "Visuals,MapSet,Frames,FireFly,Buildings,Osm,General,Log,Help,About";

    public delegate void OnUiButtonClickDelegate();
    public class UiButtonSpec
    {
        public string name;
        public string tooltip;
        public OnUiButtonClickDelegate onClickAction;
        public UiButtonSpec(string bname, string btooltip, OnUiButtonClickDelegate bOnClickAction)
        {
            name = bname;
            tooltip = btooltip;
            onClickAction = bOnClickAction;
        }
    }

    Dictionary<string, UiButtonSpec> butspec = new Dictionary<string, UiButtonSpec>()
    {
        {"Visuals",new UiButtonSpec("Visuals","Visual Base Settings",null)},
        {"MapSet",new UiButtonSpec("MapSet","Map Settings\nThere are a lot of them",null) },
        {"Frames",new UiButtonSpec("Frames","Frame parameters for image recognition labeling",null) },
        {"FireFly",new UiButtonSpec("FireFly","FireFly related parameters",null) },
        {"Buildings",new UiButtonSpec("Buildings","Building related parameters",null) },
        {"Osm",new UiButtonSpec("Osm","Open Street Map Import",null) },
        {"General",new UiButtonSpec("General","General parameters",null) },
        {"Log",new UiButtonSpec("Log","Log messages (i.e. errors, warnings, timings, etc)",null) },
        {"Help",new UiButtonSpec("Help","Help information\nincluding command line parameters",null) },
        {"About",new UiButtonSpec("About","Version and System Information",null) },
    };


    //Dictionary<string, string> tooltip = new Dictionary<string, string> {
    //    {"Visuals","Visual Base Settings" },
    //    {"MapSet","Map Settings\nThere are a lot of them" },
    //    {"Frames","Frame parameters for image recognition labeling" },
    //    {"FireFly","FireFly related parameters" },
    //    {"Buildings","Building related parameters" },
    //    {"General","General parameters" },
    //    {"Log","Log messages (i.e. errors, warnings, timings, etc)" },
    //    {"Help","Help information\nincluding command line parameters" },
    //    {"About","Version and System Information" },
    //};

    public enum TabState { Visuals, MapSet, FireFly, Frames, Buildings, Osm, General, Log, Help, About }
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
        visualsPanel = transform.Find("VisualsPanel").GetComponent<VisualsPanel>();
        mapSetPanel = transform.Find("MapSetPanel").GetComponent<MapSetPanel>();
        framePanel = transform.Find("FramePanel").GetComponent<FramePanel>();
        fireFlyPanel = transform.Find("FireFlyPanel").GetComponent<FireFlyPanel>();
        buildingsPanel = transform.Find("BuildingsPanel").GetComponent<BuildingsPanel>();
        osmPanel = transform.Find("OsmPanel").GetComponent<OsmPanel>();
        generalPanel = transform.Find("GeneralPanel").GetComponent<GeneralPanel>();
        logPanel = transform.Find("LogPanel").GetComponent<LogPanel>();
        helpPanel = transform.Find("HelpPanel").GetComponent<HelpPanel>();
        aboutPanel = transform.Find("AboutPanel").GetComponent<AboutPanel>();

        panDict[TabState.Visuals] = visualsPanel.gameObject;
        panDict[TabState.MapSet] = mapSetPanel.gameObject;
        panDict[TabState.Frames] = framePanel.gameObject;
        panDict[TabState.FireFly] = fireFlyPanel.gameObject;
        panDict[TabState.Buildings] = buildingsPanel.gameObject;
        panDict[TabState.Osm] = osmPanel.gameObject;
        panDict[TabState.General] = generalPanel.gameObject;
        panDict[TabState.Log] = logPanel.gameObject;
        panDict[TabState.Help] = helpPanel.gameObject;
        panDict[TabState.About] = aboutPanel.gameObject;


        initDict[TabState.Visuals] = delegate { visualsPanel.InitVals(); };
        initDict[TabState.MapSet] = delegate { mapSetPanel.InitVals(); };
        initDict[TabState.Frames] = delegate { framePanel.InitVals(); };
        initDict[TabState.FireFly] = delegate { fireFlyPanel.InitVals(); };
        initDict[TabState.Buildings] = delegate { buildingsPanel.InitVals(); };
        initDict[TabState.Osm] = delegate { osmPanel.InitVals(); };
        initDict[TabState.General] = delegate { generalPanel.InitVals(); };
        initDict[TabState.Log] = delegate { logPanel.FillLogPanel(); };
        initDict[TabState.Help] = delegate { helpPanel.FillHelpPanel(); };
        initDict[TabState.About] = delegate { aboutPanel.FillAboutPanel(); };

        setAndSaveDict[TabState.Visuals] = delegate { visualsPanel.SetVals(true); };
        setAndSaveDict[TabState.MapSet] = delegate { mapSetPanel.SetVals(true); };
        setAndSaveDict[TabState.Frames] = delegate { framePanel.SetVals(true); };
        setAndSaveDict[TabState.FireFly] = delegate { fireFlyPanel.SetVals(true); };
        setAndSaveDict[TabState.Buildings] = delegate { buildingsPanel.SetVals(true); };
        setAndSaveDict[TabState.Osm] = delegate { osmPanel.SetVals(true); };
        setAndSaveDict[TabState.General] = delegate { generalPanel.SetVals(true); };

        // start inactive
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }


        inited = true;

    }

    public void DeleteStuff()
    {
        DestroyButtons();
    }

    public Button MakeOneButtonStretchY(string bname, int x,int w, string txt, string tip = "", UnityEngine.Events.UnityAction action= null)
    {

        var bgo = DefaultControls.CreateButton(new DefaultControls.Resources());
        bgo.name = bname;
        var butt = bgo.GetComponentInChildren<Button>();
        var btxt = bgo.GetComponentInChildren<Text>();
        btxt.text = txt;
        btxt.fontSize = 18;
        var recttrans = butt.GetComponent<RectTransform>();
        var pos = new Vector3(x, 0, 0);
        recttrans.SetPositionAndRotation(pos, Quaternion.identity);
        recttrans.anchorMin = new Vector2(0.5f, 0);
        recttrans.anchorMax = new Vector2(0.5f, 1);
        recttrans.pivot = new Vector2(0.5f, 0.5f);
        recttrans.sizeDelta = new Vector2(w, 0);
        bgo.transform.SetParent(uiman.ottpan.transform, worldPositionStays: false);

        //bgo.transform.SetParent(this.transform,worldPositionStays:false);

        if (tip != "")
        {
            uiman.ttman.WireUpToolTip(bgo, txt, tip);
        }
        if (action != null)
        {
            butt.onClick.AddListener(action);
        }
        return butt;
    }

    public Button MakeOneButton(string bname, int x, int y, int w, int h, string txt, string tip = "", UnityEngine.Events.UnityAction action = null)
    {

        var bgo = DefaultControls.CreateButton(new DefaultControls.Resources());
        bgo.name = bname;
        var butt = bgo.GetComponentInChildren<Button>();
        var btxt = bgo.GetComponentInChildren<Text>();
        btxt.text = txt;
        btxt.fontSize = 18;
        var recttrans = butt.GetComponent<RectTransform>();
        var pos = new Vector3(x, 0, 0);
        recttrans.SetPositionAndRotation(pos, Quaternion.identity);
        recttrans.sizeDelta = new Vector2(w, h);
        bgo.transform.SetParent(uiman.ottpan.transform, worldPositionStays: false);
        if (tip != "")
        {
            uiman.ttman.WireUpToolTip(bgo, txt, tip);
        }
        if (action != null)
        {
            butt.onClick.AddListener(action);
        }
        return butt;
    }
    public void DestroyButtons()
    {
        foreach (var (but, tit) in butDict.Values)
        {
            if (but != null)
            {
                Destroy(but.gameObject);
            }
        }
        butDict = new Dictionary<TabState, (Button but, string tit)>();
    }
    public void MakeOptionsButtons()
    {
        var buttxtarr = enableString.Split(',');

        var nbut = buttxtarr.Length;
        var w = 110;
        var h = 48;
        var gap = 10;
        var twid = nbut * w + (nbut - 1) * gap;

        //var x = -460;
        var x = -twid / 2;
        var y = 662;
        var recttrans = uiman.ottpan.GetComponent<RectTransform>();

        //sman.Lgg(enableString,"yellow");
        //sman.Lgg($"butt: nbut:{nbut} twid:{twid} x:{x} y:{y}", "cyan");
        foreach (var buttxt in buttxtarr)
        {
            if (butspec.ContainsKey(buttxt))
            {
                var ok = System.Enum.TryParse<TabState>(buttxt, out var te);
                if (ok)
                {
                    butspec[buttxt].onClickAction = delegate
                    {
                        OptionsSubMenuButtonPushed(te);
                    };
                }
                else
                {
                    sman.LggError($"Could not parse {buttxt} as TabState enum");
                }
            }
        }
        foreach (var buttxt in buttxtarr)
        {
            var bname = buttxt + "Button";
            var buttip = "";
            if (butspec.ContainsKey(buttxt))
            {
                buttip = butspec[buttxt].tooltip;
            }
            var ok = System.Enum.TryParse<TabState>(buttxt, out var te);
            if (!ok)
            {
                sman.LggError($"Could not parse {buttxt} as TabState enum");
                continue;
            }
            var butt = MakeOneButtonStretchY(bname, x, w, buttxt, buttip, delegate { OptionsSubMenuButtonPushed(te); });
            butDict[te] = (butt, buttxt);
            x += w + gap;
        }
    }

    public void SetProcs(TabState ts, Initer initer, SetAndSaver setAndSaver)
    {
        initDict[ts] = initer;
        setAndSaveDict[ts] = setAndSaver;
    }

    public void OptionsSubMenuButtonPushed(TabState newstate)
    {
        gameObject.SetActive(true);
        SetTabState(newstate);
    }

    public void SetTabState(TabState newstate)
    {
        tabstate = newstate;
        initialSceneTabState.SetAndSave(newstate);
        SyncOptionsTabState();
    }
    public void SyncOptionsTabState()
    {
        if (!inited) return; // not initialized yet

        if (gameObject.activeSelf)// only do this if the panel is active
        {
            foreach (var ts in panDict.Keys)
            {
                var gob = panDict[ts];
                gob.SetActive(tabstate == ts);
            }
            if (initDict.ContainsKey(tabstate))
            {
                initDict[tabstate]();
            }
        }
        foreach (var ts in butDict.Keys)
        {
            var (but, tit) = butDict[ts];
            uiman.tbtpan.SetButtonColor(but, "lightgray", tabstate == ts, tit);
        }

    }
    public void TogglePanelState()
    {
        var newstate = !gameObject.activeSelf;
        //Debug.Log($"Options Button Pushed optionsPanelGo.activeSelf:{optionsPanelGo.activeSelf} -> newstate:{newstate}");
        gameObject.SetActive(newstate);// this does immediately take effect
        SwitchOptionsSubPanel(isOpening: newstate);
    }
    public void ClosePanel()
    {
        gameObject.SetActive(false);// this does immediately take effect
        SwitchOptionsSubPanel(isOpening: false);
    }
    public void SwitchOptionsSubPanel(bool isOpening)
    {
        if (isOpening)
        {
            SyncOptionsTabState();
        }
        else
        {
            if (setAndSaveDict.ContainsKey(tabstate))
            {
                setAndSaveDict[tabstate](closing: true);
            }
        }
    }


    void InitializeValues()
    {
        initialSceneTabState.GetInitial();
    }

    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
        InitializeValues();

        enableString = "Visuals,MapSet,FireFly,Frames,Buildings,Osm,General,Log,Help,About";
        switch (curscene)
        {
            case SceneSelE.MsftB19focused:
                {
                    enableString = "Visuals,MapSet,Frames,Buildings,Osm,General,Log,Help,About";// no firefly
                    break;
                }
            case SceneSelE.TeneriffeMtn:
                {
                    enableString = "FireFly,Visuals,MapSet,Frames,Buildings,Osm,General,Log,Help,About";
                    break;
                }

        }
        MakeOptionsButtons();

        tabstate = initialSceneTabState.Get();

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
