using System.Collections;
using System.Collections.Generic;

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CampusSimulator
{

    public class SceneSetupMan : MonoBehaviour
    {
        // This class holds static methods that invoke RegionMan commands from the classic windows menu
        // these menu commands only work on the static methods and we didn't want to clutter RegionMan
        // with them, although that may be the best option in the long run

        public static SceneMan sman;


        public GameObject ground;
        public GameObject rmango;

        // Use this for initialization
        void Start()
        {
            // Find RegionMan
            sman = FindObjectOfType<SceneMan>();

            // Move light back a bit
            var dlight = GameObject.Find("Directional Light");           
            dlight.transform.localPosition = new Vector3(-1,0,-1);
        }
        #region global commands
        //[MenuItem("--Glob/Region-Core Campus")]
        //static void SetRegionCoreCampus()
        //{
        //    sman.SetRegion(RegionSelE.MsftCoreCampus);
        //}
        //[MenuItem("--Glob/Region-Redwest")]
        //static void SetRegionRedwest()
        //{
        //    sman.SetRegion(RegionSelE.MsftRedwest);
        //}
        //[MenuItem("--Glob/Region-EB12")]
        //static void SetRegionEB12()
        //{
        //    sman.SetRegion(RegionSelE.Eb12);
        //}
        //[MenuItem("--Glob/Region-Dublin")]
        //static void SetRegionDublin()
        //{
        //    sman.SetRegion(RegionSelE.MsftDublin);
        //}
        //[MenuItem("--Glob/Region-None")]
        //static void SetRegionNone()
        //{
        //    sman.SetRegion(RegionSelE.None);
        //}
#if UNITY_EDITOR
        [MenuItem("--Glob/Refresh")]
        static void Refresh()
        {
            sman.ForceRegen();
        }
        [MenuItem("--Glob/Toggle LinkCloud Visibility")]
        static void ToggleLinkCloudVisibily()
        {
            sman.ToggleLinkCloudVisibily();
        }
        [MenuItem("--Glob/Rotate Parking Slot Form")]
        static void RotateSlotForm()
        {
            sman.RotateSlotForm();
        }
        [MenuItem("--Glob/Show Route")]
        static void ShowRoute()
        {
            sman.ShowRoute();
        }
        [MenuItem("--Glob/Hide Route")]
        static void HideRoute()
        {
            sman.HideRoute();
        }
        [MenuItem("--Glob/Show Links")]
        static void ShowLinks()
        {
            sman.ShowLinks();
        }
        [MenuItem("--Glob/Hide Links")]
        static void HideLinks()
        {
            sman.HideLinks();
        }
        [MenuItem("--Glob/Garnish")]
        static void Garnish()
        {
            sman.NextGarnish();
        }
        [MenuItem("--Glob/Toggle Floor Plan")]
        static void ShowFloorPlan()
        {
            sman.ToggleFloorPlan();
        }
        [MenuItem("--Glob/Toggle Legacy")]
        static void ToggleLegacy()
        {
            sman.ToggleLegacy();
        }
        [MenuItem("--Glob/Toggle Fast Mode")]
        static void ToggleFast()
        {
            sman.ToggleFastMode();
        }
#endif
        #endregion

        #region linkcloud commands
#if UNITY_EDITOR

        [MenuItem("--LinkCloud/Refresh Gos")]
        static void RefreshGos()
        {
            sman.RequestRefresh("SceneSetupMan-RefreshGos");
        }
        [MenuItem("--LinkCloud/Delete")]
        static void DelLinkCloud()
        {
            sman.DeleteLinkCloudGos();
        }

        [MenuItem("--LinkCloud/Delete Selected Link")]
        static void DelSelLink()
        {
            var selobj = UnityEditor.Selection.activeGameObject;
            if (selobj != null)
            {
                sman.DeleteLink(selobj.name);
            }
        }
        [MenuItem("--LinkCloud/Delete Selected Node")]
        static void DelSelNode()
        {
            var selobj = UnityEditor.Selection.activeGameObject;
            if (selobj != null)
            {
                sman.DeleteNode(selobj.name);
            }
        }
        [MenuItem("--LinkCloud/Toggle LinkCloud Visibility")]
        static void ToggleLinkCloudVisibily1()
        {
            sman.ToggleLinkCloudVisibily();
        }
        [MenuItem("--LinkCloud/Split Selected Link &s")]
        static void SplitlSelLink()
        {
            var selobj = UnityEditor.Selection.activeGameObject;
            if (selobj != null)
            {
                sman.SplitLink(selobj.name);
            }
            else
            {
                Debug.Log("Need to select a nodes");
            }
        }
        [MenuItem("--LinkCloud/Clear Clipboard")]
        static void ClearClipboard()
        {
            sman.ClearClipboard();
        }
        [MenuItem("--LinkCloud/Stretch Node &m")]
        static void StretchNode()
        {
            //var selobjs = UnityEditor.Selection.objects;
            //if (selobjs != null && selobjs.Length==1)
            //{
            //    sman.StartStretchMode(selobjs[0].name);
            //}
            //else
            //{
            //    Debug.Log("Need to select a single node");
            //}
            sman.StartStretchMode();
        }
        [MenuItem("--LinkCloud/LinkUp Nodes")]
        static void LinkUpNodes()
        {
            var selobjs = UnityEditor.Selection.objects;
            if (selobjs != null ||  selobjs.Length!=2)
            {
                sman.LinkNodes(selobjs[0].name, selobjs[1].name);
            }
            else
            {
                Debug.Log("Need to select exactly two nodes to link");
            }
        }
        //[MenuItem("--LinkCloud/Noise Up Nodes")]
        //static void NoiseUpLinkCloud()
        //{
        //    var ok = EditorUtility.DisplayDialog("Are you sure you want to noise things up?",
        //                                         "Really sure?", "Yes, noise them up", "No thanks");
        //    if (ok)
        //    {
        //        sman.NoiseUpNodes(1);
        //    }
        //}
        [MenuItem("--LinkCloud/Save To Scene File")]
        static void SaveToSceneFile()
        {
            sman.SaveToJsonFile();
        }
        [MenuItem("--LinkCloud/Save Region Files")]
        static void SaveRegionFiles()
        {
            sman.SaveRegionFiles();
        }
        [MenuItem("--LinkCloud/Save Region Code Files")]
        static void SaveRegionCodeFiles()
        {
            sman.SaveRegionCodeFiles();
        }

#endif
        #endregion

        #region bird commands
#if UNITY_EDITOR
        [MenuItem("--Bird/Start")]
        static void StartBird()
        {
            sman.StartBird();
        }
        [MenuItem("--Bird/Pause")]
        static void PauseBird()
        {
            sman.PauseBird();
        }
        [MenuItem("--Bird/Stop")]
        static void StopBird()
        {
            sman.StopBird();
        }
        [MenuItem("--Bird/Reset")]
        static void ResetBird()
        {
            sman.ResetCalled();
        }
        [MenuItem("--Bird/Faster")]
        static void FasterBird()
        {
            sman.FasterBird();
        }
        [MenuItem("--Bird/Slower")]
        static void SlowerBird()
        {
            sman.SlowerBird();
        }
        [MenuItem("--Bird/Delete Bird")]
        static void DeleteBird()
        {
            sman.DeleteBird();
        }
        [MenuItem("--Bird/Next Form")]
        static void NextBirdForm()
        {
            sman.NextBirdForm();
        }
        [MenuItem("--Bird/Next Slot Form")]
        static void NextSlotForm()
        {
            sman.NextSlotForm();
        }
#endif
        #endregion

        #region pipecommands
#if UNITY_EDITOR
        [MenuItem("--Path/A-star Path")]
        static void Astar()
        {
            sman.Astar();
        }
        //[MenuItem("--Path/Set Start Node")]
        //static void SetStartNode()
        //{
        //    sman.SetStartNode();
        //}
        //[MenuItem("--Path/Set End Node")]
        //static void SetEndNode()
        //{
        //    sman.SetEndNode();
        //}
        [MenuItem("--Path/Random End Node")]
        static void RandomEndNode()
        {
            sman.SetRandomEndNode();
        }
        [MenuItem("--Path/Reverse Path")]
        static void ReversePath()
        {
            sman.ReversePath();
        }
        [MenuItem("--Path/Random Path")]
        static void RandomPath()
        {
            sman.RandomPath();
        }
        [MenuItem("--Path/Delete Path")]
        static void DeletePath()
        {
            sman.DeletePath();
        }
        [MenuItem("--Path/Toggle Path Visibility")]
        static void TogglePathVisibily()
        {
            sman.TogglePathVisibily();
        }
#endif
        #endregion


        #region room commands
#if UNITY_EDITOR
        [MenuItem("--Scene/Toggle Trees")]
        static void ToggleTrees()
        {
            sman.ToggleTrees();
        }
#endif
        #endregion

        #region room commands
#if UNITY_EDITOR
        [MenuItem("--Room/Lobby 1")]
        static void DestRoomLobby1()
        {
            sman.SetEndNode("b43-f01-lobby");
        }
        [MenuItem("--Room/Kitchen 1")]
        static void DestRoomKitchen1()
        {
            sman.SetEndNode("f01-dt-k01");
        }
        [MenuItem("--Room/Room 1002")]
        static void DestRoom1002()
        {
            sman.SetEndNode("f01-dt-rm1002");
        }
        [MenuItem("--Room/Room 1003")]
        static void DestRoom1003()
        {
            sman.SetEndNode("f01-dt-rm1003");
        }
        [MenuItem("--Room/Room 1008")]
        static void DestRoom1008()
        {
            sman.SetEndNode("f01-dt-rm1008");
        }
        [MenuItem("--Room/Room 1013")]
        static void DestRoom1013()
        {
            sman.SetEndNode("f01-dt-rm1013");
        }
        [MenuItem("--Room/Room 1015")]
        static void DestRoom1015()
        {
            sman.SetEndNode("f01-dt-rm1013");
        }
#endif
#endregion
        // Update is called once per frame
        int updateCount = 0;
        void Update()
        {
            if  (updateCount==0)
            {
//#if MOBILE_INPUT
//                var mobinput = false;
//                mobinput = true;
//                //Debug.Log("mobinput:" + mobinput);
//#endif
            }
            if (updateCount==0)
            {
               // sman.GenCampus();
            }
            updateCount++;
        }
    }
#if UNITY_EDITOR
    public class FindMissingScripts : EditorWindow
    {
        [MenuItem("Window/FindMissingScripts")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(FindMissingScripts));
        }

        public void OnGUI()
        {
            if (GUILayout.Button("Find Missing Scripts in selected prefabs"))
            {
                FindInSelected();
            }
        }
        private static void FindInSelected()
        {
            GameObject[] go = Selection.gameObjects;
            int go_count = 0, components_count = 0, missing_count = 0;
            foreach (GameObject g in go)
            {
                go_count++;
                Component[] components = g.GetComponents<Component>();
                for (int i = 0; i < components.Length; i++)
                {
                    components_count++;
                    if (components[i] == null)
                    {
                        missing_count++;
                        string s = g.name;
                        Transform t = g.transform;
                        while (t.parent != null)
                        {
                            s = t.parent.name + "/" + s;
                            t = t.parent;
                        }
                        Debug.Log(s + " has an empty script attached in position: " + i, g);
                    }
                }
            }

            Debug.Log(string.Format("Searched {0} GameObjects, {1} components, found {2} missing", go_count, components_count, missing_count));
        }
    }
#endif
}
