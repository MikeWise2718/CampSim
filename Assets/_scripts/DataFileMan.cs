using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UxUtils;
using Aiskwk.Map;
using Aiskwk.Dataframe;
using Microsoft.Win32;

namespace CampusSimulator
{

    public class DataFileMan : MonoBehaviour
    {
        public SceneMan sman;
        public SceneSelE curregion;
        public string osmloadspec;


        public List<SimpleDf> dfwayslist;
        public List<SimpleDf> dflinkslist;
        public List<SimpleDf> dfnodeslist;

        public UxSettingBool useDfIndexes = new UxSettingBool("useDfIndexes", true);
        public UxSettingBool useDfLlCoords = new UxSettingBool("useDfLlcoords", true);

        public (int waysidxcnt,int linksidxcnt,int nodeidxcnt) GetIndexCounts()
        {
            var (rv1,rv2,rv3) = (0,0,0);
            if (dfwayslist != null)
            {
                foreach (var df in dfwayslist)
                {
                    rv1 += df.IndexAccesses;
                }
            }
            if (dflinkslist != null)
            {
                foreach (var df in dflinkslist)
                {
                    rv2 += df.IndexAccesses;
                }
            }
            if (dfnodeslist != null)
            {
                foreach (var df in dfnodeslist)
                {
                    rv3 += df.IndexAccesses;
                }
            }
            return (rv1, rv2, rv3);
        }

        public void InitPhase0()
        {
        }


        public void InitDataFrames()
        {
            dfwayslist = new List<SimpleDf>();
            dflinkslist = new List<SimpleDf>();
            dfnodeslist = new List<SimpleDf>();
        }

        public void DeleteStuff()
        {
            InitDataFrames();
        }

        public (List<SimpleDf> ways, List<SimpleDf> links, List<SimpleDf> nodes) GetSdfs()
        {
            var rv = (dfwayslist, dflinkslist, dfnodeslist);
            return rv;
        }

        public void InitializeValues()
        {
            useDfIndexes.GetInitial(true);
            useDfLlCoords.GetInitial(true);
        }

        public void BaseInitialize(SceneSelE newregion)
        {
            Debug.Log($"DataFileMan.InitializeScene {newregion}");
            InitializeValues();
            curregion = newregion;
            InitDataFrames();
            osmloadspec = "";
            switch (newregion)
            {
                case SceneSelE.MsftSmall:
                case SceneSelE.MsftRedwest:
                case SceneSelE.MsftCoreCampus:
                case SceneSelE.MsftB19focused:
                case SceneSelE.MsftB33focused:
                case SceneSelE.MsftB121focused:
                    osmloadspec = "msftcampcore";
                    break;
                case SceneSelE.MsftDublin:
                    osmloadspec = "msftdublin";
                    break;
                case SceneSelE.MsftMountainView:
                    osmloadspec = "msftmountainview";
                    break;
                case SceneSelE.Eb12small:
                case SceneSelE.Eb12:
                    osmloadspec = "eb12small";
                    break;
                case SceneSelE.TeneriffeMtn:
                    osmloadspec = "tenmtn";
                    break;
                case SceneSelE.TukSouCen:
                    osmloadspec = "tuksoucen";
                    break;
                case SceneSelE.Seattle:
                    osmloadspec = "seattle";
                    break;
                case SceneSelE.KeppelPort:
                    osmloadspec = "keppelport";
                    break;
                case SceneSelE.KeppelDist:
                    osmloadspec = "keppeldist";
                    break;
                case SceneSelE.Seatac:
                    break;
                case SceneSelE.SanFrancisco:
                    osmloadspec = "sanfrancisco";
                    break;
                case SceneSelE.Frankfurt:
                    osmloadspec = "frankfurt";
                    break;
                case SceneSelE.HiddenLakeLookout:
                    osmloadspec = "hidlakelook";
                    break;
                case SceneSelE.Riggins:
                    osmloadspec = "riggins";
                    break;
                default:
                case SceneSelE.None:
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

        public string fnameways;
        public string fnamelinks;
        public string fnamenodes;

        public void GetDfsFromResources1(string area1, LatLongMap llm = null)
        {
            SimpleDf dfways;
            SimpleDf dflinks;
            SimpleDf dfnodes;
            var dname = "osmcsv/";

            dfways = null;
            {
                fnameways = $"{dname}{area1}_ways.csv";
                dfways = new SimpleDf(area1 + "_ways");
                var wayslist = ReadResource(fnameways);
                if (wayslist != null)
                {
                    dfways.ReadCsv(wayslist);
                }
                sman.Lgg($"Read {dfways.Nrow()} ways from {fnameways}","yellow");
            }

            dflinks = null;
            {
                fnamelinks = $"{dname}{area1}_links.csv";
                dflinks = new SimpleDf(area1 + "links");
                var linkslist = ReadResource(fnamelinks);
                if (linkslist != null)
                {
                    dflinks.ReadCsv(linkslist);
                }
                if (useDfIndexes.Get())
                {
                    //Debug.Log($"Using indexes on {fnamelinks}");
                    dflinks.AddIndex("osm_wid");
                    dflinks.AddIndex("osm_nid_1");
                }
                sman.Lgg($"Read {dflinks.Nrow()} links from {fnamelinks}","yellow");
            }

            dfnodes = null;
            {
                fnamenodes = $"{dname}{area1}_nodes.csv";
                dfnodes = new SimpleDf(area1 + "nodes");
                var nodeslist = ReadResource(fnamenodes);
                if (nodeslist != null)
                {
                    dfnodes.ReadCsv(nodeslist);
                }
                if (useDfIndexes.Get())
                {
                    //Debug.Log($"Using indexes on {fnamenodes}");
                    dfnodes.AddIndex("osm_nid");
                }
                sman.Lgg($"Read {dfnodes.Nrow()} links from {fnamenodes}","yellow");
            }
            if (llm != null)
            {
                sman.Lgg($"Converting coords with llm {llm.origin} - {llm.initmethod}","yellow");
                ConvertNodeCoords(dfnodes, llm);
            }
            var okways = dfways.CheckConsistency("DataFileMan.GetDfsFromResources", quiet:true);
            var oklinks = dflinks.CheckConsistency("DataFileMan.GetDfsFromResources", quiet: true);
            var oknodes = dfnodes.CheckConsistency("DataFileMan.GetDfsFromResources", quiet: true);
            if (!okways || !oklinks || !oknodes)
            {
                Debug.LogWarning($"Df consistency check for {area1} ways:{okways}  links:{oklinks}  nodes:{oknodes}");
            }
            dfwayslist.Add(dfways);
            dflinkslist.Add(dflinks);
            dfnodeslist.Add(dfnodes);
        }

        public static List<string> ReadResource(string pathname)
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

        //public void SetScene(SceneSelE newregion) don't need this
        //{
        //}

        // Start is called before the first frame update
        //void Start()
        //{

        //}

        //// Update is called once per frame
        //void Update()
        //{

        //}
    }
}