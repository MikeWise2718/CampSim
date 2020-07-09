using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UxUtils;
using Aiskwk.Map;
using Aiskwk.Dataframe;

namespace CampusSimulator
{

    public class DataFileMan : MonoBehaviour
    {
        public SceneMan sman;

        private List<SimpleDf> dfwayslist;
        private List<SimpleDf> dflinkslist;
        private List<SimpleDf> dfnodeslist;


        public void InitPhase0()
        {
        }


        public void InitDataFrames()
        {
            dfwayslist = new List<SimpleDf>();
            dflinkslist = new List<SimpleDf>();
            dfnodeslist = new List<SimpleDf>();
        }

        public (List<SimpleDf> ways, List<SimpleDf> links, List<SimpleDf> nodes) GetSdfs()
        {
            var rv = (dfwayslist, dflinkslist, dfnodeslist);
            return rv;
        }

        public void InitializeScene(SceneSelE newregion)
        {
            Debug.Log($"DataFileMan.SetScene {newregion}");
            InitDataFrames();
            var osmloadspec = "";
            switch (newregion)
            {
                case SceneSelE.MsftRedwest:
                case SceneSelE.MsftCoreCampus:
                case SceneSelE.MsftB19focused:
                    osmloadspec = "msftb19area,msftcommons,msftredwest";
                    break;
                case SceneSelE.MsftDublin:
                    osmloadspec = "msftdublin";
                    //ptscale = 1000f;
                    break;
                case SceneSelE.Eb12small:
                case SceneSelE.Eb12:
                    osmloadspec = "eb12small";
                    break;
                case SceneSelE.TeneriffeMtn:
                    osmloadspec = "tenmtn";
                    //ptscale = 1000f;
                    break;
                case SceneSelE.TukSouCen:
                    osmloadspec = "tuksoucen";
                    //ptscale = 1000f;
                    break;
                case SceneSelE.HiddenLakeLookout:
                    osmloadspec = "hidlakelook";
                    //ptscale = 1000f;
                    break;
                default:
                case SceneSelE.None:
                    // DelBuildings called above already
                    break;
            }
            if (osmloadspec != "")
            {
                GetDfsFromResources(osmloadspec);
            }
        }


        public void GetDfsFromResources(string areaprefix)
        {
            var llm = sman.mpman.GetLatLongMap();
            var sar = areaprefix.Split(',');
            foreach(var area in sar)
            {
                GetDfsFromResources1(area,llm:llm);
            }
        }

        public void ConvertNodeCoords(SimpleDf nodes, LatLongMap ll)
        {
            var ixcol = nodes.ColIdx("x");
            var izcol = nodes.ColIdx("z");

            var latcol = nodes.GetDoubleCol("lat");
            var lngcol = nodes.GetDoubleCol("lng");
            var nrow = nodes.Nrow();
            var xmap = ll.maps.xmap;
            var zmap = ll.maps.zmap;
            for (int i = 0; i < nrow; i++)
            {
                var lat = latcol[i];
                var lng = lngcol[i];
                var xv = xmap.Map(lng, lat);
                var zv = zmap.Map(lng, lat);
                var ox = nodes.GetVal(ixcol, i, 0.0);
                var oz = nodes.GetVal(izcol, i, 0.0);
                nodes.SetDoubVal(ixcol, i, xv);
                nodes.SetDoubVal(izcol, i, zv);
            }
        }


        public void GetDfsFromResources1(string area1, LatLongMap llm = null)
        {
            SimpleDf dfways;
            SimpleDf dflinks;
            SimpleDf dfnodes;
            var dname = "osmcsv/";

            dfways = null;
            {
                var fnameways = $"{dname}{area1}_ways.csv";
                dfways = new SimpleDf(area1 + "_ways");
                var wayslist = ReadResource(fnameways);
                if (wayslist != null)
                {
                    dfways.ReadCsv(wayslist);
                }
                //Debug.Log($"Read {dfways.Nrow()} ways from {fnameways}");
            }

            dflinks = null;
            {
                var fnamelinks = $"{dname}{area1}_links.csv";
                dflinks = new SimpleDf(area1 + "links");
                var linkslist = ReadResource(fnamelinks);
                if (linkslist != null)
                {
                    dflinks.ReadCsv(linkslist);
                }
                //Debug.Log($"Read {dflinks.Nrow()} links from {fnamelinks}");
            }

            dfnodes = null;
            {
                var fnamenodes = $"{dname}{area1}_nodes.csv";
                dfnodes = new SimpleDf(area1 + "nodes");
                var nodeslist = ReadResource(fnamenodes);
                if (nodeslist != null)
                {
                    dfnodes.ReadCsv(nodeslist);
                }
                //Debug.Log($"Read {dfnodes.Nrow()} links from {fnamenodes}");
            }
            if (llm != null)
            {
                Debug.Log($"Converting coords with llm {llm.initmethod}");
                ConvertNodeCoords(dfnodes, llm);
            }
            var okways = dfways.CheckConsistency("DataFileMan.GetDfsFromResources", quiet:true);
            var oklinks = dflinks.CheckConsistency("DataFileMan.GetDfsFromResources", quiet: true);
            var oknodes = dfnodes.CheckConsistency("DataFileMan.GetDfsFromResources", quiet: true);
            Debug.Log($"Df consistency check for {area1} ways:{okways}  links:{oklinks}  nodes:{oknodes}");
            dfwayslist.Add(dfways);
            dflinkslist.Add(dflinks);
            dfnodeslist.Add(dfnodes);
        }

        public List<string> ReadResource(string pathname)
        {
            var idx = pathname.IndexOf(".csv");
            if (idx > 0)
            {
                pathname = pathname.Remove(idx);
            }
            var asset = Resources.Load<TextAsset>(pathname);
            return TextAssetToList(asset);
        }
        public static List<string> TextAssetToList(TextAsset ta)
        {
            var listToReturn = new List<string>();
            var arrayString = ta.text.Split('\n');
            foreach (var line in arrayString)
            {
                listToReturn.Add(line);
            }
            return listToReturn;
        }

        public void SetScene(SceneSelE newregion)
        {
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