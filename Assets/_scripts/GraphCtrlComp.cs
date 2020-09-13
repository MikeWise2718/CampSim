using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CampusSimulator
{

    public class GraphCtrlComp : MonoBehaviour
    {
        LinkCloudMan lcman;
        GraphAlgos.GraphCtrl grc;

        public int nnodes;
        public int nlinks;
        public int nregions;
        public List<string> regiondesc=null;
        public int regionNodeSum;
        public string NodeMultiplicty = "";
        public bool dumpMultiNodes = false;

        public void Init(LinkCloudMan lcman,GraphAlgos.GraphCtrl grc)
        {
            this.grc = grc;
            this.lcman = lcman;

        }

        void RefreshVals()
        {
            if (grc==null)
            {
                Debug.LogError("grc null in GraphCtrlComp");
                return;
            }
            nnodes = grc.GetNodeCount();
            nlinks = grc.GetLinkCount();
            nregions = grc.regman.GetNodeRegionCount();
            regiondesc = grc.regman.GetNodeRegionsDesc();
            regionNodeSum = grc.regman.GetNodeRegionCountSum();
            NodeMultiplicty = grc.regman.GetMultiplicityDesc();
        }

        int updcount = 0;
        // Update is called once per frame
        void Update()
        {
            if (updcount % 300 == 0)
            {
                RefreshVals();
            }
            updcount += 1;
            if (dumpMultiNodes)
            {
                grc.regman.DumpMultiNodes();
                dumpMultiNodes = false;
            }
        }
    }
}