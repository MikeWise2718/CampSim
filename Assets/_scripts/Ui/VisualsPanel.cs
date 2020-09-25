using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;
using TMPro;
using System;

public class VisualsPanel : MonoBehaviour
{
    public SceneMan sman;
    UiMan uiman;
    LinkCloudMan lman;
    MapMan mman;
    BuildingMan bman;
    GarageMan gman;
    VidcamMan vman;

    Dropdown initialScene;
    Dropdown treeOptions;
    Dropdown bldOptions;
    Dropdown linkVisuals;
    Dropdown slotVisuals;
    Dropdown mapVisuals;
    Dropdown backVisuals;
    Dropdown camSelection;
    InputField scenarioSeedInputField;
    TMP_Dropdown graphGenMode;

    Button closeButton;

    Slider linkTrans;
    float oldLinkTrans;
    Text linkTransText;


    bool panelActive = false;

    public void Init0()
    {
        panelActive = false;
        LinkObjectsAndComponents();
    }
    public void LinkObjectsAndComponents()
    {
        uiman = sman.uiman;
        bman = sman.bdman;
        lman = sman.lcman;
        gman = sman.gaman;
        mman = sman.mpman;
        vman = sman.vcman;

    }
    public void SceneLinkObjectsAndComponents()
    {
        initialScene = transform.Find("InitialSceneDropdown").gameObject.GetComponent<Dropdown>(); ;
        treeOptions = transform.Find("TreeModeDropdown").gameObject.GetComponent<Dropdown>();
        bldOptions = transform.Find("BuildingModeDropdown").gameObject.GetComponent<Dropdown>();
        linkVisuals = transform.Find("LinkVisualsDropdown").gameObject.GetComponent<Dropdown>();
        linkTrans = transform.Find("LinkVisualsTransSlider").gameObject.GetComponent<Slider>();
        slotVisuals = transform.Find("SlotVisualsDropdown").gameObject.GetComponent<Dropdown>();
        mapVisuals = transform.Find("MapVisualsDropdown").gameObject.GetComponent<Dropdown>();
        backVisuals = transform.Find("BackVisualsDropdown").gameObject.GetComponent<Dropdown>();
        camSelection = transform.Find("CameraSelectionDropdown").gameObject.GetComponent<Dropdown>();
        graphGenMode = transform.Find("GraphGenModeDropdown").gameObject.GetComponent<TMP_Dropdown>();
        scenarioSeedInputField = transform.Find("ScenarioSeedInputField").gameObject.GetComponent<InputField>();

        var linkTransTextGo = linkTrans.transform.Find("LinkVisualsTransparencyText").gameObject;
        linkTransText = linkTransTextGo.GetComponent<Text>();

        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel(); });
    }


    public void InitVals()
    {
        //Debug.Log("sman is null in VisualsPanel.InitVals");
        SceneLinkObjectsAndComponents();
        var errmsg = "Error in VisualsPanels.InitVals-";
        try
        {
            var soopts = SceneMan.GetSceneOptionsList();
            var soinival = SceneMan.GetInitialSceneOption().ToString();
            var soidx = soopts.FindIndex(s => s == soinival);
            if (soidx <= 0) soidx = 0;
            initialScene.ClearOptions();
            initialScene.AddOptions(soopts);
            initialScene.value = soidx;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}1:{ex.Message}");
        }

        try
        {
            //var tropts = BuildingMan.GetTreeOptionsList();
            //var trinival = BuildingMan.GetInitialTreeMode().ToString();
            var tropts = bman.treeMode.GetOptionsAsList();
            var trinival = bman.treeMode.Get().ToString();
            var tridx = tropts.FindIndex(s => s == trinival);
            if (tridx <= 0) tridx = 0;

            treeOptions.ClearOptions();
            treeOptions.AddOptions(tropts);
            treeOptions.value = tridx;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}1:{ex.Message}");
        }

        try
        {
            //var blopts = BuildingMan.GetBldOptionsList();
            //var trinival = BuildingMan.GetInitialBldMode().ToString();
            var blopts = bman.bldMode.GetOptionsAsList();
            var trinival = bman.bldMode.Get().ToString();
            var blidx = blopts.FindIndex(s => s == trinival);
            if (blidx <= 0) blidx = 0;

            bldOptions.ClearOptions();
            bldOptions.AddOptions(blopts);
            bldOptions.value = blidx;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}2:{ex.Message}");
        }
        try
        {
            //var opts = LinkCloudCtrl.GetLvisOptionsList();
            //var inival = LinkCloudCtrl.GetInitialLvisOption().ToString();
            var opts = lman.lvisOptions.GetOptionsAsList();
            var inival = lman.lvisOptions.Get().ToString();
            //lman.SetLinkAndNodeVisibility(inival); // we should not have to do this
            var idx = opts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;
            linkVisuals.ClearOptions();
            linkVisuals.AddOptions(opts);
            linkVisuals.value = idx;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}3:{ex.Message}");
        }
        try
        {
            linkTrans.minValue = lman.GetLinkTransMin();
            linkTrans.maxValue = lman.GetLinkTransMax();
            oldLinkTrans = lman.GetLinkTrans();
            linkTrans.value = oldLinkTrans;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}4:{ex.Message}");
        }
        try
        {
            var opts = gman.slotform.GetOptionsAsList();
            var inival = gman.slotform.Get().ToString();
            var idx = opts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            slotVisuals.ClearOptions();
            slotVisuals.AddOptions(opts);
            slotVisuals.value = idx;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}5:{ex.Message}");
        }
        try
        {
            var opts = mman.mapVisiblity.GetOptionsAsList();
            var inival = mman.mapVisiblity.Get().ToString();
            var idx = opts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            mapVisuals.ClearOptions();
            mapVisuals.AddOptions(opts);
            mapVisuals.value = idx;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}6:{ex.Message}");
        }
        try
        {
            var opts = vman.backType.GetOptionsAsList();
            var inival = vman.backType.Get().ToString();
            var idx = opts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            backVisuals.ClearOptions();
            backVisuals.AddOptions(opts);
            backVisuals.value = idx;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}7:{ex.Message}");
        }
        try
        {
            var opts = vman.GetCameraOptions();
            var inival = vman.mainCamName.Get().ToString();
            var idx = opts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            camSelection.ClearOptions();
            camSelection.AddOptions(opts);
            camSelection.value = idx;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}8:{ex.Message}");
        }
        try
        {
            var opts = lman.graphGenOptions.GetOptionsAsList();
            //Debug.Log($"VisualsPanel9 opts.count:{opts.Count} opts:{opts}");
            var inival = lman.graphGenOptions.Get().ToString();
            //Debug.Log($"VisualsPanel9 inival:{inival}");
            var idx = opts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            graphGenMode.ClearOptions();
            graphGenMode.AddOptions(opts);
            graphGenMode.value = idx;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}9:{ex.Message}");
        }

        scenarioSeedInputField.text = sman.scenarioSeed.Get().ToString();
        panelActive = true;
    }
    private void SetLinkTransText()
    {
        linkTransText.text = "Transparency " + linkTrans.value.ToString("F2");
        if (oldLinkTrans != linkTrans.value)
        {
            lman.SetLinkTrans(linkTrans.value);
            oldLinkTrans = linkTrans.value;
            linkTransText.text = "Transparency " + linkTrans.value.ToString("F2");
            sman.RequestRefresh("VisualPanel-SetLinkTransText");
        }
    }
    public void SetVals(bool closing = false)
    {
        //Debug.Log($"VisualsPanel/SetVals called - closing:{closing}");
        var chg = false;
        var errmsg = "Error in VisualsPanels.SetVals-";
        try
        {
            var curregionstr = SceneMan.GetSceneOptionsString(initialScene.value);
            SceneMan.SetInitialSceneOption(curregionstr);
            var reqScene = SceneMan.GetSceneOptionsEnum(curregionstr,"UI");
            if (reqScene != sman.curscene)
            {
                chg = true;
                sman.RequestRefresh("VisualsPanel.SetVals", totalrefresh: true, requestedScene: reqScene);
                //sman.SetScene(curregion);
            }
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}1:{ex.Message}");
        }
        try
        {
            var tropts = bman.treeMode.GetOptionsAsList();
            var newval = tropts[treeOptions.value];
            chg = chg || bman.treeMode.SetAndSave(newval);
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}2:{ex.Message}");
        }
        try
        {
            var blopts = bman.bldMode.GetOptionsAsList();
            var newval = blopts[bldOptions.value];
            chg = chg || bman.bldMode.SetAndSave(newval);
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}3:{ex.Message}");
        }
        try
        {
            var lvopts = lman.lvisOptions.GetOptionsAsList();
            var newval = lvopts[linkVisuals.value];
            var lchg = lman.lvisOptions.SetAndSave(newval);
            if (lchg)
            {
                lman.SetLinkAndNodeVisibility(newval);
            }
            chg = chg || lchg;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}4:{ex.Message}");
        }
        try
        {
            var lchg = lman.SetLinkTrans(linkTrans.value);
            if (lchg)
            {
                SetLinkTransText();
            }
            chg = chg || lchg;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}5:{ex.Message}");
        }
        try
        {
            var slopts = gman.slotform.GetOptionsAsList();
            var newval = slopts[slotVisuals.value];
            var lchg = gman.slotform.SetAndSave(newval);
            if (lchg)
            {
                gman.RealizeSlotForm(newval);
            }
            chg = chg || lchg;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}6:{ex.Message}");
        }
        try
        {
            var mvopts = mman.mapVisiblity.GetOptionsAsList();
            var newval = mvopts[mapVisuals.value];
            var lchg = mman.mapVisiblity.SetAndSave(newval);
            if (lchg)
            {
                mman.RealizeMapVisuals();
            }
            chg = chg || lchg;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}7:{ex.Message}");
        }
        try
        {
            var bkopts = vman.backType.GetOptionsAsList();
            var newval = bkopts[backVisuals.value];
            var lchg = vman.backType.SetAndSave(newval);
            if (lchg)
            {
                vman.RealizeBackground();
            }
            chg = chg || lchg;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}8:{ex.Message}");
        }
        try
        {
            var vcopts = vman.GetCameraOptions();
            var newval = vcopts[camSelection.value];
            var lchg = vman.mainCamName.SetAndSave(newval);
            if (lchg)
            {
                vman.SetMainCameraToVcam(newval);
            }
            chg = chg || lchg;
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}9 - CameraOptions:{ex.Message}");
            sman.LggError($"   CameraOptions");
            sman.LggError($"   value: {camSelection.value}");
            sman.LggError($"   opt count:{vman.GetCameraOptions().Count}");
            sman.LggError($"   mainCamName:{vman.mainCamName.Get()}");
        }
        try
        {
            var ggopts = lman.graphGenOptions.GetOptionsAsList();
            var newval = ggopts[graphGenMode.value];
            chg = chg || lman.graphGenOptions.SetAndSave(newval);
        }
        catch (Exception ex)
        {
            sman.LggError($"{errmsg}10:{ex.Message}");
        }
        var ok = int.TryParse(scenarioSeedInputField.text, out var ival);
        if (ok)
        {
            var oval = sman.scenarioSeed.Get();
            if (ival!=oval)
            {
                sman.scenarioSeed.SetAndSave(ival);
                chg = true;
            }
        }
        panelActive = false;
        if (chg)
        {
            sman.RequestRefresh("VisualPanel-SetVals");
        }

        //Debug.Log("Setvals done");
    }

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
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (panelActive)
        {
            SetLinkTransText();
        }
    }
}
