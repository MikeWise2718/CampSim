using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphAlgos;

namespace CampusSimulator
{
    public class RouteLayer : MonoBehaviour
    {

        // Use this for initialization
        //void Start()
        //{

        //}
        public bool nearestNode; //"run" or "generate" for example
        public bool buttonDisplayName2; //supports multiple buttons	
                                        // Update is called once per frame
        void Update()
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);

            if (nearestNode)
            {
                nearestNodeAction();
            }

        }
        void nearestNodeAction()
        {
            var lc = FindObjectOfType<LinkCloudMan>();
#pragma warning disable 0219
            var lpt = lc.FindClosestLinkOnLineCloudFiltered("", transform.position);
#pragma warning restore 0219
            //DoStuff
        }

    }


}
