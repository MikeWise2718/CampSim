using UnityEngine;
using Microsoft.MapPoint;


namespace Aiskwk.Map
{
    [System.Serializable]
    public class QkTile
    {
        public string name;
        public int lod;
        public int xidx;
        public int yidx;
        public Vector2Int pixul;
        public Vector2Int pixbr;
        public LatLng llul;
        public LatLng llbr;
        public LatLngBox box;
        public int pixpertile;
        public QkTile(int lod, int xidx, int yidx, int pixpertile = 256)
        {
            this.lod = lod;
            this.xidx = xidx;
            this.yidx = yidx;
            this.name = TileSystem.TileXYToQuadKey(xidx, yidx, lod);
            this.pixpertile = pixpertile;
            Initialize();
        }
        public QkTile(string qkname, int pixpertile = 256)
        {
            this.name = qkname;
            TileSystem.QuadKeyToTileXY(qkname, out xidx, out yidx, out lod);
            this.pixpertile = pixpertile;
            Initialize();
        }
        public void Initialize()
        {
            TileSystem.TileXYToPixelXY(xidx, yidx, out var _pix_ul, out var _pixy_ul);
            this.pixul = new Vector2Int(_pix_ul, _pixy_ul);
            this.pixbr = new Vector2Int(_pix_ul + pixpertile - 1, _pixy_ul + pixpertile - 1);
            this.llul = LatLng.GetLngLatFromV2iPixelCoords(lod, this.pixul);
            this.llul.name = "Qktile UpperLeft";
            this.llbr = LatLng.GetLngLatFromV2iPixelCoords(lod, this.pixbr);
            this.llbr.name = "Qktile BottomRight";
            this.box = new LatLngBox(llul, llbr, lod: lod);
        }
        public static QkTile GetQktileFromLatLng(LatLng ll, int lod)
        {
            TileSystem.LatLongToPixelXY(ll.lat, ll.lng, lod, out var pixx, out var pixy);
            var vi = new Vector2Int(pixx, pixy);
            var rv = GetQktileFromPix(vi, lod);
            return rv;
        }
        public static QkTile GetQktileFromPix(Vector2Int pix, int lod)
        {
            TileSystem.PixelXYToTileXY(pix.x, pix.y, out var xidx, out var yidx);
            var rv = new QkTile(lod, xidx, yidx);
            return rv;
        }
    }
}