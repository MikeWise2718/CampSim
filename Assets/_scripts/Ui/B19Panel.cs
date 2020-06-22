using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;

public class B19Panel : MonoBehaviour
{
    public SceneMan sman;
    UiMan uiman;

    Toggle b19_model;
    Toggle b19_level1;
    Toggle b19_level2;
    Toggle b19_level3;
    Toggle b19_hvac;
    Toggle b19_floors;
    Toggle b19_doors;
    Dropdown b19_matmode;
    Button closeButton;

    BuildingMan bman;
    B19Willow b19comp;

    bool panelActive = false;

    public void Init0()
    {
        bman = sman.bdman;
        uiman = sman.uiman;
        b19_model = transform.Find("B19Model").GetComponent<Toggle>();
        b19_level1 = transform.Find("Level1").GetComponent<Toggle>();
        b19_level2 = transform.Find("Level2").GetComponent<Toggle>();
        b19_level3 = transform.Find("Level3").GetComponent<Toggle>();
        b19_hvac = transform.Find("HVAC").GetComponent<Toggle>();
        b19_floors = transform.Find("Floors").GetComponent<Toggle>();
        b19_doors = transform.Find("Doors").GetComponent<Toggle>();
        b19_matmode = transform.Find("MaterialMode").GetComponent<Dropdown>();

        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel(); });
    }

    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
        InitVals();
    }


    public void EnableComponents(bool state)
    {
        b19_model.enabled = state;
        b19_level1.enabled = state;
        b19_level2.enabled = state;
        b19_level3.enabled = state;
        b19_hvac.enabled = state;
        b19_floors.enabled = state;
        b19_doors.enabled = state;
    }


    public void InitVals()
    {
        b19comp = null;
        var bld = bman?.GetBuilding("Bld19");
        if (bld != null)
        {
            b19comp = bld.GetComponent<B19Willow>();
            if (b19comp==null)
            {
                Debug.LogWarning("B19 Panel could not find B19Willow component that it needs to operate");
            }
        }
        else
        {
            Debug.LogWarning("B19 Panel can not find Bld19 in bman");
        }
        if (b19comp == null)
        {
            EnableComponents(false);
            b19_model.isOn = false;
            b19_level1.isOn = false;
            b19_level2.isOn = false;
            b19_level3.isOn = false;
            b19_hvac.isOn = false;
            b19_floors.isOn = false;
            b19_doors.isOn = false;

            b19_matmode.ClearOptions();
        }
        else
        {
            EnableComponents(true);
            b19_model.isOn = b19comp.loadmodel.Get();
            b19_level1.isOn = b19comp.level01.Get();
            b19_level2.isOn = b19comp.level02.Get();
            b19_level3.isOn = b19comp.level03.Get();
            b19_hvac.isOn = b19comp.hvac.Get();
            b19_floors.isOn = b19comp.floors.Get();
            b19_doors.isOn = b19comp.doors.Get();

            {
                var opts = b19comp.b19_materialMode.GetOptionsAsList();
                var inival = b19comp.b19_materialMode.Get().ToString();
                var idx = opts.FindIndex(s => s == inival);
                if (idx <= 0) idx = 0;
                b19_matmode.ClearOptions();
                b19_matmode.AddOptions(opts);
                //Debug.Log("MatMode add options n:" + opts.Count);
                b19_matmode.value = idx;
            }
            //visTiedToggle.isOn = fman.visibilityTiedToDetectability;
        }
        panelActive = true;
    }


    public void SetVals(bool closing = false)
    {
        //Debug.Log($"B19Panel.SetVals called - closing:{closing}");
        if (b19comp == null) return;

        //fman.visibilityTiedToDetectability = visTiedToggle.isOn;
        b19comp.loadmodel.SetAndSave( b19_model.isOn );
        b19comp.level01.SetAndSave(b19_level1.isOn);
        b19comp.level02.SetAndSave(b19_level2.isOn);
        b19comp.level03.SetAndSave(b19_level3.isOn);
        b19comp.hvac.SetAndSave(b19_hvac.isOn);
        b19comp.floors.SetAndSave(b19_floors.isOn);
        b19comp.doors.SetAndSave(b19_doors.isOn);
        {
            var opts = b19comp.b19_materialMode.GetOptionsAsList();
            var newval = opts[b19_matmode.value];
            //Debug.Log("Set toptextlabel default to " + newval);
            b19comp.b19_materialMode.SetAndSave(newval);
        }

        panelActive = false;
        sman.RequestRefresh("B19Panel-SetVals");
    }

    public void SetVals2()
    {
        if (b19comp == null) return;

        //Debug.Log("B19Panel SetVals2 called");
        //fman.visibilityTiedToDetectability = visTiedToggle.isOn;
        var chg = false;
        chg = chg || b19comp.loadmodel.SetAndSave(b19_model.isOn);
        chg = chg || b19comp.level01.SetAndSave(b19_level1.isOn);
        chg = chg || b19comp.level02.SetAndSave(b19_level2.isOn);
        chg = chg || b19comp.level03.SetAndSave(b19_level3.isOn);
        chg = chg || b19comp.hvac.SetAndSave(b19_hvac.isOn);
        chg = chg || b19comp.floors.SetAndSave(b19_floors.isOn);
        chg = chg || b19comp.doors.SetAndSave(b19_doors.isOn);
        {
            var opts = b19comp.b19_materialMode.GetOptionsAsList();
            var newval = opts[b19_matmode.value];
            //Debug.Log("Set toptextlabel default to " + newval);
            chg = chg || b19comp.b19_materialMode.SetAndSave(newval);
        }
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
        if (panelActive)
        {
            if (Time.time-lastcheck>0.5f)
            {
                SetVals2();
                lastcheck = Time.time;
            }
        }
    }
}
