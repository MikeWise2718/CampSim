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

    Dropdown jnyDefinedJnysDropdown;


    InputField jnyIdInput;
    Dropdown jnyStartBuildingDropdown;
    Dropdown jnyStartRoomDropdown;
    Dropdown jnyEndBuildingDropdown;
    Dropdown jnyEndRoomDropdown;
    Dropdown jnyAvatarDropdown;
    Toggle jnyQuitOnEndToggle;
    InputField jnyEndActionInput;

    Button defineButton;
    Button launchButton;
    Button shadowButton;
    Button closeButton;

    List<string> startBuildingOpts;
    List<string> endBuildingOpts;
    List<string> avatarOpts;

    List<string> definedJourneys;


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

        jnyDefinedJnysDropdown = transform.Find("JnyDefinedJnysDropdown").gameObject.GetComponent<Dropdown>();


        jnyIdInput = transform.Find("JnyIdInput").gameObject.GetComponent<InputField>();
        jnyStartBuildingDropdown = transform.Find("JnyStartBuildingDropdown").gameObject.GetComponent<Dropdown>();
        jnyStartRoomDropdown = transform.Find("JnyStartRoomDropdown").gameObject.GetComponent<Dropdown>();

        jnyEndBuildingDropdown = transform.Find("JnyEndBuildingDropdown").gameObject.GetComponent<Dropdown>();
        jnyEndRoomDropdown = transform.Find("JnyEndRoomDropdown").gameObject.GetComponent<Dropdown>();

        jnyAvatarDropdown = transform.Find("JnyAvatarDropdown").gameObject.GetComponent<Dropdown>();


        jnyQuitOnEndToggle = transform.Find("JnyQuitOnEndToggle").gameObject.GetComponent<Toggle>();
        jnyEndActionInput = transform.Find("JnyEndActionInput").gameObject.GetComponent<InputField>();


        defineButton = transform.Find("DefineButton").gameObject.GetComponent<Button>();
        defineButton.onClick.AddListener(delegate { DefineJourney(); });
        launchButton = transform.Find("LaunchButton").gameObject.GetComponent<Button>();
        launchButton.onClick.AddListener(delegate { LaunchJourney(); });
        shadowButton = transform.Find("ShadowButton").gameObject.GetComponent<Button>();
        shadowButton.onClick.AddListener(delegate { ShadowJourney(); });
        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel();  });

        jnyStartBuildingDropdown.onValueChanged.AddListener(delegate { RepopulateRoomsDropdown(jnyStartBuildingDropdown, jnyStartRoomDropdown); });
        jnyEndBuildingDropdown.onValueChanged.AddListener(delegate { RepopulateRoomsDropdown(jnyEndBuildingDropdown, jnyEndRoomDropdown); });
    }


    public void RepopulateRoomsDropdown(Dropdown bldctrl,Dropdown roomctrl)
    {
        var ctrlbldname = bldctrl.name;
        var curbldval = bldctrl.value;
        var bldlist = bdman.GetBuildingList();
        var bldname = bldlist[curbldval];
        //Debug.Log($"{ctrlbldname} dropdown changed current bld:{bldname}");
        var bld = bdman.GetBuilding(bldname);
        var roomlist = bld.GetRoomNames();
        //Debug.Log($"Found {roomlist.Count} rooms for {bldname}");
        roomctrl.ClearOptions();
        roomctrl.AddOptions(roomlist);
    }



    public void InitVals()
    {
        Debug.Log("JourneyPanels InitVals called");
        var curjnystr = jnman.curJnySpec.Get();
        var js = new JourneySpec(jnman.journeySpecMan,curjnystr);
        LoadDefinedJourneys();
        InitVals(js);
    }

    public void LoadDefinedJourneys()
    {
        definedJourneys = new List<string>();
    }

    public void InitVals(JourneySpec js)
    {
        Debug.Log("JourneyPanels InitVals called");
        curJnySerializedStringText.text = js.SerialString();

        jnyIdInput.text = js.jouneyId;

        var errmsg = "Exception caught in JourneyPanel.Initvals";
        try
        {
            startBuildingOpts = bdman.GetBuildingList();
            var inival = js.routeSpec.bld1name;
            var idx = startBuildingOpts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            jnyStartBuildingDropdown.ClearOptions();
            jnyStartBuildingDropdown.AddOptions(startBuildingOpts);
            jnyStartBuildingDropdown.value = idx;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg} initializing jnyStartBuildingDropdown - ex.Message:{ex.Message}");
        }

        try
        {
            endBuildingOpts = bdman.GetBuildingList();
            var inival = js.routeSpec.bld2name;
            var idx = endBuildingOpts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            jnyEndBuildingDropdown.ClearOptions();
            jnyEndBuildingDropdown.AddOptions(endBuildingOpts);
            jnyEndBuildingDropdown.value = idx;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg} initializing jnyEndBuildingDropdown - ex.Message:{ex.Message}");
        }

        try
        {
            avatarOpts = avatars;
            var inival = js.princeSpec.avatar;
            var idx = avatarOpts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            jnyAvatarDropdown.ClearOptions();
            jnyAvatarDropdown.AddOptions(avatarOpts);
            jnyAvatarDropdown.value = idx;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg} initializing jnyAvatarDropdown - ex.Message:{ex.Message}");
        }

        PopulateDefinedJourneys();
    }

    public void PopulateDefinedJourneys()
    {
        try
        {
            var inival = "";
            var idx = definedJourneys.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            jnyDefinedJnysDropdown.ClearOptions();
            jnyDefinedJnysDropdown.AddOptions(definedJourneys);
            jnyDefinedJnysDropdown.value = idx;
        }
        catch (Exception ex)
        {
            sman.LggError($"Exception caught in JourneyPanel.PopulateDefinedJourneys jnyAvatarDropdown - ex.Message:{ex.Message}");
        }
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


    List<string> avatars = new List<string>()
    {
        "drone/drone1",
        "drone/drone2",
        "People/Businesswoman001",
        "People/Businesswoman002",
        "People/Businesswoman003",
        "People/Businesswoman004",
        "People/Businesswoman005",
        "People/Businessman001",
        "People/Businessman002",
        "People/Businessman003",
        "People/Businessman004",
        "People/Businessman005",
    };

    public JourneySpec BuildJourneySpecFromControls()
    {
        var jm = jnman.journeySpecMan;
        var bld1 = startBuildingOpts[jnyStartBuildingDropdown.value];
        var bld2 = endBuildingOpts[jnyEndBuildingDropdown.value];
        Debug.Log($"BJS for {bld1} to {bld2}");
        var rs = new RouteSpec(jnman.journeySpecMan, RouteSpecMethod.BldRoomToBldRoom, bld1, "room1", bld2, "room3", "ephemeral");
        var jps = new JourneyPrincipalSpec(jm, JourneyMethod.walkjour, "ephemera", "Girl003");
        var aas = new ActionSpec(jm, JourneyEnd.disappear, quitAtDest: false, thingToDo: "nothing");
        var jid = jm.GetNewJourneyId();
        var js = new JourneySpec(jm,jid, rs, jps, aas);
        return js;
    }

    JourneySpec definedJourney = null;
    Journey launchedJny = null;

    public void DefineJourney()
    {
        definedJourney = BuildJourneySpecFromControls();
        var ss = definedJourney.SerialString();
        jnman.curJnySpec.SetAndSave(ss);
        Debug.Log($"Defined {definedJourney.jouneyId} length:{ss.Length}");
        definedJourneys.Add(definedJourney.jouneyId);
        PopulateDefinedJourneys();
    }


    public void LaunchJourney()
    {
        if (definedJourney!=null)
        {
            launchedJny = jnman.AddJsmJourney(definedJourney);
            Debug.Log($"Launched {launchedJny.name}");
        }
        else
        {
            SetStatusMessage("No journey has been defined yet", error: true);
        }
    }

    public void ShadowJourney()
    {
        if (launchedJny != null)
        {
            jnman.journeyToShadow = launchedJny.name;
            jnman.shadowJourney = true;
            Debug.Log($"Shadowing {launchedJny.name}");
        }
        else
        {
            SetStatusMessage("No journey has been launched yet",error:true);
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
