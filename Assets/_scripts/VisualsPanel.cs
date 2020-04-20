using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;
using TMPro;

public class VisualsPanel : MonoBehaviour
{
    Dropdown initialScene;
    Dropdown treeOptions;
    Dropdown bldOptions;
    Dropdown linkVisuals;
    Dropdown slotVisuals;
    Dropdown mapVisuals;
    Dropdown backVisuals;
    Dropdown camSelection;
    TMP_Dropdown graphGenMode;

    Slider linkTrans;
    float oldLinkTrans;
    Text linkTransText;

    public SceneMan sman;
    public LinkCloudMan lman;
    public MapMan mman;
    public BuildingMan bman;
    public GarageMan gman;
    public VidcamMan vman;

    bool panelActive = false;

    void Start()
    {
        panelActive = false;
        LinkObjectsAndComponents();
    }
    public void LinkObjectsAndComponents()
    {
        sman = FindObjectOfType<SceneMan>();
        if (sman == null)
        {
            throw new UnityException("Options panel could not find RegionMan");
        }
        bman = FindObjectOfType<BuildingMan>();
        lman = FindObjectOfType<LinkCloudMan>();
        gman = FindObjectOfType<GarageMan>();
        mman = FindObjectOfType<MapMan>();
        vman = FindObjectOfType<VidcamMan>();

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

        var linkTransTextGo = linkTrans.transform.Find("LinkVisualsTransparencyText").gameObject;
        linkTransText = linkTransTextGo.GetComponent<Text>();
    }
    public void InitVals()
    {
        if (sman==null)
        {
            LinkObjectsAndComponents();
        }
        {
            var soopts = SceneMan.GetSceneOptionsList();
            var soinival = SceneMan.GetInitialSceneOption().ToString();
            var soidx = soopts.FindIndex(s => s == soinival);
            if (soidx <= 0) soidx = 0;
            initialScene.ClearOptions();
            initialScene.AddOptions(soopts);
            initialScene.value = soidx;
        }

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
        {
            linkTrans.minValue = lman.GetLinkTransMin();
            linkTrans.maxValue = lman.GetLinkTransMax();
            oldLinkTrans = lman.GetLinkTrans();
            linkTrans.value = oldLinkTrans;
        }
        {
            var opts = gman.slotform.GetOptionsAsList();
            var inival = gman.slotform.Get().ToString();
            var idx = opts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            slotVisuals.ClearOptions();
            slotVisuals.AddOptions(opts);
            slotVisuals.value = idx;
        }
        {
            var opts = mman.mapVisiblity.GetOptionsAsList();
            var inival = mman.mapVisiblity.Get().ToString();
            var idx = opts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            mapVisuals.ClearOptions();
            mapVisuals.AddOptions(opts);
            mapVisuals.value = idx;
        }
        {
            var opts = vman.backType.GetOptionsAsList();
            var inival = vman.backType.Get().ToString();
            var idx = opts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            backVisuals.ClearOptions();
            backVisuals.AddOptions(opts);
            backVisuals.value = idx;
        }
        {
            var opts = vman.GetCameraOptions();
            var inival = vman.mainCamName.Get().ToString();
            var idx = opts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            camSelection.ClearOptions();
            camSelection.AddOptions(opts);
            camSelection.value = idx;
        }
        {
            var opts = lman.graphGenOptions.GetOptionsAsList();
            var inival = lman.graphGenOptions.Get().ToString();
            //Debug.Log("ggo inival:" + inival);
            var idx = opts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;

            graphGenMode.ClearOptions();
            graphGenMode.AddOptions(opts);
            graphGenMode.value = idx;
        }
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
    public void SetVals()
    {
        var chg = false;
        {
            var curregionstr = SceneMan.GetSceneOptionsString(initialScene.value);
            SceneMan.SetInitialSceneOption(curregionstr);
            var curregion = SceneMan.GetSceneOptionsEnum(curregionstr);
            sman.SetScene(curregion);
        }
        {
            var tropts = bman.treeMode.GetOptionsAsList();
            var newval = tropts[treeOptions.value];
            chg = chg || bman.treeMode.SetAndSave(newval);
        }
        {
            var blopts = bman.bldMode.GetOptionsAsList();
            var newval = blopts[bldOptions.value];
            chg = chg || bman.bldMode.SetAndSave(newval);
        }
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
        {
            var lchg = lman.SetLinkTrans(linkTrans.value);
            if (lchg)
            {
                SetLinkTransText();
            }
            chg = chg || lchg;
        }
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
        {
            var mvopts = mman.mapVisiblity.GetOptionsAsList();
            var newval = mvopts[mapVisuals.value];
            var lchg =  mman.mapVisiblity.SetAndSave(newval);
            if (lchg)
            {
                mman.RealizeMapVisuals();
            }
            chg = chg || lchg;
        }
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
        {
            var ggopts = lman.graphGenOptions.GetOptionsAsList();
            var newval = ggopts[graphGenMode.value];
            chg = chg || lman.graphGenOptions.SetAndSave(newval);
        }
        panelActive = false;
        if (chg)
        {
            sman.RequestRefresh("VisualPanel-SetVals");
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
