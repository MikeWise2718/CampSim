using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphAlgos;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CampusSimulator
{
    //[SelectionBase]
    public class NodeGo : MonoBehaviour
    {

        SceneMan sman;
        // Use this for initialization
        public LcNode node;
        public string nodeName;
        public Vector3 nodePt;
        public Vector3 nodePtWc;
        public double lng;
        public double lat;
        public string strans0;
        public string strans1;
        public string strans2;
        public string strans3;
        public Transform nodeTransform;
        public int nodeTransformSetCount;
        public string lastmsg;

        //void Start()
        //{


        //}

        // Update is called once per frame - very costly
        //void Update()
        //{
        //    if (node==null)
        //    {
        //        return;
        //    }
        //    if (node.transformSetCount != nodeTransformSetCount)
        //    {
        //        nodeTransform = node.transform;
        //        nodeTransformSetCount = node.transformSetCount;
        //        if (node.transform != null)
        //        {
        //            nodePtWc = node.transform.TransformPoint(node.pt);
        //            //var m = node.transform.worldToLocalMatrix;
        //            //var trans0 = m.GetRow(0);
        //            //var trans1 = m.GetRow(1);
        //            //var trans2 = m.GetRow(2);
        //            //var trans3 = m.GetRow(3);
        //            //strans0 = trans0.ToString("F2");
        //            //strans1 = trans1.ToString("F2");
        //            //strans2 = trans2.ToString("F2");
        //            //strans3 = trans3.ToString("F2");
        //        }
        //    }
        //}
        public static string normname(string name)
        {
            if (name.EndsWith("-sph"))
            {
                return name.Substring(0, name.Length - 4);
            }
            else
            {
                return name;
            }
        }

        public void ChangeNodeName()
        {
            var lcld = node.grc;
            var stat = lcld.ChangeNodeName(node.name, nodeName);
            lastmsg = stat.fullstatus();
            if (stat.ok)
            {
                SceneMan.Log(lastmsg);
                sman.RequestHighObjRefresh(nodeName,"ChangeNodeName");
            }
            else
            {
                SceneMan.Log(lastmsg);
                nodeName = node.name; // change the go name back to avoid confusion
            }

        }
        public static GameObject MakeNodeGo(SceneMan sman, LcNode node, float nodesize, string cname,float alf,bool addcollider=true)
        {
            var go = new GameObject();
            var nodego = go.AddComponent<NodeGo>();
            nodego.sman = sman;
            nodego.node = node;
            nodego.name = node.name;
            nodego.nodeName = node.name;
            nodego.nodePt = node.pt;
            nodego.lng = node.lng;
            nodego.lat = node.lat;
            nodego.nodeTransform = node.transform;
            nodego.nodeTransformSetCount = node.transformSetCount;
            nodego.lastmsg = "";
            if (node.transform != null)
            {
                nodego.nodePtWc = node.transform.TransformPoint(node.pt);
            }
            go.name = node.name;
            go.transform.localPosition = node.pt;

            var sph = GraphUtil.CreateMarkerSphere(node.name + "-sph", node.pt, nodesize, cname,alf);
            node.go = sph;
            if (sman != null && sman.garnish != RouteGarnishE.none)
            {
                var text = node.name + "\n" + 
                           node.pt + "\n" + 
                           node.lat.ToString("f6") + ", " + node.lng.ToString("f6");
                GraphUtil.addFloatingTextStatic(go, node.pt, text, cname, 90);
            }
            if (addcollider)
            {
                sph.AddComponent<SphereCollider>();
            }
            sph.transform.parent = go.transform;
            node.transform = sph.transform;
            node.transformSetCount += 1;
            return go;
        }
    }


#if UNITY_EDITOR
    [CustomEditor(typeof(NodeGo))]   //The script which you want to button to appear in
    public class CustomNodeGoInspectorScript : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();    //This goes first

            if (GUILayout.Button("Change Node Name"))    // If the button is clicked
            {
                NodeGo nodego = (NodeGo)target;    //The target script
                nodego.ChangeNodeName();
            }
        }
    }
#endif


}