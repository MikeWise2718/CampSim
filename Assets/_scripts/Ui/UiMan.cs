using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CampusSimulator
{

    public class UiMan : MonoBehaviour
    {
        public SceneMan sman;
        // Start is called before the first frame update

        public GameObject uigo;
        public OptionsPanel optpan;
        public InfoPanel infpan;
        public StatusPanel stapan;

        public VisualsPanel vispan;
        public MapSetPanel mappan;
        public GeneralPanel genpan;
        public FramePanel frapan;
        public BuildingsPanel bldpan;
        public HelpPanel helpan;
        public AboutPanel abtpan;

        public bool listenForKeys = false;

        public void InitPhase0()
        {
            uigo = GameObject.Find("SimParkUICanvas");
            optpan = FindObjectOfType<OptionsPanel>();
            stapan = FindObjectOfType<StatusPanel>();
            infpan = FindObjectOfType<InfoPanel>();

            vispan = Resources.FindObjectsOfTypeAll<VisualsPanel>()[0];
            mappan = Resources.FindObjectsOfTypeAll<MapSetPanel>()[0];
            genpan = Resources.FindObjectsOfTypeAll<GeneralPanel>()[0];
            frapan = Resources.FindObjectsOfTypeAll<FramePanel>()[0];
            bldpan = Resources.FindObjectsOfTypeAll<BuildingsPanel>()[0];
            helpan = Resources.FindObjectsOfTypeAll<HelpPanel>()[0];
            abtpan = Resources.FindObjectsOfTypeAll<AboutPanel>()[0];

            optpan.sman = sman;
            stapan.sman = sman;
            infpan.sman = sman;

            vispan.sman = sman;
            mappan.sman = sman;
            genpan.sman = sman;
            frapan.sman = sman;
            bldpan.sman = sman;
            helpan.sman = sman;
            abtpan.sman = sman;


            optpan.Init0();
            stapan.Init0();
            infpan.Init0();

            vispan.Init0();
            mappan.Init0();
            genpan.Init0();
            frapan.Init0();
            bldpan.Init0();
            helpan.Init0();
            abtpan.Init0();

            listenForKeys = false;
        }

        public void InitializeScene(SceneSelE newscene)
        {
            // most initialization has to happen after the scenes have set their variables, so there is not much here to do
        }

        public void SetScene(SceneSelE newscene)
        {
            //Debug.Log($"UiMan.SetScene: {newscene}");
            optpan.SetScene(newscene);
            stapan.SetScene(newscene);
            infpan.SetScene(newscene);

            // selectble tabs
            mappan.SetScene(newscene);
            genpan.SetScene(newscene);
            frapan.SetScene(newscene);
            bldpan.SetScene(newscene);
            helpan.SetScene(newscene);
            abtpan.SetScene(newscene);

            SyncState();
        }

        public void SyncState()
        {
            stapan.ColorizeButtonStates();
        }
        public void ClosePanel()
        {
            stapan.CloseButton();
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