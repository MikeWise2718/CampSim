using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Microsoft.MapPoint;
using Aiskwk.Map;

[System.Serializable]
public class LegLatLng
{
    public double lat;
    public double lng;
    public string name;

    public LegLatLng(double lat, double lng, string name = "")
    {
        this.lat = lat;
        this.lng = lng;
        this.name = name;
    }
    public override string ToString()
    {
        var fmt = "f6";
        var s = "lat:" + lat.ToString(fmt) + " lng:" + lng.ToString(fmt);
        return s;
    }
    public static Vector2Int GetVector2IntPixelCoords(int levelofDetail, double lat, double lng)
    {
        TileSystem.LatLongToPixelXY(lat, lng, levelofDetail, out var pixx, out var pixy);
        var rv = new Vector2Int(pixx, pixy);
        return rv;
    }
    public static Vector2 GetMeterCoords(int levelofDetail, double lat, double lng)
    {
        TileSystem.LatLongToPixelXY(lat, lng, levelofDetail, out var pixx, out var pixy);
        var fak = (float)TileSystem.GroundResolution(lat, levelofDetail);
        var rv = new Vector2(pixx * fak, pixy * fak);
        return rv;
    }
    public static Vector2Int GetV2iPixelCoordFromLatLng(int levelofDetail, LegLatLng ll)
    {
        return GetVector2IntPixelCoords(levelofDetail, ll.lat, ll.lng);
    }
    public static LegLatLng GetLngLatFromPixelCoords(int levelofDetail, int pixx, int pixy)
    {
        TileSystem.PixelXYToLatLong(pixx, pixy, levelofDetail, out var lat, out var lng);
        var rv = new LegLatLng(lat, lng);
        return rv;
    }
    public static LegLatLng GetLngLatFromV2iPixelCoords(int levelofDetail, Vector2Int vpix)
    {
        return GetLngLatFromPixelCoords(levelofDetail, vpix.x, vpix.y);
    }
    public Vector2Int GetPixelCoords(int LevelOfDetail)
    {
        return GetVector2IntPixelCoords(LevelOfDetail, lat, lng);
    }
    public Vector2 GetMeterCoords(int LevelOfDetail)
    {
        return GetMeterCoords(LevelOfDetail, lat, lng);
    }
}



[System.Serializable]
public class LegLatLngBox
{
    public string name;
    public double latmin = 0;
    public double latmax = 0;
    public double lngmin = 0;
    public double lngmax = 0;
    public double latextent = 0;
    public double lngextent = 0;
    public float diagonalInMeters = 0;
    public LegLatLngBox(LegLatLng ll1, LegLatLng ll2, string name = "llbox")
    {
        this.name = name;
        latmin = System.Math.Min(ll1.lat, ll2.lat);
        latmax = System.Math.Max(ll1.lat, ll2.lat);
        lngmin = System.Math.Min(ll1.lng, ll2.lng);
        lngmax = System.Math.Max(ll1.lng, ll2.lng);
        latextent = latmax - latmin;
        lngextent = lngmax - lngmin;
        var lod = 16;// kind of arbirary, but there is single precision to think about
        var p1 = ll1.GetMeterCoords(lod);
        var p2 = ll2.GetMeterCoords(lod);
        diagonalInMeters = Vector2.Distance(p1, p2);
    }
    public LegLatLng Interpolate(float lambLat, float lambLng)
    {
        var rv = new LegLatLng((float)((lambLat * latextent) + latmin), (float)((lambLng * lngextent) + lngmin));
        return rv;
    }
    public LegLatLng GetUpperLeft()
    {
        return new LegLatLng(latmax, lngmin, name + "-ul");
    }
    public LegLatLng GetBottomRight()
    {
        return new LegLatLng(latmin, lngmax, name + "br");
    }
    public LegLatLng GetUpperRight()
    {
        return new LegLatLng(latmax, lngmax, name + "ur");
    }
    public LegLatLng GetBottomLeft()
    {
        return new LegLatLng(latmin, lngmin, name + "bl");
    }
    public LegLatLng GetMidPoint()
    {
        return new LegLatLng((latmin + latmax) / 2, (lngmin + lngmax) / 2, name + "mp");
    }
    public Vector2Int GetPixelUpperLeft(int lod)
    {
        var rv = LegLatLng.GetVector2IntPixelCoords(lod, latmax, lngmin);
        return rv;
    }
    public Vector2Int GetPixelBottomRight(int lod)
    {
        var rv = LegLatLng.GetVector2IntPixelCoords(lod, latmin, lngmax);
        return rv;
    }
    public Vector2Int GetPixelSize(int lod)
    {
        var size = GetPixelBottomRight(lod) - GetPixelUpperLeft(lod);
        return size;
    }
    public bool IsIn(LegLatLng ll)
    {
        if (ll.lat < latmin) return false;
        if (latmax < ll.lat) return false;
        if (ll.lng < lngmin) return false;
        if (lngmax < ll.lng) return false;
        return true;
    }
    public bool IsSubset(LegLatLngBox box)
    {
        var ll1 = new LegLatLng(box.latmin, box.lngmin);
        if (!IsIn(ll1)) return false;
        var ll2 = new LegLatLng(box.latmax, box.lngmax);
        if (!IsIn(ll2)) return false;
        return true;
    }
    public override string ToString()
    {
        var fmt = "f6";
        var m = "";
        m += "latmin:" + latmin.ToString(fmt);
        m += " max:" + latmax.ToString(fmt);
        m += "lngmin:" + lngmax.ToString(fmt);
        m += " max:" + lngmin.ToString(fmt);
        return m;
    }
    public Tuple<int, int> GetPixelSize()
    {

        return new Tuple<int, int>(1, 2);
    }
}


[System.Serializable]
public class LegCrdMap
{
    public float a;
    public float b1;
    public float b2;
    public float rmserr;
    public float r2;
    public string formula;

    public LegCrdMap()
    {
        this.a = 0;
        this.b1 = 0;
        this.b2 = 0;
        this.r2 = 0;
        var af = a.ToString("F3");
        var bf = b1.ToString("F3");
        var cf = b2.ToString("F3");
        this.formula = $"a:{af} b:{bf} c:{cf}";
    }
    public float Map(float x1, float x2)
    {
        return a + b1 * x1 + b2 * x2;
    }
    public override string ToString()
    {
        return formula;
    }
}

[System.Serializable]
public class LegMapCoordPoint
{
    public float lng;
    public float lat;
    public float x;
    public float z;
    public float lnghat;
    public float lathat;
    public float xhat;
    public float zhat;
    public float val(string vname)
    {
        switch (vname)
        {
            case "lng": return lng;
            case "lat": return lat;
            case "x": return x;
            case "z": return z;
            case "lnghat": return lnghat;
            case "lathat": return lathat;
            case "xhat": return xhat;
            case "zhat": return zhat;
            default:
                throw new UnityException("unknown variable" + vname);
        }
    }
    public void setval(string vname, float val)
    {
        switch (vname)
        {
            case "lng": lng = val; return;
            case "lat": lat = val; return;
            case "x": x = val; return;
            case "z": z = val; return;
            case "lnghat": lnghat = val; return;
            case "lathat": lathat = val; return;
            case "xhat": xhat = val; return;
            case "zhat": zhat = val; return;
            default:
                throw new UnityException("unknown variable" + vname);
        }
    }
}



[System.Serializable]
public class LegMapCoordblock
{
    float Sqr(float x) => x * x;
    float Sqrt(float x) => (float)System.Math.Sqrt(x);
    public List<LegMapCoordPoint> mapdata = new List<LegMapCoordPoint>();
    LegLatLngMap llm;
    public LegMapCoordblock(LegLatLngMap llm)
    {
        this.llm = llm;
    }
    public void AddRowLatLng(float lng, float lat, float x, float z)
    {
        mapdata.Add(new LegMapCoordPoint { lng = lng, lat = lat, x = x, z = z });
    }
    public void AddRowLatLng(double dlat, double dlng, double dx, double dz)
    {
        mapdata.Add(new LegMapCoordPoint { lng = (float)dlng, lat = (float)dlat, x = (float)dx, z = (float)dz });
    }
    public void AddRowLngLat(LegLatLng ll, int lod, double pixToMeters, Vector2d org)
    {
        TileSystem.LatLongToPixelXY(ll.lat, ll.lng, lod, out var pixx, out var pixz);
        var x = pixx * pixToMeters - org.x;
        var z = pixz * pixToMeters - org.y;
        mapdata.Add(new LegMapCoordPoint { lng = (float)ll.lng, lat = (float)ll.lat, x = (float)x, z = (float)z });
    }
    public LegCrdMap DoRegression(string formula)
    {
        // split on + then trim leading and following whitespace
        char[] spar = { '=', '+' };
        var vnames = new List<string>(formula.Split(spar).Select(x => x.Trim()));

        var mu = new Dictionary<string, float>();

        //Debug.Log("DoRegression mapdata:" + mapdata.Count);
        if (mapdata.Count <= 1)
        {
            throw new UnityException("Not enough data for regression num points:" + mapdata.Count + " formula:" + formula);
        }

        vnames.ForEach(v => mu[v] = mapdata.Select(x => x.val(v)).Average());

        //foreach( var v in vnames)
        //{
        //    mu[v] = 0;
        //    foreach (var x in mapdata)
        //    {
        //        mu[v] += x.val(v);
        //    }
        //    mu[v] = mu[v] / mapdata.Count;
        //}

        //vars.Select(v => mean.Add(v, mapdata.Select(x => x.byname(v)).Sum() / nv);
        var covar = new Dictionary<string, float>();
        vnames.ForEach(v1 =>
            vnames.ForEach(v2 =>
               covar[$"{v1},{v2}"] = mapdata.Select(x => (x.val(v1) - mu[v1]) * (x.val(v2) - mu[v2])).Sum())
        );
        // shorthand names
        var vy = vnames[0];
        var vx1 = vnames[1];
        var vx2 = vnames[2];
        var vyx1 = $"{vy},{vx1}";
        var vyx2 = $"{vy},{vx2}";
        var vx1x2 = $"{vx1},{vx2}";
        var vx1x1 = $"{vx1},{vx1}";
        var vx2x2 = $"{vx2},{vx2}";

        // 2 var regression forumla
        var denom = covar[vx1x1] * covar[vx2x2] - (Sqr(covar[vx1x2]));
        if (denom == 0) denom = 1;
        var b1 = (covar[vx2x2] * covar[vyx1] - covar[vx1x2] * covar[vyx2]) / denom;
        var b2 = (covar[vx1x1] * covar[vyx2] - covar[vx1x2] * covar[vyx1]) / denom;
        var a = mu[vy] - b1 * mu[vx1] - b2 * mu[vx2];

        // now calculate r2
        var vyh = vy + "hat";
        mapdata.ForEach(x => x.setval(vyh, a + b1 * x.val(vx1) + b2 * x.val(vx2)));
        mu[vyh] = mapdata.Select(x => x.val(vyh)).Average();
        var varyhat = mapdata.Select(x => Sqr(x.val(vyh) - mu[vyh])).Sum();
        var vary = covar[$"{vy},{vy}"];
        var r2 = varyhat / vary;
        var rmserr = Sqrt(mapdata.Select(x => Sqr(x.val(vy) - x.val(vyh))).Sum());
        var rv = new LegCrdMap
        {
            formula = formula,
            a = a,
            b1 = b1,
            b2 = b2,
            r2 = r2,
            rmserr = rmserr
        };
        return rv;
    }
    public Vector3 glbmap(float x, float y, float z)
    {
        //         return a + b1*x1 + b2*x2;
        var lngmap = llm.maps.lngmap;
        var latmap = llm.maps.latmap;
        var lng = lngmap.a + lngmap.b1 * x + lngmap.b2 * z;
        var lat = latmap.a + latmap.b1 * x + latmap.b2 * z;
        var glbxmap = llm.glbllm.maps.xmap;
        var glbzmap = llm.glbllm.maps.zmap;
        var gx = glbxmap.a + glbxmap.b1 * lng + glbxmap.b2 * lat;
        var gz = glbzmap.a + glbzmap.b1 * lng + glbzmap.b2 * lat;
        var rv = new Vector3(gx, y, gz);
        return (rv);
    }

    public Vector3 glbunmap(float gx, float gy, float gz)
    {
        var xmap = llm.glbllm.maps.xmap;
        var zmap = llm.glbllm.maps.zmap;
        var det1 = xmap.b1 * zmap.b2 - xmap.b2 * zmap.b1;
        var x1 = gx - xmap.a;
        var z1 = gz - zmap.a;
        var lng = (zmap.b2 * x1 - xmap.b2 * z1) / det1;
        var lat = (-zmap.b1 * x1 + xmap.b1 * z1) / det1;

        var lngmap = llm.maps.lngmap;
        var latmap = llm.maps.latmap;
        var det2 = lngmap.b1 * latmap.b2 - lngmap.b2 * latmap.b1;
        var lng2 = lng - lngmap.a;
        var lat2 = lat - latmap.a;
        var x = (latmap.b2 * lng2 - lngmap.b2 * lat2) / det2;
        var z = (-latmap.b1 * lng2 + lngmap.b1 * lat2) / det2;
        var rv = new Vector3(x, gy, z);
        return (rv);
    }
    public Vector3 glbmap(Vector3 v)
    {
        return glbmap(v.x, v.y, v.z);
    }
    public Vector3 glbunmap(Vector3 v)
    {
        return glbunmap(v.x, v.y, v.z);
    }
    public GameObject MakeMarkers(string coordsys, float ska = 1, string clr = "purple")
    {
        var sphholder = new GameObject();
        sphholder.transform.parent = llm.transform;
        sphholder.name = coordsys;
        int i = 0;
        foreach (var md in mapdata)
        {
            var sph = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sph.name = "Marker " + i;
            sph.transform.localScale = new Vector3(ska, ska, ska);
            float x = 0;
            float z = 0;
            switch (coordsys)
            {
                case "Native":
                    x = md.x;
                    z = md.z;
                    break;
                case "LongLat":
                case "LngLat":
                    //x = llm.glbllm.maps.xmap.Map(md.lng, md.lat);
                    //z = llm.glbllm.maps.zmap.Map(md.lng, md.lat);
                    var v = glbmap(md.x, 0, md.z);
                    x = v.x;
                    z = v.z;
                    break;
            }
            sph.transform.position = new Vector3(x, 0, z);
            sph.transform.parent = sphholder.transform;
            GraphAlgos.GraphUtil.SetColorOfGo(sph, clr);
            //Debug.Log("Made sphere " + i + " at x:" + md.x + "  z:" + md.z + " for " + llm.name);
            i++;
        }
        return sphholder;
    }
    GameObject nativego = null;
    GameObject lgnlatgo = null;
    public void DestroyNativeCoordMarkers()
    {
        if (nativego != null)
        {
            UnityEngine.Object.Destroy(nativego);
            nativego = null;
        }
    }
    public void DestroLngLatCoordMarkers()
    {
        if (lgnlatgo != null)
        {
            UnityEngine.Object.Destroy(lgnlatgo);
            lgnlatgo = null;
        }
    }
    public void MakeNativeCoordMarkers(float ska = 1, string clr = "purple")
    {
        nativego = MakeMarkers("Native", ska, clr: clr);
    }
    public void MakeLongLatCoordMarkers(float ska = 1, string clr = "cyan")
    {
        lgnlatgo = MakeMarkers("LongLat", ska, clr: clr);
    }
}

[System.Serializable]
public class LegLongLatMapSet
{
    public LegCrdMap latmap;
    public LegCrdMap lngmap;
    public LegCrdMap xmap;
    public LegCrdMap zmap;
}

public class LegLatLngMap : MonoBehaviour
{

    public LegMapCoordblock mapcoord;
    public LegLongLatMapSet maps = new LegLongLatMapSet();
    public bool makeNativeSpheres = false;
    bool nativeSpheresMade = false;
    public bool makeLngLatSpheres = false;
    bool lnglatSpheresMade = false;

    public LegLatLngMap glbllm = null;
    // Use this for initialization

    public Vector3 xycoord(float lng, float lat)
    {
        // backwards because I specified the forumla wrong
        var x = maps.xmap.Map(lng, lat);
        var z = maps.zmap.Map(lng, lat);
        var rv = new Vector3(x, 0, z);
        return rv;
    }
    public Vector2 llcoord(float x, float z)
    {
        var lat = maps.latmap.Map(x, z);
        var lng = maps.lngmap.Map(x, z);
        var rv = new Vector2(lat, lng);
        return rv;
    }
    public void InitMapCoords(string dataSetName)
    {
        mapcoord = new LegMapCoordblock(this);
        switch (dataSetName)
        {
            case "Bld43":
                mapcoord.AddRowLatLng(47.640490, -122.133797, -149.1, 0.2);
                mapcoord.AddRowLatLng(47.639079, -122.134960, 28.0, -31.4);
                mapcoord.AddRowLatLng(47.638526, -122.134519, 75.4, 19.9);
                mapcoord.AddRowLatLng(47.639368, -122.133926, -29.4, 30.8);
                mapcoord.AddRowLatLng(47.641066, -122.136018, -155.44, -177.96);
                break;
            case "BldRWB":
                double xadj = 10.5;
                double zadj = 3.0;
                mapcoord.AddRowLatLng(47.660078, -122.140175, 72.70 + xadj, 4.77 + zadj);// upper left
                mapcoord.AddRowLatLng(47.659377, -122.140189, -5.35 + xadj, 4.77 + zadj);// lower left
                mapcoord.AddRowLatLng(47.660150, -122.139328, 81.23 + xadj, -59.70 + zadj);// upper right
                mapcoord.AddRowLatLng(47.659457, -122.139339, 3.18 + xadj, -59.70 + zadj);// lower right
                break;
            case "test":
                mapcoord.AddRowLatLng(1, 1, 40, 25);
                mapcoord.AddRowLatLng(2, 2, 45, 20);
                mapcoord.AddRowLatLng(1, 1, 38, 30);
                mapcoord.AddRowLatLng(3, 3, 50, 30);
                mapcoord.AddRowLatLng(2, 2, 48, 28);

                mapcoord.AddRowLatLng(3, 3, 55, 30);
                mapcoord.AddRowLatLng(3, 3, 53, 34);
                mapcoord.AddRowLatLng(4, 4, 55, 36);
                mapcoord.AddRowLatLng(4, 4, 58, 32);
                mapcoord.AddRowLatLng(3, 3, 40, 34);

                mapcoord.AddRowLatLng(5, 5, 55, 38);
                mapcoord.AddRowLatLng(3, 3, 48, 28);
                mapcoord.AddRowLatLng(3, 3, 45, 30);
                mapcoord.AddRowLatLng(2, 2, 55, 36);
                mapcoord.AddRowLatLng(4, 4, 60, 34);

                mapcoord.AddRowLatLng(5, 5, 60, 38);
                mapcoord.AddRowLatLng(5, 5, 60, 42);
                mapcoord.AddRowLatLng(5, 5, 65, 38);
                mapcoord.AddRowLatLng(4, 4, 50, 34);
                mapcoord.AddRowLatLng(3, 3, 58, 38);
                break;
            default:
                return;
        }
        //sman = Object.FindO            SphInfo.DoInfoSphere(ranpoints, name, pos, ska, clrs[istat]);nativebjectOfType<SceneMan>();
        //glbllm = sman.GetComponent<LegLatLngMap>();
        maps.latmap = mapcoord.DoRegression("lat = x + z");
        maps.lngmap = mapcoord.DoRegression("lng = x + z");
        maps.xmap = mapcoord.DoRegression("x = lng + lat");
        maps.zmap = mapcoord.DoRegression("z = lng + lat");
    }

    public void InitMapFromSceneSel(string regsel, int nothing )
    {
        mapcoord = new LegMapCoordblock(this);
        switch (regsel)
        {
            default:
            case "MsftRedwest":
            case "MsftCoreCampus":
            case "MsftB19focused":
                mapcoord.AddRowLatLng(47.640490, -122.133797, -149.1, 0.2);
                mapcoord.AddRowLatLng(47.639079, -122.134960, 28.0, -31.4);
                mapcoord.AddRowLatLng(47.638526, -122.134519, 75.4, 19.9);
                mapcoord.AddRowLatLng(47.639368, -122.133926, -29.4, 30.8);
                mapcoord.AddRowLatLng(47.641066, -122.136018, -155.44, -177.96);
                break;
            case "Eb12":
                mapcoord.AddRowLatLng(49.993313, 8.678353, 0, 0);          // eb12 origin streetlamp     
                mapcoord.AddRowLatLng(49.993472, 8.677981, 18.45, 27.90);   // eb12-12 doorway
                mapcoord.AddRowLatLng(49.995560, 8.676101, 260.80, 167.7); // SW corner of Rewe
                mapcoord.AddRowLatLng(49.995788, 8.676752, 287.25, 118.35); //SE corner of Rewe
                break;
            case "MsftDublin":
                //mapcoord.AddRowLngLat(53.268998, -6.196680, 0, 0);
                mapcoord.AddRowLatLng(53.268396, -6.195296, -103.5, 75.2);
                mapcoord.AddRowLatLng(53.269369, -6.196511, -12.4, -47.8);
                mapcoord.AddRowLatLng(53.269212, -6.194816, -139.0, -27.5);
                break;
        }
        glbllm = this;
        maps.latmap = mapcoord.DoRegression("lat = x + z");
        maps.lngmap = mapcoord.DoRegression("lng = x + z");
        maps.xmap = mapcoord.DoRegression("x = lng + lat");// backwards, should do something about it someday
        maps.zmap = mapcoord.DoRegression("z = lng + lat");
    }


    public void InitMapFromLatLongBox(LegLatLngBox latLngBox, int lod)
    {
        mapcoord = new LegMapCoordblock(this);
        var llbl = latLngBox.GetBottomLeft();
        var llul = latLngBox.GetUpperLeft();
        var llbr = latLngBox.GetBottomRight();
        var llur = latLngBox.GetUpperRight();
        var llmp = latLngBox.GetMidPoint();
        var pixToMeters = TileSystem.GroundResolution(llmp.lat, lod);
        var orgpix = llbl.GetPixelCoords(lod);
        var orgmeters = new Vector2d(orgpix.x * pixToMeters, orgpix.y * pixToMeters);
        mapcoord.AddRowLngLat(llbl, lod, pixToMeters, orgmeters);
        mapcoord.AddRowLngLat(llul, lod, pixToMeters, orgmeters);
        mapcoord.AddRowLngLat(llbr, lod, pixToMeters, orgmeters);
        mapcoord.AddRowLngLat(llur, lod, pixToMeters, orgmeters);
        mapcoord.AddRowLngLat(llmp, lod, pixToMeters, orgmeters);
        glbllm = this;
        maps.latmap = mapcoord.DoRegression("lat = x + z");
        maps.lngmap = mapcoord.DoRegression("lng = x + z");
        maps.xmap = mapcoord.DoRegression("x = lng + lat");
        maps.zmap = mapcoord.DoRegression("z = lng + lat");
    }
    public void AddLlmDetails()
    {
        InitMapCoords(name);
    }

    // Update is called once per frame
    void Update()
    {
        if (makeNativeSpheres && !nativeSpheresMade)
        {
            mapcoord.MakeNativeCoordMarkers();
            nativeSpheresMade = true;
        }
        if (!makeNativeSpheres && nativeSpheresMade)
        {
            mapcoord.DestroyNativeCoordMarkers();
            nativeSpheresMade = false;
        }


        if (makeLngLatSpheres && !lnglatSpheresMade)
        {
            mapcoord.MakeLongLatCoordMarkers();
            lnglatSpheresMade = true;
        }
        if (!makeLngLatSpheres && lnglatSpheresMade)
        {
            mapcoord.DestroLngLatCoordMarkers();
            lnglatSpheresMade = false;
        }
    }
}
