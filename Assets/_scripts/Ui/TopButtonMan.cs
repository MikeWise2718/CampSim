using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;

namespace CampusSimulator
{

    public class TopButtonMan : MonoBehaviour
    {
        SceneMan sman;
        UiMan uiman;
        List<(Button, string, string)> createdButList = null;
        List<string> orderedButIdnames = null;
        Dictionary<string, (string, string, UnityAction)> butSpecList = null;


        public void Init(SceneMan sman)
        {
            this.sman = sman;
            uiman = sman.uiman;

            createdButList = new List<(Button, string, string)>();
            orderedButIdnames = new List<string>();
            butSpecList = new Dictionary<string, (string, string, UnityAction)>();
        }


        int lay_nbut;
        int lay_but_gap_x;
        int lay_but_gap_y;
        int lay_but_w;
        int lay_but_h;
        int lay_totalwid;
        int lay_but_x;
        int lay_but_y;


        public void InitializeLayout(string[] buttxtarr)
        {
            lay_nbut = buttxtarr.Length;
            lay_but_gap_x = 10;
            lay_but_gap_y = 0;
            lay_but_w = 110;
            lay_but_h = 40;
            lay_totalwid = lay_nbut * lay_but_w + (lay_nbut - 1) * lay_but_gap_x;

            lay_but_x = -lay_totalwid / 2;
            lay_but_y = 0;
        }


        public void MakeOneButton(Transform parent, OttLayout ottlayout, string idname, string displayname, string tooltiptext = "", UnityAction action = null)
        {
            var bgo = DefaultControls.CreateButton(new DefaultControls.Resources());
            bgo.name = idname + "Button";
            var butt = bgo.GetComponentInChildren<Button>();
            var btxt = bgo.GetComponentInChildren<Text>();
            btxt.text = displayname;
            btxt.fontSize = 18;
            var recttrans = butt.GetComponent<RectTransform>();
            var pos = new Vector3(lay_but_x, lay_but_y, 0);
            recttrans.SetPositionAndRotation(pos, Quaternion.identity);
            switch (ottlayout)
            {
                default:
                case OttLayout.stretchy:
                    recttrans.anchorMin = new Vector2(0.5f, 0);
                    recttrans.anchorMax = new Vector2(0.5f, 1);
                    recttrans.pivot = new Vector2(0.5f, 0.5f);
                    recttrans.sizeDelta = new Vector2(lay_but_w, 0);
                    break;
                case OttLayout.fixedheight:
                    recttrans.sizeDelta = new Vector2(lay_but_w, lay_but_h);
                    break;
            }
            bgo.transform.SetParent(parent, worldPositionStays: false);
            if (tooltiptext != "")
            {
                uiman.ttman.WireUpToolTip(bgo, displayname, tooltiptext);
            }
            if (action != null)
            {
                butt.onClick.AddListener(action);
            }
            createdButList.Add((butt, idname, displayname));
            lay_but_x += lay_but_w + lay_but_gap_x;
            lay_but_y += lay_but_gap_y;
        }

        public void SpecOneButton(string idname, string displayname, string tooltiptext, UnityAction action)
        {
            if (!butSpecList.ContainsKey(idname))
            {
                orderedButIdnames.Add(idname);
            }
            else
            {
                sman.LggWarning($"OptionsTabPanel.SpecOneButton - duplicate button spec:{idname}");
            }
            butSpecList[idname] = (displayname, tooltiptext, action);
        }

        public enum OttLayout { fixedheight, stretchy }

        public void CreateButtons(OttLayout ottlayout = OttLayout.stretchy)
        {
            InitializeLayout(butSpecList.Keys.ToArray());
            foreach (var idname in orderedButIdnames)
            {
                var (dname, ttname, action) = butSpecList[idname];
                MakeOneButton(transform, ottlayout, idname, dname, ttname, action);
            }
        }

        public void DeleteStuff()
        {
            DestroyButtons();
        }

        public void DestroyButtons()
        {
            foreach (var (but, _, _) in createdButList)
            {
                Destroy(but.gameObject);
            }
            createdButList = new List<(Button, string, string)>();
            orderedButIdnames = new List<string>();
            butSpecList = new Dictionary<string, (string, string, UnityAction)>();
        }

        //// Start is called before the first frame update
        //void Start()
        //{

        //}

        //// Update is called once per frame
        //void Update()
        //{

        //}
    }
}