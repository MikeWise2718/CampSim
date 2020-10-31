using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aiskwk.Dataframe;
using Aiskwk.Map;
using System;
using UnityEngine.UI;

public enum GroundRef {  cen, min, max }
[Serializable]
public class OsmBldSpec
{
    public string osmname;
    public string shortname;
    public string bldtyp;
    public string wid;
    public float height;
    public float levelheight;
    public float firstflooroffset;
    public int levels;
    public double lat;
    public double lng;
    public float x;
    public float z;
    public float bscale;
    public Vector3 loc;
    public GroundRef groundRef;
    public Vector3 ptcen;
    public float maxy;
    public float ceny;
    public float miny;
    public bool isVisible;
    List<Vector3> boutline;
    public GameObject bgo;


    public OsmBldSpec(string nname, string bldtyp, string wid, float height = 0, int levels = 0, float bscale = 1)
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
        this.osmname = nname;
        this.bldtyp = bldtyp.ToLower();
        this.bscale = bscale;
        this.wid = wid;
        this.height = height;
        this.levels = levels;
        this.firstflooroffset = 0;
        this.levelheight = height / levels;
        this.bgo = null;
        this.isVisible = true;
        this.maxy = 0;
        this.ceny = 0;
        this.miny = 0;
        this.groundRef = GroundRef.cen;
        shortname = osmname;
        shortname = shortname.Replace("Microsoft Building ","Bld");
        shortname = shortname.Replace("Microsoft Studio ", "Stu");
        shortname = shortname.Replace("RedWest-", "BldRW");
        //Debug.Log($"osmname:{osmname}  shortname:{shortname}");
    }
    public void AddPos(double lat, double lng, float x, float z)
    {
        this.lat = lat;
        this.lng = lng;
        this.x = x * bscale;
        this.z = z * bscale;
        this.loc = new Vector3(this.x, 0, -this.z);
    }
    public void SetOutline(List<Vector3> outline, PolyGenVekMapDel pgvd=null)
    {
        // set the outline
        // note boutline can not have the yvalues in there as the tesselation algorithems need them to be zero
        // I suppose I could change that...
        boutline = new List<Vector3>();
        var n = outline.Count;
        if (n == 0)
        {
            miny = 0;
            maxy = 0;
            ceny = 0;
            // make sure everything
            return;
        }
        miny = float.MaxValue;
        maxy = float.MinValue;
        var sumx = 0f;
        var sumz = 0f;
        foreach (var pt in outline)
        {
            var x = pt.x * bscale;
            var y = pt.y * bscale;
            var z = pt.z * bscale;
            sumx += x;
            sumz += z;
            var newboutlinept = new Vector3(x, y, z);
            if (pgvd != null)
            {
                var pgvd_pt = pgvd(new Vector3(x, 0, z));
                y = pgvd_pt.y;
            }
            if (y<miny)
            {
                miny = y;
            }
            if (y > maxy)
            {
                maxy = y;
            }
            boutline.Add(newboutlinept);
        }
        if (pgvd != null)
        {
            var ptcen0 = new Vector3(sumx / n, 0, sumz / n);
            ptcen = pgvd(ptcen0);
            ceny = ptcen.y;
        }
        else
        {
            ceny = (miny + maxy) / 2;// kind of arbitrary
            ptcen = new Vector3( sumx/n, ceny, sumz/n );
        }
    }

    public List<Vector3> GetOutline()
    {
        var rv = new List<Vector3>(boutline);
        return rv;
    }

    public float GetGround()
    {
        var rv = 0f;
        switch (groundRef)
        {
            case GroundRef.cen: 
                rv = ceny;
                break;
            case GroundRef.max:
                rv = maxy;
                break;
            case GroundRef.min:
                rv = miny;
                break;
        }
        return rv;
    }

    public float GetZeroBasedFloorHeight(int i,bool includeAltitude=false)
    {
        // note that on a 3 story 12 meter building the 0, 1, 2 floors are on 0, 4, 8 meter altitude
        var y = height;
        if (levels > 0)
        {
            var iflr = i;
            if (iflr < 0) iflr = 0;
            if (iflr > levels) iflr = levels;
            y = firstflooroffset + ((iflr * height) / levels);
        }
        if (includeAltitude)
        {
            y += GetGround();
        }
        return y;
    }
    public Vector3 GetCenterFloor(int i,bool includeAltitude=false)
    {
        var y = GetZeroBasedFloorHeight(i, includeAltitude: includeAltitude);
        var rv = new Vector3(ptcen.x, y, ptcen.z);
        return rv;
    }
    public Vector3 GetCenterTop(bool includeAltitude = false)
    {
        var rv = GetCenterFloor(levels,includeAltitude:includeAltitude); 
        return rv;
    }
    public Vector3 GetCenterBottom(bool includeAltitude = false)
    {
        var rv = GetCenterFloor(0, includeAltitude: includeAltitude);
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
    public GrafPolyGen gpg;

    public BldPolyGen()
    {
        ReInit();
    }

    public void ReInit()
    {
        gpg = new GrafPolyGen();
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


    public List<OsmBldSpec> LoadOsmBuildingsFromSdfs(SimpleDf dfways, SimpleDf dfnodes, SimpleDf dflinks, float ptscale = 1, LatLongMap llm = null, bool usenodedict = false, PolyGenVekMapDel pgvd = null)
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
        Debug.Log($"Found {blddf.Nrow()} buildings in dfways - {dfways.name}");
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
            bs.SetOutline(nodeoutline,pgvd);
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
        //var l1 = new Vector3(v, 0, v);
        //GenFixedFormBldForTesting(parent, ObjForm.circle, "b10", l1, height, levs, "db", ptscale: ptscale, pgvd:pgvd );

        //ReInit();
        //var l2 = new Vector3(-v, 0, v);
        //GenFixedFormBldForTesting(parent, ObjForm.star, "b01", l2, height, levs, "dg", ptscale: ptscale, pgvd: pgvd);


        //ReInit();
        //var l3 = new Vector3(v, 0, -v);
        //GenFixedFormBldForTesting(parent, ObjForm.cross, "b10", l3, height, levs, "dr", ptscale: ptscale, pgvd: pgvd);



        //ReInit();
        //var l4 = new Vector3(-v, 0, -v);
        //GenFixedFormBldForTesting(parent, ObjForm.cross, "b00", l4, height, levs, "dy", ptscale: ptscale, pgvd: pgvd);
    }




    //public GameObject GenFixedFormBldForTesting(GameObject parent, ObjForm objform, string bldname, Vector3 loc, float height, int levels, string clr, float ptscale = 1, PolyGenVekMapDel pgvd = null)
    //{
    //    GenOutline(objform, loc);
    //    var dowalls = true;
    //    var dofloors = true;
    //    var doroof = true;
    //    // broke it, needs a bldspec now
    //    //var rv = pg.GenBld(parent, bldname,bldname, height, levels, clr, alf: 0.5f,dowalls:dowalls,dofloors: dofloors,doroof:doroof, ptscale: ptscale, pgvd:pgvd);
    //    return rv;
    //}
    public GameObject GenBldFromOsmBldSpec(GameObject parent, OsmBldSpec bs, bool plotTesselation = false, float ptscale = 1, PolyGenVekMapDel pgvd = null,float alf=0.5f)
    {
        //if (bs.shortname=="Bld34")
        //{
        //    Debug.Log("Bld34");
        //}
        gpg.SetOutline(bs.GetOutline());
        var clr = bs.GetColor();
        var dowalls = true;
        var dofloors = true;
        var doroof = true;
        var dosock = true;
        if (plotTesselation)
        {
            dowalls = false;
            dofloors = false;
        }
        var outline = bs.GetOutline();
 
        var rv = gpg.GenBld(parent, bs, clr, alf: alf, dowalls: dowalls, dofloors: dofloors, doroof: doroof,dosock:dosock, plotTesselation: plotTesselation, ptscale: ptscale, pgvd: pgvd);
        return rv;
    }


    public List<OsmBldSpec> GetBuildspecsInRegion(List<SimpleDf> dfwayslist, List<SimpleDf> dflinkslist, List<SimpleDf> dfnodeslist, float ptscale = 1, LatLongMap llm = null, PolyGenVekMapDel pgvd = null)
    {
        var osmblds = new List<OsmBldSpec>();

        var numregs = dfwayslist.Count;
        for (var i = 0; i < numregs; i++)
        {
            var wdf = dfwayslist[i];
            var ndf = dfnodeslist[i];
            var ldf = dflinkslist[i];
            var lst = LoadOsmBuildingsFromSdfs(wdf, ndf, ldf, ptscale: ptscale, llm: llm,pgvd:pgvd);
            osmblds.AddRange(lst);
        }
        return osmblds;
    }


    public List<OsmBldSpec> LoadRegionOldForTesting(GameObject parent, string regionspec, float ptscale = 1, PolyGenVekMapDel pgvd = null, LatLongMap llm = null, string buildingFilter = "",bool plotTessalation=false)
    {
        var rv = new List<OsmBldSpec>();
        var sw = new Aiskwk.Dataframe.StopWatch();
        var osmblds = new List<OsmBldSpec>();
        var sar = regionspec.Split(',');

        foreach (var regionname in sar)
        {
            LoadSdfs(regionname);
            var lst = LoadOsmBuildingsFromSdfs(_dfways,_dfnodes,_dflinks,ptscale: ptscale,llm:llm,pgvd:pgvd);
            osmblds.AddRange(lst);
        }
        var filterBuildings = buildingFilter != "";
        foreach (var bs in osmblds)
        {
            if (filterBuildings)
            {
                if (bs.osmname.StartsWith(buildingFilter))
                {
                    Debug.Log($"BldPolyGen.LoadRegionOld found {buildingFilter} plotTesselation:{plotTessalation}");
                }
                else
                {
                    continue;
                }
            }
            var nbspts = bs.GetOutline().Count;
            if (nbspts >= 3)
            {
                var bldgo = GenBldFromOsmBldSpec(parent, bs, ptscale: ptscale, pgvd: pgvd, plotTesselation:plotTessalation);
                bs.bgo = bldgo;
                rv.Add(bs);
            }
            else
            {
                Debug.LogWarning($"Building {bs.osmname} does not have enough outline points:{nbspts}");
            }
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
                    gpg.GenStarOutline(loc, 8, radiusinnner, radius);
                    break;
                }
            case ObjForm.cross:
                {
                    gpg.GenCrossOutline(loc, radius);
                    break;
                }
            case ObjForm.circle:
                {
                    gpg.GenCylinderOutline(loc, 5, radius);
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
