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

    Text statusMessageText;
    Text curJnySerializedStringText;
    InputField jnyIdInput;
    Dropdown jnyStartBuildingDropdown;
    Dropdown jnyStartRoomDropdown;
    Dropdown jnyEndBuildingDropdown;
    Dropdown jnyEndRoomDropdown;
    Toggle jnyQuitOnEndToggle;
    InputField jnyEndActionInput;

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

        statusMessageText = transform.Find("StatusMessageText").gameObject.GetComponent<Text>();
        curJnySerializedStringText = transform.Find("CurJnySerializedStringText").gameObject.GetComponent<Text>();


        jnyIdInput = transform.Find("JnyIdInput").gameObject.GetComponent<InputField>();
        jnyStartBuildingDropdown = transform.Find("JnyStartBuildingDropdown").gameObject.GetComponent<Dropdown>();
        jnyStartRoomDropdown = transform.Find("JnyStartRoomDropdown").gameObject.GetComponent<Dropdown>();

        jnyEndBuildingDropdown = transform.Find("JnyEndBuildingDropdown").gameObject.GetComponent<Dropdown>();
        jnyEndRoomDropdown = transform.Find("JnyEndRoomDropdown").gameObject.GetComponent<Dropdown>();
        jnyQuitOnEndToggle = transform.Find("JnyQuitOnEndToggle").gameObject.GetComponent<Toggle>();
        jnyEndActionInput = transform.Find("JnyEndActionInput").gameObject.GetComponent<InputField>();


        launchButton = transform.Find("LaunchButton").gameObject.GetComponent<Button>();
        launchButton.onClick.AddListener(delegate { LaunchJourney(); });
        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel();  });

    }
    public bool VerifyValues()
    {
        return true;
    }

    public void SetStatusMessage(string message, bool error)
    {
        statusMessageText.text = message;
        if (error)
        {
            statusMessageText.color = Color.red;
        }
        else
        {
            statusMessageText.color = Color.black;
        }
    }

    public void InitVals()
    {
        Debug.Log("JourneyPanels InitVals called");
        var curjny = jnman.curJnySpec.Get();
        if (curjny=="")
        {

            var js = new JourneySpec(jnman.journeySpecMan,"");
            curjny = js.SerialString();
        }
        curJnySerializedStringText.text = curjny;

        var errmsg = "Exception caught in JourneyPanel.Initvals";
        try
        {
            stopts = bdman.GetBuildingList();
            var inival = "Bld33";
            var idx = stopts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            jnyStartBuildingDropdown.ClearOptions();
            jnyStartBuildingDropdown.AddOptions(stopts);
            jnyStartBuildingDropdown.value = idx;
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

            jnyEndBuildingDropdown.ClearOptions();
            jnyEndBuildingDropdown.AddOptions(edopts);
            jnyEndBuildingDropdown.value = idx;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg} initializing endBuildingDropdown - ex.Message:{ex.Message}");
        }
    }


    public void LaunchJourney()
    {
        var bld1 = stopts[jnyStartBuildingDropdown.value];
        var bld2 = edopts[jnyEndBuildingDropdown.value];
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
