using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UxUtils;
using Aiskwk.Map;
using Aiskwk.Dataframe;
using GraphAlgos;
using System;
using UnityEditor.Experimental.GraphView;

namespace CampusSimulator
{
    public enum StreetType { GpxTrack }



    public class Street : MonoBehaviour
    {
        public StreetMan sm = null;
        public StreetType streetType;
        public string avaname;
        public string speed;
        public LinkUse use;
        public LcCapType captyp;
        public List<LcNode> nodelist = null;
        public List<LcLink> linklist = null;
        public List<GameObject> golist = null;
        public string stnode;
        public string ednode;

        public void Initialize(StreetMan sm,StreetType st,string avaname,string speed,LinkUse use,LcCapType captyp)
        {
            this.sm = sm;
            this.streetType = st;
            this.avaname = avaname;
            this.speed = speed;
            this.use = use;
            this.captyp = captyp;
            nodelist = new List<LcNode>();
            linklist = new List<LcLink>();
            golist = new List<GameObject>();
        }

        public void DestroyStreetThings()
        {
            // the lcndoes should be destroyed in the node list
            nodelist = new List<LcNode>();
            linklist = new List<LcLink>();
            foreach(var go in golist)
            {
                Destroy(go);
            }
            golist = new List<GameObject>();
        }

        public void AddNode(LcNode node)
        {
            nodelist.Add(node);
        }
        public void AddLink(LcLink link,string clr)
        {
            linklist.Add(link);

            var go = new GameObject(link.name);
            var yoff = 5;
            var pt1 = sm.sman.mpman.GetHeightVector3(link.node1.pt,yoff);
            var pt2 = sm.sman.mpman.GetHeightVector3(link.node2.pt,yoff);
            go.transform.localPosition = (pt1+pt2) / 2;
            var lr = go.AddComponent<LineRenderer>();
            lr.SetPosition(0, pt1);
            lr.SetPosition(1, pt2);
            lr.startWidth = 24f;
            lr.endWidth = 0f;
            GraphUtil.SetColorOfGo(go, clr);
            go.transform.parent = this.transform;
            golist.Add(go);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}