using CampusSimulator;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UxUtils;
using TMPro.EditorUtilities;

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
    Dictionary<TabState, (Button but, string tit)> scenarioButDict = null;
    List<(Button,string)> scenarioButList = null;
    Dictionary<TabState, Initer> initDict = null;
    Dictionary<TabState, SetAndSaver> setAndSaveDict = null;

    public UxEnumSetting<TabState> initialSceneTabState = new UxEnumSetting<TabState>("OptionsLastTabUsed", TabState.Visuals);

    public string enableString = "Visuals,MapSet,Frames,FireFly,Buildings,Osm,General,Log,Help,About";

    public delegate void OnUiButtonClickDelegate();
    public class OptButtSpec
    {
        public string idname;
        public TabState tabstate;
        public string tooltip;
        public UnityEngine.Events.UnityAction onClickAction;
        public OptButtSpec(string bname, string btooltip)
        {
            idname = bname;
            var ok = System.Enum.TryParse<TabState>(bname, out var te);
            if (!ok)
            {
                Debug.LogError($"Could not parse {bname} as TabState enum");
                te = TabState.Visuals;
            }
            tabstate = te;
            tooltip = btooltip;
            onClickAction = null;
        }
    }

    Dictionary<string, OptButtSpec> butspec = new Dictionary<string, OptButtSpec>()
    {
        {"Visuals",new OptButtSpec("Visuals","Visual Base Settings")},
        {"MapSet",new OptButtSpec("MapSet","Map Settings\nThere are a lot of them") },
        {"Frames",new OptButtSpec("Frames","Frame parameters for image recognition labeling") },
        {"FireFly",new OptButtSpec("FireFly","FireFly related parameters") },
        {"Buildings",new OptButtSpec("Buildings","Building related parameters") },
        {"Osm",new OptButtSpec("Osm","Open Street Map Import") },
        {"General",new OptButtSpec("General","General parameters") },
        {"Log",new OptButtSpec("Log","Log messages (i.e. errors, warnings, timings, etc)") },
        {"Help",new OptButtSpec("Help","Help information\nincluding command line parameters") },
        {"About",new OptButtSpec("About","Version and System Information") },
    };


    public enum TabState { Visuals, MapSet, FireFly, Frames, Buildings, Osm, General, Log, Help, About }
    TabState tabstate;
    // Start is called before the first frame update
    public void Init0()
    {
        uiman = sman.uiman;

        //ttDict = new Dictionary<string, GameObject>();
        panDict = new Dictionary<TabState, GameObject>();
        scenarioButList = new List<(Button,string)>();
        scenarioButDict = new Dictionary<TabState, (Button, string)>();
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

        AddActions();
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
        foreach (var (but,_) in  scenarioButList)
        {
             Destroy(but.gameObject);
        }
        scenarioButList = new List<(Button,string)>();
        scenarioButDict = new Dictionary<TabState, (Button but, string tit)>();
    }
    public void AddActions()
    {
        foreach (var key in butspec.Keys)
        {
            var butsp = butspec[key];
            butsp.onClickAction = delegate{ OptionsSubMenuButtonPushed(butsp.tabstate); };
        }
    }
    public void MakeOptionsButtons()
    {
        var buttxtarr = enableString.Split(',');

        var nbut = buttxtarr.Length;
        var gap = 10;
        var w = 110;
        var h = 48;
        var twid = nbut*w + (nbut-1)*gap;

        var x = -twid / 2;
        var y = 662;


        foreach (var buttxt in buttxtarr)
        {
            var bname = buttxt + "Button";
            if (!butspec.ContainsKey(buttxt))
            {
                sman.LggError("OptionsPanel butspec error");
                continue;
            }
            var bs = butspec[buttxt];
            var butt = MakeOneButtonStretchY(bname, x, w, buttxt, bs.tooltip, bs.onClickAction );
            scenarioButDict[bs.tabstate] = (butt, buttxt);
            scenarioButList.Add((butt,buttxt));
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
        foreach (var (but,idname) in scenarioButList)
        {
            var bs = butspec[idname];
            uiman.tbtpan.SetButtonColor(but, "lightgray", tabstate == bs.tabstate, bs.idname);
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
