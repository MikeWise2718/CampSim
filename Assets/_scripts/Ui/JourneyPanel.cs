using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;

public class JourneyPanel : MonoBehaviour
{
    public SceneMan sman;
    BuildingMan bdman;
    JourneyMan jnman;
    UiMan uiman;

    Dropdown startBuildingDropdown;
    Text startBuildingText;
    Dropdown endBuildingDropdown;
    Text endBuildingText;

    Button closeButton;
    Button launchButton;

    List<string> stopts;
    List<string> edopts;

    public void Init0()
    {
        LinkObjectsAndComponents();
    }

    public void LinkObjectsAndComponents()
    {
        sman = FindObjectOfType<SceneMan>();
        uiman = sman.uiman;
        bdman = sman.bdman;
        jnman = sman.jnman;

        startBuildingDropdown = transform.Find("StartBuildingDropdown").gameObject.GetComponent<Dropdown>();
        startBuildingText = transform.Find("StartBuildingText").gameObject.GetComponent<Text>();

        endBuildingDropdown = transform.Find("EndBuildingDropdown").gameObject.GetComponent<Dropdown>();
        endBuildingText = transform.Find("EndBuildingText").gameObject.GetComponent<Text>();


        launchButton = transform.Find("LaunchButton").gameObject.GetComponent<Button>();
        launchButton.onClick.AddListener(delegate { LaunchJourney(); });
        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel();  });

    }
    public bool VerifyValues()
    {
        return true;
    }

    public void InitVals()
    {
        Debug.Log("JourneyPanels InitVals called");
        var errmsg = "Exception caught in JourneyPanel.Initvals";
        try
        {
            stopts = bdman.GetBuildingList();
            var inival = "Bld33";
            var idx = stopts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            startBuildingDropdown.ClearOptions();
            startBuildingDropdown.AddOptions(stopts);
            startBuildingDropdown.value = idx;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg} initializing startBuildingDropdown - ex.Message:{ex.Message}");
        }

        try
        {
            edopts = bdman.GetBuildingList();
            var inival = "Bld19";
            var idx = edopts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            endBuildingDropdown.ClearOptions();
            endBuildingDropdown.AddOptions(edopts);
            endBuildingDropdown.value = idx;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg} initializing endBuildingDropdown - ex.Message:{ex.Message}");
        }
    }


    public void LaunchJourney()
    {
        var bld1 = stopts[startBuildingDropdown.value];
        var bld2 = edopts[endBuildingDropdown.value];
        jnman.AddBldBldJourneyWithEphemeralPeople(bld1, bld2);
        Debug.Log($"Launch journey from {bld1} to {bld2}");
    }

    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
    }
    public void UpdateText()
    {
    }


    public void SetVals(bool closing = false)
    {
        Debug.Log($"JourneyPanel.SetVals called - closing:{closing}");

        //sman.RequestRefresh("JourneyPanel-SetVals");
    }

    float checkInterval = 1f;
    float lastCheck = 0;

    private void Update()
    {
        if (Time.time-lastCheck>checkInterval)
        {
            UpdateText();
            lastCheck = Time.time;
        }
    }

}
