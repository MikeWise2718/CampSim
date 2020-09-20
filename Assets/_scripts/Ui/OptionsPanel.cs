using CampusSimulator;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.Assertions.Must;
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
    Button framesTabButton;
    Button fireflyTabButton;
    Button generalTabButton;
    Button buildingsTabButton;
    Button helpTabButton;
    Button aboutTabButton;

    public delegate void Initer();
    public delegate void SetAndSaver(bool closing=true);

    Dictionary<TabState, GameObject> panDict = null;
    Dictionary<TabState, (Button but, string tit)> butDict = null;
    Dictionary<TabState, Initer> initDict = null;
    Dictionary<TabState, SetAndSaver> setAndSaveDict = null;

    //public string enableString0 = "Visuals,MapSet,FireFly,Frames,Buildings,General,Help,About";
    string enableString = "Visuals,MapSet,Frames,Buildings,General,Help,About";

    public enum TabState { Visuals,MapSet,FireFly,Frames,Buildings,General,Help,About }
    TabState tabstate;
    // Start is called before the first frame update
    public void Init0()
    {
        uiman = sman.uiman;

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
        helpPanelGo = transform.Find("HelpPanel").gameObject;
        helpPanel = helpPanelGo.GetComponent<HelpPanel>();
        aboutPanelGo = transform.Find("AboutPanel").gameObject;
        aboutPanel = aboutPanelGo.GetComponent<AboutPanel>();



        panDict[TabState.Visuals] = visualPanelGo;
        panDict[TabState.MapSet] = mapSetGo;
        panDict[TabState.Frames] = framePanelGo;
        panDict[TabState.FireFly] = fireFlyPanelGo;
        panDict[TabState.Buildings] = buildingsPanelGo;
        panDict[TabState.General] = generalPanelGo;
        panDict[TabState.Help] = helpPanelGo;
        panDict[TabState.About] = aboutPanelGo;


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

        DestroyFixedButtons();
        MakeNewButtons();

        foreach (var ts in butDict.Keys)
        {
            var but = butDict[ts].but;
            but.onClick.AddListener(delegate { SetTabState(ts); });
        }
    }

    public void DestroyFixedButtons()
    {
        visualsTabButton = transform.Find("VisualsTabButton").GetComponent<Button>();
        mapsetTabButton = transform.Find("MapSetTabButton").GetComponent<Button>();
        framesTabButton = transform.Find("FramesTabButton").GetComponent<Button>();
        fireflyTabButton = transform.Find("FireFlyTabButton").GetComponent<Button>();
        buildingsTabButton = transform.Find("BuildingsTabButton").GetComponent<Button>();
        generalTabButton = transform.Find("GeneralTabButton").GetComponent<Button>();
        helpTabButton = transform.Find("HelpTabButton").GetComponent<Button>();
        aboutTabButton = transform.Find("AboutTabButton").GetComponent<Button>();

        Destroy(visualsTabButton.gameObject);
        Destroy(mapsetTabButton.gameObject);
        Destroy(framesTabButton.gameObject);
        Destroy(fireflyTabButton.gameObject);
        Destroy(buildingsTabButton.gameObject);
        Destroy(generalTabButton.gameObject);
        Destroy(helpTabButton.gameObject);
        Destroy(aboutTabButton.gameObject);
    }

    public void MakeOneButton(string bname,int x,int y,int w,int h,string txt)
    {
        var ok = System.Enum.TryParse<TabState>(txt,out var te);
        if (!ok)
        {
            UnityEngine.Debug.LogError($"Could not parse {txt} as TabState enum");
            return;
        }
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

        //recttrans.sizeDelta.Set(w, h);

        //recttrans.anchorMin = new Vector2(x-w/2, x-h/2);
        //recttrans.anchorMax = new Vector2(x+w/2, y+h/2);
        bgo.transform.SetParent(this.transform,worldPositionStays:false);
        butDict[te] = (butt, txt);

    }

    public void MakeNewButtons()
    {
        butDict = new Dictionary<TabState, (Button but, string tit)>();
        var buttxtarr = enableString.Split(',');

        var nbut = buttxtarr.Length;
        var h = 48;
        var w = 110;
        var gap = 10;
        var twid = nbut*w + (nbut-1)*gap;

        //var x = -460;
        var x = -twid/2;
        var y = 680;

        sman.Lgg(enableString,"yellow");
        sman.Lgg($"butt: nbut:{nbut} twid:{twid} x:{x} y:{y}", "cyan");
        foreach (var buttxt in buttxtarr)
        {
            var bname = buttxt + "Button";
            MakeOneButton(bname, x, y, w, h, buttxt);
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
        if (!visualPanelGo) return; // not initialized yet
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
