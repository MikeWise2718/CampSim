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
    Text definedJourneyText;
    Text curJnySpecKeys;
    Text curJnySpecName;
    Text curJnySerializedStringText;

    Dropdown jnyDefinedJnysDropdown;


    InputField jnyNameInput;
    Dropdown jnyStartBuildingDropdown;
    Dropdown jnyStartRoomDropdown;
    Dropdown jnyEndBuildingDropdown;
    Dropdown jnyEndRoomDropdown;
    Dropdown jnyAvatarDropdown;
    InputField jnyPersonNameInput;

    Toggle jnyQuitOnEndToggle;
    InputField jnyEndActionInput;

    Button newButton;
    Button deleteButton;
    Button defineButton;
    Button launchButton;
    Button shadowButton;
    Button closeButton;

    List<string> startBuildingOpts;
    List<string> endBuildingOpts;
    List<string> avatarOpts;

    Dictionary<string,string> definedJourneys;
    Dictionary<string, UxUtils.UxSetting<string>> jkeys;


    public void Init0()
    {
        LinkObjectsAndComponents();
    }

    public string GenNewJourneyUniqueName()
    {
        var i = 1;
        var keylist = new List<string>(definedJourneys.Keys);
        while (i<=keylist.Count+1)
        {
            var ok = true;
            var newname = $"Journey{i:d3}";
            foreach(var key in keylist)
            {
                if (key==newname)
                {
                    ok = false;
                    break;
                }
            }
            if (ok) return newname;
            i++;
        }
        return "JourneyX";
    }

    public void LinkObjectsAndComponents()
    {
        sman = FindObjectOfType<SceneMan>();
        uiman = sman.uiman;
        bdman = sman.bdman;
        jnman = sman.jnman;

        statusMessageText = transform.Find("StatusMessageText").gameObject.GetComponent<Text>();
        curJnySerializedStringText = transform.Find("CurJnySerializedStringText").gameObject.GetComponent<Text>();
        curJnySpecKeys = transform.Find("CurJnySpecKeys").gameObject.GetComponent<Text>();
        curJnySpecName = transform.Find("CurJnySpecName").gameObject.GetComponent<Text>();
        definedJourneyText = transform.Find("DefinedJourney").gameObject.GetComponent<Text>();

        jnyDefinedJnysDropdown = transform.Find("JnyDefinedJnysDropdown").gameObject.GetComponent<Dropdown>();


        jnyNameInput = transform.Find("JnyNameInput").gameObject.GetComponent<InputField>();
        jnyStartBuildingDropdown = transform.Find("JnyStartBuildingDropdown").gameObject.GetComponent<Dropdown>();
        jnyStartRoomDropdown = transform.Find("JnyStartRoomDropdown").gameObject.GetComponent<Dropdown>();

        jnyEndBuildingDropdown = transform.Find("JnyEndBuildingDropdown").gameObject.GetComponent<Dropdown>();
        jnyEndRoomDropdown = transform.Find("JnyEndRoomDropdown").gameObject.GetComponent<Dropdown>();

        jnyPersonNameInput = transform.Find("JnyPersonNameInput").gameObject.GetComponent<InputField>();
        jnyAvatarDropdown = transform.Find("JnyAvatarDropdown").gameObject.GetComponent<Dropdown>();


        jnyQuitOnEndToggle = transform.Find("JnyQuitOnEndToggle").gameObject.GetComponent<Toggle>();
        jnyEndActionInput = transform.Find("JnyEndActionInput").gameObject.GetComponent<InputField>();

        newButton = transform.Find("NewButton").gameObject.GetComponent<Button>();
        newButton.onClick.AddListener(delegate { NewJourney(); });
        deleteButton = transform.Find("DeleteButton").gameObject.GetComponent<Button>();
        deleteButton.onClick.AddListener(delegate { DeleteJourney(); });

        defineButton = transform.Find("DefineButton").gameObject.GetComponent<Button>();
        defineButton.onClick.AddListener(delegate { DefineJourney(); });
        launchButton = transform.Find("LaunchButton").gameObject.GetComponent<Button>();
        launchButton.onClick.AddListener(delegate { LaunchJourney(); });
        shadowButton = transform.Find("ShadowButton").gameObject.GetComponent<Button>();
        shadowButton.onClick.AddListener(delegate { ShadowJourney(); });
        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel();  });

        jnyStartBuildingDropdown.onValueChanged.AddListener(delegate { RepopulateRoomsDropdownOnBldChange(jnyStartBuildingDropdown, jnyStartRoomDropdown); });
        jnyEndBuildingDropdown.onValueChanged.AddListener(delegate { RepopulateRoomsDropdownOnBldChange(jnyEndBuildingDropdown, jnyEndRoomDropdown); });
        jnyDefinedJnysDropdown.onValueChanged.AddListener(delegate { DefinedJourneyDropdownChanged(); });
    }

    public void DefinedJourneyDropdownChanged()
    {
        ClearStatusMessage();
        int idx = jnyDefinedJnysDropdown.value;
        var jslist = jnyDefinedJnysDropdown.options;
        var key = jslist[idx].ToString();
        if (definedJourneys.ContainsKey(key))
        {
            var ss = definedJourneys[key];
            var js = new JourneySpec(jnman.journeySpecMan, ss);
            definedJourney = js;
            SetValsToJourneySpec(js);
            Debug.Log($"DefinedJourneyDropdown changed key:{key}");
        }
        else
        {
            //NewJourney();
            Debug.Log($"DefinedJourneyDropdown changed to new journey");
        }
    }
    public void PopulateDefinedJourneyDropdown(string inijname="" )
    {
        Debug.Log("PopulateDefinedJourneyDropdown");
        try
        {
            var inival = inijname;
            var definedJourneysList = new List<string>(definedJourneys.Keys);
            definedJourneysList.Add("(blank)");
            var idx = definedJourneysList.FindIndex(s => s == inival);
            if (idx <= 0) idx = definedJourneysList.Count-1;// this is the blank entry we added
            //if (idx <= 0) idx = 0;
            jnyDefinedJnysDropdown.ClearOptions();
            jnyDefinedJnysDropdown.AddOptions(definedJourneysList);
            jnyDefinedJnysDropdown.value = idx;
        }
        catch (Exception ex)
        {
            sman.LggError($"Exception caught in JourneyPanel.PopulateDefinedJourneys jnyAvatarDropdown - ex.Message:{ex.Message}");
        }
    }

    public void RepopulateRoomsDropdownOnBldChange(Dropdown bldctrl,Dropdown roomctrl)
    {
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
        LoadDefinedJourneys();
        var curjnyname = jnman.curJnySpecName.Get();
        JourneySpec js;
        if (curjnyname != "")
        {
            if (!definedJourneys.ContainsKey(curjnyname))
            {
                js = GetNextNewJourneySpec();
                SetStatusMessage($"Initial journey name not found in defined journeys:{curjnyname}", error: true);
            }
            else
            {
                SetStatusMessage($"Initial journey name:{curjnyname}", error: false);
                var curjnyss = definedJourneys[curjnyname];
                js = new JourneySpec(jnman.journeySpecMan, curjnyss);
            }
        }
        else
        {
            js = GetNextNewJourneySpec();
            SetStatusMessage($"Initial journey name empty", error: false);
        }
        SetValsToJourneySpec(js);
    }


    public (bool ok,string val) GetJsKeySave(string key)
    {
        var wholekey = $"journeyspec_{key}";
        var uxset = new UxUtils.UxSetting<string>(wholekey, "");
        var sval = uxset.Get();
        var ok = false;
        if (sval != "")
        {
            ok = true;
        }
        return (ok, sval);
    }
    public void SetJsKeySave(string key,string sval)
    {
        var wholekey = $"journeyspec_{key}";
        var uxset = new UxUtils.UxSetting<string>(wholekey, "");
        uxset.SetAndSave(sval);
    }

    public void EraseJsKey(string key, string sval)
    {
        var wholekey = $"journeyspec_{key}";
        var uxset = new UxUtils.UxSetting<string>(wholekey, "");
        uxset.SetAndSave("");
        // doesn't actually delete the key - just erases its values
    }


    public void LoadDefinedJourneys()
    {
        definedJourneys = new Dictionary<string,string>();
        var curspeckeys = jnman.curJnySpecKeys.Get();
        if (curspeckeys != "")
        {
            var cskarr = curspeckeys.Split('|');
            foreach (var key in cskarr)
            {
                var (ok, sval) = GetJsKeySave(key);
                definedJourneys[key] = sval;
            }
        }
        var curkey = jnman.curJnySpecName.Get();
        Debug.Log($"LoadDefinedJourneys:{curkey}");
        PopulateDefinedJourneyDropdown( inijname:curkey ); 
    }



    public void SetValsToJourneySpec(JourneySpec js)
    {
        Debug.Log($"JourneyPanels.SetValsToJourneySpec called with js.displayName:{js.displayName}");
        jnman.curJnySpecName.SetAndSave(js.displayName);
        curJnySerializedStringText.text = js.SerialString();

        jnyNameInput.text = js.displayName;
        jnyPersonNameInput.text = js.princeSpec.pname;

        var errmsg = "Exception caught in JourneyPanel.SetValsToJourneySpec";
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

    }

    public void ClearStatusMessage()
    {
        statusMessageText.text = "";
    }

    public void SetStatusMessage(string message, bool error=false)
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
        var jname = jnyNameInput.text;
        var bld1 = startBuildingOpts[jnyStartBuildingDropdown.value];
        var bld2 = endBuildingOpts[jnyEndBuildingDropdown.value];
        Debug.Log($"BJS for {bld1} to {bld2}");
        var rs = new RouteSpec(jnman.journeySpecMan, RouteSpecMethod.BldRoomToBldRoom, bld1, "room1", bld2, "room3", "ephemeral");
        var jps = new JourneyPrincipalSpec(jm, JourneyMethod.walkjour, "ephemera", "Girl003");
        var aas = new ActionSpec(jm, JourneyEnd.disappear, quitAtDest: false, thingToDo: "nothing");
        var js = new JourneySpec(jm,jname, rs, jps, aas);
        return js;
    }

    JourneySpec definedJourney = null;
    Journey launchedJny = null;

    public void AddDefinedJourneyToKeys(JourneySpec js)
    {
        var newkey = js.displayName;
        var sval = js.SerialString();
        definedJourneys[newkey] = sval;
        SetJsKeySave(newkey, sval);
        var newkeystring = "";
        foreach (var key in definedJourneys.Keys)
        {
            if (newkeystring == "")
            {
                newkeystring = key;
            }
            else
            {
                newkeystring = $"{newkeystring}|{key}";
            }
        }
        jnman.curJnySpecKeys.SetAndSave(newkeystring);
        Debug.Log($"ADJTK key:{newkey} newkeystring:{newkeystring} listcnt:{definedJourneys.Count}");
        PopulateDefinedJourneyDropdown( inijname:newkey );
    }

    public void NewJourney()
    {
        ClearStatusMessage();
        var js = GetNextNewJourneySpec();
        SetValsToJourneySpec(js);
        curJnySerializedStringText.text = js.SerialString();
        jnman.curJnySpecName.SetAndSave("");
        //PopulateDefinedJourneyDropdown(inijname:"");
    }


    public void DeleteJourney()
    {
        ClearStatusMessage();
        var key = jnyNameInput.text;
        if (!definedJourneys.ContainsKey(key))
        {
            SetStatusMessage($"Journey {key} does not exist",error:true);
            return;
        }
        definedJourneys.Remove(key);
    }



    public void DefineJourney()
    {
        ClearStatusMessage();
        definedJourney = BuildJourneySpecFromControls();
        var ss = definedJourney.SerialString();
        curJnySerializedStringText.text = ss;
        //jnman.curJnySpec.SetAndSave(ss);
        //Debug.Log($"Defined {definedJourney.jouneyId} length:{ss.Length}");
        AddDefinedJourneyToKeys(definedJourney);
    }


    public void LaunchJourney()
    {
        ClearStatusMessage();
        if (definedJourney!=null)
        {
            launchedJny = jnman.AddJsmJourney(definedJourney);
            if (launchedJny)
            {
                SetStatusMessage($"Launched {launchedJny.name}");
            }
            else
            {
                SetStatusMessage($"Could not launch journey (jny==null)",error:true);
            }
        }
        else
        {
            SetStatusMessage("No journey has been defined yet for shadoing", error: true);
        }
    }

    public void ShadowJourney()
    {
        ClearStatusMessage();
        if (launchedJny != null)
        {
            jnman.journeyToShadow = launchedJny.name;
            jnman.shadowJourney = true;
            SetStatusMessage($"Shadowing {launchedJny.name}");
        }
        else
        {
            SetStatusMessage("No journey has been launched yet",error:true);
        }
    }
    RouteSpec defaultRoute;
    JourneyPrincipalSpec defaultPrinceSpec;
    ActionSpec defaultActionSpec;

    JourneySpec GetNextNewJourneySpec()
    {
        var newname = GenNewJourneyUniqueName();
        var jm = jnman.journeySpecMan;
        var js = new JourneySpec(jm, newname, defaultRoute, defaultPrinceSpec, defaultActionSpec);
        return js;
    }
    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
        string b1name="Bld3X";
        string b1room="lobby";
        string b2name="BldY";
        string b2room="lobby";
        string personname = "Eve";
        string avaname = "People/Businesswoman001";
        switch (curscene)
        {
            case SceneSelE.MsftB121focused:
                {
                    b1name = "Bld121";
                    b1room = "lobby";
                    b2name = "Bld19";
                    b2room = "lobby";
                    personname = "Mary DelaB121";
                    avaname = "People/Businesswoman002";
                    break;
                }
            case SceneSelE.MsftB19focused:
                {
                    b1name = "Bld19";
                    b1room = "lobby";
                    b2name = "Bld121";
                    b2room = "lobby";
                    personname = "Wei VonB19";
                    avaname = "People/Businesswoman003";
                    b2room = "lobby";
                    break;
                }
            case SceneSelE.MsftB33focused:
                {
                    b1name = "Bld33";
                    b1room = "lobby";
                    b2name = "Bld19";
                    b2room = "lobby";
                    personname = "Fatma VanB33";
                    avaname = "People/Businesswoman004";
                    b2room = "lobby";
                    break;
                }
        }
        var jm = jnman.journeySpecMan;
        var rs = new RouteSpec(jm, RouteSpecMethod.BldRoomToBldRoom,b1name,b1room,b2name,b2room, avaname);
        var jjps = new JourneyPrincipalSpec(jm, JourneyMethod.walkjour, personname, avaname);
        var aas = new ActionSpec(jm, JourneyEnd.disappear, quitAtDest: false, "nothingtodo");
        defaultActionSpec = aas;
        defaultPrinceSpec = jjps;
        defaultRoute = rs;
    }
    public void UpdateText()
    {
        if (definedJourney == null)
        {
            definedJourneyText.text = "definedJourney:null";
        }
        else
        {
            definedJourneyText.text = $"definedJourney:{definedJourney.displayName}";
        }

        curJnySpecKeys.text = $"jman.CurJnySpecKeys:{jnman.curJnySpecKeys.Get()}";
        curJnySpecName.text = $"jman.CurJnySpecName:{jnman.curJnySpecName.Get()}";
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
