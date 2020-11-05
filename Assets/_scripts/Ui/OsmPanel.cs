using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;
using System.Linq;

public class OsmPanel : MonoBehaviour
{
    public SceneMan sman;
    UiMan uiman;
    BuildingMan bdman;

    Text statusMessageText;

    Dropdown buildingNameDropdown;
    Text buildingNameText;
    Text widText;
    Toggle visibleToggle;
    InputField levelsInput;
    InputField heightInput;
    InputField sockOffsetInput;
    Dropdown groundRefDropdown;

    InputField transparentInput;
    Toggle transparentToggle;


    Button closeButton;
    Button applyButton;

    Dictionary<string, string> definedBuildings=null;

    public void Init0()
    {
        LinkObjectsAndComponents();
    }

    public void LinkObjectsAndComponents()
    {
        sman = FindObjectOfType<SceneMan>();
        uiman = sman.uiman;
        bdman = sman.bdman;

        statusMessageText = transform.Find("StatusMessageText").gameObject.GetComponent<Text>();

        buildingNameDropdown = transform.Find("BuildingNameDropdown").gameObject.GetComponent<Dropdown>();
        buildingNameText = transform.Find("BuildingNameText").gameObject.GetComponent<Text>();
        widText = transform.Find("WidText").gameObject.GetComponent<Text>();

        visibleToggle = transform.Find("VisibleToggle").gameObject.GetComponent<Toggle>();
        levelsInput = transform.Find("LevelsInput").gameObject.GetComponent<InputField>();
        heightInput = transform.Find("HeightInput").gameObject.GetComponent<InputField>();
        sockOffsetInput = transform.Find("SockOffsetInput").gameObject.GetComponent<InputField>();
        groundRefDropdown = transform.Find("GroundRefDropdown").gameObject.GetComponent<Dropdown>();

        transparentInput = transform.Find("TransparentInput").gameObject.GetComponent<InputField>();
        transparentToggle = transform.Find("TransparentToggle").gameObject.GetComponent<Toggle>();


        applyButton = transform.Find("ApplyButton").gameObject.GetComponent<Button>();
        applyButton.onClick.AddListener(delegate { ApplyValues(); });
        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel();  });

        controlsBeingBuilt = true;

        buildingNameDropdown.onValueChanged.AddListener(delegate { DefinedBuildingyDropdownChanged(); });

        controlsBeingBuilt = false;

    }
    public bool ApplyValues()
    {
        return true;
    }

    public void InitVals()
    {
        Debug.Log("OsmPanel InitVals called");
        var selbld = bdman.selectedbldname.Get();
        LoadBuildings(selbld);
    }
    public void LoadBuildings(string selbld)
    {
        var bldlist = bdman.GetBuildingList();
        definedBuildings = new Dictionary<string, string>();
        foreach(var bname in bldlist)
        {
            var bld = bdman.GetBuilding(bname);
            var val = "";
            var bpec = bld.bldspec;
            if (bpec!=null)
            {
                val = bpec.wid;
            }
            definedBuildings[bname] = val;
        }
        PopulateDefinedBuildingsDropdown(selbld);
    }
    public void PopulateDefinedBuildingsDropdown(string inibldname = "")
    {
        sman.Lgg("PopulateDefinedBuildingsDropdown","amber");
        try
        {
            var inival = inibldname;
            var definedJourneysList = new List<string>(definedBuildings.Keys);
            definedJourneysList.Add("(blank)");
            var idx = definedJourneysList.FindIndex(s => s == inival);
            if (idx < 0) idx = definedJourneysList.Count - 1;// this is the blank entry we added
            //if (idx <= 0) idx = 0;
            buildingNameDropdown.ClearOptions();
            buildingNameDropdown.AddOptions(definedJourneysList);
            repopulateOnValueChanged = false;
            buildingNameDropdown.value = idx;
            repopulateOnValueChanged = true;
        }
        catch (Exception ex)
        {
            sman.LggError($"Exception caught in JourneyPanel.PopulateDefinedJourneys jnyAvatarDropdown - ex.Message:{ex.Message}");
        }
    }

    public void ClearStatusMessage()
    {
        statusMessageText.text = "";
    }

    public void SetStatusMessage(string message, bool error = false)
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


    bool controlsBeingBuilt = false;
    bool repopulateOnValueChanged = true;
    public void DefinedBuildingyDropdownChanged()
    {
        controlsBeingBuilt = true;

        ClearStatusMessage();
        int idx = buildingNameDropdown.value;
        var bldlist = definedBuildings.Keys.ToList<string>();
        if (idx < definedBuildings.Count)
        {
            var key = bldlist[idx].ToString();
            var ss = definedBuildings[key];
            widText.text = definedBuildings[key];
            //var js = new JourneySpec(jnman.journeySpecMan, ss);
            //definedJourney = js;
            //if (repopulateOnValueChanged)
            //{
            //    PopulateFormValsWithJourneySpec(js);
            //}
            sman.Lgg($"DefinedBuildingyDropdownChanged changed key:{key}", "orange");
        }
        else
        {
            sman.Lgg($"DefinedBuildingyDropdownChanged out of range:{idx} definedBuildings:{definedBuildings.Count}", "orange");
        }
        controlsBeingBuilt = false;
    }

    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
    }
    public void UpdateText()
    {
    }

    public void SetVals(bool closing = false)
    {
        Debug.Log($"Osm.SetVals called - closing:{closing}");

        //sman.RequestRefresh("OsmPanel-SetVals");
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
