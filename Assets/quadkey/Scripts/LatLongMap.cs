using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Microsoft.MapPoint;


namespace Aiskwk.Map
{
    [System.Serializable]
    public class LatLng
    {
        public double lat;
        public double lng;
        public string name;

        public LatLng(double lat, double lng, string name = "")
        {
            this.lat = lat;
            this.lng = lng;
            this.name = name;
        }
        public LatLng(LatLng ll, string name = "")
        {
            this.lat = ll.lat;
            this.lng = ll.lng;
            this.name = name;
        }
        public static (bool, LatLng ll) IsValidLatLngString(string s)
        {
            var falseRv = (false, new LatLng(0, 0));
            var sar = s.Split(',');
            if (sar.Length != 2) return falseRv;
            if (!double.TryParse(sar[0], out var lat)) return falseRv;
            if (!double.TryParse(sar[1], out var lng)) return falseRv;
            return (true, new LatLng(lat, lng));
        }
        public string ToRequestformat()
        {
            var fmt = "f7";
            var s = $"{lat.ToString(fmt)},{lng.ToString(fmt)}";
            return s;
        }
        public override string ToString()
        {
            var fmt = "f7";
            var s = $"lat:{lat.ToString(fmt)} lng:{lng.ToString(fmt)}";
            return s;
        }
        public static double DistanceV2d(Vector2d p1, Vector2d p2)
        {
            var dpx = p2.x - p1.x;
            var dpy = p2.y - p1.y;
            var rv = Math.Sqrt(dpx * dpx + dpy * dpy);
            return rv;
        }
        public static double DistanceInMeters(LatLng ll1, LatLng ll2, int lod)
        {
            var p1 = GetMeterCoords(lod, ll1);
            var p2 = GetMeterCoords(lod, ll2);
            var rv = DistanceV2d(p1, p2);
            return rv;
        }
        public static Vector2Int GetVector2IntPixelCoords(int levelofDetail, double lat, double lng)
        {
            TileSystem.LatLongToPixelXY(lat, lng, levelofDetail, out var pixx, out var pixy);
            var rv = new Vector2Int(pixx, pixy);
            return rv;
        }
        public static Vector2d GetMeterCoords(int levelofDetail, double lat, double lng)
        {
            TileSystem.LatLongToPixelXYdouble(lat, lng, levelofDetail, out double pixx, out double pixy);
            var faklng = TileSystem.GroundResolution(lat, levelofDetail);
            var faklat = TileSystem.GroundResolution(0, levelofDetail);
            //faklng = 1;
            //faklat = 1;
            var rv = new Vector2d(pixx * faklng, pixy * faklat);
            return rv;
        }
        public static Vector2d GetMeterCoords(int levelofDetail, LatLng ll)
        {
            var rv = GetMeterCoords(levelofDetail, ll.lat, ll.lng);
            return rv;
        }
        public static LatLng GetLatLngOffSetPixel(int levelofDetail, LatLng ll, Vector2Int pixoff)
        {
            var pixll = GetV2iPixelCoordFromLatLng(levelofDetail, ll);
            var rvpix = pixll + pixoff;
            var rvll = GetLngLatFromPixelCoords(levelofDetail, rvpix);
            return rvll;
        }
        public static LatLng GetLatLngOffSetMeter(int levelofDetail, LatLng ll, Vector2d metoff)
        {
            var rvll = GetLatLngOffSetMeter(levelofDetail, ll, metoff.x, metoff.y);
            return rvll;
        }
        public static LatLng GetLatLngOffSetMeter(int levelofDetail, LatLng ll, double metoffx, double metoffy)
        {
            var pixll = GetV2iPixelCoordFromLatLng(levelofDetail, ll);
            var groundres = TileSystem.GroundResolution(ll.lat, levelofDetail);
            var pixoff = new Vector2Int((int)(metoffx / groundres), (int)(metoffy / groundres));
            var rvpix = pixll + pixoff;
            var rvll = GetLngLatFromPixelCoords(levelofDetail, rvpix);
            return rvll;
        }
        public static (double, double) GetLatLngDeltInMeters(LatLng ll, double latdelt, double lngdelt)
        {
            var earthcirum = 40075016.63;// 40mm
            var latrad = Math.Cos(Math.PI * ll.lat / 180.0) * earthcirum;
            var latoffsetmeters = earthcirum * lngdelt / 360;
            var lngoffsetmeters = latrad * latdelt / 360;
            return (latoffsetmeters, lngoffsetmeters);
        }
        public static Vector2d GetLatLngDeltInMeters(LatLng ll, LatLngVek delt)
        {
            var earthcircum = 40075016.63;// 40mm
            var latrad = Math.Cos(Math.PI * ll.lat / 180.0) * earthcircum;
            var latoffsetmeters = earthcircum * delt.lng / 360;
            var lngoffsetmeters = latrad * delt.lat / 360;
            var (dlat, dlng) = GetLatLngDeltInMeters(ll, delt.lat, delt.lng);
            var rv = new Vector2d(dlng, dlat);
            return rv;
        }
        public static Vector2Int GetV2iPixelCoordFromLatLng(int levelofDetail, LatLng ll)
        {
            return GetVector2IntPixelCoords(levelofDetail, ll.lat, ll.lng);
        }
        public static LatLng GetLngLatFromPixelCoords(int levelofDetail, int pixx, int pixy)
        {
            TileSystem.PixelXYToLatLong(pixx, pixy, levelofDetail, out var lat, out var lng);
            var rv = new LatLng(lat, lng);
            return rv;
        }
        public static LatLng GetLngLatFromPixelCoords(int levelofDetail, Vector2Int vip)
        {
            return GetLngLatFromPixelCoords(levelofDetail, vip.x, vip.y);
        }
        public static LatLng GetLngLatFromV2iPixelCoords(int levelofDetail, Vector2Int vpix)
        {
            return GetLngLatFromPixelCoords(levelofDetail, vpix.x, vpix.y);
        }
        public Vector2Int GetPixelCoords(int LevelOfDetail)
        {
            return GetVector2IntPixelCoords(LevelOfDetail, lat, lng);
        }
        public Vector2d GetMeterCoords(int LevelOfDetail)
        {
            return GetMeterCoords(LevelOfDetail, lat, lng);
        }
        public static LatLngVek operator -(LatLng ll1, LatLng ll2)
        {
            var lat = ll1.lat - ll2.lat;
            var lng = ll1.lng - ll2.lng;
            var rv = new LatLngVek(lat, lng, "difference of two LatLngs");
            return rv;
        }

        public static LatLng operator +(LatLng ll1, LatLngVek lv2)
        {
            var lat = ll1.lat + lv2.lat;
            var lng = ll1.lng + lv2.lng;
            var rv = new LatLngVek(lat, lng, "difference of two LatLngs");
            return rv;
        }
        public static LatLng operator +(LatLngVek lv1, LatLng ll2)
        {
            var lat = lv1.lat + ll2.lat;
            var lng = lv1.lng + ll2.lng;
            var rv = new LatLngVek(lat, lng, "difference of two LatLngs");
            return rv;
        }
    }

    [System.Serializable]
    public class LatLngVek : LatLng
    {
        public LatLngVek(double lat, double lng, string name = "") : base(lat, lng, name)
        {
        }
        public static LatLng operator +(LatLng ll1, LatLngVek lv2)
        {
            var lat = ll1.lat + lv2.lat;
            var lng = ll1.lng + lv2.lng;
            LatLngVek rv = new LatLngVek(lat, lng, "sum of LatLng and LatLngVek");
            return rv;
        }

        public static LatLngVek operator +(LatLngVek lv1, LatLngVek lv2)
        {
            var lat = lv1.lat + lv2.lat;
            var lng = lv1.lng + lv2.lng;
            LatLngVek rv = new LatLngVek(lat, lng, "sum of LatLngVek and LatLngVek");
            return rv;
        }
        public static LatLngVek operator -(LatLngVek lv1, LatLngVek lv2)
        {
            var lat = lv1.lat - lv2.lat;
            var lng = lv1.lng - lv2.lng;
            LatLngVek rv = new LatLngVek(lat, lng, "difference of LatLngVek and LatLngVek");
            return rv;
        }

        public static LatLngVek operator *(float fak, LatLngVek lv1)
        {
            var lat = fak * lv1.lat;
            var lng = fak * lv1.lng;
            LatLngVek rv = new LatLngVek(lat, lng, "scaled LatLngVek");
            return rv;
        }
        public static double DoubleDistance(Vector3d v1, Vector3d v2)
        {
            var dv = new Vector3d(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
            var dst = Math.Sqrt(dv.x * dv.x + dv.y * dv.y + dv.z * dv.z);
            return dst;
        }

    }


    [System.Serializable]
    public class LatLngBox
    {
        public string name;
        public int lod;
        public string boxSpec = "";
        public bool hasMidDefinitions = false;
        public LatLng maxll = null;
        public LatLng minll = null;
        public LatLng midll = null;
        public LatLng orgll = null;

        public LatLngVek extent = null;

        public float groundMetersPerPixel = 0;
        public float diagonalInMeters = 0;
        public Vector2 extentMetersBadEstimate = Vector2.zero;
        public Vector2 extentMeters1 = Vector2.zero;
        public Vector2 extentPixels = Vector2.zero;

        Vector2Int pixbl;
        Vector2Int pixbr;
        Vector2Int pixul;
        Vector2Int pixur;

        Vector2d metbl;
        Vector2d metbr;
        Vector2d metul;
        Vector2d metur;
        public LatLngBox(LatLng ll1, LatLng ll2, string name = "llbox", int lod = 16, LatLng org = null)
        {
            Initialize(ll1, ll2, name, lod, org);
        }
        Vector3d diff3d(Vector3d d1, Vector3d d2)
        {
            var rv = new Vector3d(d1.x - d2.x, d1.y - d2.y, d1.z - d2.z);
            return rv;
        }
        string diff2d(Vector2d d1, Vector2d d2)
        {
            var v = new Vector2d(d1.x - d2.x, d1.y - d2.y);
            var rs = $"({v.x.ToString("f6")},{v.y.ToString("f6")}";
            return rs;
        }
        public void Initialize(LatLng ll1, LatLng ll2, string name = "llbox", int lod = 16, LatLng org = null)
        {
            this.name = name;
            this.lod = lod;
            var latmin = System.Math.Min(ll1.lat, ll2.lat);
            var lngmin = System.Math.Min(ll1.lng, ll2.lng);
            minll = new LatLng(latmin, lngmin);
            var latmax = System.Math.Max(ll1.lat, ll2.lat);
            var lngmax = System.Math.Max(ll1.lng, ll2.lng);
            maxll = new LatLng(latmax, lngmax);
            var latmid = (latmin + latmax) / 2;
            var lngmid = (lngmin + lngmax) / 2;
            midll = new LatLng(latmid, lngmid);
            orgll = (org == null ? midll : org);

            groundMetersPerPixel = (float)TileSystem.GroundResolution(latmid, lod);
            extent = maxll - minll;
            var p1 = ll1.GetMeterCoords(lod);
            var p2 = ll2.GetMeterCoords(lod);
            diagonalInMeters = (float)LatLng.DistanceV2d(p1, p2);
            pixbl = GetBottomLeft().GetPixelCoords(lod);
            pixbr = GetBottomRight().GetPixelCoords(lod);
            pixul = GetUpperLeft().GetPixelCoords(lod);
            pixur = GetUpperRight().GetPixelCoords(lod);
            var op = pixul;
            //        Debug.Log($"pix bl:{pixbl-op} br:{pixbr-op} ul:{pixul-op} ur:{pixur-op}");
            var dpx = (Vector2.Distance(pixbl, pixbr) + Vector2.Distance(pixul, pixur)) / 2;
            var dpy = (Vector2.Distance(pixul, pixbl) + Vector2.Distance(pixur, pixbr)) / 2;// long live symmetry

            extentPixels = new Vector2(dpx, dpy);
            metbl = GetBottomLeft().GetMeterCoords(lod);
            metbr = GetBottomRight().GetMeterCoords(lod);
            metul = GetUpperLeft().GetMeterCoords(lod);
            metur = GetUpperRight().GetMeterCoords(lod);
            var om = metbl;
            //        Debug.Log($"met bl:{diff2d(metbl,om)} br:{diff2d(metbr,om)} ul:{diff2d(metul,om)} ur:{diff2d(metur,om)}");
            var dmx = (LatLng.DistanceV2d(metbl, metbr) + LatLng.DistanceV2d(metul, metur)) / 2;
            var d1 = LatLng.DistanceV2d(metul, metbl);
            var d2 = LatLng.DistanceV2d(metur, metbr);
            var dmy = (LatLng.DistanceV2d(metul, metbl) + LatLng.DistanceV2d(metur, metbr)) / 2;// long live symmetry
            extentMetersBadEstimate = new Vector2((float)dmx, (float)dmy);
            extentMeters1 = groundMetersPerPixel * extentPixels;
            boxSpec = $"{latmin:f8},{lngmin:f8}, {latmax:f8},{lngmax:f8}";
        }
        public LatLngBox(LatLng llorg, double latExtentKm, double lngExtentKm, string name = "llbox", int lod = 16)
        {
            var ofs = new Vector2d((1000 * lngExtentKm / 2), (1000 * latExtentKm / 2));
            var mofs = new Vector2d(-ofs.x, -ofs.y);
            var ll1 = LatLng.GetLatLngOffSetMeter(lod, llorg, mofs);
            var ll2 = LatLng.GetLatLngOffSetMeter(lod, llorg, ofs);
            Initialize(ll1, ll2, name, lod, org: llorg);
        }
        public (int,int) GetTileSizeOld(int pixperqktile=256)
        {
            var nx = pixbr.x - pixbl.x;
            var ny = pixbr.y - pixur.y;
            var nqkx = (nx / pixperqktile) + 1;
            var nqky = (ny / pixperqktile) + 1;
            //Debug.Log($"GetTileSizeOld pixbr:{pixbr}  pixbl:{pixbl}  pixur:{pixur}");
            //Debug.Log($"GetTileSizeOld nx:{nx} nqkx:{nqkx}     ny:{ny} nqky:{nqky}");
            var rv = (nqkx,nqky);
            return rv;
        }
        public (int, int) GetTileSize(int pixperqktile = 256)
        {
            //// oldway
            ////var nx = pixbr.x - pixbl.x;
            ////var ny = pixbr.y - pixur.y;
            ////var nqkx = (nx / pixperqktile) + 1;
            ////var nqky = (ny / pixperqktile) + 1;

            // new way
            var nqkx = ((pixbr.x/pixperqktile) - (pixbl.x/pixperqktile)) + 1;
            var nqky = ((pixbr.y/pixperqktile) - (pixur.y/pixperqktile)) + 1;

            //var t1x = pixbr.x / pixperqktile;
            //var t2x = pixbl.x / pixperqktile;
            //var t1y = pixbr.y / pixperqktile;
            //var t2y = pixur.y / pixperqktile;
            //var pixh = pixbr.y - pixur.y;
            //var pixw = pixbr.x - pixbl.x;
            //Debug.Log($"GetTileSize pixbr:{pixbr}  pixbl:{pixbl}  pixur:{pixur}   pixh:{pixh} pixw:{pixw}");
            //Debug.Log($"GetTileSize t1x:{t1x} t2x:{t2x} nqkx:{nqkx}     t1y:{t1y} t2y:{t2y} nqky:{nqky}");

            var rv = (nqkx, nqky);
            return rv;
        }

        public (float, float) GetLambdaCoords(LatLng ll)
        {
            var pixll = ll.GetPixelCoords(lod);
            var xmin = Math.Min(pixul.x, pixbl.x);
            var ymax = Math.Max(pixbl.y, pixbr.y);
            var lambx = (float)((pixll.x - xmin) / extentPixels.x);
            var lamby = (float)((ymax - pixll.y) / extentPixels.y);
            return (lambx, lamby);
        }
        public LatLng Interpolate(float lambLat, float lambLng)
        {
            var rv = new LatLng((float)((lambLat * extent.lat) + minll.lat), (float)((lambLng * extent.lng) + minll.lng));
            return rv;
        }
        public (float, float) Interpolate(LatLng ll)
        {
            var lamblat = (ll.lat - minll.lat) / extent.lat;
            var lamblng = (ll.lng - minll.lng) / extent.lng;
            return ((float)lamblng, (float)lamblat);
        }
        public LatLng GetUpperLeft()
        {
            return new LatLng(maxll.lat, minll.lng, name + "-ul");
        }
        public LatLng GetBottomRight()
        {
            return new LatLng(minll.lat, maxll.lng, name + "-br");
        }
        public LatLng GetUpperRight()
        {
            return new LatLng(maxll, name + "-ur");
        }
        public LatLng GetBottomLeft()
        {
            return new LatLng(minll, name + "-bl");
        }
        public LatLng GetMidPoint()
        {
            LatLng rv = null;
            if (this.hasMidDefinitions)
            {
                rv = new LatLng(orgll, "orgll");
            }
            else
            {
                rv = new LatLng(midll, name + "-mp");
            }
            return rv;
        }
        public Vector2Int GetPixelUpperLeft(int lod)
        {
            var rv = LatLng.GetVector2IntPixelCoords(lod, maxll.lat, minll.lng);
            return rv;
        }
        public Vector2Int GetPixelBottomLeft(int lod)
        {
            var rv = LatLng.GetVector2IntPixelCoords(lod, minll.lat, minll.lng);
            return rv;
        }
        public Vector2Int GetPixelBottomRight(int lod)
        {
            var rv = LatLng.GetVector2IntPixelCoords(lod, minll.lat, maxll.lng);
            return rv;
        }
        public Vector2Int GetPixelUpperRight(int lod)
        {
            var rv = LatLng.GetVector2IntPixelCoords(lod, maxll.lat, maxll.lng);
            return rv;
        }
        public Vector2Int GetPixelSize(int lod)
        {
            var size = GetPixelBottomRight(lod) - GetPixelUpperLeft(lod) + new Vector2Int(1, 1);
            return size;
        }
        public bool IsIn(LatLng ll)
        {
            if (ll.lat < minll.lat) return false;
            if (maxll.lat < ll.lat) return false;
            if (ll.lng < minll.lng) return false;
            if (maxll.lng < ll.lng) return false;
            return true;
        }
        public bool IsSubset(LatLngBox box)
        {
            if (!IsIn(box.minll)) return false;
            if (!IsIn(box.maxll)) return false;
            return true;
        }
        public override string ToString()
        {
            var fmt = "f6";
            var m = "";
            m += "latmin:" + minll.lat.ToString(fmt);
            m += " max:" + maxll.lat.ToString(fmt);
            m += "lngmin:" + minll.lng.ToString(fmt);
            m += " max:" + maxll.lng.ToString(fmt);
            return m;
        }
        public Tuple<int, int> GetPixelSize()
        {

            return new Tuple<int, int>(1, 2);
        }
    }


    [System.Serializable]
    public class CrdMap
    {
        public double a;
        public double b1;
        public double b2;
        public double rmserr;
        public double r2;
        public string formula;

        public CrdMap()
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
        public double Map(double x1, double x2)
        {
            var d = a + b1 * x1 + b2 * x2;
            return d;
        }
        public override string ToString()
        {
            return formula;
        }
    }

    [System.Serializable]
    public class MapCoordPoint
    {
        public double lng;
        public double lat;
        public double x;
        public double z;
        public double lnghat;
        public double lathat;
        public double xhat;
        public double zhat;
        public double Val(string vname)
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
        public void SetVal(string vname, double val)
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
    public class MapCoordblock
    {
        double Sqr(double x) => x * x;
        double Sqrt(double x) => System.Math.Sqrt(x);
        public List<MapCoordPoint> mapdata = new List<MapCoordPoint>();
        LatLongMap llm;
        public MapCoordblock(LatLongMap llm)
        {
            this.llm = llm;
        }
        //public void AddRowLatLng(double lng, double lat, double x, double z)
        //{
        //    mapdata.Add(new MapCoordPoint { lng = lng, lat = lat, x = x, z = z });
        //}
        public void AddRowLatLng(double dlat, double dlng, double dx, double dz)
        {
            mapdata.Add(new MapCoordPoint { lng = dlng, lat = dlat, x = dx, z = dz });
        }
        public int Count()
        {
            return mapdata.Count;
        }
        public void AddRowLngLat(LatLng ll, int lod, double pixToMeters, Vector2d org)
        {
            TileSystem.LatLongToPixelXY(ll.lat, ll.lng, lod, out var pixx, out var pixz);
            var x = pixx * pixToMeters - org.x;
            var z = pixz * pixToMeters - org.y;
            mapdata.Add(new MapCoordPoint { lng = ll.lng, lat = ll.lat, x = z, z = x });
        }
        public CrdMap DoRegression(string formula)
        {
            // split on + then trim leading and trailing whitespace
            char[] spar = { '=', '+' };
            var vnames = new List<string>(formula.Split(spar).Select(x => x.Trim()));

            var mu = new Dictionary<string, double>();

            //Debug.Log("DoRegression mapdata:" + mapdata.Count);
            if (mapdata.Count <= 1)
            {
                throw new UnityException($"Not enough data for regression num points:{mapdata.Count} formula:{formula}");
            }

            vnames.ForEach(v => mu[v] = mapdata.Select(x => x.Val(v)).Average());

            var covar = new Dictionary<string, double>();
            vnames.ForEach(v1 =>
                vnames.ForEach(v2 =>
                   covar[$"{v1},{v2}"] = mapdata.Select(x => (x.Val(v1) - mu[v1]) * (x.Val(v2) - mu[v2])).Sum())
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
            mapdata.ForEach(x => x.SetVal(vyh, a + b1 * x.Val(vx1) + b2 * x.Val(vx2)));
            mu[vyh] = mapdata.Select(x => x.Val(vyh)).Average();
            var varyhat = mapdata.Select(x => Sqr(x.Val(vyh) - mu[vyh])).Sum();
            var vary = covar[$"{vy},{vy}"];
            var r2 = varyhat / vary;
            var rmserr = Sqrt(mapdata.Select(x => Sqr(x.Val(vy) - x.Val(vyh))).Sum());
            var rv = new CrdMap
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
        public Vector3 glbmap(double x, double y, double z)
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
            var rv = new Vector3((float)gx, (float)y, (float)gz);
            return (rv);
        }

        public Vector3 glbunmap(double gx, double gy, double gz)
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
            var rv = new Vector3((float)x, (float)gy, (float)z);
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
        public GameObject MakeMarkers(string coordsys, float ska = 1, string clr = "purple",bool wps=true)
        {
            var sphholder = new GameObject();
            // sphholder.transform.parent = llm.transform; // llm no longer monobehavior
            sphholder.name = coordsys;
            int i = 0;
            foreach (var md in mapdata)
            {
                var sph = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sph.name = coordsys + "Marker " + i;
                sph.transform.localScale = new Vector3(ska, ska, ska);
                double x = 0;
                double z = 0;
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
                sph.transform.position = new Vector3((float)x, 0, (float)z);
                sph.transform.SetParent(sphholder.transform,worldPositionStays:wps);
                var spi = sph.AddComponent<QsphInfo>();
                spi.latLng = new LatLng(md.lat, md.lng);
                spi.mapPoint = md;
                qut.SetColorOfGo(sph, clr);
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
        public GameObject MakeNativeCoordMarkers(float ska = 1, string clr = "purple", bool wps=true)
        {
            nativego = MakeMarkers("Native", ska, clr: clr, wps: wps);
            return nativego;
        }
        public GameObject MakeLongLatCoordMarkers(float ska = 1, string clr = "cyan", bool wps = true)
        {
            lgnlatgo = MakeMarkers("LongLat", ska, clr: clr, wps: wps);
            return lgnlatgo;
        }
    }

    [System.Serializable]
    public class LongLatMapSet
    {
        public CrdMap latmap;
        public CrdMap lngmap;
        public CrdMap xmap;
        public CrdMap zmap;
    }

    public class LatLongMap 
    {

        public MapCoordblock mapcoord;
        public LongLatMapSet maps = new LongLatMapSet();
        public bool makeNativeSpheres = false;
        bool nativeSpheresMade = false;
        public bool makeLngLatSpheres = false;
        bool lnglatSpheresMade = false;

        public LatLongMap glbllm = null;
        public bool isInited = false;
        public bool isOk = false;
        public string initmethod = "unknown";
        public string origin = "unknown";
        // Use this for initialization

        public LatLongMap(string origin)
        {
            this.origin = origin;
        }

        public Vector3 xycoord(double lng, double lat)
        {
            // backwards because I specified the forumla wrong
            var x = maps.xmap.Map(lng, lat);
            var z = maps.zmap.Map(lng, lat);
            var rv = new Vector3((float)x, 0, (float)z);
            return rv;
        }
        public Vector2 llcoord(double x, double z)
        {
            var lat = maps.latmap.Map(x, z);
            var lng = maps.lngmap.Map(x, z);
            var rv = new Vector2((float)lat, (float)lng);
            return rv;
        }
        public void AddRowLatLng(double lat,double lng, double x, double z)
        {
            mapcoord.AddRowLatLng(lat,lng,x,z);
        }
        public void CalcRegressionMaps()
        {
            maps.latmap = mapcoord.DoRegression("lat = x + z");
            maps.lngmap = mapcoord.DoRegression("lng = x + z");
            maps.xmap = mapcoord.DoRegression("x = lng + lat");
            maps.zmap = mapcoord.DoRegression("z = lng + lat");
            isInited = true;
        }
        public void InitMapCoords(string dataSetName="")
        {
            mapcoord = new MapCoordblock(this);
            var ok = false;
            switch (dataSetName)
            {
                case "Bld43":
                    AddRowLatLng(47.640490, -122.133797, -149.1, 0.2);
                    AddRowLatLng(47.639079, -122.134960, 28.0, -31.4);
                    AddRowLatLng(47.638526, -122.134519, 75.4, 19.9);
                    AddRowLatLng(47.639368, -122.133926, -29.4, 30.8);
                    AddRowLatLng(47.641066, -122.136018, -155.44, -177.96);
                    ok = true;
                    break;
                case "BldRWB":
                    double xadj = 10.5;
                    double zadj = 3.0;
                    AddRowLatLng(47.660078, -122.140175, 72.70 + xadj, 4.77 + zadj);// upper left
                    AddRowLatLng(47.659377, -122.140189, -5.35 + xadj, 4.77 + zadj);// lower left
                    AddRowLatLng(47.660150, -122.139328, 81.23 + xadj, -59.70 + zadj);// upper right
                    AddRowLatLng(47.659457, -122.139339, 3.18 + xadj, -59.70 + zadj);// lower right
                    ok = true;
                    break;
                case "test":
                    AddRowLatLng(1, 1, 40, 25);
                    AddRowLatLng(2, 2, 45, 20);
                    AddRowLatLng(1, 1, 38, 30);
                    AddRowLatLng(3, 3, 50, 30);
                    AddRowLatLng(2, 2, 48, 28);

                    AddRowLatLng(3, 3, 55, 30);
                    AddRowLatLng(3, 3, 53, 34);
                    AddRowLatLng(4, 4, 55, 36);
                    AddRowLatLng(4, 4, 58, 32);
                    AddRowLatLng(3, 3, 40, 34);

                    AddRowLatLng(5, 5, 55, 38);
                    AddRowLatLng(3, 3, 48, 28);
                    AddRowLatLng(3, 3, 45, 30);
                    AddRowLatLng(2, 2, 55, 36);
                    AddRowLatLng(4, 4, 60, 34);

                    AddRowLatLng(5, 5, 60, 38);
                    AddRowLatLng(5, 5, 60, 42);
                    AddRowLatLng(5, 5, 65, 38);
                    AddRowLatLng(4, 4, 50, 34);
                    AddRowLatLng(3, 3, 58, 38);
                    ok = true;
                    break;
                default:
                    return;
            }
            //sman = Object.FindO            SphInfo.DoInfoSphere(ranpoints, name, pos, ska, clrs[istat]);nativebjectOfType<SceneMan>();
            //glbllm = sman.GetComponent<LatLongMap>();
            CalcRegressionMaps();
            initmethod = $"InitMapCoords(\"{dataSetName}\")";
            isInited = true;
            isOk = ok;
        }

        public void InitMapFromSceneSelString(string regsel)
        {
            mapcoord = new MapCoordblock(this);
            bool ok = false;
            switch (regsel)
            {
                case "MsftRedwest":
                case "MsftCoreCampus":
                case "MsftB19focused":
                case "MsftB121focused":
                    // current calibration points

                    ////mapcoord.AddRowLatLng(47.65945816, -122.14133453, -1960.446 + 8.31, -1217.206 + 7.53);
                    //mapcoord.AddRowLatLng(47.65945816, -122.14133453, 0,0);

                    mapcoord.AddRowLatLng(47.640490, -122.133797, -149.1, 0.2);
                    mapcoord.AddRowLatLng(47.639079, -122.134960, 28.0, -31.4);
                    mapcoord.AddRowLatLng(47.638526, -122.134519, 75.4, 19.9);
                    mapcoord.AddRowLatLng(47.639368, -122.133926, -29.4, 30.8);
                    mapcoord.AddRowLatLng(47.641066, -122.136018, -155.44, -177.96);
                    ok = true;
                    break;
                case "Eb12":
                case "Eb12small":
                    mapcoord.AddRowLatLng(49.993313, 8.678353, 0, 0);          // eb12 origin streetlamp     
                    mapcoord.AddRowLatLng(49.993472, 8.677981, 18.45, 27.90);   // eb12-12 doorway
                    mapcoord.AddRowLatLng(49.995560, 8.676101, 260.80, 167.7); // SW corner of Rewe
                    mapcoord.AddRowLatLng(49.995788, 8.676752, 287.25, 118.35); //SE corner of Rewe
                    ok = true;
                    break;
                case "MsftDublin":
                    mapcoord.AddRowLatLng(53.268396, -6.195296, -103.5, 75.2);
                    //mapcoord.AddRowLatLng(53.269369, -6.196511, -12.4, -47.8);
                    mapcoord.AddRowLatLng(53.269411, -6.196603, -7.6, -44.7);
                    mapcoord.AddRowLatLng(53.269212, -6.194816, -139.0, -27.5);
                    mapcoord.AddRowLatLng(53.266725, -6.190259, -426.5, 252.1); // corner of curved building in golf club
                    mapcoord.AddRowLatLng(53.268040, -6.199236,  172.9, 104.8); // corner of One Microsoft
                    mapcoord.AddRowLatLng(53.268998, -6.196680,  0.0, 0.0);
                    ok = true;
                    break;
                case "TukSouCen":
                    mapcoord.AddRowLatLng(47.457029, -122.258709, -8.1, -6.53);   // parelligram island south west (lower-left)
                    mapcoord.AddRowLatLng(47.457126, -122.258634, -13.73, -17.8); // parelligram island north east (upper-right)
                    mapcoord.AddRowLatLng(47.459879, -122.261197, 180.4, -323.5); // parelligram island north east (upper-right)
                    //mapcoord.AddRowLatLng(47.457029, -122.258709, -6.53, 8.1);   // parelligram island south west (lower-left)
                    //mapcoord.AddRowLatLng(47.457126, -122.258634, -17.8, 13.73); // parelligram island north east (upper-right)
                    //mapcoord.AddRowLatLng(47.459879, -122.261197, -323.5, -180.4 ); // parelligram island north east (upper-right)
                    ok = true;
                    break;
                default:
                    Debug.LogError($"LatrLongMap.InitMapFromSceneSelString tried to init from unknown id:{regsel}");
                    break;
            }
            glbllm = this;
            //maps.latmap = mapcoord.DoRegression("lat = x + z");
            //maps.lngmap = mapcoord.DoRegression("lng = x + z");
            //maps.xmap = mapcoord.DoRegression("x = lng + lat");// backwards, should do something about it someday
            //maps.zmap = mapcoord.DoRegression("z = lng + lat");
            if (ok)
            {
                CalcRegressionMaps();
            }
            isInited = true;
            isOk = ok;
            initmethod = $"InitMapFromSceneSelString(\"{regsel}\") ok:{ok}";
        }


        public void InitMapFromLatLongBox(LatLngBox latLngBox, int lod)
        {
            mapcoord = new MapCoordblock(this);
            var llbl = latLngBox.GetBottomLeft();
            var llul = latLngBox.GetUpperLeft();
            var llbr = latLngBox.GetBottomRight();
            var llur = latLngBox.GetUpperRight();
            var llmp = latLngBox.GetMidPoint();
            var pixToMeters = TileSystem.GroundResolution(llmp.lat, lod);
            //var orgpix = llbl.GetPixelCoords(lod);
            var orgpix = llmp.GetPixelCoords(lod);
            var orgmeters = new Vector2d(orgpix.x * pixToMeters, orgpix.y * pixToMeters);
            mapcoord.AddRowLngLat(llbl, lod, pixToMeters, orgmeters);
            mapcoord.AddRowLngLat(llul, lod, pixToMeters, orgmeters);
            mapcoord.AddRowLngLat(llbr, lod, pixToMeters, orgmeters);
            mapcoord.AddRowLngLat(llur, lod, pixToMeters, orgmeters);
            mapcoord.AddRowLngLat(llmp, lod, pixToMeters, orgmeters);
            glbllm = this;
            //maps.latmap = mapcoord.DoRegression("lat = x + z");
            //maps.lngmap = mapcoord.DoRegression("lng = x + z");
            //maps.xmap = mapcoord.DoRegression("x = lng + lat");
            //maps.zmap = mapcoord.DoRegression("z = lng + lat");
            CalcRegressionMaps();
            isInited = true;
            isOk = true;
            initmethod = $"InitMapFromLatLongBox(\"{latLngBox.boxSpec}\",lod:{lod})";
        }

        // Update is called once per frame
        void Update()
        {
            if (makeNativeSpheres && !nativeSpheresMade)
            {
                mapcoord.MakeNativeCoordMarkers(wps:false);
                nativeSpheresMade = true;
            }
            if (!makeNativeSpheres && nativeSpheresMade)
            {
                mapcoord.DestroyNativeCoordMarkers();
                nativeSpheresMade = false;
            }


            if (makeLngLatSpheres && !lnglatSpheresMade)
            {
                mapcoord.MakeLongLatCoordMarkers(wps: false);
                lnglatSpheresMade = true;
            }
            if (!makeLngLatSpheres && lnglatSpheresMade)
            {
                mapcoord.DestroLngLatCoordMarkers();
                lnglatSpheresMade = false;
            }
        }
    }
}