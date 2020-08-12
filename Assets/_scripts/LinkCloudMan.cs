using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphAlgos;
using Aiskwk.Map;

namespace CampusSimulator
{
    public enum RmLinkFormE { pipe, wall, flatline }
    public class LinkCloudMan : MonoBehaviour
    {
        private SceneMan sman;
        public void SetSceneMan(SceneMan sman)
        {
            // this is attached as a component, thus we cannot set it in a contructor
            this.sman = sman;

        }


        public graphSceneE graphScene = graphSceneE.gen_campus;
        public Vector2 stats_nodes_links = Vector2.zero;
        public Range LinkFLoor;
        public float markerNodeSize;
        public bool nodesvisible = true;
        public bool linksvisible = true;
        public bool flatlinks = false;
        public bool filterOnCap = false;
        public LcCapType capfilter = LcCapType.anything;
        public bool filterOnUse = false;
        public LinkUse usefilter = LinkUse.legacy;
        public MapGenParameters mappars;
        public GraphAlgos.GraphCtrl grctrl = null;
        public LatLongMap longlatmap = null;

        public bool showNearestPoint = false;
        public Vector3 nearestPointRef = new Vector3(5, 0, 5);
        public int maxVoiceKeywords = 100;
        public int nVoiceKeywords = 0;





        #region LinkTransparency
        public float linkTrans = 0;
        static string ltransKey = "linkTransparency";
        public float GetLinkTransMin()
        {
            return 0;
        }
        public float GetLinkTransMax()
        {
            return 1;
        }
        public bool SetLinkTrans(float newlinktrans)
        {
            var oval = linkTrans;
            linkTrans = newlinktrans;
            if (linkTrans > 0.95f) linkTrans = 1; // bump to 1
            if (linkTrans < 0.05f) linkTrans = 0; // bump to 0
            PlayerPrefs.SetFloat(ltransKey, linkTrans);
            return oval != linkTrans;
        }
        public float GetLinkTransInitial()
        {
            if (PlayerPrefs.HasKey(ltransKey))
            {
                linkTrans = PlayerPrefs.GetFloat(ltransKey, linkTrans);
            }
            return linkTrans;
        }
        public float GetLinkTrans()
        {
            return linkTrans;
        }
        #endregion LinkTransparency


        public UxUtils.UxEnumSetting<GraphGenerationModeE> graphGenOptions = new UxUtils.UxEnumSetting<GraphGenerationModeE>("GraphGenerationMode", GraphGenerationModeE.GenFromCode);


        public enum LinkVisualOptionsE { NodesAndLinks, NodesAndFlatLinks, Nodes, Links, FlatLinks, None };
        public UxUtils.UxEnumSetting<LinkVisualOptionsE> lvisOptions = new UxUtils.UxEnumSetting<LinkVisualOptionsE>("linkVisuals",LinkVisualOptionsE.NodesAndLinks);

        public void SetLinkAndNodeVisibility(string snewval,bool force=true)
        {
            var newval = lvisOptions.Translate(snewval);
            if (!force && newval == lvisOptions.Get())
            {
                Debug.Log("SetLinkAndNodeVisiblty doing nothing because there was no change");
                return; // do nothing
            }
            this.nodesvisible = false;
            this.linksvisible = false;
            this.flatlinks = false;
            switch (newval)
            {
                case LinkVisualOptionsE.NodesAndLinks:
                    this.nodesvisible = true;
                    this.linksvisible = true;
                    break;
                case LinkVisualOptionsE.NodesAndFlatLinks:
                    this.nodesvisible = true;
                    this.linksvisible = true;
                    this.flatlinks = true;
                    break;
                case LinkVisualOptionsE.Nodes:
                    this.nodesvisible = true;
                    break;
                case LinkVisualOptionsE.Links:
                    this.linksvisible = true;
                    break;
                case LinkVisualOptionsE.FlatLinks:
                    this.linksvisible = true;
                    this.flatlinks = true;
                    break;
                case LinkVisualOptionsE.None:
                    break;
            }
            //if (sman != null)
            //{
            //    sman.RequestRefresh("LinkCloudMan-SetLinkAndNodeVisibility");
            //}
        }





        void initVals()
        {
            graphScene = graphSceneE.gen_campus;
            markerNodeSize = 0.18f;
            //Debug.Log("linkRadius:" + linkRadius + " linkNodeSize:" + linkNodeSize);
            mappars = new MapGenParameters();
            LinkFLoor = new Range(0, 0);
            nodesvisible = true;

            linkTrans = GetLinkTransInitial();
            var lopt = lvisOptions.GetInitial();
            SetLinkAndNodeVisibility(lopt.ToString());
            graphGenOptions.GetInitial();
            InitNodeColorOverrides();
            //grctrl = GetGraphCtrl();
            //Debug.Log("Initial ggo get:" + graphGenOptions.Get());
            //Debug.Log("Initial ggo getInitial:" + graphGenOptions.GetInitial());
            //Debug.Log("Initial ggo get:" + graphGenOptions.Get());
        }


        void Start()
        {
            //initVals();
        }



        graphSceneE translate(SceneSelE ss)
        {
            var rv = graphSceneE.gen_none;
            switch (ss)
            {
                case SceneSelE.MsftCoreCampus:
                case SceneSelE.MsftB19focused:
                case SceneSelE.MsftB121focused:
                case SceneSelE.MsftRedwest:
                    rv = graphSceneE.gen_campus;
                    break;
                case SceneSelE.MsftDublin:
                    rv = graphSceneE.gen_dublin;
                    break;
                case SceneSelE.TukSouCen:
                    rv = graphSceneE.gen_tukwila;
                    break;
                case SceneSelE.Eb12small:
                    rv = graphSceneE.gen_eb12_small;
                    break;
                case SceneSelE.Eb12:
                    rv = graphSceneE.gen_eb12;
                    break;
                case SceneSelE.TeneriffeMtn:
                    rv = graphSceneE.gen_tenmtn;
                    break;
            }
            return rv;
        }


        public void ModelBuild()
        {

            var genmode = graphGenOptions.Get();
            var graphScene = translate(sman.curscene);

            var mm = new LcMapMaker(grctrl, mappars);
            grctrl.maxRanHeight = LinkFLoor.max;
            grctrl.minRanHeight = LinkFLoor.min;

            mm.maxVoiceKeywords = this.maxVoiceKeywords;
            var awl = sman.bdman.walllinks.Get();
            mm.AddGraphToLinkCloud(graphScene, genmode, addWallLinks: awl);
            nVoiceKeywords = mm.nVoiceKeywords;
        }

        public void SetHeights()
        {
            if (CanGetHeights())
            {
                CalculateAndSetHeightsOnLinkCloud();
            }
            else
            {
                sman.needsLifted = false;
            }
        }

        public void ModelBuildFinal()
        {
            var gcr = GetGraphCtrl();
            gcr.RealizeLateLinks();
            SetHeights();
            DeleteUnconnectedNodes();
        }

        int updateCount = 0;
        int needRefreshUpdateCount = 0;
        public void RequestNodeEditRefresh()
        {
            needRefreshUpdateCount = updateCount;
        }

        bool oldLinksVisible;
        bool oldNodesVisible;
        bool oldFilterOnCap = false;
        LcCapType oldCapFilter;
        bool oldFilterOnUse = false;
        LinkUse oldUseFilter;
        bool CheckForVisibiltyChanges()
        {
            bool chg = (updateCount == 0) ||
                       (oldFilterOnCap != filterOnCap) ||
                       (oldCapFilter != capfilter) ||
                       (oldFilterOnUse != filterOnUse) ||
                       (oldUseFilter != usefilter) ||
                       (oldLinksVisible != linksvisible) ||
                       (oldNodesVisible != nodesvisible);
            if (chg)
            {
                if (filterOnCap && !oldFilterOnCap)
                {
                    filterOnUse = false;
                }
                else if (filterOnUse && !oldFilterOnUse)
                {
                    filterOnCap = false;
                }
                oldLinksVisible = linksvisible;
                oldNodesVisible = nodesvisible;
                oldFilterOnCap = filterOnCap;
                oldCapFilter = capfilter;
                oldFilterOnUse = filterOnUse;
                oldUseFilter = usefilter;
                sman.RequestRefresh("LinkCloudMan-CheckForVisibiltyChanges");
            }
            return chg;
        }

        // Update is called once per frame
        void Update()
        {
            updateCount += 1;

            //if (needRefreshUpdateCount > 0 && ((updateCount - needRefreshUpdateCount) > 15))
            //{
            //    sman.RequestRefresh("LinkCloudMan-Update on needRefreshUpdateCount>0");
            //    needRefreshUpdateCount = 0;
            //}
            //CheckForVisibiltyChanges();
        }

        bool CheckCapUseVisibility(LcLink link)
        {
            var rv = true;
            if (filterOnCap)
            {
                rv = LcLink.CanDoCapFromUse(capfilter,link.usetype);
            }
            else if (filterOnUse)
            {
                rv = link.usetype==this.usefilter;
            }
            return rv;
        }

        bool IsFragable(LcLink link)
        {
            var rv = true;
            if (link.usetype== LinkUse.droneway)
            {
                rv = false;
            }
            return rv;
        }

        bool CheckCapUseVisibility(LcNode node)
        {
            var rv = true;
            if (filterOnCap)
            {
                rv = LcLink.CanDoCapFromUse(capfilter, node.usetype);
            }
            else if (filterOnUse)
            {
                rv = node.usetype == this.usefilter;
            }
            return rv;
        }



        public bool CanGetHeights()
        {
            // todo - to do: setup heights from qkmaptool
            if (longlatmap == null)
            {
                //longlatmap = sman.glGetComponent<LatLongMap>();
                longlatmap = sman.coman.glbllm;
                if (longlatmap == null) return false;
            }
            return true;
            //var y = GetHeight(0, 0);
            //if (y > 0)
            //{
            //    Debug.Log("y:" + y);
            //}
            //return y > 0;
        }

        public float GetHeight(float x,float z)
        {
            var y = sman.mpman.GetHeight(x, z);
            return y;
        }

        public void CalculateAndSetHeightsOnLinkCloud()
        {
            longlatmap = sman.coman.glbllm;
            if (longlatmap == null) return;
            var calcHeights = true;
            var grc = GetGraphCtrl();
            var llmap = sman.mpman.GetLatLongMap();
            foreach (string lptname in grc.linkpoints())
            {
                var node = grc.GetNode(lptname);
                //var v2 = longlatmap.llcoord(node.pt.x, node.pt.z);
                var v2 = llmap.llcoord(node.pt.x, node.pt.z);
                node.lat = v2.x;
                node.lng = v2.y;
                if (calcHeights)
                {
                    var yoff = GetHeight(node.pto.x, node.pto.z);
                    //if (node.pto.y>5)
                    //{
                    //    Debug.Log("Here is one");
                    //}
                    node.pt = new Vector3(node.pto.x, node.pto.y + yoff, node.pto.z);
                }
            }
            var cam = Camera.current;
            if (cam != null)
            {
                var pt = cam.transform.position;
                var ht = GetHeight(pt.x, pt.z);
                cam.transform.position = new Vector3(pt.x, pt.y + ht, pt.z);
            }
            sman.needsLifted = false;
        }
        public GraphCtrl GetGraphCtrl(bool donotallocate=false)
        {
            if (grctrl == null)
            {
                if (donotallocate)
                {
                    return null;
                }
                grctrl = new GraphCtrl(sman.graphsdir)
                {
                    lltoxz = new GraphCtrl.LtoXZfunction(sman.coman.lltoxz)
                };
            }
            return (grctrl);
        }
        public void SetKeyWordLimit(int maxVoiceKeywords)
        {
            this.maxVoiceKeywords = maxVoiceKeywords;
        }
        public void SaveToJsonFile(string fname)
        {
            var gcr = GetGraphCtrl();
            if (gcr != null)
            {
                LcMapMaker.SaveToFile(gcr, fname,ref gcr.regman.curNodeRegion);
            }
        }
        public void SaveRegionFiles(string path)
        {
            grctrl.SaveRegionFiles(path);
        }
        public void SaveRegionCodeFiles(string path)
        {
            grctrl.SaveRegionCodeFiles(path);
        }
        public void LoadRegionBuildings(string path)
        {
            grctrl.SaveRegionCodeFiles(path);
        }

        public void CreateNodeGo(LcNode node)
        {
            var cname = nodecolor(node.name);
            var nsize = nodesize(node);
            var go = NodeGo.MakeNodeGo(sman, node, nsize, cname, 1 - linkTrans);
            go.transform.parent = grcnodes.transform;
        }
        public void CreateNodeGo(string lptname)
        {
            var gcr = GetGraphCtrl();
            var node = gcr.GetNode(lptname);
            CreateNodeGo(node);
        }
        int gogencount = 0;
        void CreateGrcGos()
        {
            Debug.Log($"CreateGrcGos-{gogencount} scene:{sman.curscene} isnull:{grcgos==null}");
            var sw = new Aiskwk.Map.StopWatch();
            var swnd = new Aiskwk.Map.StopWatch();
            var swlk = new Aiskwk.Map.StopWatch();
            var grc = GetGraphCtrl();
            sman.leditor.SetGraphCtrl(grc);
            if (grcgos == null)
            {
                grcgos = new GameObject("GraphCtrl-" + gogencount);
                var gccomp = grcgos.AddComponent<GraphCtrlComp>();
                gccomp.Init(this,grctrl);
                grcgos.transform.parent = sman.rgo.transform;
                grcnodes = new GameObject("nodes");
                grcnodes.transform.parent = grcgos.transform;
                grclinks = new GameObject("links");
                grclinks.transform.parent = grcgos.transform;
                var (gogen, nn, nl) = GetNodeLinkCounts();
                Debug.Log($"CreateGrcGos - gogen:{gogen} nodes:{nn} links:{nl}");
                gogencount++;
            }
            if (linksvisible)
            {

                swlk.Start();
                var links = grc.GetLcLinks();
                sman.mpman.nTotIsects = 0;
                foreach (var lnk in links)
                {
                    if (!CheckCapUseVisibility(lnk)) continue;
                    var dofrag = IsFragable(lnk);
                    var clrname = linkcolor(lnk);
                    var linkrad = linkradius(lnk);
                    var linkfrm = linkform(lnk);
                    var go = LinkGo.MakeLinkGo(sman, lnk, linkfrm, linkrad, clrname,1-linkTrans,this.flatlinks,dofrag:dofrag);
                    go.transform.parent = grclinks.transform;
                }
                swlk.Stop();
                var nisects = sman.mpman.nTotIsects;
                Debug.Log($"CreateGrcGos - linknamelist size:{grc.linknamelist.Count}/{links.Count} took:{swlk.ElapSecs()} secs  -  isects:{nisects}");
            }
            if (nodesvisible)
            {

                swnd.Start();

                //Debug.Log("Recreating nodegos");
                var nodes = grc.GetLcNodes();
                foreach (var node in nodes)
                {
                    if (!CheckCapUseVisibility(node)) continue;
                    CreateNodeGo(node);
                }
                swnd.Stop();
                Debug.Log($"CreateGrcGos - nodenamelist size:{grc.nodenamelist.Count}/{nodes.Count} took:{swnd.ElapSecs()} secs");


                if (showNearestPoint)
                {
                    var tup = FindClosestPointOnLineCloud(nearestPointRef);
                    var npt = tup.Item2;
                    var nname = "linknearsph-";

                    var pnsph = GraphUtil.CreateMarkerSphere(nname, npt, size: 2.5f *sman.linknodescale*markerNodeSize, clr: "red",alf:1-linkTrans);
                    pnsph.transform.parent = grcgos.transform;
                }
            }
            stats_nodes_links.x = grc.GetNodeCount();
            stats_nodes_links.y = grc.GetLinkCount();
            sw.Stop();
            Debug.Log($"CreateGrcGos {gogencount} took {sw.ElapSecs()} secs");
        }
        public void DeleteGrcGos()
        {
            if (grcgos != null)
            {
                Destroy(grcgos);
                grcgos = null;
            }
        }
        public void DeleteUnconnectedNodes()
        {
            var grc = GetGraphCtrl();
            var nodesToDelete = new List<string>();
            var nodelist = grc.GetLcNodes();
            var numnodesbefore = nodelist.Count;
            foreach (var n in nodelist)
            {
                if (n.wegtos==null || n.wegtos.Count == 0)
                {
                    nodesToDelete.Add(n.name);
                }
            }
            Debug.Log($"DeleteUnconnectedNodes  number to delete:{nodesToDelete.Count} of {numnodesbefore}");
            foreach (var nname in nodesToDelete)
            {
                grc.DelNode(nname);
            }
        }
        public void DeleteAllNodes()
        {
            var grc = GetGraphCtrl(donotallocate:true);
            if (grc != null)
            {
                var nodesToDelete = grc.GetLcNodes();
                foreach (var node in nodesToDelete)
                {
                    grc.DelNode(node.name);
                }
                grc.DeleteLateLinks();
                grc.DeleteKeywords();
            }
        }
        public void DeleteAllLinks()
        {
            var grc = GetGraphCtrl();
            var linksToDelete = grc.GetLcLinks();
            foreach (var link in linksToDelete)
            {
                grc.DelLink(link.name);
            }
        }
        #region public methods
        public void DestroyLinkCloud()
        {
            //DelLcGos();
            grctrl = null;        
        }
        public void BaseInitialize(SceneSelE newregion)
        {
            CreateGrcGos();

            LcMapMaker.Reset();
            initVals();

        }
        public void DelLcGos()
        {
            DeleteGrcGos();
            grctrl = null;
        }

        GameObject grcgos = null;
        GameObject grcnodes = null;
        GameObject grclinks = null;

        Dictionary<string,string> nodeColorOverrides = new Dictionary<string,string>();

        public void InitNodeColorOverrides()
        {
            Dictionary<string, string> nodeColorOverrides = new Dictionary<string, string>();
        }
        public void SetNodeColorOverride(string nodename,string color,GameObject go=null)
        {
            nodeColorOverrides[nodename] = color;
            if (go)
            {
                GraphAlgos.GraphUtil.SetColorOfGo(go, color);
            }
        }
        public void RemoveNodeColorOverride(string nodename)
        {
            nodeColorOverrides.Remove(nodename);
        }
        public bool NodeHasOverrideColor(string nodename)
        {
            return nodeColorOverrides.ContainsKey(nodename);
        }
        public string NodeOverrideColor(string nodename)
        {
            return nodeColorOverrides[nodename];
        }

        private string nodecolor(string nodename)
        {
            if (NodeHasOverrideColor(nodename))
            {
                return nodeColorOverrides[nodename];
            }
            if (sman == null)
            {
                return ("steelblue");
            }
            var nl = nodename.Length;

            var colselecter = SceneMan.RmColorModeE.nodecloud;
            var gcr = GetGraphCtrl();
            if (gcr.voiceEnabled(nodename))
            {
                colselecter = SceneMan.RmColorModeE.nodecloudx;
            }
            return (sman.getcolorname(colselecter, nodename));
        }

        Dictionary<LinkUse, SceneMan.RmColorModeE> linkclrdicttran = new Dictionary<LinkUse, SceneMan.RmColorModeE>()
        {
            { LinkUse.legacy,SceneMan.RmColorModeE.linkcloud },
            { LinkUse.highway,SceneMan.RmColorModeE.linkhighway },
            { LinkUse.road,SceneMan.RmColorModeE.linkroad },
            { LinkUse.slowroad,SceneMan.RmColorModeE.linkslowroad },
            { LinkUse.driveway,SceneMan.RmColorModeE.linkdriveway },
            { LinkUse.walkway,SceneMan.RmColorModeE.linkwalk },
            { LinkUse.walkwaynoshow,SceneMan.RmColorModeE.linkwalknoshow },
            { LinkUse.excavation,SceneMan.RmColorModeE.linkexcavate},
            { LinkUse.marker,SceneMan.RmColorModeE.linksurvey},
            { LinkUse.waterpipe,SceneMan.RmColorModeE.linkwater},
            { LinkUse.sewerpipe,SceneMan.RmColorModeE.linksewer},
            { LinkUse.recwaterpipe,SceneMan.RmColorModeE.linkreclaimwater   },
            { LinkUse.elecpipe,SceneMan.RmColorModeE.linkelec },
            { LinkUse.commspipe,SceneMan.RmColorModeE.linkcomms },
            { LinkUse.oilgaspipe,SceneMan.RmColorModeE.linkoilgas },
            { LinkUse.bldwall,SceneMan.RmColorModeE.bldwall },
            { LinkUse.trackperson,SceneMan.RmColorModeE.trackperson },
            { LinkUse.trackheli,SceneMan.RmColorModeE.trackheli },
            { LinkUse.trackdrone,SceneMan.RmColorModeE.trackdrone },
            { LinkUse.droneway,SceneMan.RmColorModeE.trackdrone },
        };


        private string linkcolor(LcLink link)
        {
            var linkname = link.name;
            if (sman == null)
            {
                return ("orange");
            }
            var rmmode= linkclrdicttran[link.usetype];
            var clrname = sman.getcolorname(rmmode, linkname);
            return clrname;
        }
        private float linkradius(LcLink link)
        {
            var linkname = link.name;
            if (sman == null)
            {
                return 0.1f;
            }
            var rmmode = linkclrdicttran[link.usetype];
            var rad = sman.getradius(rmmode);
            //Debug.Log("link.usetype:" + link.usetype + " rmmode:" + rmmode + " rad:" + rad);
            return rad;
        }
        private RmLinkFormE linkform(LcLink link)
        {
            var linkname = link.name;
            if (sman == null)
            {
                return RmLinkFormE.pipe;
            }
            var rmmode = linkclrdicttran[link.usetype];
            var form = sman.getform(rmmode);
            //Debug.Log("link.usetype:" + link.usetype + " rmmode:" + rmmode + " rad:" + rad);
            return form;
        }
        private float nodesize(LcNode node)
        {
            var nodename = node.name;
            if (sman == null)
            {
                return 0.1f;
            }
            var rmmode = linkclrdicttran[node.usetype];
            var rad = 2.0f*sman.getradius(rmmode); 
            //Debug.Log("link.usetype:" + link.usetype + " rmmode:" + rmmode + " rad:" + rad);
            return rad;
        }
        public LcLink GetLink(string name)
        {
            var gcr = GetGraphCtrl();
            if (gcr.islinkname(name))
            {
                return (gcr.GetLink(name));
            }
            return (null);
        }
        public void DeleteLink(string name)
        {
            var gcr = GetGraphCtrl();
            if (gcr.islinkname(name))
            {
                gcr.DelLink(name);
                RefreshGos();
            }
        }
        public List<string> FindNodes(string begfilt)
        {
            var gcr = GetGraphCtrl();
            return gcr.FindNodes(begfilt);
        }
        public string q(string s)
        {
            var rv = "\"" + s + "\"";
            return rv;
        }

        public void LinkNodes(string nodename1,string nodename2)
        {
            var gcr = GetGraphCtrl();
            if (gcr.IsNodeName(nodename1) && gcr.IsNodeName(nodename2))
            {
                string linkname = nodename1 + ":" + nodename2;
                var lpt1 = gcr.GetNode(nodename1);
                var lpt2 = gcr.GetNode(nodename2);
                gcr.AddLink(linkname,lpt1,lpt2);
                RefreshGos();
                var clipstring = "lc.AddLinkByNodeName( " + q(nodename1) + "," + q(nodename2) + ");";
                GraphUtil.AddToClipboard( clipstring );
                Debug.Log("Wrote "+clipstring+" to clipboard");
            }
        }
        public void DeleteNode(string name)
        {
            var gcr = GetGraphCtrl();
            if (gcr.IsNodeName(name))
            {
                gcr.DelNode(name);
                RefreshGos();
            }
        }
        public LcNode PunchNewNode(PathPos pp, string newptname = "", bool deleteparentlink = false)
        {
            var gcr = GetGraphCtrl();
            var lpt = gcr.PunchNewNode(pp, newptname, deleteparentlink);
            return (lpt);
        }
        public LcNode GetNode(int idx)
        {
            var gcr = GetGraphCtrl();
            var lpt = gcr.GetNode(idx);
            return (lpt);
        }
        public LcNode GetNode(string name)
        {
            var gcr = GetGraphCtrl();
            var lpt = gcr.GetNode(name);
            return (lpt);
        }
        public (int gogen,int nnodes,int nlinks) GetNodeLinkCounts()
        {
            if (grctrl != null)
            {
                return (gogencount, grctrl.GetNodeCount(), grctrl.GetLinkCount());
            }
            else
            {
                return (gogencount, 0, 0);
            }
        }
        public void RefreshGos(bool deletethings=true)
        {
            if (deletethings)
            {
                DeleteGrcGos();
            }
            CreateGrcGos();
        }
        public LcNode GetRandomNode()
        {
            var gcr = GetGraphCtrl();
            var lpt = gcr.GenRanNode();
            return (lpt);
        }
        public Path GenAstar(string startnodename, string endnodename, LcCapType captype)
        {
            var gcr = GetGraphCtrl();
            var path = gcr.GenAstar(startnodename, endnodename, captype);
            return (path);
        }
        public Path GenRanPath(string startnodename, int n)
        {
            var gcr = GetGraphCtrl();
            var path = gcr.GenRanPath(startnodename, n);
            return (path);
        }
        public LinkedList<string> GetKeywordKeys()
        {
            var gcr = GetGraphCtrl();
            return (gcr.GetKeywordKeys());
        }
        public LinkedList<string> GetKeywordValues()
        {
            var gcr = GetGraphCtrl();
            return (gcr.GetKeywordValues());
        }
        public string GetKeywordValue(string key)
        {
            var gcr = GetGraphCtrl();
            return (gcr.GetKeywordValue(key));
        }
        public bool IsLinkName(string lname)
        {
            var gcr = GetGraphCtrl();
            return (gcr.islinkname(lname));
        }
        public bool IsNodeName(string pname)
        {
            var gcr = GetGraphCtrl();
            return (gcr.IsNodeName(pname));
        }
        public Tuple<LcLink, Vector3> FindClosestPointOnLineCloud(Vector3 pt)
        {
            var gcr = GetGraphCtrl();
            return (gcr.FindClosestPointOnLineCloudTuple(pt));
        }
        public LcLink FindClosestLinkOnLineCloudFiltered(string filter, Vector3 pt)
        {
            return (FindClosestLinkOnLineCloudFiltered(filter, pt));
        }
        public void NoiseUpNodes(float maxdist)
        {
            var gcr = GetGraphCtrl();
            gcr.noiseUpNodes(maxdist, maxdist, maxdist);
        }
        #endregion
    }
}