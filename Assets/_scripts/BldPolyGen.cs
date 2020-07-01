using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aiskwk.Dataframe;
using Aiskwk.Map;
using UnityEngine.UIElements;
using System.Text;
using System.Linq;
using UnityEngine.AI;
using System.Data.Common;
using System;

public class Bldspec
{
    public string name;
    public string bldtyp;
    public string wid;
    public float height;
    public int levels;
    public double lat;
    public double lng;
    public float x;
    public float z;
    public float bscale;
    public Vector3 loc;
    List<Vector3> boutline;
    public Bldspec(string name, string bldtyp, string wid, float height = 0, int levels = 0, float bscale = 1)
    {
        if (height == 0 && levels == 0)
        {
            height = 5;
            levels = 1;
        }
        else if (height == 0)
        {
            height = levels * 5;
        }
        else if (levels == 0)
        {
            levels = 1;
        }
        this.name = name;
        this.bldtyp = bldtyp.ToLower();
        this.bscale = bscale;
        this.wid = wid;
        this.height = height;
        this.levels = levels;
    }
    public void AddPos(double lat, double lng, float x, float z)
    {
        this.lat = lat;
        this.lng = lng;
        this.x = x * bscale;
        this.z = z * bscale;
        this.loc = new Vector3(this.x, 0, -this.z);
    }
    public void SetOutline(List<Vector3> outline)
    {
        boutline = new List<Vector3>();
        foreach (var pt in outline)
        {
            var npt = new Vector3(pt.x * bscale, pt.y * bscale, pt.z * bscale);
            boutline.Add(npt);
        }
    }
    public List<Vector3> GetOutline()
    {
        var rv = new List<Vector3>(boutline);
        return rv;
    }

    static Dictionary<string, string> clrcvt = new Dictionary<string, string>()
        {
            { "construction","red" },
            { "commercial","darkblue" },
            { "yes","black" },
            { "osmbld","black" },
            { "bld","darkgreen" },
            { "house","blue" },
            { "parking","darkred" },
            { "garage","darkred" },
            { "carport","darkred" },
            { "apartments","purple" },
            { "appartments","indigo" },
            { "terrace","green" },
            { "office","lightblue" },
            { "shed","green" },
            { "hotel","pink" },
            { "retail","gray" },
            { "school","orange" },
            { "roof","green" },
            { "church","purple" },

        };
    public string GetColor()
    {
        if (clrcvt.ContainsKey(bldtyp))
        {
            return clrcvt[bldtyp];
        }
        return "gray";
    }
}





public class BldPolyGen
{
    public GrafPolyGen pg;

    public BldPolyGen()
    {
        ReInit();
    }

    public void ReInit()
    {
        pg = new GrafPolyGen();
    }

    List<Vector3> ExtractNodes(string wid, string name, SimpleDf linksdf, SimpleDf nodedf, Dictionary<string, int> nodedict)
    {
        var rv = new List<Vector3>();
        var osm_nid_1 = linksdf.GetStringCol("osm_nid_1");
        //var osm_nid_2 = linksdf.GetStringCol("osm_nid_2");
        var xvals = nodedf.GetFloatCol("x");
        var zvals = nodedf.GetFloatCol("z");
        //var latvals = nodedf.GetDoubleCol("lat");
        //var lngvals = nodedf.GetDoubleCol("lng");
        //var on1 = "";
        //var on2 = "";
        for (int i = 0; i < linksdf.Nrow(); i++)
        {
            var n1 = osm_nid_1[i];
            if (!nodedict.ContainsKey(n1))
            {
                Debug.LogError($"Bld:{name} - wid:{wid} - Unknown node 1 {osm_nid_1}");
                continue;
            }
            var n1idx = nodedict[n1];
            var x = xvals[n1idx];
            var z = zvals[n1idx];
            var pt1 = new Vector3(x, 0, z);

            //var n2 = osm_nid_2[i];
            //if (!nodedict.ContainsKey(n2))
            //{
            //    Debug.LogError($"Bld:{name} - wid:{wid} - Unknown node 1 {osm_nid_1}");
            //    continue;
            //}
            //var n2idx = nodedict[n2];
            //var pt2 = new Vector3(xvals[n2idx], 0, zvals[n2idx]);

            rv.Add(pt1);
        }
        return rv;
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


    (SimpleDf ways, SimpleDf links, SimpleDf nodes) GetDfsFromFiles(string areaprefix, string dname = "")
    {
        if (dname == "")
        {
            dname = "d:/pyprj/overpy/output/";
        }
        var fnameways = $"{dname}{areaprefix}_ways.csv";
        var fnamenodes = $"{dname}{areaprefix}_nodes.csv";
        var fnamelinks = $"{dname}{areaprefix}_links.csv";

        var dfways = new SimpleDf(areaprefix + "_ways");
        dfways.ReadCsv(fnameways);
        Debug.Log($"Read {dfways.Nrow()} ways from {fnameways}");

        var dflinks = new SimpleDf(areaprefix + "links");
        dflinks.ReadCsv(fnamelinks);
        Debug.Log($"Read {dflinks.Nrow()} links from {fnamelinks}");

        var dfnodes = new SimpleDf(areaprefix + "nodes");
        dfnodes.ReadCsv(fnamenodes);
        Debug.Log($"Read {dfnodes.Nrow()} links from {fnamenodes}");

        return (dfways, dflinks, dfnodes);
    }

    (SimpleDf ways, SimpleDf links, SimpleDf nodes) GetDfsFromResources(string areaprefix, string dname = "")
    {
        if (dname == "")
        {
            dname = "osmcsv/";
        }

        SimpleDf dfways;
        {
            var fnameways = $"{dname}{areaprefix}_ways.csv";
            dfways = new SimpleDf(areaprefix + "_ways");
            var wayslist = ReadResource(fnameways);
            dfways.ReadCsv(wayslist);
            //Debug.Log($"Read {dfways.Nrow()} ways from {fnameways}");
        }

        SimpleDf dflinks;
        {
            var fnamelinks = $"{dname}{areaprefix}_links.csv";
            dflinks = new SimpleDf(areaprefix + "links");
            var linkslist = ReadResource(fnamelinks);
            dflinks.ReadCsv(linkslist);
            //Debug.Log($"Read {dflinks.Nrow()} links from {fnamelinks}");
        }

        SimpleDf dfnodes;
        {
            var fnamenodes = $"{dname}{areaprefix}_nodes.csv";
            dfnodes = new SimpleDf(areaprefix + "nodes");
            var nodeslist = ReadResource(fnamenodes);
            dfnodes.ReadCsv(nodeslist);
            //Debug.Log($"Read {dfnodes.Nrow()} links from {fnamenodes}");
        }

        return (dfways, dflinks, dfnodes);
    }


    public List<Bldspec> LoadBuildingsFromCsv(string areaprefix, string dname = "", float ptscale = 1)
    {
        var sw = new Aiskwk.Dataframe.StopWatch();
        sw.Start();
        var rv = new List<Bldspec>();

        //var (dfways, dflinks, dfnodes) = GetDfsFromFiles(areaprefix, dname);
        var (dfways, dflinks, dfnodes) = GetDfsFromResources(areaprefix, dname);

        var nid = dfnodes.GetStringCol("osm_nid");
        var nodedict = new Dictionary<string, int>();
        for (int idx = 0; idx < dfnodes.Nrow(); idx++)
        {
            nodedict[nid[idx]] = idx;
        }
        var blddf = SimpleDf.SubsetOnStringColVal(dfways, "osmtype", "building");
        Debug.Log($"Found {blddf.Nrow()} buildings in dfways");
        var bldtyp = blddf.GetStringCol("osmsubtype");
        var bldwids = blddf.GetStringCol("osm_wid");
        var bldnames = blddf.GetStringCol("name");
        var bldheights = blddf.GetFloatCol("height");
        var bldlevels = blddf.GetIntCol("levels");
        var bldlat = blddf.GetDoubleCol("lat");
        var bldlng = blddf.GetDoubleCol("lng");
        var bldz = blddf.GetFloatCol("z");
        var bldx = blddf.GetIntCol("x");
        int i = 0;
        foreach (var bwid in bldwids)
        {
            var bname = bldnames[i];
            var btype = bldtyp[i];
            var bheit = bldheights[i];
            var blevs = bldlevels[i];
            var bllat = (bldlat == null ? 0 : bldlat[i]);
            var bllng = (bldlng == null ? 0 : bldlng[i]);
            var blz = (bldz == null ? 0 : bldz[i]);
            var blx = (bldx == null ? 0 : bldx[i]);
            var bldwalldf = SimpleDf.SubsetOnStringColVal(dflinks, "osm_wid", bwid);
            //Debug.Log($"Found {bldwalldf.Nrow()} links for bld wid:{bwid} name:{bname}");
            var bs = new Bldspec(bname, btype, bwid, bheit, blevs, bscale: ptscale);
            bs.AddPos(bllat, bllng, blx, blz);
            var nodeoutline = ExtractNodes(bname, bwid, bldwalldf, dfnodes, nodedict);
            var area = GrafPolyGen.CalcAreaWithYup(nodeoutline);
            if (area < 0)
            {
                nodeoutline.Reverse();
            }
            bs.SetOutline(nodeoutline);
            rv.Add(bs);
            i++;
        }
        var nbld = i;
        sw.Stop();
        Debug.Log($"{areaprefix} Loading and generating {nbld} buildings took {sw.ElapSecs()} secs");
        return rv;
    }
    public void Test4(GameObject parent, float ptscale = 1)
    {
        // debug one layer only
        //GenObj(ObjForm.circle, dowalls:false,doceil:true,dofloor:false,dbOutline:false);
        //GenObj(ObjForm.circle,onesided:false);

        var v = 5;
        var levs = 12;
        var height = 48;
        height = 9;
        height = 0;
        levs = 3;
        ReInit();
        //var l1 = new Vector3(v, 0, v);
        //GenFixedFormBld(parent, ObjForm.cross, "b11", l1, height, levs, "dr", ptscale: ptscale);

        //ReInit();
        //var l2 = new Vector3(-v, 0, v);
        //GenFixedFormBld(parent, ObjForm.star, "b01", l2, height, levs, "dg", ptscale: ptscale);

        ReInit();
        var l3 = new Vector3(v, 0, -v);
        //l3 = Vector3.zero;
        GenFixedFormBld(parent, ObjForm.circle, "b10", l3, height, levs, "db", ptscale: ptscale);

        //ReInit();
        //var l4 = new Vector3(-v, 0, -v);
        //GenFixedFormBld(parent, ObjForm.cross, "b00", l4, height, levs, "dy", ptscale: ptscale);
    }




    public void GenFixedFormBld(GameObject parent, ObjForm objform, string bldname, Vector3 loc, float height, int levels, string clr, float ptscale = 1)
    {
        GenOutline(objform, loc);
        var dowalls = false;
        var dofloors = false;
        var doroof = true;
        pg.GenBld(parent, bldname, height, levels, clr, alf: 1f,dowalls:dowalls,dofloors: dofloors,doroof:doroof, ptscale: ptscale);
    }
    public void GenBld(GameObject parent, Bldspec bs, bool plotTesselation = false, float ptscale = 1, GetHeightDel ghd = null)
    {
        pg.SetOutline(bs.GetOutline());
        var clr = bs.GetColor();
        var bldname = $"{bs.name} ({bs.wid})";
        var dowalls = true;
        var dofloors = true;
        var doroof = true;
        if (plotTesselation)
        {
            dowalls = false;
            dofloors = false;
        }
        pg.GenBld(parent, bldname, bs.height, bs.levels, clr, alf: 0.5f, dowalls: dowalls, dofloors: dofloors, doroof: doroof, plotTesselation: plotTesselation, ptscale: ptscale, ghd: ghd);
    }

    public void LoadRegion(GameObject parent, string regionspec, float ptscale = 1)
    {
        var sw = new Aiskwk.Dataframe.StopWatch();
        var blds = new List<Bldspec>();
        var sar = regionspec.Split(',');
        foreach (var s in sar)
        {
            blds.AddRange(LoadBuildingsFromCsv(s, ptscale: ptscale));
        }
        foreach (var bs in blds)
        {
            //GenFixedFormBld(ObjForm.cross, bs.name, bs.loc, bs.height,bs.levels,"db");
            GenBld(parent, bs, ptscale: ptscale);
        }
        sw.Stop();
        Debug.Log($"Generation of {regionspec} took {sw.ElapSecs()} secs");
    }

    public void LoadRegionOneBld(GameObject parent, string regionspec, string bldwid, float ptscale = 1)
    {
        var sw = new Aiskwk.Dataframe.StopWatch();
        var blds = new List<Bldspec>();
        var sar = regionspec.Split(',');
        foreach (var s in sar)
        {
            blds.AddRange(LoadBuildingsFromCsv(s, ptscale: ptscale));
        }
        foreach (var bs in blds)
        {
            if (bs.wid == bldwid)
            {
                //GenFixedFormBld(ObjForm.cross, bs.name, bs.loc, bs.height,bs.levels,"db");
                GenBld(parent, bs, plotTesselation: true, ptscale: ptscale);
            }
        }
        sw.Stop();
        Debug.Log($"Generation of {regionspec} took {sw.ElapSecs()} secs");
    }

    void GenOutline(ObjForm objform, Vector3 loc)
    {
        var radiusinnner = 0.5f;
        var radius = 5f;
        switch (objform)
        {
            default:
            case ObjForm.star:
                {
                    pg.GenStarOutline(loc, 8, radiusinnner, radius);
                    break;
                }
            case ObjForm.cross:
                {
                    pg.GenCrossOutline(loc, radius);
                    break;
                }
            case ObjForm.circle:
                {
                    pg.GenCylinderOutline(loc, 10, radius);
                    break;
                }
        }
    }

    public enum ObjForm { star, cross, circle }
    void GenObj(GameObject parent, ObjForm objform, bool dowalls = true, bool doroof = true, bool dofloor = true, bool plotTesselation = false, bool onesided = false)
    {
        var alf = 0.5f;
        //alf = 1;
        GenOutline(objform, Vector3.zero);
        if (dowalls)
        {
            pg.SetGenForm(PolyGenForm.wallsmesh);
            var walgo = pg.GenMesh("walls", height: 2, clr: "blue", alf: alf, plotTesselation: plotTesselation, onesided: onesided);
            walgo.transform.parent = parent.transform;
        }
        if (doroof)
        {
            pg.SetGenForm(PolyGenForm.tesselate);
            var rufgo = pg.GenMesh("ceiling", height: 2, clr: "blue", alf: alf, plotTesselation: plotTesselation, onesided: onesided);
            rufgo.transform.parent = parent.transform;
        }
        if (dofloor)
        {
            pg.SetGenForm(PolyGenForm.tesselate);
            var fl1go = pg.GenMesh("floor1", height: 1, clr: "blue", alf: alf, plotTesselation: plotTesselation, onesided: onesided);
            fl1go.transform.parent = parent.transform;
        }
    }
}
