using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;

public class BuildingsPanel : MonoBehaviour
{
    public SceneMan sman;
    UiMan uiman;

    Toggle b19_model_toggle;
    Toggle b19_level1_toggle;
    Toggle b19_level2_toggle;
    Toggle b19_level3_toggle;
    Toggle b19_hvac_toggle;
    Toggle b19_floors_toggle;
    Toggle b19_doors_toggle;
    Toggle b19_osmbld_toggle;
    Toggle b19_wilbld_toggle;

    Toggle b121_model_toggle;
    Toggle b121_shell_toggle;
    Toggle b121_interiorwalls_toggle;
    Toggle b121_hvac_toggle;
    Toggle b121_lighting_toggle;
    Toggle b121_plumbing_toggle;
    Toggle b121_osmbld_toggle;
    Toggle b121_wilbld_toggle;


    Toggle walllinks_toggle;
    Toggle osmblds_toggle;
    Toggle osmbldstrans_toggle;
    Toggle osmbldspolys_toggle;
    Toggle osmoutline_toggle;
    Toggle osmgroundoutline_toggle;
    Toggle fixedblds_toggle;
    Toggle osmstreets_toggle;
    Toggle fixedstreets_toggle;

    Dropdown b19_matmode_dropdown;
    Dropdown b121_matmode_dropdown;
    Button applyButton;
    Button closeButton;

    StreetMan stman;
    BuildingMan bdman;
    B19Willow b19comp;
    B121Willow b121comp;
    StaplesStadium sscomp;



    public void Init0()
    {
        bdman = sman.bdman;
        stman = sman.stman;
        uiman = sman.uiman;
        b19_model_toggle = transform.Find("B19ModelToggle").GetComponent<Toggle>();
        b19_level1_toggle = transform.Find("Level1Toggle").GetComponent<Toggle>();
        b19_level2_toggle = transform.Find("Level2Toggle").GetComponent<Toggle>();
        b19_level3_toggle = transform.Find("Level3Toggle").GetComponent<Toggle>();
        b19_hvac_toggle = transform.Find("HVACToggle").GetComponent<Toggle>();
        b19_floors_toggle = transform.Find("FloorsToggle").GetComponent<Toggle>();
        b19_doors_toggle = transform.Find("DoorsToggle").GetComponent<Toggle>();
        b19_osmbld_toggle = transform.Find("OsmbldToggle").GetComponent<Toggle>();
        b19_wilbld_toggle = transform.Find("WilbldToggle").GetComponent<Toggle>();
        b19_matmode_dropdown = transform.Find("MaterialModeDropdown").GetComponent<Dropdown>();

        b121_model_toggle = transform.Find("B121ModelToggle").GetComponent<Toggle>();
        b121_shell_toggle = transform.Find("B121ShellToggle").GetComponent<Toggle>();
        b121_interiorwalls_toggle = transform.Find("B121InteriorWallsToggle").GetComponent<Toggle>();
        b121_hvac_toggle = transform.Find("B121HvacToggle").GetComponent<Toggle>();
        b121_lighting_toggle = transform.Find("B121LightingToggle").GetComponent<Toggle>();
        b121_plumbing_toggle = transform.Find("B121PlumbingToggle").GetComponent<Toggle>();
        b121_osmbld_toggle = transform.Find("B121OsmbldToggle").GetComponent<Toggle>();
        b121_wilbld_toggle = transform.Find("B121WilbldToggle").GetComponent<Toggle>();
        b121_matmode_dropdown = transform.Find("B121MaterialModeDropdown").GetComponent<Dropdown>();

        walllinks_toggle = transform.Find("WallLinksToggle").GetComponent<Toggle>();
        osmblds_toggle = transform.Find("OsmBldsToggle").GetComponent<Toggle>();
        osmbldstrans_toggle = transform.Find("OsmBldsTransToggle").GetComponent<Toggle>();
        osmbldspolys_toggle = transform.Find("OsmBldsPolygonsToggle").GetComponent<Toggle>();
        osmoutline_toggle = transform.Find("OsmBldsOutlineToggle").GetComponent<Toggle>();
        osmgroundoutline_toggle = transform.Find("OsmBldsGroundOutlineToggle").GetComponent<Toggle>();
        fixedblds_toggle = transform.Find("FixedBldsToggle").GetComponent<Toggle>();

        osmstreets_toggle = transform.Find("OsmStreetsToggle").GetComponent<Toggle>();
        fixedstreets_toggle = transform.Find("FixedStreetsToggle").GetComponent<Toggle>();

        applyButton = transform.Find("ApplyButton").gameObject.GetComponent<Button>();
        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel(); });
        applyButton.onClick.AddListener(delegate { SetVals(); });
        //applyButton.onClick.AddListener(delegate { MakeItSo(); });
    }

    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
        InitVals();
    }


    public void EnableStapStadParts(bool state)
    {
        //b19_model_toggle.enabled = state;
        //b19_level1_toggle.enabled = state;
        //b19_level2_toggle.enabled = state;
        //b19_level3_toggle.enabled = state;
        //b19_hvac_toggle.enabled = state;
        //b19_floors_toggle.enabled = state;
        //b19_doors_toggle.enabled = state;
        //b19_osmbld_toggle.enabled = state;
        //b19_wilbld_toggle.enabled = state;
    }

    public void EnableB19Parts(bool state)
    {
        b19_model_toggle.enabled = state;
        b19_level1_toggle.enabled = state;
        b19_level2_toggle.enabled = state;
        b19_level3_toggle.enabled = state;
        b19_hvac_toggle.enabled = state;
        b19_floors_toggle.enabled = state;
        b19_doors_toggle.enabled = state;
        b19_osmbld_toggle.enabled = state;
        b19_wilbld_toggle.enabled = state;
    }

    public void EnableB121Parts(bool state)
    {
        b121_model_toggle.enabled = state;
        b121_shell_toggle.enabled = state;
        b121_interiorwalls_toggle.enabled = state;
        b121_hvac_toggle.enabled = state;
        b121_lighting_toggle.enabled = state;
        b121_plumbing_toggle.enabled = state;
        b121_osmbld_toggle.enabled = state;
        b121_wilbld_toggle.enabled = state;
    }



    public void InitVals()
    {
        InitB19Vals();
        InitB121Vals();
        InitSsVals();

        walllinks_toggle.isOn = bdman.walllinks.Get();
        osmblds_toggle.isOn = bdman.osmblds.Get();
        osmbldstrans_toggle.isOn = bdman.osmbldstrans.Get();
        osmbldspolys_toggle.isOn = bdman.osmbldpolygons.Get();
        osmoutline_toggle.isOn = bdman.osmoutline.Get();
        osmgroundoutline_toggle.isOn = bdman.osmgroundoutline.Get();
        fixedblds_toggle.isOn = bdman.fixedblds.Get();

        osmstreets_toggle.isOn = stman.osmstreets.Get();
        fixedstreets_toggle.isOn = stman.fixedstreets.Get();
    }

    public void InitB121Vals()
    {
        b121comp = null;
        var b121bld = bdman.GetBuilding("Bld121", couldFail: true);
        if (b121bld != null)
        {
            b121comp = b121bld.GetComponent<B121Willow>();
            if (b121comp == null)
            {
                Debug.LogWarning("BuildingsPanel could not find B121 willow component in B121 building object that it needs to operate");
            }
        }

        if (b121comp == null)
        {
            EnableB121Parts(false);
            b121_interiorwalls_toggle.isOn = false;
        }
        else
        {
            EnableB121Parts(true);
            b121_model_toggle.isOn = b121comp.loadmodel.Get();
            b121_shell_toggle.isOn = b121comp.shell.Get();
            b121_interiorwalls_toggle.isOn = b121comp.interiorwalls.Get();
            b121_hvac_toggle.isOn = b121comp.hvac.Get();
            b121_lighting_toggle.isOn = b121comp.lighting.Get();
            b121_plumbing_toggle.isOn = b121comp.plumbing.Get();
            b121_osmbld_toggle.isOn = b121comp.osmbld.Get();

            // MaterialMode
            {
                var opts = b121comp.b121_materialMode.GetOptionsAsList();
                var inival = b121comp.b121_materialMode.Get().ToString();
                var idx = opts.FindIndex(s => s == inival);
                if (idx <= 0) idx = 0;
                b121_matmode_dropdown.ClearOptions();
                b121_matmode_dropdown.AddOptions(opts);
                //Debug.Log("MatMode add options n:" + opts.Count);
                b121_matmode_dropdown.value = idx;
            }
        }
    }
    public void InitB19Vals()
    {
        b19comp = null;
        var b19bld = bdman.GetBuilding("Bld19", couldFail: true);
        if (b19bld != null)
        {
            b19comp = b19bld.GetComponent<B19Willow>();
            if (b19comp == null)
            {
                Debug.LogWarning("BuildingsPanel could not find B19Willow component in B19 building object that it needs to operate");
            }
        }

        if (b19comp == null)
        {
            EnableB19Parts(false);
            b19_model_toggle.isOn = false;
            b19_level1_toggle.isOn = false;
            b19_level2_toggle.isOn = false;
            b19_level3_toggle.isOn = false;
            b19_hvac_toggle.isOn = false;
            b19_floors_toggle.isOn = false;
            b19_doors_toggle.isOn = false;
            b19_osmbld_toggle.isOn = false;
            b19_wilbld_toggle.isOn = false;

            b19_matmode_dropdown.ClearOptions();
        }
        else
        {
            EnableB19Parts(true);
            b19_model_toggle.isOn = b19comp.loadmodel.Get();
            b19_level1_toggle.isOn = b19comp.level01.Get();
            b19_level2_toggle.isOn = b19comp.level02.Get();
            b19_level3_toggle.isOn = b19comp.level03.Get();
            b19_hvac_toggle.isOn = b19comp.hvac.Get();
            b19_floors_toggle.isOn = b19comp.floors.Get();
            b19_doors_toggle.isOn = b19comp.doors.Get();
            b19_osmbld_toggle.isOn = b19comp.osmbld.Get();
            b19_wilbld_toggle.isOn = b19comp.wilbld.Get();

            // MaterialMode
            {
                var opts = b19comp.b19_materialMode.GetOptionsAsList();
                var inival = b19comp.b19_materialMode.Get().ToString();
                var idx = opts.FindIndex(s => s == inival);
                if (idx <= 0) idx = 0;
                b19_matmode_dropdown.ClearOptions();
                b19_matmode_dropdown.AddOptions(opts);
                //Debug.Log("MatMode add options n:" + opts.Count);
                b19_matmode_dropdown.value = idx;
            }
        }
    }

    public void InitSsVals()
    {
        sscomp = null;
        var ssbld = bdman.GetBuilding("StaplesStadium", couldFail: true);
        if (ssbld != null)
        {
            sscomp = ssbld.GetComponent<StaplesStadium>();
            if (sscomp == null)
            {
                Debug.LogWarning("BuildingsPanel could not find B19Willow component in B19 building object that it needs to operate");
            }
        }

        if (sscomp == null)
        {
            EnableB19Parts(false);
            b19_model_toggle.isOn = false;
            b19_level1_toggle.isOn = false;
            b19_level2_toggle.isOn = false;
            b19_level3_toggle.isOn = false;
            b19_hvac_toggle.isOn = false;
            b19_floors_toggle.isOn = false;
            b19_doors_toggle.isOn = false;
            b19_osmbld_toggle.isOn = false;
            b19_wilbld_toggle.isOn = false;

            b19_matmode_dropdown.ClearOptions();
        }
        else
        {
            EnableB19Parts(true);
            b19_model_toggle.isOn = b19comp.loadmodel.Get();
            b19_level1_toggle.isOn = b19comp.level01.Get();
            b19_level2_toggle.isOn = b19comp.level02.Get();
            b19_level3_toggle.isOn = b19comp.level03.Get();
            b19_hvac_toggle.isOn = b19comp.hvac.Get();
            b19_floors_toggle.isOn = b19comp.floors.Get();
            b19_doors_toggle.isOn = b19comp.doors.Get();
            b19_osmbld_toggle.isOn = b19comp.osmbld.Get();
            b19_wilbld_toggle.isOn = b19comp.wilbld.Get();

            // MaterialMode
            {
                var opts = b19comp.b19_materialMode.GetOptionsAsList();
                var inival = b19comp.b19_materialMode.Get().ToString();
                var idx = opts.FindIndex(s => s == inival);
                if (idx <= 0) idx = 0;
                b19_matmode_dropdown.ClearOptions();
                b19_matmode_dropdown.AddOptions(opts);
                //Debug.Log("MatMode add options n:" + opts.Count);
                b19_matmode_dropdown.value = idx;
            }
        }
    }

    public void MakeItSo()
    {
        if (b19comp!=null)
        {
            b19comp.MakeItSo();
        }
        if (b121comp != null)
        {
            b121comp.MakeItSo();
        }
    }


    public void SetVals(bool closing=false)
    {

        //Debug.Log("BuildingsPanel SetVals2 called");
        //fman.visibilityTiedToDetectability = visTiedToggle.isOn;
        var chg = false;
        var tchg = false;
        if (b19comp != null)
        {
            chg = chg || b19comp.loadmodel.SetAndSave(b19_model_toggle.isOn);
            chg = chg || b19comp.level01.SetAndSave(b19_level1_toggle.isOn);
            chg = chg || b19comp.level02.SetAndSave(b19_level2_toggle.isOn);
            chg = chg || b19comp.level03.SetAndSave(b19_level3_toggle.isOn);
            chg = chg || b19comp.hvac.SetAndSave(b19_hvac_toggle.isOn);
            chg = chg || b19comp.floors.SetAndSave(b19_floors_toggle.isOn);
            chg = chg || b19comp.doors.SetAndSave(b19_doors_toggle.isOn);
            chg = chg || b19comp.osmbld.SetAndSave(b19_osmbld_toggle.isOn);
            chg = chg || b19comp.wilbld.SetAndSave(b19_wilbld_toggle.isOn);
            {
                var opts = b19comp.b19_materialMode.GetOptionsAsList();
                var newval = opts[b19_matmode_dropdown.value];
                //Debug.Log("Set toptextlabel default to " + newval);
                chg = chg || b19comp.b19_materialMode.SetAndSave(newval);
            }
        }
        if (b121comp!=null)
        { 
            chg = chg || b121comp.loadmodel.SetAndSave(b121_model_toggle.isOn);
            chg = chg || b121comp.shell.SetAndSave(b121_shell_toggle.isOn);
            chg = chg || b121comp.interiorwalls.SetAndSave(b121_interiorwalls_toggle.isOn);
            chg = chg || b121comp.hvac.SetAndSave(b121_hvac_toggle.isOn);
            chg = chg || b121comp.lighting.SetAndSave(b121_lighting_toggle.isOn);
            chg = chg || b121comp.plumbing.SetAndSave(b121_plumbing_toggle.isOn);
            chg = chg || b121comp.osmbld.SetAndSave(b121_osmbld_toggle.isOn);
            chg = chg || b121comp.wilbld.SetAndSave(b121_wilbld_toggle.isOn);
            {
                var opts = b121comp.b121_materialMode.GetOptionsAsList();
                var newval = opts[b121_matmode_dropdown.value];
                //Debug.Log("Set toptextlabel default to " + newval);
                chg = chg || b121comp.b121_materialMode.SetAndSave(newval);


            }
        }

        tchg = tchg || bdman.walllinks.SetAndSave(walllinks_toggle.isOn);
        tchg = tchg || bdman.osmblds.SetAndSave(osmblds_toggle.isOn);
        tchg = tchg || bdman.osmbldstrans.SetAndSave(osmbldstrans_toggle.isOn);
        tchg = tchg || bdman.osmbldpolygons.SetAndSave(osmbldspolys_toggle.isOn);
        tchg = tchg || bdman.osmoutline.SetAndSave(osmoutline_toggle.isOn);
        tchg = tchg || bdman.osmgroundoutline.SetAndSave(osmgroundoutline_toggle.isOn);
        tchg = tchg || stman.osmstreets.SetAndSave(osmstreets_toggle.isOn);
        tchg = tchg || stman.fixedstreets.SetAndSave(fixedstreets_toggle.isOn);
        chg = chg || bdman.fixedblds.SetAndSave(fixedblds_toggle.isOn);


        Debug.Log($"SetValsForRefresh t:{Time.time:f1}   chg:{chg} tchg:{tchg}");
        if (chg || tchg)
        {
            if (b121comp != null)
            {
                b121comp.ActuateChange();
            }
            if (b19comp != null)
            {
                b19comp.ActuateChange();
            }
            //Debug.Log($"BuildingsPanel.SetValsForRefresh bman.fixedblds.SetAndSave:{fixedblds_toggle.isOn}");
            sman.RequestRefresh("BuildingsPanel.SetValsForRefresh", totalrefresh:tchg);
        }
    }
    //float lastcheck = 0;
    //bool panelActiveForRefreshChecks = false;    // Update is called once per frame
    //void Update()
    //{
    //    if (panelActiveForRefreshChecks)
    //    {
    //        if (Time.time - lastcheck > 0.5f)
    //        {
    //            SetValsForRefresh();
    //            lastcheck = Time.time;
    //        }
    //    }
    //}
}
