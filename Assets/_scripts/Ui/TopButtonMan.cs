using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;
using System.ComponentModel;
using System.Xml.Schema;

namespace CampusSimulator
{

    public class TopButtonMan : MonoBehaviour
    {
        SceneMan sman;
        UiMan uiman;
        List<(Button, string, string)> createdButList = null;
        List<string> orderedButIdnames = null;
        Dictionary<string,TopButSpec> butSpecList = null;
        List<string> filterList = null;


        public class TopButSpec
        {
            public string idname;
            public string dispname;
            public string ttname;
            public string xspec;
            public int xpos;
            public string yspec;
            public int ypos;
            public UnityAction action;
            public string filter;
            public TopButSpec(string idname,string dispname,string ttname,string xspec,int xpos,string yspec,int ypos,string filter)
            {
                this.idname = idname;
                this.dispname = dispname;
                this.ttname = ttname;
                this.xspec = xspec;
                this.xpos = xpos;
                this.yspec = yspec;
                this.ypos = ypos;
                this.filter = filter;
            }
        }

        public void Init(SceneMan sman)
        {
            this.sman = sman;
            uiman = sman.uiman;

            createdButList = new List<(Button, string, string)>();
            orderedButIdnames = new List<string>();
            butSpecList = new Dictionary<string, TopButSpec>();
            filterList = new List<string>();
        }

        public Button GetButton(string bname)
        {
            foreach(var (but,idname,_) in createdButList)
            {
                if (idname==bname)
                {
                    return but;
                }
            }
            return null;
        }

        //public void FindAndDestroy(string targetname)
        //{
        //    var trargo = transform.Find(targetname);
        //    if (trargo != null)
        //    {
        //       Destroy(trargo.gameObject);
        //    }
        //    else
        //    {
        //        sman.LggError($"FindAndDestroy Cannot find button {targetname}");
        //    }
        //}

        //string fixedDummyButtonList = "HideUiButton,RunButton,FlyButton,FrameButton,EvacButton,UnEvacButton,PipeButton,GoButton,OptionsButton,ShowTracksButton,FreeFlyButton,QuitButton," +
        //                               "FteButton,ConButton,VisButton,SecButton,UnkButton,Vt2DButton,TranButton,HvacButton,ElecButton,PlumButton";

        //public void DestroyFixedDummyButtonsOld()
        //{
        //    var farr = fixedDummyButtonList.Split(',');
        //    foreach (var f in farr)
        //    {
        //        FindAndDestroy(f);
        //    }
        //}

        public void DestroyFixedDummyButtons()
        {
            var butcoll = transform.GetComponentsInChildren<Button>();
            foreach (var but in butcoll)
            {
                Destroy(but.gameObject);
            }
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
            lay_but_w = 80;
            lay_but_h = 60;
            lay_totalwid = lay_nbut * lay_but_w + (lay_nbut - 1) * lay_but_gap_x;

            lay_but_x = -lay_totalwid / 2;
            lay_but_y = 0;
        }

        public bool IsInFilter(string fex)
        {
            foreach(var fentry in filterList)
            {
                if (fentry.Contains(fex))
                {
                    return true;
                }
            }
            return false;
        }

        public void MakeOneButton(Transform parent, TopButSpec tbs)
        {
            if (filterList.Count > 0)
            {
                if (!IsInFilter(tbs.filter))
                {
                    return;
                }
            }
            var bgo = DefaultControls.CreateButton(new DefaultControls.Resources());
            bgo.name = tbs.idname;
            var butt = bgo.GetComponentInChildren<Button>();
            var btxt = bgo.GetComponentInChildren<Text>();
            btxt.text = tbs.dispname+"*";
            btxt.fontSize = 28;
            var preflen = btxt.preferredWidth;
            btxt.text = tbs.dispname;
            var recttrans = butt.GetComponent<RectTransform>();
            lay_but_y = 30;
            var pos = new Vector3(lay_but_x, lay_but_y, 0);
            recttrans.SetPositionAndRotation(pos, Quaternion.identity);
            var txlen = tbs.dispname.Length;
            //if (txlen < 5) txlen = 5;
            var txwneed = (int) (preflen+1);
            var (a_xmin, a_xmax) = (0.5f, 0.5f);
            var (a_ymin, a_ymax) = (0.5f, 0.5f);
            var (s_x, s_y) = (lay_but_w, lay_but_h);
            var (p_x, p_y) = (tbs.xpos, tbs.ypos);
            var (szd_x, szd_y) = (recttrans.sizeDelta.x, recttrans.sizeDelta.y);
            switch (tbs.yspec)
            {
                case "stretch":
                    a_ymin = 0;
                    a_ymax = 1;
                    if (tbs.ypos > 0)
                    {
                        recttrans.offsetMin = new Vector2(recttrans.offsetMin.x, -8);
                        recttrans.offsetMax = new Vector2(recttrans.offsetMax.x, -8);
                    }
                    s_y = 0;
                    p_y = tbs.ypos;
                    break;
                case "cen":
                    a_ymin = 0.5f;
                    a_ymax = 0.5f; 
                    s_y = lay_but_h;
                    p_y = tbs.ypos;
                    break;
                case "top":
                    a_ymin = 0f;
                    a_ymax = 0f;
                    s_y = lay_but_h;
                    p_y = tbs.ypos;
                    break;
                case "bot":
                    a_ymin = 1f;
                    a_ymax = 1f;
                    s_y = lay_but_h;
                    p_y = tbs.xpos;
                    break;
            }
            switch (tbs.xspec)
            {
                case "stretch":
                    a_xmin = 0;
                    a_xmax = 1;
                    s_x = 0;
                    break;
                case "cen":
                    a_xmin = 0.5f;
                    a_xmax = 0.5f; 
                    s_x = txwneed;
                    p_x = tbs.xpos;
                    break;
                case "left":
                    a_xmin = 0f;
                    a_xmax = 0f;
                    s_x = txwneed;
                    p_x = tbs.xpos;
                    break;
                case "right":
                    a_xmin = 1f;
                    a_xmax = 1f;
                    s_x = txwneed;
                    p_x = tbs.xpos;
                    break;
            }
            recttrans.anchorMin = new Vector2(a_xmin, a_ymin);
            recttrans.anchorMax = new Vector2(a_xmax, a_ymax);
            recttrans.sizeDelta = new Vector2(s_x, s_y);
            recttrans.position = new Vector3(p_x, p_y, 0);
            if (tbs.ypos > 0)
            {
                recttrans.offsetMin = new Vector2(recttrans.offsetMin.x, tbs.ypos);
                recttrans.offsetMax = new Vector2(recttrans.offsetMax.x, -tbs.ypos);
            }
            else
            {
                recttrans.offsetMin = new Vector2(recttrans.offsetMin.x, 2);
                recttrans.offsetMax = new Vector2(recttrans.offsetMax.x, -2);
            }
            bgo.transform.SetParent(parent, worldPositionStays: false);
            if (tbs.ttname != "")
            {
                uiman.ttman.WireUpToolTip(bgo, tbs.dispname, tbs.ttname);
            }
            if (tbs.action != null)
            {
                butt.onClick.AddListener(tbs.action);
            }
            createdButList.Add((butt, tbs.idname, tbs.dispname));
            lay_but_x += lay_but_w + lay_but_gap_x;
            lay_but_y += lay_but_gap_y;
        }

        public void SpecOneButton(TopButSpec tbs)
        {
            if (!butSpecList.ContainsKey(tbs.idname))
            {
                orderedButIdnames.Add(tbs.idname);
            }
            else
            {
                sman.LggWarning($"OptionsTabPanel.SpecOneButton - duplicate button spec:{tbs.idname}");
            }
            butSpecList[tbs.idname] = tbs;
        }

        public enum OttLayout { fixedheight, stretchy }

        public void CreateButtons(OttLayout ottlayout = OttLayout.stretchy)
        {
            InitializeLayout(butSpecList.Keys.ToArray());
            foreach (var idname in orderedButIdnames)
            {
                var tbs = butSpecList[idname];
                MakeOneButton(transform,  tbs );
            }
        }

        public void DeleteStuff()
        {
            DestroyButtons();
            filterList = new List<string>();
        }

        public void DestroyButtons()
        {
            foreach (var (but, _, _) in createdButList)
            {
                Destroy(but.gameObject);
            }
            createdButList = new List<(Button, string, string)>();
            orderedButIdnames = new List<string>();
            butSpecList = new Dictionary<string,TopButSpec>();
        }
        public void SetTbtFilter(string tbtfilter)
        {
            filterList = new List<string>(tbtfilter.Split(','));
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