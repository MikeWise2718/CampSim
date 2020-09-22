using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GraphAlgos;
using CampusSimulator;


public class LogPanel : MonoBehaviour
{
    public CampusSimulator.SceneMan sman;
    UiMan uiman;

    Text logTabText;
    Button copyClipboardButton;

    Button closeButton;


    public void Init0()
    {
        LinkObjectsAndComponents();
    }


    void LinkObjectsAndComponents()
    {
        uiman = sman.uiman;
        copyClipboardButton = transform.Find("ClipboardCopyButton").gameObject.GetComponent<Button>();
        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();

        closeButton.onClick.AddListener(delegate { uiman.ClosePanel(); });
        copyClipboardButton.onClick.AddListener(delegate { ButtonClick(copyClipboardButton.name); });

    }
    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
        //FillHelpPanel();
    }

    public string GetLogText()
    {
        var utc = System.DateTime.UtcNow;
        string msg = "Time Now: " + utc.ToString("yyyy-MM-dd HH:mm:ss UTC") + "\n";
        try
        {
            for(int i=0;i<10;i++)
            {
                msg += $"line-{i}\n";
            }
        }
        catch (Exception ex)
        {
            msg += "\n" + ex.Message;
            Debug.LogError("Error filling help text");
            Debug.LogError(ex.ToString());
        }
        return msg;
    }

    public List<string> GetLogTextAsList()
    {
        var msg = GetLogText();
        var rv = new List<string>(msg.Split('\n'));
        return rv;
    }

    public void FillLogPanel()
    {
        var arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        var consolas = Font.CreateDynamicFontFromOSFont("Consolas", 24);

        var font = arial;
        if (consolas != null)
        {
            font = consolas;
        }

        var go = GameObject.Find("LogTabText");
        logTabText = go.GetComponent<Text>();
        logTabText.font = font;
        logTabText.fontSize = 24;
        logTabText.alignment = TextAnchor.UpperLeft;
        logTabText.verticalOverflow = VerticalWrapMode.Overflow;
        var msg = GetLogText();
        logTabText.text = msg;
    }
    void ButtonClick(string buttonname)
    {
        Debug.Log($"{buttonname} clicked:" + Time.time);
        switch (buttonname)
        {
            case "ClipboardCopyButton":
                {
                    Debug.Log($"CopyText {logTabText.text.Length} chars");
                    Aiskwk.Map.qut.CopyTextToClipboard(logTabText.text);
                    break;
                }
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //}

}
