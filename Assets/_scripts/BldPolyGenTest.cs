using Aiskwk.Dataframe;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.UI;

public class BldPolyGenTest : MonoBehaviour
{
    BldPolyGen bpg;
    // Start is called before the first frame update
    void Start()
    {
        var blds = LoadCsv("eb12small");
        foreach(var bs in blds)
        {
            GenFixedFormBld(ObjForm.cross, bs.name, bs.loc, bs.height,bs.levels,"db");
            GenBld(bs, "r");
        }
    }

    void Test4()
    {
        // debug one layer only
        //GenObj(ObjForm.circle, dowalls:false,doceil:true,dofloor:false,dbOutline:false);
        //GenObj(ObjForm.circle,onesided:false);

        var v = 4;
        var l1 = new Vector3(v, 0, v);
        GenFixedFormBld(ObjForm.cross, "b11", l1, 48, 12, "dr");
        var l2 = new Vector3(-v, 0, v);
        GenFixedFormBld(ObjForm.star, "b01", l2, 48, 12, "dg");
        var l3 = new Vector3(v, 0, -v);
        GenFixedFormBld(ObjForm.circle, "b10", l3, 48, 12, "db");
        var l4 = new Vector3(-v, 0, -v);
        GenFixedFormBld(ObjForm.cross, "b00", l4, 48, 12, "dy");
    }


    List<Vector3> ExtractNodes(string wid,string name,SimpleDf linksdf,SimpleDf nodedf,Dictionary<string,int> nodedict)
    {
        var rv = new List<Vector3>();
        var osm_nid_1 = linksdf.GetStringCol("osm_nid_1");
        var osm_nid_2 = linksdf.GetStringCol("osm_nid_2");
        var xvals = nodedf.GetFloatCol("x");
        var zvals = nodedf.GetFloatCol("z");
        var latvals = nodedf.GetDoubleCol("lat");
        var lngvals = nodedf.GetDoubleCol("lng");
        var on1 = "";
        var on2 = "";
        for (int i= 0; i < linksdf.Nrow(); i++)
        {
            var n1 = osm_nid_1[i];
            if (!nodedict.ContainsKey(n1))
            {
                Debug.LogError($"Bld:{name} - wid:{wid} - Unknown node 1 {osm_nid_1}");
                continue;
            }
            var n1idx = nodedict[n1];
            var pt1 = new Vector3(xvals[n1idx], 0, zvals[n1idx]);

            var n2 = osm_nid_2[i];
            if (!nodedict.ContainsKey(n2))
            {
                Debug.LogError($"Bld:{name} - wid:{wid} - Unknown node 1 {osm_nid_1}");
                continue;
            }
            var n2idx = nodedict[n2];
            var pt2 = new Vector3(xvals[n2idx], 0, zvals[n2idx]);

            if (i == 0)
            {
                rv.Add(pt1);
            }
            else
            {
                if (on2!=n1)
                {
                    Debug.LogError($"Bld:{name} - wod:{wid} - On node {i} - old node2:{on2} not the same as node1:{n1}");
                    return rv;
                }
            }
            rv.Add(pt2);
            on1 = n1;
            on2 = n2;
        }
        return rv;
    }

    public class Bldspec
    {
        public string name;
        public string wid;
        public float height;
        public int levels;
        public double lat;
        public double lng;
        public float x;
        public float z;
        public Vector3 loc;
        public List<Vector3> outline;
        public Bldspec(string name,string wid,float height=0,int levels=0)
        {
            this.name = name;
            this.wid = wid;
            this.height = height;
            this.levels = levels;
        }
        public void AddPos(double lat,double lng,float x,float z)
        {
            this.lat = lat;
            this.lng = lng;
            this.x = x;
            this.z = z;
            this.loc = new Vector3(x, 0, z);
        }
    }

    List<Bldspec> LoadCsv(string areaprefix,string dname="")
    {
        var rv = new List<Bldspec>();
        if (dname=="")
        {
            dname = "d:/pyprj/overpy/output/";
        }
        var fnameways = $"{dname}{areaprefix}_ways.csv";
        var fnamenodes = $"{dname}{areaprefix}_nodes.csv";
        var fnamelinks = $"{dname}{areaprefix}_links.csv";

        var dfways = new SimpleDf(areaprefix +"_ways");
        dfways.ReadCsv(fnameways);
        Debug.Log($"Read {dfways.Nrow()} ways from {fnameways}");

        var dflinks = new SimpleDf(areaprefix + "links");
        dflinks.ReadCsv(fnamelinks);
        Debug.Log($"Read {dflinks.Nrow()} links from {fnamelinks}");

        var dfnodes = new SimpleDf(areaprefix + "nodes");
        dfnodes.ReadCsv(fnamenodes);
        Debug.Log($"Read {dfnodes.Nrow()} links from {fnamenodes}");

        var nid = dfnodes.GetStringCol("osm_nid");
        var nodedict = new Dictionary<string, int>();
        for (int idx = 0; idx < dfnodes.Nrow(); idx++)
        {
            nodedict[nid[idx]] = idx;
        }


        var blddf = SimpleDf.SubsetOnStringColVal(dfways, "osmtype", "building");
        Debug.Log($"Found {blddf.Nrow()} buildings in dfways");
        var bldwids = blddf.GetStringCol("osm_wid");
        var bldnames = blddf.GetStringCol("name");
        var bldheights = blddf.GetFloatCol("height");
        var bldlevels = blddf.GetIntCol("levels");
        var bldlat = blddf.GetDoubleCol("lat");
        var bldlng = blddf.GetDoubleCol("lng");
        var bldz = blddf.GetFloatCol("z");
        var bldx = blddf.GetIntCol("x");
        int i = 0;
        foreach(var bwid in bldwids)
        {
            var bname = bldnames[i];
            var bheit = bldheights[i];
            var blevs = bldlevels[i];
            var bllat = (bldlat == null ? 0 : bldlat[i] );
            var bllng = (bldlng == null ? 0 : bldlng[i] );
            var blz = (bldz == null ? 0 : bldz[i]);
            var blx = (bldx == null ? 0 : bldx[i]);
            var bldwalldf = SimpleDf.SubsetOnStringColVal(dflinks, "osm_wid", bwid);
            Debug.Log($"Found {bldwalldf.Nrow()} links for bld wid:{bwid} name:{bname}");
            var bs = new Bldspec(bname, bwid, bheit, blevs);
            bs.AddPos(bllat, bllng, blx, blz);
            var outline = ExtractNodes(bname,bwid,dflinks, dfnodes,nodedict);
            bs.outline = outline;
            rv.Add(bs);
            i++;
        }
        return rv;
    }

    void GenFixedFormBld(ObjForm objform,string bldname,Vector3 loc,float height,int levels,string clr)
    {
        bpg = new BldPolyGen();
        GenOutline(objform,loc);
        bpg.GenBld(this.gameObject, bldname, height, levels, clr, alf: 0.5f);
    }

    void GenBld(Bldspec bs, string clr)
    {
        bpg = new BldPolyGen();
        bpg.SetOutline(bs.outline);
        bpg.GenBld(this.gameObject, bs.name, bs.height,bs.levels, clr, alf: 0.5f);
    }


    void GenOutline(ObjForm objform,Vector3 loc)
    {
        switch (objform)
        {
            default:
            case ObjForm.star:
                {
                    bpg.GenStarOutline(loc, 8, 0.5f, 3f);
                    break;
                }
            case ObjForm.cross:
                {
                    bpg.GenCrossOutline(loc, 2f);
                    break;
                }
            case ObjForm.circle:
                {
                    bpg.GenCylinderOutline(loc, 10, 3f);
                    break;
                }
        }
    }

    enum ObjForm { star, cross, circle }
    void GenObj(ObjForm objform, bool dowalls = true, bool doroof = true, bool dofloor = true, bool dbOutline = false, bool onesided=false)
    {
        var alf = 0.5f;
        //alf = 1;
        GenOutline(objform,Vector3.zero);
        if (dowalls)
        {
            bpg.SetGenForm(BldPolyGenForm.wallsmesh);
            var walgo = bpg.GenMesh("walls", height: 2, clr: "blue", alf: alf,dbout:dbOutline, onesided:onesided);
            walgo.transform.parent = this.transform;
        }
        if (doroof)
        {
            bpg.SetGenForm(BldPolyGenForm.tesselate);
            var rufgo = bpg.GenMesh("ceiling", height: 2, clr: "blue", alf: alf, dbout: dbOutline, onesided: onesided);
            rufgo.transform.parent = this.transform;
        }
        if (dofloor)
        {
            bpg.SetGenForm(BldPolyGenForm.tesselate);
            var fl1go = bpg.GenMesh("floor1", height: 1, clr: "blue", alf: alf, dbout: dbOutline, onesided: onesided);
            fl1go.transform.parent = this.transform;
        }
    }
}
