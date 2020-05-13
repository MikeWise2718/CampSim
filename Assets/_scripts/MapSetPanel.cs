﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;

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
    Button deleteSettingsButton;

    Text latLngText;
    Text latKmText;
    Text lngKmText;

    public bool needSetSceneReset;


    public SceneMan sman;
    public MapMan mman;

    bool panelActive = false;
    bool buttonsInited = false;
    bool linked = false;

    void Start()
    {
        //Debug.Log("MapSetPanel Start called");
        panelActive = false;
        LinkObjectsAndComponents();
    }

    public void LinkObjectsAndComponents()
    {
        //Debug.Log("MapSetPanel LinkObjectsAndComponents called");
        sman = FindObjectOfType<SceneMan>();
        if (sman == null)
        {
            Debug.LogError("MapSet panel could not find SceneMan");
        }
        mman = FindObjectOfType<MapMan>();
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
        deleteSettingsButton = transform.Find("DeleteSettingsButton").gameObject.GetComponent<Button>();
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
        //Debug.Log("MapSetPanel.LinkObjectsAndComponents Found everything apparently");
        linked = true;
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
        InitCheckNeedSetModeRefresh();

       // Debug.Log("MapSetPanel.InitVals called");
        if (!linked)
        {
            LinkObjectsAndComponents();
        }


        var errmsg = "Error in MapSetPanel.InitVals-";
        try
        {
            var opts = MapMan.GetMapProviderList();
            var inival = mman.reqMapProv.Get().ToString();
            Debug.Log($"InitVals get:{inival}");
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
        oldHmultVal = -9e9f;
        hmultVal.value = mman.hmult.Get();

        UpdateHmult();
        UpdateFileText();

        lodVal.minValue = 0;
        lodVal.maxValue = 19;

        npqkVal.minValue = 1;
        npqkVal.maxValue = 48;
        oldHmultVal = -9e9f;
        npqkVal.value = mman.nodesPerQuadKey;

        var stats = mman.GetQkmeshStatistics();
        if (stats != null)
        {
            var lats = stats.llbox.midll.lat.ToString("f6");
            var lngs = stats.llbox.midll.lng.ToString("f6");
            latLngText.text = $"lat,lng: {lats},{lngs}";
            var latkms = stats.heightKm.ToString("f5");
            var lngkms = stats.widthKm.ToString("f5");
            latKmText.text = $"Latkm: {latkms}   lat-tiles:{stats.nqktiles.y}";
            lngKmText.text = $"Lnglm: {lngkms}   lng-tiles:{stats.nqktiles.x}";
            //Debug.Log($"Setting lod to {stats.llbox.lod}");
            lodVal.value = stats.llbox.lod;
            npqkVal.value = mman.nodesPerQuadKey;
            SetLodTextValues();
            SetNpqkTextValues();
        }


        if (!buttonsInited)
        {
            closeButton.onClick.AddListener(delegate { ButtonClick(closeButton.name); });
            copyClipboardButton.onClick.AddListener(delegate { ButtonClick(copyClipboardButton.name); });
            deleteSettingsButton.onClick.AddListener(delegate { ButtonClick(deleteSettingsButton.name); });
            deleteMapsButton.onClick.AddListener(delegate { ButtonClick(deleteMapsButton.name); });
            loadMapsButton.onClick.AddListener(delegate { ButtonClick(loadMapsButton.name); });
            buttonsInited = true;
        }

        panelActive = true;
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
        var sregkey = "User settings regkey:"+" Computer\\HKEY_CURRENT_USER\\Software\\Unity\\UnityEditor\\DefaultCompany\\campusim";
        persMapsPathText.text = s1;
        persMapsDataText.text = s2;
        persElevPathText.text = s3;
        persElevInfoText.text = s4;
        tempMapsPathText.text = s5;
        tempMapsDataText.text = s6;
        tempElevPathText.text = s7;
        tempElevInfoText.text = s8;
        copyClipText = $"{s1}\n{s2}\n{s5}\n{s6}\n\n{s3}\n{s4}\n{s7}\n{s8}\n\n{sregkey}";
    }

    bool isLoadingMaps = false;
    float loadStartTime = 0;
    void StartLoading()
    {
        isLoadingMaps = true;
        loadStartTime = Time.time;
        mman.DeleteMaps();
        mman.LoadMaps();
    }
    float checkLoadInterval = 0.25f;
    float lastLoadCheck = 0;
    void CheckLoading()
    {
        if (isLoadingMaps && Time.time-lastLoadCheck>checkLoadInterval)
        {
            var msg = "";
            var (isLoading, nbmLoaded, nbmToLoad, nelevBatchesLoaded, nelevBatchsToLoad) = mman.GetLoadingStatus();
            var numstr = $"{nbmLoaded}/{nbmToLoad}  {nelevBatchesLoaded}/{nelevBatchsToLoad}";
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
            loadStatusText.text = msg;
        }
    }
    void ButtonClick(string buttonname)
    {
        //Debug.Log("Clicked " + buttonname);
        switch (buttonname)
        {
            case "CloseButton":
                {
                    var spcomp = FindObjectOfType<StatusPanel>();
                    spcomp.OptionsButton();
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
                    StartLoading();
                    break;
                }
            case "DeleteMapsButton":
                {
                    mman.DeleteMaps();
                    break;
                }
        }
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
    private void UpdateHmult()
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

    private void Updatelod()
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


    public void SetVals(bool closing=false)
    {
        Debug.Log("MapSetPanel.SetVals called closing:{closing}");

        var sw = new Aiskwk.Map.StopWatch();
        sw.Start();

   
        var chg = false;
        var errmsg = "Error in VisualsPanels.SetVals-";
        try
        {
            var curstr = MapMan.GetMapProviderString(mapProv.value);
            MapMan.SetInitialMapProvider(curstr);
            var curmap = MapMan.GetMapProviderEnum(curstr);
            if (curmap != mman.reqMapProv.Get())
            {
                chg = true;
                mman.SetMap(curmap);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"{errmsg}-1:{ex.Message}");
        }

        try
        {
            var curstr = MapMan.GetElevProviderString(eleProv.value);
            MapMan.SetInitialElevProvider(curstr);
            var curele = MapMan.GetElevProviderEnum(curstr);
            if (curele != mman.reqEleProv.Get())
            {
                chg = true;
                mman.SetEle(curele);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"{errmsg}-2:{ex.Message}");
        }
        sw.Mark();
        Debug.Log($"MapSetPanel.SetVals Phase1 took:{sw.ElapSecs()} secs");

        UpdateHmult();
        panelActive = false;


        mman.SetUseElevations(useElevationsToggle.isOn);
        mman.SetFlatTris(flatTrisToggle.isOn);
        mman.SetQuadkeyFraming(frameQuadkeysToggle.isOn);
        mman.SetMeshGrid(meshGridToggle.isOn);
        mman.SetTriPoints(triPointsToggle.isOn);
        mman.SetMeshPoints(meshPointsToggle.isOn);
        mman.SetCoordPoints(coordPointsToggle.isOn);
        mman.SetExtentPoints(extentPointsToggle.isOn);

        mman.SetHmult(hmultVal.value);

        sman.RequestRefresh("MapSetPanel-SetVals");
        sw.Stop();
        Debug.Log($"MapSetPanel.SetVals Phase1 took in total :{sw.ElapSecs()} secs");
        var needSetScene = CheckNeedSetSceneRefresh();
        sman.RequestRefresh("MapSetPanel-SetVals",totalrefresh:needSetScene);
        if (needSetScene)
        {
            Debug.LogWarning("Need set mode reset");
            /// how do do do this now?
        }
    }
    float fileTextUpdate;
    // Update is called once per frame
    void Update()
    {
        if (panelActive)
        {
            if (nSetHmultTextValueCalled == 0)
            {
               SetHmultTextValues();
            }
            UpdateHmult();
            UpdateChangables();
            if (Time.time - fileTextUpdate > 1)
            {
                UpdateFileText();
                fileTextUpdate = Time.time;
            }
            if (isLoadingMaps)
            {
                CheckLoading();
            }
        }
    }
}
