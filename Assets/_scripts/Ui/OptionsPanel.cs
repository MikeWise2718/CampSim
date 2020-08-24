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

    enum TabState { Visuals,MapSet,FireFly,Frames,Buildings,General,Help,About }
    TabState tabstate;
    // Start is called before the first frame update
    public void Init0()
    {
        uiman = sman.uiman;
        //Debug.Log("Options Panel Start:"+name);
        aboutPanelGo = transform.Find("AboutPanel").gameObject;
        aboutPanel = aboutPanelGo.GetComponent<AboutPanel>();
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



        visualsTabButton = transform.Find("VisualsTabButton").GetComponent<Button>();
        mapsetTabButton = transform.Find("MapSetTabButton").GetComponent<Button>();
        frameTabButton = transform.Find("FrameTabButton").GetComponent<Button>();
        fireflyTabButton = transform.Find("FireFlyTabButton").GetComponent<Button>();
        buildingsTabButton = transform.Find("BuildingsTabButton").GetComponent<Button>();
        generalTabButton = transform.Find("GeneralTabButton").GetComponent<Button>();
        aboutTabButton = transform.Find("AboutTabButton").GetComponent<Button>();
        helpTabButton = transform.Find("HelpTabButton").GetComponent<Button>();

        visualsTabButton.onClick.AddListener(delegate { SetTabState(TabState.Visuals); });
        mapsetTabButton.onClick.AddListener(delegate { SetTabState(TabState.MapSet); });
        frameTabButton.onClick.AddListener(delegate { SetTabState(TabState.Frames); });
        fireflyTabButton.onClick.AddListener(delegate { SetTabState(TabState.FireFly); });
        buildingsTabButton.onClick.AddListener(delegate { SetTabState(TabState.Buildings); });
        generalTabButton.onClick.AddListener(delegate { SetTabState(TabState.General); });
        aboutTabButton.onClick.AddListener(delegate { SetTabState(TabState.About); });
        helpTabButton.onClick.AddListener(delegate { SetTabState(TabState.Help); });


        //SyncOptionsTabState();
    }
    
    void SetTabState(TabState newstate)
    {
        tabstate = newstate;
        SyncOptionsTabState();
    }
    public void SyncOptionsTabState()
    {
        if (!visualPanelGo) return; // not initialized yet

        visualPanelGo.SetActive(tabstate == TabState.Visuals);
        mapSetGo.SetActive(tabstate == TabState.MapSet);
        framePanelGo.SetActive(tabstate == TabState.Frames);
        fireFlyPanelGo.SetActive(tabstate == TabState.FireFly);
        buildingsPanelGo.SetActive(tabstate == TabState.Buildings);
        generalPanelGo.SetActive(tabstate == TabState.General);
        helpPanelGo.SetActive(tabstate == TabState.Help);
        aboutPanelGo.SetActive(tabstate == TabState.About);

        uiman.stapan.SetButtonColor(visualsTabButton, "lightgreen", tabstate == TabState.Visuals, "Visuals");
        uiman.stapan.SetButtonColor(mapsetTabButton, "lightgreen", tabstate == TabState.MapSet, "MapSet");
        uiman.stapan.SetButtonColor(frameTabButton, "lightgreen", tabstate == TabState.Frames, "Frames");
        uiman.stapan.SetButtonColor(fireflyTabButton, "lightgreen", tabstate == TabState.FireFly, "Firefly");
        uiman.stapan.SetButtonColor(generalTabButton, "lightgreen", tabstate == TabState.General, "General");
        uiman.stapan.SetButtonColor(buildingsTabButton, "lightgreen", tabstate == TabState.Buildings, "Buildings");
        uiman.stapan.SetButtonColor(helpTabButton, "lightgreen", tabstate == TabState.Help, "Help");
        uiman.stapan.SetButtonColor(aboutTabButton, "lightgreen", tabstate == TabState.About, "About");

        if (visualPanelGo.activeSelf)
        {
            visualsPanel.InitVals();
        }
        if (mapSetGo.activeSelf)
        {
            mapSetPanel.InitVals();
        }
        if (framePanelGo.activeSelf)
        {
            framePanel.InitVals();
        }
        if (fireFlyPanelGo.activeSelf)
        {
            fireFlyPanel.InitVals();
        }
        if (buildingsPanelGo.activeSelf)
        {
            buildingsPanel.InitVals();
        }
        if (generalPanelGo.activeSelf)
        {
            generalPanel.InitVals();
        }
        if (helpPanelGo.activeSelf)
        {
            helpPanel.FillHelpPanel();
        }
        if (aboutPanelGo.activeSelf)
        {
            aboutPanel.FillAboutPanel();
        }
    }
    public void ChangingOptionsDialog(bool isOpening)
    {
        //Debug.Log($"ChangingOptionsDialog - isOpening:{isOpening}");

        if (isOpening)
        {
            SyncOptionsTabState();
        }
        else
        {
            // if we are not opening then we must be closing
            if (visualPanelGo.activeSelf)
            {
                visualsPanel.SetVals(closing: true);
            }
            if (mapSetGo.activeSelf)
            {
                mapSetPanel.SetVals(closing:true);
            }
            if (framePanelGo.activeSelf)
            {
                framePanel.SetVals(closing: true);
            }
            if (fireFlyPanelGo.activeSelf)
            {
                fireFlyPanel.SetVals(closing: true);
            }
            if (buildingsPanelGo.activeSelf)
            {
                buildingsPanel.SetVals(closing: true);
            }
            if (generalPanelGo.activeSelf)
            {
                generalPanel.SetVals(closing: true);
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
