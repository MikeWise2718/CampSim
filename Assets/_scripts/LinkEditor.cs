using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphAlgos;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CampusSimulator
{
    public enum nodeMoveModeE { stretch, move };
    public class LinkEditor : MonoBehaviour
    {
        // Start is called before the first frame update
        public SceneMan sm;
        public LinkCloudMan lm;
        public GraphCtrl grc;

        public bool editMode = false;
        public bool largeNodes = false;
        public bool lockYval = false;
        public bool checkForNodeMovement = false;

        public string uniqueNodePrefix = "node";
        public string uniqueLinkPrefix = "link";

        public LcNode curEditNode = null;

        public NodeRegion editNodeRegion;

        public LinkUse linkUseType;

        public nodeMoveModeE nodeMoveMode = nodeMoveModeE.move;
        bool olargeNodes = false;
        bool oeditMode = false;
        void Start()
        {
            editMode = false;
            largeNodes = false;
            lockYval = true;
            olargeNodes = largeNodes;
            oeditMode = editMode;
            checkForNodeMovement = editMode;
//#if UNITY_EDITOR
//            Selection.selectionChanged += OnSelectionChange;
//#endif
        }
        public void InitPhase0(LinkCloudMan lm,SceneMan sm)
        {
            this.lm = lm;
            this.sm = sm;
            nodeMoveMode = nodeMoveModeE.move;
        }
        public void SetGraphCtrl(GraphCtrl grc)
        {
            this.grc = grc;
        }

        public void SetCurrentEditNode(string nodename)
        {
            var node = grc.GetNode(nodename);
            if (curEditNode!=null)
            {
                if (curEditNode.name!=nodename)
                {
                    lm.RemoveNodeColorOverride(curEditNode.name);
                }
            }
            curEditNode = node;
            editNodeRegion = grc.regman.GetRegion(node.regid);
            linkUseType = LinkUse.legacy;
            lm.SetNodeColorOverride(nodename, "green",node.go);
            foreach ( var weg in node.wegtos)
            {
                var lnk = weg.link;
                if (lnk.regid==node.regid)
                {
                    linkUseType = lnk.usetype;
                    break;
                }
            }
            //sm.RequestRefresh("LinkEdit:SetCurrentEditMode");
        }
        public void SplitLink(string name)
        {
            grc.uniqueNodePrefix = this.uniqueNodePrefix;
            grc.uniqueLinkPrefix = this.uniqueLinkPrefix;
            if (grc.islinkname(name))
            {
                grc.SplitLink(name);
                lm.RefreshGos();
            }
        }
        public Vector3 originalpos;
        public void StartStretchMode()
        {
            var stretchnodename = curEditNode.name;
            Debug.Log("StartStrechMode selname:"+stretchnodename);
            grc.uniqueNodePrefix = uniqueNodePrefix;
            grc.uniqueLinkPrefix = uniqueLinkPrefix;

            if (grc.IsNodeName(stretchnodename))
            {
                var node = grc.GetNode(stretchnodename);
                if (nodeMoveMode == nodeMoveModeE.move)
                {
                    // turn purple and start stretching
                    this.nodeMoveMode = nodeMoveModeE.stretch;
                    originalpos = node.pt;
                    lm.SetNodeColorOverride(node.name, "purple",node.go);
                }
                else
                {
                    // now stop stretching
                    //var npt = grc.finishStretchMovement(selname, originalpos,linkUseType, editNodeRegion.regid);
                    var nodename = LcNode.NormName(stretchnodename);
                    var lnode = grc.GetNode(nodename);
                    var closeest = grc.FindClosestNodeToNodeGo(lnode);
                    if (Vector3.Distance(closeest.go.transform.position, lnode.go.transform.position) > 0.2f)
                    {
                        // move the node because there is nothing close (20 cm)
                        var newname = grc.genuniquenodename();
                        var newnode = grc.GetNewNode(newname, lnode.go.transform.position, lnode.usetype);
                        newnode.regid = editNodeRegion.regid;
                        lnode.pt = originalpos;
                        lnode.go.transform.position = originalpos;
                        var lnk = grc.AddLink("", lnode, newnode, linkUseType);
                        lnk.regid = editNodeRegion.regid;
                        SetCurrentEditNode(newnode.name);
                    }
                    else
                    {
                        // here we just link to the closest node ... this may not always be the right thing to do
                        var newlinkname = grc.genuniquelinkname();
                        var lnk = grc.AddLink(newlinkname, lnode, closeest, linkUseType);
                        lnk.regid = editNodeRegion.regid;
                    }
                    lm.RemoveNodeColorOverride(node.name);
                    nodeMoveMode = nodeMoveModeE.move;
                    //sm.RequestHighObjRefresh(selname,"SetStretchMode");
                }
            }
            else
            {
                Debug.Log("Not a node name:" + stretchnodename);
            }
        }

        void MoveNodes()
        {
            var movedNodes = grc.checkForNodeMovement();
            if (movedNodes.Count > 0)
            {
                if (nodeMoveMode == nodeMoveModeE.move)
                {
                    grc.syncNodeMovement(movedNodes, lockYval);
                }
                lm.RequestNodeEditRefresh();
            }
        }
        void MoveCurNode()
        {
            if (curEditNode == null) return;

            var movedNodes = curEditNode.WasMoved();
            curEditNode.SyncToGo(lockYval);
        }

        void ResizeNodesAndLinks()
        {
            if (largeNodes)
            {
                sm.linknodescale *= 2;
            }
            else
            {
                sm.linknodescale /= 2;
            }
            sm.RequestRefresh("LinkEdit.Update");
        }

        void ChangeEditNode()
        {
            curEditNode = null;
            if (editMode)
            {
                sm.mpman.TurnOffMeshCollider();
            }
            else
            {
                if (curEditNode!=null)
                {
                    lm.RemoveNodeColorOverride(curEditNode.name);
                }
            }
            checkForNodeMovement = editMode;
        }
        void EnsureSelection()
        {
#if UNITY_EDITOR

            if (editMode && curEditNode!=null && newname == curEditNode.name)
            {
                if (Selection.activeGameObject != null)
                {
                    if (Selection.activeGameObject.name == newname) return; // nothing to do
                }
                Selection.activeGameObject = curEditNode.go;
            }
#endif
        }
        public void MaybeSelectEditNode(GameObject go)
        {
            var partr = go.transform.parent;
            if (partr)
            {
                var nodego = partr.gameObject.GetComponent<NodeGo>();
                if (nodego)
                {
                    //Selection.objects = new GameObject[1] { go };
                    Debug.Log("Selected nodego" + nodego.name);
                    SetCurrentEditNode(nodego.name);
                }
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (grc == null) return;
            if (olargeNodes != largeNodes)
            {
                ResizeNodesAndLinks();
                olargeNodes = largeNodes;
            }
            if (oeditMode!=editMode)
            {
                ChangeEditNode();
                oeditMode = editMode;
            }
            if (checkForNodeMovement)
            {
                MoveNodes();
            }
            EnsureSelection();
        }
        //GameObject oldact;
        //string wasname = "null";
        string newname = "null";
        //void OnSelectionChange()
        //{
            //if (oldact)
            //{
            //    wasname = oldact.name;
            //}

            //if (Selection.activeGameObject)
            //{
            //    newname = Selection.activeGameObject.name;
            //}
            //Debug.Log("LinkEdit.OnSelectionChange - was:" + wasname + "  now:" + newname);
            //oldact = Selection.activeGameObject;
        //}
    }
}