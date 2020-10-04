using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;
using System.Collections.Generic;

public class UiConfigPanel : MonoBehaviour
{
    public SceneMan sman;
    UiMan uiman;

    Text scenarioNameText;

    Button closeButton;
    Button applyButton;
    GameObject ottcontent;
    GameObject tbtcontent;
    bool uiResourcesInited = false;
    DefaultControls.Resources uiResources;

    public void Init0()
    {
        LinkObjectsAndComponents();

        uiResources = new DefaultControls.Resources();
        uiResources.background = uiman.GetSprite("Background");
        uiResources.checkmark = uiman.GetSprite("Checkmark");
        uiResourcesInited = true;
    }

    public void LinkObjectsAndComponents()
    {
        sman = FindObjectOfType<SceneMan>();
        uiman = sman.uiman;

        scenarioNameText = transform.Find("ScenarioNameText").gameObject.GetComponent<Text>();

        ottcontent = transform.Find("OptionsTabConfigSettingsCanvas/Scroll View/Viewport/Content").gameObject;
        tbtcontent = transform.Find("TopButtonConfigSettingsCanvas/Scroll View/Viewport/Content").gameObject;

        applyButton = transform.Find("ApplyButton").gameObject.GetComponent<Button>();
        applyButton.onClick.AddListener(delegate { ApplySettings(); });
        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel();  });


    }
    Dictionary<string, Toggle> tbttogdict = null;
    public void ApplyTbtSettings()
    {
        var newTbtEnableString = "";
        foreach (var kname in tbttogdict.Keys)
        {
            var tog = tbttogdict[kname];
            if (tog.isOn)
            {
                if (newTbtEnableString != "")
                {
                    newTbtEnableString += ",";
                }
                newTbtEnableString += kname;
            }
        }
        sman.Lgg($"newTbtEnableString:{newTbtEnableString}", "orange");
        //uiman.optpan.enableString = newTbtEnableString;
        //uiman.ottpan.DestroyButtons();
        //uiman.optpan.MakeOptionsButtons();
    }

    Dictionary<string, Toggle> otttogdict = null;
    public bool ApplyOttSettings()
    {
        var newOttEnableString = "";
        foreach (var kname in otttogdict.Keys)
        {
            var tog = otttogdict[kname];
            if (tog.isOn)
            {
                if (newOttEnableString != "")
                {
                    newOttEnableString += ",";
                }
                newOttEnableString += kname;
            }
        }
        sman.Lgg($"newOttEnableString:{newOttEnableString}", "orange");
        uiman.optpan.enableString = newOttEnableString;
        uiman.ottpan.DestroyButtons();
        uiman.optpan.MakeOptionsButtons();
        return true;
    }


    public void ApplySettings()
    {
        ApplyOttSettings();
        ApplyTbtSettings();
    }


    public void DeleteOttTogs()
    {
        if (otttogdict != null)
        {
            foreach (var tog in otttogdict.Values)
            {
                Destroy(tog.gameObject);
            }
        }
        otttogdict = new Dictionary<string,Toggle>();
    }
    public void DeleteTbtTogs()
    {
        if (tbttogdict != null)
        {
            foreach (var tog in tbttogdict.Values)
            {
                Destroy(tog.gameObject);
            }
        }
        tbttogdict = new Dictionary<string, Toggle>();
    }

    public void InitVals()
    {


        DeleteOttTogs();
        DeleteTbtTogs();

        scenarioNameText.text = $"Current Scene:{sman.curscene}";
        var rootOptions = OptionsPanel.enableStringRoot;
        var curOptions = uiman.optpan.enableString;
        var togopts = rootOptions.Split(',');

        for (int i = 0; i < togopts.Length; i++)
        {
            var curRootOpt = togopts[i];
            var ison = curOptions.Contains(curRootOpt);
            var toggo = DefaultControls.CreateToggle(uiResources);
            var togcomp = toggo.GetComponentInChildren<Toggle>();
            togcomp.interactable = true;
            toggo.name = $"Toggle{i} {curRootOpt} initially on:{ison}";
            var togtext = toggo.GetComponentInChildren<Text>();
            if (togtext != null)
            {
                togtext.text = curRootOpt;
            }
            otttogdict[curRootOpt] = togcomp;
            togcomp.isOn = ison;
            toggo.transform.SetParent(ottcontent.transform, worldPositionStays: false);
        }
    }

    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
    }

    public void SetVals(bool closing = false)
    {
        Debug.Log($"UiConfig.SetVals called - closing:{closing}");

        //sman.RequestRefresh("UiConfig-SetVals");
    }


    //private void Update()
    //{
    //}

}
