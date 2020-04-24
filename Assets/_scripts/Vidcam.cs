using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CampusSimulator
{
    public class Vidcam : MonoBehaviour
    {
        VidcamMan vm;
        public GameObject vidgo = null;
        public bool saveimages;
        public float saveperiodsecs;
        public float lastsave;
        public float storagepath;
        public string cameraname;
        public Camera vcamera;
        public string shortname;

        public Vector3 campos;
        public Vector3 camlookat;
        public Vector3 camrotate;
        public float camfov;
        public string camimage;
        public string cambackhwname;
        public float camimagelambda;
        public int camimpixx;
        public int camimpixy;

        public enum CamOrientTypeE { lookat, rotate };
        public CamOrientTypeE camorienttype;

        System.Random ranman = new System.Random();

        public bool makeMainCamera = false;

        BackgroundMainCamImage bgim = null;


        public static List<string> GetVidcamNames(string filter)
        {
            var l = new List<string>
            {
                "Eb_vc_mwinview",
                "Eb_vc_frontdoor",
                "Eb_vc_o_xdir",
                "Eb_vc_o_zdir",
                "Ms_Redwg_KM-47",
                "Ms_Redwg_KM-48",
                "Ms_Redwg_KM-51",
                "Ms_Redwg_KM-52",
                "Ms_Redwg_KM-53",
                "Ms_Redwg_KM-54",
                "Ms_Redwg_Birdseye",
                "Ms_Redwg_Entrance",
                "Ms_Redwg_Garage_Birdseye",
                "Tuk_SouthCentral",
                "Ms_c_B19_raspipole",
                "Ms_c_B19_lobbyhigh",
                "Ms_c_B19_topview",
                "Ms_c_B19_bird1",
                "Ms_c_B19_lobby",
                "Ms_c_B11_raspipole",
            };
            l.RemoveAll(item => !item.StartsWith(filter));
            l.Add("Viewer");
            return l;
        }
        //public void AddCameraMarker(string name, Vector3 campos, string clrname)
        //{
        //    var pname = "CameraMarkers";
        //    var parent = GameObject.Find(pname);
        //    if (parent == null)
        //    {
        //        parent = new GameObject(pname);
        //    }
        //    var go = GraphAlgos.GraphUtil.CreateMarkerSphere(name, campos, clr: clrname, size: 0.4f);
        //    //var bcs = go.AddComponent<BundleCalibrateSphere>();
        //    //bcs.origin = org;
        //    go.transform.parent = parent.transform;
        //}
        public void AddCameraMarker(string name, Vector3 cpt, string clrname)
        {
            var cman = GameObject.FindObjectOfType<CalibMan>();
            if (cman != null)
            {
                cman.AddCalibMarker(name, cpt.x, cpt.y, cpt.z, "purple");
            }
        }

        public void AddDetail(VidcamMan vm, GameObject vgo)
        {
            this.vm = vm;
            this.vidgo = vgo;
            campos = Vector3.zero;
            camlookat = Vector3.forward;
            camrotate = Vector3.zero;
            camimage = "";
            cambackhwname = "";
            camorienttype = CamOrientTypeE.lookat;
            vcamera = vidgo.AddComponent<Camera>();
            var makecammarker = true;
            if (makecammarker)
            {
                var vcmarker = GraphAlgos.GraphUtil.CreateMarkerSphere(name, Vector3.zero);
                vcmarker.transform.parent = vcamera.transform;
            }
            bool enablecams = false;
            camimagelambda = 0.999f;
            switch (name)
            {
                case "Tuk_SouthCentral":
                    campos = new Vector3(1.0f, 1.5f, 0);
                    camrotate = new Vector3(1.9f, -169f, 0);
                    camfov = 52f;
                    camorienttype = CamOrientTypeE.rotate;
                    camimage = "tuk_southcentral";
                    camimpixx = 2048;
                    camimpixy = 1536;
                    cambackhwname = "SamsungTabS3";
                    //camlookat = new Vector3(18, 2, 0);
                    //camorienttype = CamOrientTypeE.lookat;
                    break;
                case "Eb_vc_mwinview":
                    campos = new Vector3(17.8f, 4.5f, 30.5f);
                    //camrotate = new Vector3(11, -180f, 0);
                    camrotate = new Vector3(4.3f, 173f, 1.6f);
                    camfov = 41f;
                    camorienttype = CamOrientTypeE.rotate;
                    camimage = "Eb12_mwinview";
                    camimpixx = 1920;
                    camimpixy = 1080;
                    camimagelambda = 0.05f;
                    cambackhwname = "Realo";
                    //camlookat = new Vector3(18, 2, 0);
                    //camorienttype = CamOrientTypeE.lookat;
                    break;
                case "Eb_vc_frontdoor":
                    campos = new Vector3(19f, 2.4f, 29);
                    //camrotate = new Vector3(11, -180f, 0);
                    camrotate = new Vector3(4.6f, -178.5f, -0.5f);
                    camfov = 47.0f;
                    camorienttype = CamOrientTypeE.rotate;
                    camimage = "Eb12_frontdoor_";
                    camimpixx = 2048;
                    camimpixy = 1536;
                    camimagelambda = 0.03888f;
                    cambackhwname = "SamsungTabS3";

                    //camlookat = new Vector3(18, 2, 0);
                    //camorienttype = CamOrientTypeE.lookat;
                    break;
                case "Eb_vc_o_xdir":
                    campos = new Vector3(0,1.0f,0);
                    camrotate = new Vector3(2.5f,87.5f,0);
                    camfov = 48.5f;
                    camorienttype = CamOrientTypeE.rotate;
                    camimage = "Eb12_origin_xdir_";
                    camimpixx = 2048;
                    camimpixy = 1536;
                    cambackhwname = "SamsungTabS3";
                    //camlookat = new Vector3(18, 2, 0);
                    //camorienttype = CamOrientTypeE.lookat;
                    break;
                case "Eb_vc_o_zdir":
                    campos = new Vector3(0, 1.74f, 0);
                    camrotate = new Vector3(1.9f, -2, 0);
                    camfov = 38.7f;
                    camorienttype = CamOrientTypeE.rotate;
                    camimage = "Eb12_origin_zdir_";
                    camimpixx = 2048;
                    camimpixy = 1536;
                    cambackhwname = "SamsungTabS3";
                    //camlookat = new Vector3(18, 2, 0);
                    //camorienttype = CamOrientTypeE.lookat;
                    break;
                case "Ms_Redwg_KM-47":
                    campos = new Vector3(-2039.4f, 2.8f, -1175.2f);
                    //camrotate = new Vector3(40f, 100f, 22f);
                    //camfov = 90;
                    camrotate = new Vector3(28.356f, 105.615f, 17.056f);
                    camfov = 67.61f;
                    camorienttype = CamOrientTypeE.rotate;
                    vcamera.enabled = enablecams;
                    vcamera.depth = 0;
                    camimage = "RDG-L3-047";
                    camimpixx = 1600;
                    camimpixy = 1200;
                    AddCameraMarker("km-47", campos, "orange");
                    break;
                case "Ms_Redwg_KM-48":
                    campos = new Vector3(-2035.2f, 3.8f, -1173.5f);
                    //camrotate = new Vector3(23.9f, 163.1f, 0);
                    //camfov = 45;
                    camrotate = new Vector3(21.895f, 163.310f, 0.475f);
                    camfov = 42.51f;
                    //campos = new Vector3(-2038.2f, 3f, -1174.8f);
                    //camrotate = new Vector3(0,149.022f,0);
                    camorienttype = CamOrientTypeE.rotate;
                    vcamera.enabled = enablecams;
                    vcamera.depth = 0;
                    camimage = "RDG-L3-048";
                    camimpixx = 1600;
                    camimpixy = 1200;
                    AddCameraMarker("km-48", campos, "orange");
                    break;
                case "Ms_Redwg_KM-51":
                    campos = new Vector3(-1967.5f, 3f, -1257.4f);
                    //camrotate = new Vector3(-0.434f, -73.955f, 11.601f);
                    //camfov = 60;
                    camrotate = new Vector3(21.686f, -72.275f, 10.303f);
                    camfov = 53.76f;
                    camorienttype = CamOrientTypeE.rotate;
                    vcamera.enabled = enablecams;
                    camimage = "RDG-L3-051";
                    //camimpixx = 636;
                    //camimpixy = 457;
                    camimpixx = 1600;
                    camimpixy = 1200;
                    AddCameraMarker("km-51", campos, "orange");

                    //vcamera.depth = 0;
                    break;
                case "Ms_Redwg_KM-52":
                    campos = new Vector3(-1967.7f, 3f, -1261.3f);
                    //camrotate = new Vector3(0f, -20f, -2f);
                    //camfov = 65;
                    camrotate = new Vector3(32.95f, -25.253f, -9.515f);
                    camfov = 100.33f;
                    camorienttype = CamOrientTypeE.rotate;
                    vcamera.enabled = enablecams;
                    vcamera.depth = 0;
                    camimage = "RDG-L3-052";
                    //camimpixx = 642;
                    //camimpixy = 457;
                    camimpixx = 1600;
                    camimpixy = 1200;
                    AddCameraMarker("km-52", campos, "orange");
                    break;
                case "Ms_Redwg_KM-53":
                    campos = new Vector3(-1983.1f, 3f, -1249.7f);
                    //camrotate = new Vector3(0f, -110f, 0);
                    //camfov = 60;
                    camrotate = new Vector3(11.157f, -113.481f, 1.753f);
                    camfov = 19.35f;
                    camorienttype = CamOrientTypeE.rotate;
                    vcamera.enabled = enablecams;
                    vcamera.depth = 0;
                    camimage = "RDG-L3-053";
                    //camimpixx = 642;
                    //camimpixy = 457;
                    camimpixx = 640;
                    camimpixy = 480;
                    AddCameraMarker("km-53", campos, "orange");
                    break;
                case "Ms_Redwg_KM-54":
                    campos = new Vector3(-1985.7f, 3f, -1267.9f);
                    //camrotate = new Vector3(37f, -20f, 0);
                    //camfov = 75;
                    camrotate = new Vector3(33.106f, -19.711f, -3.407f);
                    camfov = 54.75f;
                    camorienttype = CamOrientTypeE.rotate;
                    vcamera.enabled = enablecams;
                    vcamera.depth = 0;
                    camimage = "RDG-L3-054";
                    //camimpixx = 642;
                    //camimpixy = 457;
                    camimpixx = 2048;
                    camimpixy = 1536;
                    AddCameraMarker("km-54", campos, "orange");
                    break;
                case "Ms_Redwg_Birdseye":
                    campos = new Vector3(-1876.3f, 111.4f, -1113.6f);
                    camrotate = new Vector3(43, -87, 0);
                    camfov = 45;
                    camorienttype = CamOrientTypeE.rotate;
                    vcamera.enabled = enablecams;
                    vcamera.depth = 0;
                    camimage = "";
                    camimpixx = 1600;
                    camimpixy = 1600;
                    break;
                case "Ms_Redwg_Entrance":
                    campos = new Vector3(-2109, 18.4f, -1100);
                    camrotate = new Vector3(17, 113.5f, 0);
                    camfov = 45;
                    camorienttype = CamOrientTypeE.rotate;
                    vcamera.enabled = enablecams;
                    vcamera.depth = 0;
                    camimage = "";
                    camimpixx = 1600;
                    camimpixy = 1600;
                    break;
                case "Ms_Redwg_Garage_Birdseye":
                    campos = new Vector3(-2062.6f, 48.9f, -1150.9f);
                    camrotate = new Vector3(33.4f, 128.0f, 0);
                    camfov = 72.3f;
                    camorienttype = CamOrientTypeE.rotate;
                    vcamera.enabled = enablecams;
                    vcamera.depth = 0;
                    camimage = "";
                    camimpixx = 1600;
                    camimpixy = 1600;
                    break;
                case "Ms_c_B11_raspipole":
                    campos = new Vector3(-131.42f, 3f, 223.8f);
                    camrotate = new Vector3(33.4f, 0, 0);
                    camfov = 60f;
                    camorienttype = CamOrientTypeE.rotate;
                    vcamera.enabled = enablecams;
                    vcamera.depth = 0;
                    camimage = "";
                    camimpixx = 1600;
                    camimpixy = 1600;
                    break;
                case "Ms_c_B19_raspipole":
                    campos = new Vector3(-451.5f, 3f, 98.3f);
                    camrotate = new Vector3(30f, -60f, 0);
                    camfov = 90f;
                    camorienttype = CamOrientTypeE.rotate;
                    vcamera.enabled = enablecams;
                    vcamera.depth = 0;
                    camimage = "";
                    camimpixx = 1600;
                    camimpixy = 1600;
                    break;
                case "Ms_c_B19_lobby":
                    campos = new Vector3(-476.2f, 1.9f, 93.7f);
                    camrotate = new Vector3(0, 40, 0);
                    camfov = 60f;
                    camorienttype = CamOrientTypeE.rotate;
                    vcamera.enabled = enablecams;
                    vcamera.depth = 0;
                    camimage = "";
                    camimpixx = 1600;
                    camimpixy = 1600;
                    break;
                case "Ms_c_B19_lobbyhigh":
                    campos = new Vector3(-469.5f, 17.8f, 95.8f);
                    camrotate = new Vector3(52.9f, 141.2f, 0);
                    camfov = 60f;
                    camorienttype = CamOrientTypeE.rotate;
                    vcamera.enabled = enablecams;
                    vcamera.depth = 0;
                    camimage = "";
                    camimpixx = 1600;
                    camimpixy = 1600;
                    break;
                case "Ms_c_B19_bird1":
                    campos = new Vector3(-421.4f, 25.2f, 120.3f);
                    camrotate = new Vector3(17.3f, 246.2f, 0);
                    camfov = 60f;
                    camorienttype = CamOrientTypeE.rotate;
                    vcamera.enabled = enablecams;
                    vcamera.depth = 0;
                    camimage = "";
                    camimpixx = 1600;
                    camimpixy = 1600;
                    break;
                case "Ms_c_B19_topview":
                    campos = new Vector3(-480.2f, 61.0f, 91.4f);
                    camrotate = new Vector3(83.4f, 71.6f, 0);
                    camfov = 60f;
                    camorienttype = CamOrientTypeE.rotate;
                    vcamera.enabled = enablecams;
                    vcamera.depth = 0;
                    camimage = "";
                    camimpixx = 1600;
                    camimpixy = 1600;
                    break;
            }

            vcamera.fieldOfView = camfov;
            vcamera.transform.position = campos;
            if (camorienttype == CamOrientTypeE.lookat)
            {
                Debug.Log("Legacy");
                //vcamera.transform.LookAt(camlookat);
            }
            else
            {
                vcamera.transform.Rotate(camrotate);
            }
            if (camimage!="")
            {
                bgim = vidgo.AddComponent<BackgroundMainCamImage>();
                bgim.imageName = camimage;
                bgim.showBackground = false;
                bgim.showSpheres = false;
            }
        }
        public void SaveCameraShot(string path)
        {
            // https://forum.unity.com/threads/how-to-save-manually-save-a-png-of-a-camera-view.506269/
            if (!saveimages) return;
            var gap = Time.time - lastsave;
            if (gap > vm.savefreqsecs)
            {
                lastsave = Time.time;
                GraphAlgos.GraphUtil.SaveCameraShot(vcamera,camimpixx,camimpixy, path, name, adddatetime: true);
            }
        }

        public void CreateGos()
        {

        }
        public void DeleteGos()
        {

        }

        private void Start()
        {
            lastsave = -vm.savefreqsecs;
        }

        // Update is called once per frame
        void Update()
        {
            if (makeMainCamera)
            {
                Debug.Log("makeMainCamera triggered:"+name);
                vm.SetMainCameraToVcam(name);
                makeMainCamera = false;
            }
            
            if (vidgo.activeInHierarchy) // dead code?
            {
                SaveCameraShot(vm.imagesavepath);
            }
        }
    }
}