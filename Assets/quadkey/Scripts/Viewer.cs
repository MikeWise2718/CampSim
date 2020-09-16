using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Aiskwk.Map
{
    public enum ViewerAvatar { SphereMan, CapsuleMan, SimpleTruck, Minehaul1, Shovel1, Dozer1, Dozer2, Rover, QuadCopter, QuadCopter2, Car012 };
    public enum ViewerCamConfig { EyesDown, Eyes, FloatBehindDiv4, FloatBehindDiv2, FloatBehind, FloatBehindTimes2, FloatBehindTimes4 }
    public enum ViewerControl { Position, Velocity }

    public class ViewerState
    {
        public Vector3 pos = Vector3.zero;
        public Vector3 rot = Vector3.zero;

        public ViewerAvatar avatar = ViewerAvatar.CapsuleMan;
        public ViewerCamConfig camconfig = ViewerCamConfig.Eyes;
        public ViewerControl vctrl = ViewerControl.Position;
        public ViewerState()
        {
            pos = Vector3.zero;
            rot = Vector3.zero;
            avatar = ViewerAvatar.CapsuleMan;
            camconfig = ViewerCamConfig.Eyes;
            vctrl = ViewerControl.Position;
        }
        public ViewerState(Vector3 pos, Vector3 rot, ViewerAvatar ava = ViewerAvatar.CapsuleMan, ViewerCamConfig cam = ViewerCamConfig.Eyes, ViewerControl vctrl = ViewerControl.Position)
        {
            this.pos = pos;
            this.rot = rot;
            this.avatar = ava;
            this.camconfig = cam;
            this.vctrl = vctrl;
        }
    }

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
        static Camera viewercam;
        bool doTrackThings = false;
        public ViewerAvatar viewerAvatar = ViewerAvatar.CapsuleMan;
        public ViewerCamConfig viewerCamPosition = ViewerCamConfig.Eyes;
        public ViewerControl viewerControl = ViewerControl.Position;
        public Quaternion bodyPrefabRotation = Quaternion.identity;
        public Quaternion bodyPlaneRotation = Quaternion.identity;
        public string qcmdescriptor = "";

        public LatLng curLatLng = new LatLng(0, 0);
        public LatLngVek offsetToMapMidpoint;
        public Vector2d offsetToMapMidpointMeter;
        public LatLngVek offsetToOrigin;
        public Vector2d offsetToOriginMeter;
        public float altitude = 0;
        public bool followGround;

        private static ViewerState defViewer = new ViewerState();

        public ViewerState home;

        public static Camera GetViewerCamera()
        {
            return viewercam;
        }
        public static void InvalidateViewerCamera()
        {
            viewercam = null;
        }


        // Start is called before the first frame update
        void Start()
        {
            SetVtm();
        }
        public void SetVtm()
        {
            this.vtm = FindObjectOfType<VehicleTrackMan>();
            doTrackThings = vtm != null;
            if (doTrackThings)
            {
                Debug.LogWarning($"Viewer.SetVtm - DoTrackThings:{doTrackThings}");
            }
        }
        public ViewerState GetViewerState()
        {
            var vn = new ViewerState();
            vn.pos = transform.position;
            vn.rot = transform.localRotation.eulerAngles;
            vn.avatar = viewerAvatar;
            vn.camconfig = viewerCamPosition;
            vn.vctrl = viewerControl;
            return vn;
        }
        public void InitViewer(QmapMesh qmm, ViewerState homespec = null)
        {
            //Debug.Log("InitViewer");
            this.qmm = qmm;
            if (homespec != null)
            {
                home = homespec;
            }
            else
            {
                home = defViewer;
            }
            viewerAvatar = home.avatar;
            viewerCamPosition = home.camconfig;
            viewerControl = home.vctrl;
            //var (vo,_, istat) = qmm.GetWcMeshPosFromLambda(0.5f, 0.5f);
            var (vo, _, istat) = qmm.GetWcMeshPosProjectedAlongYnew(home.pos);
            transform.position = vo;
            //Debug.Log($"Initviwer initial position {vo}");
            transform.localRotation = Quaternion.Euler(home.rot);
            qcmdescriptor = qmm.descriptor;
            BuildViewer();
            InitTeleporter();
            //Debug.Log("Done with InitViewer");
        }


        public void DumpViewer()
        {
            int iter = 0;
            var t = transform;
            var s = t.localScale.x.ToString("f3");
            var pname = $"{t.name}({s})";
            while (true)
            {
                if (iter++ > 20) break;
                if (t.parent == null) break;
                t = t.parent;
                s = t.localScale.x.ToString("f3");
                pname = $"{t.name}({s})-{pname}";
            }
            Debug.Log($"ViewerPath:{pname}");
        }
        public Transform GetRootTransform(Transform t)
        {
            int iter = 0;
            while (true)
            {
                if (iter++ > 20) break;
                if (t.parent == null) break;
                //Debug.Log($"{t.name}  {iter}");
                t = t.parent;
            }
            //Debug.Log($"GetRootTransform root:{t.name}  {iter}");
            return t;
        }
        public void ReAdjustViewerInitialPosition()
        {
            //Debug.Log($"ReAdjustViewerInitialPosition - before scale:{transform.localScale} rotation:{transform.localRotation.eulerAngles}");
            bodyPrefabRotation = Quaternion.identity;
            bodyPlaneRotation = Quaternion.identity;
            var scale = transform.localScale;

            var parent = transform.parent;
            transform.SetParent(null, worldPositionStays: false);// disconnect
            transform.position = home.pos;
            transform.localRotation = Quaternion.Euler(home.rot);
            //Debug.Log($"ReAdjustViewerInitialPosition - viewerDefaultRotation:{viewerDefaultRotation}");
            var t = GetRootTransform(parent.transform);
            var s = t.localScale.x;
            if (s != 0)
            {
                var sinv = 1 / s;
                //Debug.Log($"{t.name} - sinv:{sinv}");
                transform.localScale = new Vector3(sinv, sinv, sinv);
            }
            else
            {
                Debug.LogError($"{t.name} s == 0");
            }
            transform.SetParent(parent.transform, worldPositionStays: true);// reconnect
            transform.localRotation = Quaternion.Euler(home.rot); // Think this has to match the rotation it was built with
                                                                  // or we get problems when we follownormal along the mesh
            TranslateViewer(0, 0);
            RotateViewer(0);
            //Debug.Log($"ReAdjustViewerInitialPosition - after  scale:{transform.localScale} rotation:{transform.localRotation.eulerAngles}");
            //DumpViewer();
        }

        string[] primitivetypes = { "Capsule", "Sphere" };
        public (GameObject, float) GetAvatarPrefab(string avaname, float angle, Vector3 shift, Vector3 rot, float scale = 1)
        {
            //Debug.Log($"GetAvatarPrefab scale:{scale}");
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
                    //Debug.Log("Sucessfully loaded " + avaname);
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

            var vscale = instancego.transform.localScale * scale;
            instancego.transform.localScale = vscale;
            //Debug.Log($"Setting bodyprefab rotation for {avaname} angle:{angle}");
            instancego.transform.localRotation = Quaternion.Euler(rot.x, rot.y + angle, rot.z);
            instancego.transform.position += shift;
            instancego.transform.SetParent(body.transform, worldPositionStays: false);
            return (instancego, height);
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
            viewercam = null;
        }
        void DestroyGo(ref GameObject go)
        {
            if (go != null)
            {
                Destroy(go);
                go = null;
            }
        }
        void DestroyAvatar()
        {
            DestroyGo(ref rodgo);
            DestroyGo(ref visor);
            DestroyGo(ref camgo);
            DestroyGo(ref body);
            DestroyGo(ref moveplane);
            viewercam = null;
        }
        public bool pinCameraToFrame = false;
        public bool showNormalRod = false;
        public bool showDroppings = false;
        public void MakeAvatar(string avaname, float angle, Vector3 shift, Vector3 rot, float scale = 1, float visorscale = 2)
        {
            Debug.Log($"MakeAvatar {avaname} angle:{angle}");
            Debug.Log($"MakeAvatar - Viewer rotation before  {transform.localRotation.eulerAngles}");
            // TODO: if we are remaking an existing viewer, we probably need to save rotations here and restore them later on
            // see 
            DestroyAvatar();
            moveplane = new GameObject("moveplane");
            body = new GameObject("body");

            float height = 0;
            (bodyprefab, height) = GetAvatarPrefab(avaname, angle, shift, rot, scale);

            body.transform.SetParent(transform, worldPositionStays: false);

            visor = GameObject.CreatePrimitive(PrimitiveType.Cube);
            visor.name = "Visor";
            visor.transform.localScale = new Vector3(0.95f, 0.25f, 0.5f);
            //Debug.Log($"{name} height {height}");
            var vv = new Vector3(0, height, 0.25f);

            visor.transform.position = vv;
            var vska = visorscale;
            visor.transform.localScale = new Vector3(vska, vska / 2, vska);
            visor.transform.localRotation = Quaternion.Euler(0, -angle, 0);
            visor.transform.SetParent(body.transform, worldPositionStays: false);
            qut.SetColorOfGo(visor, Color.black);

            camgo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var cska = 0.1f;
            camgo.name = "viewer-camgo";
            camgo.transform.localScale = new Vector3(cska, cska, cska);
            viewercam = camgo.AddComponent<Camera>();
            SetCamPosition(viewerCamPosition);
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
            viewercam.farClipPlane = 10000;// 10 km


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
            Debug.Log($"MakeAvatar - Viewer rotation after  {transform.localRotation.eulerAngles}");
        }
        static Dictionary<ViewerCamConfig, (Vector3 pos, Vector3 lookdir)> viewerVectorPos = new Dictionary<ViewerCamConfig, (Vector3, Vector3)>{
            {ViewerCamConfig.EyesDown, (new Vector3(0, 0, 0), Vector3.down)},
            {ViewerCamConfig.Eyes, (new Vector3(0, 1.75f, 0.4f), Vector3.forward)},
            {ViewerCamConfig.FloatBehindDiv4, (new Vector3(0, 2.2f, -2), Vector3.forward)},
            {ViewerCamConfig.FloatBehindDiv2, (new Vector3(0, 3, -6), Vector3.forward)},
            {ViewerCamConfig.FloatBehind, (new Vector3(0, 6, -12), Vector3.forward)},
            {ViewerCamConfig.FloatBehindTimes2, (new Vector3(0, 12, -24), Vector3.forward)},
            {ViewerCamConfig.FloatBehindTimes4, (new Vector3(0, 24, -48), Vector3.forward)},
        };
        public void SetCamPosition(ViewerCamConfig newCamPos)
        {
            viewerCamPosition = newCamPos;
            var camtrans = camgo.gameObject.transform;
            var curparent = camtrans.parent;
            camtrans.SetParent(null, worldPositionStays: true);
            var vvp = viewerVectorPos[newCamPos];
            camtrans.position = vvp.pos;
            camtrans.LookAt(vvp.pos + vvp.lookdir);
            camtrans.SetParent(curparent, worldPositionStays: false);

            // now force the camera rotation back to zero 
            var rot = camtrans.localRotation.eulerAngles;
            camtrans.localRotation *= Quaternion.Euler(0, -rot.y, 0);
        }
        static Dictionary<ViewerCamConfig, ViewerCamConfig> nextpos = new Dictionary<ViewerCamConfig, ViewerCamConfig>{
            {ViewerCamConfig.FloatBehindDiv4, ViewerCamConfig.FloatBehindDiv2 },
            {ViewerCamConfig.FloatBehindDiv2, ViewerCamConfig.FloatBehind },
            {ViewerCamConfig.FloatBehind, ViewerCamConfig.FloatBehindTimes2},
            {ViewerCamConfig.FloatBehindTimes2, ViewerCamConfig.FloatBehindTimes4},
//            {ViewerCamPosition.FloatBehindTimes4, ViewerCamPosition.Eyes},
            {ViewerCamConfig.FloatBehindTimes4, ViewerCamConfig.EyesDown},
            {ViewerCamConfig.EyesDown,ViewerCamConfig.FloatBehindDiv4 },
        };
        static Dictionary<ViewerCamConfig, ViewerCamConfig> prevpos = new Dictionary<ViewerCamConfig, ViewerCamConfig>{
            {ViewerCamConfig.EyesDown,ViewerCamConfig.FloatBehindTimes4 },
            {ViewerCamConfig.Eyes,ViewerCamConfig.EyesDown },
//            {ViewerCamPosition.Eyes,ViewerCamPosition.FloatBehindTimes4},
            {ViewerCamConfig.FloatBehindDiv4, ViewerCamConfig.Eyes },
            {ViewerCamConfig.FloatBehindDiv2, ViewerCamConfig.FloatBehindDiv4 },
            {ViewerCamConfig.FloatBehind, ViewerCamConfig.FloatBehindDiv2},
            {ViewerCamConfig.FloatBehindTimes2, ViewerCamConfig.FloatBehind},
            {ViewerCamConfig.FloatBehindTimes4, ViewerCamConfig.FloatBehindTimes2 },

        };


        public void RotateCamPositionTopPrev()
        {
            var oldVcp = viewerCamPosition;
            var newVcp = prevpos[oldVcp];
            SetCamPosition(newVcp);
            Debug.Log($"ShiftCamPosition old:{oldVcp} new:{newVcp} ");
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
            //Debug.Log($"BuildViewer - Viewer rotation before  {transform.localRotation.eulerAngles}");

            DeleteGos();
            var shift = Vector3.zero;
            var scale = 1.0f;
            var angle = 0;
            var rot = Vector3.zero;
            bodyPrefabRotation = Quaternion.identity;
            bodyPlaneRotation = Quaternion.identity;
            var pfix = "obj3d/";
            followGround = true;
            switch (viewerAvatar)
            {
                case ViewerAvatar.SimpleTruck:
                    {
                        angle = 180;
                        scale = 1 / 0.3125f;
                        MakeAvatar(pfix + "DumpTruck_TS1", angle, shift, rot, scale, visorscale: 0.01f);
                        break;
                    }
                case ViewerAvatar.Minehaul1:
                    {
                        shift = new Vector3(0, 0, 0);
                        MakeAvatar(pfix + "Minehaul1", angle, shift, rot, scale);
                        break;
                    }
                case ViewerAvatar.Shovel1:
                    {
                        shift = new Vector3(-10, 0, 0);
                        MakeAvatar(pfix + "Shovel1", angle, shift, rot, scale);
                        break;
                    }
                case ViewerAvatar.Dozer1:
                    {
                        shift = new Vector3(-28.80f, 0, 0);
                        MakeAvatar(pfix + "Dozer1", angle, shift, rot, scale);
                        break;
                    }
                case ViewerAvatar.Dozer2:
                    {
                        shift = new Vector3(-20, 0, 0);
                        MakeAvatar(pfix + "Dozer2", angle, shift, rot, scale);
                        break;
                    }
                case ViewerAvatar.Rover:
                    {
                        angle = 90;
                        MakeAvatar(pfix + "rover2", angle, shift, rot, scale, visorscale: 0.01f);
                        break;
                    }
                case ViewerAvatar.Car012:
                    {
                        bodyPrefabRotation = Quaternion.identity;
                        bodyPlaneRotation = Quaternion.identity;

                        angle = 0;
                        scale = 1 / 0.3125f;
                        MakeAvatar("Cars/Car012", angle, shift, rot, scale, visorscale: 0.01f);
                        break;
                    }
                case ViewerAvatar.QuadCopter:
                    {
                        angle = 90;
                        scale = 100;
                        shift = new Vector3(0, 2, 0);
                        //MakeAvatar(pfix + "quadcopter", angle, shift, scale,visorscale:0.01f);
                        MakeAvatar(pfix + "quadcopterspinning", angle, shift, rot, scale, visorscale: 0.01f);
                        followGround = false;
                        break;
                    }
                case ViewerAvatar.QuadCopter2:
                    {
                        angle = 0;
                        scale = 1;
                        shift = new Vector3(0, 2, 0);
                        rot = new Vector3(-90, 0, 0);
                        //MakeAvatar(pfix + "quadcopter", angle, shift, scale,visorscale:0.01f);
                        MakeAvatar(pfix + "DJI_Mavic_Air_2spinning", angle, shift, rot, scale, visorscale: 0.01f);
                        followGround = false;
                        break;
                    }
                case ViewerAvatar.SphereMan:
                    {
                        shift = new Vector3(0, 1, 0);
                        MakeAvatar("Sphere", angle, shift, rot, scale);
                        break;
                    }
                default:
                case ViewerAvatar.CapsuleMan:
                    {
                        shift = new Vector3(0, 0, 0);
                        MakeAvatar("Capsule", angle, shift, rot, scale, visorscale: 0.64f);
                        //MakeGeomeryViewer(PrimitiveType.Capsule);
                        break;
                    }
            }
            TranslateViewer(0, 0);
            RotateViewer(0);
            //Debug.Log($"BuildViewer - Viewer rotation after  {transform.localRotation.eulerAngles}");
        }

        ViewerAvatar NextAvatar(ViewerAvatar curava)
        {
            var rv = ViewerAvatar.CapsuleMan;
            switch (curava)
            {
                default:
                case ViewerAvatar.QuadCopter:
                    rv = ViewerAvatar.Rover;
                    break;
                case ViewerAvatar.Rover:
                    rv = ViewerAvatar.CapsuleMan;
                    break;
                case ViewerAvatar.CapsuleMan:
                    rv = ViewerAvatar.SimpleTruck;
                    break;
                case ViewerAvatar.SimpleTruck:
                    rv = ViewerAvatar.Car012;
                    break;
                case ViewerAvatar.Car012:
                    rv = ViewerAvatar.QuadCopter;
                    break;
            }
            return rv;
        }
        void MoveToNextAvatar()
        {
            var nextAvatar = NextAvatar(viewerAvatar);
            viewerAvatar = nextAvatar;
            BuildViewer();
        }

        void TiltHead(float rotate)
        {
            visor.transform.localRotation *= Quaternion.Euler(new Vector3(rotate, 0, 0));
            //Debug.Log("Rotated visor by " + rotate);
        }
        void RaiseViewer(float ymove)
        {
            var fak = calctimefak(ref tvlastkey);
            altitude += fak * ymove;
            TranslateViewerProjected(0, 0);
            var posstr = transform.position.ToString("f1");
            //Debug.Log($"RaiseViewer ymove:{ymove} newpos:{posstr}");
        }

        void RotateViewer(float rotate)
        {
            ////Debug.Log($"RotateViewer - Viewer rotation before  {transform.localRotation.eulerAngles} followGround:{followGround}");

            var fak = calctimefak(ref tvlastkey);
            bodyPlaneRotation *= Quaternion.Euler(new Vector3(0, fak * rotate, 0));
            moveplane.transform.localRotation = bodyPlaneRotation;
            bodyPrefabRotation *= Quaternion.Euler(new Vector3(0, fak * rotate, 0));
            body.transform.localRotation = Quaternion.FromToRotation(Vector3.up, lstnrm) * bodyPrefabRotation;

            ////if (followGround)
            ////{
            ////    body.transform.localRotation = Quaternion.FromToRotation(Vector3.up, lstnrm) * bodyPrefabRotation;
            ////}
            ////Debug.Log($"RotateViewer - Viewer rotation after   {transform.localRotation.eulerAngles}");
            ////bodypose.transform.localRotation = Quaternion.Euler(new Vector3(0, rotate, 0)) * Quaternion.FromToRotation(Vector3.up, lstnrm) ;
            ////Debug.Log($"RotateViewer: {rotate}");
        }

        void RotateViewerToYangle(float yangle)
        {
            Debug.Log($"RotateViewerToYangle - Viewer rotation before  {transform.localRotation.eulerAngles}");

            bodyPlaneRotation = Quaternion.Euler(new Vector3(0, yangle, 0));
            moveplane.transform.localRotation = bodyPlaneRotation;
            bodyPrefabRotation = Quaternion.Euler(new Vector3(0, yangle, 0));
            body.transform.localRotation = Quaternion.FromToRotation(Vector3.up, lstnrm) * bodyPrefabRotation;

            Debug.Log($"RotateViewerToYangle - Viewer rotation after   {transform.localRotation.eulerAngles}");
        }

        void RotateViewerNoTimeFak(float rotate)
        {
            Debug.Log($"RotateViewerNoTimeFak - Viewer rotation before  {transform.localRotation.eulerAngles}");

            bodyPlaneRotation *= Quaternion.Euler(new Vector3(0, rotate, 0));
            moveplane.transform.localRotation = bodyPlaneRotation;
            bodyPrefabRotation *= Quaternion.Euler(new Vector3(0, rotate, 0));
            body.transform.localRotation = Quaternion.FromToRotation(Vector3.up, lstnrm) * bodyPrefabRotation;

            Debug.Log($"RotateViewerNoTimeFak - Viewer rotation after   {transform.localRotation.eulerAngles}");
        }

        public delegate (bool ok, Vector3 pos) FindClosestPointDelegate(Vector3 pos);
        FindClosestPointDelegate findclosepointer = null;

        public void SetFindClosestPointDelegate(FindClosestPointDelegate fcpd)
        {
            findclosepointer = fcpd;
        }


        public delegate (bool ok, ViewerState vst) TeleporterDelegate(string trigger);
        TeleporterDelegate teleporter = null;

        public void InitTeleporter()
        {
            InitTestTelelocs();
            teleporter = this.TestTeleporter2;
        }

        public void SetTeleporter(TeleporterDelegate tpd)
        {
            teleporter = tpd;
        }

        //var pgvd = new PolyGenVekMapDel(hmo.ChangeHeight);
        //bpg.LoadRegionOld(this.gameObject, "msftcampcore", 1f, pgvd: pgvd, llm: latlngmap);

        Dictionary<string, ViewerState> telelocs = new Dictionary<string, ViewerState>();

        public void AddTelelLoc(string trigger,ViewerState vst)
        {
            telelocs[trigger] = vst;
        }
        public void AddTelelLoc(Dictionary<string, ViewerState> newtelelocs)
        {
            foreach( var k in newtelelocs.Keys )
            {
                telelocs[k] = newtelelocs[k];
            }
        }
        public void InitTelelocsToEmpty()
        {
            telelocs = new Dictionary<string, ViewerState>();
        }
        public void InitTestTelelocs()
        {
            telelocs = new Dictionary<string, ViewerState>();
            AddTestTelelocs();
        }
        public void AddTestTelelocs()
        { 
            var newtls = new Dictionary<string,ViewerState>() 
            {
                { "t5",new ViewerState()
                    {
                        pos = new Vector3(-850.70f, 73.05f, -487.70f), // "b121-f01-1071"
                        rot = new Vector3(0, 37.8f, 0),
                        avatar = ViewerAvatar.QuadCopter,
                        camconfig = ViewerCamConfig.FloatBehind,
                        vctrl = ViewerControl.Position
                    } 
                },
                { "t1", new ViewerState()
                    {
                        pos = new Vector3(-850.70f, 73.05f, -487.70f), // "b121-f01-1071"
                        rot = new Vector3(0, 37.8f, 0),
                        avatar = ViewerAvatar.QuadCopter2,
                        camconfig = ViewerCamConfig.FloatBehind,
                        vctrl = ViewerControl.Position
                    } 
                },
                { "t2", new ViewerState()
                    {
                        pos = new Vector3(-862.3f, 77.05f, -506.2f),// "b121-f02-2060-2"
                        rot = new Vector3(0, 41.1f, 0),
                        avatar = ViewerAvatar.QuadCopter2,
                        camconfig = ViewerCamConfig.FloatBehind,
                        vctrl = ViewerControl.Position
                    } 
                },
                { "t3",new ViewerState()
                    {
                        pos = new Vector3(-828.12f, 81.25f, -467.71f),// "b121-f03-31-2"
                        rot = new Vector3(0, 48.31f, 0),
                        avatar = ViewerAvatar.QuadCopter2,
                        camconfig = ViewerCamConfig.FloatBehind,
                        vctrl = ViewerControl.Position
                    } 
                },
                { "t4", new ViewerState()
                    {
                        pos = new Vector3(-821.76f, 81.25f, -480.29f),// "b121-f03-3100-2"
                        rot = new Vector3(0, 48.31f, 0),
                        avatar = ViewerAvatar.QuadCopter2,
                        camconfig = ViewerCamConfig.FloatBehind,
                        vctrl = ViewerControl.Position
                    } 
                } 
            };
            AddTelelLoc(newtls);
        }
        public (bool ok, ViewerState vst) TestTeleporter2(string trigger)
        {
            ViewerState vst = null;
            var ok = false;
            if (telelocs != null && telelocs.ContainsKey(trigger))
            {
                vst = telelocs[trigger];
                ok = true;
            }
            return (ok, vst);
        }

        void TeleportViewer(string trigger)
        {
            //var newrot = 0f; /// this seems wierd, but we seemingly have the homeRotation coded in the toplevel Viewer rotation already
            Debug.Log($"MoveViewerToStoredPos:{trigger} pos:{home.pos:f1} rot:{home.rot:f1}");
            var (valid, vst) = teleporter(trigger);
            //var bodyeuler = bodyPrefabRotation.eulerAngles;
            if (valid)
            {
                SetViewerInState(vst);
            }
        }

        void MoveViewerToClosePoint()
        {
            if (findclosepointer == null)
            {
                Debug.Log("MoveViewerToClosePoint - findclosepointer is null - exiting");
                return;
            }
            Debug.Log("MoveViewerToClosePoint");
            var curpos = transform.position;
            var (ok,newpt) = findclosepointer(curpos);
            if (ok)
            {
                var movetopt = new Vector3(newpt.x, curpos.y, newpt.z);
                MoveToPosition(newpt);
            }
            else
            {
                Debug.LogError($"findclosepointer error");
            }
        }


        void SetViewerInState(ViewerState vst)
        {
            if (vst.camconfig != viewerCamPosition)
            {
                SetCamPosition(vst.camconfig);
            }
            if (vst.avatar != viewerAvatar)
            {
                viewerAvatar = vst.avatar;
                BuildViewer();
            }
            viewerControl = vst.vctrl;
            RotateViewerToYangle(vst.rot.y);
            var (vn, _, _) = qmm.GetWcMeshPosProjectedAlongYnew(vst.pos);
            transform.position = vst.pos;
            altitude = vst.pos.y-vn.y;
        }
        void MoveViewerToHomeOld()
        {
            //Debug.Log($"MoveViewerToHome pos:{home.viewerPosition:f1} rot:{home.viewerRotation:f1}");
            var newpos = home.pos;
            var newrot = Vector3.zero; /// this seems wierd, but we seemingly have the homeRotation coded in the toplevel Viewer rotation already


            var bodyeuler = bodyPrefabRotation.eulerAngles;
            // the following two lines don't work
            var qqrot = Quaternion.FromToRotation(bodyeuler, newrot);
            var angtorot = qqrot.eulerAngles;
            //Debug.Log($"MoveViewerToHome bodyeuler:{bodyeuler:f1} ");
            //Debug.Log($"MoveViewerToHome ang:{angtorot:f1} ");
            // aparently it starts from zero every time

            RotateViewerNoTimeFak(-bodyeuler.y);// this only handles the y-axis so it is wrong....

            TranslateViewerToPosition(newpos);
            TranslateViewer(0, 0);// TODO: this shouldn't be necessary but it is for MsftB19focused for some reason....
        }
        void MoveViewerToHome()
        {
            SetViewerInState(home);
        }

        Vector3 lstnrm = Vector3.up;
        void TranslateViewerProjected(float xmove, float zmove)
        {
            var po = transform.position;
            //var (vo, _, _) = qmm.GetWcMeshPosProjectedAlongYnew(po);
            var bto = moveplane.transform;
            var pnstar = po + zmove*bto.forward + xmove*bto.right;

            var (vn, nrm, _) = qmm.GetWcMeshPosProjectedAlongYnew(pnstar);
            var pn = vn + altitude*Vector3.up;
            transform.position = pn;

            if (followGround)
            {
                if (Vector3.Dot(Vector3.up, nrm) < 0)
                {
                    nrm = -nrm;
                }
                lstnrm = nrm;
                var nrmrot = Quaternion.FromToRotation(Vector3.up, nrm);
                body.transform.localRotation = nrmrot * bodyPrefabRotation;
                //body.transform.localRotation = bodyPrefabRotation * nrmrot; // this did not work
                rodgo.transform.localRotation = nrmrot;
            }
            //var fwdstr = bto.forward.ToString("f2");
            //var postr = po.ToString("f3");
            //var pnstr = pn.ToString("f3");
            //var nrmstr = nrm.ToString("f3");
            //Debug.Log($"TranslateViewerLatLng -  xmove:{xmove} zmove:{zmove} po:{postr}  pn:{pnstr}  fwd:{fwdstr}  nrm:{nrm}");
            //Debug.Log($"TranslateViewerLatLng - vo:{vo} vn:{vn}  pos:{t.position}");
        }


        void TranslateViewerToPosition(Vector3 p)
        {
            //var (vo, _, _) = qmm.GetWcMeshPosProjectedAlongY(p);
            //var bt = moveplane.transform;
            var (vn, nrm, _) = qmm.GetWcMeshPosProjectedAlongY(p);
            //t.position = p + Vector3.up * (vn.y - vo.y);
            transform.position = vn;
            if (followGround)
            {
                //bt.position = t.position;
                if (Vector3.Dot(Vector3.up, nrm) < 0)
                {
                    nrm = -nrm;
                }
                lstnrm = nrm;
                var nrmrot = Quaternion.FromToRotation(Vector3.up, nrm);
                body.transform.localRotation = nrmrot * bodyPrefabRotation;
                rodgo.transform.localRotation = nrmrot;
            }
            var pnstr = transform.position.ToString("f3");
            var nrmstr = nrm.ToString("f3");
            //Debug.Log($"TranslateViewerToPosition - vn:{vn}");
        }


        public float calctimefak(ref float lastkeytime)
        {
            var altpressed = Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.LeftAlt);
            var ctrlpressed = Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl);
            var shiftpressed = Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift);

            var timedelt = Time.time - lastkeytime;
            if (timedelt > 0.2) timedelt = 0.2f;
            lastkeytime = Time.time;
            if (lastkeytime == 0)
            {
                lastkeytime = 0.1f;
            }

            var timefak = timedelt;
            if (ctrlpressed)
            {
                timefak *= 3.0f;
            }
            if (shiftpressed)
            {
                timefak *= 3.0f;
            }
            if (shiftpressed && ctrlpressed)
            {
                timefak *= 2.0f;
            }
            //if (timefak > 1) timefak = 1;
            //Debug.Log($"time:{Time.time:f2} lastkeytime:{lastkeytime:f2} timedelt:{timedelt:f2} timefak:{timefak:f2}");
            return timefak;
        }


        int ndrop = 0;
        float tvlastkey = 0;
        void TranslateViewer(float xmove, float zmove)
        {
            var fak = calctimefak(ref tvlastkey);
            TranslateViewerProjected(xmove*fak, zmove*fak);
            curLatLng = qmm.GetLngLat(transform.position);
            offsetToMapMidpoint = curLatLng - qmm.stats.llbox.midll;
            offsetToOrigin = curLatLng - qmm.stats.llbox.orgll;
            offsetToMapMidpointMeter = LatLng.GetLatLngDeltInMeters(curLatLng, offsetToMapMidpoint);
            offsetToOriginMeter = LatLng.GetLatLngDeltInMeters(curLatLng, offsetToOrigin);
            if (showDroppings)
            {
                var dropgo = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                var ska = 0.125f;
                dropgo.transform.localScale = new Vector3(ska, ska, ska);
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
            if (viewercam == null)
            {
                Debug.LogError($"SetSceneCamToMainCam viewcam is null");
            }
            else
            {
                //Debug.Log($"SetSceneCamToMainCam viewcam:{viewercam.name}");
            }
#if UNITY_EDITOR
            //var svcam = UnityEditor.SceneView.lastActiveSceneView.camera;
            //svcam.transform.position = cam.transform.position;
            //svcam.transform.localRotation = cam.transform.localRotation;
            //svcam.depth = cam.depth;
            //svcam.fieldOfView = cam.fieldOfView;
            // see Unity Editor Menu View/AlignViewToSelected
            UnityEditor.SceneView.lastActiveSceneView.AlignViewToObject(viewercam.transform);
#endif
        }
        float f2Hit = float.MinValue;
        float ctrlAhit = float.MinValue;
        float ctrlHhit = float.MinValue;
        float ctrlVhit = float.MinValue;
        float ctrlRhit = float.MinValue;
        float ctrlLhit = float.MinValue;
        float ctrlNhit = float.MinValue;
        float ctrlEhit = float.MinValue;
        float ctrlDhit = float.MinValue;
        float ctrlShit = float.MinValue;
        float ctrlMhit = float.MinValue;
        float ctrlThit = float.MinValue;
        float lftArrowHit = 0;
        float rgtArrowHit = 0;
        float ctrlWhit = 0;
        float hitgap0 = 0.0f;
        //float hitgap1 = 0.1f;
        //float hitgap2 = 0.2f;
        float hitgap3 = 0.3f;


        float shiftpressedElapTime = 0;
        float shiftpressedStartTime = 0;
        float shiftMultiplier = 1;

        void CheckShiftTime()
        {
            var shiftpressed = Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift);
            if (!shiftpressed)
            {
                shiftpressedElapTime = 0;
                shiftpressedStartTime = 0;
                shiftMultiplier = 1;
            }
            else
            {
                if (shiftpressedStartTime==0)
                {
                    shiftpressedStartTime = Time.time;
                }
                shiftpressedElapTime = Time.time - shiftpressedStartTime;
                shiftMultiplier = shiftpressedElapTime / 0.2f;
            }
        }

        public void MoveToPosition(Vector3 newpos)
        {
            TranslateViewerToPosition(newpos);
        }
        void DoKeys()
        {
            var altpressed = Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.LeftAlt);
            var ctrlpressed = Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl);
            var shiftpressed = Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift);
            CheckShiftTime();

            var angincpersec = 15.0f; // deg per sec
            var incpersec = shiftMultiplier * 2.0f; //  m per sec
            if (!ViewerProcessKeys)
            {
                var forcekeyhit = Input.GetKey(KeyCode.V) || Input.GetKey(KeyCode.W);
                if (ctrlpressed && forcekeyhit)
                {
                    ViewerProcessKeys = true;
                    Debug.LogWarning($"Forcing Viewer to processkeys");
                }
                else
                {
                    return; /// no processing keys
                }
            }

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
                TiltHead(angincpersec);
            }
            if (Input.GetKey(KeyCode.PageDown))
            {
                TiltHead(-angincpersec);
            }
            if (Input.GetKey(KeyCode.S))
            {
                SetSceneCamToMainCam();
            }
            if (Input.GetKey(KeyCode.N) && Time.time - ctrlNhit > hitgap3)
            {
                showNormalRod = !showNormalRod;
                ctrlNhit = Time.time;
            }
            if (Input.GetKey(KeyCode.E) && ctrlpressed && Time.time - ctrlEhit > hitgap3)
            {
                RotateCamPositionTopPrev();
                ctrlEhit = Time.time;
            }

            if (Input.GetKey(KeyCode.A) && ctrlpressed)
            {
                //Debug.Log($"hit A {Time.time - ctrlAhit} hitgap3:{hitgap3} doTrackThings:{doTrackThings}");
                if (doTrackThings && Time.time - ctrlAhit > hitgap3)
                {
                    vtm.ActivateNextTrack();
                }
                else if (Time.time - ctrlAhit > hitgap3)
                {
                    var oldav = viewerAvatar;
                    MoveToNextAvatar();
                    var newav = viewerAvatar;
                    Debug.Log($"Moving to next avatar old:{oldav}  new:{newav}");
                    ctrlAhit = Time.time;
                }
            }
            if (Input.GetKey(KeyCode.H) && ctrlpressed)
            {
                //Debug.Log($"hit H {Time.time - ctrlHhit} hitgap3:{hitgap3} doTrackThings:{doTrackThings}");
                if (Time.time - ctrlHhit > hitgap3)
                {
                    MoveViewerToHome();
                }
                ctrlHhit = Time.time;
            }
            if (Time.time - ctrlThit < 2)
            {
                var gap = Time.time - ctrlThit;
                //Debug.Log($"hit second ctrl-T char inputstring:\"{Input.inputString}\" gap:{gap}");
                if (Input.inputString.Length>0)
                {
                    var trigger = "t" + Input.inputString[0];
                    TeleportViewer(trigger);
                    ctrlThit = float.MinValue;
                }
            }
            if (Input.GetKey(KeyCode.T) && ctrlpressed)
            {
                //Debug.Log($"hit T {Time.time - ctrlThit}");
                ctrlThit = Time.time;
            }
            if (Input.GetKey(KeyCode.F2) && Time.time-f2Hit >hitgap3 )
            {
                MoveViewerToClosePoint();
                f2Hit = Time.time;
            }
            if (Input.GetKey(KeyCode.Alpha0))
            {
                //if (doTrackThings && Time.time - ctrlVhit > hitgap3)
                //{
                //    vtm.AddRandomVehicleToFirstActiveTrack();
                //}
                //Debug.Log("Ctrl-KeyCode.Alpha0 hit");
                altitude = 0;
                TranslateViewerProjected(0,0);
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
                    TranslateViewer(incpersec, 0);
                }
                else if (doTrackThings && shiftpressed)
                {
                    vtm.MoveInTime(+timeinc);
                }
                else
                {
                    RotateViewer(angincpersec);
                }
                rgtArrowHit = Time.time;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && Time.time - lftArrowHit > hitgap0)
            {
                if (altpressed)
                {
                    TranslateViewer(-incpersec, 0);
                }
                else if (doTrackThings && shiftpressed)
                {
                    vtm.MoveInTime(-timeinc);
                }
                else
                {
                    RotateViewer(-angincpersec);
                }
                lftArrowHit = Time.time;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (altpressed)
                {
                    TiltHead(-angincpersec);
                }
                else
                {
                    TranslateViewer(0, incpersec);
                }
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (altpressed)
                {
                    TiltHead(angincpersec);
                }
                else
                {
                    TranslateViewer(0, -incpersec);
                }
            }
            if (Input.GetKey(KeyCode.PageUp))
            {
                if (altpressed)
                {
                    TiltHead(angincpersec);
                }
                else
                {
                    RaiseViewer(incpersec);
                }
            }
            if (Input.GetKey(KeyCode.PageDown))
            {
                if (altpressed)
                {
                    TiltHead(-angincpersec);
                }
                else
                {
                    RaiseViewer(-incpersec);
                }
            }
            //var v = transform.position;
            //Debug.Log($"Viewer now at {transform.position}");
        }

        bool changed;
        int updateCount = 0;
        ViewerAvatar old_viewerAvatar;
        ViewerCamConfig old_viewerCamPosition;
        ViewerControl old_viewerControl;
        bool old_showNormalRod;
        bool old_pinCameraToFrame;
        bool CheckChange()
        {
            bool rv = false;
            if (updateCount > 0)
            {
                rv = (old_viewerAvatar != viewerAvatar) ||
                     //(old_viewerCamPosition != viewerCamPosition) || // todo - rebuilding viewer does not respect current viewing angle
                     (old_showNormalRod != showNormalRod) ||
                     (old_pinCameraToFrame != pinCameraToFrame);
            }
            updateCount++;
            old_showNormalRod = showNormalRod;
            old_viewerAvatar = viewerAvatar;
            //old_viewerCamPosition = viewerCamPosition;
            old_pinCameraToFrame = pinCameraToFrame;
            return rv;
        }
        public static bool ViewerProcessKeys = true;

        public static void ActivateViewerKeys(bool newstat)
        {
            ViewerProcessKeys = newstat;
        }
        // Update is called once per frame
        void Update()
        {
            //if (CheckChange())
            //{
            //    BuildViewer();
            //}
            DoKeys();
        }
    }
}