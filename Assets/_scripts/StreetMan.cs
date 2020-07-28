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

namespace CampusSimulator
{

    public class StreetMan : MonoBehaviour
    {
        public SceneMan sman;

        public UxSettingBool osmstreets = new UxSettingBool("osmstreets", false);
        public UxSettingBool fixedstreets = new UxSettingBool("fixedstreets", false);

        public UxSetting<int> maxtrackload = new UxSetting<int>("maxtrackload", 0);
        public UxSetting<int> skiptrackstride = new UxSetting<int>("skiptrackstride", 0);
        public UxSetting<int> skiptrackptstride = new UxSetting<int>("skiptrackptstride", 0);
        public UxSettingBool tracksusefragline = new UxSettingBool("tracksusefragline", false);

        public List<Street> streetlist = null;

        public void InitPhase0()
        {
        }


        public void InitializeValues()
        {
            osmstreets.GetInitial(false);
            fixedstreets.GetInitial(true);
            maxtrackload.GetInitial(0);
            skiptrackstride.GetInitial(0);
            skiptrackptstride.GetInitial(0);
            tracksusefragline.GetInitial(false);

            Debug.Log($"StreetMan.InitializeValues osmblds:{osmstreets.Get()}   fixedblds:{fixedstreets.Get()}");
        }

        public void DeleteStreets()
        {
            foreach( var s in streetlist)
            {
                s.DestroyStreetThings();
                Destroy(s);
            }
            streetlist = new List<Street>();
        }

        public Street AddStreet(string sname)
        {
            var sgo = new GameObject(sname);
            sgo.transform.parent = this.transform;
            var strt = sgo.AddComponent<Street>();
            strt.Initialize(this, StreetType.GpxTrack);
            streetlist.Add(strt);
            return strt;
        }
        public void InitializeScene(SceneSelE newregion)
        {
            Debug.Log($"StreetMan.SetScene {newregion}");
            streetlist = new List<Street>();
            InitializeValues();
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
            Debug.Log($"CreateGraphForOsmImport_streets_df");
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
            this.sman.lcman.CalculateHeights();
            grc.regman.SetRegion("default");
            Debug.Log($"CreateGraphForOsmImport_streets_df added nodes:{nnodes} links:{nlinks}");
        }

        public void SetScene(SceneSelE newregion)
        {
            var regname = "";
            var trackdir = "";
            var regcolor = "blue";
            switch (newregion)
            {
                case SceneSelE.MsftRedwest:
                case SceneSelE.MsftCoreCampus:
                case SceneSelE.MsftB19focused:
                case SceneSelE.MsftB121focused:
                    regname = "msft-campus";
                    break;
                case SceneSelE.MsftDublin:
                    regname = "msftdublin";
                    //ptscale = 1000f;
                    break;
                case SceneSelE.MsftMountainView:
                    regname = "msftmountainview";
                    //ptscale = 1000f;
                    break;
                case SceneSelE.Eb12small:
                case SceneSelE.Eb12:
                    regname = "eb12-streets";
                    break;
                case SceneSelE.TeneriffeMtn:
                    regname = "tenmtn";
                    trackdir = "tracks/mtten_rescue_export_1/";
                    //ptscale = 1000f;
                    break;
                case SceneSelE.TukSouCen:
                    regname = "tuksoucen";
                    //ptscale = 1000f;
                    break;
                case SceneSelE.Seattle:
                    regname = "seattle";
                    //ptscale = 1000f;
                    break;
                case SceneSelE.SanFrancisco:
                    regname = "sanfrancisco";
                    //ptscale = 1000f;
                    break;
                case SceneSelE.Frankfurt:
                    regname = "frankfurt";
                    //ptscale = 1000f;
                    break;
                case SceneSelE.HiddenLakeLookout:
                    regname = "hidlakelook";
                    //ptscale = 1000f;
                    break;
                case SceneSelE.Riggins:
                    regname = "riggins";
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
            if (trackdir != "")
            {
                var dftracks = LoadTracks(trackdir);
                MakeTracks(dftracks);
            }
        }

        public SimpleDf LoadTracks(string trackdir,string trackname="track_points")
        {
            SimpleDf dftrackpts = null;
            {
                var fnametrackpts = $"{trackdir}{trackname}.csv";
                dftrackpts = new SimpleDf(trackname);
                var trackpts_stringlist = DataFileMan.ReadResource(fnametrackpts);
                if (trackpts_stringlist != null)
                {
                    dftrackpts.ReadCsv(trackpts_stringlist);
                }
                Debug.Log($"Read {dftrackpts.Nrow()} track points from {fnametrackpts}");
            }
            return dftrackpts;
        }



        Dictionary<int, string> taildict = new Dictionary<int, string>()
        {
            {0,"person|--" },
            {1,"person|--" },
            {2,"person|--" },
            {3,"person|--" },
            {11,"person|--" },
            {22,"person|--" },
            {61,"person|--" },
            {28,"heli|--" },
            {104,"drone|--" },
            {107,"drone|--" },
            {108,"drone|--" },
            {109,"drone|--" },
            {110,"drone|--" },
            {111,"drone|--" },
            {139,"drone|--" },
            {144,"drone|--" },
            {196,"drone|--" },
        };
        Dictionary<string, (string,LinkUse)> trailatts = new Dictionary<string, (string,LinkUse)>()
        {
            {"person",("darkred",LinkUse.trackperson)},
            {"heli",("darkgreen",LinkUse.trackperson)},
            {"drone",("darkblue",LinkUse.trackperson)},
        };
        public (string cls,string clr,LinkUse use,string desc) Classify(int i)
        {
            if (taildict.ContainsKey(i))
            {
                var sar = taildict[i].Split( '|');
                var cls = sar[0];
                var (clr, use) = trailatts[cls];
                return (cls, clr, use, sar[1]);
            }
            return ("unknown", "yellow", LinkUse.legacy, "--");
        }

        public void MakeTracks(SimpleDf dft)
        {
            var sw = new  Aiskwk.Map.StopWatch();
            var lcman = sman.lcman;
            var grc = lcman.GetGraphCtrl();
            var lats = dft.GetDoubleCol("Y");
            var lngs = dft.GetDoubleCol("X");
            var tridx = dft.GetIntCol("track_fid");
            var ptidx = dft.GetIntCol("track_seg_point_id");

            grc.regman.NewNodeRegion("tenmtn-tracks","blue",false);

            var i = 0;
            var lsttrkid = -1;
            var nrows = dft.Nrow();

            if (nrows<=0)
            {
                Debug.LogError($"No rows in {dft.name}");
                return;
            }
            var started = false;
            var ntrksread = 0;
            var ntrkscreated = 0;
            var nodesread = 0;
            var nodescreated = 0;
            Street strt = null;
            var clr = "gray";
            bool executeOnUnknown = false;
            bool addtracks = true;

            while ( i<nrows)
            {
                var trkid = tridx[i];
                var pid = ptidx[i];
                var lat = lats[i];
                var lng = lngs[i];
                if (trkid != lsttrkid)
                {
                    //if (trk > 10) break;
                    ntrksread++;
                    if (started)
                    {
                        // add endpoint at last node name
                        //grc.AddNodePtll($"enode_{lsttrk}_{pid}", lat,lng ); 
                    }
                    var (cls,nclr,use,_) = Classify(trkid);
                    clr = nclr;
                    var sname = $"track-{trkid}-{cls}";
                    addtracks = executeOnUnknown || cls != "unknown";
                    if (addtracks)
                    {
                        ntrkscreated++;
                        strt = AddStreet(sname);
                        // add startpoint at new node name
                        grc.SetCurUseType(use);
                        var nname = $"track_{trkid}_start";
                        var node = grc.AddNodePtll(nname, lat, lng);
                        strt.AddNode(node);
                        nodescreated++;
                    }
                    nodesread++;
                }
                else
                {
                    // Make new node point
                    // connect from last nodename to new node name
                    if (addtracks)
                    {
                        var nname = $"tracknode_{trkid}_{pid}";
                        var lname = $"tracklink_{trkid}_{pid}";
                        var link = grc.LinkToPtll(nname, lat, lng, lname: lname);
                        strt.AddLink(link, clr);
                        nodescreated++;
                    }
                    nodesread++;
                }
                lsttrkid = trkid;
                // 
                i++;
            }
            if (started)
            {
                // add endpoint at last node name
                //grc.AddNodePtll($"enode_{lsttrk}_{pid}", lat, lng); 
            }
            grc.regman.SetRegion("default");
            sw.Stop();
            Debug.Log($"StreetMan processed {ntrkscreated}/{ntrksread} tracks and  {nodescreated}/{nodesread} nodes in {sw.ElapSecs()} secs");
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