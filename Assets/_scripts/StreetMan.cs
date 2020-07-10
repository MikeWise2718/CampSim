using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UxUtils;
using Aiskwk.Map;
using Aiskwk.Dataframe;
using GraphAlgos;

namespace CampusSimulator
{

    public class StreetMan : MonoBehaviour
    {
        public SceneMan sman;

        public UxSettingBool osmstreets = new UxSettingBool("osmstreets", false);
        public UxSettingBool fixedstreets = new UxSettingBool("fixedstreets", false);

        public void InitPhase0()
        {
        }


        public void InitializeValues()
        {
            osmstreets.GetInitial(false);
            fixedstreets.GetInitial(true);
            Debug.Log($"StreetMan.InitializeValues osmblds:{osmstreets.Get()}   fixedblds:{fixedstreets.Get()}");
        }


        public void InitializeScene(SceneSelE newregion)
        {
            Debug.Log($"StreetMan.SetScene {newregion}");
            InitializeValues();
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
                //GetDfsFromResources(osmloadspec);
            }
        }
        public LinkUse CvtLinkUse(string s, LinkUse def)
        {
            var rv = def;
            switch (s)
            {
                case "bldwall":
                    rv = LinkUse.bldwall;
                    break;
                default:
                    Debug.LogWarning($"CvtLinkUse:Unknown linktype:{s}");
                    rv = def;
                    break;
                case "road":
                    rv = LinkUse.road;
                    break;
                case "slowroad":
                    rv = LinkUse.slowroad;
                    break;
                case "driveway":
                    rv = LinkUse.driveway;
                    break;
                case "highway":
                    rv = LinkUse.highway;
                    break;
                case "walkway":
                    rv = LinkUse.walkway;
                    break;
            }
            return rv;
        }

        public void CreateGraphForOsmImport_streets_df(string regionname, string color)
        {
            Debug.Log($"CreateGraphForOsmImport_msft_streets_df");
            var grc = this.sman.lcman.GetGraphCtrl();
            grc.regman.NewNodeRegion(regionname, color, saveToFile: true);
            var sman = GameObject.FindObjectOfType<SceneMan>();
            var (nnodes, nlinks) = (0, 0);
            var (dfwayslst, dflinkslist, dfnodeslist) = sman.dfman.GetSdfs();
            for (int idf = 0; idf < dfwayslst.Count; idf++)
            {
                // Nodes
                var dfnode = dfnodeslist[idf];
                var nidcol = dfnode.ColIdx("osm_nid");
                var nixcol = dfnode.ColIdx("x");
                var nizcol = dfnode.ColIdx("z");
                var nnrow = dfnode.Nrow();
                for (int i = 0; i < nnrow; i++)
                {
                    var nid = dfnode.GetVal(nidcol, i, "");
                    var x = dfnode.GetVal(nixcol, i, 0.0);
                    var z = dfnode.GetVal(nizcol, i, 0.0);
                    grc.AddNodePtxz(nid, x, z);
                    nnodes++;
                }
                // Links
                var dflink = dflinkslist[idf];
                var lidcol = dflink.ColIdx("osm_wid");
                var lin1col = dflink.ColIdx("osm_nid_1");
                var lin2col = dflink.ColIdx("osm_nid_2");
                var liutcol = dflink.ColIdx("linkuse");
                var lictcol = dflink.ColIdx("comment");
                var nlrow = dflink.Nrow();
                bool dowalls = sman.bdman.walllinks.Get();
                for (int i = 0; i < nlrow; i++)
                {
                    nlinks++;
                    var lid = dflink.GetVal(lidcol, i, "");
                    var nid1 = dflink.GetVal(lin1col, i, "");
                    var nid2 = dflink.GetVal(lin2col, i, "");
                    var lts = dflink.GetVal(liutcol, i, "");
                    var cmt = dflink.GetVal(lictcol, i, "");
                    var linktyp = CvtLinkUse(lts, LinkUse.road);
                    if (dowalls || linktyp != LinkUse.bldwall)
                    {
                        grc.AddLinkByNodeName(nid1, nid2, usetype: linktyp, comment: cmt);
                    }
                }
            }
            grc.regman.SetRegion("default");
            Debug.Log($"CreateGraphForOsmImport_msft_streets_df added nodes:{nnodes} links:{nlinks}");
        }

        public void SetScene(SceneSelE newregion)
        {
            var regname = "";
            var regcolor = "blue";
            switch (newregion)
            {
                case SceneSelE.MsftRedwest:
                case SceneSelE.MsftCoreCampus:
                case SceneSelE.MsftB19focused:
                    regname = "msftb19area,msftcommons,msftredwest";
                    break;
                case SceneSelE.MsftDublin:
                    regname = "msftdublin";
                    //ptscale = 1000f;
                    break;
                case SceneSelE.Eb12small:
                case SceneSelE.Eb12:
                    regname = "eb12small";
                    break;
                case SceneSelE.TeneriffeMtn:
                    regname = "tenmtn";
                    //ptscale = 1000f;
                    break;
                case SceneSelE.TukSouCen:
                    regname = "tuksoucen";
                    //ptscale = 1000f;
                    break;
                case SceneSelE.HiddenLakeLookout:
                    regname = "hidlakelook";
                    //ptscale = 1000f;
                    break;
                default:
                case SceneSelE.None:
                    // DelBuildings called above already
                    break;
            }
            if (regname != "")
            {

                CreateGraphForOsmImport_streets_df(regname,regcolor);
            }
        }

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