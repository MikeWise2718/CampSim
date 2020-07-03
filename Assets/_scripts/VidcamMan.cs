﻿using System.Collections.Generic;
using UnityEngine;
using System;
using UxUtils;

namespace CampusSimulator
{
    public class VidcamMan : MonoBehaviour
    {
        public SceneMan sman;

        public GameObject vmcamgo;
        public Camera vmcam;// we don't want this to change

        public string lastcamset = "MainCam";
        public bool setMainCamToSceneCam = false;
        public bool setSceneCamToMainCam = false;

        public UxSetting<string> mainCamName = new UxSetting<string>("MainCamName","NoCameraChosen");

        Dictionary<string, Vidcam> vidcam = new Dictionary<string, Vidcam>();
        List<string> vidcamnames = new List<string>(); // maintain a sorted list 

        public enum BackGroundTypeE { UiFrame, Quad, None }
        public UxEnumSetting<BackGroundTypeE> backType = new UxEnumSetting<BackGroundTypeE>("BackgroundType",BackGroundTypeE.None);


        public void InitPhase0()
        {
            vmcamgo = new GameObject("Vmain Camera");
            vmcam = vmcamgo.AddComponent<Camera>();
        }

        public void RealizeBackground()
        {
            if (vmcam == null) return;
            var bgim = vmcam.GetComponent<BackgroundMainCamImage>();
            if (bgim == null) return;
            bgim.RealizeBackground();
        }

        public void SetScene(SceneSelE newscene)
        {
            var vcamname = mainCamName.Get();
            if (!vidcam.ContainsKey(vcamname))
            {
                vcamname = "Viewer";
            }
            SetMainCameraToVcam(vcamname);
        }
        public void PostTerrainLoadAdjustments()
        {
            AdjustHeightsForTerrain();
        }
        public void InitializeScene(SceneSelE newscene)
        {
            DelVidcams();
            backType.GetInitial();
            RealizeBackground();
            mainCamName.GetInitial();
            //string mcamvcam = "";
            switch (newscene)
            {
                case SceneSelE.MsftCoreCampus:
                case SceneSelE.MsftB19focused:
                    //Debug.Log("Making cams for MsftCore");
                    MakeVidcams("Ms_c");
                    //mcamvcam = "Ms_Redwg_KM-48";
                    break;
                case SceneSelE.MsftRedwest:
                    MakeVidcams("Ms_Redw");
                    //mcamvcam = "Ms_Redwg_KM-48";
                    break;
                case SceneSelE.Eb12:
                case SceneSelE.Eb12small:
                    MakeVidcams("Eb");
                    //mcamvcam = "Eb_vc_frontdoor";
                    break;
                case SceneSelE.Tukwila:
                    MakeVidcams("Tuk");
                    //mcamvcam = "Eb_vc_frontdoor";
                    break;
                default:
                case SceneSelE.None:
                    break;
            }
            vidcamlist.Insert(0,"Viewer");
        }
        public bool toggleFreeFly;
        public FreeFlyCam ffc = null;
        public bool inFreeFly = false;
        public bool InFreeFly()
        {
            return inFreeFly;
        }
        public bool ToggleFreeFly()
        {
            if (!inFreeFly)
            {
                Debug.Log($"VidCamMan.toggleFreeFly - Adding FreeFlyCam");
                //var mcamgo = Camera.main.gameObject;
                var curcam = GetCurrentCamera();
                //ffc = vmcamgo.AddComponent<FreeFlyCam>();
                ffc = curcam.gameObject.AddComponent<FreeFlyCam>();
            }
            else
            {
                if (ffc != null)
                {
                    Debug.Log($"VidCamMan.toggleFreeFly - Destroying FreeFlyCam");
                    Destroy(ffc);
                }
                ffc = null;
            }
            inFreeFly = !inFreeFly;
            return inFreeFly;
        }
        public List<string> GetCameraOptions()
        {
            return vidcamlist;
        }
        public void SetMainCameraToVcam(string mcamvcam)
        {
            Debug.Log($"SetMainCamToVcam:{mcamvcam}");
            var camsetok = false;
            if (mcamvcam == "Viewer")
            {
                var viewercam = Aiskwk.Map.Viewer.GetViewerCamera();
                if (viewercam != null)
                {
                    vmcam.transform.position = viewercam.gameObject.transform.position;
                    vmcam.transform.rotation = viewercam.gameObject.transform.rotation;
                    lastcamset = mcamvcam;
                    vmcamgo.SetActive(false);
                    camsetok = true;
                }
                else
                {
                    Debug.LogWarning($"VidcamMan could not find viewercam for Viewer object");
                    if (vidcam.Count > 0)
                    {
                        var keys = new List<string>(vidcam.Keys);
                        mcamvcam = keys[0];
                    }
                }
            }
            if (!camsetok && vidcam.ContainsKey(mcamvcam))
            {
                vmcamgo.SetActive(true);
                var vcam = vidcam[mcamvcam];
                vmcam.transform.position = vcam.transform.position;
                vmcam.transform.localRotation = vcam.transform.localRotation;
                vmcam.depth = 1;
                vmcam.fieldOfView = vcam.camfov;
                lastcamset = mcamvcam;
                vmcam.gameObject.name = "vc-" + mcamvcam;
                if (vcam.camimage != "")
                {
                    var bgim = vmcam.GetComponent<BackgroundMainCamImage>();
                    if (bgim == null)
                    {
                        bgim = vmcam.gameObject.AddComponent<BackgroundMainCamImage>();
                    }
                    bgim.imageName = vcam.camimage;
                    bgim.showBackground = true;
                    bgim.showSpheres = false;
                }
            }
            else
            {
                if (mcamvcam != "Viewer")
                {
                    Debug.LogWarning($"Camera name:{mcamvcam} not found - number of cams defined:{vidcam.Count}");
                }
            }
            vmcam.gameObject.name = "vc-" + mcamvcam;
        }
        public void SetMainCameraToCam(Camera cam)
        {
            vmcam.transform.position = cam.transform.position;
            //mcam.transform.localRotation = cam.transform.localRotation*iquat;
            vmcam.transform.localRotation = cam.transform.localRotation;
            vmcam.depth = cam.depth;
            vmcam.fieldOfView = cam.fieldOfView;
            vmcam.clearFlags = cam.clearFlags;
            vmcam.backgroundColor = cam.backgroundColor;
            var bgim = vmcam.GetComponent<BackgroundMainCamImage>();
            if (bgim)
            {
                Destroy(bgim);
            }
            var qt = vmcam.transform.Find("Quad");
            if (qt)
            {
                Destroy(qt.gameObject);
            }
            //mcam.fieldOfView = vcam.camfov;
        }
        public void SetSceneCamToMainCam()
        {
#if UNITY_EDITOR
            if (vmcam != null)
            {
                var svcam = UnityEditor.SceneView.lastActiveSceneView.camera;
                vmcam.transform.position = svcam.transform.position;
                vmcam.transform.localRotation = svcam.transform.localRotation;
                vmcam.depth = svcam.depth;
                vmcam.fieldOfView = svcam.fieldOfView;
                lastcamset = "SceneCam";
                var bgim = vmcam.GetComponent<BackgroundMainCamImage>();
                if (bgim)
                {
                    Destroy(bgim);
                }
                var qt = vmcam.transform.Find("Quad");
                if (qt)
                {
                    Destroy(qt.gameObject);
                }
            }
#endif
        }
        public void SetMainCamToSceneCam()
        {
#if UNITY_EDITOR
            if (vmcam != null)
            {
                // There are limitations -  see this for details: https://forum.unity.com/threads/moving-scene-view-camera-from-editor-script.64920/
                var svcam = UnityEditor.SceneView.lastActiveSceneView.camera;
                svcam.transform.position = vmcam.transform.position;
                svcam.transform.localRotation = vmcam.transform.localRotation;
                //svcam.depth = mcam.depth;
                //svcam.fieldOfView = mcam.fieldOfView;
                UnityEditor.SceneView.lastActiveSceneView.AlignViewToObject(svcam.transform);
                // lastcamset = "SceneCam";
                var bgim = vmcam.GetComponent<BackgroundMainCamImage>();
                if (bgim)
                {
                    Destroy(bgim);
                }
                var qt = vmcam.transform.Find("Quad");
                if (qt)
                {
                    Destroy(qt.gameObject);
                }
            }
#endif
        }
        public Camera GetCurrentCamera()
        {
            var rv = vmcam;
            if (lastcamset=="Viewer")
            {
                rv = Aiskwk.Map.Viewer.GetViewerCamera();
            }
            return rv;
        }
        public void DelVidcams()
        {
            //  Debug.Log("DelVidcams called");
            var keynamelist = new List<string>(vidcam.Keys);
            keynamelist.ForEach(name => DelVidcam(name));
            vidcam = new Dictionary<string, Vidcam>();
            vidcamlist = new List<string>();
        }
        List<string> vidcamlist = new List<string>();
        public void MakeVidcams(string filtername)
        {
            vidcamlist = Vidcam.GetVidcamNames(filtername);
            //Debug.Log($"Making vidcams n:{vidcamlist.Count}");
            vidcamlist.ForEach(item => MakeVidcam(item));
        }
        public void AdjustHeightsForTerrain()
        {
            foreach( var vc in vidcam.Values)
            {
                vc.AdjustHeight();
            }
        }

        public void MakeVidcam(string name)
        {
            //Debug.Log("$Making vidcam:{name}");
            var vgo = new GameObject(name);
            vgo.SetActive( false );
            vgo.transform.parent = this.transform;
            var vc = vgo.AddComponent<Vidcam>();
            AddVidcam(vc);
            vc.AddDetail(this, vgo );
        }
        public void DelVidcam(string name)
        {
            //Debug.Log($"Deleting Vidcam {name}");
            //var go = GameObject.Find(name);
            var vc = vidcam[name];
            //vc.Empty(); // destroys game object as well
            vidcam.Remove(name);
        }
        public Vidcam GetVidcam(string vcname)
        {
            if (!vidcam.ContainsKey(vcname))
            {
                Debug.LogError($"Bad Vidcam lookup:{vcname}");
                return null;
            }
            return vidcam[vcname];
        }

        public bool VidcamExists(string vcname)
        {
            return vidcam.ContainsKey(vcname);  
        }

        public void AddVidcam(Vidcam Vidcam)
        {
            if (vidcam.ContainsKey(Vidcam.name))
            {
                Debug.LogError($"Tried to add duplicate Vidcam:{Vidcam.name}");
                return;
            }
            vidcamnames.Add(Vidcam.name);
            vidcamnames.Sort();
            vidcam[Vidcam.name] = Vidcam;
            //Debug.Log("Added bld " + Vidcam.name);
        }

        public List<string> GetVidcamList()
        {
            return vidcamnames;
        }
        public int GetVidcamCount()
        {
            return vidcamnames.Count;
        }

        public void DeleteGos()
        {
            foreach (var vcname in vidcam.Keys)
            {
                vidcam[vcname].DeleteGos();
            }
        }
        public void CreateGos()
        {
            foreach (var vcname in vidcam.Keys)
            {
                vidcam[vcname].CreateGos();
            }
        }
        public void RefreshGos()
        {
            DeleteGos();
            CreateGos();
        }

        // Use this for initialization
        void Start()
        {
            sman = FindObjectOfType<SceneMan>();

#if MOBILE_INPUT
        var mc = GameObject.Find("Main Camera");
            if (mc != null)
            {
                mc.AddComponent<TouchCamera>();
                //Debug.Log("Added TouchCamera Component to " + mc.name);
            }
            else
            {
                Debug.Log("No Main Camera found");
            }
#endif
        }

        public float savefreqsecs = 5;
        public string imagesavepath;
        public bool saveContinuouslyOnPlay = false;
        public bool saveMainCamOnce = false;
        public int numMainCamSaves = 0;
        public bool saveMainCamContinuously = false;
        float lastcamerashotsave;

        public string GetImageSaveFileName(string camname)
        {
            lastcamerashotsave = Time.time;
            var spath = sman.simrundir + sman.imagesdir;
            System.IO.Directory.CreateDirectory(spath);
            var tstmp = GraphAlgos.GraphUtil.LeadZeroFloat(lastcamerashotsave, 5, 1);
            var fname = spath + camname + "_" + tstmp + ".jpg";
            return fname;
        }
        public void SaveMainCameraShot(string camname)
        {
            // https://forum.unity.com/threads/how-to-save-manually-save-a-png-of-a-camera-view.506269/
            if (vmcam != null)
            {
                var fname = GetImageSaveFileName(camname);

                var savetex = vmcam.targetTexture;
                var rendtex = new RenderTexture(Screen.width, Screen.height, 24);
                vmcam.targetTexture = rendtex;
                var currentRT = RenderTexture.active;
                RenderTexture.active = vmcam.targetTexture;

                vmcam.Render();

                Texture2D image = new Texture2D(vmcam.targetTexture.width, vmcam.targetTexture.height);
                image.ReadPixels(new Rect(0, 0, vmcam.targetTexture.width, vmcam.targetTexture.height), 0, 0);
                image.Apply();
                RenderTexture.active = currentRT;

                var bytes = image.EncodeToJPG();
                Destroy(image);
                Debug.Log("Writing " + fname+" bytes:" + bytes.Length+" time:"+lastcamerashotsave.ToString("f1"));

                vmcam.targetTexture = savetex;

                System.IO.File.WriteAllBytes(fname, bytes);
                numMainCamSaves++;
            }
            else
            {
                Debug.LogWarning("No Main Camera found");
            }
        }

        public void SaveMainCameraShotContinous(string camname)
        {
            // https://forum.unity.com/threads/how-to-save-manually-save-a-png-of-a-camera-view.506269/
            var gap = Time.time - lastcamerashotsave;
            if (gap > savefreqsecs)
            {
                SaveMainCameraShot(camname);
            }
        }

        // Update is called once per frame
        void Update()
        {
            //foreach( var vc in vidcam.Values)
            //{
            //    vc.SaveCameraShot(filesavepath);
            //}
            if (saveMainCamOnce)
            {
                var maincamgo =  GameObject.Find("Main Camera");
                var maincam = maincamgo.GetComponent<Camera>();
                SaveMainCameraShot(lastcamset);
                saveMainCamOnce = false;
                sman.frman.saveLabelListOnce = true;
            }
            if (saveMainCamContinuously)
            {
                SaveMainCameraShotContinous(lastcamset);
            }
            if (this.setMainCamToSceneCam)
            {
#if UNITY_EDITOR
                this.SetMainCamToSceneCam();
#endif
                setMainCamToSceneCam = false;
            }
            if (this.setSceneCamToMainCam)
            {
#if UNITY_EDITOR
                this.SetSceneCamToMainCam();
#endif
                setSceneCamToMainCam = false;
            }
            if (toggleFreeFly)
            {
                ToggleFreeFly();
                toggleFreeFly = false;
            }
        }
    }
}
