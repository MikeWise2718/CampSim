﻿using UnityEngine;
using UnityEngine.UI;

namespace CampusSimulator
{

    public class UiMan : MonoBehaviour
    {
        public SceneMan sman;
        // Start is called before the first frame update

        public GameObject uigo;
        public OptionsPanel optpan;
        public OptionsTabPanel ottpan;
        public InfoPanel infpan;
        public TopButtonPanel tbtpan;

        public VisualsPanel vispan;
        public MapSetPanel mappan;
        public GeneralPanel genpan;
        public FireFlyPanel flypan;
        public FramePanel frapan;
        public BuildingsPanel bldpan;
        public OsmPanel osmpan;
        public UiConfigPanel uiconpan;
        public LogPanel logpan;
        public HelpPanel helpan;
        public AboutPanel abtpan;

        public ToolTipMan ttman;

        public int ui_w;
        public int ui_h;

        public bool listenForKeys = false;

        public void InitPhase0()
        {
            ui_w = Screen.width;
            ui_h = Screen.height;

            var ttgo = new GameObject("tooltipman");
            ttman = ttgo.AddComponent<ToolTipMan>();

            uigo = transform.Find("UiRootCanvas").gameObject;// works even for non-active children
            uigo.SetActive(true);
            // not strictly necessary but keeps things sane
            var tr = uigo.GetComponent<RectTransform>();
            tr.position = new Vector3(ui_w / 2, ui_h / 2, 0);
            tr.sizeDelta = new Vector2(ui_w, ui_h);

            optpan = Resources.FindObjectsOfTypeAll<OptionsPanel>()[0];
            ottpan = Resources.FindObjectsOfTypeAll<OptionsTabPanel>()[0];
            tbtpan = Resources.FindObjectsOfTypeAll<TopButtonPanel>()[0];
            infpan = Resources.FindObjectsOfTypeAll<InfoPanel>()[0];

            vispan = Resources.FindObjectsOfTypeAll<VisualsPanel>()[0];
            mappan = Resources.FindObjectsOfTypeAll<MapSetPanel>()[0];
            genpan = Resources.FindObjectsOfTypeAll<GeneralPanel>()[0];
            frapan = Resources.FindObjectsOfTypeAll<FramePanel>()[0];
            flypan = Resources.FindObjectsOfTypeAll<FireFlyPanel>()[0];
            bldpan = Resources.FindObjectsOfTypeAll<BuildingsPanel>()[0];
            osmpan = Resources.FindObjectsOfTypeAll<OsmPanel>()[0];
            uiconpan = Resources.FindObjectsOfTypeAll<UiConfigPanel>()[0];
            logpan = Resources.FindObjectsOfTypeAll<LogPanel>()[0];
            helpan = Resources.FindObjectsOfTypeAll<HelpPanel>()[0];
            abtpan = Resources.FindObjectsOfTypeAll<AboutPanel>()[0];

            ttman.sman = sman;
            optpan.sman = sman;
            ottpan.sman = sman;
            tbtpan.sman = sman;
            infpan.sman = sman;
            logpan.sman = sman;

            vispan.sman = sman;
            mappan.sman = sman;
            genpan.sman = sman;
            frapan.sman = sman;
            bldpan.sman = sman;
            osmpan.sman = sman;
            uiconpan.sman = sman;
            helpan.sman = sman;
            abtpan.sman = sman;
            flypan.sman = sman;


            ttman.Init0();
            optpan.Init0();
            ottpan.Init0();
            tbtpan.Init0();
            infpan.Init0();
            logpan.Init0();

            vispan.Init0();
            mappan.Init0();
            genpan.Init0();
            frapan.Init0();
            bldpan.Init0();
            osmpan.Init0();
            uiconpan.Init0();
            helpan.Init0();
            abtpan.Init0();
            flypan.Init0();

            listenForKeys = false;
        }
        public void DeleteStuff()
        {
            optpan.DeleteStuff();
            ottpan.DeleteStuff();
            tbtpan.DeleteStuff();
        }
        public void ModelInitialize(SceneSelE newscene)
        {
            // most initialization has to happen after the scenes have set their variables, so there is not much here to do
        }

        public void ModelBuild()
        {
            var newscene = sman.curscene;
            //Debug.Log($"UiMan.SetScene: {newscene}");
            optpan.SetScene(newscene);
            ottpan.SetScene(newscene);
            tbtpan.SetScene(newscene);
            infpan.SetScene(newscene);

            // selectble tabs
            mappan.SetScene(newscene);
            genpan.SetScene(newscene);
            frapan.SetScene(newscene);
            bldpan.SetScene(newscene);
            osmpan.SetScene(newscene);
            uiconpan.SetScene(newscene);
            helpan.SetScene(newscene);
            abtpan.SetScene(newscene);
            logpan.SetScene(newscene);

            SyncState();
        }

        public void SyncState()
        {
            tbtpan.ColorizeButtonStates();
        }
        public void ClosePanel()
        {
            Debug.Log($"UiMan.ClosePanel");
            tbtpan.CloseButton();
        }
        public void HideUi()
        {
            uigo.SetActive(false);
            listenForKeys = true;
        }
        public void ShowUi()
        {
            uigo.SetActive(true);
            listenForKeys = false;
        }

        public void SetButtonColor(Button butt, string activeColor, string idleColor, bool status, string txt, bool force = false)
        {
            if (butt == null)
            {
                //Debug.LogWarning($"SetButton color button {txt} is null"); // this can happen, don't make a fuss
                return;
            }
            var colors = butt.colors;
            //Debug.Log("Set button color:"+hicolor+" status:"+status+" butt.name:"+butt.name);
            var textgo = butt.transform.Find("Text");
            var textcomp = textgo.GetComponent<Text>();
            if (status)
            {
                var hiclr = GraphAlgos.GraphUtil.GetColorByName(activeColor);
                //Debug.Log("Setting button color to:"+clr.ToString());
                colors.normalColor = hiclr;
                colors.highlightedColor = hiclr;
                colors.selectedColor = hiclr;
                if (force)
                {
                    textcomp.text = txt + "**";
                }
                else
                {
                    textcomp.text = txt + "*";
                }
            }
            else
            {
                var loclr = GraphAlgos.GraphUtil.GetColorByName(idleColor);
                colors.normalColor = loclr;
                colors.highlightedColor = loclr;
                colors.selectedColor = loclr;
                textcomp.text = txt;
            }
            butt.colors = colors;
            Canvas.ForceUpdateCanvases();
        }

        public Font GetFont()
        {
            var arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            var consolas = Font.CreateDynamicFontFromOSFont("Consolas", 24);

            var font = arial;
            if (consolas != null)
            {
                font = consolas;
            }
            return font;
        }

        public void DoKeys()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                ShowUi();
            }
        }
        //void Start()
        //{

        //}

        // Update is called once per frame
        void Update()
        {
            if (listenForKeys)
            {
                DoKeys();
            }
        }
    }
}