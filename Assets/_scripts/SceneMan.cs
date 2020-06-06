#define UNITYSIM
using System;
using System.Collections.Generic;
using UnityEngine;
#if USE_KEYWORDRECOGNIZER
using UnityEngine.Windows.Speech;
#endif
using System.Linq;
using GraphAlgos;
#if UNITY_EDITOR
using UnityEditor;
#endif
using Aiskwk.Map;

namespace CampusSimulator
{
    public enum RouteGarnishE { none, names, coords, all }

    public enum SceneSelE {  MsftB19focused, Custom, Seattle, MtStHelens,Riggins, Eb12, MsftCoreCampus, MsftRedwest, MsftDublin, Tukwila, None }

    public class SceneMan : MonoBehaviour
    {
        static SceneMan theone = null;

        public LinkedList<string> loglist = null;

        public bool unitySim = false;
        public string logfilenameroot = "brlog";

        public GameObject rgo;
        public float rgoScale = 1.0f;
        public float rgoRotate = 0f;
        public Vector3 rgoTranslate = Vector3.zero;

        public string strans0;
        public string strans1;
        public string strans2;
        public string strans3;

        public float home_height = 1.7f;
        float home_rgoScale = 1.0f;
        float home_rgoRotate = 0f;
        Vector3 home_rgoTranslate = Vector3.zero;

        public bool showTripod = false;
        private bool tripodShown = false;

        public float scaleIncFak = 1.1f;
        public float rotationIncDeg = 2.0f;
        public float tranlsationIncMeter = 1.0f;
        public float gridsize = 2.0f;
        public float linknodescale = 1.0f;
        public RouteGarnishE garnish = RouteGarnishE.none;

        public bool showlookat = false;

        public bool movecamera = false;

        public bool droperrormarkers = false;

        public bool autoerrorcorrect = false;
        private bool needsrefresh = false;
        private bool needstotalrefresh = false;


        public GameObject rmango;

        public LinkCloudMan linkcloudman = null;
        public PathCtrl hlpathctrl = null;
        public BirdCtrl hlbirsctrl = null;
        public StatusCtrl statusctrl = null;
        public ErrorMarkerCtrl errmarkctrl = null;
        public FloorPlanCtrl floorplanctrl = null;
#if USE_KEYWORDRECOGNIZER
        public KeywordMan keyman = null;
#endif

        public int keywordLoadInc = 100;
        public int keywordLimit = 80;
        public int keycount = 0;
        public bool fastMode = false;
        public bool legacyStatus = false;
        public int maxLegacyAvatarGen = 20;
        public int maxLegacyCarGen = 30;
        public string imagesdir = "images/";
        public string labelsdir = "labels/";
        public string graphsdir = "graphs/";

#if USE_SPATIALMAPPPER
        public SpatialMapperMan smm = null;
#endif

        private Vector4 trans0;
        private Vector4 trans1;
        private Vector4 trans2;
        private Vector4 trans3;
        public Transform rgoTransform;
        public int rgoTransformSetCount = 0;
        public int lastRgoTransformSetCount = -1;

        public GarageMan gaman;
        public BuildingMan bdman;
        public MapMan mpman;
        public JourneyMan jnman;
        public VidcamMan vcman;
        public LocationMan loman;
        public PersonMan psman;
        public VehicleMan veman;
        public ZoneMan znman;
        public FrameMan frman;
        public CalibMan cbman;
        public UiMan uiman;
        public string runtimestamp = DateTime.UtcNow.ToString("yyyyMMdd-HHmmss");
        public string simrundir;
        public LinkEditor leditor;

        public bool needsLifted = false;


        public LatLongMap glbllm;

        public bool arcoreTrack = false;

        void InitPhase0()
        {
            // In StartInitPhase0 we do structural initialzation - no logic
            // - Find and initialize statoc component references (those that will not change during execution) so that doesn't have to be done again and again
            // - Add any componets that need to be added
            // - Do StartInitialization on those
            // - (optional) do any internal initialization that does not depend on external links (because they might not have done this yet) 
            // In StartInitPhase1 we do initialization that calls components that have done Phase0

            GraphAlgos.GraphUtil.CheckVersionString();

            theone = this;
            loglist = new LinkedList<string>();
            GraphUtil.loglist = loglist;

            // Create game object to hold ctrl inspectors
            rmango = this.gameObject;
            linkcloudman = GetComponent<LinkCloudMan>();
            linkcloudman.SetSceneMan(this);
            hlpathctrl = rmango.AddComponent<PathCtrl>();
            hlbirsctrl = rmango.AddComponent<BirdCtrl>();
            statusctrl = rmango.AddComponent<StatusCtrl>();
            //errmarkctrl = rmango.AddComponent<ErrorMarkerCtrl>();
            floorplanctrl = rmango.AddComponent<FloorPlanCtrl>();
            hlpathctrl.SetSceneMan(this);
            hlbirsctrl.sman = this;
            statusctrl.SetSceneMan(this);
            //errmarkctrl.SetRegMan(this);
            floorplanctrl.SetSceneMan(this);

            //var cmango = new GameObject("CalibMarkers");
            //cbman = cmango.AddComponent<CalibMan>();

#if USE_KEYWORDRECOGNIZER
            keyman = new KeywordMan(this);
#endif

            rmango.AddComponent<LatLongMap>();

            // Create game object to hold actual game objects
            rgo = new GameObject("Rgo");
            rgoTransformSetCount += 1;

            statusctrl.outMode = StatusCtrl.outModeE.help;
            statusctrl.RealizeMode();

            leditor = rgo.AddComponent<LinkEditor>();
            leditor.InitPhase0(linkcloudman, this);

            SetLegacy(legacyStatus);

#if USE_KEYWORDRECOGNIZER
            keycount = keyman.totalKeywordCount();
#endif
#if USE_SPATIALMAPPER
            smm = FindObjectOfType<SpatialMapperMan>();
#endif
            DisableSpatialMapping();

// Start of new initialzation scheme
            uiman = FindObjectOfType<UiMan>();
            mpman = FindObjectOfType<MapMan>();
            vcman = FindObjectOfType<VidcamMan>();
            bdman = FindObjectOfType<BuildingMan>();
            gaman = FindObjectOfType<GarageMan>();
            znman = FindObjectOfType<ZoneMan>();
            jnman = FindObjectOfType<JourneyMan>();
            loman = FindObjectOfType<LocationMan>();
            psman = FindObjectOfType<PersonMan>();
            veman = FindObjectOfType<VehicleMan>();
            frman = FindObjectOfType<FrameMan>();

            bdman.sman = this;
            znman.sman = this;
            gaman.sman = this;
            jnman.sman = this;
            frman.sman = this;
            vcman.sman = this;
            uiman.sman = this;

            bool subbordinatethemall = false;
            if (subbordinatethemall)
            {
                uiman.transform.parent = rgo.transform;
                mpman.transform.parent = rgo.transform;
                vcman.transform.parent = rgo.transform;
                bdman.transform.parent = rgo.transform;
                gaman.transform.parent = rgo.transform;
                znman.transform.parent = rgo.transform;
                jnman.transform.parent = rgo.transform;
                loman.transform.parent = rgo.transform;
                psman.transform.parent = rgo.transform;
                veman.transform.parent = rgo.transform;
                frman.transform.parent = rgo.transform;
            }

            uiman.InitPhase0();
            mpman.InitPhase0();
            vcman.InitPhase0();
        }

        void InitPhase1()
        {
        }


        public void SetScene( SceneSelE newscene,bool force=false )
        {
            if (newscene != curscene || force)
            {
                try
                {
                    Debug.LogWarning($"SceneMan-Setting scenario to {newscene} - curscene:{curscene} - force:{force}");
                    if (runtimestamp == "")
                    {
                        runtimestamp = DateTime.UtcNow.ToString("yyyyMMdd-HHmmss");
                    }
                    simrundir = "./simrun/" + newscene + "_" + runtimestamp + "/";
                    UxUtils.UxSettingsMan.SetScenario(newscene.ToString());
                    jnman.DeleteAllJourneys();
                    curscene = newscene;
                    //var oldglblm = rmango.GetComponent<LegLatLngMap>();
                    glbllm = rmango.AddComponent<LatLongMap>();
                    glbllm.InitMapFromSceneSel(newscene.ToString(),0); // to do uncomment

                    uiman.SetScene(newscene);

                    linkcloudman.SetScene(newscene);

                    mpman.SetScene(newscene);
                    gaman.SetScene(newscene);
                    vcman.SetScene(newscene);

                    bdman.SetScene(newscene);// building details, but no nodes and links
                    DeleteLinkCloud();

                    linkcloudman.SetScene2(newscene); // create or read in most nodes and links

                    RealizeFloorPlanStatus();
                    psman.SetScene(newscene); // needs to be before we populate the buildings
                    veman.SetScene(newscene); // needs to be before we populate the garages

                    bdman.SetScenePostLinkCloud(newscene);// building details that need nodes and links
                    gaman.SetScenePostLinkCloud(newscene);// garage details that need nodes and links

                    znman.SetScene(newscene);
                    jnman.SetScene(newscene);
                    frman.SetScene(newscene);

                    linkcloudman.SetScene3(newscene);  // realize latelinks    
                    // TODO - put this stuff in a Uiman
                    SetUiScene(newscene);

                    //Debug.Log("SetScene finished");
                }
                catch(Exception ex)
                {
                    Debug.LogError("Scene "+newscene.ToString()+" not initialized successfully Exception:"+ex.ToString());
                }   
            }
            else
            {
                Debug.Log("Scene already set to " + newscene + " so this is a noop");
            }
        }

        public void SetUiScene(SceneSelE newscene)
        {
            var optpan = FindObjectOfType<OptionsPanel>();
            if (optpan != null)
            {
                optpan.SetScene(newscene);
            }
            var span = FindObjectOfType<StatusPanel>();
            if (span != null)
            {
                //Debug.LogWarning($"Resetting StatusPanel for {newscene}");
                span.Init();
                span.ColorizeButtonStates();
            }
            else
            {
                Debug.LogWarning("SceneMan.SetScene - span is null ");
            }
        }

        public void SetArcoreTracking()
        {
            //var tpd = FindObjectOfType<TrackedPoseDriver>();
            //if (tpd!=null)
            //{
            //   // tpd.enabled = arcoreTrack;
            //}
#if USE_ARCORE
            var iptpd = FindObjectOfType<GoogleARCore.InstantPreviewTrackedPoseDriver>();
            if (iptpd != null)
            {
                iptpd.enabled = arcoreTrack;
            }
#endif
        }

        public void RequestRefresh(string requester,bool totalrefresh=false)
        {
            Debug.Log($"RefreshRequested by {requester} total:{totalrefresh}");    
            needsrefresh = true;
            if (totalrefresh)
            {
                // note that just setting this to totalrefresh would overwrite other totalrefresh requests
                needstotalrefresh = true; 
            }
        }
        public (bool refresh,bool totalrefresh) GetRefreshStatus()
        {
            return (needsrefresh, needstotalrefresh);
        }
        public void RequestHighObjRefresh(string highobjname,string requester)
        {
            //Debug.Log("RefreshHighObjRequested by " + requester);
            needsrefresh = true;
            //this.highobjnames.Add(highobjname);
        }
        public void ToggleDropErrorMarkers()
        {
            droperrormarkers = !droperrormarkers;
        }
        public void CorrectOnErrorMarkers()
        {
            // Debug.Log("CorrectOnErrorMarkers called");
            //errmarkctrl.FinishMarking();
            //var foundCorrection = errmarkctrl.CalculateOptimalTransformation();
            //if (foundCorrection)
            //{
            //    CorrectAngle(errmarkctrl.rotvek_deg.y);
            //    CorrectPositionDiff(errmarkctrl.trnvek_met);
            //}
        }
        public void StartErrorMarking(int n = 5)
        {
            //errmarkctrl.startMarking(n);
        }
        public void FinishErrorMarking()
        {
            //errmarkctrl.CalculateOptimalTransformation();
        }
        public void EnableSpatialMapping()
        {
            //if (smm != null)
            //{
            //    smm.SetSpatialMapping(true);
            //}
        }
        public void DisableSpatialMapping()
        {
            //if (smm != null)
            //{
            //    smm.SetSpatialMapping(false);
            //}
        }
        public void IncSpatialExtent()
        {
            //if (smm != null)
            //{
            //    smm.ChangeSpatialExtent(2.0f);
            //}
        }
        public void DecSpatialExtent()
        {
            //if (smm != null)
            //{
            //    smm.ChangeSpatialExtent(-2.0f);
            //}
        }
        public void IncSpatialDetail()
        {
            //if (smm != null)
            //{
            //    smm.ChangeSpatialDetail(1);
            //}
        }
        public void DecSpatialDetail()
        {
            //if (smm != null)
            //{
            //    smm.ChangeSpatialDetail(-1);
            //}
        }
        public static void Log(string msg)
        {
            if (theone != null)
            {
                if (theone.loglist != null)
                {
                    theone.loglist.AddFirst(msg);
                }
            }
        }

#region linkcloud commands
        public void SetFov(float fov)
        {
            var maincam = Camera.main; // only works with one camera and might be better with camera.current
            maincam.fieldOfView = fov;
        }
#endregion


#region linkcloud commands

        private Vector3 adjustDiff(Vector3 diff)
        {
            var angrad = Mathf.PI * rgoRotate / 180;
            var x = Mathf.Cos(angrad) * diff.x - Mathf.Sin(angrad) * diff.z;
            var y = diff.y;
            var z = Mathf.Sin(angrad) * diff.x + Mathf.Cos(angrad) * diff.z;
            return new Vector3(x, y, z);
        }
        public Vector3 GetCurrentPosition()
        {
            var maincam = Camera.main; // only works with one camera and might be better with camera.current
            var campt = maincam.transform.position;
            return campt;
        }
        public void CorrectPositionDiff(Vector3 diff)
        {
            rgoTranslate = rgoTranslate - diff;
            //StopBird();
            RequestRefresh("SceneMan-CorrectPositionDiff");
        }

        public void CorrectPosition(Vector3 ptwc)
        {
            var maincam = Camera.main; // only works with one camera and might be better with camera.current
            var campt = maincam.transform.position;
            //campt.y = 0;
            var diff = ptwc - campt;
            diff.y += home_height;
            var adiff = adjustDiff(diff);
            //var adiff = diff;
            Debug.Log("Campt:" + campt + "  ptwc:" + ptwc + " hh:" + home_height + "  diff:" + diff + "  adiff:" + adiff);
            rgoTranslate = rgoTranslate - adiff;
            //StopBird();
            RequestRefresh("SceneMan-CorrectPosition");
        }

        public void CorrectPosition()
        {
            var maincam = Camera.main; // only works with one camera and might be better with camera.current
            var campt = maincam.transform.position;
            //campt.y = 0;
            var pathcampt = hlpathctrl.FindClosestPointOnPath(campt);
            //pathcampt.y = 0;
            //var ppwc = pathctrl.pathgo.transform.TransformPoint(pathcampt);
            var ppwc = pathcampt;
            SceneMan.Log("CP pathcampt:" + pathcampt + "  ppwc:" + ppwc);
            CorrectPosition(ppwc);
        }
        public void CorrectAngle(float dang, bool refresh = true)
        {
            rgoRotate = rgoRotate - dang;
            if (refresh)
            {
                //StopBird();
                RequestRefresh("SceneMan-CorrectAngle");
            }
        }
        public void CorrectAngleOnVectors(Vector3 vk1, Vector3 vk2, bool refresh = true)
        {
            vk1 = Vector3.Normalize(vk1);
            vk2 = Vector3.Normalize(vk2);
            var ang1 = 180 * Mathf.Atan2(vk1.z, vk1.x) / Mathf.PI;
            var ang2 = 180 * Mathf.Atan2(vk2.z, vk2.x) / Mathf.PI;
            SceneMan.Log("vk2:" + vk2 + "  ang2:" + ang2 + "  vk1:" + vk1 + " ang1:" + ang1);
            var dang = ang2 - ang1;
            rgoRotate = rgoRotate - dang;
            if (refresh)
            {
                //StopBird();
                RequestRefresh("SceneMan-CorrectAngleOnVectors");
            }
        }
        public float CorrectAngle(bool refresh = true)
        {
            var maincam = Camera.main; // only works with one camera and might be better with camera.current
            var camfor = maincam.transform.forward;
            // find closet link and get its direction
            var campt = maincam.transform.position;
            campt.y = 0;
            float nearptpathdist = 0;
            var pathweg = hlpathctrl.FindClosestWegOnPath(campt, out nearptpathdist);
            var wegdir = pathweg.GetWegDirection(normalized: true);
            var wegdirwc = rgo.transform.TransformVector(wegdir);
            CorrectAngleOnVectors(wegdirwc, camfor, refresh: refresh);
            return (nearptpathdist);
        }
        public void CorrectPositionAndAngle()
        {
            var pdist = CorrectAngle();
            var pp = hlpathctrl.path.MovePositionAlongPath(pdist);
            // var ppwc = pathctrl.pathgo.transform.TransformPoint(pp.pt); // why do we have to do this? Should be wc already?
            var ptwc = rgo.transform.TransformPoint(pp.pt);
            SceneMan.Log("Both pdist:" + pdist + "  pp.pt:" + pp.pt + "  ptwc:" + ptwc);
            CorrectPosition(ptwc);
        }
        public void RevertToHome()
        {
            rgoRotate = home_rgoRotate;
            rgoScale = home_rgoScale;
            rgoTranslate = home_rgoTranslate;
            rgoTransformSetCount += 1;

            //StopBird();
            RequestRefresh("SceneMan-RevertToHome");
        }
        public void OrientToEndNode(string newenodename)
        {
            SceneMan.Log("OrientToEndNode:" + newenodename);
            home_rgoRotate = rgoRotate;
            home_rgoScale = rgoScale;
            home_rgoTranslate = rgoTranslate;
            home_height = Camera.main.transform.position.y; // camera.current might be more performant

            var lpt = linkcloudman.GetNode(newenodename);
            if (lpt.wegtos.Count == 0) return;
            var wa = lpt.wegtos.First(); // get the first one, it should suffice
            var lnk = wa.link;
            //var p1wc = lnk.lp1.transform.TransformPoint(lnk.lp1.pt);
            //var p2wc = lnk.lp2.transform.TransformPoint(lnk.lp2.pt);
            //var p1wc = lnk.lp1.ptwc;
            //var p2wc = lnk.lp2.ptwc;
            //var lnkdir = p2wc - p1wc;
            var wfr = wa.frNode.pt;
            var wto = wa.toNode.pt;
            var wfrwc = rgo.transform.TransformPoint(wfr);
            var wtowc = rgo.transform.TransformPoint(wto);
            var lnkdir = wfr - wto;
            lnkdir = rgo.transform.TransformVector(lnkdir);
            SceneMan.Log("CorrectAngle");
            SceneMan.Log("lpt.name:" + lpt.name + "  wfr:" + wfr + " wto:" + wto);
            SceneMan.Log("      wc:" + lpt.name + "  wfrwc:" + wfrwc + " wtowc:" + wtowc);
            var camfor = Camera.main.transform.forward;// camera.current might be more performant
            CorrectAngleOnVectors(lnkdir, camfor);

            // Position
            lpt = linkcloudman.GetNode(newenodename);
            wa = lpt.wegtos.First();
            var wto1 = wa.toNode.pt;
            var wto1wc = rgo.transform.TransformPoint(wto1);
            CorrectPosition(wto1wc);
            SceneMan.Log("CorrectPosition");
            SceneMan.Log("Node:" + lpt.name + "  wto1:" + wto1 + " wto1wc:" + wto1wc);
        }
        public void writeLogToFile()
        {
            var fname = this.logfilenameroot;
            fname += System.DateTime.Now.ToString("yyyyMMddTHHmmss") + ".log";
            GraphUtil.writeListToFile(loglist.ToList<string>(), fname);
            SceneMan.Log("Wrote " + loglist.Count + " lines to " + fname);
            Debug.Log("Wrote " + loglist.Count + " lines to " + fname);
        }

        public void NextGarnish()
        {
            switch (garnish)
            {
                case RouteGarnishE.none: garnish = RouteGarnishE.names; break;
                case RouteGarnishE.names: garnish = RouteGarnishE.none; break;
                case RouteGarnishE.coords: garnish = RouteGarnishE.all; break;
                case RouteGarnishE.all: garnish = RouteGarnishE.none; break;
            }
            RequestRefresh("SceneMan-NextGarnish");
        }
        //public void SetBallColor(string color)
        //{
        //    linkcloudnodecolor = color;
        //    RefreshRegionManGos();
        //}
        //public void SetPipeColor(string color)
        //{
        //    linkcloudlinkcolor = color;
        //    RefreshRegionManGos();
        //}

        public void IncInc()
        {
            scaleIncFak = scaleIncFak * 1.1f;
            rotationIncDeg = rotationIncDeg * 2f;
            tranlsationIncMeter = tranlsationIncMeter * 2f;
            keywordLoadInc *= 2;
            SceneMan.Log("ScaInfFak " + scaleIncFak + "  rotIncDeg:" + rotationIncDeg +
                          "transIncM " + tranlsationIncMeter + "  keyInc:" + keywordLoadInc);
        }
        public void DecInc()
        {
            scaleIncFak = scaleIncFak / 1.1f;
            rotationIncDeg = rotationIncDeg / 2f;
            tranlsationIncMeter = tranlsationIncMeter / 2f;
            keywordLoadInc /= 2;
            SceneMan.Log("ScaInfFak " + scaleIncFak + "  rotIncDeg:" + rotationIncDeg +
                          "transIncM " + tranlsationIncMeter + "  keyInc:" + keywordLoadInc);
        }
        public void IncKeyLimit()
        {
            keywordLimit += keywordLoadInc;
            linkcloudman.SetKeyWordLimit(keywordLimit);
            SceneMan.Log("Keywordlimit " + keywordLimit + "  keyInc:" + keywordLoadInc);
        }
        public void DecKeyLimit()
        {
            keywordLimit -= keywordLoadInc;
            linkcloudman.SetKeyWordLimit(keywordLimit);
            SceneMan.Log("Keywordlimit " + keywordLimit + "  keyInc:" + keywordLoadInc);
        }
        public void Grow()
        {
            ScaleEverything(scaleIncFak);
        }
        public void Shrink()
        {
            ScaleEverything(1 / scaleIncFak);
        }
        public void TranslateLeft()
        {
            var tinc = Vector3.left * tranlsationIncMeter;
            TranslateEverything(tinc);
        }
        public void TranslateRight()
        {
            var tinc = Vector3.right * tranlsationIncMeter;
            TranslateEverything(tinc);
        }
        public void TranslateUp()
        {
            var tinc = Vector3.up * tranlsationIncMeter;
            TranslateEverything(tinc);
        }
        public void TranslateDown()
        {
            var tinc = Vector3.down * tranlsationIncMeter;
            TranslateEverything(tinc);
        }
        public void TranslateForward()
        {
            var tinc = Vector3.forward * tranlsationIncMeter;
            TranslateEverything(tinc);
        }
        public void TranslateBack()
        {
            var tinc = Vector3.back * tranlsationIncMeter;
            TranslateEverything(tinc);
        }
        public void RotateCw()
        {
            RotateEverything(rotationIncDeg);
        }
        public void RotateCcw()
        {
            RotateEverything(-rotationIncDeg);
        }
        public void Rotate()
        {
            ScaleEverything(1 / scaleIncFak);
        }
        public void Grow01()
        {
            ScaleEverything(1.01f);
        }
        public void Shrink01()
        {
            ScaleEverything(1 / 1.01f);
        }
        public void Grow10()
        {
            ScaleEverything(1.1f);
        }
        public void Shrink10()
        {
            ScaleEverything(1 / 1.1f);
        }
        public void Grow50()
        {
            ScaleEverything(2.0f);
        }
        public void Shrink50()
        {
            ScaleEverything(0.5f);
        }
        public void ScaleEverything(float sfak)
        {
            rgoScale = sfak * rgoScale;
            rgoTransformSetCount += 1;

            //const float rgoScaleMin = 0.01375f;
            //  rgoScale = Mathf.Max(rgoScale, rgoScaleMin);
            //Debug.Log("ScaleEverything sfak:" + sfak + "  rgoScale:" + rgoScale);
            RequestRefresh("SceneMan-ScaleEverything");
        }
        public void GridOff()
        {

        }
        public void GridOn()
        {

        }
        public void GridBigger()
        {
            gridsize *= 2;
        }
        public void GridSmaller()
        {
            gridsize /= 2;
        }
        public void ForceRegen()
        {
            RefreshSceneManGos(); // ForceRegen
        }
        public void ResetHomeHeight()
        {
            home_height = 1.7f;
            SceneMan.Log("Reset HomeHeight:" + home_height);
        }
        public void RotateEverything(float rinc)
        {
            rgoRotate = rgoRotate + rinc;
            SceneMan.Log("RotateEverything rinc:" + rinc + "  rgoRotate:" + rgoRotate);
            RequestRefresh("SceneMan-RotateEverything");
        }
        public void ToggleMoveCamera()
        {
            movecamera = !movecamera;
            SceneMan.Log("Movecamera now:" + movecamera);
        }
        public void ToggleFloorPlan()
        {
            floorplanctrl.visible = !floorplanctrl.visible;
            RealizeFloorPlanStatus();
            RequestRefresh("SceneMan-ToggleFloorPlan");
        }
        public void SetLegacy(bool newval)
        {
            legacyStatus = newval;
            if (legacyStatus)
            {
                maxLegacyAvatarGen = 50;
                BldEvacAlarm.outAlarmAldeboColor = "deeppurple";
            }
            else
            {
                maxLegacyAvatarGen = 20;
                BldEvacAlarm.outAlarmAldeboColor = "darkgray";
            }
            RequestRefresh("SceneMan-SetLegacy");
        }
        public void SetFastMode(bool newval)
        {
            fastMode = newval;
            RequestRefresh("SceneMan-SetFastMode");
        }
        public void ToggleLegacy()
        {
            SetLegacy(!legacyStatus);
        }

        public void ToggleFastMode()
        {
            SetFastMode(!fastMode);
        }
        public void RealizeFloorPlanStatus()
        {
            if (floorplanctrl.visible)
            {
                var lcld = linkcloudman.GetGraphCtrl();
                floorplanctrl.setGraphtex(lcld.floorMan);
            }
            SceneMan.Log("Show floor plan:" + floorplanctrl.visible);
        }
        public void TranslateEverything(Vector3 tinc)
        {
            if (movecamera)
            {
                Camera.main.transform.position += tinc; // camera.current?
                SceneMan.Log("TranslateEverything tinc:" + tinc + "  Moved Camera");
            }
            else
            {
                rgoTranslate = rgoTranslate + tinc;
                SceneMan.Log("TranslateEverything tinc:" + tinc + "  rgoTranslate:" + rgoTranslate);
                RequestRefresh("SceneMan-TranslateEverything");
            }
        }
        public void GenCampus()
        {
            DeleteLinkCloud();
            linkcloudman.GenLinkCloud(graphSceneE.gen_campus, GraphGenerationModeE.GenFromCode);
            //floorplanctrl.visible = true;
            RealizeFloorPlanStatus();
            //CreateLinkCloud();
        }
        public void Gen43_1()
        {
            DeleteLinkCloud();
            linkcloudman.GenLinkCloud(graphSceneE.gen_b43_1, GraphGenerationModeE.GenFromCode);
            //floorplanctrl.visible = true;
            RealizeFloorPlanStatus();
            //CreateLinkCloud();
        }
        public void Gen43_2()
        {
            DeleteLinkCloud();
            linkcloudman.GenLinkCloud(graphSceneE.gen_b43_2, GraphGenerationModeE.GenFromCode);
            //floorplanctrl.visible = true;
            RealizeFloorPlanStatus();
            //CreateLinkCloud();
        }
        public void Gen43_3()
        {
            DeleteLinkCloud();
            linkcloudman.GenLinkCloud(graphSceneE.gen_b43_3, GraphGenerationModeE.GenFromCode);
            //floorplanctrl.visible = true;
            RealizeFloorPlanStatus();
            //CreateLinkCloud();
        }
        public void Gen43_4()
        {
            DeleteLinkCloud();
            linkcloudman.GenLinkCloud(graphSceneE.gen_b43_4, GraphGenerationModeE.GenFromCode);
            //floorplanctrl.visible = true;
            RealizeFloorPlanStatus();
            //CreateLinkCloud();
        }
        public void GenBHO()
        {
            DeleteLinkCloud();
            linkcloudman.GenLinkCloud(graphSceneE.gen_bho, GraphGenerationModeE.GenFromCode);
            //floorplanctrl.visible = true;
            RealizeFloorPlanStatus();
            //CreateLinkCloud();
        }
        public void GenSphere()
        {
            linkcloudman.GenLinkCloud(graphSceneE.gen_sphere, GraphGenerationModeE.GenFromCode);
            RequestRefresh("SceneMan-GenSphere");
        }
        public void GenCirc()
        {

            linkcloudman.GenLinkCloud(graphSceneE.gen_circ, GraphGenerationModeE.GenFromCode);
            RequestRefresh("SceneMan-GenCirc");
        }
        public void Gen431p2()
        {
            DeleteLinkCloud();
            linkcloudman.GenLinkCloud(graphSceneE.gen_b43_1p2, GraphGenerationModeE.GenFromCode);
            //floorplanctrl.visible = true;
            RealizeFloorPlanStatus();
            //CreateLinkCloud();
            ScaleEverything(0.1375f / 2.0f);
        }

         public void GenRedwb3()
        {
            DeleteLinkCloud();
            linkcloudman.GenLinkCloud(graphSceneE.gen_redwb_3, GraphGenerationModeE.GenFromCode);
            //floorplanctrl.visible = true;
            RealizeFloorPlanStatus();
            //CreateLinkCloud();
            //keycount = keyman.totalKeywordCount();
        }
        public void SaveToJsonFile()
        {
            System.IO.Directory.CreateDirectory(graphsdir);
            string fname = graphsdir + curscene.ToString() + ".json";
            Debug.Log("Saving to Json file:" + fname);
            linkcloudman.SaveToJsonFile(fname);
        }
        public void SaveRegionFiles()
        {
            System.IO.Directory.CreateDirectory(graphsdir);
            linkcloudman.SaveRegionFiles(graphsdir);
        }
        public void SaveRegionCodeFiles()
        {
            System.IO.Directory.CreateDirectory(graphsdir);
            linkcloudman.SaveRegionCodeFiles(graphsdir);
        }
        public void NoiseUpNodes(float maxdist)
        {
            linkcloudman.NoiseUpNodes(maxdist);
            RequestRefresh("SceneMan-NoiseUpNodes");
        }
        public void CleanStart()
        {
            DeleteLinkCloud();
        }
        //[MenuItem("LinkCloud/Generate")]
        //public void CreateLinkCloud()
        //{
        //    hlpathctrl.path = null;
        //    // DeleteLinkCloud();
        //    RequestRefresh("SceneMan-CreateLinkCloud");
        //    //SetStartAndEndNode("f01-dt-ps01r", "f01-dt-rm1002");
        //    //SetStartAndEndNode(linkcloudctrl.defSnode, linkcloudctrl.defEnode); ???
        //    //SetEndNode();
        //    //Astar();
        //    //initKeywordsWithRooms();
        //}
        public void DeleteLinkCloud()
        {
            //floorplanctrl.visible = false;
            hlbirsctrl.DeleteBird();
            hlpathctrl.DeletePath();
            linkcloudman.DelLinkCloud();
        }
        public void DeleteLink(string name)
        {
            linkcloudman.DeleteLink(name);
        }
        public void SplitLink(string name)
        {
            leditor.SplitLink(name);
        }
        public void ClearClipboard()
        {
            GraphUtil.Clipboard = "";
        }
        public void StartStretchMode()
        {
            leditor.StartStretchMode();
        }
        public void LinkNodes(string nodename1,string nodename2)
        {
            linkcloudman.LinkNodes(nodename1,nodename2);
        }
        public void DeleteNode(string name)
        {
            linkcloudman.DeleteNode(name);
        }

        public void ToggleLinkCloudVisibily()
        {
            linkcloudman.nodesvisible = !linkcloudman.nodesvisible;
            linkcloudman.linksvisible = !linkcloudman.linksvisible;
            RequestRefresh("SceneMan-ToggleLinkCloudVisibily");
        }
        public void RotateSlotForm()
        {
            gaman.RotateSlotForm();
            RequestRefresh("SceneMan-RotateSlotForm");
        }
        public void ShowRoute()
        {
            linkcloudman.nodesvisible = true;
            linkcloudman.linksvisible = true;
            hlpathctrl.visible = true;
            RequestRefresh("SceneMan-ShowRoute");
        }
        public void HideRoute()
        {
            linkcloudman.nodesvisible = false;
            linkcloudman.linksvisible = false;
            hlpathctrl.visible = false;
            RequestRefresh("SceneMan-HideRoute");
        }
        public void HideLinks()
        {
            linkcloudman.nodesvisible = true;
            linkcloudman.linksvisible = false;
            hlpathctrl.visible = true;
            RequestRefresh("SceneMan-HideLinks");
        }
        public void ShowLinks()
        {
            linkcloudman.nodesvisible = true;
            linkcloudman.linksvisible = true;
            hlpathctrl.visible = true;
            RequestRefresh("SceneMan-ShowLinks");
        }
#endregion

#region birdcommands
        public void StartBird()
        {
            if (hlbirsctrl.isAtGoal())
            {
                ReversePath();
            }
            hlbirsctrl.StartBird();
        }
        public void PauseBird()
        {
            hlbirsctrl.PauseBird();
        }
        public void UnPauseBird()
        {
            hlbirsctrl.UnPauseBird();
        }
        public void StopBird()
        {
            if (hlpathctrl.path != null)
            {
                var bpos = hlbirsctrl.GetBirdPos();
                var lpt = linkcloudman.PunchNewNode(bpos, deleteparentlink: true);
                hlpathctrl.startnodename = lpt.name;
                hlpathctrl.GenAstarPath();
                PropagatePath();
                RequestRefresh("SceneMan-StopBird");
            }
        }
        public void ResetCalled()
        {
            if (hlpathctrl.path == null)
            {
                hlpathctrl.GenAstarPath();
            }
            //birdctrl.ResetBirdToStartOfPath();
        }
        public void FasterBird()
        {
            hlbirsctrl.AdjustSpeed(1.7f, 0.5f);
        }
        public void SlowerBird()
        {
            hlbirsctrl.AdjustSpeed(1 / 1.7f, 0.5f);
        }
        public void SetSpeed(float newvel)
        {
            if (hlbirsctrl.isAtStart())
            {
                StartBird();
            }
            hlbirsctrl.SetSpeed(newvel);
        }
        public void DeleteBird()
        {
            hlbirsctrl.DeleteBird();
        }
        public void NextBirdForm()
        {
            hlbirsctrl.NextForm();
            hlbirsctrl.RefreshBirdGos();
        }
        public void NextSlotForm()
        {
            gaman.RotateSlotForm();
            RequestRefresh("SceneMan-NextSlotForm");
        }
        public void FlyBirdHigher()
        {
            hlbirsctrl.AdjustBirdHeight(1.25f);
        }
        public void FlyBirdLower()
        {
            hlbirsctrl.AdjustBirdHeight(1 / 1.25f);
        }
#endregion

        public void PropagatePath()
        {
            var path = hlpathctrl.path;
            hlbirsctrl.SetBirdPath(path);
            //errmarkctrl.SetErrorMarkPath(path);
        }

        #region scenecommands
        public void ToggleTrees()
        {
            bdman.ToggleTrees();
            RequestRefresh("SceneMan-ToggleTrees");
        }
        #endregion

        #region pipecommands
        public void Astar()
        {
            hlpathctrl.GenAstarPath();
            PropagatePath();
            RequestRefresh("SceneMan-Astar");
        }
        public void SetStartNode(string newenodename)
        {
            if (hlbirsctrl.isRunning())
            {
                StopBird();  // If we reset the endnode during running we need to stop and set a new node there
            }
            hlpathctrl.startnodename = newenodename;
            hlpathctrl.GenAstarPath();
            PropagatePath();
            RequestRefresh("SceneMan-SetStartNode");
        }
        public enum RoomActionE { makeDestination, orientOn, makeStart, makeHome }
        public RoomActionE roomAction = RoomActionE.makeDestination;

        public bool loadVoiceKeysForAllRooms = false;

        public void togglLoadVoiceKeysForAllRooms()
        {
            loadVoiceKeysForAllRooms = !loadVoiceKeysForAllRooms;
            SceneMan.Log("loadVoiceKeysForAllRooms set to:" + loadVoiceKeysForAllRooms);
        }

#region status info commands
        public void NextInfoMode()
        {
            statusctrl.NextInfoMode();
        }
        public void SetStatusInfoMode(StatusCtrl.outModeE mode)
        {
            statusctrl.outMode = mode;
            //statusctrl.RealizeMode();
        }
        public void ScrollStatus(int n)
        {
            //statusctrl.scroll(n);
        }
        public void ScrollPage(int n)
        {
            //statusctrl.scrollpage(n);
        }
#endregion

        public void SetRoomAction(RoomActionE action)
        {
            roomAction = action;
        }
        public void NodeAction(string nodename)
        {
            //Debug.Log("NodeAction node:" + nodename + " action:" + roomAction);
            switch (roomAction)
            {
                case RoomActionE.orientOn:
                    {
                        OrientToEndNode(nodename);
                        break;
                    }
                case RoomActionE.makeDestination:
                    {
                        SetEndNode(nodename);
                        break;
                    }
                case RoomActionE.makeStart:
                    {
                        SetStartNode(nodename);
                        break;
                    }
                case RoomActionE.makeHome:
                    {
                        OrientToEndNode(nodename);
                        SetStartNode(nodename);
                        break;
                    }
            }
        }
        public void SetEndNode(string newenodename)
        {
            bool restartbird = false;
            if (!linkcloudman.IsNodeName(newenodename)) return;
            if (hlbirsctrl.isAtGoal())
            {
                //var tmp = pathctrl.startnodename;
                hlpathctrl.startnodename = hlpathctrl.endnodename;
                // this keeps the path from hopping away to the start point
                // when we change the end node when we are finished and want to go somewhere else
                // note that calling ReversePath leads to a stackoverflow
            }
            if (hlbirsctrl.isRunning())
            {
                StopBird();  // If we reset the endnode during running we need to stop and set a new node there
                restartbird = true;
            }
            hlpathctrl.endnodename = newenodename;
            hlpathctrl.GenAstarPath();
            PropagatePath();
            RequestRefresh("SceneMan-SetEndNode");
            if (restartbird)
            {
                StartBird();
            }
        }
        public void SetRandomEndNode()
        {
            var lpt = linkcloudman.GetRandomNode();
            SetEndNode(lpt.name);
        }
        public void ReversePath()
        {
            var tmp = hlpathctrl.startnodename;
            hlpathctrl.startnodename = hlpathctrl.endnodename;
            SetEndNode(tmp);
        }
        public void RandomPath()
        {
            hlpathctrl.GenRanPath();
            PropagatePath();
            RequestRefresh("SceneMan-RandomPath");
        }
        public void DeletePath()
        {
            hlpathctrl.DeletePath();
        }
        public void TogglePathVisibily()
        {
            hlpathctrl.visible = !hlpathctrl.visible;
            hlpathctrl.RefreshGos();
        }
#endregion


        private List<string> highobjnames = new List<string>();
        private string highobactselname = "";
        public void saveHighobs()
        {
#if UNITY_EDITOR
            var selgos = UnityEditor.Selection.gameObjects;
            // string selojbnames = "";
            foreach (var selgo in selgos)
            {
                highobjnames.Add(selgo.name);
                // selojbnames += "|" + selgo.name;
            }
            var actgo = UnityEditor.Selection.activeGameObject;
            if (actgo != null)
            {
                highobactselname = actgo.name;
                // Debug.Log("Saved " + highobactselname);
            }
            else
            {
                // Debug.Log("Nothing selected");
            }
            //Debug.Log("Saved"+selojbnames);
#endif
        }
        void restoreHighobs()
        {
#if UNITY_EDITOR
            var actgo = GameObject.Find(highobactselname);
            if (actgo != null)
            {
                UnityEditor.Selection.activeGameObject = actgo;
                // Debug.Log("Restored:" + actgo.name);
            }
            else
            {
                // Debug.Log("Not Restored (actogo is null):" + highobactselname);
            }
            if (highobjnames.Count > 0)
            {
                List<GameObject> listgos = new List<GameObject>();
                //  string selogjnames = "";
                foreach (var selname in highobjnames)
                {
                    GameObject selgo = GameObject.Find(selname);
                    if (selgo != null)
                    {
                        listgos.Add(selgo);
                        // selogjnames += "|" + selgo.name;
                    }
                }
                var selgos = listgos.ToArray();
                UnityEditor.Selection.objects = selgos;
                // Debug.Log("Restored:" + selogjnames);
            }
#endif
        }
        void clearhighobs()
        {
            highobjnames.Clear();
            highobactselname = "";
        }

#region gameobject management
        public void RefreshSceneManGos()
        {
            // Cleanse the transform :)
            //saveHighobs();
            rgo.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            rgo.transform.localScale = Vector3.one;

            // This is Unity wierdness - it should work doing things before
            //            rgo.transform.localScale = new Vector3(rgoScale, rgoScale, rgoScale);
            //            rgo.transform.Rotate(0, rgoRotate, 0);
            //            rgo.transform.Translate(rgoTranslate);

            linkcloudman.RefreshGos();
            hlpathctrl.RefreshGos();
            hlbirsctrl.RefreshBirdGos();
            //errmarkctrl.RefreshGos();
            floorplanctrl.RefreshGos();
            gaman.RefreshGos();
            bdman.RefreshGos();
            vcman.RefreshGos();
            cbman?.RefreshGos();

            // We have to do it afterwards - that is the trick :)
            rgo.transform.localScale = new Vector3(rgoScale, rgoScale, rgoScale);
            rgo.transform.Rotate(0, rgoRotate, 0);
            rgo.transform.Translate(rgoTranslate);
            rgoTransformSetCount += 1;

            SceneMan.Log("Refresh rgo - Scale:" + rgoScale + "  Rotate:" + rgoRotate + " Translate:" + rgoTranslate);
            //keycount = keyman.totalKeywordCount();
            //restoreHighobs();

        }
#endregion

        //public string startnodecolor = "green";
        //public string endnodecolor = "red";
        //public string linkcloudnodecolor = "blue";
        //public string linkcloudnodecolorx = "steelblue";
        //public string linkcloudlinkcolor = "yellow";
        //public string linkhighwaycolor = "steelblue";
        //public string pathnodecolor = "cyan";
        //public string pathlinkcolor = "purple";
        //public string pathlookatcolor = "steelblue";


        public enum RmColorModeE { nodepathstart, nodepathend, nodecloud, nodecloudx,  linkcloud,linkhighway,linkroad,linkslowroad,linkdriveway, linkwalk,linkwalknoshow, linkexcavate, linksurvey,linkwater,linkreclaimwater,linksewer, linkelec,linkcomms,linkoilgas, pathnode, pathlink, pathlookat }
        public Dictionary<RmColorModeE, string> lcclrdict = new Dictionary<RmColorModeE, string>()
        {
            { RmColorModeE.nodepathstart, "green"},
            { RmColorModeE.nodepathend, "red"},
            { RmColorModeE.nodecloud, "navyblue"},
            { RmColorModeE.nodecloudx, "steelblue"},
            { RmColorModeE.linkcloud, "yellow"},
            { RmColorModeE.linkhighway, "black"},
            { RmColorModeE.linkroad, "darkgray"},
            { RmColorModeE.linkslowroad, "gray"},
            { RmColorModeE.linkdriveway, "lightgray"},
            { RmColorModeE.linkwalk, "pink"},
            { RmColorModeE.linkwalknoshow, "darkgray"},

            { RmColorModeE.linkexcavate, "white"},
            { RmColorModeE.linksurvey, "red"},
            { RmColorModeE.linkwater, "darkblue"},
            { RmColorModeE.linkreclaimwater, "purple"},
            { RmColorModeE.linksewer, "darkgreen"},
            { RmColorModeE.linkelec, "darkorange"},
            { RmColorModeE.linkcomms, "lightorange"},
            { RmColorModeE.linkoilgas, "lightyellow"},

            { RmColorModeE.pathnode, "cyan"},
            { RmColorModeE.pathlink, "purple"},
            { RmColorModeE.pathlookat, "steelblue"},
        };

        public Dictionary<RmColorModeE, float> lcradiusdict = new Dictionary<RmColorModeE, float>()
        {
            { RmColorModeE.nodepathstart, 0.1f},
            { RmColorModeE.nodepathend,  0.1f},
            { RmColorModeE.nodecloud,  0.1f},
            { RmColorModeE.nodecloudx,  0.1f},
            { RmColorModeE.linkcloud,  0.1f},
            { RmColorModeE.linkhighway,  0.4f},
            { RmColorModeE.linkroad,  0.3f},
            { RmColorModeE.linkslowroad,  0.2f},
            { RmColorModeE.linkdriveway,  0.2f},
            { RmColorModeE.linkwalk,  0.1f},
            { RmColorModeE.linkwalknoshow,  0.02f},

            { RmColorModeE.linkexcavate,  0.1f},
            { RmColorModeE.linksurvey,  0.1f},
            { RmColorModeE.linkwater,  0.1f},
            { RmColorModeE.linkreclaimwater,  0.1f},
            { RmColorModeE.linksewer,  0.1f},
            { RmColorModeE.linkelec,  0.1f},
            { RmColorModeE.linkcomms,  0.1f},
            { RmColorModeE.linkoilgas,  0.1f},

            { RmColorModeE.pathnode,  0.1f},
            { RmColorModeE.pathlink,  0.1f},
            { RmColorModeE.pathlookat,  0.1f},
        };

        public string getcolorname(RmColorModeE mode, string name = "")
        {
            if (mode == RmColorModeE.nodecloud || mode == RmColorModeE.nodecloudx)
            {
                if (name == hlpathctrl.startnodename) mode = RmColorModeE.nodepathstart;
                if (name == hlpathctrl.endnodename) mode = RmColorModeE.nodepathend;
            }
            if (!lcclrdict.ContainsKey(mode))
            {
                Debug.Log("lccclrdict does not contain the key " + mode);
//                return (lcclrdict[RmColorModeE.linkcloud]);
            }
            return (lcclrdict[mode]);
        }
        public float getradius(RmColorModeE mode)
        {
            return linknodescale*lcradiusdict[mode];
        }

        public SceneSelE curscene = SceneSelE.None;
        #region SceneOptions
        static List<string> sceneOptions = new List<string>(System.Enum.GetNames(typeof(SceneSelE)));
        static string initialSceneOptionsKey = "InitialScene";
        public static List<string> GetSceneOptionsList()
        {
            return sceneOptions;
        }
        public static string GetSceneOptionsString(int ival)
        {
            return sceneOptions[ival];
        }
        public static SceneSelE GetSceneOptionsEnum(string sval)
        {
            SceneSelE enumval;
            System.Enum.TryParse<SceneSelE>(sval, true, out enumval);
            return enumval;
        }
        public static SceneSelE GetInitialSceneOption()
        {
            var einival = SceneSelE.MsftB19focused; // default scene
            if (PlayerPrefs.HasKey(initialSceneOptionsKey))
            {
                var inival = PlayerPrefs.GetString(initialSceneOptionsKey, "");
                einival = GetSceneOptionsEnum(inival);
            }
            return einival;
        }
        public static void SetInitialSceneOption(string inisval)
        {
            PlayerPrefs.SetString(initialSceneOptionsKey, inisval);
        }
        #endregion SceneOptions


        private void Start()
        {
            InitPhase0();
            InitPhase1();
            var esi = SceneMan.GetInitialSceneOption();
            curscene = SceneSelE.None; // force it to execute - kind of a kludge
            SetScene(esi);
        }
        public void ToggleAutoErrorCorrect()
        {
            SetErrorCorrect(!autoerrorcorrect);
        }
        public void SetErrorCorrect(bool onoff)
        {
            //autoerrorcorrect = onoff;
            //RegionMan.Log("autoerrorcorrect now:" + autoerrorcorrect);
            //if (autoerrorcorrect && errmarkctrl.markingState != ErrorMarkerCtrl.markingStateE.marking)
            //{
            //    errmarkctrl.startMarking();
            //}
        }
        private void checkTripod()
        {
            if (tripodShown && !showTripod)
            {
                var tgo = GameObject.Find("tripod");
                if (tgo!=null) Destroy(tgo);
                tripodShown = false;
            }
            if (!tripodShown && showTripod)
            {
                tripodShown = false;
                var tgo = GameObject.Find("tripod");
                if (tgo == null)
                {
                    var oo = Vector3.zero;
                    var xx = new Vector3(10, 0, 0);
                    var zz = new Vector3( 0, 0, 10);
                    tgo = new GameObject("tripod");
                    var ori = GraphUtil.CreateMarkerCube("origin", oo, 1, "white");
                    ori.transform.parent = tgo.transform;
                    var xax = GraphUtil.CreateMarkerSphere("xax-10m",xx , 1, "red");
                    var xtripodleg = GraphUtil.CreatePipe("xpipe",oo, xx,clr:"red");
                    var zax = GraphUtil.CreateMarkerSphere("zax-10m", zz, 1, "blue");
                    var ztripodleg = GraphUtil.CreatePipe("zpipe", oo, zz, clr: "blue");
                    xax.transform.parent = tgo.transform;
                    zax.transform.parent = tgo.transform;
                    xtripodleg.transform.parent = tgo.transform;
                    ztripodleg.transform.parent = tgo.transform;
                }
                tripodShown = true;
            }
        }

        void FindColliders()
        {
            var col = GameObject.FindObjectsOfType<Collider>();
            var cnt = col.Length;
            Debug.Log("Found " + cnt + " colliders");
            foreach(var go in col)
            {
                Debug.Log(go.name);
            }
        }
        float ctrlChitTime = 0;
        float ctrlMhitTime = 0;
        float ctrlQhitTime = 0;
        float ctrlShitTime = 0;
        float ctrlDhitTime = 0;
        float F5hitTime = 0;
        public void KeyProcessing()
        {
            //if (Input.GetKeyDown(KeyCode.LeftShift))
            //{
            //    Debug.Log("Left Shift down " + updatesSinceRefresh);
            //}

            //if (updatesSinceRefresh==1)
            //{
            //    FindColliders();
            //}

            //Detect if the extra mouse button is pressed
            //if (Input.GetKey(KeyCode.Mouse4))
            //{
            //    Debug.Log("Mouse 4 ");
            //}
            // note that one uses GetKey and the other GetKeyDown... not sure why
            var ctrlhit = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
            if (ctrlhit && Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Hit Ctrl-Q");
                if ((Time.time - ctrlQhitTime) < 1)
                {
                    Debug.Log("Hit it twice so quitting: Application.Quit()");
                    Application.Quit();
                }
                // CTRL + Q
                ctrlQhitTime = Time.time;
            }
            if (((Time.time - F5hitTime) > 0.5) && Input.GetKeyDown(KeyCode.F5))
            {
                Debug.Log("F5 - Request Total Refresh");
                this.RequestRefresh("F5 hit", totalrefresh: true);
            }
            if (ctrlhit && Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Hit Ctrl-C - interrupting");
                Aiskwk.Map.QkMan.interruptLoading = true;
                // CTRL + C
                ctrlChitTime = Time.time;
            }
            if (ctrlhit &&  Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("Hit LCtrl-D");
                if ((Time.time - ctrlDhitTime)<1)
                {
                    // must have hit it twice
                    psman.EverybodyDance();
                }
                ctrlDhitTime = Time.time;
            }
        }


        int updateCount = 0;
        private void Update()
        {
            //if (autoerrorcorrect)
            //{
            //    if (errmarkctrl.nMarksInList >= errmarkctrl.nErrmarkIntervalsInSet)
            //    {
            //        //   Debug.Log("CorrectOnErrorMarkers to be called");
            //        this.CorrectOnErrorMarkers();
            //        errmarkctrl.startMarking();
            //    }
            //}
            if (updateCount==0)
            {
                //Debug.Log("First update");
            }
            checkTripod();
            SetArcoreTracking();

            if (needsLifted)
            {
                if (linkcloudman.CanGetHeights())
                {
                    linkcloudman.CalculateHeights();
                    needsrefresh = true;
                }
            }


            if (needsrefresh)
            {
                if (needstotalrefresh)
                {
                    SetScene(curscene, force: true);
                    RefreshSceneManGos(); // in update
                }
                else
                {
                    RefreshSceneManGos(); // in update
                }
                SetUiScene(curscene);
                needstotalrefresh = false;
                needsrefresh = false;
            }
            KeyProcessing();
            updateCount++;
        }


#if UNITY_EDITOR

        private void OnEnable()
        {
            if (Application.isEditor)
            {
                SceneView.onSceneGUIDelegate += OnScene;
            }
        }

        public UnityEngine.Object[] selObs;
        public GameObject actgo;

        void OnScene(SceneView scene)
        {
            Event e = Event.current;
            if ((e.type == EventType.KeyDown) && (e.keyCode == KeyCode.B) && Event.current.modifiers == EventModifiers.Control)
            {
                Debug.Log("Ctrl-B");
                e.Use(); // keeps unity shortcuts from popping up
            }
            else if ((e.type == EventType.KeyDown) && (e.keyCode == KeyCode.B))
            {
                Debug.Log("B");
                e.Use();
            }

            if (e.type == EventType.MouseDown && e.button == 2 )
            {
                //Debug.Log("Middle Mouse was pressed");

                Vector3 mousePos = e.mousePosition;
                float ppp = EditorGUIUtility.pixelsPerPoint;
                mousePos.y = scene.camera.pixelHeight - mousePos.y * ppp;
                mousePos.x *= ppp;

                Ray ray = scene.camera.ScreenPointToRay(mousePos);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    var go = hit.collider.gameObject;
                    //Debug.Log("Middle mouse button hit " + go.name);
                    var hitname = go.name.ToLower();
                    if (hitname.StartsWith("bldevacalarm"))
                    {
                        var alarm = go.GetComponent<BldEvacAlarm>();
                        bool justone = e.control;
                        alarm.ToggleBuildAlarm(justone);
                    }
                    if (hitname.StartsWith("allfreealarm"))
                    {
                        Debug.Log("hit:" + go.name);
                        var alarm = go.GetComponent<BldEvacAlarm>();
                        bool justone = e.control;
                        bool startstream = e.shift;
                        alarm.ToggleZoneAlarm(justone,startstream);
                    }
                    e.Use();
                }
            }
            if (e.type == EventType.MouseDown && e.button == 0)
            {
                //Debug.Log("Left Mouse was pressed");

                Vector3 mousePos = e.mousePosition;
                float ppp = EditorGUIUtility.pixelsPerPoint;
                mousePos.y = scene.camera.pixelHeight - mousePos.y * ppp;
                mousePos.x *= ppp;

                Ray ray = scene.camera.ScreenPointToRay(mousePos);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    var go = hit.collider.gameObject;
                    Debug.Log("Left Mouse button hit " + go.name +"  mousePos:"+mousePos.ToString("F1"));
                    if (leditor.editMode)
                    {
                        leditor.MaybeSelectEditNode(go);
                        e.Use();
                    }
                }
                else
                {
                    //Debug.Log("Left Mouse button missed everything");
                }
              
            }
            var ctrlpressed = Event.current.modifiers == EventModifiers.Control;

            if ((e.type == EventType.KeyDown) && (e.keyCode == KeyCode.S))
            {
                if ((Time.time - ctrlMhitTime) < 1)
                {
                    vcman.SetMainCamToSceneCam();
                    e.Use();
                }
                if (ctrlpressed)
                {
                    Debug.Log("Hit Ctrl-S");
                    ctrlShitTime = Time.time;
                }
            }
            if ((e.type == EventType.KeyDown) && (e.keyCode == KeyCode.M))
            {
                if ((Time.time - ctrlMhitTime) < 1)
                {
                    vcman.SetSceneCamToMainCam();
                }
                if (ctrlpressed)
                {
                    Debug.Log("Hit Ctrl-M");
                    ctrlMhitTime = Time.time;
                }
            }
            if ((e.type == EventType.KeyDown) && (e.keyCode == KeyCode.E) && ctrlpressed)
            {
                Debug.Log("Hit Ctrl-E - setEditMode will now be set to " + !leditor.editMode);
                leditor.editMode = !leditor.editMode;
            }
            if ((e.type == EventType.KeyDown) && (e.keyCode == KeyCode.X) && ctrlpressed)
            {
                Debug.Log("Hit Ctrl-X - StartStretchMode");
                leditor.StartStretchMode();
            }
            if ((e.type == EventType.KeyDown) && (e.keyCode == KeyCode.Y) && ctrlpressed)
            {
                Debug.Log("Hit Ctrl-Y - Splitting Link if link selected");
                var selobj = UnityEditor.Selection.activeGameObject;
                if (selobj != null)
                {
                    SplitLink(selobj.name);
                }
            }
            selObs = Selection.objects;
            actgo = Selection.activeGameObject;
        }

#endif
    }


}