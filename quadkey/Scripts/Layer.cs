using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aiskwk.Map
{
    public class Layer : MonoBehaviour
    {
        Dictionary<string, GameObject> laygodict = new Dictionary<string, GameObject>();
        public void AddGo(GameObject objgo)
        {
            string key = objgo.name;
            if (laygodict.ContainsKey(key))
            {
                Debug.LogError($"layer {name} already contains a go named {key} - exiting");
                return;
            }
            laygodict[key] = objgo;
            objgo.transform.parent = transform;
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