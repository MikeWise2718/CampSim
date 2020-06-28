﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aiskwk.Dataframe;
using Aiskwk.Map;
using UnityEngine.UIElements;
using System.Text;
using System.Linq;
using UnityEngine.AI;
using System.Data.Common;

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
    public Vector3 loc;
    public List<Vector3> outline;
    public Bldspec(string name, string bldtyp, string wid, float height = 0, int levels = 0)
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
        this.wid = wid;
        this.height = height;
        this.levels = levels;
    }
    public void AddPos(double lat, double lng, float x, float z)
    {
        this.lat = lat;
        this.lng = lng;
        this.x = x;
        this.z = z;
        this.loc = new Vector3(x, 0, -z);
    }
    static Dictionary<string, string> clrcvt = new Dictionary<string, string>()
        {
            { "appartment","yellow" },
            { "apartment","yellow" },
            { "bld","red" },
            { "commercial","blue" },
            { "office","cyan" },
            { "school","green" },
            { "church","darkgreen" },

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
            var pt1 = new Vector3(xvals[n1idx], 0, zvals[n1idx]);

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


    (SimpleDf ways, SimpleDf links, SimpleDf nodes) GetSimpleDfs(string areaprefix, string dname = "")
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

    public List<Bldspec> LoadBuildingsFromCsv(string areaprefix, string dname = "")
    {
        var sw = new Aiskwk.Dataframe.StopWatch();
        sw.Start();
        var rv = new List<Bldspec>();

        var (dfways, dflinks, dfnodes) = GetSimpleDfs(areaprefix, dname);

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
            var bs = new Bldspec(bname, btype, bwid, bheit, blevs);
            bs.AddPos(bllat, bllng, blx, blz);
            var outline = ExtractNodes(bname, bwid, bldwalldf, dfnodes, nodedict);
            bs.outline = outline;
            rv.Add(bs);
            i++;
        }
        var nbld = i;
        sw.Stop();
        Debug.Log($"Loading and generating {nbld} builds took {sw.ElapSecs()} secs");
        return rv;
    }
    void Test4(GameObject parent)
    {
        // debug one layer only
        //GenObj(ObjForm.circle, dowalls:false,doceil:true,dofloor:false,dbOutline:false);
        //GenObj(ObjForm.circle,onesided:false);

        var v = 4;
        var l1 = new Vector3(v, 0, v);
        GenFixedFormBld(parent,ObjForm.cross, "b11", l1, 48, 12, "dr");
        var l2 = new Vector3(-v, 0, v);
        GenFixedFormBld(parent,ObjForm.star, "b01", l2, 48, 12, "dg");
        var l3 = new Vector3(v, 0, -v);
        GenFixedFormBld(parent,ObjForm.circle, "b10", l3, 48, 12, "db");
        var l4 = new Vector3(-v, 0, -v);
        GenFixedFormBld(parent,ObjForm.cross, "b00", l4, 48, 12, "dy");
    }




    public void GenFixedFormBld(GameObject parent, ObjForm objform, string bldname, Vector3 loc, float height, int levels, string clr)
    {
        GenOutline(objform, loc);
        pg.GenBld(parent, bldname, height, levels, clr, alf: 0.5f);
    }

    public void GenBld(GameObject parent,Bldspec bs)
    {
        pg.SetOutline(bs.outline);
        var clr = bs.GetColor();
        pg.GenBld(parent, bs.name, bs.height, bs.levels, clr, alf: 0.5f);
    }

    public void LoadRegion(GameObject parent,string regionspec)
    {
        var blds = new List<Bldspec>();
        var sar = regionspec.Split(',');
        foreach (var s in sar)
        {
            blds.AddRange(LoadBuildingsFromCsv(s));
        }
        foreach (var bs in blds)
        {
            //GenFixedFormBld(ObjForm.cross, bs.name, bs.loc, bs.height,bs.levels,"db");
            GenBld(parent, bs);
        }
    }

    void GenOutline(ObjForm objform, Vector3 loc)
    {
        switch (objform)
        {
            default:
            case ObjForm.star:
                {
                    pg.GenStarOutline(loc, 8, 0.5f, 3f);
                    break;
                }
            case ObjForm.cross:
                {
                    pg.GenCrossOutline(loc, 2f);
                    break;
                }
            case ObjForm.circle:
                {
                    pg.GenCylinderOutline(loc, 10, 3f);
                    break;
                }
        }
    }

    public enum ObjForm { star, cross, circle }
    void GenObj(GameObject parent,ObjForm objform, bool dowalls = true, bool doroof = true, bool dofloor = true, bool dbOutline = false, bool onesided = false)
    {
        var alf = 0.5f;
        //alf = 1;
        GenOutline(objform, Vector3.zero);
        if (dowalls)
        {
            pg.SetGenForm(PolyGenForm.wallsmesh);
            var walgo = pg.GenMesh("walls", height: 2, clr: "blue", alf: alf, dbout: dbOutline, onesided: onesided);
            walgo.transform.parent = parent.transform;
        }
        if (doroof)
        {
            pg.SetGenForm(PolyGenForm.tesselate);
            var rufgo = pg.GenMesh("ceiling", height: 2, clr: "blue", alf: alf, dbout: dbOutline, onesided: onesided);
            rufgo.transform.parent = parent.transform;
        }
        if (dofloor)
        {
            pg.SetGenForm(PolyGenForm.tesselate);
            var fl1go = pg.GenMesh("floor1", height: 1, clr: "blue", alf: alf, dbout: dbOutline, onesided: onesided);
            fl1go.transform.parent = parent.transform;
        }
    }
}
