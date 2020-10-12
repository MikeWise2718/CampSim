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
    DefaultControls.Resources uiResources;

    public void Init0()
    {
        LinkObjectsAndComponents();

        uiResources = new DefaultControls.Resources();
        uiResources.background = uiman.GetSprite("Background");
        uiResources.checkmark = uiman.GetSprite("Checkmark");
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
    int togalloc = 0;
    Dictionary<string, Toggle> tbttogdict = null;
    public void ApplyTbtSettings()
    {
        var newTbtEnableString = "";
        foreach (var kname in tbttogdict.Keys)
        {
            var tog = tbttogdict[kname];
            sman.Lgg($"     {kname} {tog.name} isOn:{tog.isOn}", "orange");
            if (tog.isOn)
            {
                if (newTbtEnableString != "")
                {
                    newTbtEnableString += ",";
                }
                newTbtEnableString += kname;
            }
        }
        //sman.Lgg($"newTbtEnableString:{newTbtEnableString}", "orange");
        uiman.tbtpan.tbpfiltlist = newTbtEnableString;
        uiman.optpan.topButtonStringSetting.SetAndSave(newTbtEnableString);
        uiman.tbtpan.DestroyButtons();
        uiman.tbtpan.CreateButtonsAnew(newTbtEnableString);
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
        sman.Lgg($"newOttEnableString:{newOttEnableString}", "purple");
        uiman.optpan.enableString = newOttEnableString;
        uiman.optpan.enableStringSetting.SetAndSave(newOttEnableString);
        uiman.ottpan.DestroyButtons();
        uiman.optpan.MakeOptionsButtons();
        return true;
    }

    public void ApplySettings()
    {
        ApplyTbtSettings();
        ApplyOttSettings();// has to happen after ApplyTbtSettings since newOttEnableString needs to be set
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

    public void SetupLayout(GameObject content)
    {
        var layout = content.GetComponent<VerticalLayoutGroup>();
        if (layout==null)
        {
            sman.LggError($"UiConfigPanel could not find VerticalLayoutGroup");
            return;
        }
        layout.childControlHeight = false;
        layout.childControlWidth = false;
        layout.childForceExpandHeight = true;
        layout.childForceExpandWidth = true;
        layout.childScaleHeight = false;
        layout.childScaleWidth = false;
        layout.childAlignment = TextAnchor.UpperLeft;
        layout.padding.left = 0;
        layout.padding.right = 0;
        layout.padding.top = 0;
        layout.padding.bottom = 0;
        layout.spacing = 12; 


        var contentsizefitter = content.GetComponent<ContentSizeFitter>();
        if (contentsizefitter == null)
        {
            sman.LggError($"UiConfigPanel could not find ContentSizeFitter");
            return;
        }
        contentsizefitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        contentsizefitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
    }

    public void InitOttVals()
    {
        SetupLayout(ottcontent);
        DeleteOttTogs();
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
            toggo.name = $"Toggle{togalloc++} {curRootOpt} initially on:{ison}";
            var togtext = toggo.GetComponentInChildren<Text>();
            var tooltip = uiman.optpan.GetToolTip(curRootOpt);
            if (togtext != null)
            {
                togtext.text = $"{curRootOpt} - {tooltip}";
                togtext.fontSize = 22;// default 14 
                togtext.horizontalOverflow = HorizontalWrapMode.Overflow;
                togtext.verticalOverflow = VerticalWrapMode.Overflow;
            }
            otttogdict[curRootOpt] = togcomp;
            togcomp.isOn = ison;
            toggo.transform.SetParent(ottcontent.transform, worldPositionStays: false);
            if (tooltip != "")
            {
                uiman.ttman.WireUpToolTip(toggo, curRootOpt, tooltip);
            }
        }
    }


    public void InitTbtVals()
    {
        SetupLayout(tbtcontent);
        DeleteTbtTogs();
        var rootOptions = TopButtonPanel.tbprootfiltlist;
        var curOptions = uiman.tbtpan.tbpfiltlist;
        var togopts = rootOptions.Split(',');

        for (int i = 0; i < togopts.Length; i++)
        {
            var curRootOpt = togopts[i];
            var ison = curOptions.Contains(curRootOpt);
            var toggo = DefaultControls.CreateToggle(uiResources);
            var togcomp = toggo.GetComponentInChildren<Toggle>();
            togcomp.interactable = true;
            toggo.name = $"Toggle{togalloc++} {curRootOpt} initially on:{ison}";
            var togtext = toggo.GetComponentInChildren<Text>();
            var tooltip = uiman.tbtpan.GetTbtClassToolTip(curRootOpt);
            if (togtext != null)
            {
                togtext.text = $"{curRootOpt} - {tooltip}";
                togtext.fontSize = 22;// default 14 
                togtext.horizontalOverflow = HorizontalWrapMode.Overflow;
                togtext.verticalOverflow = VerticalWrapMode.Overflow;
            }
            tbttogdict[curRootOpt] = togcomp;
            togcomp.isOn = ison;
            toggo.transform.SetParent(tbtcontent.transform, worldPositionStays: false);
            if (tooltip != "")
            {
                uiman.ttman.WireUpToolTip(toggo, curRootOpt, tooltip);
            }
        }
    }


    public void InitVals()
    {
        scenarioNameText.text = $"Current Scene:{sman.curscene}";
        InitOttVals();
        InitTbtVals();
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
