using System.Collections.Generic;
using UnityEngine;
using System;
using UxUtils;

namespace CampusSimulator
{


    public class VidcamMan : MonoBehaviour
    {
        public SceneMan sman;

        public string lastcamset = "MainCam";
        public bool setMainCamToSceneCam = false;
        public bool setSceneCamToMainCam = false;


        public UxSetting<string> mainCamName = new UxSetting<string>("MainCamName","NoCameraChosen");

        Dictionary<string, Vidcam> vidcam = new Dictionary<string, Vidcam>();
        List<string> vidcamnames = new List<string>(); // maintain a sorted list 

        public enum BackGroundTypeE { UiFrame, Quad, None }
        public UxEnumSetting<BackGroundTypeE> backType = new UxEnumSetting<BackGroundTypeE>("BackgroundType",BackGroundTypeE.None);

        public void RealizeBackground()
        {
            var mcam = Camera.main;
            if (mcam == null) return;
            var bgim = mcam.GetComponent<BackgroundMainCamImage>();
            if (bgim == null) return;
            bgim.RealizeBackground();
        }
        public void SetScene(SceneSelE newregion)
        {
            backType.GetInitial();
            RealizeBackground();
            mainCamName.GetInitial();
            DelVidcams();
            //string mcamvcam = "";
            switch (newregion)
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
            SetMainCameraToVcam(mainCamName.Get());
        }
        public bool toggleFreeFly;
        public FreeFlyCam ffc = null;
        public bool inFreeFly = false;
        public bool ToggleFreeFly()
        {
            if (!inFreeFly)
            {
                //Debug.Log("   VidCamMan.toggleFreeFly - Adding FreeFlyCam");
                var mcamgo = Camera.main.gameObject;
                ffc = mcamgo.AddComponent<FreeFlyCam>();
            }
            else
            {
                //Debug.Log("   VidCamMan.toggleFreeFly - Destroying FreeFlyCam");
                Destroy(ffc);
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
            //Debug.Log("SetMainCamToVcam: " + mcamvcam);
            var mcam = Camera.main;
            if (mcam!=null)
            {
                if (vidcam.ContainsKey(mcamvcam))
                {
                    //Debug.Log("doing it sybil");
                    var vcam = vidcam[mcamvcam];
                    mcam.transform.position = vcam.transform.position;
                    mcam.transform.localRotation = vcam.transform.localRotation;
                    mcam.depth = 1;
                    mcam.fieldOfView = vcam.camfov;
                    lastcamset = mcamvcam;
                    if (vcam.camimage != "")
                    {
                        var bgim = mcam.GetComponent<BackgroundMainCamImage>();
                        if (bgim==null)
                        {
                            bgim = mcam.gameObject.AddComponent<BackgroundMainCamImage>();
                        }
                        bgim.imageName = vcam.camimage;
                        bgim.showBackground = true;
                        bgim.showSpheres = false;
                    }
                }
                else
                {
                    Debug.Log("Bad camera name:" + mcamvcam);
                }
            }
        }
        public void SetMainCameraToCam(Camera cam)
        {
            var mcam = Camera.main;
            //var camparent = cam.transform.parent;
            //Quaternion quat = Quaternion.identity;
            //Quaternion iquat = Quaternion.identity;
            //if (camparent)
            //{
            //    quat = camparent.transform.localRotation;
            //    iquat = Quaternion.Inverse(quat);
            //    var qiq = quat * iquat;
            //    Debug.Log("quat:" + quat.ToString()+"  Iquat:"+iquat.ToString()+"  qiq:"+qiq.ToString());
            //}
            mcam.transform.position = cam.transform.position;
            //mcam.transform.localRotation = cam.transform.localRotation*iquat;
            mcam.transform.localRotation = cam.transform.localRotation;
            mcam.depth = cam.depth;
            mcam.fieldOfView = cam.fieldOfView;
            mcam.clearFlags = cam.clearFlags;
            mcam.backgroundColor = cam.backgroundColor;
            var bgim = mcam.GetComponent<BackgroundMainCamImage>();
            if (bgim)
            {
                Destroy(bgim);
            }
            var qt = mcam.transform.Find("Quad");
            if (qt)
            {
                Destroy(qt.gameObject);
            }
            //mcam.fieldOfView = vcam.camfov;
        }

        //#if UNITY_EDITOR
        //        var svc = UnityEditor.SceneView.lastActiveSceneView.camera;
        //            if (svc!=null)
        //            {
        //                var t = svc.transform;
        //        msg += "\nScene Cam Pos:" + t.position.ToString("F1");
        //                msg += "\nScene Cam Rot:" + t.rotation.eulerAngles.ToString("F1");
        //                msg += "\nScene Cam FOV:" + svc.fieldOfView.ToString("F1");
        //            }
        //            else
        //            {
        //                msg += "\nScene Cam lastActiveSceneView is null";
        //            }
        //#endif

        public void SetSceneCamToMainCam()
        {
#if UNITY_EDITOR
            var mcam = Camera.main;
            if (mcam != null)
            {
                var svcam = UnityEditor.SceneView.lastActiveSceneView.camera;
                mcam.transform.position = svcam.transform.position;
                mcam.transform.localRotation = svcam.transform.localRotation;
                mcam.depth = svcam.depth;
                mcam.fieldOfView = svcam.fieldOfView;
                lastcamset = "SceneCam";
                var bgim = mcam.GetComponent<BackgroundMainCamImage>();
                if (bgim)
                {
                    Destroy(bgim);
                }
                var qt = mcam.transform.Find("Quad");
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
            var mcam = Camera.main;
            if (mcam != null)
            {
                // There are limitations -  see this for details: https://forum.unity.com/threads/moving-scene-view-camera-from-editor-script.64920/
                var svcam = UnityEditor.SceneView.lastActiveSceneView.camera;
                svcam.transform.position = mcam.transform.position;
                svcam.transform.localRotation = mcam.transform.localRotation;
                //svcam.depth = mcam.depth;
                //svcam.fieldOfView = mcam.fieldOfView;
                UnityEditor.SceneView.lastActiveSceneView.AlignViewToObject(svcam.transform);
                // lastcamset = "SceneCam";
                var bgim = mcam.GetComponent<BackgroundMainCamImage>();
                if (bgim)
                {
                    Destroy(bgim);
                }
                var qt = mcam.transform.Find("Quad");
                if (qt)
                {
                    Destroy(qt.gameObject);
                }
            }
#endif
        }
        public void DelVidcams()
        {
            //  Debug.Log("DelVidcams called");
            var namelist = new List<string>(vidcam.Keys);
            namelist.ForEach(name => DelVidcam(name));
        }
        List<string> vidcamlist = new List<string>();
        public void MakeVidcams(string filtername)
        {
            vidcamlist = Vidcam.GetVidcamNames(filtername);
            //Debug.Log("Making vidcams n:" + vidcamlist.Count);
            vidcamlist.ForEach(item => MakeVidcam(item));
        }
        public void MakeVidcam(string name)
        {
            //Debug.Log("  Making vidcam " + name);
            var vgo = new GameObject(name);
            vgo.SetActive( false );
            vgo.transform.parent = this.transform;
            var vc = vgo.AddComponent<Vidcam>();
            AddVidcam(vc);
            vc.AddDetail(this, vgo );
            //Debug.Log("  Made vidcam " + name);
        }
        public void DelVidcam(string name)
        {
            //Debug.Log("Deleting Vidcam " + name);
            //var go = GameObject.Find(name);
            var vc = vidcam[name];
            //vc.Empty(); // destroys game object as well
            vidcam.Remove(name);
        }
        public Vidcam GetVidcam(string name)
        {
            if (!vidcam.ContainsKey(name))
            {
                Debug.Log("Bad Vidcam lookup:" + name);
                return null;
            }
            return vidcam[name];
        }

        public void AddVidcam(Vidcam Vidcam)
        {
            if (vidcam.ContainsKey(Vidcam.name))
            {
                Debug.Log("Tried to add duplicate Vidcam:" + Vidcam.name);
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
            //   SetRegion(RegionSelE.MsftCoreCampus);
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
            //var ncs = numMainCamSaves.ToString("D3");
            var spath = sman.simrundir + sman.imagesdir;
            System.IO.Directory.CreateDirectory(spath);
            var tstmp = GraphAlgos.GraphUtil.LeadZeroFloat(lastcamerashotsave, 5, 1);
            var fname = spath + camname + "_" + tstmp + ".jpg";
            return fname;
        }
        public void SaveMainCameraShot(string camname)
        {
            // https://forum.unity.com/threads/how-to-save-manually-save-a-png-of-a-camera-view.506269/
            var mcam = Camera.main;
            if (mcam != null)
            {
                var fname = GetImageSaveFileName(camname);

                var savetex = mcam.targetTexture;
                var rendtex = new RenderTexture(Screen.width, Screen.height, 24);
                mcam.targetTexture = rendtex;
                var currentRT = RenderTexture.active;
                RenderTexture.active = mcam.targetTexture;

                mcam.Render();

                Texture2D image = new Texture2D(mcam.targetTexture.width, mcam.targetTexture.height);
                image.ReadPixels(new Rect(0, 0, mcam.targetTexture.width, mcam.targetTexture.height), 0, 0);
                image.Apply();
                RenderTexture.active = currentRT;

                var bytes = image.EncodeToJPG();
                Destroy(image);
                Debug.Log("Writing " + fname+" bytes:" + bytes.Length+" time:"+lastcamerashotsave.ToString("f1"));

                mcam.targetTexture = savetex;

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
