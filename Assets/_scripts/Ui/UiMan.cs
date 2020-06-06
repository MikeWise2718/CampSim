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
        public OptionsPanel optpan;
        public StatusPanel span;
    
        public void InitPhase0()
        {
            uigo = GameObject.Find("SimParkUICanvas");
            optpan = FindObjectOfType<OptionsPanel>();
            span = FindObjectOfType<StatusPanel>();
            span.InitPhase0();
        }

        public void SetScene(SceneSelE newscene)
        {
            Debug.Log($"UiMan.SetScene: {newscene}");
            var optpan = FindObjectOfType<OptionsPanel>();
            if (optpan != null)
            {
                optpan.SetScene(newscene);
            }
            SyncState();
        }

        public void SyncState()
        {
            span.ColorizeButtonStates();
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