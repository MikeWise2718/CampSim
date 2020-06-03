using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CampusSimulator;

public class GeneralPanel : MonoBehaviour
{

    Toggle fastModeToggle;
    bool oldFastMode;
    Text fastModeText;


    SceneMan sman;
    FrameMan fman;

    bool panelActive = false;

    void Start()
    {
        panelActive = false;
        LinkObjectsAndComponents();
    }

    public void LinkObjectsAndComponents()
    {
        sman = FindObjectOfType<SceneMan>();
        if (sman == null)
        {
            throw new UnityException("General panel could not find RegionMan");
        }
        fman = FindObjectOfType<FrameMan>();

        if (fman == null)
        {
            Debug.Log("lman null");
        }
        {
            var go = transform.Find("FastModeToggle").gameObject;
            fastModeToggle = go.GetComponent<Toggle>();
        }

        panelActive = true;
    }
    public void InitVals()
    {
        Debug.Log("GeneralPanel InitVals called");
        if (fastModeToggle != null)
        {
            fastModeToggle.isOn = sman.fastMode;
        }
        panelActive = true;
    }

    int nSetTextValuesCalled = 0;
    private void SetTextValues()
    {
        nSetTextValuesCalled += 1;
    }


    public void SetVals(bool closing = false)
    {
        Debug.Log($"GeneralPanel.SetVals called - closing:{closing}");
        sman.fastMode = fastModeToggle.isOn;
        panelActive = false;
        sman.RequestRefresh("GeneralPanel-SetVals");
    }

    // Update is called once per frame
    void Update()
    {
        if (panelActive)
        {
        }
    }
}
