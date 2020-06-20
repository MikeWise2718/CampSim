using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;

public class FramePanel : MonoBehaviour
{
    public SceneMan sman;
    FrameMan fman;
    UiMan uiman;

    Toggle visTiedToggle;

    Toggle showCarsToggle;
    Toggle showPersToggle;
    Toggle showHeadToggle;

    Toggle frameJourneys;
    Toggle frameBuildings;
    Toggle frameGarages;
    Toggle frameZones;

    Dropdown topTextDropdown;
    Dropdown botTextDropdown;

    Button closeButton;


    bool panelActive = false;

    public void Init0()
    {
        panelActive = false;
        LinkObjectsAndComponents();
    }
    public void LinkObjectsAndComponents()
    {
        uiman = sman.uiman;
        fman = sman.frman;
        visTiedToggle = transform.Find("VisibilityTiedToggle").gameObject.GetComponent<Toggle>();
        showCarsToggle = transform.Find("ShowCarRectsToggle").gameObject.GetComponent<Toggle>();
        showPersToggle = transform.Find("ShowPersRectsToggle").gameObject.GetComponent<Toggle>();
        showHeadToggle = transform.Find("ShowHeadRectsToggle").gameObject.GetComponent<Toggle>();
        frameJourneys = transform.Find("FrameJourneysToggle").gameObject.GetComponent<Toggle>();
        frameBuildings = transform.Find("FrameBuildingsToggle").gameObject.GetComponent<Toggle>();
        frameGarages = transform.Find("FrameGaragesToggle").gameObject.GetComponent<Toggle>();
        frameZones = transform.Find("FrameZonesToggle").gameObject.GetComponent<Toggle>();
        topTextDropdown = transform.Find("TopTextDropdown").gameObject.GetComponent<Dropdown>();
        botTextDropdown = transform.Find("BotTextDropdown").gameObject.GetComponent<Dropdown>();
        panelActive = true;

        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel(); });
    }


    public void InitVals()
    {
        visTiedToggle.isOn = fman.visibilityTiedToDetectability.Get();
        showCarsToggle.isOn = fman.showCarRects.Get();
        showPersToggle.isOn = fman.showPersRects.Get();
        showHeadToggle.isOn = fman.showHeadRects.Get();
        frameJourneys.isOn = fman.frameJourneys.Get();
        frameBuildings.isOn = fman.frameBuildings.Get();
        frameGarages.isOn = fman.frameGarages.Get();
        frameZones.isOn = fman.frameZones.Get();

        {
            var opts = fman.topLabelText.GetOptionsAsList();
            var inival = fman.topLabelText.Get().ToString();
            var idx = opts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;
            topTextDropdown.ClearOptions();
            topTextDropdown.AddOptions(opts);
            topTextDropdown.value = idx;
        }
        {
            var opts = fman.botLabelText.GetOptionsAsList();
            var inival = fman.botLabelText.Get().ToString();
            var idx = opts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;
            botTextDropdown.ClearOptions();
            botTextDropdown.AddOptions(opts);
            botTextDropdown.value = idx;
        }


        panelActive = true;
    }

    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
    }


    int nSetTextValuesCalled = 0;
    private void SetTextValues()
    {
        nSetTextValuesCalled += 1;
    }


    public void SetVals(bool closing = false)
    {
        Debug.Log($"FramePanel.SetVals called - closing:{closing}");
        fman.visibilityTiedToDetectability.SetAndSave(visTiedToggle.isOn);
        fman.showCarRects.SetAndSave(showCarsToggle.isOn);
        fman.showPersRects.SetAndSave(showPersToggle.isOn);
        fman.showHeadRects.SetAndSave(showHeadToggle.isOn);
        fman.frameJourneys.SetAndSave(frameJourneys.isOn);
        fman.frameBuildings.SetAndSave(frameBuildings.isOn);
        fman.frameGarages.SetAndSave(frameGarages.isOn);
        fman.frameZones.SetAndSave(frameZones.isOn);

        {
            var opts = fman.topLabelText.GetOptionsAsList();
            var newval = opts[topTextDropdown.value];
            fman.topLabelText.SetAndSave(newval);
            Debug.Log("SetAndSave toptextlabel default to " + newval);
        }
        {
            var opts = fman.botLabelText.GetOptionsAsList();
            var newval = opts[botTextDropdown.value];
            fman.botLabelText.SetAndSave(newval);
            Debug.Log("SetAndSave botLabelText default to " + newval);
        }
        panelActive = false;
        sman.RequestRefresh("FramePanel-SetVals");
    }

}
