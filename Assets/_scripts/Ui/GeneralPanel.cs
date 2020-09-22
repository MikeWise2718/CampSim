using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;
using UnityEditor;
using System.Diagnostics.Eventing.Reader;

public class GeneralPanel : MonoBehaviour
{
    public SceneMan sman;
    FrameMan fman;
    UiMan uiman;

    Toggle fastModeToggle;
    Toggle useDfInexesToggle;
    Toggle useDfLlCoordsToggle;

    Text SimpleDfIndexCountText;

    InputField panCamOrientationInputField;
    InputField panCamMonitorsInputField;
    Text panCamValidationText;
    Text availableMonitorsText;

    Button closeButton;
    Button validationButton;

    public void Init0()
    {
        LinkObjectsAndComponents();
    }

    public void LinkObjectsAndComponents()
    {
        sman = FindObjectOfType<SceneMan>();
        uiman = sman.uiman;
        fman = sman.frman;

        fastModeToggle = transform.Find("FastModeToggle").gameObject.GetComponent<Toggle>();
        useDfInexesToggle = transform.Find("UseDataFileIndexesToggle").gameObject.GetComponent<Toggle>();
        useDfLlCoordsToggle = transform.Find("UseDataFileLlCoordsToggle").gameObject.GetComponent<Toggle>();
        SimpleDfIndexCountText = transform.Find("SimpleDfIndexCountText").gameObject.GetComponent<Text>();
        panCamOrientationInputField = transform.Find("PanCamOrientationInputField").gameObject.GetComponent<InputField>();
        panCamMonitorsInputField = transform.Find("PanCamMonitorsInputField").gameObject.GetComponent<InputField>();
        panCamValidationText = transform.Find("PanCamValidationText").gameObject.GetComponent<Text>();
        availableMonitorsText = transform.Find("AvailableMonitorsText").gameObject.GetComponent<Text>();

        validationButton = transform.Find("ValidationButton").gameObject.GetComponent<Button>();
        validationButton.onClick.AddListener(delegate { VerifyValues(); });
        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel();  });

    }
    int verifycount = 0;
    public bool VerifyValues()
    {
        var pcori = panCamOrientationInputField.text;
        string msg1, msg2;
        bool ok1, ok2;
        float amin, amax;
        List<int> mons;
        (ok1, msg1, amin, amax) = sman.vcman.ParseAndVeriyPanCamOrientationString(pcori);
        if (ok1)
        {
            msg1 = $"ok:  {amin:f1} : {amax:f1}";
            sman.vcman.panCamOrientation.SetAndSave(pcori);
        }
        var pcmon = panCamMonitorsInputField.text;
        (ok2, msg2, mons) = sman.vcman.ParseAndVeriyPanCamMonitorString(pcmon);
        if (ok2)
        {
            msg2 = "ok:  ";
            int i = 0;
            foreach(var m in mons)
            {
                if (i>0)
                {
                    msg2 += $": {m}";
                }
                else
                {
                    msg2 += $"{m}";
                }
                i++;
            }
            sman.vcman.panCamMonitors.SetAndSave(pcmon);
        }
        var msg = $"{msg1}\n{msg2}";
        panCamValidationText.text = msg;
        Debug.Log(msg);
        verifycount++;
        return true;
    }

    public void InitVals()
    {
        Debug.Log("GeneralPanel InitVals called");
        fastModeToggle.isOn = sman.fastMode;
        useDfInexesToggle.isOn = sman.dfman.useDfIndexes.Get();
        useDfLlCoordsToggle.isOn = sman.dfman.useDfLlCoords.Get();

        panCamOrientationInputField.text = sman.vcman.panCamOrientation.Get();
        panCamMonitorsInputField.text = sman.vcman.panCamMonitors.Get();
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
        SimpleDfIndexCountText.text = tx;

        var msg = $"Available Monitors:{Display.displays.Length}";
        for (int i = 0; i < Display.displays.Length; i++)
        {
            var dd = Display.displays[i];
            msg += $" \n  {i + 1}  native: {dd.systemWidth},{dd.systemHeight}";
            msg += $"   render: {dd.renderingWidth},{dd.renderingHeight}";
            msg += $"   active: {dd.active}";
        }
        availableMonitorsText.text = msg;
    }

    public void SetVals(bool closing = false)
    {
        Debug.Log($"GeneralPanel.SetVals called - closing:{closing}");
        sman.fastMode = fastModeToggle.isOn;
        sman.dfman.useDfIndexes.SetAndSave(useDfInexesToggle.isOn);
        sman.dfman.useDfLlCoords.SetAndSave(useDfLlCoordsToggle.isOn);

        sman.vcman.panCamOrientation.SetAndSave(panCamOrientationInputField.text);
        sman.vcman.panCamMonitors.SetAndSave(panCamMonitorsInputField.text);

        sman.RequestRefresh("GeneralPanel-SetVals");
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
