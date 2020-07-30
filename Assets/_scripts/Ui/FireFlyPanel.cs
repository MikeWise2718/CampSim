using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;

public class FireFlyPanel : MonoBehaviour
{
    public SceneMan sman;
    FrameMan fman;
    MapMan mman;
    JourneyMan jman;
    UiMan uiman;

    Toggle fastModeToggle;
    Toggle useDfInexesToggle;

    Dropdown viewerJourneyStartDropdown;
    Dropdown viewerJourneyEndDropdown;
    Text fireFlyDfText;

    InputField scaleNumberField;

    Button startJourney;
    Button closeButton;

    public void Init0()
    {
        LinkObjectsAndComponents();
    }

    public void LinkObjectsAndComponents()
    {
        uiman = sman.uiman;
        fman = sman.frman;
        jman = sman.jnman;
        mman = sman.mpman;


        fastModeToggle = transform.Find("FastModeToggle").gameObject.GetComponent<Toggle>();
        useDfInexesToggle = transform.Find("UseDataFileIndexesToggle").gameObject.GetComponent<Toggle>();

        viewerJourneyStartDropdown = transform.Find("ViewerJourneyStartDropdown").gameObject.GetComponent<Dropdown>();
        viewerJourneyEndDropdown = transform.Find("ViewerJourneyEndDropdown").gameObject.GetComponent<Dropdown>();

        scaleNumberField = transform.Find("ScaleNumberField").gameObject.GetComponent<InputField>();

        startJourney = transform.Find("StartJourneyButton").gameObject.GetComponent<Button>();
        startJourney.onClick.AddListener(delegate { StartJourney();  });

        fireFlyDfText = transform.Find("FireFlyDfText").gameObject.GetComponent<Text>();


        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel(); });

    }
    public void InitVals()
    {
        Debug.Log("FireFlyPanel InitVals called");
        if (fastModeToggle != null)
        {
            fastModeToggle.isOn = sman.fastMode;
        }

        var opts = new List<string>(jman.GetJourneyNodes());
        var errmsg = "Error in FireFlyPanel.InitVals-";
        try
        {
            var inival = jman.lastViewerStartJourney.Get();
            //Debug.Log($"InitVals get:{inival}");
            var idx = opts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;
            viewerJourneyStartDropdown.ClearOptions();
            viewerJourneyStartDropdown.AddOptions(opts);
            viewerJourneyStartDropdown.value = idx;
        }
        catch (Exception ex)
        {
            Debug.LogError($"{errmsg}1:{ex.Message}");
        }

        try
        {
            var inival = jman.lastViewerEndJourney.Get();
            //Debug.Log($"InitVals get:{inival}");
            var idx = opts.FindIndex(s => s == inival);
            if (idx <= 0) idx = 0;
            viewerJourneyEndDropdown.ClearOptions();
            viewerJourneyEndDropdown.AddOptions(opts);
            viewerJourneyEndDropdown.value = idx;
        }
        catch (Exception ex)
        {
            Debug.LogError($"{errmsg}1:{ex.Message}");
        }

        var scaleval = sman.stman.scalemodelnumber.Get();
        //Debug.Log($"InitVals get:{inival}");
        scaleNumberField.text = scaleval.ToString("f1");
    }

    public void StartJourney()
    {
        var nodes = jman.GetJourneyNodes();
        var sidx = viewerJourneyStartDropdown.value;
        var snode = nodes[sidx];
        var eidx = viewerJourneyEndDropdown.value;
        var enode = nodes[eidx];
        var sar = snode.Split('_');
        var sname = sar[0];
        var st = sman.stman.GetStreet(sname);
        if (st!=null)
        {
            //var jsnode = sname + "_start";
            //var jenode = sname + "_end";
            jman.StartViewerJourney(snode, enode,captype:st.captyp,ava:st.avaname);

        }
        else
        {
            Debug.LogError($"Cound not find street");
        }
        //jman.StartViewerJourney(snode, enode);
    }

    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
    }
    public void UpdateText()
    {
        var tx = "";
        var dfman = sman.dfman;
        var (rv1, rv2, rv3) = dfman.GetIndexCounts();
        tx = $"SimpleDf Index Counts - Ways:{rv1} Links:{rv2} Nodes:{rv3}";
        fireFlyDfText.text = tx;
    }

    public void SetVals(bool closing = false)
    {
        Debug.Log($"FireFlyPanel.SetVals called - closing:{closing}");
        var chg = false;

        //Debug.Log($"InitVals get:{inival}");
        var scalevaltxt = scaleNumberField.text;
        float val = sman.stman.scalemodelnumber.Get();
        string msg;
        var ok = float.TryParse(scalevaltxt, out val);
        if (ok)
        {
            chg = chg || (val != sman.stman.scalemodelnumber.Get());
            sman.stman.scalemodelnumber.SetAndSave(val);
            Debug.Log($"FireFlyPanel.SetVal set scalemodenumber to {val}");
        }
        else
        {
            msg = $"FireFlyPanel.SetVal ScaleNumberField format error scalevaltxt:{scalevaltxt}";
            Debug.LogError(msg);
        }
        if (chg)
        {
            sman.RequestRefresh("FireFlyPanel-SetVals");
        }
    }

    float checkInterval = 1f;
    float lastCheck = 0;

    private void Update()
    {
        if (Time.time-lastCheck>checkInterval)
        {
            UpdateText();
            lastCheck = Time.time;
        }
    }

}
