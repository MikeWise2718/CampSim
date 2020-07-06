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

        public SimpleDf dfways;
        public SimpleDf dflinks;
        public SimpleDf dfnodes;

        public List<Bldspec> blds;


        public void InitializeScene(SceneSelE newregion)
        {
            var osmloadspec = "";
            var ptscale = 1f;
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
            blds = new List<Bldspec>();
            var bpg = new BldPolyGen();
            var sar = osmloadspec.Split(',');
            foreach (var s in sar)
            {
                var lst = bpg.LoadBuildingsFromCsv(s, ptscale: ptscale, llm: null);
                blds.AddRange(lst);
            }
        }

         public void InitializeValues()
        {
        }


        public void SetScene(SceneSelE newregion)
        {
        }

        void LoadSfsFromResources(string areaprefix, string dname = "")
        {
            if (dname == "")
            {
                dname = "osmcsv/";
            }

            {
                var fnameways = $"{dname}{areaprefix}_ways.csv";
                dfways = new SimpleDf(areaprefix + "_ways");
                var wayslist = ReadResource(fnameways);
                dfways.ReadCsv(wayslist);
                //Debug.Log($"Read {dfways.Nrow()} ways from {fnameways}");
            }

            {
                var fnamelinks = $"{dname}{areaprefix}_links.csv";
                dflinks = new SimpleDf(areaprefix + "links");
                var linkslist = ReadResource(fnamelinks);
                dflinks.ReadCsv(linkslist);
                //Debug.Log($"Read {dflinks.Nrow()} links from {fnamelinks}");
            }

            {
                var fnamenodes = $"{dname}{areaprefix}_nodes.csv";
                dfnodes = new SimpleDf(areaprefix + "nodes");
                var nodeslist = ReadResource(fnamenodes);
                dfnodes.ReadCsv(nodeslist);
                //Debug.Log($"Read {dfnodes.Nrow()} links from {fnamenodes}");
            }
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