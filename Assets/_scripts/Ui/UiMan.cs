using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CampusSimulator
{

    public class UiMan : MonoBehaviour
    {
        public SceneMan sman;
        // Start is called before the first frame update

        public GameObject uigo;
    
        public void InitPhase0()
        {
            uigo = GameObject.Find("SimParkUICanvas");
        }

        public void SetScene(SceneSelE newregion)
        {
            Debug.Log($"UiMan.SetRegion: {newregion}");
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}