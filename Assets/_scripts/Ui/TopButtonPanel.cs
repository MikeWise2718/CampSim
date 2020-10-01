using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CampusSimulator
{
    public class TopButtonPanel : MonoBehaviour
    {
        public SceneMan sman;
        UiMan uiman;
        public int btnclk;

        GameObject freeFlyPanel;

        TopButtonMan topButMan;

        Dictionary<string, TopButtonMan.TopButSpec> butspec = new Dictionary<string, TopButtonMan.TopButSpec>()
        {
            {"HideUiButton",new TopButtonMan.TopButSpec("HideUiButton","HideUI", "Hide the User Interface\nEsc brings it back afterwards","left",70,"stretch",0,"All")},
            {"PipeButton",new TopButtonMan.TopButSpec("PipeButton","Pipes", "Show journey path links and nodes","cen",-742,"stretch",0,"All")},
            {"RunButton",new TopButtonMan.TopButSpec("RunButton","Run", "Start ground based journeys","cen",-648,"stretch",0,"Sim")},
            {"FlyButton",new TopButtonMan.TopButSpec("FlyButton","Fly", "Start flying journeys","cen",-578,"stretch",0,"Sim")},
            {"EvacButton",new TopButtonMan.TopButSpec("EvacButton", "Evac", "Start an evacuation simulation","cen",-500,"stretch",0,"Evac")},
            {"UnEvacButton",new TopButtonMan.TopButSpec("UnEvacButton", "Unevac", "After an evacuation, go back to starting positions","cen",-405,"stretch",0,"Evac")},
            {"GoButton",new TopButtonMan.TopButSpec("GoButton","Go", "Kick off a preprogramed scenario dependent journey script","cen",335,"stretch",0,"Sim")},
            {"ShowTracksButton",new TopButtonMan.TopButSpec("ShowTracksButton","Tracks", "Show GPX Tracks","cen",429,"stretch",0,"Trx")},
            {"OptionsButton",new TopButtonMan.TopButSpec("OptionsButton","Options", "Bring up detailed configuration tabs","cen",558,"stretch",0,"All")},
            {"FreeFlyButton",new TopButtonMan.TopButSpec("FreeFlyButton","FreeFly", "Fly around in scene freely\nEsc exits this state","cen",707,"stretch",0,"All")},
            {"QuitButton" ,new TopButtonMan.TopButSpec("QuitButton","Quit", "Quit to OS","right",-70,"stretch",0,"All")},

            {"FrameButton",new TopButtonMan.TopButSpec("FrameButton","Frame", "Draw labels on people, cars, etc","cen",-275,"stretch",10,"Frame")},
            {"FteButton" ,new TopButtonMan.TopButSpec("FteButton","F", "Detect FTEs","cen",-194,"stretch",10,"Frame")},
            {"ConButton" ,new TopButtonMan.TopButSpec("ConButton","C", "Detect Contractors","cen",-154,"stretch",10,"Frame")},
            {"VisButton" ,new TopButtonMan.TopButSpec("VisButton","V", "Detect Visitors","cen",-114,"stretch",10,"Frame")},
            {"SecButton" ,new TopButtonMan.TopButSpec("SecButton","S", "Detect Security","cen",-74,"stretch",10,"Frame")},
            {"UnkButton" ,new TopButtonMan.TopButSpec("UnkButton","U", "Detect Unknowns","cen",-34,"stretch",10,"Frame")},
            {"Vt2DButton" ,new TopButtonMan.TopButSpec("Vt2DButton","Vt2D", "Tie Visibility to Detectability","cen",32,"stretch",10,"Frame")},

            {"TranButton" ,new TopButtonMan.TopButSpec("TranButton","Tran", "Make Walls Transparent","cen",120,"stretch",10,"B121")},
            {"HvacButton" ,new TopButtonMan.TopButSpec("HvacButton","Tran", "Show HVAC System","cen",170,"stretch",10,"B121")},
            {"ElecButton" ,new TopButtonMan.TopButSpec("ElecButton","Tran", "Show Electrical System","cen",212,"stretch",10,"B121")},
            {"PlumButton" ,new TopButtonMan.TopButSpec("PlumButton","Tran", "Show Plumbing System","cen",254,"stretch",10,"B121")},
        };

        public void AddActionsToButspecs()
        {
            // this is easier than initializing it inline
            butspec["HideUiButton"].action = delegate { uiman.HideUi(); };
            butspec["RunButton"].action = delegate { RunButton(); };
            butspec["FlyButton"].action = delegate { FlyButton(); };
            butspec["FrameButton"].action = delegate { FrameButton(); };
            butspec["EvacButton"].action = delegate { EvacButton(); };
            butspec["UnEvacButton"].action = delegate { UnevacButton(); };
            butspec["PipeButton"].action = delegate { DetectPipButton(); };
            butspec["GoButton"].action = delegate { GoButton(); };
            butspec["ShowTracksButton"].action = delegate { ShowTracksButton(); };
            butspec["OptionsButton"].action = delegate { OptionsButtonPushed(); };
            butspec["FreeFlyButton"].action = delegate { FreeFlyButton(); };
            butspec["QuitButton"].action = delegate { QuitButton(); };

            butspec["FteButton"].action = delegate { DetectFteButton(); };
            butspec["ConButton"].action = delegate { DetectConButton(); };
            butspec["VisButton"].action = delegate { DetectSecButton(); };
            butspec["SecButton"].action = delegate { DetectVisButton(); };
            butspec["UnkButton"].action = delegate { DetectUnkButton(); };
            butspec["Vt2DButton"].action = delegate { Vt2DButton(); };

            butspec["TranButton"].action = delegate { DetectTranButton(); };
            butspec["HvacButton"].action = delegate { DetectFteButton(); };
            butspec["ElecButton"].action = delegate { DetectElecButton(); };
            butspec["PlumButton"].action = delegate { DetectPlumButton(); };

        }

        void LinkObjectsAndComponents()
        {
            uiman = sman.uiman;
            topButMan = gameObject.AddComponent<TopButtonMan>();
            topButMan.Init(sman);
            AddActionsToButspecs();

        }

        public void DeleteStuff()
        {
            if (topButMan != null)
            {
                topButMan.DeleteStuff();
            }
        }



        public void SetScene(CampusSimulator.SceneSelE curscene)
        {
            string tbpfiltlist = "All,Sim,Trx";
            switch(curscene)
            {
                case SceneSelE.MsftSmall:
                    tbpfiltlist = "All";
                    break;
                case SceneSelE.MsftB121focused:
                    tbpfiltlist += ",B121,Frame";
                    break;
                case SceneSelE.MsftB19focused:
                    tbpfiltlist += ",Evac,Frame";
                    break;
                case SceneSelE.MsftB33focused:
                    tbpfiltlist += ",Evac,Frame";
                    break;
                case SceneSelE.Eb12:
                case SceneSelE.Eb12small:
                    tbpfiltlist += ",Evac";
                    break;
                case SceneSelE.MsftRedwest:
                    tbpfiltlist += ",Evac,Frame";
                    break;
            }
            CreateButtonsAnew(tbpfiltlist);
        }
        public void Init0()
        {
            LinkObjectsAndComponents();
            topButMan.DestroyFixedDummyButtons();
        }


        string orderedFixedButtonList = "HideUiButton,RunButton,FlyButton,FrameButton,EvacButton,UnEvacButton,PipeButton,GoButton,OptionsButton,ShowTracksButton,FreeFlyButton,QuitButton";
        string orderedScenarioButtonList1 = "FteButton,ConButton,VisButton,SecButton,UnkButton,Vt2DButton,TranButton,HvacButton,ElecButton,PlumButton";

        public void CreateButtonsAnew(string tbtfiltlist)
        {
            topButMan.SetTbtFilter(tbtfiltlist);
            var butfixtxtarr = orderedFixedButtonList.Split(',');
            var butsentxtarr = orderedScenarioButtonList1.Split(',');
            var buttxtarra = new List<string>(butfixtxtarr);
            buttxtarra.AddRange(butsentxtarr);
            foreach (var k in buttxtarra)
            {
                if (!butspec.ContainsKey(k))
                {
                    sman.LggError($"TopButtonPanel.CreateButtonsAnew - bad option spec:{k}");
                    continue;
                }
                var bs = butspec[k];
                topButMan.SpecOneButton(bs);
            }
            topButMan.CreateButtons();
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
        public void clrbut(string bname,string activecolor,string idlecolor,bool status,string displaytxt)
        {
            var but = topButMan.GetButton(bname);
            if (but != null)
            {
                uiman.SetButtonColor(but, activecolor, idlecolor, status,displaytxt);
            }
        }
        public void ColorizeButtonStates()
        {
            var loc = "white";
            clrbut("PipeButton", "pink", loc, sman.lcman.pipevis, "Pipes");
            clrbut("FteButton", "lightblue", loc, sman.frman.detectFte.Get(), "F");
            clrbut("ConButton", "lightblue", loc, sman.frman.detectContractor.Get(), "C");
            clrbut("SecButton", "lightblue", loc, sman.frman.detectSecurity.Get(), "S");
            clrbut("VisButton", "lightblue", loc, sman.frman.detectVisitor.Get(), "V");
            clrbut("UnkButton", "lightblue", loc, sman.frman.detectUnknown.Get(), "U");
            clrbut("ShowTracksButton", "lightblue", loc, sman.trman.showtracks.Get(), "Tracks");
            clrbut("TranButton", "lightblue", loc, sman.bdman.transwalls, "Tr");
            clrbut("HvacButton", "yellow", loc, sman.bdman.showhvac, "Hv");
            clrbut("ElecButton", "yellow", loc, sman.bdman.showelec, "El");
            clrbut("PlumButton", "yellow", loc, sman.bdman.showplum, "Pb");
            clrbut("Vt2dButton", "lightblue", loc, sman.frman.visibilityTiedToDetectability.Get(), "Vt2D");
            clrbut("FrameButton", "pink", loc, sman.frman.frameJourneys.Get(), "Frame");
            clrbut("FreeFlyButton", "pink", loc, sman.vcman.InFreeFly(), "FreeFly");
            clrbut("RunButton", "pink", loc, sman.jnman.spawnrunjourneys, "Run");
            clrbut("FlyButton", "lightblue", loc, sman.jnman.spawnflyjourneys, "Fly");
        }
        //public void ColorizeButtonStatesOld()
        //{
        //    var loc = "white";
        //    uiman.SetButtonColor(pipeButton, "pink",loc, sman.lcman.pipevis, "Pi");
        //    uiman.SetButtonColor(fteButton, "lightblue", loc, sman.frman.detectFte.Get(), "F");
        //    uiman.SetButtonColor(conButton, "lightblue", loc, sman.frman.detectContractor.Get(), "C");
        //    uiman.SetButtonColor(secButton, "lightblue", loc, sman.frman.detectSecurity.Get(), "S");
        //    uiman.SetButtonColor(visButton, "lightblue", loc, sman.frman.detectVisitor.Get(), "V");
        //    uiman.SetButtonColor(unkButton, "lightblue", loc, sman.frman.detectUnknown.Get(), "U");
        //    uiman.SetButtonColor(showTracksButton, "lightblue", loc, sman.trman.showtracks.Get(), "Tracks");
        //    uiman.SetButtonColor(tranButton, "lightblue", loc, sman.bdman.transwalls, "Tr");
        //    uiman.SetButtonColor(hvacButton, "yellow", loc, sman.bdman.showhvac, "Hv");
        //    uiman.SetButtonColor(elecButton, "yellow", loc, sman.bdman.showelec, "El");
        //    uiman.SetButtonColor(plumButton, "yellow", loc, sman.bdman.showplum, "Pb");
        //    //Debug.LogWarning($"ColorizeButtonStates Vt2D:{sman.frman.visibilityTiedToDetectability.Get()}");
        //    uiman.SetButtonColor(vt2dButton, "lightblue", loc, sman.frman.visibilityTiedToDetectability.Get(), "Vt2D");
        //    uiman.SetButtonColor(frameButton, "pink", loc, sman.frman.frameJourneys.Get(), "Frame");
        //    uiman.SetButtonColor(freeFlyButton, "pink", loc, sman.vcman.InFreeFly(), "FreeFly");
        //    uiman.SetButtonColor(runButton, "pink", loc, sman.jnman.spawnrunjourneys, "Run");
        //    uiman.SetButtonColor(flyButton, "lightblue", loc, sman.jnman.spawnflyjourneys, "Fly");
        //}
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
    //    private void Start()
    //    {
    //    }

    //    int updcount = 0;
    //    void Update()
    //    {
    //        updcount++;
    //    }
    }
}