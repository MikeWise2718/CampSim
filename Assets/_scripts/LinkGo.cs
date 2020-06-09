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
    public class LinkGo : MonoBehaviour
    {

        SceneMan sman; // todo: should get rid of this sometime
        // Use this for initialization
        public LcLink link;
        public string linkName;
        public string nodeName1;
        public string nodeName2;
        public string lastmsg;
        //public NodeGo node1;
        //public NodeGo node2;

        // Use this for initialization
        void Start()
        {

        }
        public static string normname(string name)
        {
            if (name.EndsWith("-cyl"))
            {
                return name.Substring(0, name.Length - 4);
            }
            else
            {
                return name;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void ChangeLinkName()
        {
            var lcld = link.grc;
            var stat = lcld.ChangeLinkName(link.name, linkName);
            lastmsg = stat.fullstatus();
            if (stat.ok)
            {
                SceneMan.Log(lastmsg);
                sman.RequestHighObjRefresh(linkName,"ChangeLinkName");
            }
            else
            {
                SceneMan.Log(lastmsg);
                linkName = link.name; // change the go name back to avoid confusion
            }

        }
        public static bool usemman = true;

        public static GameObject MakeLinkGo(SceneMan sman, LcLink link, RmLinkFormE linkForm, float linkRadius, string clrname,float alf,bool flatlink=false)
        {
            var go = new GameObject();
            var linkgo = go.AddComponent<LinkGo>();
            linkgo.sman = sman;
            linkgo.link = link;
            linkgo.name = link.name;
            linkgo.linkName = link.name;
            linkgo.nodeName1 = link.node1.name;
            linkgo.nodeName2 = link.node2.name;
            //linkgo.node1 = link.node1.go.GetComponent<NodeGo>();
            //linkgo.node2 = link.node2.go.GetComponent<NodeGo>();


            go.name = link.name; //  + "-go";
            var p1 = link.node1.pt;
            var p2 = link.node2.pt;
            var midpt = (p1 + p2) / 2;
            go.transform.localPosition = midpt;
            GameObject linkcyl;
            if (flatlink || linkForm==RmLinkFormE.flatline)
            {
                linkcyl = GraphUtil.CreateFlatPipe(link.name, p1, p2, linkRadius, clrname,alf);
            }
            else
            {
                if (usemman)
                {
                    linkcyl = sman.mpman.AddLine(link.name, p1, p2, linkForm, linkRadius, lclr:clrname, frag:true );// for flat lines?
                }
                else
                {
                    linkcyl = GraphUtil.CreatePipe(link.name, p1, p2, linkRadius, clrname, alf);
                }
            }
            if (sman != null && sman.garnish != RouteGarnishE.none)
            {
                var text = link.name;
                var anglat = GraphUtil.GetAngLatDegrees(p1, p2);
                GraphUtil.addFloatingTextStatic(go, midpt, text + "  ang:" + anglat, clrname, anglat + 90);
            }
            if (linkcyl != null)
            {
                linkcyl.transform.parent = go.transform;
            }
            return go;
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(LinkGo))]   //The script which you want to button to appear in
    public class CustomLinkGoInspectorScript : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();    //This goes first

            if (GUILayout.Button("Change Link Name"))    // If the button is clicked
            {
                LinkGo linkgo = (LinkGo)target;    //The target script
                linkgo.ChangeLinkName();
            }
        }
    }
#endif
}