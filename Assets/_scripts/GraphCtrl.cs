using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Aiskwk.Map;

/// <summary>
/// GraphAlgos.cs  - This file contains Graph algorithems that we need. It is fairly self-contained. 
/// </summary>

namespace GraphAlgos
{
    public enum GraphGenerationModeE { GenFromCode, ReadFromFile };
    public enum textureMethE { none, material, bitmap }
    public enum textureGeomE { none, plane, mesh }
    [Serializable]
    public class graphtex
    {
        public textureMethE texMeth;
        public textureGeomE texGeom;
        public string bitmapName = "";
        public string materialName = "";
        public int bitmapXpix = 100;
        public int bitmapYpix = 100;
        public float aspectXoY = 1f;
        public Vector3 scale;
        public Vector3 rotate;
        public Vector3 translate;

        public graphtex()
        {
            texMeth = textureMethE.none;
            texGeom = textureGeomE.none;
            scale = Vector3.zero;
            rotate = Vector3.zero;
            translate = Vector3.zero;
        }
        public void SetMaterialPlane(string matname, int xpix, int ypix, Vector3 sca, Vector3 rot, Vector3 trn)
        {
            // here we store the bitmap values for possible future reference, but we do not use them
            this.texMeth = textureMethE.material;
            this.texGeom = textureGeomE.plane;
            this.materialName = matname;
            this.bitmapXpix = xpix;
            this.bitmapYpix = ypix;
            this.aspectXoY = xpix * 1f / ypix;
            this.scale = sca;
            this.rotate = rot;
            this.translate = trn;
        }
        public void SetMaterialPlane(string matname, int xpix, int ypix, Vector3 rot, Vector3 trn, float scalefak = 1)
        {
            // here we calculate the scale factor from the aspect ratio
            this.texMeth = textureMethE.material;
            this.texGeom = textureGeomE.plane;
            this.materialName = matname;
            this.bitmapXpix = xpix;
            this.bitmapYpix = ypix;
            this.aspectXoY = xpix * 1f / ypix;
            var sca = new Vector3(10 * aspectXoY, 1, 10);
            this.scale = sca * scalefak;
            this.rotate = rot;
            this.translate = trn;
        }
        public graphtex(graphtex gt)
        {
            this.texMeth = gt.texMeth;
            this.texGeom = gt.texGeom;
            this.bitmapName = gt.bitmapName;
            this.materialName = gt.materialName;
            this.bitmapXpix = gt.bitmapXpix;
            this.bitmapYpix = gt.bitmapYpix;
            this.aspectXoY = gt.aspectXoY;
            this.scale = gt.scale;
            this.rotate = gt.rotate;
            this.translate = gt.translate;
        }
    }
    public class graphmods
    {
        public string mod_name_pfx = "";
        public float mod_x_fak = 1.0f;
        public float mod_x_off = 0.0f;
        public float mod_y_fak = 1.0f;
        public float mod_y_off = 0.0f;
        public float mod_z_fak = 1.0f;
        public float mod_z_off = 0.0f;
        public LatLongMap llm=null;
        public graphmods()
        {
            initmods();
        }
        public void initmods()
        {
            mod_name_pfx = "";
            mod_x_fak = 1.0f;
            mod_x_off = 0.0f;
            mod_y_fak = 1.0f;
            mod_y_off = 0.0f;
            mod_z_fak = 1.0f;
            mod_z_off = 0.0f;
            this.llm = null;
        }
        public void setmapper(LatLongMap llm)
        {
            this.llm = llm;
        }
        public Vector3 modv(Vector3 v)
        {
            var rv = new Vector3(
                v.x * mod_x_fak - mod_x_off,
                v.y * mod_y_fak - mod_y_off,
                v.z * mod_z_fak - mod_z_off
                );
            if (llm!=null)
            {
                rv = llm.mapcoord.glbmap(rv);
            }
            return (rv);
        }
        public Vector3 unmodv(Vector3 v)
        {
            if (llm != null)
            {
                v = llm.mapcoord.glbunmap(v);
            }
            var rv = new Vector3(
                (v.x + mod_x_off) / mod_x_fak,
                (v.y + mod_y_off) / mod_y_fak,
                (v.z + mod_z_off) / mod_z_fak
                );
            return (rv);
        }
        public string addprefix(string basestring)
        {
            if (basestring.IndexOf(mod_name_pfx) != 0)
            {
                return mod_name_pfx + basestring;
            }
            return basestring;
        }
    }
    [Serializable]
    public class NodeRegion
    {
        public string name;
        public string color;
        public int regid;
        public bool saveToFile;
        public int maxDefStepIdx;
        public NodeRegion()
        {
            maxDefStepIdx = 1;
        }
        public int GetCurStepIdx()
        {
            return maxDefStepIdx;
        }

        public void IncDefStepIdx()
        {
            maxDefStepIdx++;
        }
    }

    public class NodeRegionMan
    {
        GraphCtrl grc;
        Dictionary<string,NodeRegion> regionDict;
        public NodeRegion curNodeRegion;
        public NodeRegionMan(GraphCtrl grc)
        {
            this.grc = grc;
            regionDict = new Dictionary<string, NodeRegion>();
            curNodeRegion = NewNodeRegion("default", "red", false);
        }
        public List<NodeRegion> GetRegions()
        {
            var rv = new List<NodeRegion>(regionDict.Values);
            return rv;
        }
        public NodeRegion NewNodeRegion(string name, string color, bool saveToFile, bool makeCurrent=true, bool warnondups=false)
        {
            //Debug.Log($"NewNodeRegion:{name}");
            NodeRegion newRegion;
            if (regionDict.ContainsKey(name))
            {
                if (warnondups)
                {
                    Debug.LogWarning("NewNodeRegion " + name + " already exists");
                }
                newRegion = regionDict[name];
            }
            else
            {
                newRegion = new NodeRegion { name = name, color = color, saveToFile = saveToFile, regid = regionDict.Count + 2000 };
                regionDict[name] = newRegion;
            }
            if (makeCurrent)
            {
                curNodeRegion = newRegion;
            }
            return newRegion;
        }
        public bool SetRegion(string name)
        {
            if (!regionDict.ContainsKey(name))
            {
                Debug.LogWarning("NodeRegion man does not contain a region:" + name);
                return false;
            }
            curNodeRegion = regionDict[name];
            return true;
        }
        public NodeRegion GetRegion(string name)
        {
            if (!regionDict.ContainsKey(name))
            {
                Debug.LogWarning("Unknown regionname:" + name + " in GetRegion");
                return null;
            }
            var rv = regionDict[name];
            return rv;
        }
        public NodeRegion GetRegion(int regid)
        {
            foreach( var reg in regionDict.Values)
            {
                if (reg.regid==regid)
                {
                    return reg;
                }
            }
            return null;
        }
        public NodeRegion GetCurrent()
        {
            return curNodeRegion;
        }
        public int GetNodeRegionCount()
        {
            return regionDict.Count;
        }
        public List<int> GetNodeRegionCounts()
        {
            var rv = new List<int>();
            foreach (var r in regionDict.Values)
            {
                var ncnt = grc.GetNodeCount(r.regid);
                rv.Add(ncnt);
            }
            return rv;
        }
        public int GetNodeRegionCountSum()
        {
            var cnts = GetNodeRegionCounts();
            return cnts.Sum();
        }
        public List<string> GetNodeRegionsDesc()
        {
            var cnts = GetNodeRegionCounts();
            var rv = new List<string>();
            foreach (var r in regionDict.Values)
            {
                var ncnt = grc.GetNodeCount(r.regid);
                var msg = "Region " + r.name + " " + r.color + " id:" + r.regid+" nodes:"+ncnt;
                rv.Add(msg);
            }
            return rv;
        }
        static string ListToStr(List<int> ilist)
        {
            var rv = "";
            ilist.ForEach(x => rv += x.ToString()+" ");
            return rv;
        }
        public string GetMultiplicityDesc()
        {
            var maxcnt = 5;
            var cnt = new int[maxcnt];
            foreach (var n in grc.GetLcNodes())
            {
                var multi = 0;
                if (n.regid!=0)
                {
                    multi = 1;
                }
                if (multi > maxcnt) multi = maxcnt;
                cnt[multi]++;
            }
            var rv = "Node Regions Multiplicity: ";
            for(int i = 0; i<maxcnt; i++)
            {
                if (i == maxcnt-1)
                {
                    rv += i + "+:" + cnt[i] + "   ";
                }
                else
                {
                    rv += i + ":" + cnt[i] + "   ";
                }
            }
            rv += "   sum:" + cnt.Sum();
            return rv;
        }
        public void DumpMultiNodes()
        {
            //foreach (var n in grc.GetLcNodes())
            //{
            //    var multi = n.regions.Count();
            //    if (multi==0 || multi>1)
            //    {
            //        Debug.Log("Node "+n.name+" n:"+multi+"  ids:"+ListToStr(n.regions));
            //    }
            //}
        }


    }


    public class GraphCtrl
    {
        public delegate (float x,float z) LtoXZfunction(double Lat,double lng);
        public LtoXZfunction lltoxz = null;

        public NodeRegionMan regman;

        public List<string> nodenamelist = null;
        Dictionary<string, LcNode> nodedict = null;
        public Dictionary<string, string> nodekeywords = null;

        public List<string> linknamelist = null;
        Dictionary<string, LcLink> linkdict = null;
        //List<Link> lklistlist = null;

        public bool exceptionOnDuplicate = false;

        System.Random ranman = null;
        public float maxRanHeight = 0.0f;
        public float minRanHeight = 0.0f;
        public static int ranSeed = 1;

        public LinkUse curUseType = LinkUse.legacy;

        public graphtex floorMan = new graphtex();

        public string uniqueNodePrefix = "node";
        public string uniqueLinkPrefix = "link";
        public string graphdir = "";


        public void SetCurUseType(LinkUse usetype)
        {
            curUseType = usetype;
        }
        public int GetLinkCount()
        {
            return linkdict.Count;
        }
        public int GetNodeCount()
        {
            return nodenamelist.Count;
        }
        public int GetNodeCount(int regid)
        {
            var cnt = 0;
            foreach (var node in nodedict.Values)
            {
                if (node.IsInRegion(regid)) cnt++;
            }
            return cnt;
        }

        public List<LcNode> GetNodesInRegion(int regid)
        {

            var rv = new List<LcNode>();
            foreach (var node in nodedict.Values)
            {
                if (node.IsInRegion(regid))
                {
                    rv.Add(node);
                }
            }
            return rv;
        }
        public List<LcLink> GetLinksInRegion(int regid)
        {

            var rv = new List<LcLink>();
            foreach (var link in linkdict.Values)
            {
                if (link.IsInRegion(regid))
                {
                    rv.Add(link);
                }
            }
            return rv;
        }
        private int newnodenamenumber = 0;
        public string genuniquenodename()
        {
            var maxiter = GetNodeCount() + 100;
            var niter = 0;
            while (niter < maxiter)
            {
                var newname = uniqueNodePrefix + newnodenamenumber.ToString("D2");
                newnodenamenumber++;
                if (!IsNodeName(newname)) return newname;
            }
            return null;
        }
        private int newlinknamenumber = 0;
        public string genuniquelinkname()
        {
            var maxiter = GetNodeCount() + 100;
            var niter = 0;
            while (niter < maxiter)
            {
                var newname = uniqueLinkPrefix + newlinknamenumber.ToString("D2");
                newlinknamenumber++;
                if (!islinkname(newname)) return newname;
            }
            return null;
        }

        public GraphCtrl(string graphdir)
        {
            ranman = new System.Random(ranSeed);
            ranSeed++;
            nodenamelist = new List<string>();
            nodedict = new Dictionary<string, LcNode>();
            nodekeywords = new Dictionary<string, string>();
            linknamelist = new List<string>();
            //lklistlist = new List<Link>();
            linkdict = new Dictionary<string, LcLink>();
            regman = new NodeRegionMan(this);
            this.graphdir = graphdir;
            //Debug.Log("Initialized LinkCloud and regman graphdir:"+graphdir);
        }
        public List<LcNode> GetLcNodes()
        {
            return new List<LcNode>(nodedict.Values);
        }
        public List<LcLink> GetLcLinks()
        {
            return new List<LcLink>(linkdict.Values);
        }
        public void noiseUpNodes(float maxdistx, float maxdisty, float maxdistz)
        {
            var rnd = new System.Random();
            foreach (var ptname in nodenamelist)
            {
                var node = nodedict[ptname];
                var incx = (float)(2 * maxdistx * rnd.NextDouble() - maxdistx);
                var incy = (float)(2 * maxdisty * rnd.NextDouble() - maxdisty);
                var incz = (float)(2 * maxdistz * rnd.NextDouble() - maxdistz);
                node.pt = new Vector3(node.pt.x + incx, node.pt.y + incy, node.pt.z + incz);
            }
        }
        public bool voiceEnabled(string roomname)
        {
            return nodekeywords.Values.Contains<string>(roomname);
        }
        #region linkcloud construction
        public graphmods gm = new graphmods();

        public void SaveRegionFiles(string path)
        {
            var regs = regman.GetRegions();
            Debug.Log($"GraphCloud SaveRegionFiles regs:{regs.Count}");
            foreach (var reg in regs)
            {
                var rreg = reg;
                if (rreg.saveToFile)
                {
                    var fname = path + rreg.name + ".region";
                    Debug.Log("Saving " + fname);
                    LcMapMaker.SaveToFile(this, fname,ref rreg);
                }
            }
        }
        public void LoadRegionBuildings(string path)
        {
            var regs = regman.GetRegions();
            Debug.Log($"GraphCloud LoadRegionBuildings regs:{regs.Count} not implemented yet");
            //foreach (var reg in regs)
            //{
            //    var rreg = reg;
            //    if (rreg.saveToFile)
            //    {
            //        var fname = path + rreg.name + ".region";
            //        Debug.Log("Saving " + fname);
            //        LcMapMaker.SaveToFile(this, fname, ref rreg);
            //    }
            //}
        }
        public void SaveRegionCodeFiles(string path)
        {
            var regs = regman.GetRegions();
            Debug.Log($"GraphCloud SaveRegionCodeFiles regs:{regs.Count}");
            var codeWriter = new GraphAlgos.CodeFileSaver(this);
            path = path + "code/";
            System.IO.Directory.CreateDirectory(path);
            foreach (var reg in regs)
            {
                var rreg = reg;
                if (rreg.saveToFile)
                {
                    var fname = path  + rreg.name + ".code";
                    Debug.Log("Saving " + fname);
                    codeWriter.SaveToFile(fname, reg);
                }
            }
        }
        public LcNode AddNode(string ndname, Vector3 v,bool domodv=true,string comment="")
        {
            ndname = gm.addprefix(ndname);
            if (nodedict.ContainsKey(ndname))
            {
                var msg = $"Duplicate Point name:{ndname}";
                Debug.LogWarning(msg);
                if (exceptionOnDuplicate)
                {
                    throw new UnityException(msg);
                }
                else
                {
                    return null;
                }
            }
            if (domodv)
            {
                v = gm.modv(v);
            }
            nodenamelist.Add(ndname);
            var node = new LcNode(this, ndname, v,LinkUse.legacy,ref regman.curNodeRegion,comment:comment);
            nodedict.Add(ndname, node);
            anchorpt = node;
            return (node);
        }
        public float yfloor = 0;
        float ranHeight()
        {
            var dlt = maxRanHeight - minRanHeight;
            var rv = yfloor + (float)ranman.NextDouble() * dlt + minRanHeight;
            return (rv);
        }
        float GetUseOffset(LinkUse use)
        {
            switch (use)
            {
                //case LinkUse.trackdrone: return 10f;
                //case LinkUse.trackheli: return 100f;
                case LinkUse.trackdrone: return 0f;
                case LinkUse.trackheli: return 0f;
                default: return 0f;
            }
        }
        public LcNode AddNodePtxzNoInc(string ndname, double x, double z, string comment = "")
        {
            var xf = (float)x;
            var yf = ranHeight() + GetUseOffset(curUseType);
            var zf = (float)z;
            return (AddNode(ndname, new Vector3(xf, yf, zf), comment: comment));
        }
        public LcNode AddNodePtll(string ndname, double lat, double lng, string comment = "")
        {
            if (lltoxz==null)
            {
                Debug.LogError($"lltoxz null in AddNodePtll");
                return null;
            }
            var (x, z) = lltoxz(lat, lng);
            //Debug.Log($"AddNodePtll lat:{lat} lng:{lng}  x:{x} z:{z}");
            var rv = AddNodePtxzNoInc(ndname, x, z, comment);
            regman.curNodeRegion.IncDefStepIdx();
            return rv;
        }
        public LcNode AddNodePtxz(string ndname, double x, double z,string comment="")
        {
            var rv = AddNodePtxzNoInc(ndname, x, z, comment);
            regman.curNodeRegion.IncDefStepIdx();
            return rv;
        }
        public LcNode AddNodePtxyzNoInc(string ndname, double x, double y,double z, string comment = "")
        {
            var xf = (float)x;
            var yf = (float)y;
            var zf = (float)z;
            return (AddNode(ndname, new Vector3(xf, yf, zf), comment: comment));
        }
        public LcNode AddNodePtxyz(string ndname, double x, double y,double z, string comment = "")
        {
            var rv = AddNodePtxyzNoInc(ndname, x,y, z, comment);
            regman.curNodeRegion.IncDefStepIdx();
            return rv;
        }
        public LcNode GetNewNode(string ndname, Vector3 v,LinkUse usetype,string comment="")
        {
            if (nodedict.ContainsKey(ndname))
            {
                return (nodedict[ndname]);
            }
            // otherwise we need to make it
            nodenamelist.Add(ndname);
            var node = new LcNode(this, ndname, v,usetype, ref regman.curNodeRegion,comment);
            nodedict.Add(ndname, node);
            return (node);
        }
        //public void AddIdToNode(string name)
        //{
        //    if (!nodedict.ContainsKey(name))
        //    {
        //        Debug.LogWarning("AddIdToNode could not find node:" + name);
        //        return;
        //    var node = GetNode(name);
        //    node.AddRegion(regman.curNodeRegion.regid);
        //}
        public void SaveRegionFiles()
        {

        }
        public LcLink AddLink(string lname, LcNode lp1, LcNode lp2)
        {
            return AddLink(lname, lp1, lp2, curUseType);
        }
        public LcLink AddLink(string lname, LcNode lp1, LcNode lp2,LinkUse usetype)
        {
            //if (lname== "rwb-f03-cv1101")
            //{
            //    Debug.Log("Magic link begin added");
            //}
            if (lname == "")
            {
                lname = gm.addprefix(lp1.name + ":" + lp2.name);
            }
            else
            {
                lname = gm.addprefix(lname);
            }
            if (linkdict.ContainsKey(lname))
            {
                var msg = "AddLink: Duplicate Link name:" + lname;
                Debug.LogWarning(msg);
                if (exceptionOnDuplicate)
                {
                    throw new UnityException(msg);
                }
                else
                {
                    return null;
                }
            }
            linknamelist.Add(lname);
            var lnk = new LcLink(this, lname, lp1, lp2, usetype);
            linkdict.Add(lname, lnk);
            //lklistlist.Add(lnk);
            return (lnk);
        }
        public LcLink AddLinkByNodeName(string lp1name, string lp2name, string lname = "")
        {
            return AddLinkByNodeName(lp1name, lp2name, curUseType, lname);
        }
        Tuple<string,bool> ResolveNodeName(string lpname)
        {
            bool doLateLink = false;
            var newname = lpname;
            if (lpname.StartsWith("reg:"))
            {
                doLateLink = true;
            }
            else if (!nodeExists(newname))
            {
                newname = gm.addprefix(newname);
                if (!nodeExists(newname))
                {
                    doLateLink = true;
                }
            }
            return new Tuple<string, bool>(newname, doLateLink);
        }
        public LcLink AddLinkByNodeName(string lp1name, string lp2name, LinkUse usetype, string lname = "",string comment="",bool inLateLinkingPhase=false)
        {
            bool doll1,doll2;
            (lp1name, doll1) = ResolveNodeName(lp1name);
            (lp2name, doll2) = ResolveNodeName(lp2name);
            var doLateLink = doll1 || doll2;
            if (doLateLink)
            {
                if (!inLateLinkingPhase)
                {
                    if (comment == "")
                    {
                        comment = $"ALBNN: usetype:{usetype} from {lp1name} to {lp2name} linkname:{lname}";
                    }
                    AddLateLink(lp1name, lp2name, usetype, comment);
                }
                regman.curNodeRegion.IncDefStepIdx();
                //Debug.Log($"doll1:{doll1} lp1name:{lp1name}  doll2:{doll2} lp2name:{lp2name}");
                return null;
            }
            var lp1 = nodedict[lp1name];
            var lp2 = nodedict[lp2name];
            if (lname == "")
            {
                lname = gm.addprefix(lp1.name + ":" + lp2.name);
            }
            else
            {
                lname = gm.addprefix(lname);
            }

            if (linkdict.ContainsKey(lname))
            {
                var msg = "AddLinkByNodeName: Duplicate Link name:" + lname;
                Debug.LogWarning(msg);
                if (exceptionOnDuplicate)
                {
                    throw new UnityException(msg);
                }
                else
                {
                    return null;
                }
            }
            linknamelist.Add(lname);
            var lnk = new LcLink(this, lname, lp1, lp2,usetype,comment:comment);
            linkdict.Add(lname, lnk);
            regman.curNodeRegion.IncDefStepIdx();
            //Debug.Log("Added link:" + lname);
            //lklistlist.Add(lnk);
            return (lnk);
        }
        static LcNode anchorpt = null;
        public LcLink LinkTo(string nodename, Vector3 v, LinkUse usetype, string lname = "",string comment="")
        {
            var lp0 = anchorpt;
            if (lp0 == null)
            {
                throw new UnityException("Anchorpt null");
            }
            nodename = gm.addprefix(nodename);
            v = gm.modv(v);
            var lp1 = GetNewNode(nodename, v,usetype,comment);
            if (lname == "")
            {
                lname = lp0.name + ":" + nodename;
            }
            else
            {
                lname = gm.addprefix(lname);
            }
            if (linkdict.ContainsKey(lname))
            {
                var msg = "LinkTo: Duplicate Link name:" + lname;
                Debug.LogWarning(msg);
                if (exceptionOnDuplicate)
                {
                    throw new UnityException(msg);
                }
                else
                {
                    return null;
                }
            }
            linknamelist.Add(lname);

            var lnk = new LcLink(this, lname, lp0, lp1, usetype);
            linkdict.Add(lname, lnk);
            //lklistlist.Add(lnk);
            anchorpt = lp1;
            regman.curNodeRegion.IncDefStepIdx();
            return (lnk);
        }

        public LcLink LinkToPtxz(string nodename, double x, double z, string lname = "",string comment="")
        {
            var xf = (float)x;
            var yf = ranHeight();
            var zf = (float)z;
            return (LinkTo(nodename, new Vector3(xf, yf, zf), curUseType, lname,comment));
        }
        public LcLink LinkToPtll(string nodename, double lat, double lng, string lname = "", string comment = "")
        {
            var (x, z) = lltoxz(lat, lng);
            var xf = (float)x;
            var yf = ranHeight();
            var zf = (float)z;
            return (LinkTo(nodename, new Vector3(xf, yf, zf), curUseType, lname, comment));
        }
        public LcLink LinkToPtxyz(string nodename, double x, double y, double z, string lname = "",string comment="")
        {
            var xf = (float)x;
            var yf = (float)y;
            var zf = (float)z;
            return (LinkTo(nodename, new Vector3(xf, yf, zf), curUseType, lname,comment));
        }
        public LcLink LinkToPtxyz(string newanchor,string nodename, double x, double y, double z, LinkUse usetype, string lname = "", string comment = "")
        {
            var xf = (float)x;
            var yf = (float)y;
            var zf = (float)z;
            if (!IsNodeName(newanchor))
            {
                throw new UnityException("LinkTo: Unknown anchor:" + newanchor);
            }
            anchorpt = nodedict[newanchor];
            return (LinkTo(nodename, new Vector3(xf, yf, zf), usetype, lname, comment));
        }
        public LcLink LinkToPtxyz(string nodename, double x, double y, double z, LinkUse usetype, string lname = "", string comment = "")
        {
            var xf = (float)x;
            var yf = (float)y;
            var zf = (float)z;
            return (LinkTo(nodename, new Vector3(xf, yf, zf), usetype, lname, comment));
        }
        public LcLink LinkTo(string newanchor, string nodename, Vector3 v, string lname = "",string comment="")
        {
            if (!IsNodeName(newanchor))
            {
                throw new UnityException("LinkTo: Unknown anchor:" + newanchor);
            }
            anchorpt = nodedict[newanchor];
            return (LinkTo(nodename, v, curUseType, lname,comment));
        }
        public LcLink NewAnchorLinkTo(string newanchor, string nodename, double x, double y, double z, string lname = "", string comment = "")
        {
            var xf = (float)x;
            var yf = (float)y;
            var zf = (float)z;
            return (LinkTo(newanchor, nodename, new Vector3(xf, yf, zf), lname,comment));
        }
        public LcLink NewAnchorLinkToxz(string newanchor, string nodename, double x, double z, string lname = "",string comment="")
        {
            var xf = (float)x;
            var yf = ranHeight();
            var zf = (float)z;
            return (LinkTo(newanchor, nodename, new Vector3(xf, yf, zf), lname,comment));
        }

        public LcLink LinkToxyz(string newanchor, string nodename, double x, double y, double z, string lname = "", string comment = "")
        {
            var xf = (float)x;
            var yf = (float)y;
            var zf = (float)z;
            return (LinkTo(newanchor, nodename, new Vector3(xf, yf, zf), lname,comment));
        }

        static int crosslinkcount = 0;
        public void AddCrossLink(string lname, float x, float z, string lname1, string lname2,string comment="")
        {
            lname = gm.addprefix(lname);
            lname1 = gm.addprefix(lname1);
            lname2 = gm.addprefix(lname2);
            var pt0 = new Vector3(x, yfloor, z);
            var pt = gm.modv(pt0);
            //Debug.Log("pt0:"+pt0+"  pt:"+pt);
            // find closest filtered link 1 and 2
            //var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //go.transform.position = pt;
            var lnk1 = FindClosestLinkOnLineCloudFilteredOnNamePrefix(lname1, pt);
            if (lnk1 == null)
            {
                lnk1 = FindClosestLinkOnLineCloudFilteredOnNamePrefix(lname1, pt);
                throw new UnityException("AddCrossLink: Could not find filtered link for filter:" + lname1);
            }
            var lnk2 = FindClosestLinkOnLineCloudFilteredOnNamePrefix(lname2, pt);
            if (lnk2 == null)
            {
                throw new UnityException("AddCrossLink: Could not find filtered link for filter:" + lname2);
            }
            //GraphUtil.Log("ACL pt:" + pt+" lnk1:"+lnk1+" lnk2:"+lnk2);
            var pt1 = lnk1.FindClosestPointOnLink(pt);
            var newlname1 = gm.addprefix(lname1 + "x"+ crosslinkcount);
            var newpname1 = gm.addprefix(lname + "-0");
            var node1 = PunchNewNode(lnk1, pt1, newptname: newpname1, newlinkrootname: newlname1, deleteparentlink: true);
            var pt2 = lnk2.FindClosestPointOnLink(pt);
            var newlname2 = gm.addprefix(lname2 + crosslinkcount);
            var newpname2 = gm.addprefix(lname + "-1");
            var node2 = PunchNewNode(lnk2, pt2, newptname: newpname2, newlinkrootname: newlname2, deleteparentlink: true);
            //GraphUtil.Log("ACL pt:" + pt + " pt1:" + pt1 + " pt2:" + pt2);
            AddLink(lname, node1, node2);
            crosslinkcount += 1;
        }
        public void addSpurLink(string lname, float x, float z, string occupantnames = "")
        {
            GraphUtil.Log("Add Spur Link:" + lname);
            var linknodename = "sp-" + lname;
            var node1 = AddNodePtxz(linknodename, x, z);

            var pt = new Vector3(x, yfloor, z);
            pt = gm.modv(pt);
            var filter = gm.addprefix("c");
            var lnk = FindClosestLinkOnLineCloudFilteredOnNamePrefix(filter, pt, deb: false);
            if (lnk == null)
            {
                throw new UnityException("AddRoomLink: Could not find filtered link for filter:" + filter);
            }
            var punchpoint = lnk.FindClosestPointOnLink(pt);
            var node2 = PunchNewNode(lnk, punchpoint, newptname: "cor" + lname, newlinkrootname: lnk.name, deleteparentlink: true);
            AddLink("c" + linknodename, node1, node2);
        }
        public void addRoomLink(string roomnumber, float x, float z, string occupantnames = "")
        {
            GraphUtil.Log("Add Room Link:" + roomnumber);
            var rmname = "rm" + roomnumber;
            var node1 = AddNodePtxz(rmname, x, z,comment:occupantnames);

            var pt = new Vector3(x, yfloor, z);
            pt = gm.modv(pt);
            var filter = gm.addprefix("c");
            var lnk = FindClosestLinkOnLineCloudFilteredOnNamePrefix(filter, pt, deb: false);
            if (lnk == null)
            {
                throw new UnityException("AddRoomLink: Could not find filtered link for filter:" + filter);
            }
            var punchpoint = lnk.FindClosestPointOnLink(pt);
            var node2 = PunchNewNode(lnk, punchpoint, newptname: "cor" + roomnumber, newlinkrootname: lnk.name, deleteparentlink: true);
            AddLink("l" + rmname, node1, node2);
        }
        #endregion construction
        public List<string> FindNodes(string begfilt)
        {
            var nlst = new List<string>();
            foreach( var n in nodenamelist )
            {
                if (n.StartsWith(begfilt))
                {
                    nlst.Add(n);
                }
            }
            return nlst;
        }
        public LcNode GetNode(int n)
        {
            if (n < 0)
            {
                n = nodenamelist.Count + n;
            }
            if (n < 0 || nodenamelist.Count <= n)
            {
                Debug.LogError("GetNode: index out of range:" + n);
                return null;
            }
            var pname = nodenamelist[n];
            return (nodedict[pname]);
        }
        public LcNode GetNode(string nodename)
        {
            nodename = LcNode.NormName(nodename);
            if (!IsNodeName(nodename))
            {
                Debug.LogError("GetNode: No node with this name:" + nodename);
                return null;
                //throw new UnityException("GetNode: No node with this name:" + nodename);
            }
            return (nodedict[nodename]);
        }
        public LcNode GenRanNode()
        {
            int n = nodenamelist.Count;
            var idx = ranman.Next(n);
            var pname = nodenamelist[idx];
            return (nodedict[pname]);
        }
        public bool islinkname(string lname)
        {
            return (linkdict.ContainsKey(lname));
        }

        public bool IsNodeName(string pname)
        {
            return (nodedict.ContainsKey(LcNode.NormName(pname)));
        }
        public StatusMsg ChangeNodeName(string oldnodename, string newnodename)
        {
            if (!IsNodeName(oldnodename)) return new StatusMsg(false, "Old nodename " + oldnodename + " does not exist");
            if (IsNodeName(newnodename)) return new StatusMsg(false, "New nodename " + newnodename + "exists already");
            var node = nodedict[oldnodename];
            node.name = newnodename;
            nodedict.Remove(oldnodename);
            nodedict[newnodename] = node;
            nodenamelist.Remove(oldnodename);
            nodenamelist.Add(newnodename);
            return new StatusMsg(true, "changed name from " + oldnodename + " to " + newnodename);
        }
        public StatusMsg ChangeLinkName(string oldlinkname, string newlinkname)
        {
            if (!islinkname(oldlinkname)) return new StatusMsg(false, "Old nodename " + oldlinkname + " does not exist");
            if (islinkname(newlinkname)) return new StatusMsg(false, "New nodename " + newlinkname + "exists already");
            var link = linkdict[oldlinkname];
            link.name = newlinkname;
            linkdict.Remove(oldlinkname);
            linkdict[newlinkname] = link;
            linknamelist.Remove(oldlinkname);
            linknamelist.Add(newlinkname);
            return new StatusMsg(true, "changed name from " + oldlinkname + " to " + newlinkname);
        }

        List<Tuple<string, string, LinkUse,int,int,string>> latelinks = new List<Tuple<string, string, LinkUse,int,int,string>>();
        public void AddLateLink(string node1, string node2,LinkUse usetype,string comment="")
        {
            int regStepIdx = regman.curNodeRegion.GetCurStepIdx();
            int regid = regman.curNodeRegion.regid;
            var sar = new string[2] { node1, node2 };
            var tup = new Tuple<string, string, LinkUse,int,int,string>(node1, node2, usetype,regStepIdx,regid,comment );
            latelinks.Add(tup);
        }

        public void RealizeLateLinks()
        {
            //Debug.LogWarning("RealizeLateLinks");
            try
            {
                int nllnkcnt = latelinks.Count;
                int nllnkcnt0 = nllnkcnt;
                int maxiter = 2*nllnkcnt + 2;
                var iter = 0;
                int ilnk = 0;
                while (ilnk<nllnkcnt)
                {
                    iter++;
                    if (iter > maxiter)
                    {
                        Debug.LogError($"RealizeLateLinks: probable infinite loop detected i:{ilnk} iter:{iter} maxiter:{maxiter} nllnkcnt0:{nllnkcnt0}");
                        break;
                    }
                    var lnk = latelinks[ilnk];
                    var (name1, name2, usetype, regStepIdx, regid, cmt) = lnk;
                    var oname2 = name2;
                    //Debug.Log($"RealizeLateLinks {i}/{nllnkcnt}  :  {name1} to {name2}  {usetype} regStepIdx:{regStepIdx}");
                    if (name2.StartsWith("reg:"))
                    {
                        var regname = name2.Split(':')[1];
                        //Debug.Log("Linking "+name1+" to region " + regname);
                        var reg = regman.GetRegion(regname);
                        if (reg == null)
                        {
                            Debug.LogWarning($"RealizeLateLinks: bad region name:{regname}  ilnk:{ilnk} iter:{iter} nllnkcnt:{nllnkcnt}");
                            ilnk++;
                            nllnkcnt = latelinks.Count;
                            continue;
                        }
                        var pt = GetNode(name1).pt;
                        var (nlnk, nppt) = FindClosestPointOnLineCloud(pt, reg);
                        //Debug.Log("FindClosestPointOnLineCloud returned nlnk:"+nlnk.name);
                        var nnode = PunchNewNode(nlnk, nppt, deleteparentlink: false);
                        //Debug.Log("PunchNewNode name:"+nnode.name +" at " + nppt.ToString("f1"));
                        name2 = nnode.name;
                    }
                    //Debug.Log($"AddingLink name1:{name1} name2:{name2} oname2:{oname2}");
                    var nllnk = AddLinkByNodeName(name1, name2, usetype,inLateLinkingPhase:true);
                    if (nllnk == null)
                    {
                        Debug.LogWarning($"RealizeLateLinks: failed on {cmt}");
                    }
                    else
                    {
                        nllnk.regionStepIdx = regStepIdx;
                        nllnk.regid = regid;
                        nllnk.node2spec = oname2;
                    }
                    ilnk++;
                    nllnkcnt = latelinks.Count;
                }
            }
            catch(Exception ex)
            {
                Debug.LogError("RealizeLateLinks: Exception caught");
                Debug.LogError(ex.ToString());
            }
        }


        #region linkcloud editing
        static int newnodecount = 0;

        public LcNode PunchNewNode(PathPos pp, string newptname = "", bool deleteparentlink = false,string comment="")
        {
            return (PunchNewNode(pp.weg.link, pp.pt, newptname: newptname, deleteparentlink: deleteparentlink,comment:comment));
        }
        public LcNode PunchNewNode(LcLink lnk, Vector3 pt, string newptname = "", string newlinkrootname = "", bool deleteparentlink = false, bool alwayspunch = false,string comment="")
        {
            if (!alwayspunch)
            {
                // we don't punch a new link point if we are close enough to one of the end points
                // 5e-2 is 5 cm
                if (Vector3.Distance(pt, lnk.node1.pt) < 5e-2)
                {
                    //  GraphUtil.Log("Punched to lp1:"+lnk.lp1.pt);
                    return lnk.node1;
                }
                if (Vector3.Distance(pt, lnk.node2.pt) < 5e-2)
                {
                    //  GraphUtil.Log("Punched to lp2:" + lnk.lp2.pt);
                    return lnk.node2;
                }
            }
            if (newptname == "")
            {
                newptname = "tmp-x-" + newnodecount;
            }
            newnodecount += 1;
//            pt = gm.unmodv(pt);
            //pt = lnk.FindClosestPointOnLink(pt);
            //GraphUtil.Log("Adding point:" + pt);
            var newnode = AddNode(newptname, pt,domodv:false,comment:comment);
            regman.curNodeRegion.IncDefStepIdx();
            var newlinkname0 = "";
            var newlinkname1 = "";
            if (newlinkrootname != "")
            {
                newlinkname0 = newlinkrootname + "0";
                newlinkname1 = newlinkrootname + "1";
            }
            AddLink(newlinkname0, newnode, lnk.node1, lnk.usetype);
            regman.curNodeRegion.IncDefStepIdx();
            //GraphUtil.Log("Adding lnk:" + newlinkname0);
            AddLink(newlinkname1, newnode, lnk.node2, lnk.usetype);
            regman.curNodeRegion.IncDefStepIdx();
            //GraphUtil.Log("Adding lnk:" + newlinkname1);
            if (deleteparentlink)
            {
                //GraphUtil.Log("Deleting lnk:" + lnk.name);
                DelLink(lnk.name);
            }
            return (newnode);
        }
        public List<LcNode> checkForNodeMovement()
        {
            var movedNodes = new List<LcNode>();
            var nodes = GetLcNodes();
            foreach (var node in nodes)
            {
                if (node.WasMoved())
                {
                    movedNodes.Add(node);
                }
            }
            //Debug.Log("checkForNodeMovement - nmoved:" + movedNodes.Count);
            return movedNodes;
        }
        public LcNode finishStretchMovement(string nodename,Vector3 oposition,LinkUse usetype,int regid)
        {
            Debug.Log("finishStretchMovement");
            nodename = LcNode.NormName(nodename);
            var lnode = GetNode(nodename);
            var closeest = FindClosestNodeToNodeGo(lnode);
            if (Vector3.Distance(closeest.go.transform.position, lnode.go.transform.position) > 0.2f)
            {
                var newname = genuniquenodename();
                var newnode = GetNewNode(newname, lnode.go.transform.position,lnode.usetype);
                lnode.pt = oposition;
                lnode.go.transform.position = oposition;
                var lnk = AddLink("", lnode, newnode,usetype);
                lnk.regid = regid;
                return newnode;
            }
            else
            {
                var newlinkname = genuniquelinkname();
                var lnk = AddLink(newlinkname, lnode, closeest,usetype);
                lnk.regid = regid;
                return null;
            }
        }
        public void syncNodeMovement(List<LcNode> movedNodes,bool lockYval)
        {
            movedNodes.ForEach(x => x.SyncToGo(lockYval));
        }
        public void DelLink(string lname)
        {
            lname = LcLink.NormName(lname);
            if (!linkdict.ContainsKey(lname))
            {
                throw new UnityException("DelLink: Unknown Link name:" + lname);
            }
            var lnk = linkdict[lname];
            lnk.UnlinkLink();
            //lklistlist.Remove(lnk);
            linkdict.Remove(lname);
            linknamelist.Remove(lname);
        }
        public void SplitLink(string lname)
        {
            lname = LcLink.NormName(lname);
            if (!linkdict.ContainsKey(lname))
            {
                throw new UnityException("SplitLink: Unknown Link name:" + lname);
            }
            var lnk = linkdict[lname];
            var npt = (lnk.node1.pt + lnk.node2.pt) * 0.5f;
            var nnodename = genuniquenodename();
            PunchNewNode(lnk, npt, newptname: nnodename, newlinkrootname: lnk.name, deleteparentlink: true, alwayspunch: true);
        }
        public LcNode StartStretchNode(string nodename)
        {
            nodename = LcNode.NormName(nodename);
            if (!nodedict.ContainsKey(nodename))
            {
                throw new UnityException("StartStretchNode: Unknown node name:" + nodename);
            }

            var node = GetNode(nodename);
            return node;
        }
        public void DelNode(string nname)
        {
            if (!nodedict.ContainsKey(nname))
            {
                throw new UnityException("DelNodeL Unknown Node name:" + nname);
            }
            var pt = nodedict[nname];
            // first find the names of all connected links
            if (pt.wegtos != null)
            {
                var linknamelist = new HashSet<string>();
                foreach (var w in pt.wegtos)
                {
                    linknamelist.Add(w.link.name);
                }
                // now delete them all
                foreach (var lname in linknamelist)
                {
                    DelLink(lname);
                }
            }
            // now remove the point
            nodedict.Remove(nname);
            nodenamelist.Remove(nname);
        }
        #endregion
        public List<string> linkpoints()
        {
            return (nodenamelist);
        }

        public void VerfiyNodeExists(string callname, string ptname)
        {
            if (!nodedict.ContainsKey(ptname))
            {
                throw new UnityException("verifyPointExists: Node '" + ptname + "' not defined in " + callname);
            }
        }
        public bool nodeExists(string ptname)
        {
            return nodedict.ContainsKey(ptname);
        }
        public LcLink GetLink(string name)
        {
            if (islinkname(name))
            {
                var lnk = linkdict[name];
                return (lnk);
            }
            return (null);
        }
        public LcNode FindClosestNode(Vector3 pt)
        {
            float mindist = 9e30f;
            LcNode minnode = null;
            foreach (var nname in nodenamelist)
            {
                var node = GetNode(nname);
                var dist = Vector3.Distance(pt, node.pt);
                if (dist < mindist)
                {
                    mindist = dist;
                    minnode = node;
                }
            }
            return (minnode);
        }
        public LcNode FindClosestNodeToNodeGo(LcNode targetnode)
        {
            float mindist = 9e30f;
            LcNode minnode = null;
            var gopt = targetnode.go.transform.position;
            foreach (var nname in nodenamelist)
            {
                if (nname != targetnode.name)
                {
                    var node = GetNode(nname);
                    var dist = Vector3.Distance(gopt, node.pt);
                    if (dist < mindist)
                    {
                        mindist = dist;
                        minnode = node;
                    }
                }
            }
            return (minnode);
        }
        public Tuple<LcLink,Vector3> FindClosestPointOnLineCloud(Vector3 pt,List<LcLink> links)
        {
            var rpt = Vector3.zero;
            LcLink rlink = null;
            float mindist = 9e30f;
            foreach (var lnk in links)
            {
                var npt = lnk.FindClosestPointOnLink(pt);
                var dist = Vector3.Distance(pt, npt);
                if (dist < mindist)
                {
                    rpt = npt;
                    mindist = dist;
                    rlink = lnk;
                }
            }
            return new Tuple<LcLink,Vector3>(rlink,rpt);
        }
        public Tuple<LcLink, Vector3> FindClosestPointOnLineCloudTuple(Vector3 pt)
        {
            var links = linkdict.Values.ToList();
            return FindClosestPointOnLineCloud(pt, links);
        }
        public (LcLink link, Vector3 pt) FindClosestPointOnLineCloud(Vector3 pt)
        {
            var links = linkdict.Values.ToList();
            var v1 = FindClosestPointOnLineCloud(pt, links);
            return (v1.Item1, v1.Item2);
        }
        public Tuple<LcLink, Vector3> FindClosestPointOnLineCloud(Vector3 pt,NodeRegion region)
        {
            var links = GetLinksInRegion(region.regid);
            return FindClosestPointOnLineCloud(pt, links);
        }
        public LcLink FindClosestLinkOnLineCloudFilteredOnNamePrefix(string filter, Vector3 pt, bool deb = false)
        {
            if (deb)
            {
                Debug.Log("FCLOLCF filter:" + filter + " pt:" + pt);
            }
            var rpt = Vector3.zero;
            int nflthit = 0;
            LcLink rlnk = null;
            float mindist = 9e30f;
            foreach (var lnkname in linknamelist)
            {
                var lnk = GetLink(lnkname);
                if (filter == "" || lnk.name.StartsWith(filter))
                {
                    nflthit++;
                    var npt = lnk.FindClosestPointOnLink(pt);
                    var dist = Vector3.Distance(pt, npt);
                    if (dist < mindist)
                    {
                        rlnk = lnk;
                        rpt = npt;
                        mindist = dist;
                        if (deb)
                        {
                            var lamb = lnk.FindClosestLamb(pt);
                            Debug.Log("    lnk:" + lnk.name + " npt:" + npt + " dist:" + dist + " lamb:" + lamb);
                            Debug.Log("    lnk.p1:" + lnk.node1.pt + " p2:" + lnk.node2.pt);
                        }
                    }
                }
            }
            if (deb)
            {
                Debug.Log("FCLOLCF found:" + rlnk.name+" from "+nflthit+" filter hits");
            }
            return rlnk;
        }
        public LinkedList<string> GetKeywordKeys()
        {
            var l = new LinkedList<string>(nodekeywords.Keys);
            return (l);
        }
        public LinkedList<string> GetKeywordValues()
        {
            var l = new LinkedList<string>(nodekeywords.Values);
            return (l);
        }
        public string GetKeywordValue(string key)
        {
            if (!nodekeywords.ContainsKey(key)) return ("");
            return (nodekeywords[key]);
        }
        #region pathfinding
        LcNode findminfscore(HashSet<LcNode> openset)
        {
            var minf = 99e30f;
            LcNode minnode = null;
            foreach (var node in openset)
            {
                if (node.fScore < minf)
                {
                    minf = node.fScore;
                    minnode = node;
                }
            }
            if (minnode == null)
            {
                Debug.LogWarning("minnode is null in findminfscore");
            }
            return (minnode);
        }
        Path reconstructPath(LcNode spt, LcNode ept)
        {
            var cflist = new LinkedList<LcNode>();
            cflist.AddLast(ept);
            var curpt = ept;
            int nloop = 0;
            while (curpt != spt)
            {
                nloop = nloop + 1;
                if (nloop > (4 * nodenamelist.Count))
                {
                    GraphUtil.Log("Iter count exceeded 1 in reconstructPath");
                    return (null);
                }

                cflist.AddLast(curpt);
                curpt = curpt.cameFrom;
            }
            cflist.AddLast(curpt);
            nloop = 0;
            var path = new Path(spt);
            var cur = cflist.Last;
            while (cur != null)
            {
                nloop = nloop + 1;
                if (nloop > (4 * nodenamelist.Count))
                {
                    GraphUtil.Log("Iter count exceeded 2 in reconstructPath");
                    return (null);
                }
                var next = cur.Previous;
                if (next != null)
                {
                    var nxpt = next.Value.pt;
                    foreach (var w in cur.Value.wegtos)
                    {
                        if (nxpt == w.toNode.pt)
                        {
                            path.AddWaypt(w);
                            continue;
                        }
                    }
                }
                cur = next;
            }
            path.Finish();
            return (path);
        }
        public Path GenAstar(string sptname, string eptname,LcCapType captype)
        {
            VerfiyNodeExists("GenAstar", sptname);
            VerfiyNodeExists("GenAstar", eptname);
            if (sptname == eptname)
            {
                Debug.LogError("GenAstar called with start and end nodes being the same");
                return null;
            }

            var spt = nodedict[sptname];
            var ept = nodedict[eptname];


            foreach (var ptname in nodenamelist)
            {
                var node = nodedict[ptname];
                node.AstarInit();
            }

            var closedSet = new HashSet<LcNode>();
            var openSet = new HashSet<LcNode>();
            openSet.Add(spt);
            spt.gScore = 0;
            spt.fScore = spt.heuristic_cost_estimate(ept);

            int nloop = 0;

            while (openSet.Count > 0)
            {
                //   GraphUtil.Log("openSet count:" + openSet.Count + " closedSet count:" + closedSet.Count);
                nloop = nloop + 1;
                if (nloop > (4 * nodenamelist.Count))
                {
                    GraphUtil.Log("Iter count exceeded in genAstar");
                    return (null);
                }

                var current = findminfscore(openSet);
                if (current==null)
                {
                    Debug.LogWarning("current null in genAstar - exiting");
                    return null;
                }
                if (current == ept)
                {
                    return (reconstructPath(spt, ept)); // the correct exit
                }
                openSet.Remove(current);
                closedSet.Add(current);

                if (current.wegtos == null)
                {
                    Debug.LogWarning("current.wegtos null in genAstar - exiting");
                    return null;
                }
                foreach (var w in current.wegtos)
                {
                    if (!LcLink.CanDoCapFromUse(captype,w.link.usetype)) continue;
                    //if (!w.link.CanDo(captype)) continue;
                    if (closedSet.Contains(w.toNode)) continue; // already evaluated

                    if (!openSet.Contains(w.toNode))            // discover a new node 
                    {
                        openSet.Add(w.toNode);
                    }

                    var tentative_gScore = current.gScore + Vector3.Distance(current.pt, w.toNode.pt);
                    if (tentative_gScore > w.toNode.gScore) continue; // this is not a better path

                    w.toNode.cameFrom = current;
                    w.toNode.gScore = tentative_gScore;
                    w.toNode.fScore = w.toNode.gScore + ept.heuristic_cost_estimate(w.toNode);
                }
            }
            Debug.LogWarning("openset null in genAstar - exiting");
            return (null);
        }
        public Path GenRanPath(string sptname, int npts)
        {
            VerfiyNodeExists("GenRanPath", sptname);
            var pt = nodedict[sptname];
            var path = new Path(pt);
            var rnd = new System.Random();
            for (int i = 0; i < npts; i++)
            {
                var wegar = pt.wegtos.ToArray();
                var w = wegar[rnd.Next(wegar.Length)];
                path.AddWaypt(w);
                pt = w.toNode;
            }
            path.Finish();
            return (path);
        }
        #endregion
    }
}

