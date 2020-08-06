using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UxUtils;
using Aiskwk.Map;
using Aiskwk.Dataframe;
using Microsoft.Win32;

namespace CampusSimulator
{

    public class CoordMapMan : MonoBehaviour
    {
        public SceneMan sman;
        public SceneSelE curregion;

        public void InitPhase0()
        {
        }

        public void DeleteStuff()
        {
        }


        public void InitializeValues()
        {
        }

        public void InitializeScene(SceneSelE newregion)
        {
            Debug.Log($"DataFileMan.InitializeScene {newregion}");
            InitializeValues();
            curregion = newregion;
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