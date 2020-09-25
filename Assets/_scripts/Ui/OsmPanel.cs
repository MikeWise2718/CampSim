using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;
using UnityEditor;
using System.Diagnostics.Eventing.Reader;

public class OsmPanel : MonoBehaviour
{
    public SceneMan sman;
    FrameMan fman;
    UiMan uiman;

    InputField scenarioNameInputField;
    Text scenarioNameText;

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

        scenarioNameInputField = transform.Find("ScenarioNameInputField").gameObject.GetComponent<InputField>();
        scenarioNameText = transform.Find("ScenarioNameText").gameObject.GetComponent<Text>();


        validationButton = transform.Find("ValidationButton").gameObject.GetComponent<Button>();
        validationButton.onClick.AddListener(delegate { VerifyValues(); });
        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel();  });

    }
    public bool VerifyValues()
    {
        return true;
    }

    public void InitVals()
    {
        Debug.Log("OsmPanel InitVals called");
    }

    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
    }
    public void UpdateText()
    {
    }

    public void SetVals(bool closing = false)
    {
        Debug.Log($"Osm.SetVals called - closing:{closing}");

        //sman.RequestRefresh("OsmPanel-SetVals");
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
