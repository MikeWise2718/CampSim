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
    public bool ApplySettings()
    {
        return true;
    }


    Dictionary<string, Toggle> togdict =null;

    public void DeleteTogs()
    {
        if (togdict != null)
        {
            foreach (var tog in togdict.Values)
            {
                Destroy(tog.gameObject);
            }
        }
        togdict = new Dictionary<string,Toggle>();
    }

    public void InitVals()
    {
        if (!uiResourcesInited)
        {
            uiResources = new DefaultControls.Resources();
            uiResources.background = uiman.GetSprite("Background");
            uiResources.checkmark = uiman.GetSprite("Checkmark");
            uiResourcesInited = true;
        }

        DeleteTogs();

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
            togdict[curRootOpt] = togcomp;
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
