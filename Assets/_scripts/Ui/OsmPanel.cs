using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;
using System.Linq;
using UnityScript.Steps;

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
    InputField shortNameInput;
    InputField levelsInput;
    InputField heightInput;
    InputField sockOffsetInput;
    Dropdown groundRefDropdown;

    Dropdown renderModeDropdown;
    InputField transparentInput;


    Button closeButton;
    Button applyButton;

    Dictionary<string, Building> definedBuildings = null;

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
        shortNameInput = transform.Find("ShortNameInput").gameObject.GetComponent<InputField>();
        levelsInput = transform.Find("LevelsInput").gameObject.GetComponent<InputField>();
        heightInput = transform.Find("HeightInput").gameObject.GetComponent<InputField>();
        sockOffsetInput = transform.Find("SockOffsetInput").gameObject.GetComponent<InputField>();
        groundRefDropdown = transform.Find("GroundRefDropdown").gameObject.GetComponent<Dropdown>();

        renderModeDropdown = transform.Find("RenderModeDropdown").gameObject.GetComponent<Dropdown>();
        transparentInput = transform.Find("TransparentInput").gameObject.GetComponent<InputField>();


        applyButton = transform.Find("ApplyButton").gameObject.GetComponent<Button>();
        applyButton.onClick.AddListener(delegate { ApplyValues(); });
        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel(); });

        controlsBeingBuilt = true;

        buildingNameDropdown.onValueChanged.AddListener(delegate { DefinedBuildingyDropdownChanged(); });
        applyButton.onClick.AddListener(delegate { ReadOutControlsIntoBuilding(); });
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel(); });

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
        var bld = bdman.GetBuilding(selbld);
        if (bld == null)
        {
            var blist = new List<string>(definedBuildings.Keys);
            if (blist.Count > 0)
            {
                bld = bdman.GetBuilding(blist[0]);
            }
        }
        if (bld != null)
        {
            PopulateFormValsWithBuilding(bld);
        }
    }
    public string MakeNameUnique(string bname)
    {
        if (!definedBuildings.ContainsKey(bname))
        {
            return bname;
        }
        int i = 1;
        var nname = $"{bname} ({i})";
        while (definedBuildings.ContainsKey(nname))
        {
            i += 1;
            nname = $"{bname} ({i})";
            if (i > 1000) break;
        }
        return nname;
    }

    public void LoadBuildings(string selbld)
    {
        var bldlist = bdman.GetAllBuildings();
        definedBuildings = new Dictionary<string, Building>();
        foreach (var bname in bldlist)
        {
            var bld = bdman.GetBuilding(bname);
            definedBuildings[bname] = bld;
        }
        PopulateDefinedBuildingsDropdown(selbld);
    }
    public void PopulateDefinedBuildingsDropdown(string inibldname = "")
    {
        sman.Lgg("PopulateDefinedBuildingsDropdown", "amber");
        try
        {
            var inival = inibldname;
            var definedBuildingList = new List<string>(definedBuildings.Keys);
            definedBuildingList.Add("(blank)");
            var idx = definedBuildingList.FindIndex(s => s == inival);
            if (idx < 0) idx = definedBuildingList.Count - 1;// this is the blank entry we added
            //if (idx <= 0) idx = 0;
            buildingNameDropdown.ClearOptions();
            buildingNameDropdown.AddOptions(definedBuildingList);
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
            var bld = definedBuildings[key];
            var wid = "";
            var bpec = bld.bldspec;
            if (bpec != null)
            {
                wid = bpec.wid;
            }
            widText.text = wid;
            if (repopulateOnValueChanged)
            {
                PopulateFormValsWithBuilding(bld);
            }
            sman.Lgg($"DefinedBuildingyDropdownChanged changed key:{key}", "orange");
        }
        else
        {
            sman.Lgg($"DefinedBuildingyDropdownChanged out of range:{idx} definedBuildings:{definedBuildings.Count}", "orange");
        }
        controlsBeingBuilt = false;
    }

    public int GetIntFromText(string txt, int def, int imin, int imax)
    {
        var ok = int.TryParse(txt, out int ival);
        if (!ok)
        {
            return def;
        }
        var rv = Math.Max(imin, Math.Min(imax, ival));
        return rv;
    }
    public float GetFloatFromText(string txt, float def, float fmin, float fmax)
    {
        var ok = float.TryParse(txt, out float fval);
        if (!ok)
        {
            return def;
        }
        var rv = Mathf.Max(fmin, Mathf.Min(fmax, fval));
        return rv;
    }

    public void SetBspecFromControls(OsmBldSpec bspec)
    {
        bspec.isVisible = visibleToggle.isOn;
        bspec.shortname = shortNameInput.text;
        bspec.levels = GetIntFromText(levelsInput.text, 1, 1, 200);
        bspec.height = GetFloatFromText(heightInput.text, 4, 0, 1000);
        bspec.sockOffset = GetFloatFromText(sockOffsetInput.text, 0, 0, 1000);
        {
            var grftxt = Enum.GetName(typeof(GroundRef), groundRefDropdown.value);
            var ok = System.Enum.TryParse<GroundRef>(grftxt, true, out GroundRef genumval);
            if (!ok)
            {
                Debug.LogError($"Bad enum text ({grftxt}) - unknown error - should not happen");
            }
            else
            {
                bspec.groundRef = genumval;
            }
        }

        {
            var rentxt = Enum.GetName(typeof(OsmBldRenderMode), renderModeDropdown.value);
            var ok = System.Enum.TryParse<OsmBldRenderMode>(rentxt, true, out OsmBldRenderMode renumval);
            if (!ok)
            {
                Debug.LogError($"Bad enum text ({rentxt}) - unknown error - should not happen");
            }
            else
            {
                bspec.renmode = renumval;
            }
        }
        transparentInput.text = bspec.transparency.ToString("f3");
    }

    public void RealizeChanges(Building bld)
    {
        if (bld == null)
        {
            var bname = bdman.selectedbldname.Get();
            bld = bdman.GetBuilding(bname);
        }
        if (bld != null)
        {
            bdman.UpdateFloorHeights();
            bld.DeleteGos();
            bld.CreateGos();
            bdman.sman.lcman.RefreshGos();
        }
    }


    public void ReadOutControlsIntoBuilding()
    {
        if (!controlsBeingBuilt)
        {
            var bname = bdman.selectedbldname.Get();
            var bld = bdman.GetBuilding(bname);
            if (bld != null)
            {
                var bspec = bld.bldspec;
                if (bspec != null)
                {
                    SetBspecFromControls(bspec);
                    RealizeChanges(null);
                }
            }
        }
    }


    public void PopulateFormValsWithBuilding(Building bld)
    {
        sman.Lgg($"OsmPanel.PopulateFormValsWithBuilding called with bld:{bld.shortname}", "green");
        controlsBeingBuilt = true;
        bdman.selectedbldname.SetAndSave(bld.name);
        OsmBldSpec bspec = bld.bldspec;
        if (bspec==null)
        {
            SetStatusMessage("No OSM data for building", error: true);
            controlsBeingBuilt = false;
            return;
        }

        visibleToggle.isOn = bspec.isVisible;
        shortNameInput.text = bspec.shortname;
        levelsInput.text = bspec.levels.ToString();
        heightInput.text = bspec.height.ToString();
        sockOffsetInput.text = bspec.sockOffset.ToString();
        transparentInput.text = bspec.transparency.ToString("f3");

        try
        {
            var osmBldSpecNames = new List<string>(Enum.GetNames(typeof(GroundRef)));
            var inival = bspec.groundRef;
            var idx = osmBldSpecNames.FindIndex(s => s == inival.ToString());
            if (idx <= 0) idx = 0;

            groundRefDropdown.ClearOptions();
            groundRefDropdown.AddOptions(osmBldSpecNames);
            groundRefDropdown.value = idx;
            sman.Lgg($"groundRefDropdown value:{idx}");
        }
        catch (Exception ex)
        {
            sman.LggError($"OsmPanel.PopulateFormValsWithBuilding initializing groundRefDropdown - ex.Message:{ex.Message}");
        }

        try
        {
            var renModeNames = new List<string>(Enum.GetNames(typeof(OsmBldRenderMode)));
            var inival = bspec.renmode;
            var idx = renModeNames.FindIndex(s => s == inival.ToString());
            if (idx <= 0) idx = 0;

            renderModeDropdown.ClearOptions();
            renderModeDropdown.AddOptions(renModeNames);
            renderModeDropdown.value = idx;
            sman.Lgg($"renderModeDropdown value:{idx}");
        }
        catch (Exception ex)
        {
            sman.LggError($"OsmPanel.PopulateFormValsWithBuilding initializing groundRefDropdown - ex.Message:{ex.Message}");
        }


        finally
        {
            controlsBeingBuilt = false;
        }
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
