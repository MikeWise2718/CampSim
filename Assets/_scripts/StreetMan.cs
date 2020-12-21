using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UxUtils;
using Aiskwk.Map;
using Aiskwk.Dataframe;
using GraphAlgos;
using UnityEngine.UIElements;
using System.Runtime.InteropServices;
using UnityEngine.Networking;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

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

            //Debug.Log($"StreetMan.InitializeValues osmblds:{osmstreets.Get()}   fixedblds:{fixedstreets.Get()} ");
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
            //Debug.Log($"CreateGraphForOsmImport_streets_df region:{regionname}");
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
            //this.sman.lcman.CalculateAndSetHeightsOnLinkCloud();
            grc.regman.SetRegion("default");
            //Debug.Log($"CreateGraphForOsmImport_streets_df added nodes:{nnodes} links:{nlinks}");
        }

        public void ModelInitiailze(SceneSelE newregion)
        {
            //Debug.Log($"StreetMan.InitializeScene {newregion}");
            InitializeValues();
        }

        public void ModelBuild()
        {
            //Debug.Log($"StreetMan.SetScene {newregion}");
            var regname = "";
            var regcolor = "blue";
            switch (sman.curscene)
            {
                case SceneSelE.MsftSmall:
                case SceneSelE.MsftRedwest:
                case SceneSelE.MsftCoreCampus:
                case SceneSelE.MsftB19focused:
                case SceneSelE.MsftB33focused:
                case SceneSelE.MsftB121focused:
                    regname = "msft-campus";
                    break;
                case SceneSelE.MsftDublin:
                    regname = "msftdublin";
                    break;
                case SceneSelE.MsftMountainView:
                    regname = "msftmountainview";
                    break;
                case SceneSelE.Eb12small:
                case SceneSelE.Eb12:
                    regname = "eb12-streets";
                    break;
                case SceneSelE.TeneriffeMtn:
                    regname = "tenmtn";
                    break;
                case SceneSelE.TukSouCen:
                    regname = "tuksoucen";
                    break;
                case SceneSelE.Seattle:
                    regname = "seattle";
                    break;
                case SceneSelE.KeppelPort:
                    regname = "keppelport";
                    break;
                case SceneSelE.KeppelDist:
                    regname = "keppeldist";
                    break;
                case SceneSelE.Seatac:
                    regname = "seatac";
                    break;
                case SceneSelE.SanFrancisco:
                    regname = "sanfrancisco";
                    break;
                case SceneSelE.Frankfurt:
                    regname = "frankfurt";
                    break;
                case SceneSelE.HiddenLakeLookout:
                    regname = "hidlakelook";
                    break;
                case SceneSelE.Riggins:
                    regname = "riggins";
                    break;
                default:
                case SceneSelE.None:
                    break;
            }
            if (regname != "")
            {
               CreateGraphForOsmImport_streets_df(regname,regcolor);
            }
            var (gogen, nnodes, nlinks) = sman.lcman.GetNodeLinkCounts();
            Debug.Log($"StreetMan.SetScene finished gogen:{gogen} nodes:{nnodes}  links:{nlinks}");
        }

    }
}