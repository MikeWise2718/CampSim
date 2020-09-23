using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace CampusSimulator
{
    public enum LogSeverity { Error,Warning,Info,Verbose,Debug}
    public enum LogTyp { General,Refresh }

    public class LogEntry
    {
        public DateTime time;
        public float unitytime;
        public LogSeverity severity;
        public LogTyp typ;
        public string msg;
        public string [] colorar;
        public LogEntry(string lmsg, LogSeverity lseverity = LogSeverity.Info, LogTyp ltyp = LogTyp.General,string lcolors="")
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
        public SceneMan sman;

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
            var nmsg = $"<color={color[0]}>";
            var sidx = nmsg.Length;
            nmsg += msg;
            var lidx = 0;
            foreach (var idx in delimIdxes)
            {
                iclr = (iclr + 1) % color.Length;
                var isrt = $"</color><color={color[iclr]}>";
                sidx += idx - lidx;
                nmsg = nmsg.Remove(sidx, delim.Length);// remove the delim
                nmsg = nmsg.Insert(sidx, isrt);
                sidx += isrt.Length - delim.Length;
                lidx = idx;
            }
            nmsg += "</color>";
            return nmsg;
        }

        public void AddMessage(string msg,LogSeverity severity=LogSeverity.Info,LogTyp typ=LogTyp.General,string colors="")
        {
            var nmsg = new LogEntry(msg, severity, typ, colors);
            messages.Add(nmsg);
        }

        public void AddMessage(string msg, LogSeverity severity = LogSeverity.Info, LogTyp typ = LogTyp.General, string [] colors=null)
        {
            var colorstring = "";
            if (colors!=null)
            {
                for(int i=0; i<colors.Length; i++)
                {
                    if (i > 0) colorstring += ",";
                    colorstring += colors[i];

                }
            }
            var nmsg = new LogEntry(msg, severity, typ, colorstring );
            messages.Add(nmsg);
        }

        public List<string> GetCodedLogMessages()
        {
            var rv = new List<string>();
            foreach(var msg in messages)
            {
                var ccmsg = LogMan.ColorCode(msg.msg,msg.colorar);
                rv.Add(ccmsg);
            }
            return rv;
        }


        public void SetScene()
        {

        }
        // Start is called before the first frame update

        void Start()
        {
        }

        // Update is called once per frame
        //void Update()
        //{

        //}
    }
}

