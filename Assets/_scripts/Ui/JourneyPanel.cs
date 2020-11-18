using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;
using System.Linq;

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
    Dropdown jnytypeDropdown;


    InputField jnyNameInput;
    Dropdown jnyStartBuildingDropdown;
    Dropdown jnyStartRoomDropdown;
    Dropdown jnyEndBuildingDropdown;
    Dropdown jnyEndRoomDropdown;
    Dropdown jnyAvatarDropdown;
    Dropdown jnyEndActionDropdown;
    InputField jnyPersonNameInput;

    Toggle jnyQuitOnEndToggle;
    InputField jnyEndCmdInput;

    Button newButton;
    Button deleteButton;
    Button defineButton;
    Button launchButton;
    Button shadowButton;
    Button closeButton;

    List<string> startBuildingOpts;
    List<string> startRoomOpts;
    List<string> endBuildingOpts;
    List<string> endRoomOpts;
    List<string> avatarOpts;
    List<string> jourEndOpts;

    Dictionary<string,string> definedJourneys;
    //Dictionary<string, UxUtils.UxSetting<string>> jkeys;

    public UxUtils.UxEnumSetting<JourneyType>  curjnytype = new UxUtils.UxEnumSetting<JourneyType>("curjnytype", JourneyType.BldRoomToBldRoom );


    public void Init0()
    {
        LinkObjectsAndComponents();
    }

    public string GenNewJourneyUniqueName(string rootname="Journey")
    {
        var i = 1;
        var keylist = new List<string>(definedJourneys.Keys);
        while (i<=keylist.Count+1)
        {
            var ok = true;
            var newname = $"{rootname}{i:d3}";
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
        return "{root}X";
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
        jnytypeDropdown = transform.Find("JnytypeDropdown").gameObject.GetComponent<Dropdown>();


        jnyNameInput = transform.Find("JnyNameInput").gameObject.GetComponent<InputField>();
        jnyStartBuildingDropdown = transform.Find("JnyStartBuildingDropdown").gameObject.GetComponent<Dropdown>();
        jnyStartRoomDropdown = transform.Find("JnyStartRoomDropdown").gameObject.GetComponent<Dropdown>();

        jnyEndBuildingDropdown = transform.Find("JnyEndBuildingDropdown").gameObject.GetComponent<Dropdown>();
        jnyEndRoomDropdown = transform.Find("JnyEndRoomDropdown").gameObject.GetComponent<Dropdown>();

        jnyPersonNameInput = transform.Find("JnyPersonNameInput").gameObject.GetComponent<InputField>();
        jnyAvatarDropdown = transform.Find("JnyAvatarDropdown").gameObject.GetComponent<Dropdown>();
        jnyEndActionDropdown = transform.Find("JnyEndActionDropdown").gameObject.GetComponent<Dropdown>();


        jnyQuitOnEndToggle = transform.Find("JnyQuitOnEndToggle").gameObject.GetComponent<Toggle>();
        jnyEndCmdInput = transform.Find("JnyEndCmdInput").gameObject.GetComponent<InputField>();

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


        controlsBeingBuilt = true;

        UnityEngine.Events.UnityAction<int> readouti = delegate { ReadOutControlsIntoDefinedJourney(); };
        UnityEngine.Events.UnityAction<string> readouts = delegate { ReadOutControlsIntoDefinedJourney(); };
        UnityEngine.Events.UnityAction<bool> readoutb = delegate { ReadOutControlsIntoDefinedJourney(); };

        jnytypeDropdown.onValueChanged.AddListener(delegate { JourneyTypeChanged(); });

        jnyStartBuildingDropdown.onValueChanged.AddListener(readouti);
        jnyStartRoomDropdown.onValueChanged.AddListener(readouti);
        jnyEndBuildingDropdown.onValueChanged.AddListener(readouti);
        jnyEndRoomDropdown.onValueChanged.AddListener(readouti);

        jnyPersonNameInput.onValueChanged.AddListener(readouts);
        jnyAvatarDropdown.onValueChanged.AddListener(readouti);

        jnyEndActionDropdown.onValueChanged.AddListener(readouti);
        jnyQuitOnEndToggle.onValueChanged.AddListener(readoutb);
        jnyEndCmdInput.onValueChanged.AddListener(readouts);

        jnyStartBuildingDropdown.onValueChanged.AddListener(delegate { RepopulateRoomsDropdownOnBldChange(jnyStartBuildingDropdown, jnyStartRoomDropdown, ref startRoomOpts); });
        jnyEndBuildingDropdown.onValueChanged.AddListener(delegate { RepopulateRoomsDropdownOnBldChange(jnyEndBuildingDropdown, jnyEndRoomDropdown, ref endRoomOpts); });
        jnyDefinedJnysDropdown.onValueChanged.AddListener(delegate { DefinedJourneyDropdownChanged(); });

        controlsBeingBuilt = false;
        sman.Lgg("JouneyPanel.LinkObjectAndComponents","orange");
    }

    public void InitVals()
    {
        Debug.Log("JourneyPanels InitVals called");
        curjnytype.GetInitial( JourneyType.BldRoomToBldRoom );
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
                definedJourney = js;
            }
        }
        else
        {
            js = GetNextNewJourneySpec();
            SetStatusMessage($"Initial journey name empty", error: false);
        }

        try
        {
            var jtypnames = new List<string>(Enum.GetNames(typeof(JourneyType)));
            var inival = curjnytype.Get();
            var idx = jtypnames.FindIndex(s => s == inival.ToString());
            if (idx <= 0) idx = 0;

            jnytypeDropdown.ClearOptions();
            jnytypeDropdown.AddOptions(jtypnames);
            jnytypeDropdown.value = idx;
            sman.Lgg($"jnytypeDropdown value:{idx}");
        }
        catch (Exception ex)
        {
            sman.LggError($"JourneyPanels.InitVals initializing exception - ex.Message:{ex.Message}");
        }


        PopulateFormValsWithJourneySpec(js);
    }

    public void JourneyTypeChanged()
    {
        var newjval = (JourneyType)jnytypeDropdown.value;
        curjnytype.SetAndSave ( newjval );
        PopulateDefinedJourneyDropdown();
        NewJourney();
    }

    public RouteSpecMethod ConvertToRsm(JourneyType jt)
    {
        RouteSpecMethod rsm;
        switch (jt)
        {
            default:
            case JourneyType.BldRoomToBldRoom: 
                rsm = RouteSpecMethod.BldRoomToBldRoom;
                break;
            case JourneyType.DronePadToDronePad:
                rsm = RouteSpecMethod.DronePadToDronePad;
                break;
        }
        return rsm;
    }


    bool controlsBeingBuilt = false;
    public JourneySpec BuildJourneySpecFromControls()
    {
        sman.Lgg($"BuildJourneySpecFromControls", "lightblue");
        var jm = jnman.journeySpecMan;
        var jname = jnyNameInput.text;
        var bld1 = "bld1";
        var room1 = "room1";
        var bld2 = "bld2";
        var room2 = "room2";
        var pname = "pname";
        var aname = "avatar";
        var jeopt = JourneyEnd.disappear;
        if (startBuildingOpts != null)
        {
            bld1 = startBuildingOpts[jnyStartBuildingDropdown.value];
            room1 = startRoomOpts[jnyStartRoomDropdown.value];
            bld2 = endBuildingOpts[jnyEndBuildingDropdown.value];
            room2 = endRoomOpts[jnyEndRoomDropdown.value];
            pname = jnyPersonNameInput.text;
            aname = avatarOpts[jnyAvatarDropdown.value];
            var jeoptstr = jourEndOpts[jnyEndActionDropdown.value];
            JourneyEnd.TryParse(jeoptstr, out jeopt);
        }
        sman.Lgg($"BJS for {bld1} {room1} to {bld2} {room2}","green");
        var rs = new RouteSpec(jnman.journeySpecMan, ConvertToRsm(curjnytype.Get()), bld1, room1, bld2, room2, pname);
        var jps = new JourneyPrincipalSpec(jm, JourneyMethod.walkjour, pname, aname);
        var qad = jnyQuitOnEndToggle.isOn;
        var tname = jnyEndCmdInput.text;
        var aas = new ActionSpec(jm, jeopt, quitAtDest: qad, thingToDo: tname);
        var js = new JourneySpec(jm, jname, rs, jps, aas);
        sman.Lgg($"BuildJourneySpecFromControls pname:{pname} aname:{aname}", "lightblue");
        return js;
    }

    public void ReadOutControlsIntoDefinedJourney()
    {
        if (!controlsBeingBuilt)
        {
            definedJourney = BuildJourneySpecFromControls();
            PropagateChangeToDefinedJourneys(definedJourney);
        }
    }

    bool repopulateOnValueChanged = true;
    public void DefinedJourneyDropdownChanged()
    {
        controlsBeingBuilt = true;

        ClearStatusMessage();
        int idx = jnyDefinedJnysDropdown.value;
        var jslist = definedJourneys.Keys.ToList<string>();
        if (idx<definedJourneys.Count)
        {
            var key = jslist[idx].ToString();
            var ss = definedJourneys[key];
            var js = new JourneySpec(jnman.journeySpecMan, ss);
            definedJourney = js;
            if (repopulateOnValueChanged)
            {
                PopulateFormValsWithJourneySpec(js);
            }
            sman.Lgg($"DefinedJourneyDropdown changed key:{key}","orange");
        }
        else
        {
            sman.Lgg($"DefinedJourneyDropdown out of range:{idx} definedJourneys:{definedJourneys.Count}","orange");
        }
        controlsBeingBuilt = false;
    }
    //public enum RouteSpecMethod { BldRoomToBldRoom, DronePadToDronePad }


    public bool IsRightJnyType(string jnystr)
    {
        RouteSpecMethod lookForRsm;
        switch(curjnytype.Get())
        {
            default:
            case JourneyType.BldRoomToBldRoom:
                lookForRsm = RouteSpecMethod.BldRoomToBldRoom;
                break;
            case JourneyType.DronePadToDronePad:
                lookForRsm = RouteSpecMethod.DronePadToDronePad;
                break;
        }
        var ss = definedJourneys[jnystr];
        var js = new JourneySpec(jnman.journeySpecMan, ss);
        var rv = js.routeSpec.routeSpecMethod == lookForRsm;
        return rv;
    }
    public void PopulateDefinedJourneyDropdown(string inijname="" )
    {
        sman.Lgg($"PopulateDefinedJourneyDropdown curjnytype:{curjnytype.Get()}","grass");
        try
        {
            var inival = inijname;
            var populateList = new List<string>(definedJourneys.Keys);
            var removeList = new List<string>();
            foreach(var jnystr in populateList)
            {
                if (!IsRightJnyType(jnystr))
                {
                    removeList.Add(jnystr);
                }
            }
            foreach(var jnystr in removeList)
            {
                sman.Lgg($"   Removing {jnystr}", "grass");
                populateList.Remove(jnystr);
            }
            sman.Lgg($"Removed {removeList.Count} from {definedJourneys.Count} defined journeys - new count:{populateList.Count}", "grass");
            populateList.Add("(blank)");
            var idx = populateList.FindIndex(s => s == inival);
            if (idx < 0) idx = populateList.Count-1;// this is the blank entry we added
            //if (idx <= 0) idx = 0;
            jnyDefinedJnysDropdown.ClearOptions();
            jnyDefinedJnysDropdown.AddOptions(populateList);
            repopulateOnValueChanged = false;
            jnyDefinedJnysDropdown.value = idx;
            repopulateOnValueChanged = true;
        }
        catch (Exception ex)
        {
            sman.LggError($"Exception caught in JourneyPanel.PopulateDefinedJourneys jnyAvatarDropdown - ex.Message:{ex.Message}");
        }
    }

    public void RepopulateRoomsDropdownOnBldChange(Dropdown bldctrl,Dropdown roomctrl,ref List<string> roomopts, string defaultroom="")
    {

        var curbldval = bldctrl.value;
        var bldlist = bdman.GetBuildingsWithDestinations();
        var bldname = bldlist[curbldval];
        sman.Lgg($"{bldctrl.name} dropdown changed current bld:{bldname}","orange");
        var bld = bdman.GetBuilding(bldname);
        var roomlist = bld.GetRoomNames();
        sman.Lgg($"Found {roomlist.Count} rooms for {bldname}","orange");
        roomctrl.ClearOptions();
        roomctrl.AddOptions(roomlist);
        if (defaultroom!="")
        {
            for(int i=0; i<roomlist.Count; i++)
            {
                if (roomlist[i]==defaultroom)
                {
                    roomctrl.value = i;
                    break;
                }
            }
        }
        roomopts = roomlist;
    }



    //public (bool ok,string val) GetJsKeySave(string key)
    //{
    //    var wholekey = $"journeyspec_{key}";
    //    var uxset = new UxUtils.UxSetting<string>(wholekey, "");
    //    var sval = uxset.GetInitial("");
    //    var ok = false;
    //    if (sval != "")
    //    {
    //        ok = true;
    //    }
    //    return (ok, sval);
    //}
    //public void SetJsKeySave(string key,string sval)
    //{
    //    var wholekey = $"journeyspec_{key}";
    //    var uxset = new UxUtils.UxSetting<string>(wholekey, "");
    //    uxset.SetAndSave(sval);
    //}

    //public void EraseJsKey(string key)
    //{
    //    var wholekey = $"journeyspec_{key}";
    //    var uxset = new UxUtils.UxSetting<string>(wholekey, "");
    //    uxset.SetAndSave("");
    //}


    public void LoadDefinedJourneys()
    {
        definedJourneys = new Dictionary<string,string>();
        var curspeckeys = jnman.curJnySpecKeys.Get();
        if (curspeckeys != "")
        {
            var cskarr = curspeckeys.Split('|');
            foreach (var key in cskarr)
            {
                var (ok, sval) = JourneySpec.GetJsKeySave(key);
                definedJourneys[key] = sval;
            }
        }
        var curkey = jnman.curJnySpecName.Get();
        sman.Lgg($"LoadDefinedJourneys:{curkey}","lightblue");
        PopulateDefinedJourneyDropdown( inijname:curkey ); 
    }


    public List<string> GetDestinations()
    {
        List<string> rv;
        switch (curjnytype.Get())
        {
            default:
            case JourneyType.BldRoomToBldRoom:
                rv = bdman.GetBuildingsWithDestinations();
                break;
            case JourneyType.DronePadToDronePad:
                rv = bdman.GetDronePadNames();
                break;
        }
        return rv;
    }


    public void PopulateFormValsWithJourneySpec(JourneySpec js)
    {
        sman.Lgg($"JourneyPanels.SetValsToJourneySpec called with js.displayName:{js.displayName}","green");
        controlsBeingBuilt = true;
        jnman.curJnySpecName.SetAndSave(js.displayName);
        curJnySerializedStringText.text = js.SerialString();

        jnyNameInput.text = js.displayName;
        jnyPersonNameInput.text = js.princeSpec.pname;
        var acs = js.actionSpec;


        var errmsg = "Exception caught in JourneyPanel.SetValsToJourneySpec";
        try
        {
            startBuildingOpts = GetDestinations();
            var inival = js.routeSpec.bld1name;
            var idx = startBuildingOpts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            jnyStartBuildingDropdown.ClearOptions();
            jnyStartBuildingDropdown.AddOptions(startBuildingOpts);
            jnyStartBuildingDropdown.value = idx;
            RepopulateRoomsDropdownOnBldChange(jnyStartBuildingDropdown, jnyStartRoomDropdown, ref startRoomOpts, defaultroom:js.routeSpec.bld1room);
            sman.Lgg($"SetStartBuilding value:{idx}");
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg} initializing jnyStartBuildingDropdown - ex.Message:{ex.Message}");
        }

        try
        {
            endBuildingOpts = GetDestinations();
            var inival = js.routeSpec.bld2name;
            var idx = endBuildingOpts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            jnyEndBuildingDropdown.ClearOptions();
            jnyEndBuildingDropdown.AddOptions(endBuildingOpts);
            jnyEndBuildingDropdown.value = idx;
            RepopulateRoomsDropdownOnBldChange(jnyEndBuildingDropdown, jnyEndRoomDropdown, ref endRoomOpts, defaultroom: js.routeSpec.bld2room);
            sman.Lgg($"SetEndBuilding value:{idx}");
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg} initializing jnyEndBuildingDropdown - ex.Message:{ex.Message}");
        }


        jnyPersonNameInput.text = js.princeSpec.pname;

        try
        {
            avatarOpts = curjnytype.Get() == JourneyType.BldRoomToBldRoom ? personavatars : droneavatars;
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

        try
        {
            jourEndOpts = new List<string>(Enum.GetNames(typeof(JourneyEnd)));
            jnyEndActionDropdown.ClearOptions();
            jnyEndActionDropdown.AddOptions(jourEndOpts);
            var idx = jourEndOpts.FindIndex(s => s == acs.journeyEnd.ToString());
            if (idx <= 0) idx = 0;
            jnyEndActionDropdown.value = idx;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg} initializing jnyEndActionDropdown - ex.Message:{ex.Message}");
        }

        jnyQuitOnEndToggle.isOn = acs.quitAtDest;
        jnyEndCmdInput.text = acs.thingToDo;
        controlsBeingBuilt = false;

        sman.Lgg($"JourneyPanels.SetValsToJourneySpec done", "green");
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


    List<string> personavatars = new List<string>()
    {
        "People/Businesswoman001",
        "People/Businesswoman002",
        "People/Businesswoman003",
        "People/Businesswoman004",
        "People/Businesswoman005",
        "People/Businesswoman006",
        "People/Businesswoman007",
        "People/Businesswoman008",
        "People/Businessman001",
        "People/Businessman002",
        "People/Businessman003",
        "People/Businessman004",
        "People/Businessman005",
        "People/Businessman006",
        "People/Businessman007",
        "People/Businessman008",
        "People/Girl001",
        "People/Girl002",
        "People/Girl003",
        "People/Girl004",
        "People/Girl005",
        "People/Girl006",
        "People/Girl007",
        "People/Girl008",
        "People/Man001",
        "People/Man002",
        "People/Man003",
        "People/Man004",
        "People/Man005",
        "People/Man006",
        "People/Man007",
        "People/Man008",
    };
    List<string> droneavatars = new List<string>()
    {
        "drone/drone1",
        "drone/drone2",
        "drone/drone3",
        "drone/drone4",
    };


    JourneySpec definedJourney = null;
    Journey launchedJny = null;

    public void PropagateChangeToDefinedJourneys(JourneySpec js)
    {
        var newkey = js.displayName;
        var sval = js.SerialString();
        definedJourneys[newkey] = sval;
        //SetJsKeySave(newkey, sval);
    }

    public void AddDefinedJourneyToKeys(JourneySpec js)
    {
        var newkey = js.displayName;
        PropagateChangeToDefinedJourneys(js);
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
        jnman.curJnySpecName.SetAndSave(newkey);
        jnman.curJnySpecKeys.SetAndSave(newkeystring);
        Debug.Log($"ADJTK key:{newkey} newkeystring:{newkeystring} listcnt:{definedJourneys.Count}");
        PopulateDefinedJourneyDropdown( inijname:newkey );
    }

    public void NewJourney()
    {
        ClearStatusMessage();
        var js = GetNextNewJourneySpec();
        PopulateFormValsWithJourneySpec(js);
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
        JourneySpec.EraseJsKey(key);
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
        SaveDefinedJourneyToPersistentStore();
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
            uiman.tbtpan.ColorizeButtonStates();
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
        var rootname = curjnytype.Get() == JourneyType.BldRoomToBldRoom ? "BldJour" : "DroneJour";
        var newname = GenNewJourneyUniqueName(rootname);
        var jm = jnman.journeySpecMan;
        var js = new JourneySpec(jm, newname, defaultRoute, defaultPrinceSpec, defaultActionSpec);
        return js;
    }
    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
        string b1name="Bld3X";
        string b1room="";
        string b2name="BldY";
        string b2room="";
        string personname = "Eve";
        string avaname = "People/Businesswoman001";
        switch (curscene)
        {
            case SceneSelE.Eb12small:
            case SceneSelE.Eb12:
                {
                    b1name = "Eb0814";
                    b1room = "eb0814-f01-12-lob";
                    b2name = "EbRewe";
                    b2room = "eb12-rewe-lob";
                    personname = "Mary Poppins";
                    avaname = "People/Girl005";
                    break;
                }
            case SceneSelE.MsftB121focused:
                {
                    b1name = "Bld121";
                    b1room = "";
                    b2name = "Bld19";
                    b2room = "";
                    personname = "Mary DelaB121";
                    avaname = "People/Businesswoman002";
                    break;
                }
            case SceneSelE.MsftB19focused:
                {
                    b1name = "Bld19";
                    b1room = "";
                    b2name = "Bld121";
                    b2room = "";
                    personname = "Wei VonB19";
                    avaname = "People/Businesswoman003";
                    break;
                }
            case SceneSelE.MsftB33focused:
                {
                    b1name = "Bld33";
                    b1room = "";
                    b2name = "Bld19";
                    b2room = "";
                    personname = "Fatma VanB33";
                    avaname = "People/Businesswoman004";
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


    public void SaveDefinedJourneyToPersistentStore()
    {
        foreach (var key in definedJourneys.Keys)
        {
            var val = definedJourneys[key];
            JourneySpec.SetJsKeySave(key, val);
        }

        //sman.RequestRefresh("JourneyPanel-SetVals");
    }

    public void SetVals(bool closing = false)
    {
        Debug.Log($"JourneyPanel.SetVals called - closing:{closing}");
        SaveDefinedJourneyToPersistentStore();
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
