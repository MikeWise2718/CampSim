using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;

public class GeneralPanel : MonoBehaviour
{
    public SceneMan sman;
    FrameMan fman;
    UiMan uiman;

    Toggle fastModeToggle;
    Toggle useDfInexesToggle;
    Toggle useDfLlCoordsToggle;

    Text SimpleDfIndexCountText;

    Button closeButton;

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

        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel();  });

    }
    public void InitVals()
    {
        Debug.Log("GeneralPanel InitVals called");
        fastModeToggle.isOn = sman.fastMode;
        useDfInexesToggle.isOn = sman.dfman.useDfIndexes.Get();
        useDfLlCoordsToggle.isOn = sman.dfman.useDfLlCoords.Get();
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
    }

    public void SetVals(bool closing = false)
    {
        Debug.Log($"GeneralPanel.SetVals called - closing:{closing}");
        sman.fastMode = fastModeToggle.isOn;
        sman.dfman.useDfIndexes.SetAndSave(useDfInexesToggle.isOn);
        sman.dfman.useDfLlCoords.SetAndSave(useDfLlCoordsToggle.isOn);

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
