using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GraphAlgos;

public class HelpPanel : MonoBehaviour
{
    Text helpText;


    // Start is called before the first frame update
    void Start()
    {
        InitVals();
    }


    void LinkObjectsAndComponents()
    {
        var go = gameObject;
        var name = go.name;
        helpText = transform.Find("HelpText").GetComponent<Text>();
    }

    public void InitVals()
    {
    }



    public void FillHelpPanel()
    {
        if (helpText == null)
        {
            LinkObjectsAndComponents();
            InitVals();
        }

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
            msg += "\nCtrl-E            - Shift Camera position on viewer";
            msg += "\nCtrl-A            - Shift Camera position on viewer";
            msg += "\nCtrl-W            - Force Viewer to respond to keys";
            msg += "\\nnCtrl-C            - Interrupt bitmap loading";
            msg += "\n\nCtrl-Q Ctrl-Q   - Quit Application (hit ctrl-q twice)";
        }
        catch (Exception ex)
        {
            msg += "\n" + ex.Message;
        }
        helpText.text = msg;
        //Debug.Log("msg:" + msg);
    }


    // Update is called once per frame
    void Update()
    {
    }
}
