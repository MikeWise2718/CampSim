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

        public UxSettingBool showtracks = new UxSettingBool("showtracks", false);


        public UxSetting<int> maxtrackload = new UxSetting<int>("maxtrackload", 0);
        public UxSetting<int> skiptrackstride = new UxSetting<int>("skiptrackstride", 0);
        public UxSetting<int> skiptrackptstride = new UxSetting<int>("skiptrackptstride", 0);
        public UxSetting<float> scalemodelnumber = new UxSetting<float>("scalemodelnumber", 1f);
        public UxSettingBool tracksusefragline = new UxSettingBool("tracksusefragline", false);

        public List<Street> streetlist = null;

        public Dictionary<string, Street> lookup = null;

        public void InitPhase0()
        {
        }


        public void InitializeValues()
        {
            osmstreets.GetInitial(false);
            fixedstreets.GetInitial(true);
            showtracks.GetInitial(true);
            maxtrackload.GetInitial(0);
            skiptrackstride.GetInitial(0);
            skiptrackptstride.GetInitial(0);
            tracksusefragline.GetInitial(false);
            scalemodelnumber.GetInitial(1f);

            Debug.Log($"StreetMan.InitializeValues osmblds:{osmstreets.Get()}   fixedblds:{fixedstreets.Get()}  scalemodel:{scalemodelnumber.Get()} showtracks:{showtracks.Get()}");
        }

        public void DeleteStreets()
        {
            foreach( var s in streetlist)
            {
                s.DestroyStreetThings();
                Destroy(s);
            }
            streetlist = new List<Street>();
            lookup = new Dictionary<string, Street>();
        }

        public Street AddStreet(string sname,string ava,string move,LinkUse use,LcCapType captyp)
        {
            var sgo = new GameObject(sname);
            sgo.transform.parent = this.transform;
            var strt = sgo.AddComponent<Street>();
            strt.Initialize(this, StreetType.GpxTrack,ava,move,use,captyp);
            streetlist.Add(strt);
            lookup[sname] = strt;
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

        public Street GetStreet(string sname)
        {
            if (!lookup.ContainsKey(sname)) return null;
            return lookup[sname];
        }



        Dictionary<int, string> taildict = new Dictionary<int, string>()
        {
            {0,"person|girl001|1.0|--" },
            {1,"person|man001|1.0|--" },
            {2,"person|girl002|1.0|--" },
            {3,"person|man002|1.0|--" },
            {11,"person|girl003|1.0|--" },
            {22,"person|man003|1.0|--" },
            {61,"person|girl004|1.0|--" },
            {28,"heli|heli|1.0|--" },
            {104,"drone|drone|1.0|--" },
            {107,"drone|drone|1.0|--" },
            {108,"drone|drone|1.0|--" },
            {109,"drone|drone|1.0|--" },
            {110,"drone|drone|1.0|--" },
            {111,"drone|drone|1.0|--" },
            {139,"drone|drone|1.0|--" },
            {144,"drone|drone|1.0|--" },
            {196,"drone|drone|1.0|--" },
            {198,"person|girl010|1.0|kim" },
        };
        Dictionary<string, (string clr,LinkUse linuse,LcCapType captype)> trailatts = new Dictionary<string, (string,LinkUse,LcCapType)>()
        {
            {"person",("darkred",LinkUse.trackperson,LcCapType.anything)},
            {"heli",("darkgreen",LinkUse.trackperson,LcCapType.anything)},
            {"drone",("darkblue",LinkUse.trackperson,LcCapType.anything)},
        };
        public (string cls,string clr, string ava, LinkUse use,LcCapType captype,string speed,string desc) Classify(int i)
        {
            if (taildict.ContainsKey(i))
            {
                var sar = taildict[i].Split( '|');
                if (sar.Length<4)
                {
                    Debug.Log("opps");
                }
                var cls = sar[0];
                var (clr, use, captyp) = trailatts[cls];
                return (cls, clr,sar[1], use,captyp, sar[2], sar[3]);
            }
            return ("unknown", "yellow","girl001", LinkUse.legacy,LcCapType.anything, "walk", "--");
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
            var jman = sman.jnman;
            Street strt = null;
            bool executeOnUnknown = false;
            bool addtrack = true;
            string enodename="";
            var trkname = "";

            while ( i<nrows)
            {
                var trkid = tridx[i];
                var pid = ptidx[i];
                var lat = lats[i];
                var lng = lngs[i];
                //Debug.Log($"trkid:{trkid} i:{i} lat:{lat} lng:{lng}");
                if (trkid != lsttrkid)
                {
                    //if (trkid > 4) break;
                    var cls = Classify(trkid);
                    trkname = $"track-{trkid}-{cls.cls}";
                    addtrack = executeOnUnknown || cls.cls != "unknown";

                    //if (trk > 10) break;
                    ntrksread++;
                    if (started && addtrack)
                    {
                        // add endpoint at last node name
                        //grc.AddNodePtll($"enode_{lsttrk}_{pid}", lat,lng ); 
                        jman.AddViewerJourneyNode(enodename);
                    }
                    if (addtrack)
                    {
                        started = true;
                        ntrkscreated++;
                        strt = AddStreet(trkname,cls.ava,cls.speed,cls.use,cls.captype);
                        // add startpoint at new node name
                        grc.SetCurUseType(cls.use);
                        var nname = $"{trkname}_start";
                        //Debug.Log($"Trk start {nname} {lat} {lng}");
                        var node = grc.AddNodePtll(nname, lat, lng);
                        strt.stnode = nname;
                        enodename = nname;
                        strt.AddNode(node);
                        jman.AddViewerJourneyNode(nname);
                        nodescreated++;
                    }
                    nodesread++;
                }
                else
                {
                    // Make new node point
                    // connect from last nodename to new node name
                    if (addtrack)
                    {
                        var cls = Classify(trkid);
                        var nname = $"{trkname}_{pid}";
                        enodename = nname;
                        strt.ednode = nname;
                        var lname = $"tracklink_{trkid}_{pid}";
                        //Debug.Log($"   link to {nname} {lat} {lng}");
                        var link = grc.LinkToPtll(nname, lat, lng, lname: lname);
                        strt.AddLink(link, cls.clr);
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
                jman.AddViewerJourneyNode(enodename);
            }
            grc.regman.SetRegion("default");
            sw.Stop();
            var active = showtracks.Get();
            this.gameObject.SetActive(active);
            sman.uiman.SyncState();
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