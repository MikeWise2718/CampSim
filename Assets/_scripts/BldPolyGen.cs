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

public class OsmBldSpec
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
    public GameObject bgo;

    public OsmBldSpec(string name, string bldtyp, string wid, float height = 0, int levels = 0, float bscale = 1)
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
        this.bgo = null;
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
            { "construction","brown" },
            { "commercial","darkblue" },
            { "industrial","brown" },
            { "data_center","lightblue" },
            { "train_station","indigo" },
            { "transportation","indigo" },
            { "public","purple" },
            { "civic","purple" },
            { "government","purple" },
            { "hospital","red" },
            { "yes","lightblue" },
            { "osmbld","black" },
            { "bld","darkgreen" },
            { "house","blue" },
            { "manufactured_home","blue" },
            { "semidetached_house","blue" },
            { "detached","darkblue" },
            { "demolished","black" },
            { "razed building","black" },
            { "ruins","black" },
            { "bunker","black" },
            { "parking","darkred" },
            { "garage","darkred" },
            { "garages","darkred" },
            { "carport","darkred" },
            { "carports","darkred" },
            { "mixed","cyan" },
            { "bridge","cyan" },
            { "gangway","cyan" },
            { "apartments","purple" },
            { "appartments","indigo" },
            { "terrace","green" },
            { "office","lightblue" },
            { "shed","green" },
            { "barn","darkred" },
            { "cabin","green" },
            { "hut","green" },
            { "greenhouse","green" },
            { "hotel","darkred" },
            { "pavilion","darkred" },
            { "retail","lightgreen" },
            { "supermarket","lightgreen" },
            { "kindergarten","orange" },
            { "school","orange" },
            { "university","orange" },
            { "college","orange" },
            { "roof","green" },
            { "dome","pink" },
            { "leisure_centre","pink" },
            { "sports_hall","pink" },
            { "sports_centre","pink" },
            { "sports_center","pink" },
            { "theater","pink" },
            { "theatre","pink" },
            { "toilets","pink" },
            { "toilet","pink" },
            { "church","purple" },
            { "cathedral","purple" },

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
        int n1idx;
        for (int i = 0; i < linksdf.Nrow(); i++)
        {
            var n1 = osm_nid_1[i];
            if (nodedict != null)
            {
                if (!nodedict.ContainsKey(n1))
                {
                    Debug.LogError($"Bld:{name} - wid:{wid} - Unknown node 1 {osm_nid_1}");
                    continue;
                }
                n1idx = nodedict[n1];
            }
            else
            {
                n1idx = nodedf.GetColIdx("osm_nid",n1);
            }
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
        if (asset==null)
        {
            Debug.LogError($"Could not load TextAsset {pathname}");
            return null;
        }
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


    //(SimpleDf ways, SimpleDf links, SimpleDf nodes) GetDfsFromFiles(string areaprefix, string dname = "")
    //{
    //    if (dname == "")
    //    {
    //        dname = "d:/pyprj/overpy/output/";
    //    }
    //    var fnameways = $"{dname}{areaprefix}_ways.csv";
    //    var fnamenodes = $"{dname}{areaprefix}_nodes.csv";
    //    var fnamelinks = $"{dname}{areaprefix}_links.csv";

    //    var dfways = new SimpleDf(areaprefix + "_ways");
    //    dfways.ReadCsv(fnameways);
    //    Debug.Log($"Read {dfways.Nrow()} ways from {fnameways}");

    //    var dflinks = new SimpleDf(areaprefix + "links");
    //    dflinks.ReadCsv(fnamelinks);
    //    Debug.Log($"Read {dflinks.Nrow()} links from {fnamelinks}");

    //    var dfnodes = new SimpleDf(areaprefix + "nodes");
    //    dfnodes.ReadCsv(fnamenodes);
    //    Debug.Log($"Read {dfnodes.Nrow()} links from {fnamenodes}");

    //    return (dfways, dflinks, dfnodes);
    //}

    public (SimpleDf dfways1, SimpleDf dflinks1, SimpleDf dfnodes1) GetDfsFromResources(string areaprefix, string dname = "", LatLongMap llm = null)
    {
        if (dname == "")
        {
            dname = "osmcsv/";
        }

        var dfways1 = new SimpleDf();
        {
            var fnameways = $"{dname}{areaprefix}_ways.csv";
            dfways1 = new SimpleDf(areaprefix + "_ways");
            var wayslist = ReadResource(fnameways);
            if (wayslist != null)
            {
                dfways1.ReadCsv(wayslist);
            }
            //Debug.Log($"Read {dfways.Nrow()} ways from {fnameways}");
        }

        var dflinks1 = new SimpleDf();
        {
            var fnamelinks = $"{dname}{areaprefix}_links.csv";
            dflinks1 = new SimpleDf(areaprefix + "links");
            var linkslist = ReadResource(fnamelinks);
            if (linkslist != null)
            {
                dflinks1.ReadCsv(linkslist);
            }
            //Debug.Log($"Read {dflinks.Nrow()} links from {fnamelinks}");
        }

        var dfnodes1 = new SimpleDf();
        {
            var fnamenodes = $"{dname}{areaprefix}_nodes.csv";
            dfnodes1 = new SimpleDf(areaprefix + "nodes");
            var nodeslist = ReadResource(fnamenodes);
            if (nodeslist != null)
            {
                dfnodes1.ReadCsv(nodeslist);
            }
            //Debug.Log($"Read {dfnodes.Nrow()} links from {fnamenodes}");
        }
        if (llm != null)
        {
            ConvertNodeCoords(dfnodes1, llm);
        }
        _dfways = dfways1;
        _dfnodes = dfnodes1;
        _dflinks = dflinks1;
        return (dfways1, dflinks1, dfnodes1);
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
        for (int i=0; i<nrow; i++)
        {
            var lat = latcol[i];
            var lng = lngcol[i];
            var xv = xmap.Map(lng,lat);
            var zv = zmap.Map(lng,lat);
            var ox = nodes.GetVal(ixcol, i,0.0);
            var oz = nodes.GetVal(izcol, i,0.0);
            nodes.SetDoubVal(ixcol, i, xv);
            nodes.SetDoubVal(izcol, i, zv);
        }
    }

    SimpleDf _dfways = null;
    SimpleDf _dflinks = null;
    SimpleDf _dfnodes = null;

    public void LoadSdfs(string areaprefix, string dname = "")
    {
        GetDfsFromResources(areaprefix, dname);
    }


    //public List<Bldspec> LoadOsmBuildings(float ptscale = 1, LatLongMap llm = null)
    //{
    //    if (_dfways==null)
    //    {
    //        Debug.LogError("LoadOsmBuildingsFromSdfs not initialized");
    //    }
    //    var rv = LoadOsmBuildingsFromSdfs(_dfways,_dfnodes,_dflinks,ptscale: ptscale, llm: llm);
    //    return rv;
    //}


    public List<OsmBldSpec> LoadOsmBuildingsFromSdfs(SimpleDf dfways, SimpleDf dfnodes, SimpleDf dflinks, float ptscale = 1, LatLongMap llm = null, bool usenodedict = false)
    {
        var sw = new Aiskwk.Dataframe.StopWatch();
        sw.Start();
        var rv = new List<OsmBldSpec>();


        if (llm!=null)
        {
            ConvertNodeCoords(dfnodes, llm);
        }

        var nid = dfnodes.GetStringCol("osm_nid");
        Dictionary<string, int> nodedict = null;
        if (usenodedict)
        {
            new Dictionary<string, int>();
            for (int idx = 0; idx < dfnodes.Nrow(); idx++)
            {
                nodedict[nid[idx]] = idx;
            }
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
            var bs = new OsmBldSpec(bname, btype, bwid, bheit, blevs, bscale: ptscale);
            bs.AddPos(bllat, bllng, blx, blz);
            //var nodeoutline = ExtractNodes(bname, bwid, bldwalldf, dfnodes, nodedict);
            var nodeoutline = ExtractNodes(bname, bwid, bldwalldf, dfnodes, null);
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
        Debug.Log($"LoadBuilding from simpledfs generating {nbld} buildings took {sw.ElapSecs()} secs");
        return rv;
    }

    public Vector3 RaiseHeight(Vector3 iv)
    {
        var rv = new Vector3(iv.x, 20, iv.z);
        return rv;
    }
    public void Test4(GameObject parent, float ptscale = 1, PolyGenVekMapDel pgvd = null)
    {
        // debug one layer only
        //GenObj(ObjForm.circle, dowalls:false,doceil:true,dofloor:false,dbOutline:false);
        //GenObj(ObjForm.circle,onesided:false);
        var v = 5;
        var levs = 12;
        var height = 48;
        height = 9;
        levs = 3;

        ReInit();
        var l1 = new Vector3(v, 0, v);
        GenFixedFormBld(parent, ObjForm.circle, "b10", l1, height, levs, "db", ptscale: ptscale, pgvd:pgvd );

        //ReInit();
        //var l2 = new Vector3(-v, 0, v);
        //GenFixedFormBld(parent, ObjForm.star, "b01", l2, height, levs, "dg", ptscale: ptscale, pgvd: pgvd);


        //ReInit();
        //var l3 = new Vector3(v, 0, -v);
        //GenFixedFormBld(parent, ObjForm.cross, "b10", l3, height, levs, "dr", ptscale: ptscale, pgvd: pgvd);



        //ReInit();
        //var l4 = new Vector3(-v, 0, -v);
        //GenFixedFormBld(parent, ObjForm.cross, "b00", l4, height, levs, "dy", ptscale: ptscale, pgvd: pgvd);
    }




    public GameObject GenFixedFormBld(GameObject parent, ObjForm objform, string bldname, Vector3 loc, float height, int levels, string clr, float ptscale = 1, PolyGenVekMapDel pgvd = null)
    {
        GenOutline(objform, loc);
        var dowalls = true;
        var dofloors = true;
        var doroof = true;
        var rv = pg.GenBld(parent, bldname, height, levels, clr, alf: 0.5f,dowalls:dowalls,dofloors: dofloors,doroof:doroof, ptscale: ptscale, pgvd:pgvd);
        return rv;
    }
    public GameObject GenBld(GameObject parent, OsmBldSpec bs, bool plotTesselation = false, float ptscale = 1, PolyGenVekMapDel pgvd = null)
    {
        pg.SetOutline(bs.GetOutline());
        var clr = bs.GetColor();
        var bldname = $"{bs.name} ({bs.wid} {bs.bldtyp})";
        var dowalls = true;
        var dofloors = true;
        var doroof = true;
        if (plotTesselation)
        {
            dowalls = false;
            dofloors = false;
        }
        var rv = pg.GenBld(parent, bldname, bs.height, bs.levels, clr, alf: 0.5f, dowalls: dowalls, dofloors: dofloors, doroof: doroof, plotTesselation: plotTesselation, ptscale: ptscale, pgvd: pgvd);
        return rv;
    }

    public List<OsmBldSpec> LoadRegion(GameObject parent, List<SimpleDf> dfwayslist, List<SimpleDf> dflinkslist, List<SimpleDf> dfnodeslist, float ptscale = 1, PolyGenVekMapDel pgvd = null, LatLongMap llm = null,bool useindexes=true)
    {
        var rv = new List<OsmBldSpec>();
        var sw = new Aiskwk.Dataframe.StopWatch();
        var osmblds = new List<OsmBldSpec>();

        var numregs = dfwayslist.Count;
        for(var i=0; i< numregs; i++)
        {
            var wdf = dfwayslist[i];
            var ndf = dfnodeslist[i];
            var ldf = dflinkslist[i];
            var lst = LoadOsmBuildingsFromSdfs(wdf, ndf, ldf, ptscale: ptscale, llm: llm);
            osmblds.AddRange(lst);
        }
        foreach (var bs in osmblds)
        {
            var nbspts = bs.GetOutline().Count;
            if (nbspts >= 3)
            {
                //GenFixedFormBld(ObjForm.cross, bs.name, bs.loc, bs.height,bs.levels,"db");
                var bldgo = GenBld(parent, bs, ptscale: ptscale, pgvd: pgvd);
                bs.bgo = bldgo;
                rv.Add(bs);
            }
            else
            {
                //Debug.LogWarning($"Building {bs.name} does not have enough outline points:{nbspts}");
            }
        }
        sw.Stop();
        Debug.Log($"BldPolyGen.LoadRegion Building Generation took {sw.ElapSecs()} secs");
        return rv;
    }


    public List<OsmBldSpec> LoadRegionOld(GameObject parent, string regionspec, float ptscale = 1, PolyGenVekMapDel pgvd = null, LatLongMap llm = null)
    {
        var rv = new List<OsmBldSpec>();
        var sw = new Aiskwk.Dataframe.StopWatch();
        var osmblds = new List<OsmBldSpec>();
        var sar = regionspec.Split(',');

        foreach (var regionname in sar)
        {
            LoadSdfs(regionname);
            var lst = LoadOsmBuildingsFromSdfs(_dfways,_dfnodes,_dflinks,ptscale: ptscale,llm:llm);
            osmblds.AddRange(lst);
        }
        foreach (var bs in osmblds)
        {
            //GenFixedFormBld(ObjForm.cross, bs.name, bs.loc, bs.height,bs.levels,"db");
            var bldgo = GenBld(parent, bs, ptscale: ptscale, pgvd: pgvd);
            bs.bgo = bldgo;
            rv.Add(bs);
        }
        sw.Stop();
        Debug.Log($"Generation of {regionspec} took {sw.ElapSecs()} secs");
        return rv;
    }

    //public void LoadRegionOneBld(GameObject parent, string regionspec, string bldwid, float ptscale = 1)
    //{
    //    var sw = new Aiskwk.Dataframe.StopWatch();
    //    var blds = new List<Bldspec>();
    //    var sar = regionspec.Split(',');
    //    foreach (var regionname in sar)
    //    {
    //        LoadSdfs(regionname);
    //        blds.AddRange(LoadOsmBuildingsFromSdfs(ptscale: ptscale));
    //    }
    //    foreach (var bs in blds)
    //    {
    //        if (bs.wid == bldwid)
    //        {
    //            //GenFixedFormBld(ObjForm.cross, bs.name, bs.loc, bs.height,bs.levels,"db");
    //            GenBld(parent, bs, plotTesselation: true, ptscale: ptscale);
    //        }
    //    }
    //    sw.Stop();
    //    Debug.Log($"Generation of {regionspec} took {sw.ElapSecs()} secs");
    //}
    public enum ObjForm { star, cross, circle }
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
                    pg.GenCylinderOutline(loc, 5, radius);
                    break;
                }
        }
    }


    //void GenObj(GameObject parent, ObjForm objform, bool dowalls = true, bool doroof = true, bool dofloor = true, bool plotTesselation = false, bool onesided = false)
    //{
    //    var alf = 0.5f;
    //    //alf = 1;
    //    GenOutline(objform, Vector3.zero);
    //    var wps = true;
    //    if (dowalls)
    //    {
    //        Debug.Log($"GenObj doing walls for {objform}");
    //        pg.SetGenForm(PolyGenForm.wallsmesh);
    //        var walgo = pg.GenMesh("walls", height: 2, clr: "blue", alf: alf, plotTesselation: plotTesselation, onesided: onesided);
    //        walgo.transform.SetParent(parent.transform, worldPositionStays: wps);
    //    }
    //    if (doroof)
    //    {
    //        Debug.Log($"GenObj doing roof for {objform}");
    //        pg.SetGenForm(PolyGenForm.tesselate);
    //        var rufgo = pg.GenMesh("ceiling", height: 2, clr: "blue", alf: alf, plotTesselation: plotTesselation, onesided: onesided);
    //        rufgo.transform.SetParent(parent.transform, worldPositionStays: wps);
    //    }
    //    if (dofloor)
    //    {
    //        Debug.Log($"GenObj doing floor for {objform}");
    //        pg.SetGenForm(PolyGenForm.tesselate);
    //        var fl1go = pg.GenMesh("floor1", height: 1, clr: "blue", alf: alf, plotTesselation: plotTesselation, onesided: onesided);
    //        fl1go.transform.SetParent(parent.transform, worldPositionStays: wps);
    //    }
    //}
}
