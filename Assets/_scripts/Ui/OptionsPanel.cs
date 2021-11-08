using CampusSimulator;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
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
    OsmPanel osmPanel;
    JourneyPanel journeyPanel;
    GeneralPanel generalPanel;
    UiConfigPanel uiConfigPanel;
    LogPanel logPanel;
    HelpPanel helpPanel;
    AboutPanel aboutPanel;

    bool inited = false;

    public delegate void Initer();
    public delegate void SetAndSaver(bool closing = true);
    public delegate void SetTabStater(TabState te);

    Dictionary<TabState, GameObject> panDict = null;
    Dictionary<TabState, Initer> initDict = null;
    Dictionary<TabState, SetAndSaver> setAndSaveDict = null;

    public UxEnumSetting<TabState> initialSceneTabState = new UxEnumSetting<TabState>("OptionsLastTabUsed", TabState.Visuals);
    public UxSetting<string> enableStringSetting = new UxSetting<string>("OptionsEnableString", enableStringRoot);
    public UxSetting<string> topButtonStringSetting = new UxSetting<string>("TopButtonEnableString", enableStringRoot);

    public const string enableStringRoot = "Visuals,MapSet,Frames,FireFly,Buildings,Osm,Journey,General,Ui,Log,Help,About";
    public string enableString;

    public const string tbpfiltlistDefault = "All,Sim";


    public class OptButtSpec
    {
        public string idname;
        public string displayName;
        public string tooltip;
        public UnityEngine.Events.UnityAction onClickAction;
        public OptButtSpec(string bidname,string bdispname, string btooltip)
        {
            idname = bidname;
            displayName = bdispname;
            tooltip = btooltip;
            onClickAction = null;
        }
    }

    Dictionary<string, OptButtSpec> butspec = new Dictionary<string, OptButtSpec>()
    {
        {"Visuals",new OptButtSpec(TabState.Visuals.ToString(),"Visuals","Visual Base Settings")},
        {"MapSet",new OptButtSpec(TabState.MapSet.ToString(),"MapSet","Map Settings") },
        {"Frames",new OptButtSpec(TabState.Frames.ToString(),"Frames","Frame parameters for image labeling") },
        {"FireFly",new OptButtSpec(TabState.FireFly.ToString(),"FireFly","FireFly related parameters") },
        {"Buildings",new OptButtSpec(TabState.Buildings.ToString(),"Buildings","Building related parameters") },
        {"Osm",new OptButtSpec(TabState.Osm.ToString(),"Osm","Open Street Map Import") },
        {"Journey",new OptButtSpec(TabState.Journey.ToString(),"Journey","Configure a new Journey") },
        {"General",new OptButtSpec(TabState.General.ToString(),"General","General parameters") },
        {"Ui",new OptButtSpec(TabState.Ui.ToString(),"Ui","UI Configuration") },
        {"Log",new OptButtSpec(TabState.Log.ToString(),"Log","Log messages (i.e. errors, warnings, timings, etc)") },
        {"Help",new OptButtSpec(TabState.Help.ToString(),"Help","Help information and command line") },
        {"About",new OptButtSpec(TabState.About.ToString(),"About","Version and System Information") },
    };

    public void AddActionsToButspecs()
    {
        // this is easier than initializing it inline
        foreach (var key in butspec.Keys)
        {
            var butsp = butspec[key];
            butsp.onClickAction = delegate { OptionsSubMenuButtonPushed(butsp.idname); };
        }
    }



    public enum TabState { Visuals, MapSet, FireFly, Frames, Buildings, Osm, Journey, General, Ui, Log, Help, About }
    TabState currentTabState;


    public void NoOp()
    {

    }


    T InitPanel<T>(string panname,TabState panstate, Initer paninitdel, SetAndSaver pansetandsave=null )
    {
        var tran = transform.Find(panname);
        if (tran==null)
        {
            sman.LggError($"OptionsPanel could not find panel gameobject:{panname}");
            return default(T);
        }
        var pan = tran.GetComponent<T>();
        panDict[panstate] = tran.gameObject;
        initDict[panstate] = paninitdel;
        if (pansetandsave!=null)
        {
            setAndSaveDict[panstate] = pansetandsave;
        }
        return pan;
    }

    public void Init0new()
    {
        //var nopdel = new delegate { NoOp(); };
        visualsPanel = InitPanel<VisualsPanel>("VisualsPanel", TabState.Visuals, delegate { visualsPanel.InitVals(); });
        mapSetPanel = InitPanel<MapSetPanel>("MapSetPanel", TabState.MapSet, delegate { mapSetPanel.InitVals(); });
        framePanel = InitPanel<FramePanel>("FramePanel", TabState.Frames, delegate { framePanel.InitVals(); });
        fireFlyPanel = InitPanel<FireFlyPanel>("FireFlyPanel", TabState.FireFly, delegate { fireFlyPanel.InitVals(); });
        buildingsPanel = InitPanel<BuildingsPanel>("BuildingsPanel", TabState.Buildings, delegate { buildingsPanel.InitVals(); });
        osmPanel = InitPanel<OsmPanel>("OsmPanel", TabState.Osm, delegate { osmPanel.InitVals(); });
        journeyPanel = InitPanel<JourneyPanel>("JourneyPanel", TabState.Journey, delegate { journeyPanel.InitVals(); });
        uiConfigPanel = InitPanel<UiConfigPanel>("UiConfigPanel", TabState.Ui, delegate { uiConfigPanel.InitVals(); });
        generalPanel = InitPanel<GeneralPanel>("GeneralPanel", TabState.General, delegate { generalPanel.InitVals(); });
        logPanel = InitPanel<LogPanel>("LogPanel", TabState.Log, delegate { logPanel.InitVals(); });
        aboutPanel = InitPanel<AboutPanel>("AboutPanel", TabState.About, delegate { aboutPanel.InitVals(); });
    }

    public void Init0()
    {
        //Debug.Log("Options Panel Init0:"+name);
        uiman = sman.uiman;

        AddActionsToButspecs();

        panDict = new Dictionary<TabState, GameObject>();

        initDict = new Dictionary<TabState, Initer>();
        setAndSaveDict = new Dictionary<TabState, SetAndSaver>();

        Init0new();

        // Panels are predefined so we can layout things on them
        //visualsPanel = transform.Find("VisualsPanel").GetComponent<VisualsPanel>();
        //mapSetPanel = transform.Find("MapSetPanel").GetComponent<MapSetPanel>();
        //framePanel = transform.Find("FramePanel").GetComponent<FramePanel>();

        //fireFlyPanel = transform.Find("FireFlyPanel").GetComponent<FireFlyPanel>();
        //buildingsPanel = transform.Find("BuildingsPanel").GetComponent<BuildingsPanel>();
        //osmPanel = transform.Find("OsmPanel").GetComponent<OsmPanel>();
        //journeyPanel = transform.Find("JourneyPanel").GetComponent<JourneyPanel>();
        //uiConfigPanel = transform.Find("UiConfigPanel").GetComponent<UiConfigPanel>();
        //generalPanel = transform.Find("GeneralPanel").GetComponent<GeneralPanel>();
        //logPanel = transform.Find("LogPanel").GetComponent<LogPanel>();
        //helpPanel = transform.Find("HelpPanel").GetComponent<HelpPanel>();

        //aboutPanel = transform.Find("AboutPanel").GetComponent<AboutPanel>();

        // Connecting them up
        //panDict[TabState.Visuals] = visualsPanel.gameObject;
        //panDict[TabState.MapSet] = mapSetPanel.gameObject;
        //panDict[TabState.Frames] = framePanel.gameObject;
        //panDict[TabState.FireFly] = fireFlyPanel.gameObject;
        //panDict[TabState.Buildings] = buildingsPanel.gameObject;
        //panDict[TabState.Osm] = osmPanel.gameObject;
        //panDict[TabState.Journey] = journeyPanel.gameObject;
        //panDict[TabState.Ui] = uiConfigPanel.gameObject;
        //panDict[TabState.General] = generalPanel.gameObject;
        //panDict[TabState.Log] = logPanel.gameObject;
        //panDict[TabState.Help] = helpPanel.gameObject;
        //panDict[TabState.About] = aboutPanel.gameObject;


        //initDict[TabState.Visuals] = delegate { visualsPanel.InitVals(); };
        //initDict[TabState.MapSet] = delegate { mapSetPanel.InitVals(); };
        //initDict[TabState.Frames] = delegate { framePanel.InitVals(); };
        //initDict[TabState.FireFly] = delegate { fireFlyPanel.InitVals(); };
        //initDict[TabState.Buildings] = delegate { buildingsPanel.InitVals(); };
        //initDict[TabState.Osm] = delegate { osmPanel.InitVals(); };
        //initDict[TabState.Journey] = delegate { journeyPanel.InitVals(); };
        //initDict[TabState.General] = delegate { generalPanel.InitVals(); };
        //initDict[TabState.Ui] = delegate { uiConfigPanel.InitVals(); };
        //initDict[TabState.Log] = delegate { logPanel.InitVals(); };
        //initDict[TabState.Help] = delegate { helpPanel.InitVals(); };
        //initDict[TabState.About] = delegate { aboutPanel.InitVals(); };

        setAndSaveDict[TabState.Visuals] = delegate { visualsPanel.SetValsOld(true); };
        setAndSaveDict[TabState.MapSet] = delegate { mapSetPanel.SetVals(true); };
        setAndSaveDict[TabState.Frames] = delegate { framePanel.SetVals(true); };
        setAndSaveDict[TabState.FireFly] = delegate { fireFlyPanel.SetVals(true); };
        setAndSaveDict[TabState.Buildings] = delegate { buildingsPanel.SetVals(true); };
        setAndSaveDict[TabState.Osm] = delegate { osmPanel.SetVals(true); };
        setAndSaveDict[TabState.Journey] = delegate { journeyPanel.SetVals(true); };
        setAndSaveDict[TabState.Ui] = delegate { uiConfigPanel.SetVals(true); };
        setAndSaveDict[TabState.General] = delegate { generalPanel.SetVals(true); };

        CloseOptionsPanel();
        // start inactive

        inited = true;
    }

    public bool IsOptionsPanelOpen()
    {
        if (gameObject==null)
        {
            return false;
        }
        return gameObject.activeSelf;
    }

    public void OpenOptionsPanel()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(true);
            uiman.ottpan.gameObject.SetActive(true);
        }
    }

    public void CloseOptionsPanel()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(false);
            uiman.ottpan.gameObject.SetActive(false);
        }
    }


    public void SetProcs(TabState ts, Initer initer, SetAndSaver setAndSaver)
    {
        initDict[ts] = initer;
        setAndSaveDict[ts] = setAndSaver;
    }

    public void DeleteStuff()
    {
    }

    public string GetToolTip(string option)
    {
        if (!butspec.ContainsKey(option))
        {
            return "";
        }
        var rv = butspec[option].tooltip;
        return rv;
    }

    public void MakeOptionsButtons()
    {
        var buttxtarr = enableString.Split(',');
        foreach (var k in buttxtarr)
        {
            if (!butspec.ContainsKey(k))
            {
                sman.LggError($"OptionsPanel.MakeOptionsButton - bad option spec:{k}");
                continue;
            }
            var bs = butspec[k];
            uiman.ottpan.SpecOneButton(bs.idname, bs.displayName, bs.tooltip, bs.onClickAction);
        }
        uiman.ottpan.CreateButtons();
        uiman.optpan.SyncOptionsTabState();
    }

    //public void OptionsSubMenuButtonPushed(TabState newstate)
    //{
    //    if (!IsOptionsPanelOpen())
    //    {
    //        OpenOptionsPanel();
    //    }
    //    SetTabState(newstate);
    //}

    public void OptionsSubMenuButtonPushed(string newstate)
    {
        var ok = System.Enum.TryParse<TabState>(newstate, out var tabstate);
        if (!ok)
        {
            sman.LggError($"OptionsPanel.OptionsSubMenuButtonPushed Could not parse {newstate} as TabState enum");
            tabstate = TabState.Visuals;
        }
        if (IsOptionsPanelOpen() && tabstate==currentTabState)
        {
            ClosePanel();
        }
        else
        {
            SetTabState(tabstate);
        }
    }

    public void SetTabState(TabState newstate,bool ensureActive=true)
    {
        if (ensureActive)
        {
            gameObject.SetActive(true);
        }
        currentTabState = newstate;
        initialSceneTabState.SetAndSave(newstate);
        SyncOptionsTabState();
    }
    public void SyncOptionsTabState()
    {
        if (!inited) return; // not initialized yet

        if (IsOptionsPanelOpen())// only do this if the panel is active
        {
            foreach (var ts in panDict.Keys)
            {
                panDict[ts].SetActive(currentTabState == ts);
            }
            if (initDict.ContainsKey(currentTabState))
            {
                try
                {
                    initDict[currentTabState]();
                }
                catch(System.Exception ex)
                {
                    sman.LggError(ex.Message);
                }
            }
        }
        var curts = currentTabState.ToString();
        uiman.ottpan.SyncOptionsTabState(curts);
    }
    public void TogglePanelState()
    {
        var newstate = !IsOptionsPanelOpen();
        if (newstate)
        {
            OpenOptionsPanel();
        }
        else
        {
            CloseOptionsPanel();
        }
        SwitchOptionsSubPanel(isOpening: newstate);
    }
    public void ClosePanel()
    {
        CloseOptionsPanel();
        SwitchOptionsSubPanel(isOpening: false);
        SyncOptionsTabState();
    }
    public void SwitchOptionsSubPanel(bool isOpening)
    {
        if (isOpening)
        {
            SyncOptionsTabState();
        }
        else
        {
            if (setAndSaveDict.ContainsKey(currentTabState))
            {
                setAndSaveDict[currentTabState](closing: true);
            }
        }
    }

    void InitializeValues()
    {
        initialSceneTabState.GetInitial();
        enableStringSetting.GetInitial();
        topButtonStringSetting.GetInitial();
    }

    public void SetScene(CampusSimulator.SceneSelE curscene)
    {

        var enableStringSceneDefault = enableStringRoot;
        switch (curscene)
        {
            case SceneSelE.Eb12:
            case SceneSelE.Eb12small:
                {
                    enableStringSceneDefault = "Visuals,MapSet,Buildings,Osm,Journey,Ui,Log,Help,About";
                    break;
                }
            case SceneSelE.MsftSmall:
                {
                    enableStringSceneDefault = "Visuals,MapSet,Ui,Log,Help,About";
                    break;
                }
            default:
            case SceneSelE.StaplesCenter:
            case SceneSelE.MsftB19focused:
                {
                    enableStringSceneDefault = "Visuals,MapSet,Frames,Buildings,Osm,Journey,General,Ui,Log,Help,About";
                    break;
                }
            case SceneSelE.MsftB33focused:
                {
                    enableStringSceneDefault = "Visuals,MapSet,Frames,Buildings,Osm,Journey,General,Ui,Log,Help,About";
                    break;
                }
            case SceneSelE.MsftB121focused:
                {
                    enableStringSceneDefault = "Visuals,MapSet,Buildings,Osm,Journey,General,Ui,Log,Help,About";
                    break;
                }
            case SceneSelE.TeneriffeMtn:
                {
                    enableStringSceneDefault = "FireFly,Visuals,MapSet,Frames,Buildings,Osm,General,Ui,Log,Help,About";
                    break;
                }
        }

        InitializeValues();
        if (!enableStringSetting.ValueRetrievedFromPersistentStore())
        {
            enableStringSetting.SetAndSave(enableStringSceneDefault);
        }
        enableString = enableStringSetting.Get();
        //enableString = enableStringSceneDefault; // disables saving state

        MakeOptionsButtons();
        currentTabState = initialSceneTabState.Get();
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
