using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aiskwk.Map
{
    public enum ViewerAvatar { SphereMan, CapsuleMan, SimpleTruck, Minehaul1, Shovel1, Dozer1, Dozer2, Rover, QuadCopter, Car012 };
    public enum ViewerCamPosition { Eyes, FloatBehindDiv4, FloatBehindDiv2, FloatBehind, FloatBehindTimes2, FloatBehindTimes4 }
    public enum ViewerControl { Position, Velocity }

    public class ViewerState
    {
        public Vector3 viewerPosition = Vector3.zero;
        public Vector3 viewerRotation = Vector3.zero;

        public ViewerAvatar viewerAvatarValue = ViewerAvatar.CapsuleMan;
        public ViewerCamPosition viewerCamPositionValue = ViewerCamPosition.Eyes;
        public ViewerControl viewerControlValue = ViewerControl.Position;
        public ViewerState()
        {
            viewerPosition = Vector3.zero;
            viewerRotation = Vector3.zero;
            viewerAvatarValue = ViewerAvatar.CapsuleMan;
            viewerCamPositionValue = ViewerCamPosition.Eyes;
            viewerControlValue = ViewerControl.Position;
        }
        public ViewerState(Vector3 pos, Vector3 rot, ViewerAvatar ava = ViewerAvatar.CapsuleMan, ViewerCamPosition cam = ViewerCamPosition.Eyes, ViewerControl ctrl = ViewerControl.Position)
        {
            viewerPosition = pos;
            viewerRotation = rot;
            viewerAvatarValue = ava;
            viewerCamPositionValue = cam;
            viewerControlValue = ctrl;
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
            viewerAvatar = home.viewerAvatarValue;
            viewerCamPosition = home.viewerCamPositionValue;
            viewerControl = home.viewerControlValue;
            //var (vo,_, istat) = qmm.GetWcMeshPosFromLambda(0.5f, 0.5f);
            var (vo, _, istat) = qmm.GetWcMeshPosProjectedAlongYnew(home.viewerPosition);
            transform.position = vo;
            //Debug.Log($"Initviwer initial position {vo}");
            transform.localRotation = Quaternion.Euler(home.viewerRotation);
            qcmdescriptor = qmm.descriptor;
            BuildViewer();
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
            transform.position = home.viewerPosition;
            transform.localRotation = Quaternion.Euler(home.viewerRotation);
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
            transform.localRotation = Quaternion.Euler(home.viewerRotation); // Think this has to match the rotation it was built with
                                                                             // or we get problems when we follownormal along the mesh
            TranslateViewer(0, 0);
            RotateViewer(0);
            //Debug.Log($"ReAdjustViewerInitialPosition - after  scale:{transform.localScale} rotation:{transform.localRotation.eulerAngles}");
            //DumpViewer();
        }

        string[] primitivetypes = { "Capsule", "Sphere" };
        public (GameObject, float) GetAvatarPrefab(string avaname, float angle, Vector3 shift, float scale = 1)
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
            instancego.transform.localRotation = Quaternion.Euler(0, angle, 0);
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
        public void MakeAvatar(string avaname, float angle, Vector3 shift, float scale = 1, float visorscale = 2)
        {
            Debug.Log($"MakeAvatar {avaname} angle:{angle}");
            Debug.Log($"MakeAvatar - Viewer rotation before  {transform.localRotation.eulerAngles}");
            // TODO: if we are remaking an existing viewer, we probably need to save rotations here and restore them later on
            // see 
            DestroyAvatar();
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
            SetCamPosition();
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
        static Dictionary<ViewerCamPosition, Vector3> viewerVectorPos = new Dictionary<ViewerCamPosition, Vector3>{
            {ViewerCamPosition.Eyes, new Vector3(0, 1.75f, 0.4f)},
            {ViewerCamPosition.FloatBehindDiv4, new Vector3(0, 2.2f, -2)},
            {ViewerCamPosition.FloatBehindDiv2, new Vector3(0, 3, -6)},
            {ViewerCamPosition.FloatBehind, new Vector3(0, 6, -12)},
            {ViewerCamPosition.FloatBehindTimes2, new Vector3(0, 12, -24)},
            {ViewerCamPosition.FloatBehindTimes4, new Vector3(0, 24, -48)},
        };
        public void SetCamPosition()
        {
            var camtrans = camgo.gameObject.transform;
            var curparent = camtrans.parent;
            camtrans.SetParent(null, worldPositionStays: true);
            camtrans.position = viewerVectorPos[viewerCamPosition];
            camtrans.SetParent(curparent, worldPositionStays: false);

            // now force the camera rotation back to zero 
            var rot = camtrans.localRotation.eulerAngles;
            camtrans.localRotation *= Quaternion.Euler(0, -rot.y, 0);
        }
        static Dictionary<ViewerCamPosition, ViewerCamPosition> nextpos = new Dictionary<ViewerCamPosition, ViewerCamPosition>{
            {ViewerCamPosition.Eyes,ViewerCamPosition.FloatBehindDiv4 },
            {ViewerCamPosition.FloatBehindDiv4, ViewerCamPosition.FloatBehindDiv2 },
            {ViewerCamPosition.FloatBehindDiv2, ViewerCamPosition.FloatBehind },
            {ViewerCamPosition.FloatBehind, ViewerCamPosition.FloatBehindTimes2},
            {ViewerCamPosition.FloatBehindTimes2, ViewerCamPosition.FloatBehindTimes4},
            {ViewerCamPosition.FloatBehindTimes4, ViewerCamPosition.Eyes},
        };
        static Dictionary<ViewerCamPosition, ViewerCamPosition> prevpos = new Dictionary<ViewerCamPosition, ViewerCamPosition>{
            {ViewerCamPosition.Eyes,ViewerCamPosition.FloatBehindTimes4},
            {ViewerCamPosition.FloatBehindDiv4, ViewerCamPosition.Eyes },
            {ViewerCamPosition.FloatBehindDiv2, ViewerCamPosition.FloatBehindDiv4 },
            {ViewerCamPosition.FloatBehind, ViewerCamPosition.FloatBehindDiv2},
            {ViewerCamPosition.FloatBehindTimes2, ViewerCamPosition.FloatBehind},
            {ViewerCamPosition.FloatBehindTimes4, ViewerCamPosition.FloatBehindTimes2 },

        };


        public void ShiftCamPosition()
        {
            var oldViewerCamPosition = viewerCamPosition;
            viewerCamPosition = prevpos[oldViewerCamPosition];
            Debug.Log($"ShiftCamPosition old:{oldViewerCamPosition} new:{viewerCamPosition} ");
            SetCamPosition();
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
                        MakeAvatar(pfix + "DumpTruck_TS1", angle, shift, scale, visorscale: 0.01f);
                        break;
                    }
                case ViewerAvatar.Minehaul1:
                    {
                        shift = new Vector3(0, 0, 0);
                        MakeAvatar(pfix + "Minehaul1", angle, shift, scale);
                        break;
                    }
                case ViewerAvatar.Shovel1:
                    {
                        shift = new Vector3(-10, 0, 0);
                        MakeAvatar(pfix + "Shovel1", angle, shift, scale);
                        break;
                    }
                case ViewerAvatar.Dozer1:
                    {
                        shift = new Vector3(-28.80f, 0, 0);
                        MakeAvatar(pfix + "Dozer1", angle, shift, scale);
                        break;
                    }
                case ViewerAvatar.Dozer2:
                    {
                        shift = new Vector3(-20, 0, 0);
                        MakeAvatar(pfix + "Dozer2", angle, shift, scale);
                        break;
                    }
                case ViewerAvatar.Rover:
                    {
                        angle = 90; 
                        MakeAvatar(pfix + "rover2", angle, shift, scale, visorscale: 0.01f);
                        break;
                    }
                case ViewerAvatar.Car012:
                    {
                        bodyPrefabRotation = Quaternion.identity;
                        bodyPlaneRotation = Quaternion.identity;

                        angle = 0;
                        scale = 1 / 0.3125f;
                        MakeAvatar("Cars/Car012", angle, shift, scale, visorscale: 0.01f);
                        break;
                    }
                case ViewerAvatar.QuadCopter:
                    {
                        angle = 90;
                        scale = 100;
                        shift = new Vector3(0, 2, 0);
                        //MakeAvatar(pfix + "quadcopter", angle, shift, scale,visorscale:0.01f);
                        MakeAvatar(pfix + "quadcopterspinning", angle, shift, scale, visorscale: 0.01f);
                        followGround = false;
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
                        MakeAvatar("Capsule", angle, shift, scale, visorscale: 0.64f);
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
            altitude += fak*ymove;
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

        void MoveViewerToHome()
        {
            //Debug.Log($"MoveViewerToHome pos:{home.viewerPosition:f1} rot:{home.viewerRotation:f1}");
            var newpos = home.viewerPosition;
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
        void MoveViewerToStoredPos(int ipos)
        {
            var newpos = home.viewerPosition;
            var newrot = 0f; /// this seems wierd, but we seemingly have the homeRotation coded in the toplevel Viewer rotation already
            Debug.Log($"MoveViewerToStoredPos:{ipos} pos:{home.viewerPosition:f1} rot:{home.viewerRotation:f1}");
            switch (ipos)
            {
                case 1:
                    //grc.LinkToPtxyz("b121-f01-1071", -850.70 + xs, 0.000, -487.7 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
                    newpos = new Vector3(-850.70f,73.05f,-487.70f); // "b121-f01-1071"
                    newrot = 37.8f;
                    break;
                case 2:
                    //grc.LinkToPtxyz("b121-f02-2060-2", -862.30 + xs, 4.280, -506.20 + zs, LinkUse.walkway, comment: ""); //  1 nn:1 nl:0
                    newpos = new Vector3(-862.3f, 77.05f, -506.2f);// "b121-f02-2060-2"
                    newrot = 41.1f;
                    break;
                case 3:
                    newpos = new Vector3(-828.12f, 81.25f, -467.71f);// "b121-f03-31-2"
                    newrot = 48.31f;
                    break;
                case 4:
                    newpos = new Vector3(-821.76f, 81.25f, -480.29f);// "b121-f03-3100-2"
                    newrot = 48.31f;
                    break;
                default:
                    return; // do nothing
            }
            //var bodyeuler = bodyPrefabRotation.eulerAngles;
            RotateViewerToYangle(newrot);
            transform.position = newpos;
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
            //if (Input.GetKey(KeyCode.N))
            //{
            //    SetSceneCamToMainCam();
            //}
            //if (Input.GetKey(KeyCode.D) && Time.time - ctrlDhit > hitgap3)
            //{
            //    showDroppings = !showDroppings;
            //    ctrlDhit = Time.time;
            //}
            if (Input.GetKey(KeyCode.N) && Time.time - ctrlNhit > hitgap3)
            {
                showNormalRod = !showNormalRod;
                ctrlNhit = Time.time;
            }
            if (Input.GetKey(KeyCode.E) && ctrlpressed && Time.time - ctrlEhit > hitgap3)
            {
                ShiftCamPosition();
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
                //Debug.Log($"hit second ctrl-T char");
                if (Input.GetKey(KeyCode.Alpha1))
                {
                    MoveViewerToStoredPos(1);
                }
                if (Input.GetKey(KeyCode.Alpha2))
                {
                    MoveViewerToStoredPos(2);
                }
                if (Input.GetKey(KeyCode.Alpha3))
                {
                    MoveViewerToStoredPos(3);
                }
                if (Input.GetKey(KeyCode.Alpha4))
                {
                    MoveViewerToStoredPos(4);
                }
                //if (!Input.GetKey(KeyCode.T) && !Input.GetKey(KeyCode.RightControl) && !Input.GetKey(KeyCode.LeftControl))
                //{
                //    //ctrlThit = float.MinValue;
                //}
            }
            if (Input.GetKey(KeyCode.T) && ctrlpressed)
            {
                Debug.Log($"hit T {Time.time - ctrlThit} hitgap3:{hitgap3} doTrackThings:{doTrackThings}");
                ctrlThit = Time.time;
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
            if (CheckChange())
            {
                BuildViewer();
            }
            DoKeys();
        }
    }
}