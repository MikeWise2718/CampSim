using System;
using System.Collections.Generic;
using UnityEngine;

public enum LogSeverity { Error, Warning, Info, Verbose, Debug }
public enum LogTyp { General, GraphCtrl, Qmesh, Polygon, Refresh }

public class LogEntry
{
    public DateTime time;
    public float unitytime;
    public LogSeverity severity;
    public LogTyp typ;
    public string msg;
    public string[] colorar;
    public LogEntry(string lmsg, LogSeverity lseverity = LogSeverity.Info, LogTyp ltyp = LogTyp.General, string lcolors = "")
    {
        time = DateTime.Now;
        unitytime = Time.time;
        msg = lmsg;
        severity = lseverity;
        typ = ltyp;
        colorar = lcolors.Split(',');
    }
}
public class LogMan : MonoBehaviour
{
    List<LogEntry> messages;

    public void InitPhase0()
    {
        messages = new List<LogEntry>();
    }

    public static string ColorCode(string msg, string[] color, string delim = "|")
    {
        if (color.Length == 0)
        {
            return msg;
        }
        var delimIdxes = new List<int>();
        {
            var idx = msg.IndexOf(delim);
            while (idx >= 0)
            {
                delimIdxes.Add(idx);
                idx = msg.IndexOf(delim, idx + 1);
            }
        }
        var iclr = 0;
        var hclr0 = GraphAlgos.GraphUtil.GetHexColorByName(color[0]);
        var nmsg = $"<color={hclr0}>";
        var sidx = nmsg.Length;
        nmsg += msg;
        var lidx = 0;
        foreach (var idx in delimIdxes)
        {
            iclr = (iclr + 1) % color.Length;
            var hclr = GraphAlgos.GraphUtil.GetHexColorByName(color[iclr]);
            var isrt = $"</color><color={hclr}>";
            sidx += idx - lidx;
            nmsg = nmsg.Remove(sidx, delim.Length);// remove the delim
            nmsg = nmsg.Insert(sidx, isrt);
            sidx += isrt.Length - delim.Length;
            lidx = idx;
        }
        nmsg += "</color>";
        return nmsg;
    }

    public void AddMessage(string msg, LogSeverity severity = LogSeverity.Info, LogTyp typ = LogTyp.General, string colors = "")
    {
        var nmsg = new LogEntry(msg, severity, typ, colors);
        messages.Add(nmsg);
    }

    public void AddMessage(string msg, LogSeverity severity = LogSeverity.Info, LogTyp typ = LogTyp.General, string[] colors = null)
    {
        var colorstring = "";
        if (colors != null)
        {
            for (int i = 0; i < colors.Length; i++)
            {
                if (i > 0) colorstring += ",";
                colorstring += colors[i];

            }
        }
        var nmsg = new LogEntry(msg, severity, typ, colorstring);
        messages.Add(nmsg);
    }

    public List<string> GetCodedLogMessages()
    {
        var rv = new List<string>();
        foreach (var msg in messages)
        {
            var ccmsg = LogMan.ColorCode(msg.msg, msg.colorar);
            rv.Add(ccmsg);
        }
        return rv;
    }

    public void UnityLog(string nmsg, LogSeverity severity)
    {
        switch (severity)
        {
            case LogSeverity.Error:
                Debug.LogError(nmsg);
                break;
            case LogSeverity.Warning:
                Debug.LogWarning(nmsg);
                break;
            default:
                Debug.Log(nmsg);
                break;
        }
    }
    public void Lgglong(string msg, LogSeverity severity = LogSeverity.Info, LogTyp typ = LogTyp.General, string[] color = null, string delim = "|", bool unitylog = true)
    {
        AddMessage(msg, severity, typ, color);
        var nmsg = LogMan.ColorCode(msg, color, delim);
        if (unitylog)
        {
            UnityLog(nmsg, severity);
        }
    }

    public void Lgg(string msg, string color = "gray")
    {
        Lgglong(msg, LogSeverity.Info, LogTyp.GraphCtrl, color: new string[] { color });
    }

    public void SetScene()
    {

    }
    // Start is called before the first frame update

    void Start()
    {
    }


}

