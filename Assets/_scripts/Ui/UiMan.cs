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
        public FireFlyPanel flypan;
        public FramePanel frapan;
        public BuildingsPanel bldpan;
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

            uigo = GameObject.Find("SimParkUICanvas");
            optpan = FindObjectOfType<OptionsPanel>();
            stapan = FindObjectOfType<StatusPanel>();
            infpan = FindObjectOfType<InfoPanel>();

            vispan = Resources.FindObjectsOfTypeAll<VisualsPanel>()[0];
            mappan = Resources.FindObjectsOfTypeAll<MapSetPanel>()[0];
            genpan = Resources.FindObjectsOfTypeAll<GeneralPanel>()[0];
            frapan = Resources.FindObjectsOfTypeAll<FramePanel>()[0];
            flypan = Resources.FindObjectsOfTypeAll<FireFlyPanel>()[0];
            bldpan = Resources.FindObjectsOfTypeAll<BuildingsPanel>()[0];
            helpan = Resources.FindObjectsOfTypeAll<HelpPanel>()[0];
            abtpan = Resources.FindObjectsOfTypeAll<AboutPanel>()[0];

            ttman.sman = sman;
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
            flypan.sman = sman;


            ttman.Init0();
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
            flypan.Init0();

            listenForKeys = false;
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
            Debug.Log($"UiMan.ClosePanel");
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