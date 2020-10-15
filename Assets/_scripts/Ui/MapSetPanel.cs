using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;
using Aiskwk.Map;

public class MapSetPanel : MonoBehaviour
{
    Toggle instantChangeToggle;
    Dropdown mapProv;
    Dropdown eleProv;

    Toggle useElevationsToggle;
    Toggle flatTrisToggle;
    bool oldFlatTriangles;
    bool oldUseElevations;

    Slider hmultVal;
    float oldHmultVal;
    Text hmultValText;

    Slider lodVal;
    float oldLodVal;
    Text lodValText;


    Slider npqkVal;
    float oldNpqkVal;
    Text npqkValText;

    Toggle frameQuadkeysToggle;
    Toggle meshGridToggle;
    Toggle triPointsToggle;
    Toggle meshPointsToggle;
    Toggle coordPointsToggle;
    Toggle extentPointsToggle;

    bool origUseElevation;
    float origHmult;

    bool oldFrameQuadkeys;
    bool oldMeshGrid;
    bool oldTriPoints;
    bool oldMeshPoints;
    bool oldCoordPoints;
    bool oldExtentPoints;

    Button loadMapsButton;
    Button deleteMapsButton;
    Text loadStatusText;

    Text persMapsPathText;
    Text persMapsDataText;
    Text persElevPathText;
    Text persElevInfoText;
    Text tempMapsPathText;
    Text tempMapsDataText;
    Text tempElevPathText;
    Text tempElevInfoText;

    Button closeButton;
    Button copyClipboardButton;
    Button doesNothingButton;

    Text latLngText;
    Text latKmText;
    Text lngKmText;
    Text curFetchSizeText;
    Text fetchSizeEstText;

    Button lookupAddressButton;
    InputField lookupAddressInputField;
    InputField newLatLngInputField;
    InputField newLatKmInputField;
    InputField newLngKmInputField;

    bool newPosAndExtentAvailable;
    double newLat;
    double newLng;
    double newLatKm;
    double newLngKm;


    public bool needSetSceneReset;


    public SceneMan sman;
    UiMan uiman;
    MapMan mman;

    bool panelTakingInput = false;

    Color textColorDef = Color.gray;
    Color darkGreenColor = GraphAlgos.GraphUtil.GetColorByName("darkgreen");



    public void LinkObjectsAndComponents()
    {
        //Debug.Log("MapSetPanel LinkObjectsAndComponents called");
        uiman = sman.uiman;
        mman = sman.mpman;

        if (mman == null)
        {
            Debug.LogError("MapSet panel could not find MapMan");
        }
        instantChangeToggle = transform.Find("InstantChangeToggle").gameObject.GetComponent<Toggle>();
        mapProv = transform.Find("MapProvDropdown").gameObject.GetComponent<Dropdown>();
        eleProv = transform.Find("EleProvDropdown").gameObject.GetComponent<Dropdown>();
        useElevationsToggle = transform.Find("UseElevationsToggle").gameObject.GetComponent<Toggle>();
        flatTrisToggle = transform.Find("FlatTrisToggle").gameObject.GetComponent<Toggle>();
        frameQuadkeysToggle = transform.Find("FrameQuadkeysToggle").gameObject.GetComponent<Toggle>();
        meshGridToggle = transform.Find("MeshGridToggle").gameObject.GetComponent<Toggle>();
        triPointsToggle = transform.Find("TriPointsToggle").gameObject.GetComponent<Toggle>();
        meshPointsToggle = transform.Find("MeshPointsToggle").gameObject.GetComponent<Toggle>();
        coordPointsToggle = transform.Find("CoordPointsToggle").gameObject.GetComponent<Toggle>();
        extentPointsToggle = transform.Find("ExtentPointsToggle").gameObject.GetComponent<Toggle>();

        hmultVal = transform.Find("HmultSlider").gameObject.GetComponent<Slider>();
        hmultValText = hmultVal.gameObject.transform.Find("HmultText").gameObject.GetComponent<Text>();
        lodVal = transform.Find("LodSlider").gameObject.GetComponent<Slider>();
        lodValText = lodVal.gameObject.transform.Find("LodText").gameObject.GetComponent<Text>();
        npqkVal = transform.Find("NpqkSlider").gameObject.GetComponent<Slider>();
        npqkValText = npqkVal.gameObject.transform.Find("NpqkText").gameObject.GetComponent<Text>();
        loadMapsButton = transform.Find("LoadMapsButton").gameObject.GetComponent<Button>();
        loadStatusText = loadMapsButton.transform.Find("LoadStatusText").gameObject.GetComponent<Text>();
        deleteMapsButton = transform.Find("DeleteMapsButton").gameObject.GetComponent<Button>();
        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        copyClipboardButton = transform.Find("ClipboardCopyButton").gameObject.GetComponent<Button>();
        doesNothingButton = transform.Find("DoesNothingButton").gameObject.GetComponent<Button>();
        var igo = transform.Find("MapInfoText").gameObject;
        persMapsPathText = igo.transform.Find("PersMapsPathText").gameObject.GetComponent<Text>();
        persMapsDataText = igo.transform.Find("PersMapsDataText").gameObject.GetComponent<Text>();
        persElevPathText = igo.transform.Find("PersElevPathText").gameObject.GetComponent<Text>();
        persElevInfoText = igo.transform.Find("PersElevInfoText").gameObject.GetComponent<Text>();
        tempMapsPathText = igo.transform.Find("TempMapsPathText").gameObject.GetComponent<Text>();
        tempMapsDataText = igo.transform.Find("TempMapsDataText").gameObject.GetComponent<Text>();
        tempElevPathText = igo.transform.Find("TempElevPathText").gameObject.GetComponent<Text>();
        tempElevInfoText = igo.transform.Find("TempElevInfoText").gameObject.GetComponent<Text>();

        latLngText = transform.Find("LatLngText").gameObject.GetComponent<Text>();
        latKmText = transform.Find("LatKmText").gameObject.GetComponent<Text>();
        lngKmText = transform.Find("LngKmText").gameObject.GetComponent<Text>();
        curFetchSizeText = transform.Find("CurFetchSizeText").gameObject.GetComponent<Text>();
        fetchSizeEstText = transform.Find("FetchSizeEstText").gameObject.GetComponent<Text>();
        textColorDef = fetchSizeEstText.color;

        lookupAddressButton = transform.Find("LookupAddressButton").gameObject.GetComponent<Button>();
        lookupAddressInputField = transform.Find("LookupAddressInputField").gameObject.GetComponent<InputField>();
        newLatLngInputField = transform.Find("NewLatLngInputField").gameObject.GetComponent<InputField>();
        newLatKmInputField = transform.Find("NewLatKmInputField").gameObject.GetComponent<InputField>();
        newLngKmInputField = transform.Find("NewLngKmInputField").gameObject.GetComponent<InputField>();


        closeButton.onClick.AddListener(delegate { uiman.ClosePanel(); });
        copyClipboardButton.onClick.AddListener(delegate { ButtonClick(copyClipboardButton.name); });
        //deleteSettingsButton.onClick.AddListener(delegate { ButtonClick(deleteSettingsButton.name); });
        deleteMapsButton.onClick.AddListener(delegate { ButtonClick(deleteMapsButton.name); });
        loadMapsButton.onClick.AddListener(delegate { ButtonClick(loadMapsButton.name); });
        lookupAddressButton.onClick.AddListener(delegate { ButtonClick(lookupAddressButton.name); });

        //Debug.Log("MapSetPanel.LinkObjectsAndComponents Found everything apparently");

    }

    public void Init0()
    {
        LinkObjectsAndComponents();
        sman.uiman.ttman.WireUpToolTip(closeButton.gameObject, "mapsetpanel-closepanel", "Close Panel");
        sman.uiman.ttman.WireUpToolTip(copyClipboardButton.gameObject, "mapsetpanel-copyclipboard", "Copy bitmap information to clipboard");
        sman.uiman.ttman.WireUpToolTip(doesNothingButton.gameObject, "mapsetpanel-doesnothing", "Currently does nothing");
        sman.uiman.ttman.WireUpToolTip(loadMapsButton.gameObject, "mapsetpanel-loadmaps", "Reload maps\nmight take awhile - get some coffee",isDangerous:true);
        sman.uiman.ttman.WireUpToolTip(deleteMapsButton.gameObject, "mapsetpanel-deletemaps", "Delete scenario maps\ncareful reloading them might take awhile",isDangerous:true);
    }
    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
    }

    public void InitCheckNeedSetModeRefresh()
    {
        needSetSceneReset = false;
        origHmult = mman.hmult.Get(); 
        origUseElevation = mman.useElevations.Get();
    }


    public bool CheckNeedSetSceneRefresh()
    {
        needSetSceneReset = origHmult != mman.hmult.Get() || origUseElevation != mman.useElevations.Get();
        return needSetSceneReset;
    }

    public void InitVals()
    {
        Debug.Log($"MapSetPanel.InitVals called scene:{sman.curscene} iscustomizable:{mman.isCustomizable}");

        InitCheckNeedSetModeRefresh();


        var errmsg = "Error in MapSetPanel.InitVals-";
        try
        {
            var opts = mman.GetMapProviderList();
            var inival = mman.reqMapProv.Get().ToString();
            //Debug.Log($"InitVals get:{inival}");
            var idx = opts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;
            mapProv.ClearOptions();
            mapProv.AddOptions(opts);
            mapProv.value = idx;
        }
        catch (Exception ex)
        {
            Debug.LogError($"{errmsg}1:{ex.Message}");
        }

        try
        {
            var opts = MapMan.GetElevProviderList();
            var inival = mman.reqEleProv.Get().ToString();
            var idx = opts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;
            eleProv.ClearOptions();
            eleProv.AddOptions(opts);
            eleProv.value = idx;
        }
        catch (Exception ex)
        {
            Debug.LogError($"{errmsg}2:{ex.Message}");
        }

        instantChangeToggle.isOn = mman.InstantMapSettingsChange.Get();
        useElevationsToggle.isOn = mman.useElevations.Get();
        oldUseElevations = useElevationsToggle.isOn;
        flatTrisToggle.isOn = mman.flatTris.Get();
        oldFlatTriangles = flatTrisToggle.isOn;
        frameQuadkeysToggle.isOn = mman.frameQuadkeys.Get();
        meshGridToggle.isOn = mman.meshGrid.Get();
        triPointsToggle.isOn = mman.triPoints.Get();
        meshPointsToggle.isOn = mman.meshPoints.Get();
        coordPointsToggle.isOn = mman.coordPoints.Get();
        extentPointsToggle.isOn = mman.extentPoints.Get();

        hmultVal.minValue = 0;
        hmultVal.maxValue = 15;
        oldHmultVal = float.MinValue;
        hmultVal.value = mman.hmult.Get();

        lodVal.minValue = 0;
        lodVal.maxValue = 19;
        oldLodVal = float.MinValue;
        lodVal.value = 15;

        npqkVal.minValue = 1;
        npqkVal.maxValue = 48;
        oldHmultVal = float.MinValue;
        npqkVal.value = mman.npqk;

        UpdateHmultTextValue();
        UpdateLodTextValue();
        UpdateNpqkTextValue();

        UpdateFileText();

        var locactive = mman.isCustomizable;
        newLatLngInputField.transform.gameObject.SetActive(locactive);
        newLatKmInputField.transform.gameObject.SetActive(locactive);
        newLngKmInputField.transform.gameObject.SetActive(locactive);
        lookupAddressButton.gameObject.SetActive(locactive);
        lookupAddressInputField.gameObject.SetActive(locactive);

        UpdateLatLngText();


        panelTakingInput = true;
    }

    public void UpdateLatLngText()
    {
        var stats = mman.GetQkmeshStatistics();
        if (stats != null)
        {
            var lats = stats.llbox.midll.lat.ToString("f6");
            var lngs = stats.llbox.midll.lng.ToString("f6");
            latLngText.text = $"lat,lng: {lats},{lngs}";
            var latkms = stats.heightKm.ToString("f3");
            var lngkms = stats.widthKm.ToString("f3");
            latKmText.text = $"Latkm: {latkms}   lat-tiles:{stats.nqktiles.y}";
            lngKmText.text = $"Lngkm: {lngkms}   lng-tiles:{stats.nqktiles.x}";
            //Debug.Log($"Setting lod to {stats.llbox.lod}");
            lodVal.value = stats.llbox.lod;
            npqkVal.value = mman.npqk;
            SetLodTextValues();
            SetNpqkTextValues();


            if (mman.isCustomizable)
            {
                var lat1s = stats.llbox.midll.lat.ToString("f6");
                var lng1s = stats.llbox.midll.lng.ToString("f6");
                var latlngs = $"{lat1s},{lng1s}";
                newLatLngInputField.text = latlngs;
                newLatLngInputField.onValueChanged.AddListener(delegate { ParseLatLng(); });
                newLatKmInputField.text = stats.heightKm.ToString("f3");
                newLatKmInputField.onValueChanged.AddListener(delegate { ParseLatKm(); });
                newLngKmInputField.text = stats.widthKm.ToString("f3");
                newLngKmInputField.onValueChanged.AddListener(delegate { ParseLngKm(); });
                lookupAddressInputField.text = mman.address;
                //Debug.LogWarning($"MapSetPanel Initializing lookupAddress to {mman.address}");

                newPosAndExtentAvailable = false;
                newLat = stats.llbox.midll.lat;
                newLng = stats.llbox.midll.lng;
                newLatKm = stats.heightKm;
                newLngKm = stats.widthKm;
            }

        }
    }

    public void ParseLatKm()
    {
        var s = newLatKmInputField.text;
        var msg = "--";
        double f;
        var ok = double.TryParse(s, out f);
        if (!ok)
        {
           msg = "format error";
        }
        else if (f <= 0)
        {
            msg = "value must be greater zero";
        }
        else
        {
            msg = "LatKm: "+f.ToString("f3");
            newPosAndExtentAvailable = true;
            newLatKm = f;
        }
        latKmText.text = msg;
    }

    public void ParseLngKm()
    {
        var s = newLngKmInputField.text;
        var msg = "--";
        double f;
        var ok = double.TryParse(s, out f);
        if (!ok)
        {
            msg = "format error";
        }
        else if (f<=0)
        {
            msg = "value must be greater zero";
        }
        else
        {
            msg = "LngKm: " + f.ToString("f3");
            newLngKm = f;
            newPosAndExtentAvailable = true;
        }
        lngKmText.text = msg;
    }


    public void ParseLatLng()
    {
        var sarr = newLatLngInputField.text.Split(',');
        var msg = "--";
        if (sarr.Length != 2)
        {
            msg = "Need 2 comma fields";
        }
        else
        {
            double v1 = 0;
            double v2 = 0;
            var ok1 = double.TryParse(sarr[0], out v1);
            if (!ok1)
            {
                msg = "field 1 format error";
            }
            else
            {
                var ok2 = double.TryParse(sarr[1], out v2);
                if (!ok2)
                {
                    msg = "field 2 format error";
                }
                else
                {
                    if (Math.Abs(v1) > 90)
                    {
                        msg = "field 1 not in (-90 to 90)";
                    }
                    else if (Math.Abs(v2) > 180)
                    {
                        msg = "field 2 not in (-180 to 180)";
                    }
                    else
                    {
                        var v1s = v1.ToString("f6");
                        var v2s = v2.ToString("f6");
                        msg = $"lat,lng: {v1s},{v2s}";
                        newPosAndExtentAvailable = true;
                        newLat = v1;
                        newLng = v2;
                    }
                }
            }
        }
        latLngText.text = msg;
    }

    string copyClipText;
    void UpdateFileText()
    {
        var (s1, s2, s3, s4, s5, s6, s7, s8) = mman.GetGeoDataStoragePaths();
        s1 = "Tex Pers Path: " + s1;
        s2 = "Tex Pers Info: " + s2;
        s3 = "Ele Pers Path: " + s3;
        s4 = "Ele Pers Info: " + s4;
        s5 = "Tex Temp Path: " + s5;
        s6 = "Tex Temp Info: " + s6 + "  " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        s7 = "Ele Temp Path: " + s7;
        s8 = "Ele Temp Info: " + s8;
        var sedregkey = "User settings regkey editor:"+" Computer\\HKEY_CURRENT_USER\\Software\\Unity\\UnityEditor\\DefaultCompany\\campusim";
        var splregkey = "User settings regkey player:" + " Computer\\HKEY_CURRENT_USER\\Software\\DefaultCompany\\campusim";
        //var spllogfiles = "Log files regkey player:" + "%USERPROFILE%\\AppData\\LocalLow\\DefaultCompany\\campusim\\Player.log";
        var spllogfiles = "Log files regkey player:" + "C:\\Users\\mike\\AppData\\LocalLow\\DefaultCompany\\campusim\\Player.log";


        persMapsPathText.text = s1;
        persMapsDataText.text = s2;
        persElevPathText.text = s3;
        persElevInfoText.text = s4;
        tempMapsPathText.text = s5;
        tempMapsDataText.text = s6;
        tempElevPathText.text = s7;
        tempElevInfoText.text = s8;
        copyClipText = $"{s1}\n{s2}\n{s5}\n{s6}\n\n{s3}\n{s4}\n{s7}\n{s8}\n\n{sedregkey}\n{splregkey}\n{spllogfiles}";
    }

    static public bool isLoadingMaps = false;
    float loadStartTime = 0;
    (bool oktoload,string errmsg) StartLoadingTiles(bool forceload)
    {
        if (!loadererrmsg.StartsWith("ok"))
        {
            loadStatusText.color = Color.red;
            loadStatusText.text = loadererrmsg;
            return (false,loadererrmsg);
        }
        isLoadingMaps = true;
        loadStartTime = Time.time;
        //mman.DeleteMaps();
        var newlod = (int)(lodVal.value + 0.5f);
        RealizeSelectedMapProv();
        RealizeSelectedEleProv();
        mman.SetLod(newlod);
        if (newPosAndExtentAvailable)
        {
            var addr = lookupAddressInputField.text;
            mman.SetLatLngAndExtent(addr,newLat, newLng, newLatKm, newLngKm);
        }
        mman.SetNtqk((int) (npqkVal.value+0.5f));
        mman.LoadMaps(forceload:forceload);
        return (true, "");
    }
    float checkLoadInterval = 0.25f;
    float lastLoadCheck = 0;
    void CheckLoadingAndMessageIfNeeded()
    {
        if (isLoadingMaps && Time.time-lastLoadCheck>checkLoadInterval)
        {
            var msg = "";
            var (isLoading, irupt,lodLoading, nbmLoaded, nbmToLoad, nelevBatchesLoaded, nelevBatchsToLoad) = mman.GetLoadingStatus();
            var numstr = $"{nbmLoaded}/{nbmToLoad}  {nelevBatchesLoaded}/{nelevBatchsToLoad}";
            if (irupt)
            {
                numstr = $"IRUPT {numstr}";
            }
            var elaps = "Elap:"+(Time.time - loadStartTime).ToString("f1") + " secs";
            if (!isLoading)
            {
                msg = numstr +  " Finished loading " + elaps;
                isLoadingMaps = false;
            }
            else
            {
                msg = numstr + " Loading " + elaps;
            }
            loadStatusText.color = textColorDef;
            loadStatusText.text = msg;
        }
    }

    async void LookupAddress()
    {
        var locspecer = new Aiskwk.Map.LocSpecer(null);
        var locspec = lookupAddressInputField.text;
        if (locspec=="")
        {
            locspec = "///beamed.craft.regions";
            lookupAddressInputField.text = locspec;
        }
        var rv = await locspecer.GetLLfromLocspec(locspec);
        var fmt = "f7";
        if (rv.ll==null)
        {
            latLngText.text = $"{locspec} was not a valid locspec";
        }
        else
        {
            var newlatlngtxt = $"{rv.ll.lat.ToString(fmt)},{rv.ll.lng.ToString(fmt)}";
            latLngText.text = newlatlngtxt;
            newLatLngInputField.text = newlatlngtxt;
            ParseLatLng();
        }
    }

    int buttonClickCount = 0;
    void ButtonClick(string buttonname)
    {
        //Debug.Log("Clicked \"" + buttonname+"\" "+buttonClickCount);
        switch (buttonname)
        {
            case "CloseButton":
                {
                    uiman.ClosePanel();
                    break;
                }
            case "ClipboardCopyButton":
                {
                    //Debug.Log("Copyied " + copyClipText.Length + " chars");
                    Aiskwk.Map.qut.CopyTextToClipboard(copyClipText);
                    break;
                }
            case "DeleteSettingsButton":
                {
                    Debug.LogWarning("PlayerPref Settings Deleted");
                    PlayerPrefs.DeleteAll();
                    break;
                }
            case "LoadMapsButton":
                {
                    StartLoadingTiles(forceload:true);
                    break;
                }
            case "DeleteMapsButton":
                {
                    mman.EraseMapsFromDisk();
                    break;
                }
            case "LookupAddressButton":
                {
                    LookupAddress();
                    break;
                }
        }
        buttonClickCount++;
    }

    int nSetHmultTextValueCalled = 0;
    private void SetHmultTextValues()
    {
        nSetHmultTextValueCalled += 1;
        hmultValText.text = "hmult: " + hmultVal.value.ToString("f1");
    }

    int nSetLodTextValueCalled = 0;
    private void SetLodTextValues()
    {
        nSetLodTextValueCalled += 1;
        lodValText.text = "lod: " + lodVal.value.ToString("f0");
    }
    int nSetNpqkTextValueCalled = 0;
    private void SetNpqkTextValues()
    {
        nSetNpqkTextValueCalled += 1;
        npqkValText.text = "Nodes per qk: " + npqkVal.value.ToString("f0");
    }
    private void UpdateChangables()
    {
        if (instantChangeToggle.isOn)
        {
            if (oldUseElevations != useElevationsToggle.isOn)
            {
                oldUseElevations = useElevationsToggle.isOn;
                needSetSceneReset = true;
                mman.SetUseElevations(oldUseElevations);
            }
            if (oldFlatTriangles != flatTrisToggle.isOn)
            {
                oldFlatTriangles = flatTrisToggle.isOn;
                mman.SetFlatTris(oldFlatTriangles);
            }
            if (oldFrameQuadkeys != frameQuadkeysToggle.isOn)
            {
                oldFrameQuadkeys = frameQuadkeysToggle.isOn;
                mman.SetQuadkeyFraming(oldFrameQuadkeys);
            }
            if (oldMeshGrid != meshGridToggle.isOn)
            {
                oldMeshGrid = meshGridToggle.isOn;
                mman.SetMeshGrid(oldMeshGrid);
            }
            if (oldTriPoints != triPointsToggle.isOn)
            {
                oldTriPoints = triPointsToggle.isOn;
                mman.SetTriPoints(oldTriPoints);
            }
            if (oldMeshPoints != meshPointsToggle.isOn)
            {
                oldMeshPoints = meshPointsToggle.isOn;
                mman.SetMeshPoints(oldMeshPoints);
            }
            if (oldCoordPoints != coordPointsToggle.isOn)
            {
                oldCoordPoints = coordPointsToggle.isOn;
                mman.SetCoordPoints(oldCoordPoints);
            }
            if (oldExtentPoints != extentPointsToggle.isOn)
            {
                oldExtentPoints = extentPointsToggle.isOn;
                mman.SetExtentPoints(oldExtentPoints);
            }
        }
    }
    private void UpdateHmultTextValue()
    {
        var callsettextvalues = false;
        if (oldHmultVal != hmultVal.value)
        {
            //Debug.Log("MapSet hmult changed to " + hmultVal.value);
            var diffv = new Vector3(0,0,hmultVal.value - oldHmultVal);
            //sman.CorrectPositionDiff(diffv);
            if (instantChangeToggle.isOn)
            {
                mman.SetHmult(hmultVal.value);
            }
            oldHmultVal = hmultVal.value;
            callsettextvalues = true;
        }
        if (callsettextvalues)
        {
            SetHmultTextValues();
        }
    }

    private void UpdateLodTextValue()
    {
        var callsettextvalues = false;
        if (oldLodVal != lodVal.value)
        {
            var diffv = new Vector3(0, 0, lodVal.value - oldLodVal);
            oldLodVal = lodVal.value;
            callsettextvalues = true;
        }
        if (callsettextvalues)
        {
            SetLodTextValues();
        }
    }

    private void UpdateNpqkTextValue()
    {
        var callsettextvalues = false;
        if (oldNpqkVal != npqkVal.value)
        {
            var diffv = new Vector3(0, 0, npqkVal.value - oldNpqkVal);
            oldNpqkVal = npqkVal.value;
            callsettextvalues = true;
        }
        if (callsettextvalues)
        {
            SetNpqkTextValues();
        }
    }

    bool RealizeSelectedMapProv()
    {
        bool changed = false;
        var curstr = MapMan.GetMapProviderString(mapProv.value);
        var curMapProv = MapMan.GetMapProviderEnum(curstr);
        if (curMapProv != mman.reqMapProv.Get())
        {
            MapMan.SetInitialMapProvider(curstr);
            mman.SetMapPovider(curMapProv);
            Debug.Log($"Setting Map Provider:{curMapProv}");
            changed = true;
        }
        return changed;
    }

    bool RealizeSelectedEleProv()
    {
        bool changed = false;
        var curstr = MapMan.GetElevProviderString(eleProv.value);
        var curEleProv = MapMan.GetElevProviderEnum(curstr);
        if (curEleProv != mman.reqEleProv.Get())
        {
            MapMan.SetInitialElevProvider(curstr);
            mman.SetEleProvider(curEleProv);
            Debug.Log($"Setting Elev Provider:{curEleProv}");
            changed = true;
        }
        return changed;
    }


    public void SetVals(bool closing=false)
    {
       // Debug.Log("MapSetPanel.SetVals called closing:{closing}");

        var sw = new Aiskwk.Map.StopWatch();
        sw.Start();

        var errmsg = "Error in VisualsPanels.SetVals-";
        try
        {
            RealizeSelectedMapProv();
        }
        catch (Exception ex)
        {
            Debug.LogError($"{errmsg}-1:{ex.Message}");
        }

        try
        {
            RealizeSelectedEleProv();
        }
        catch (Exception ex)
        {
            Debug.LogError($"{errmsg}-2:{ex.Message}");
        }
        sw.Mark();
        //Debug.Log($"MapSetPanel.SetVals Phase1 took:{sw.ElapSecs()} secs");

        UpdateHmultTextValue();
        UpdateLodTextValue();
        UpdateNpqkTextValue();

        mman.SetUseElevations(useElevationsToggle.isOn);
        mman.SetFlatTris(flatTrisToggle.isOn);
        mman.SetQuadkeyFraming(frameQuadkeysToggle.isOn);
        mman.SetMeshGrid(meshGridToggle.isOn);
        mman.SetTriPoints(triPointsToggle.isOn);
        mman.SetMeshPoints(meshPointsToggle.isOn);
        mman.SetCoordPoints(coordPointsToggle.isOn);
        mman.SetExtentPoints(extentPointsToggle.isOn);
        mman.SetHmult(hmultVal.value);
        mman.SetLod((int) (lodVal.value+0.5f));
        mman.SetNtqk((int) (npqkVal.value+0.5f));

        sman.RequestRefresh("MapSetPanel-SetVals");
        sw.Stop();
        //Debug.Log($"MapSetPanel.SetVals Phase1 took in total :{sw.ElapSecs()} secs");
        var needSetScene = CheckNeedSetSceneRefresh();
        sman.RequestRefresh("MapSetPanel-SetVals",totalrefresh:needSetScene);
        if (needSetScene)
        {
            Debug.LogWarning("Need set mode reset");
            /// how do do do this now?
        }
        if (closing)
        {
            panelTakingInput = false;
            Aiskwk.Map.Viewer.ActivateViewerKeys(true);
            StartLoadingTiles(forceload: false);
        }
    }
    string loadererrmsg = "";
    int estimateCheckedCount = 0;
    bool estimateChanged = false;
    public void checkEstimateChanged()
    {
        bool recheck = estimateCheckedCount>=0;
        if (recheck)
        {
            var stats = mman.GetQkmeshStatistics();
            if (stats != null)
            {
                var nll = stats.llbox.midll;
                var latkm = stats.heightKm;
                var lngkm = stats.widthKm;
                var olod = stats.llbox.lod;
                var nlod = olod;
                var onpqk =  mman.npqk;
                var npqk = onpqk;
                if (mman.isCustomizable)
                {
                    nll = new Aiskwk.Map.LatLng(newLat, newLng);
                    latkm = (float) newLatKm;
                    lngkm = (float) newLngKm;

                }
                nlod = (int)(lodVal.value + 0.5f);
                npqk = (int)(npqkVal.value + 0.5f);
                var nllbox = new Aiskwk.Map.LatLngBox(nll, latkm, lngkm, lod: nlod);
                var (nqkx, nqky) = nllbox.GetTileSize();
                var nbm = nqkx * nqky;
                var maxElevationsPerRequest = 1024; // https://docs.microsoft.com/en-us/bingmaps/rest-services/elevations/get-elevations
                var nel = (nbm * npqk * npqk / maxElevationsPerRequest) + 1;
                var nllhkm = nllbox.extentMetersBadEstimate.y;
                var pixx = nqkx * 256;
                var pixy = nqky * 256;
                var imsz = pixx*1f*pixy*4f / 1e6;
                var pixlim = SystemInfo.maxTextureSize;
                var imszlim = 100;
                var nbmlim = 200;
                estimateChanged = stats.llbox.lod != nlod ||
                                  stats.llbox.midll.lat != nll.lat ||
                                  stats.llbox.midll.lng != nll.lng ||
                                  stats.heightKm != (float) newLatKm ||
                                  stats.widthKm != (float) newLngKm;
                if (pixx > pixlim)
                {
                    loadererrmsg = $"xpix>{pixlim}";
                    fetchSizeEstText.color = Color.red;
                }
                else if (pixy > pixlim)
                {
                    loadererrmsg = $"ypix>{pixlim}";
                    fetchSizeEstText.color = Color.red;
                }
                else if (imsz>imszlim)
                {
                    loadererrmsg = $"ok - image size>{imszlim} MB";
                    fetchSizeEstText.color = Color.yellow;
                }
                else if (nbm>nbmlim)
                {
                    loadererrmsg = $"ok - nbm>{nbmlim}";
                    fetchSizeEstText.color = Color.yellow;
                }
                else 
                {
                    loadererrmsg = $"ok";
                    fetchSizeEstText.color = estimateChanged ? darkGreenColor : textColorDef;
                }

                fetchSizeEstText.text = $"nbm:{nbm} ({nqkx}x{nqky}) (pix:{pixx}x{pixy}) ({imsz:f1} MB)  nelev:{nel}  lod:{nlod}  npqk:{npqk}  {loadererrmsg}";
                if (estimateCheckedCount==0)
                {
                    var (onqkx, onqky) = stats.llbox.GetTileSize();
                    var onbm = onqkx * onqky;
                    var opixx = onqkx * 256;
                    var opixy = onqky * 256;
                    var oimsz = opixx*1f*opixy*4f / 1e6;


                    curFetchSizeText.text = $"nbm:{onbm} ({onqkx}x{onqky}) (pix:{opixx}x{opixy}) ({imsz:f1} MB) nelev:{nel}  lod:{olod}  npqk:{onpqk}";
                }
                estimateCheckedCount++;
            }
        }
    }
    float fileTextUpdate;
    float lastPanelCheck;
    // Update is called once per frame
    void Update()
    {
        if ((Time.time - lastPanelCheck) > 0.2f)
        {
            Aiskwk.Map.Viewer.ActivateViewerKeys(!panelTakingInput);
            if (panelTakingInput)
            {
                if (nSetHmultTextValueCalled == 0)
                {
                    SetHmultTextValues();
                }
                UpdateHmultTextValue();
                UpdateLodTextValue();
                UpdateNpqkTextValue();
                UpdateChangables();
                if (Time.time - fileTextUpdate > 1)
                {
                    UpdateFileText();
                    fileTextUpdate = Time.time;
                }
                if (isLoadingMaps)
                {
                    CheckLoadingAndMessageIfNeeded();
                }
                checkEstimateChanged();
            }
            lastPanelCheck = Time.time;
        }
    }
}
