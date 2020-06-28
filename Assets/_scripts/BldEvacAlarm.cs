using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphAlgos;

namespace CampusSimulator
{
    public class BldEvacAlarm : MonoBehaviour
    {
        Building bld;
        Zone zone;
        Vector3 pos;

        bool inAlarm = false;

        public string inAlarmAldeboColor = "blue";
        public string inAlarmEmissiveColor = "blue";
        public static string outAlarmAldeboColor = "darkgray";
        public static string outAlarmEmissiveColor = "black";

        float startAlarmTime;
        float throbPeriod = 4.0f; // secs
        float colorThrobFak = 1.0f;
        float alarmDuration = 32f;// try and make a multiple of throb period


        public void Init(Zone zone,Vector3 pos)
        {
            this.zone = zone;
            this.pos = pos;
            MakeIntoAllClearAlarm();
        }
        public void Init(Building bld, Vector3 pos)
        {
            this.bld = bld;
            this.pos = pos;
            MakeIntoEvacAlarm();
        }
        public void ToggleBuildAlarm(bool justone)
        {
            if (bld == null) return;
            bld.SetAlarmState(!inAlarm, justone);
        }

        public void ToggleZoneAlarm(bool justone,bool startstream)
        {
            if (zone == null) return;
            zone.SetAlarmState(!inAlarm, justone,startstream);
        }

        public void SetState(bool newstate)
        {
            inAlarm = newstate;
            if (inAlarm)
            {
                startAlarmTime = Time.time;
            }
            colorThrobFak = 1.0f; // always reset throb to start
            SetColor();
        }
        public void MakeIntoEvacAlarm()
        {
            inAlarmAldeboColor = "red";
            inAlarmEmissiveColor = "red";
            SetColor();
        }

        public void MakeIntoAllClearAlarm()
        {
            inAlarmAldeboColor = "green";
            inAlarmEmissiveColor = "green";
            SetColor();
        }
        public void SetColor()
        {
            var albedocolor = inAlarm ? inAlarmAldeboColor : outAlarmAldeboColor;
            var emissivecolor = inAlarm ? inAlarmEmissiveColor : outAlarmEmissiveColor;
            //Debug.Log(name + " color to " + cclr);
            //GraphUtil.SetColorOfGo(this.gameObject,clr);
            var alclr = GraphUtil.GetColorByName(albedocolor);
            var emclr = GraphUtil.GetColorByName(emissivecolor);
            emclr = emclr * colorThrobFak;
            alclr = alclr * colorThrobFak;
            //Debug.Log("alclr:" + alclr + "  emclr:" + emclr);
            //eclrv = Color.Lerp(eclrv, Color.black, colorThrobFak);
            var mat = this.gameObject.GetComponent<Renderer>().material;
            mat.shader = Shader.Find("Diffuse");
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_Color", alclr);
            mat.SetColor("_EmissionColor", emclr);
        }
        public static GameObject GetGo(string name, Vector3 pos, float fsize)
        {
            var go = GraphAlgos.GraphUtil.CreateMarkerSphere(name, pos, clr: "gray", size: fsize);
            var clder = go.GetComponent<Collider>();
            if (clder != null)
            {
                clder.enabled = true;
            }
            return go;
        }

        private void Update()
        {
            if (inAlarm)
            {
                var elap = Time.time - startAlarmTime;
                colorThrobFak = Mathf.Cos(3.14159f*elap / throbPeriod);
                colorThrobFak *= colorThrobFak;
                SetColor();
                if (elap>alarmDuration)
                {
                    SetState(false);
                    SetColor();
                }
            }
        }
    }

}