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
    GameObject buildingsPanelGo;
    BuildingsPanel buildingsPanel;
    GameObject generalPanelGo;
    GeneralPanel generalPanel;
    GameObject helpPanelGo;
    HelpPanel helpPanel;
    GameObject aboutPanelGo;
    AboutPanel aboutPanel;
    Toggle visualToggle;
    Toggle mapsetToggle;
    Toggle frameToggle;
    Toggle buildingsToggle;
    Toggle generalToggle;
    Toggle helpToggle;
    Toggle aboutToggle;
    ToggleGroup togGroup;
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
        buildingsPanelGo = transform.Find("BuildingsPanel").gameObject;
        buildingsPanel = buildingsPanelGo.GetComponent<BuildingsPanel>();
        generalPanelGo = transform.Find("GeneralPanel").gameObject;
        generalPanel = generalPanelGo.GetComponent<GeneralPanel>();
        helpPanelGo = transform.Find("HelpPanel").gameObject;
        helpPanel = helpPanelGo.GetComponent<HelpPanel>();

        visualToggle = transform.Find("VisualsToggle").GetComponent<Toggle>();
        mapsetToggle = transform.Find("MapSetToggle").GetComponent<Toggle>();
        frameToggle = transform.Find("FrameToggle").GetComponent<Toggle>();
        buildingsToggle = transform.Find("BuildingsToggle").GetComponent<Toggle>();
        generalToggle = transform.Find("GeneralToggle").GetComponent<Toggle>();
        helpToggle = transform.Find("HelpToggle").GetComponent<Toggle>();
        aboutToggle = transform.Find("AboutToggle").GetComponent<Toggle>();

        visualToggle.onValueChanged.AddListener(delegate { OptionsTabToggle(); });
        mapsetToggle.onValueChanged.AddListener(delegate { OptionsTabToggle(); });
        frameToggle.onValueChanged.AddListener(delegate { OptionsTabToggle(); });
        buildingsToggle.onValueChanged.AddListener(delegate { OptionsTabToggle(); });
        generalToggle.onValueChanged.AddListener(delegate { OptionsTabToggle(); });
        helpToggle.onValueChanged.AddListener(delegate { OptionsTabToggle(); });
        aboutToggle.onValueChanged.AddListener(delegate { OptionsTabToggle(); });


        togGroup = GetComponent<ToggleGroup>();
        togGroup.allowSwitchOff = true; // otherwise it does not save state correctly when we turn off the panel
        //SyncOptionsTabState();
    }
    public void SyncOptionsTabState()
    {
        if (!visualPanelGo) return; // not initialized yet
        //Debug.Log("SyncOptionsTabState");
        visualPanelGo.SetActive(visualToggle.isOn);
        mapSetGo.SetActive(mapsetToggle.isOn);
        framePanelGo.SetActive(frameToggle.isOn);
        buildingsPanelGo.SetActive(buildingsToggle.isOn);
        generalPanelGo.SetActive(generalToggle.isOn);
        helpPanelGo.SetActive(helpToggle.isOn);
        aboutPanelGo.SetActive(aboutToggle.isOn);
        if (aboutToggle.isOn)
        {
            aboutPanel.FillAboutPanel();
        }
        if (visualToggle.isOn)
        {
            visualsPanel.InitVals();
        }
        if (mapsetToggle.isOn)
        {
            mapSetPanel.InitVals();
        }
        if (frameToggle.isOn)
        {
            framePanel.InitVals();
        }
        if (buildingsToggle.isOn)
        {
            buildingsPanel.InitVals();
        }
        if (helpToggle.isOn)
        {
            helpPanel.FillHelpPanel();
        }
        if (generalToggle.isOn)
        {
            generalPanel.InitVals();
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
            if (visualToggle.isOn)
            {
                visualsPanel.SetVals(closing: true);
            }
            if (mapsetToggle.isOn)
            {
                mapSetPanel.SetVals(closing:true);
            }
            if (frameToggle.isOn)
            {
                framePanel.SetVals(closing: true);
            }
            if (buildingsToggle.isOn)
            {
                buildingsPanel.SetVals(closing: true);
            }
            if (generalToggle.isOn)
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
    void Update()
    {

    }
}
