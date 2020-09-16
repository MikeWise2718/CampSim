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
            grc.regman.RefreshVals();
        }

        int updcount = 0;
        // Update is called once per frame
        void Update()
        {
            if (updcount % 300 == 0)
            {
                RefreshVals();// wtf? There must be a better way than this.
            }
            updcount += 1;
        }
    }
}