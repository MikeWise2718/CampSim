﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphAlgos;

namespace CampusSimulator
{
    public class PathCtrl : MonoBehaviour
    {

        private SceneMan sman;
        public void SetSceneMan(SceneMan sman)
        {
            // this is attached as a component, thus we cannot set it in a contructor
            this.sman = sman;
        }

        public PathStatusE status = PathStatusE.Initializing;
        public float PathLength = 0;
        public int PathCount = 0;
        public string startnodename = "";
        public string endnodename = "";
        public Vector3 startpt = Vector3.zero;
        public Vector3 endpt = Vector3.zero;
        public Vector3 weg1Pt1 = Vector3.zero;
        public Vector3 weg1Pt2 = Vector3.zero;
        public Vector3 weg1FrPt = Vector3.zero;
        public Vector3 weg1ToPt = Vector3.zero;
        public bool visible = true;
        public float pathNodeSize;
        public float pathRadius;
        public bool updateNearestPathPointWithMainCamPos = false;
        public enum PathStatusE { Initializing, AstarOk, AstarNotFound };


        public Path _path = null;
        public Path path
        {
            get { return _path; }
            set
            {
                _path = value;
                if (_path != null)
                {
                    PathLength = _path.pathLength;
                    PathCount = _path.waypts.Count;
                }
            }
        }
        public void initVals()
        {
            startnodename = "";
            endnodename = "";
            pathRadius = 0.03f;
            pathNodeSize = 3 * pathRadius;
            visible = true;
            status = PathStatusE.Initializing;
        }
        // Use this for initialization
        void Start()
        {
            initVals();
        }
        public Vector3 FindClosestPointOnPath(Vector3 pt)
        {
            float mpl;
            return (FindClosestPointOnPath(pt, out mpl));
        }
        public Vector3 FindClosestPointOnPath(Vector3 pt, out float minpathlength)
        {
            var rpt = Vector3.zero;
            float mindist = 9e30f;
            minpathlength = 9e30f;
            float curpathlength = 0;
            foreach (var w in _path.waypts)
            {
                var wp1 = sman.rgo.transform.TransformPoint(w.frNode.pt);
                var wp2 = sman.rgo.transform.TransformPoint(w.toNode.pt);
                var lamb = (float)GraphUtil.FindClosestLambClampedTo01(pt, wp1, wp2);
                var nearpt = lamb * (wp2 - wp1) + wp1;
                var dist = Vector3.Distance(pt, nearpt);
                if (dist < mindist)
                {
                    rpt = nearpt;
                    mindist = dist;
                    minpathlength = curpathlength + lamb * w.distance;
                }
                curpathlength += w.distance;
            }
            return rpt;
        }
        public Weg FindClosestWegOnPath(Vector3 pt)
        {
            float mpl;
            return (FindClosestWegOnPath(pt, out mpl));
        }
        public Weg FindClosestWegOnPath(Vector3 pt, out float minpathlength)
        {
            Weg rweg = null;
            float mindist = 9e30f;
            minpathlength = 9e30f;
            float curpathlength = 0;
            if (_path != null)
            {
                foreach (var w in _path.waypts)
                {
                    var wp1 = sman.rgo.transform.TransformPoint(w.frNode.pt);
                    var wp2 = sman.rgo.transform.TransformPoint(w.toNode.pt);
                    var lamb = (float)GraphUtil.FindClosestLambClampedTo01(pt, wp1, wp2);
                    var nearpt = lamb * (wp2 - wp1) + wp1;
                    var dist = Vector3.Distance(pt, nearpt);
                    if (dist < mindist)
                    {
                        rweg = w;
                        mindist = dist;
                        minpathlength = curpathlength + lamb * w.distance;
                    }
                    curpathlength += w.distance;
                }
            }
            //RegionMan.Log("fclp:" + i);
            return rweg;
        }
        TextMesh tm = null;
        //  MeshRenderer mr = null;
        private void addFloatingText(GameObject go, Vector3 pt, string text, string colorname, float yrot = 0, float yoff = 0)
        {
            var sgo = new GameObject();
            sgo.transform.parent = go.transform;
            //mr = sgo.AddComponent<MeshRenderer>();
            tm = sgo.AddComponent<TextMesh>();
            int linecount = text.Split('\n').Length;
            //tm.transform.parent = go.transform;
            tm.anchor = TextAnchor.UpperCenter;
            tm.text = text;
            tm.fontSize = 12;
            float sfak = 0.1f;
            tm.transform.localScale = new Vector3(sfak, sfak, sfak);
            tm.transform.Rotate(0, yrot, 0);
            var lpt = pt + new Vector3(0f, yoff * sfak + linecount * 0.25f, 0.0f);
            tm.transform.position = lpt;
            //SceneMan.Log("lpt:" + lpt);
            // tm.transform.parent = go.transform;
            tm.color = GraphUtil.GetColorByName(colorname);
        }

        static int pathsphcnt = 0;
        public GameObject pathgo = null;
        int gogeninst = 0;
        public bool showNearestPathPoint = true;
        public bool showNearestWegPoints = false;
        public Vector3 nearestPointRef = new Vector3(5, 0, 5);
        void CreatePathGos()
        {
            if (_path == null) return; // nothing to do
            DeletePathGos();

            if (pathgo == null)
            {
                pathgo = new GameObject("Path-" + gogeninst);
                gogeninst++;
            }
            pathgo.transform.parent = sman.rgo.transform;
            int i = 0;
            int ilast = path.waypts.Count - 1;
            var lclr = sman.getcolorname(SceneMan.RmColorModeE.pathlink);
            var nclr = sman.getcolorname(SceneMan.RmColorModeE.pathnode);
            foreach (var w in _path.waypts)
            {
                var lnk = w.link;
                string wname = "way:" + i + " (" + lnk.name + ")";
                if (visible)
                {
                    var pathcyl = GraphUtil.CreatePipe(wname, lnk.node1.pt, lnk.node2.pt, pathRadius, clr: lclr);
                    pathcyl.transform.parent = pathgo.transform;
                    if (i != ilast)
                    {
                        var mkname = "pathsph-" + pathsphcnt;
                        var psph = GraphUtil.CreateMarkerSphere(mkname, w.toNode.pt, size: pathNodeSize, clr: nclr);
                        psph.transform.parent = pathgo.transform;
                        w.toNode.transform = pathgo.transform;

                        //RegionMan.Log("path point i:" + i +"  w.tolpt.pt:"+w.tolpt.pt+ "  w.tolpt.ptwc:" + w.tolpt.ptwc);
                    }
                    if (showNearestWegPoints)
                    {
                        var npt = w.link.FindClosestPointOnLink(nearestPointRef);
                        var nname = "nearsph-" + pathsphcnt;
                        var pnsph = GraphUtil.CreateMarkerSphere(nname, npt, size: 1.5f * pathNodeSize, clr: "orange");
                        pnsph.transform.parent = pathgo.transform;
                    }
                }
                i++;
                pathsphcnt++;
            }
            if (showNearestPathPoint)
            {
                float pathdst = 0;
                FindClosestPointOnPath(nearestPointRef, out pathdst);
                var pp = path.MovePositionAlongPath(pathdst);
                var nspwc = sman.rgo.transform.TransformPoint(pp.pt);
                var nname = "nearpathsph";
                //RegionMan.Log("pp pp.pt:" + pp.pt + "  pp.ptwc:" + pp.ptwc);
                var go = new GameObject();
                go.name = nname + "-go";
                go.transform.position = nspwc;
                var cname = "lilac";
                var pnsph = GraphUtil.CreateMarkerSphere(nname, nspwc, size: 1.1f * pathNodeSize, clr: cname);
                if (sman != null)
                {
                    //                    if (sman.garnish != RouterGarnishE.none || sman.statusctrl.outMode != StatusCtrl.outModeE.geninfo)
                    if (sman.garnish != RouteGarnishE.none)
                    {
                        //RegionMan.Log("Adding text");
                        addFloatingText(go, nspwc, "Hello Sphere", cname, yrot: 0, yoff: 1.1f);
                    }
                }
                pnsph.transform.parent = go.transform;
                go.transform.parent = pathgo.transform;
            }
        }
        void DeletePathGos()
        {
            if (pathgo != null)
            {
                Destroy(pathgo);
                pathgo = null;
            }
        }

        #region command methods
        public void GenAstarPath(LcCapType captype=LcCapType.anything)
        {
            if (startnodename == "")
            {
                var sp = sman.lcman.GetNode(0);
                startnodename = sp.name;
            }
            if (endnodename == "")
            {
                var ep = sman.lcman.GetNode(-1); // last point
                endnodename = ep.name;
            }
            path = sman.lcman.GenAstar(startnodename, endnodename, captype);
            if (path == null)
            {
                Debug.LogWarning("A * path was not found for captype "+captype);
                status = PathStatusE.AstarNotFound;
            }
            else
            {
                status = PathStatusE.AstarOk;
                //Debug.Log("A * path length:" + _path.waypts.Count + " len:" + _path.pathLength+" captype:"+captype);
            }
        }
        public void GenAstarPath(string snode, string enode, LcCapType captype = LcCapType.anything)
        {
            startnodename = snode;
            endnodename = enode;
            // Debug.Log("GenAstarPath from " + snode + " to " + enode);
            GenAstarPath(captype);
        }
        public void GenRanPath()
        {
            path = sman.lcman.GenRanPath(startnodename, 12);
        }
        public void DeletePathGoesAndInit()
        {
            DeletePathGos();
            path = null;
            initVals();
        }
        public void RefreshGos()
        {
            DeletePathGos();
            CreatePathGos();
        }
        #endregion

        // Update is called once per frame
        GameObject npsph = null;
        void Update()
        {
            if (path != null)
            {
                //                public Vector3 startpt = Vector3.zero;
                //public Vector3 endpt = Vector3.zero;
                //public Vector3 weg1Pt1 = Vector3.zero;
                //public Vector3 weg1Pt2 = Vector3.zero;
                this.startpt = path.startpt;
                this.endpt = path.endpt;
                this.weg1Pt1 = path.weg1Pt1;
                this.weg1Pt2 = path.weg1Pt2;
                this.weg1FrPt = path.weg1FrPt;
                this.weg1ToPt = path.weg1ToPt;
            }
            if (updateNearestPathPointWithMainCamPos)// very expensive
            {
                nearestPointRef = Camera.main.transform.position;
                var npsph = GameObject.Find("nearpathsph-go");
                //if (npsph==null)
                //{ 
                //    var nname = "nearpathsph";
                //    var go = new GameObject();
                //    go.name = nname + "-go";
                //    var cname = "lilac";
                //    npsph = GraphUtil.CreateMarkerSphere(nname, Vector3.zero, size: 1.1f * pathNodeSize, clr: cname);
                //}
                var pathdst = -1f;
                PathPos pp = null;
                var npt = Vector3.zero;
                var nsphpos = Vector3.zero;
                if (npsph != null)
                {
                    FindClosestWegOnPath(nearestPointRef, out pathdst);
                    pp = path.MovePositionAlongPath(pathdst);
                    nsphpos = sman.rgo.transform.TransformPoint(pp.pt);
                    npsph.transform.position = nsphpos;
                    if (tm != null)
                    {
                        var text = "";
                        text += "nsphpos:" + nsphpos;
                        text += "\npt:" + pp.pt;
                        var ptwc = sman.rgo.transform.TransformPoint(pp.pt);
                        text += "\nptwc:" + ptwc;
                        text += "\nidx:" + pp.index;
                        text += "\nlambda:" + pp.lambda;
                        text += "\nstart:" + this.startnodename;
                        text += "\nend:" + this.endnodename;
                        text += "\npathdist:" + pathdst.ToString("F1") + "/" + path.pathLength.ToString("F1");
                        tm.text = text;
                    }
                    //RegionMan.Log("pathdst:"+pathdst);
                }


            }
        }
    }
}