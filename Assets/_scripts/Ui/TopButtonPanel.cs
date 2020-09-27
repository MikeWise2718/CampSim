using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CampusSimulator
{
    public class TopButtonPanel : MonoBehaviour
    {
        public SceneMan sman;
        UiMan uiman;
        public int btnclk;
        Button runButton;
        Button flyButton;
        Button frameButton;
        Button evacButton;
        Button unevacButton;
        Button freeFlyButton;
        Button quitButton;
        Button hideUiButton;
        Button fteButton;
        Button conButton;
        Button secButton;
        Button visButton;
        Button unkButton;
        Button vt2dButton;

        Button pipeButton;

        Button tranButton;
        Button hvacButton;
        Button elecButton;
        Button plumButton;


        Button goButton;
        Button optionsButton;
        Button showTracksButton;
       // Canvas canvas;
        GameObject freeFlyPanel;


        List<Button> butList; 
        // Start is called before the first frame update

        void LinkObjectsAndComponents()
        {
            uiman = sman.uiman;

            runButton = transform.Find("RunButton").gameObject.GetComponent<Button>();
            flyButton = transform.Find("FlyButton").gameObject.GetComponent<Button>();
            frameButton = transform.Find("FrameButton").gameObject.GetComponent<Button>();
            evacButton = transform.Find("EvacButton").gameObject.GetComponent<Button>();
            unevacButton = transform.Find("UnEvacButton").gameObject.GetComponent<Button>();
            pipeButton = transform.Find("PipeButton").gameObject.GetComponent<Button>();
            goButton = transform.Find("GoButton").gameObject.GetComponent<Button>();
            optionsButton = transform.Find("OptionsButton").gameObject.GetComponent<Button>();
            showTracksButton = transform.Find("ShowTracksButton").gameObject.GetComponent<Button>();
            freeFlyButton = transform.Find("FreeFlyButton").gameObject.GetComponent<Button>();
            quitButton = transform.Find("QuitButton").gameObject.GetComponent<Button>();
            hideUiButton = transform.Find("HideUiButton").gameObject.GetComponent<Button>();
            freeFlyPanel = transform.Find("FreeFlyHelpPanel").gameObject;



            fteButton = transform.Find("FteButton").gameObject.GetComponent<Button>();
            conButton = transform.Find("ConButton").gameObject.GetComponent<Button>();
            secButton = transform.Find("SecButton").gameObject.GetComponent<Button>();
            visButton = transform.Find("VisButton").gameObject.GetComponent<Button>();
            unkButton = transform.Find("UnkButton").gameObject.GetComponent<Button>();
            vt2dButton = transform.Find("Vt2DButton").gameObject.GetComponent<Button>();

            tranButton = transform.Find("TranButton").gameObject.GetComponent<Button>();
            hvacButton = transform.Find("HvacButton").gameObject.GetComponent<Button>();
            elecButton = transform.Find("ElecButton").gameObject.GetComponent<Button>();
            plumButton = transform.Find("PlumButton").gameObject.GetComponent<Button>();


            runButton.onClick.AddListener(delegate { RunButton(); });
            flyButton.onClick.AddListener(delegate { FlyButton(); });
            frameButton.onClick.AddListener(delegate { FrameButton(); });
            evacButton.onClick.AddListener(delegate { EvacButton(); });
            unevacButton.onClick.AddListener(delegate { UnevacButton(); });
            vt2dButton.onClick.AddListener(delegate { Vt2DButton(); });
            freeFlyButton.onClick.AddListener(delegate { FreeFlyButton(); });
            quitButton.onClick.AddListener(delegate { QuitButton(); });
            showTracksButton.onClick.AddListener(delegate { ShowTracksButton(); });
            hideUiButton.onClick.AddListener(delegate { uiman.HideUi(); });
            fteButton.onClick.AddListener(delegate { DetectFteButton(); });
            conButton.onClick.AddListener(delegate { DetectConButton(); });
            secButton.onClick.AddListener(delegate { DetectSecButton(); });
            visButton.onClick.AddListener(delegate { DetectVisButton(); });
            unkButton.onClick.AddListener(delegate { DetectUnkButton(); });
            goButton.onClick.AddListener(delegate { GoButton(); });
            optionsButton.onClick.AddListener(delegate { OptionsButtonPushed(); });
            tranButton.onClick.AddListener(delegate { DetectTranButton(); });
            hvacButton.onClick.AddListener(delegate { DetectHvacButton(); });
            elecButton.onClick.AddListener(delegate { DetectElecButton(); });
            plumButton.onClick.AddListener(delegate { DetectPlumButton(); });
            pipeButton.onClick.AddListener(delegate { DetectPipButton(); });

            uiman.ttman.WireUpToolTip(hideUiButton.gameObject, "HideUI", "Hide the User Interface\nEsc brings it back afterwards");
            uiman.ttman.WireUpToolTip(runButton.gameObject, "Run", "Start ground based journeys");
            uiman.ttman.WireUpToolTip(flyButton.gameObject, "Fly", "Start flying journeys");
            uiman.ttman.WireUpToolTip(frameButton.gameObject, "Frame", "Draw labels on people, cars, etc");
            uiman.ttman.WireUpToolTip(evacButton.gameObject, "Evac", "Start an evacuation simulation");
            uiman.ttman.WireUpToolTip(unevacButton.gameObject, "Unevac", "After an evacuation, go back to starting positions");
            uiman.ttman.WireUpToolTip(fteButton.gameObject, "Fte", "Detect people with FTE status");
            uiman.ttman.WireUpToolTip(conButton.gameObject, "Con", "Detect people with contractor status");
            uiman.ttman.WireUpToolTip(secButton.gameObject, "Sec", "Detect people with security status");
            uiman.ttman.WireUpToolTip(secButton.gameObject, "Vis", "Detect people with visor status");
            uiman.ttman.WireUpToolTip(unkButton.gameObject, "Unk", "Detect unknown people");
            uiman.ttman.WireUpToolTip(vt2dButton.gameObject, "vt2d", "Tie Visibility to Detectability");

            uiman.ttman.WireUpToolTip(tranButton.gameObject, "trans", "Switch Bld121 walls to being transparent");
            uiman.ttman.WireUpToolTip(hvacButton.gameObject, "hvac", "Show Bld121 HVAC structures");
            uiman.ttman.WireUpToolTip(elecButton.gameObject, "elec", "Show Bld121 electric structures");
            uiman.ttman.WireUpToolTip(plumButton.gameObject, "plum", "Show Bld121 plumbing structures");

            uiman.ttman.WireUpToolTip(showTracksButton.gameObject, "trax", "Show GPX Tracks");


            uiman.ttman.WireUpToolTip(pipeButton.gameObject, "Pi", "Show journey path links and nodes");


            uiman.ttman.WireUpToolTip(freeFlyButton.gameObject, "freefly", "Fly around in scene freely\nEsc exits this state");
            uiman.ttman.WireUpToolTip(quitButton.gameObject, "quit", "Quit to OS");
            uiman.ttman.WireUpToolTip(goButton.gameObject, "go", "Kick off a preprogramed scenario dependent journey script");
            uiman.ttman.WireUpToolTip(optionsButton.gameObject, "opts", "Bring up detailed configuration tabs");
        }
        public void SetScene(CampusSimulator.SceneSelE curscene)
        {
        }
        public void Init0()
        {
            LinkObjectsAndComponents();
        }

 

        public void RunButton()
        {
            sman.jnman.spawnrunjourneys = !sman.jnman.spawnrunjourneys;
            if (sman.vcman.saveContinuouslyOnPlay)
            {
                sman.vcman.saveMainCamContinuously = true;
            }
            if (sman.frman.saveContinuouslyOnPlay)
            {
                sman.frman.saveLabelListContinuously = true;
            }
            //Debug.Log("Toggled run to " + sman.jnman.spawnjourneys);
            ColorizeButtonStates();
            btnclk++;
        }

        public void FlyButton()
        {
            sman.jnman.spawnflyjourneys = !sman.jnman.spawnflyjourneys;
            if (sman.vcman.saveContinuouslyOnPlay)
            {
                sman.vcman.saveMainCamContinuously = true;
            }
            if (sman.frman.saveContinuouslyOnPlay)
            {
                sman.frman.saveLabelListContinuously = true;
            }
            //Debug.Log("Toggled run to " + sman.jnman.spawnjourneys);
            ColorizeButtonStates();
            btnclk++;
        }


        public void FrameButton()
        {
            var oldval = sman.frman.frameJourneys.Get();
            var newval = !oldval;
            //Debug.LogWarning($"FrameButton {sman.curscene} setting all frames to newval:{newval}");
            var ctrlmod = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
            sman.frman.FrameButtonPressed(newval,ctrlmod);
            ColorizeButtonStates();
            btnclk++;
        }
        public void EvacButton()
        {
            sman.bdman.EvacPresetBld();
            btnclk++;
        }
        public void UnevacButton()
        {
            sman.bdman.UnevacPresetBld();
            btnclk++;
        }
        public void ArcoreTrackButton()
        {
            //sman.arcoreTrack = !sman.arcoreTrack;
            //sman.SetArcoreTracking();
            //SetButtonColor(trackButton, "pink", sman.arcoreTrack, "Track");
            //btnclk++;
        }
        public void SnapshotButton()
        {
            //GraphAlgos.GraphUtil.SaveCameraShot(Camera.main, "snaps/", "snap");
            GraphAlgos.GraphUtil.SaveScreenShot("snaps/", "snap");
            btnclk++;
        }
        public void Main2SceneButton()
        {
#if UNITY_EDITOR
            sman.vcman.SetMainCamToSceneCam();
#endif
            btnclk++;
        }
        public void Scene2MainButton()
        {
#if UNITY_EDITOR
            sman.vcman.SetSceneCamToMainCam();
#endif
            btnclk++;
        }


        public void GoButton()
        {
            sman.jnman.LaunchJourneys();
        }
        public void OptionsButtonPushed()
        {
            uiman.optpan.TogglePanelState();
        }
        public void CloseButton()
        {
            uiman.optpan.ClosePanel();
        }
        bool ffpanstat = false;
        public void ToggleFreeFlyPanel()
        {
            ffpanstat = !ffpanstat;
            freeFlyPanel.SetActive(ffpanstat);
            //Debug.Log("Turned FreeFlyPanel " + ffpanstat);
        }
        //bool ffstat=false;
        public void FreeFlyButton()
        {
            //Debug.Log("FreeFlyButton Pushed");
            var ffstat = sman.vcman.ToggleFreeFly();
            if (freeFlyPanel)
            {
                if (ffstat!=ffpanstat)
                {
                    ToggleFreeFlyPanel();
                }
            }
            ColorizeButtonStates();
        }

        public void ShowTracksButton()
        {
            var trman = sman.trman;
            if (trman != null)
            {
                //var active = stman.gameObject.activeSelf;
                var active = trman.showtracks.Get();
                trman.showtracks.SetAndSave(!active);
                trman.gameObject.SetActive(!active);
                ColorizeButtonStates();
            }
        }

        public void QuitButton()
        {
            Debug.Log($"Activating QuitButton");
            sman.Quit();
        }

        public void ColorizeButtonStates()
        {
            var loc = "white";
            uiman.SetButtonColor(pipeButton, "pink",loc, sman.lcman.pipevis, "Pi");
            uiman.SetButtonColor(fteButton, "lightblue", loc, sman.frman.detectFte.Get(), "F");
            uiman.SetButtonColor(conButton, "lightblue", loc, sman.frman.detectContractor.Get(), "C");
            uiman.SetButtonColor(secButton, "lightblue", loc, sman.frman.detectSecurity.Get(), "S");
            uiman.SetButtonColor(visButton, "lightblue", loc, sman.frman.detectVisitor.Get(), "V");
            uiman.SetButtonColor(unkButton, "lightblue", loc, sman.frman.detectUnknown.Get(), "U");
            uiman.SetButtonColor(showTracksButton, "lightblue", loc, sman.trman.showtracks.Get(), "Tracks");
            uiman.SetButtonColor(tranButton, "lightblue", loc, sman.bdman.transwalls, "Tr");
            uiman.SetButtonColor(hvacButton, "yellow", loc, sman.bdman.showhvac, "Hv");
            uiman.SetButtonColor(elecButton, "yellow", loc, sman.bdman.showelec, "El");
            uiman.SetButtonColor(plumButton, "yellow", loc, sman.bdman.showplum, "Pb");
            //Debug.LogWarning($"ColorizeButtonStates Vt2D:{sman.frman.visibilityTiedToDetectability.Get()}");
            uiman.SetButtonColor(vt2dButton, "lightblue", loc, sman.frman.visibilityTiedToDetectability.Get(), "Vt2D");
            uiman.SetButtonColor(frameButton, "pink", loc, sman.frman.frameJourneys.Get(), "Frame");
            uiman.SetButtonColor(freeFlyButton, "pink", loc, sman.vcman.InFreeFly(), "FreeFly");
            uiman.SetButtonColor(runButton, "pink", loc, sman.jnman.spawnrunjourneys, "Run");
            uiman.SetButtonColor(flyButton, "lightblue", loc, sman.jnman.spawnflyjourneys, "Fly");
        }
        public void DetectFteButton()
        {
            sman.frman.detectFte.SetAndSave(!sman.frman.detectFte.Get());
            ColorizeButtonStates();
        }
        public void DetectConButton()
        {
            sman.frman.detectContractor.SetAndSave(!sman.frman.detectContractor.Get());
            ColorizeButtonStates();
        }
        public void DetectSecButton()
        {
            sman.frman.detectSecurity.SetAndSave(!sman.frman.detectSecurity.Get());
            ColorizeButtonStates();
        }
        public void DetectVisButton()
        {
            sman.frman.detectVisitor.SetAndSave(!sman.frman.detectVisitor.Get());
            ColorizeButtonStates();
        }
        public void DetectUnkButton()
        {
            sman.frman.detectUnknown.SetAndSave(!sman.frman.detectUnknown.Get());
            ColorizeButtonStates();
        }

        public void DetectTranButton()
        {
            sman.bdman.transwalls = !sman.bdman.transwalls;
            sman.bdman.TransBld121Button();
            ColorizeButtonStates();
        }
        public void DetectHvacButton()
        {
            sman.bdman.showhvac = !sman.bdman.showhvac;
            sman.bdman.ShowHvacBld121Button();
            ColorizeButtonStates();
        }
        public void DetectElecButton()
        {
            sman.bdman.showelec = !sman.bdman.showelec;
            sman.bdman.ShowElecBld121Button();
            ColorizeButtonStates();
        }

        public void DetectPlumButton()
        {
            sman.bdman.showplum = !sman.bdman.showplum;
            sman.bdman.ShowPlumBld121Button();
            ColorizeButtonStates();
        }


        public void DetectPipButton()
        {
            sman.lcman.pipevis = !sman.lcman.pipevis;
            sman.lcman.PipeVisButton();
            ColorizeButtonStates();
        }
        public void Vt2DButton()
        {
            sman.frman.visibilityTiedToDetectability.SetAndSave(!sman.frman.visibilityTiedToDetectability.Get());
            ColorizeButtonStates();
        }
        // Update is called once per frame

        int updcount = 0;
        void Update()
        {
            updcount++;
        }
    }
}