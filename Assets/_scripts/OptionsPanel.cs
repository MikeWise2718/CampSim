using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour
{

    public GameObject visualPanelGo;
    public VisualsPanel visualsPanel;
    public GameObject mapSetGo;
    public MapSetPanel mapSetPanel;
    public GameObject framePanelGo;
    public FramePanel framePanel;
    public GameObject b19PanelGo;
    public B19Panel b19Panel;
    public GameObject generalPanelGo;
    public GeneralPanel generalPanel;
    public GameObject helpPanelGo;
    public HelpPanel helpPanel;
    public GameObject aboutPanelGo;
    public AboutPanel aboutPanel;
    public Toggle visualToggle;
    public Toggle mapsetToggle;
    public Toggle frameToggle;
    public Toggle b19Toggle;
    public Toggle generalToggle;
    public Toggle helpToggle;
    public Toggle aboutToggle;
    public ToggleGroup togGroup;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Options Panel Start:"+name);
        aboutPanelGo = transform.Find("AboutPanel").gameObject;
        aboutPanel = aboutPanelGo.GetComponent<AboutPanel>();
        visualPanelGo = transform.Find("VisualsPanel").gameObject;
        visualsPanel = visualPanelGo.GetComponent<VisualsPanel>();
        mapSetGo = transform.Find("MapSetPanel").gameObject;
        mapSetPanel = mapSetGo.GetComponent<MapSetPanel>();
        framePanelGo = transform.Find("FramePanel").gameObject;
        framePanel = framePanelGo.GetComponent<FramePanel>();
        b19PanelGo = transform.Find("B19Panel").gameObject;
        b19Panel = b19PanelGo.GetComponent<B19Panel>();
        generalPanelGo = transform.Find("GeneralPanel").gameObject;
        generalPanel = generalPanelGo.GetComponent<GeneralPanel>();
        helpPanelGo = transform.Find("HelpPanel").gameObject;
        helpPanel = helpPanelGo.GetComponent<HelpPanel>();
        var vgo = transform.Find("VisualsToggle").gameObject;
        visualToggle = vgo.GetComponent<Toggle>();
        var mgo = transform.Find("MapSetToggle").gameObject;
        mapsetToggle = mgo.GetComponent<Toggle>();
        var fgo = transform.Find("FrameToggle").gameObject;
        frameToggle = fgo.GetComponent<Toggle>();
        var bgo = transform.Find("B19Toggle").gameObject;
        b19Toggle = bgo.GetComponent<Toggle>();
        var ggo = transform.Find("GeneralToggle").gameObject;
        generalToggle = ggo.GetComponent<Toggle>();
        var hgo = transform.Find("HelpToggle").gameObject;
        helpToggle = hgo.GetComponent<Toggle>();
        var ago = transform.Find("AboutToggle").gameObject;
        aboutToggle = ago.GetComponent<Toggle>();
        togGroup = GetComponent<ToggleGroup>();
        togGroup.allowSwitchOff = true; // otherwise it does not save state correctly when we turn off the panel
        SyncOptionsTabState();
    }
    public void SyncOptionsTabState()
    {
        if (!visualPanelGo) return; // not initialized yet
        //Debug.Log("SyncOptionsTabState");
        visualPanelGo.SetActive(visualToggle.isOn);
        mapSetGo.SetActive(mapsetToggle.isOn);
        framePanelGo.SetActive(frameToggle.isOn);
        b19PanelGo.SetActive(b19Toggle.isOn);
        generalPanelGo.SetActive(generalToggle.isOn);
        helpPanelGo.SetActive(helpToggle.isOn);
        aboutPanelGo.SetActive(aboutToggle.isOn);
        var heavyInit = false;
        if (heavyInit)
        {
            aboutPanel.FillAboutPanel();
            visualsPanel.InitVals();
            mapSetPanel.InitVals();
            framePanel.InitVals();
            b19Panel.InitVals();
            helpPanel.FillHelpPanel();
            generalPanel.InitVals();
        }
        else
        {
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
            if (b19Toggle.isOn)
            {
                b19Panel.InitVals();
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
            if (b19Toggle.isOn)
            {
                b19Panel.SetVals(closing: true);
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
