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
        public List<LcNode> stnodelist = null;
        public List<(LcLink stlink,string clr)> stlinklist = null;
        public List<GameObject> stgolist = null;
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
            stnodelist = new List<LcNode>();
            stlinklist = new List<(LcLink,string)>();
            stgolist = new List<GameObject>();
        }

        public void AddNode(LcNode node)
        {
            stnodelist.Add(node);
        }

        public void AddLink(LcLink link, string clr)
        {
            stlinklist.Add((link,clr));
            //AddGoFromLink(link,clr);
        }


        public void DestroyStreetThings()
        {
            // the lcndoes should be destroyed in the node list
            stnodelist = new List<LcNode>();
            stlinklist = new List<(LcLink,string)>();
            foreach(var stgo in stgolist)
            {
                Destroy(stgo);
            }
        }

        public void CreateStreetThings()
        {
            stgolist = new List<GameObject>();
            foreach (var (stlink,clr) in stlinklist)
            {
                CreateStlinkGos(stlink,clr);
            }
        }

        public void RefreshGos()
        {
            DestroyStreetThings();
            CreateStreetThings();
        }




        public void CreateStlinkGos(LcLink stlink,string clr)
        {
            var stgo = new GameObject(stlink.name);
            var yoff = 5;
            var pt1 = sm.sman.mpman.GetHeightVector3(stlink.node1.pt, yoff);
            var pt2 = sm.sman.mpman.GetHeightVector3(stlink.node2.pt, yoff);
            stgo.transform.localPosition = (pt1 + pt2) / 2;
            var lr = stgo.AddComponent<LineRenderer>();
            lr.SetPosition(0, pt1);
            lr.SetPosition(1, pt2);
            lr.startWidth = 24f;
            lr.endWidth = 0f;
            GraphUtil.SetColorOfGo(stgo, clr);
            stgo.transform.parent = this.transform;
            stgolist.Add(stgo);
        }



        // Start is called before the first frame update
        //void Start()
        //{

        //}

        //// Update is called once per frame
        //void Update()
        //{

        //}
    }
}