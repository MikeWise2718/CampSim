using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aiskwk.Map
{
    public enum ViewerAvatar { SphereMan, CapsuleMan, SimpleTruck, Minehaul1, Shovel1, Dozer1, Dozer2, Rover };
    public enum ViewerCamPosition { Eyes, FloatBehind }
    public enum ViewerControl { Position, Velocity }

    public class Viewer : MonoBehaviour
    {
        QmapMesh qmm;
        VehicleTrackMan vtm;
        GameObject visor = null;
        GameObject moveplane = null;
        GameObject body = null;
        GameObject bodyprefab = null;
        GameObject camgo = null;
        GameObject rodgo = null;
        Light lightcomp;
        Camera cam;
        bool doTrackThings = false;
        public ViewerAvatar viewerAvatar = ViewerAvatar.CapsuleMan;
        public ViewerCamPosition viewerCamPosition = ViewerCamPosition.Eyes;
        public ViewerControl viewerControl = ViewerControl.Position;
        public Quaternion bodyPrefabRotation = Quaternion.identity;
        public Quaternion bodyPlaneRotation = Quaternion.identity;
        public string qcmdescriptor = "";

        public LatLng curLatLng = new LatLng(0, 0);
        public LatLngVek offsetToMapMidpoint;
        public Vector2d offsetToMapMidpointMeter;
        public LatLngVek offsetToOrigin;
        public Vector2d offsetToOriginMeter;

        public static Vector3 viewerDefaultPosition = Vector3.zero;
        public static Vector3 viewerDefaultRotation = Vector3.zero;

        public static ViewerAvatar viewerAvatarDefaultValue = ViewerAvatar.CapsuleMan;
        public static ViewerCamPosition ViewerCamPositionDefaultValue = ViewerCamPosition.Eyes;
        public static ViewerControl ViewerControlDefaultValue = ViewerControl.Position;

        // Start is called before the first frame update
        void Start()
        {
            SetVtm();
        }
        public void SetVtm()
        {
            this.vtm = FindObjectOfType<VehicleTrackMan>();
            doTrackThings = vtm != null;
            //Debug.Log($"SetVtm - DoTrackThings:{doTrackThings}");
        }
        public void InitViewer(QmapMesh qmm)
        {
            this.qmm = qmm;
            viewerAvatar = viewerAvatarDefaultValue;
            viewerCamPosition = ViewerCamPositionDefaultValue;
            viewerControl = ViewerControlDefaultValue;
            //var (vo,_, istat) = qmm.GetWcMeshPosFromLambda(0.5f, 0.5f);
            var (vo, _, istat) = qmm.GetWcMeshPosProjectedAlongY(viewerDefaultPosition);
            transform.position = vo;
            transform.localRotation = Quaternion.Euler(viewerDefaultRotation);
            qcmdescriptor = qmm.descriptor;
            BuildViewer();
        }
        public void DeleteGos()
        {
            if (moveplane != null)
            {
                Destroy(moveplane);
                moveplane = null;
            }
            if (body != null)
            {
                Destroy(body);
                body = null;
            }
            if (bodyprefab != null)
            {
                Destroy(bodyprefab);
                bodyprefab = null;
            }
            if (visor != null)
            {
                Destroy(visor);
                visor = null;
            }
            if (camgo != null)
            {
                Destroy(camgo);
                camgo = null;
            }
            if (rodgo != null)
            {
                Destroy(rodgo);
                rodgo = null;
            }
        }

        string[] primitivetypes = { "Capsule", "Sphere" };
        public (GameObject, float) GetAvatarPrefab(string avaname, float angle, Vector3 shift, float scale = 1)
        {
            GameObject instancego = null;

            var height = 0f;
            var loaded = false;
            var ptypespecified = PrimitiveType.TryParse(avaname, out PrimitiveType ptype);
            if (!ptypespecified)
            {
                try
                {
                    var prefab = Resources.Load<GameObject>(avaname);
                    Transform t = Instantiate<Transform>(prefab.transform, Vector3.zero, Quaternion.identity);
                    instancego = t.gameObject;
                    height = 2.5f;
                    loaded = true;
                    Debug.Log("Sucessufully loaded " + avaname);
                }
                catch (System.Exception ex)
                {
                    Debug.LogWarning("Could not load " + avaname);
                    Debug.LogWarning(ex.Message);
                }
            }
            if (!loaded)
            {
                if (!ptypespecified)
                {
                    ptype = PrimitiveType.Capsule;
                    shift = new Vector3(0, 1, 0)
    ;
                }
                instancego = GameObject.CreatePrimitive(ptype);
                instancego.transform.position = new Vector3(0, 0.98f, 0);
                height = 1.5f;
                loaded = true;
            }
            instancego.name = "bodyprefab";

            var skav3 = instancego.transform.localScale * scale;
            instancego.transform.localScale = skav3;
            //Debug.Log($"Setting bodyprefab rotation for {avaname} angle:{angle} ");
            instancego.transform.localRotation = Quaternion.Euler(0, angle, 0);
            instancego.transform.position += shift;
            instancego.transform.SetParent(body.transform, worldPositionStays: false);
            return (instancego, height);
        }

        public void DestroyBody()
        {
            if (moveplane != null)
            {
                Destroy(moveplane);
                moveplane = null;
            }
            if (bodyprefab != null)
            {
                Destroy(bodyprefab);
                bodyprefab = null;
            }
            if (body != null)
            {
                Destroy(body);
                body = null;
            }

        }

        public bool pinCameraToFrame = false;
        public bool showNormalRod = false;
        public bool showDroppings = false;
        public void MakeAvatar(string avaname, float angle, Vector3 shift, float scale = 1)
        {
            moveplane = new GameObject("moveplane");
            body = new GameObject("body");

            float height = 0;
            (bodyprefab, height) = GetAvatarPrefab(avaname, angle, shift, scale);

            body.transform.SetParent(transform, worldPositionStays: false);

            visor = GameObject.CreatePrimitive(PrimitiveType.Cube);
            visor.name = "Visor";
            visor.transform.localScale = new Vector3(0.95f, 0.25f, 0.5f);
            //Debug.Log($"{name} height {height}");
            var vv = new Vector3(0, height, 0.25f);

            visor.transform.position = vv;

            visor.transform.localRotation = Quaternion.Euler(0, -angle, 0); ;
            visor.transform.SetParent(body.transform, worldPositionStays: false);
            qut.SetColorOfGo(visor, Color.black);

            camgo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var cska = 0.1f;
            camgo.name = "camgo";
            camgo.transform.localScale = new Vector3(cska, cska, cska);
            cam = camgo.AddComponent<Camera>();
            switch (viewerCamPosition)
            {
                case ViewerCamPosition.Eyes:
                    {
                        camgo.transform.position = Vector3.up * 1.75f;
                        break;
                    }
                case ViewerCamPosition.FloatBehind:
                    {
                        camgo.transform.position = new Vector3(0, 10, -24);
                        break;
                    }
            }
            if (pinCameraToFrame)
            {
                //camgo.transform.localRotation = Quaternion.Euler(0, -angle, 0); ;
                //camgo.transform.localRotation = Quaternion.Euler(0, -angle, 0); ;
                camgo.transform.SetParent(body.transform, worldPositionStays: false);
            }
            else
            {
                camgo.transform.SetParent(moveplane.transform, worldPositionStays: false);
                //Debug.Log("camgo parent is now moveplane");
            }
            cam.farClipPlane = 10000;// 10 km


            moveplane.transform.SetParent(transform, worldPositionStays: false);

            rodgo = new GameObject("rodgo");
            if (showNormalRod)
            {
                var rod = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                var rodheight = 4.0f;
                rod.transform.localScale = new Vector3(0.2f, rodheight, 0.2f);
                rod.transform.position = new Vector3(0, rodheight * 0.75f, 0);
                rod.transform.SetParent(rodgo.transform, worldPositionStays: false);
                qut.SetColorOfGo(rod, Color.blue);
            }
            rodgo.transform.SetParent(transform, worldPositionStays: false);
        }
        public void ToggleLight()
        {
            if (lightcomp == null)
            {
                lightcomp = camgo.AddComponent<Light>();
                lightcomp.color = Color.white;
                lightcomp.type = LightType.Directional;
                //Debug.Log("Adding light");
            }
            else
            {
                Destroy(lightcomp);
                lightcomp = null;
                //Debug.Log("Destroying light");
            }
        }

        public void ToggleBlueLight()
        {
            if (lightcomp == null)
            {
                lightcomp = camgo.AddComponent<Light>();
                lightcomp.color = Color.blue;
                lightcomp.type = LightType.Directional;
                //Debug.Log("Adding light");
            }
            else
            {
                Destroy(lightcomp);
                lightcomp = null;
                // Debug.Log("Destroying light");
            }
        }



        public void BuildViewer()
        {
            //Debug.Log("BuildViewer");
            DeleteGos();
            var shift = Vector3.zero;
            var scale = 1.0f;
            var angle = 0;
            switch (viewerAvatar)
            {
                case ViewerAvatar.SimpleTruck:
                    {
                        angle = 180;
                        MakeAvatar("obj/DumpTruck_TS1", angle, shift, scale);
                        break;
                    }
                case ViewerAvatar.Minehaul1:
                    {
                        shift = new Vector3(0, 0, 0);
                        MakeAvatar("obj/Minehaul1", angle, shift, scale);
                        break;
                    }
                case ViewerAvatar.Shovel1:
                    {
                        shift = new Vector3(-10, 0, 0);
                        MakeAvatar("obj/Shovel1", angle, shift, scale);
                        break;
                    }
                case ViewerAvatar.Dozer1:
                    {
                        shift = new Vector3(-28.80f, 0, 0);
                        MakeAvatar("obj/Dozer1", angle, shift, scale);
                        break;
                    }
                case ViewerAvatar.Dozer2:
                    {
                        shift = new Vector3(-20, 0, 0);
                        MakeAvatar("obj/Dozer2", angle, shift, scale);
                        break;
                    }
                case ViewerAvatar.Rover:
                    {
                        angle = 90;
                        MakeAvatar("obj/rover2", angle, shift, scale);
                        break;
                    }
                case ViewerAvatar.SphereMan:
                    {
                        shift = new Vector3(0, 1, 0);
                        MakeAvatar("Sphere", angle, shift, scale);
                        break;
                    }
                default:
                case ViewerAvatar.CapsuleMan:
                    {
                        shift = new Vector3(0, 0, 0);
                        MakeAvatar("Capsule", angle, shift, scale);
                        //MakeGeomeryViewer(PrimitiveType.Capsule);
                        break;
                    }
            }
            TranslateViewer(0, 0);
            RotateViewer(0);
        }

        void TiltHead(float rotate)
        {
            visor.transform.localRotation *= Quaternion.Euler(new Vector3(rotate, 0, 0));
            Debug.Log("Rotated visor by " + rotate);
        }
        Vector3 lstnrm = Vector3.up;
        void RotateViewer(float rotate)
        {
            bodyPlaneRotation *= Quaternion.Euler(new Vector3(0, rotate, 0));
            moveplane.transform.localRotation = bodyPlaneRotation;
            bodyPrefabRotation *= Quaternion.Euler(new Vector3(0, rotate, 0));
            body.transform.localRotation = Quaternion.FromToRotation(Vector3.up, lstnrm) * bodyPrefabRotation;
            //bodypose.transform.localRotation = Quaternion.Euler(new Vector3(0, rotate, 0)) * Quaternion.FromToRotation(Vector3.up, lstnrm) ;
            //Debug.Log($"RotateViewer: {rotate}");
        }

        Vector3 FlattenForward(Vector3 fwd)
        {
            if (fwd.x == 0 && fwd.z == 0)
            {
                return Vector3.forward;
            }
            var rv = new Vector3(fwd.x, 0, fwd.z);
            rv.Normalize();
            return rv;
        }


        void TranslateViewerLatLng(float xmove, float zmove)
        {
            var bt = moveplane.transform;
            var t = transform;
            var p = t.position;
            var postr = t.position.ToString("f3");
            var (vo, nrm, _) = qmm.GetWcMeshPosProjectedAlongY(p);
            var fwd = bt.forward;
            p += zmove * fwd + xmove * bt.right;
            var fwdstr = fwd.ToString("f2");
            var (vn, _, _) = qmm.GetWcMeshPosProjectedAlongY(p);
            //t.position = p + Vector3.up * (vn.y - vo.y);
            t.position = vn;
            //bt.position = t.position;
            if (Vector3.Dot(Vector3.up, nrm) < 0)
            {
                nrm = -nrm;
            }
            lstnrm = nrm;
            var nrmrot = Quaternion.FromToRotation(Vector3.up, nrm);
            body.transform.localRotation = nrmrot * bodyPrefabRotation;
            //bodypose.transform.localRotation = nrmrot;
            rodgo.transform.localRotation = nrmrot;
            var pnstr = t.position.ToString("f3");
            var nrmstr = nrm.ToString("f3");
            //Debug.Log($"translate viewer = xmove:{xmove} zmove:{zmove} po:{postr}  pn:{pnstr}  fwd:{fwdstr}");
        }
        void TranslateViewerToPosition(Vector3 p)
        {
            var (vo, nrm, _) = qmm.GetWcMeshPosProjectedAlongY(p);
            var bt = moveplane.transform;
            var t = transform;
            var (vn, _, _) = qmm.GetWcMeshPosProjectedAlongY(p);
            //t.position = p + Vector3.up * (vn.y - vo.y);
            t.position = vn;
            //bt.position = t.position;
            if (Vector3.Dot(Vector3.up, nrm) < 0)
            {
                nrm = -nrm;
            }
            lstnrm = nrm;
            var nrmrot = Quaternion.FromToRotation(Vector3.up, nrm);
            body.transform.localRotation = nrmrot * bodyPrefabRotation;
            //bodypose.transform.localRotation = nrmrot;
            rodgo.transform.localRotation = nrmrot;
            var pnstr = t.position.ToString("f3");
            var nrmstr = nrm.ToString("f3");
            //Debug.Log($"translate viewer = xmove:{xmove} zmove:{zmove} po:{postr}  pn:{pnstr}  fwd:{fwdstr}");
        }
        bool usellmeth = true;
        void TranslateViewerLambda(float xmove, float zmove)
        {
            var t = transform;
            var p = t.position;
            var (olambx, olambz) = qmm.GetMeshLambdaFromXZ(p.x, p.z);
            var (vo, nrm, _) = qmm.GetWcMeshPosFromLambda(olambx, olambz);
            if (Vector3.Dot(Vector3.up, nrm) < 0)
            {
                nrm = -nrm;
            }
            lstnrm = nrm;
            p += zmove * t.forward + xmove * t.right;
            var (nlambx, nlambz) = qmm.GetMeshLambdaFromXZ(p.x, p.z);
            var (vn, _, _) = qmm.GetWcMeshPosFromLambda(nlambx, nlambz);
            t.position = p + Vector3.up * (vn.y - vo.y);
            t.up = nrm;
            var pstr = t.position.ToString("f1");
            Debug.Log($"lambx:{nlambx} lambz:{nlambz}   p:{pstr}");
        }
        int ndrop = 0;
        void TranslateViewer(float xmove, float zmove)
        {
            if (usellmeth)
            {
                TranslateViewerLatLng(xmove, zmove);
            }
            else
            {
                TranslateViewerLambda(xmove, zmove);
            }
            curLatLng = qmm.GetLngLat(transform.position);
            offsetToMapMidpoint = curLatLng - qmm.stats.llbox.midll;
            offsetToOrigin = curLatLng - qmm.stats.llbox.orgll;
            offsetToMapMidpointMeter = LatLng.GetLatLngDeltInMeters(curLatLng, offsetToMapMidpoint);
            offsetToOriginMeter = LatLng.GetLatLngDeltInMeters(curLatLng, offsetToOrigin);
            if (showDroppings)
            {
                var dropgo = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                dropgo.transform.position = transform.position;
                dropgo.name = "Drop" + ndrop;
                qut.SetColorOfGo(dropgo, "green");
                ndrop++;
            }
        }

        public void SetMainCamToSceneCam()
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
            }
#endif
        }
        public void SetSceneCamToMainCam()
        {
#if UNITY_EDITOR
            //var svcam = UnityEditor.SceneView.lastActiveSceneView.camera;
            //svcam.transform.position = cam.transform.position;
            //svcam.transform.localRotation = cam.transform.localRotation;
            //svcam.depth = cam.depth;
            //svcam.fieldOfView = cam.fieldOfView;
            // see Unity Editor Menu View/AlignViewToSelected
            UnityEditor.SceneView.lastActiveSceneView.AlignViewToObject(cam.transform);
#endif
        }
        float ctrlAhit = float.MinValue;
        float ctrlVhit = float.MinValue;
        float ctrlRhit = float.MinValue;
        float ctrlLhit = float.MinValue;
        float ctrlNhit = float.MinValue;
        float ctrlDhit = float.MinValue;
        float ctrlShit = float.MinValue;
        float ctrlMhit = float.MinValue;
        float lftArrowHit = 0;
        float rgtArrowHit = 0;
        float ctrlWhit = 0;
        float hitgap0 = 0.0f;
        //float hitgap1 = 0.1f;
        //float hitgap2 = 0.2f;
        float hitgap3 = 0.3f;
        public void MoveToPosition(Vector3 newpos)
        {
            TranslateViewerToPosition(newpos);
        }
        void DoKeys()
        {
            var altpressed = Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.LeftAlt);
            var ctrlpressed = Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl);
            var shiftpressed = Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift);
            var speedmult = 0.3f;
            if (ctrlpressed) speedmult = 3.0f;

            var ainc = 2.0f * speedmult;
            var inc = 1.0f * speedmult;

            if (doTrackThings && (Time.time - ctrlVhit < 1.0f))
            {
                var vt = vtm.GetAddVehichalTrack();
                if (vt != null)
                {
                    if (Input.GetKey(KeyCode.S) && Time.time - ctrlShit > hitgap3)
                    {

                        vt.AddShovel();
                        ctrlShit = Time.time;
                    }
                    if (Input.GetKey(KeyCode.D) && Time.time - ctrlDhit > hitgap3)
                    {
                        vt.AddDozer();
                        ctrlDhit = Time.time;
                    }
                    if (Input.GetKey(KeyCode.M) && Time.time - ctrlMhit > hitgap3)
                    {
                        vt.AddMineTruck();
                        ctrlMhit = Time.time;
                    }
                    if (Input.GetKey(KeyCode.R) && Time.time - ctrlRhit > hitgap3)
                    {
                        vt.AddRandomVehicle();
                        ctrlRhit = Time.time;
                    }
                    return;
                }
                else
                {
                    Debug.LogWarning("No Add Vehicle Track set");
                }
            }
            if (Input.GetKey(KeyCode.PageDown))
            {
                TiltHead(ainc);
            }
            if (Input.GetKey(KeyCode.PageDown))
            {
                TiltHead(-ainc);
            }
            if (Input.GetKey(KeyCode.S))
            {
                SetSceneCamToMainCam();
            }
            if (Input.GetKey(KeyCode.D) && Time.time - ctrlDhit > hitgap3)
            {
                showDroppings = !showDroppings;
                ctrlDhit = Time.time;
            }
            if (Input.GetKey(KeyCode.N) && Time.time - ctrlNhit > hitgap3)
            {
                showNormalRod = !showNormalRod;
                ctrlNhit = Time.time;
            }
            if (Input.GetKey(KeyCode.D) && ctrlpressed)
            {
                this.gameObject.SetActive(false);
            }
            if (Input.GetKey(KeyCode.A) && ctrlpressed)
            {
                Debug.Log($"hit A {Time.time - ctrlAhit} hitgap3:{hitgap3} doTrackThings:{doTrackThings}");
                if (doTrackThings && Time.time - ctrlAhit > hitgap3)
                {
                    vtm.ActivateNextTrack();
                }
                ctrlAhit = Time.time;
            }
            if (Input.GetKey(KeyCode.V) && ctrlpressed)
            {
                //if (doTrackThings && Time.time - ctrlVhit > hitgap3)
                //{
                //    vtm.AddRandomVehicleToFirstActiveTrack();
                //}
                ctrlVhit = Time.time;
            }
            if (Input.GetKey(KeyCode.W) && ctrlpressed)
            {
                ctrlWhit = Time.time;
            }
            if (Input.GetKey(KeyCode.M) && ctrlpressed)
            {
                if (doTrackThings)
                {
                    vtm.MoveToLastCollision();
                }
            }
            if (Input.GetKey(KeyCode.R) && ctrlpressed)
            {
                if (doTrackThings)
                {
                    vtm.RestartThings();
                }
            }
            if (Input.GetKey(KeyCode.L) && ctrlpressed)
            {
                if (doTrackThings && Time.time - ctrlLhit > hitgap3)
                {
                    ToggleLight();
                }
                ctrlLhit = Time.time;
            }
            if (Input.GetKey(KeyCode.B))
            {
                if (doTrackThings)
                {
                    ToggleBlueLight();
                }
            }

            if (Input.GetKey(KeyCode.Alpha0))
            {
                if (doTrackThings)
                {
                    vtm.ResetTime();
                }
            }
            float timeinc = 0.25f;
            if (Input.GetKey(KeyCode.RightArrow) && Time.time - rgtArrowHit > hitgap0)
            {
                if (altpressed)
                {
                    TranslateViewer(inc, 0);
                }
                else if (shiftpressed)
                {
                    if (doTrackThings)
                    {
                        vtm.MoveInTime(+timeinc);
                    }
                }
                else
                {
                    RotateViewer(ainc);
                }
                rgtArrowHit = Time.time;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && Time.time - lftArrowHit > hitgap0)
            {
                if (altpressed)
                {
                    TranslateViewer(-inc, 0);
                }
                else if (shiftpressed)
                {
                    if (doTrackThings)
                    {
                        vtm.MoveInTime(-timeinc);
                    }
                }
                else
                {
                    RotateViewer(-ainc);
                }
                lftArrowHit = Time.time;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (altpressed)
                {
                    TiltHead(-ainc);
                }
                else
                {
                    TranslateViewer(0, inc);
                }
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (altpressed)
                {
                    TiltHead(ainc);
                }
                else
                {
                    TranslateViewer(0, -inc);
                }
            }
        }

        bool changed;
        int updateCount = 0;
        ViewerAvatar old_viewerAvatar;
        ViewerCamPosition old_viewerCamPosition;
        ViewerControl old_viewerControl;
        bool old_showNormalRod;
        bool old_pinCameraToFrame;
        bool CheckChange()
        {
            bool rv = false;
            if (updateCount > 0)
            {
                rv = (old_viewerAvatar != viewerAvatar) ||
                     (old_viewerCamPosition != viewerCamPosition) ||
                     (old_showNormalRod != showNormalRod) ||
                     (old_pinCameraToFrame != pinCameraToFrame);
            }
            updateCount++;
            old_showNormalRod = showNormalRod;
            old_viewerAvatar = viewerAvatar;
            old_viewerCamPosition = viewerCamPosition;
            old_pinCameraToFrame = pinCameraToFrame;
            return rv;
        }
        // Update is called once per frame
        void Update()
        {
            if (CheckChange())
            {
                BuildViewer();
            }
            DoKeys();
        }
    }
}