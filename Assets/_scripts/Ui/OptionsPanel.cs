using CampusSimulator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour
{
    public CampusSimulator.SceneMan sman;
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
    GameObject helpPanelGo;
    HelpPanel helpPanel;
    GameObject aboutPanelGo;
    AboutPanel aboutPanel;

    Button visualsTabButton;
    Button mapsetTabButton;
    Button frameTabButton;
    Button fireflyTabButton;
    Button generalTabButton;
    Button buildingsTabButton;
    Button helpTabButton;
    Button aboutTabButton;

    public delegate void Initer();
    public delegate void SetAndSaver(bool closing=true);

    Dictionary<TabState,(Button but,string tit,GameObject gob)> butDict = null;
    Dictionary<TabState, Initer> initDict = null;
    Dictionary<TabState, SetAndSaver> setAndSaveDict = null;

    public string enableString = "Visuals,MapSet,FireFly,Frames,Buildings,General,Help,About";

    public enum TabState { Visuals,MapSet,FireFly,Frames,Buildings,General,Help,About }
    TabState tabstate;
    // Start is called before the first frame update
    public void Init0()
    {
        uiman = sman.uiman;

        butDict = new Dictionary<TabState, (Button, string, GameObject)>();
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
        helpPanelGo = transform.Find("HelpPanel").gameObject;
        helpPanel = helpPanelGo.GetComponent<HelpPanel>();
        aboutPanelGo = transform.Find("AboutPanel").gameObject;
        aboutPanel = aboutPanelGo.GetComponent<AboutPanel>();

        visualsTabButton = transform.Find("VisualsTabButton").GetComponent<Button>();
        mapsetTabButton = transform.Find("MapSetTabButton").GetComponent<Button>();
        frameTabButton = transform.Find("FrameTabButton").GetComponent<Button>();
        fireflyTabButton = transform.Find("FireFlyTabButton").GetComponent<Button>();
        buildingsTabButton = transform.Find("BuildingsTabButton").GetComponent<Button>();
        generalTabButton = transform.Find("GeneralTabButton").GetComponent<Button>();
        aboutTabButton = transform.Find("AboutTabButton").GetComponent<Button>();
        helpTabButton = transform.Find("HelpTabButton").GetComponent<Button>();

        butDict[TabState.Visuals] = (visualsTabButton,"Visuals", visualPanelGo);
        butDict[TabState.MapSet] = (mapsetTabButton,"MapSet", mapSetGo);
        butDict[TabState.Frames] = (frameTabButton, "Frames", framePanelGo);
        butDict[TabState.FireFly] = (fireflyTabButton, "FireFly", fireFlyPanelGo);
        butDict[TabState.Buildings] = (buildingsTabButton, "Buildings", buildingsPanelGo);
        butDict[TabState.General] = (generalTabButton, "General", generalPanelGo);
        butDict[TabState.Help] = (helpTabButton, "Help", helpPanelGo);
        butDict[TabState.About] = (aboutTabButton, "About", aboutPanelGo);

        foreach (var ts in butDict.Keys)
        {
            var but = butDict[ts].but;
            but.onClick.AddListener(delegate { SetTabState(ts); });
        }

        initDict[TabState.Visuals] = delegate { visualsPanel.InitVals(); };
        initDict[TabState.MapSet] = delegate { mapSetPanel.InitVals(); };
        initDict[TabState.Frames] = delegate { framePanel.InitVals(); };
        initDict[TabState.FireFly] = delegate { fireFlyPanel.InitVals(); };
        initDict[TabState.Buildings] = delegate { buildingsPanel.InitVals(); };
        initDict[TabState.General] = delegate { generalPanel.InitVals(); };
        initDict[TabState.Help] = delegate { helpPanel.FillHelpPanel(); };
        initDict[TabState.About] = delegate { aboutPanel.FillAboutPanel(); };

        setAndSaveDict[TabState.Visuals] = delegate { visualsPanel.SetVals(true); };
        setAndSaveDict[TabState.MapSet] = delegate { mapSetPanel.SetVals(true); };
        setAndSaveDict[TabState.Frames] = delegate { framePanel.SetVals(true); };
        setAndSaveDict[TabState.FireFly] = delegate { fireFlyPanel.SetVals(true); };
        setAndSaveDict[TabState.Buildings] = delegate { buildingsPanel.SetVals(true); };
        setAndSaveDict[TabState.General] = delegate { generalPanel.SetVals(true); };
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
        if (!visualPanelGo) return; // not initialized yet
        foreach (var ts in butDict.Keys)
        {
            var (but, tit, gob) = butDict[ts];
            gob.SetActive(tabstate == ts);
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
