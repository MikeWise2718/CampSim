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
    bool oldFastMode;
    Text fastModeText;

    Button closeButton;

    bool panelActive = false;

    public void Init0()
    {
        panelActive = false;
        LinkObjectsAndComponents();
    }

    public void LinkObjectsAndComponents()
    {
        sman = FindObjectOfType<SceneMan>();
        uiman = sman.uiman;
        fman = sman.frman;

        fastModeToggle = transform.Find("FastModeToggle").gameObject.GetComponent<Toggle>();

        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel();  });

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

    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
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

}
