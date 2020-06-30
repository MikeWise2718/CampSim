using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;

public class B19Panel : MonoBehaviour
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
    Toggle walllinks_toggle;
    Toggle osmblds_toggle;
    Toggle fixedblds_toggle;

    Dropdown b19_matmode_dropdown;
    Button closeButton;

    BuildingMan bman;
    B19Willow b19comp;

    bool panelActiveForRefreshChecks = false;

    public void Init0()
    {
        bman = sman.bdman;
        uiman = sman.uiman;
        b19_model_toggle = transform.Find("B19ModelToggle").GetComponent<Toggle>();
        b19_level1_toggle = transform.Find("Level1Toggle").GetComponent<Toggle>();
        b19_level2_toggle = transform.Find("Level2Toggle").GetComponent<Toggle>();
        b19_level3_toggle = transform.Find("Level3Toggle").GetComponent<Toggle>();
        b19_hvac_toggle = transform.Find("HVACToggle").GetComponent<Toggle>();
        b19_floors_toggle = transform.Find("FloorsToggle").GetComponent<Toggle>();
        b19_doors_toggle = transform.Find("DoorsToggle").GetComponent<Toggle>();
        b19_matmode_dropdown = transform.Find("MaterialModeDropdown").GetComponent<Dropdown>();

        walllinks_toggle = transform.Find("WallLinksToggle").GetComponent<Toggle>();
        osmblds_toggle = transform.Find("OsmBldsToggle").GetComponent<Toggle>();
        fixedblds_toggle = transform.Find("FixedBldsToggle").GetComponent<Toggle>();


        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel(); });
    }

    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
        InitVals();
    }


    public void EnableComponents(bool state)
    {
        b19_model_toggle.enabled = state;
        b19_level1_toggle.enabled = state;
        b19_level2_toggle.enabled = state;
        b19_level3_toggle.enabled = state;
        b19_hvac_toggle.enabled = state;
        b19_floors_toggle.enabled = state;
        b19_doors_toggle.enabled = state;

    }


    public void InitVals()
    {
        b19comp = null;
        var bld = bman?.GetBuilding("Bld19",couldFail:true);
        if (bld != null)
        {
            b19comp = bld.GetComponent<B19Willow>();
            if (b19comp==null)
            {
                Debug.LogWarning("B19Panel could not find B19Willow component in B19 building object that it needs to operate");
            }
        }
        walllinks_toggle.isOn = bman.walllinks.Get();
        osmblds_toggle.isOn = bman.osmblds.Get();
        fixedblds_toggle.isOn = bman.fixedblds.Get();

        if (b19comp == null)
        {
            EnableComponents(false);
            b19_model_toggle.isOn = false;
            b19_level1_toggle.isOn = false;
            b19_level2_toggle.isOn = false;
            b19_level3_toggle.isOn = false;
            b19_hvac_toggle.isOn = false;
            b19_floors_toggle.isOn = false;
            b19_doors_toggle.isOn = false;

            b19_matmode_dropdown.ClearOptions();
        }
        else
        {
            EnableComponents(true);
            b19_model_toggle.isOn = b19comp.loadmodel.Get();
            b19_level1_toggle.isOn = b19comp.level01.Get();
            b19_level2_toggle.isOn = b19comp.level02.Get();
            b19_level3_toggle.isOn = b19comp.level03.Get();
            b19_hvac_toggle.isOn = b19comp.hvac.Get();
            b19_floors_toggle.isOn = b19comp.floors.Get();
            b19_doors_toggle.isOn = b19comp.doors.Get();



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
            //visTiedToggle.isOn = fman.visibilityTiedToDetectability;
        }
        panelActiveForRefreshChecks = true;
    }


    public void SetVals(bool closing = false)
    {
        //Debug.Log($"B19Panel.SetVals called - closing:{closing}");
        if (b19comp != null)
        {

            //fman.visibilityTiedToDetectability = visTiedToggle.isOn;
            b19comp.loadmodel.SetAndSave(b19_model_toggle.isOn);
            b19comp.level01.SetAndSave(b19_level1_toggle.isOn);
            b19comp.level02.SetAndSave(b19_level2_toggle.isOn);
            b19comp.level03.SetAndSave(b19_level3_toggle.isOn);
            b19comp.hvac.SetAndSave(b19_hvac_toggle.isOn);
            b19comp.floors.SetAndSave(b19_floors_toggle.isOn);
            b19comp.doors.SetAndSave(b19_doors_toggle.isOn);
            {
                var opts = b19comp.b19_materialMode.GetOptionsAsList();
                var newval = opts[b19_matmode_dropdown.value];
                //Debug.Log("Set toptextlabel default to " + newval);
                b19comp.b19_materialMode.SetAndSave(newval);
            }
        }

        var chg = false;
        chg = chg || bman.walllinks.SetAndSave(walllinks_toggle.isOn);
        chg = chg || bman.osmblds.SetAndSave(osmblds_toggle.isOn);
        chg = chg || bman.fixedblds.SetAndSave(fixedblds_toggle.isOn);
        Debug.Log($"B19Panel.SetVals walllinks:{walllinks_toggle.isOn} osmblds:{osmblds_toggle.isOn}  fixedblds:{fixedblds_toggle.isOn} chg:{chg}");

        sman.RequestRefresh("B19Panel-SetVals",totalrefresh:chg);
        panelActiveForRefreshChecks = false;

    }

    public void SetValsForRefresh()
    {
        if (b19comp == null) return;

        //Debug.Log("B19Panel SetVals2 called");
        //fman.visibilityTiedToDetectability = visTiedToggle.isOn;
        var chg = false;
        chg = chg || b19comp.loadmodel.SetAndSave(b19_model_toggle.isOn);
        chg = chg || b19comp.level01.SetAndSave(b19_level1_toggle.isOn);
        chg = chg || b19comp.level02.SetAndSave(b19_level2_toggle.isOn);
        chg = chg || b19comp.level03.SetAndSave(b19_level3_toggle.isOn);
        chg = chg || b19comp.hvac.SetAndSave(b19_hvac_toggle.isOn);
        chg = chg || b19comp.floors.SetAndSave(b19_floors_toggle.isOn);
        chg = chg || b19comp.doors.SetAndSave(b19_doors_toggle.isOn);
        {
            var opts = b19comp.b19_materialMode.GetOptionsAsList();
            var newval = opts[b19_matmode_dropdown.value];
            //Debug.Log("Set toptextlabel default to " + newval);
            chg = chg || b19comp.b19_materialMode.SetAndSave(newval);
        }

        chg = chg || bman.walllinks.SetAndSave(walllinks_toggle.isOn);
        chg = chg || bman.osmblds.SetAndSave(osmblds_toggle.isOn);
        chg = chg || bman.fixedblds.SetAndSave(fixedblds_toggle.isOn);
        Debug.Log($"B19Panel.SetVals2 bman.fixedblds.SetAndSave:{fixedblds_toggle.isOn}");


        //Debug.Log("SetVals2 t:" + Time.time + "   chg:" + chg);
        if (chg)
        {
            sman.RequestRefresh("B19Panel-SetVals");
        }
    }
    float lastcheck = 0;
    // Update is called once per frame
    void Update()
    {
        if (panelActiveForRefreshChecks)
        {
            if (Time.time-lastcheck>0.5f)
            {
                SetValsForRefresh();
                lastcheck = Time.time;
            }
        }
    }
}
