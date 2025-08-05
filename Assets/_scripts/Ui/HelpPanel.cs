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

    Text helpTabText;
    Button copyClipboardButton;

    Button closeButton;


    public void Init0()
    {
        LinkObjectsAndComponents();
    }


    void LinkObjectsAndComponents()
    {
        uiman = sman.uiman;
        //helpText = transform.Find("HelpText").GetComponent<Text>();
        copyClipboardButton = transform.Find("ClipboardCopyButton").gameObject.GetComponent<Button>();
        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();

        closeButton.onClick.AddListener(delegate { uiman.ClosePanel(); });
        copyClipboardButton.onClick.AddListener(delegate { ButtonClick(copyClipboardButton.name); });

    }
    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
        //FillHelpPanel();
    }

    public string GetHelpText()
    {
        var utc = System.DateTime.UtcNow;
        string msg = "Time Now: " + utc.ToString("yyyy-MM-dd HH:mm:ss UTC") + "\n";
        try
        {
#if UNITY_EDITOR
            msg += "\n" + "Ctrl-M Ctrl-M       - Copy scene camera to main camera (in Unity Editor only)";
            msg += "\n" + "Ctrl-M Ctrl-S       - Copy main camera to scene camera (in Unity Editor only)";
#endif
            msg += "\n" + "F2                  - Snap Viewer to nearest pipe-like path guide";
            msg += "\n" + "F4                  - Reverse Viewer Orientation";
            msg += "\n" + "F5                  - Total Refresh of Scene (can take ~10 secs)";
            msg += "\n" + "F8                  - Toggle Viewer panoramic camera";
            msg += "\n" + "F10                 - Options Panel";
            msg += "\n" + "Ctrl-E              - Shift Camera position on viewer";
            msg += "\n" + "Ctrl-A              - Shift Camera position on viewer";
            msg += "\n" + "Ctrl-W              - Force Viewer to respond to keys";
            msg += "\n" + "Ctrl-C              - Interrupt bitmap loading";
            msg += "\n\n" + "Ctrl-Q Ctrl-Q       - Quit Application (hit ctrl-q twice)";
            msg += "\n\n" + "Bugs/Requests/Info  - Contact: mwise@microsoft.com (Mike Wise)";
            msg += "\n" + "                               brujo@microsoft.com (Bruce E. Johnson)";
            var args = GraphAlgos.GraphUtil.GetArgs();

            msg += $"\n\nCommand line argument help:";
            msg += "\n" + "     -monitor n - Select Monitor n for display - see sysinfo for recognized displays";
            msg += "\n" + "     -scene scenespec - Select scene and run (scenespec list is in first visuals tab dropdown)";
            msg += "\n" + "     -run - Start the scene-wide people journey simulation";
            msg += "\n" + "     -fly - Start the scene-wide drone journey simulation";
            msg += "\n" + "     -nopipes- Don't show the pipe-like travel path markers";
            msg += "\n" + "     -pcori - Panoramic camera orientation in the form minang:maxangle like -45:45";
            msg += "\n" + "     -pcmon - Panoramic camera monitor usage - colon delimited monitor numbers like 1:2:3";
            msg += "\n" + "              Also implicitly determines number of panoramic cameras";
            msg += "\n" + "     -delsettings - Delete all saved application seettings and exit";
            msg += "\n" + "     -delmaps - Delete all saved map and elevation data and exit";
            msg += "\n" + "     -help - Write this help text and sysinfo to text (help.txt) file and exit";
            msg += $"\n\nCurrent Command line arguments:{args.Count}";
            for (int i = 0; i < args.Count; i++)
            {
                msg += $"\n   {i}:{args[i]}";
            }
        }
        catch (Exception ex)
        {
            msg += "\n" + ex.Message;
            sman.LggError("Error filling help text");
            sman.LggError(ex.ToString());
        }
        return msg;
    }

    public List<string> GetHelpTextAsList()
    {
        var msg = GetHelpText();
        var rv = new List<string>(msg.Split('\n'));
        return rv;
    }

    public void InitVals()
    {
        var arial = (Font)Resources.GetBuiltinResource(typeof(Font), "LegacyRuntime.ttf");
        var consolas = Font.CreateDynamicFontFromOSFont("Consolas", 24);

        var font = arial;
        if (consolas!=null)
        {
            font = consolas;
        }

        var go = GameObject.Find("HelpTabText");
        helpTabText = go.GetComponent<Text>();
        helpTabText.font = font;
        helpTabText.fontSize = 24;
        helpTabText.alignment = TextAnchor.UpperLeft;
        helpTabText.verticalOverflow = VerticalWrapMode.Overflow;
        var msg = GetHelpText();
        helpTabText.text = msg;
    }
    void ButtonClick(string buttonname)
    {
        Debug.Log($"{buttonname} clicked:" + Time.time);
        switch (buttonname)
        {
            case "ClipboardCopyButton":
                {
                    Debug.Log($"CopyText {helpTabText.text.Length} chars");
                    Aiskwk.Map.qut.CopyTextToClipboard(helpTabText.text);
                    break;
                }
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //}
}
