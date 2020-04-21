using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aiskwk.Map
{
    public class LayerMan : MonoBehaviour
    {

        GameObject layerRootGo = null;
        Dictionary<string, Layer> laydict = new Dictionary<string, Layer>();

        public void Init(Transform desiredParent)
        {
            layerRootGo = new GameObject("layers");
            layerRootGo.transform.parent = desiredParent;
        }

        public Layer AddLayer(string layername)
        {

            var laygo = new GameObject(layername);
            if (laydict.ContainsKey(layername))
            {
                Debug.LogError($"LayerManager {name} already contains a layer named {layername} - exiting");
                return null;
            }
            laygo.transform.parent = layerRootGo.transform;
            var laygocomp = laygo.AddComponent<Layer>();
            laydict[layername] = laygocomp;
            //Debug.Log("Created layer " + laygo.name + " parent:"+laygo.transform.parent.name);
            return laygocomp;
        }
        public Layer GetLayer(string layername)
        {
            if (!laydict.ContainsKey(layername))
            {
                Debug.LogError($"LayerManager {name} does not contains a layer named {layername} - exiting");
                return null;
            }
            return (laydict[layername]);
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