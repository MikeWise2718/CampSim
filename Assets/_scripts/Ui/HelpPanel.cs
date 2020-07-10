using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GraphAlgos;
using CampusSimulator;

public class HelpPanel : MonoBehaviour
{
    public CampusSimulator.SceneMan sman;
    UiMan uiman;

    Text helpText;
    Button closeButton;


    public void Init0()
    {
        LinkObjectsAndComponents();
    }


    void LinkObjectsAndComponents()
    {
        uiman = sman.uiman;
        helpText = transform.Find("HelpText").GetComponent<Text>();
        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        closeButton.onClick.AddListener(delegate { uiman.ClosePanel(); });
    }
    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
        FillHelpPanel();
    }


    public void FillHelpPanel()
    {

        var sysver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        var utc = System.DateTime.UtcNow;
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        helpText.font = arial;
        helpText.fontSize = 24;
        helpText.alignment = TextAnchor.UpperLeft;
        helpText.verticalOverflow = VerticalWrapMode.Overflow;
        string msg = "Time Now: " + utc.ToString("yyyy-MM-dd HH:mm:ss UTC") + "\n";
        try
        {
#if UNITY_EDITOR
            msg += "\nCtrl-M Ctrl-M   - Copy scene camera to main camera (editor only)";
            msg += "\nCtrl-M Ctrl-S   - Copy main camera to scene camera (editor only)";
#endif
            msg += "\nF5                - Total Refresh of Scene";
            msg += "\nCtrl-E            - Shift Camera position on viewer";
            msg += "\nCtrl-A            - Shift Camera position on viewer";
            msg += "\nCtrl-W            - Force Viewer to respond to keys";
            msg += "\\nnCtrl-C          - Interrupt bitmap loading";
            msg += "\n\nCtrl-Q Ctrl-Q   - Quit Application (hit ctrl-q twice)";
        }
        catch (Exception ex)
        {
            msg += "\n" + ex.Message;
            Debug.LogError("Error filling help text");
            Debug.LogError(ex.ToString());
        }
        helpText.text = msg;
    }


    // Update is called once per frame
    //void Update()
    //{
    //}
}
