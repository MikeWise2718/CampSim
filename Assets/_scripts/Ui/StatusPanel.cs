﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CampusSimulator
{
    public class StatusPanel : MonoBehaviour
    {
        public SceneMan sman;
        JourneyMan jman;
        GarageMan gman;
        public int btnclk;
        GameObject optionsPanelGo;
        OptionsPanel optionsPanel;
        Button runButton;
        Button frameButton;
        Button evacButton;
        Button unevacButton;
        Button freeFlyButton;
        Button fteButton;
        Button conButton;
        Button secButton;
        Button visButton;
        Button unkButton;
        Button vt2dButton;
        Button goButton;
        Button optionsButton;
        Button mapfitButton;
        Canvas canvas;
        GameObject freeFlyPanel;
        // Start is called before the first frame update

        bool linked = false;
        void LinkObjectsAndComponents()
        {
            if (linked) return;
            jman = sman.jnman;
            gman = sman.gaman;
            var cango = GameObject.Find("SimParkUICanvas");
            canvas = cango.GetComponent<Canvas>();
            canvas = cango.GetComponent<Canvas>();

            optionsPanelGo = transform.Find("OptionsPanel").gameObject;
            optionsPanel = optionsPanelGo.GetComponent<OptionsPanel>();
            if (optionsPanelGo.activeSelf)
            {
                optionsPanelGo.SetActive(false);
            }

            runButton = transform.Find("RunButton").gameObject.GetComponent<Button>();
            frameButton = transform.Find("FrameButton").gameObject.GetComponent<Button>();
            evacButton = transform.Find("EvacButton").gameObject.GetComponent<Button>();
            unevacButton = transform.Find("EvacButton").gameObject.GetComponent<Button>();
            goButton = transform.Find("GoButton").gameObject.GetComponent<Button>();
            optionsButton = transform.Find("OptionsButton").gameObject.GetComponent<Button>();
            mapfitButton = transform.Find("MapFitButton").gameObject.GetComponent<Button>();
            freeFlyButton = transform.Find("FreeFlyButton").gameObject.GetComponent<Button>();
            freeFlyPanel = transform.Find("FreeFlyHelpPanel").gameObject;
            fteButton = transform.Find("FteButton").gameObject.GetComponent<Button>();
            conButton = transform.Find("ConButton").gameObject.GetComponent<Button>();
            secButton = transform.Find("SecButton").gameObject.GetComponent<Button>();
            visButton = transform.Find("VisButton").gameObject.GetComponent<Button>();
            unkButton = transform.Find("UnkButton").gameObject.GetComponent<Button>();
            vt2dButton = transform.Find("Vt2DButton").gameObject.GetComponent<Button>();

            runButton.onClick.AddListener(delegate { RunButton(); });
            frameButton.onClick.AddListener(delegate { FrameButton(); });
            evacButton.onClick.AddListener(delegate { EvacButton(); });
            unevacButton.onClick.AddListener(delegate { UnevacButton(); });
            unevacButton.onClick.AddListener(delegate { UnevacButton(); });
            vt2dButton.onClick.AddListener(delegate { Vt2DButton(); });
            freeFlyButton.onClick.AddListener(delegate { FreeFlyButton(); });
            fteButton.onClick.AddListener(delegate { DetectFteButton(); });
            conButton.onClick.AddListener(delegate { DetectConButton(); });
            secButton.onClick.AddListener(delegate { DetectSecButton(); });
            visButton.onClick.AddListener(delegate { DetectVisButton(); });
            unkButton.onClick.AddListener(delegate { DetectUnkButton(); });
            goButton.onClick.AddListener(delegate { GoButton(); });
            optionsButton.onClick.AddListener(delegate { OptionsButton(); });
            linked = true;
        }

        public void Init0()
        {
            LinkObjectsAndComponents();
        }

        public void SetButtonColor(Button butt,string hicolor,bool status,string txt,bool force=false)
        {
            if (butt == null)
            {
                Debug.Log($"SetButton color button {txt} is null");
                return;
            }
            var colors = butt.colors;
            //Debug.Log("Set button color:"+hicolor+" status:"+status+" butt.name:"+butt.name);
            var textgo = butt.transform.Find("Text");
            var textcomp = textgo.GetComponent<Text>();
            if (status)
            {
                var clr = GraphAlgos.GraphUtil.getcolorbyname(hicolor);
                //Debug.Log("Setting button color to:"+clr.ToString());
                colors.normalColor = clr;
                colors.highlightedColor = clr;
                colors.selectedColor = clr;
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
                colors.normalColor = Color.white;
                colors.highlightedColor = Color.white;
                colors.selectedColor = Color.white;
                textcomp.text = txt;
            }
            butt.colors = colors;
            Canvas.ForceUpdateCanvases();
        }

        public void RunButton()
        {
            sman.jnman.spawnjourneys = !sman.jnman.spawnjourneys;
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
            sman.jnman.LaunchArnie();
        }
        public void OptionsButton()
        {
            var newstate = !optionsPanelGo.activeSelf;
            //Debug.Log($"Options Button Pushed optionsPanelGo.activeSelf:{optionsPanelGo.activeSelf} -> newstate:{newstate}");
            optionsPanelGo.SetActive(newstate);// this does immediately take effect
            optionsPanel.ChangingOptionsDialog(newstate);
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

        public void ColorizeButtonStates()
        {
            SetButtonColor(fteButton, "lightblue", sman.frman.detectFte.Get(), "F");
            SetButtonColor(conButton, "lightblue", sman.frman.detectContractor.Get(), "C");
            SetButtonColor(secButton, "lightblue", sman.frman.detectSecurity.Get(), "S");
            SetButtonColor(visButton, "lightblue", sman.frman.detectVisitor.Get(), "V");
            SetButtonColor(unkButton, "lightblue", sman.frman.detectUnknown.Get(), "U");
            //Debug.LogWarning($"ColorizeButtonStates Vt2D:{sman.frman.visibilityTiedToDetectability.Get()}");
            SetButtonColor(vt2dButton, "lightblue", sman.frman.visibilityTiedToDetectability.Get(), "Vt2D");
            SetButtonColor(frameButton, "pink", sman.frman.frameJourneys.Get(), "Frame");
            SetButtonColor(freeFlyButton, "pink", sman.vcman.InFreeFly(), "FreeFly");
            SetButtonColor(runButton, "pink", sman.jnman.spawnjourneys, "Run");
        }
        public void DetectFteButton()
        {
            sman.frman.detectFte.SetAndSave(!sman.frman.detectFte.Get());
            ColorizeButtonStates();
            //SetButtonColor(fteButton, "lightblue", sman.frman.detectFte.Get(), "F");
        }
        public void DetectConButton()
        {
            sman.frman.detectContractor.SetAndSave(!sman.frman.detectContractor.Get());
            ColorizeButtonStates();
            //SetButtonColor(conButton, "lightblue", sman.frman.detectContractor.Get(), "C");
        }
        public void DetectSecButton()
        {
            sman.frman.detectSecurity.SetAndSave(!sman.frman.detectSecurity.Get());
            ColorizeButtonStates();
            //SetButtonColor(secButton, "lightblue", sman.frman.detectSecurity.Get(), "S");
        }
        public void DetectVisButton()
        {
            sman.frman.detectVisitor.SetAndSave(!sman.frman.detectVisitor.Get());
            ColorizeButtonStates();
            //SetButtonColor(visButton, "lightblue", sman.frman.detectVisitor.Get(), "V");
        }
        public void DetectUnkButton()
        {
            sman.frman.detectUnknown.SetAndSave(!sman.frman.detectUnknown.Get());
            ColorizeButtonStates();
            //SetButtonColor(unkButton, "lightblue", sman.frman.detectUnknown.Get(), "U");
        }
        public void Vt2DButton()
        {
            sman.frman.visibilityTiedToDetectability.SetAndSave(!sman.frman.visibilityTiedToDetectability.Get());
            ColorizeButtonStates();
            //SetButtonColor(vt2dButton, "lightblue", sman.frman.visibilityTiedToDetectability.Get(), "Vt2D");
        }
        // Update is called once per frame

        int updcount = 0;
        void Update()
        {
            updcount++;
        }
    }
}