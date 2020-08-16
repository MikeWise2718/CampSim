using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UxUtils;
using Aiskwk.Map;
using Aiskwk.Dataframe;
using GraphAlgos;
using System;

namespace CampusSimulator
{
    public enum TrackType { GpxTrack }

    public class Track : MonoBehaviour
    {
        public TrackMan tm = null;
        public TrackType streetType;
        public string avaname;
        public string speed;
        public LinkUse use;
        public LcCapType captyp;
        public List<LcNode> trnodelist = null;
        public List<(LcLink trlink,string clr)> trlinklist = null;
        public List<GameObject> trgolist = null;
        public string stnode;
        public string ednode;

        public void Initialize(TrackMan tm,TrackType st,string avaname,string speed,LinkUse use,LcCapType captyp)
        {
            this.tm = tm;
            this.streetType = st;
            this.avaname = avaname;
            this.speed = speed;
            this.use = use;
            this.captyp = captyp;
            trnodelist = new List<LcNode>();
            trlinklist = new List<(LcLink,string)>();
            trgolist = new List<GameObject>();
        }

        public void AddNode(LcNode node)
        {
            trnodelist.Add(node);
        }

        public void AddLink(LcLink link, string clr)
        {
            trlinklist.Add((link,clr));
            //AddGoFromLink(link,clr);
        }


        public void DestroyTrackThings()
        {
            DestroyTrackGos();
            // the lcndoes should be destroyed in the node list
            trnodelist = new List<LcNode>();
            trlinklist = new List<(LcLink,string)>();
            foreach(var stgo in trgolist)
            {
                Destroy(stgo);
            }
        }

        public void DestroyTrackGos(bool dump = false)
        {
            foreach (var stgo in trgolist)
            {
                Destroy(stgo);
            }
            trgolist = new List<GameObject>();
        }

        public void CreateTrackGos(bool dump = false)
        {
            trgolist = new List<GameObject>();
            var i = 0;
            foreach (var (trlink,clr) in trlinklist)
            {
                //dump = dump && ( i< 10);
                CreateTrackGoesFromLink(trlink,clr);
                i++;
            }
        }

        public void RefrehTrackhGos()
        {
            DestroyTrackThings();
            CreateTrackGos();
        }




        public void CreateTrackGoesFromLink(LcLink stlink,string clr,bool dump=false)
        {
            var stgo = new GameObject(stlink.name);
//            var yoff = 5;
//            var pt1 = tm.sman.mpman.GetHeightVector3(stlink.node1.pt, yoff);
//            var pt2 = tm.sman.mpman.GetHeightVector3(stlink.node2.pt, yoff);
            var pt1 = stlink.node1.pt;
            var pt2 = stlink.node2.pt;
            stgo.transform.localPosition = (pt1 + pt2) / 2;
            var lr = stgo.AddComponent<LineRenderer>();
            lr.SetPosition(0, pt1);
            lr.SetPosition(1, pt2);
            lr.startWidth = 24f;
            lr.endWidth = 0f;
            GraphUtil.SetColorOfGo(stgo, clr);
            stgo.transform.parent = this.transform;
            if (dump)
            {
                Debug.Log($"CreateStlinkGos pt1:{pt1:f1} pt2:{pt2:f1}");
            }
            trgolist.Add(stgo);
        }
    }
}