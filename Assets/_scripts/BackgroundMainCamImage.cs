using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphAlgos;
using UnityEngine.UI;


namespace CampusSimulator
{
    public class BackgroundMainCamImage : MonoBehaviour
    {
        private SceneMan sman;
        private VidcamMan vman;
        public Camera cam;
        public Vidcam vcam;
        public GameObject camgo;
        public string nname;
        public RawImage rawimage;
        public string imageName = "Eb12_frontdoor_nzdir_sj";
        public bool showBackground = true;
        public bool showSpheres = false;
        GameObject bcango = null;
        GameObject quadgo = null;
        public float lamb = 0.999f;

        // Start is called before the first frame update
        void Start()
        {
            LinkObjectsAndComponents();
        }

        void LinkObjectsAndComponents()
        {
            sman = FindObjectOfType<SceneMan>();
            vman = sman.vcman;
            camgo = gameObject;
            cam = gameObject.GetComponent<Camera>();
            if (cam == null)
            {
                Debug.LogError($"BackgroundMainCamImage could not find Camera Component on {name}");
            }
            nname = cam.name;

            if (vman.VidcamExists(vman.lastcamset))
            {
                vcam = vman.GetVidcam(vman.lastcamset);
                if (vcam == null)
                {
                    Debug.LogError($"BackgroundMainCamImage could not find Vidcam \"{vman.lastcamset}\" on go {name}");
                    return;
                }
                lamb = vcam.camimagelambda;
            }
        }
        void DeactivateBackgroundImage()
        {
            if (bcango != null)
            {
                Destroy(bcango);
                bcango = null;
            }
            if (quadgo != null)
            {
                Destroy(quadgo);
                quadgo = null;
            }
        }

        Texture2D LoadImage()
        {
            var imname = imageName;
            if (imname.EndsWith("_"))
            {
                if (Screen.width > Screen.height)
                {
                    imname += "land_sj";
                }
                else
                {
                    imname += "port_sj";
                }
            }
            var fullimname = "Images/" + imname;
            //Debug.Log("BackImage loading:" + fullimname);
            var tex = Resources.Load<Texture2D>(fullimname );
            if (tex==null)
            {
                Debug.LogError($"BackgroundMainCamImage LoadImage failed to load:{fullimname}");
            }
            //else
            //{
            //    Debug.Log("Loaded xpix:"+tex.width+" ypix:"+tex.height);
            //}
            return tex;
        }


        void AttachFrameImageToBackground()
        {
            DeactivateBackgroundImage();
            var o = 0.5f;
            var w = Screen.width + 0.5f;
            var h = Screen.height + 0.5f;
            var gap = 0.1f;
            var zdist = cam.farClipPlane - gap;

            var pos = cam.transform.position;
            var pos00 = cam.ScreenToWorldPoint(new Vector3(o, o, zdist));
            var pos01 = cam.ScreenToWorldPoint(new Vector3(o, h, zdist));
            var pos10 = cam.ScreenToWorldPoint(new Vector3(w, o, zdist));
            var pos11 = cam.ScreenToWorldPoint(new Vector3(w, h, zdist));
            var poscn = cam.transform.position + cam.transform.forward * zdist;

 
            pos00 = Vector3.Lerp(pos, pos00, lamb);
            pos01 = Vector3.Lerp(pos, pos01, lamb);
            pos10 = Vector3.Lerp(pos, pos10, lamb);
            pos11 = Vector3.Lerp(pos, pos11, lamb);
            poscn = Vector3.Lerp(pos, poscn, lamb);

            bcango = new GameObject("bgcanvas");
            var bcan = bcango.AddComponent<Canvas>();
            bcan.renderMode = RenderMode.WorldSpace;
            bcan.transform.position = poscn;
            bcan.transform.localRotation = camgo.transform.localRotation;
            bcan.transform.parent = camgo.transform;
            bcan.transform.localScale = new Vector3(Vector3.Magnitude(pos10 - pos00) / 100, Vector3.Magnitude(pos01 - pos00) / 100, 1);

            if (showSpheres)
            {
                var sgo00 = GraphUtil.CreateMarkerSphere("csph-00", pos00, 20, "purple");
                sgo00.transform.parent = bcango.transform;
                var sgo01 = GraphUtil.CreateMarkerSphere("csph-01", pos01, 20, "purple");
                sgo01.transform.parent = bcango.transform;
                var sgo10 = GraphUtil.CreateMarkerSphere("csph-10", pos10, 20, "purple");
                sgo10.transform.parent = bcango.transform;
                var sgo11 = GraphUtil.CreateMarkerSphere("csph-11", pos11, 20, "purple");
                sgo11.transform.parent = bcango.transform;
                var sgo = GraphUtil.CreateMarkerSphere("csph-cen", poscn, 30, "purple");
                sgo.transform.parent = bcango.transform;
            }

            if (showBackground)
            {
                var tex = LoadImage();
                rawimage = bcango.AddComponent<RawImage>();
                rawimage.texture = tex;
                rawimage.transform.position = poscn;
                rawimage.transform.parent = camgo.transform;
            }
        }
        void AttachQuadImageToBackground()
        {
            DeactivateBackgroundImage();
            var o = 0.5f;
            var w = Screen.width + 0.5f;
            var h = Screen.height + 0.5f;
            var gap = 0.1f;
            var zdist = cam.farClipPlane - gap;

            var pos = cam.transform.position;
            var pos00 = cam.ScreenToWorldPoint(new Vector3(o, o, zdist));
            var pos01 = cam.ScreenToWorldPoint(new Vector3(o, h, zdist));
            var pos10 = cam.ScreenToWorldPoint(new Vector3(w, o, zdist));
            var pos11 = cam.ScreenToWorldPoint(new Vector3(w, h, zdist));
            var poscn = cam.transform.position + cam.transform.forward * zdist;



            pos00 = Vector3.Lerp(pos, pos00, lamb);
            pos01 = Vector3.Lerp(pos, pos01, lamb);
            pos10 = Vector3.Lerp(pos, pos10, lamb);
            pos11 = Vector3.Lerp(pos, pos11, lamb);
            poscn = Vector3.Lerp(pos, poscn, lamb);

            quadgo = GameObject.CreatePrimitive(PrimitiveType.Quad);
            quadgo.transform.position = poscn;
            quadgo.transform.localRotation = camgo.transform.localRotation;
            quadgo.transform.parent = camgo.transform;
            quadgo.transform.localScale = new Vector3(Vector3.Magnitude(pos10 - pos00), Vector3.Magnitude(pos01 - pos00), 1);

            if (showSpheres)
            {
                var sgo00 = GraphUtil.CreateMarkerSphere("csph-00", pos00, 20, "purple");
                sgo00.transform.parent = quadgo.transform;
                var sgo01 = GraphUtil.CreateMarkerSphere("csph-01", pos01, 20, "purple");
                sgo01.transform.parent = quadgo.transform;
                var sgo10 = GraphUtil.CreateMarkerSphere("csph-10", pos10, 20, "purple");
                sgo10.transform.parent = quadgo.transform;
                var sgo11 = GraphUtil.CreateMarkerSphere("csph-11", pos11, 20, "purple");
                sgo11.transform.parent = quadgo.transform;
                var sgo = GraphUtil.CreateMarkerSphere("csph-cen", poscn, 30, "purple");
                sgo.transform.parent = quadgo.transform;
            }

            bool addLight = false;
            if (addLight)
            {
                var lightob = new GameObject("quadlight");
                var dlight = lightob.AddComponent<Light>();
                dlight.type = LightType.Directional;
                lightob.transform.SetParent(quadgo.transform);
                lightob.transform.localRotation = Quaternion.Euler(66, 0, 0);
            }

            if (showBackground)
            {
                var tex = LoadImage();
                var rend = quadgo.GetComponent<Renderer>();
                rend.material.mainTexture = tex;
            }
        }
        public void RealizeBackground()
        {
            if (vman == null) return;
            var bg = vman.backType.Get();
            //Debug.Log("RealizingBackground " + bg);
            switch (bg)
            {
                case VidcamMan.BackGroundTypeE.None:
                    DeactivateBackgroundImage();
                    break;
                case VidcamMan.BackGroundTypeE.Quad:
                    AttachQuadImageToBackground();
                    break;
                case VidcamMan.BackGroundTypeE.UiFrame:
                    AttachFrameImageToBackground();
                    break;
            }

        }

        float oldFov = 0;
        int updatecount = 0;
        string oldImageName = "";
        bool oldShowBackground = true;
        bool oldShowSheres = false;
        float oldLamb;

        // Update is called once per frame
        void Update()
        {
            var doAttach = updatecount == 0 ||
                oldShowBackground != showBackground ||
                oldShowSheres != showSpheres ||
                oldFov != cam.fieldOfView ||
                oldLamb != lamb ||
                oldImageName != imageName;
            if (doAttach)
            {
                RealizeBackground();
                oldShowBackground = showBackground;
                oldShowSheres = showSpheres;
                oldFov = cam.fieldOfView;
                oldImageName = imageName;
                oldLamb = lamb;
            }
            updatecount++;

        }
    }

}