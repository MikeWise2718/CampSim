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

        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel();  });

    }
    public void InitVals()
    {
        Debug.Log("GeneralPanel InitVals called");
        if (fastModeToggle != null)
        {
            fastModeToggle.isOn = sman.fastMode;
        }
    }

    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
    }


    public void SetVals(bool closing = false)
    {
        Debug.Log($"GeneralPanel.SetVals called - closing:{closing}");
        sman.fastMode = fastModeToggle.isOn;
        sman.dfman.useDfIndexes.SetAndSave(useDfInexesToggle.isOn);

        sman.RequestRefresh("GeneralPanel-SetVals");
    }

}
