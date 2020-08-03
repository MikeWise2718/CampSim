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

    public class TrackMan : MonoBehaviour
    {
        public SceneMan sman;

        public UxSettingBool showtracks = new UxSettingBool("showtracks", false);


        public UxSetting<int> maxtrackload = new UxSetting<int>("maxtrackload", 0);
        public UxSetting<int> skiptrackstride = new UxSetting<int>("skiptrackstride", 0);
        public UxSetting<int> skiptrackptstride = new UxSetting<int>("skiptrackptstride", 0);
        public UxSetting<float> scalemodelnumber = new UxSetting<float>("scalemodelnumber", 1f);
        public UxSettingBool tracksusefragline = new UxSettingBool("tracksusefragline", false);

        public List<Track> tracklist = null;

        public Dictionary<string, Track> lookup = null;

        public void InitPhase0()
        {
        }


        public void InitializeValues()
        {
            showtracks.GetInitial(true);
            maxtrackload.GetInitial(0);
            skiptrackstride.GetInitial(0);
            skiptrackptstride.GetInitial(0);
            tracksusefragline.GetInitial(false);
            scalemodelnumber.GetInitial(1f);

            Debug.Log($"TrackMan.InitializeValues   scalemodel:{scalemodelnumber.Get()} showtracks:{showtracks.Get()}");
        }

        public void DeleteTracks()
        {
            foreach( var s in tracklist)
            {
                s.DestroyTrackThings();
                Destroy(s);
            }
            tracklist = new List<Track>();
            lookup = new Dictionary<string, Track>();
        }

        public void DeleteGos()
        {
            foreach(var st in tracklist)
            {
                st.DestroyTrackGos();
            }
        }

        public void CreateGos()
        {
            int i = 0;
            foreach (var st in tracklist)
            {
                var dump = i < 10;
                st.CreateTrackGos(dump);
                i++;
            }
        }

        public void RefreshGos()
        {
            DeleteGos();
            CreateGos();
        }


        public Track AddTrack(string sname,string ava,string move,LinkUse use,LcCapType captyp)
        {
            var sgo = new GameObject(sname);
            sgo.transform.parent = this.transform;
            var trck = sgo.AddComponent<Track>();
            trck.Initialize(this, TrackType.GpxTrack,ava,move,use,captyp);
            tracklist.Add(trck);
            lookup[sname] = trck;
            return trck;
        }
        public void InitializeScene(SceneSelE newregion)
        {
            Debug.Log($"TrackMan.SetScene {newregion}");
            tracklist = new List<Track>();
            InitializeValues();
        }



        public void SetScene(SceneSelE newregion)
        {
            Debug.Log($"TrackMan.SetScene {newregion}");
            var trackdir = "";
            switch (newregion)
            {
                case SceneSelE.TeneriffeMtn:
                    trackdir = "tracks/mtten_rescue_export_1/";
                    break;
                default:
                case SceneSelE.None:
                    break;
            }
            if (trackdir != "")
            {
                var dftracks = LoadTracks(trackdir);
                MakeTracks(dftracks);
            }
            var (gogen, nnodes, nlinks) = sman.lcman.GetNodeLinkCounts();
            Debug.Log($"TrackMan.SetScene finished gogen:{gogen} nodes:{nnodes}  links:{nlinks}");
        }

        public SimpleDf LoadTracks(string trackdir,string trackname="track_points")
        {
            SimpleDf dftrackpts;
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

        public Track GetTrack(string tname)
        {
            if (!lookup.ContainsKey(tname)) return null;
            return lookup[tname];
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
            {"person",("darkred",LinkUse.trackperson,LcCapType.walk)},
            {"heli",("darkgreen",LinkUse.trackheli,LcCapType.fly)},
            {"drone",("darkblue",LinkUse.trackdrone,LcCapType.fly)},
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
            Track strt = null;
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
                        strt = AddTrack(trkname,cls.ava,cls.speed,cls.use,cls.captype);
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