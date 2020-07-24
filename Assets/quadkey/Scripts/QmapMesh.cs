using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Aiskwk.Dataframe;

namespace Aiskwk.Map
{
    [System.Serializable]
    public class QkmeshStatistics
    {
        public LatLngBox llbox;
        public MapExtentTypeE extent;
        public float areaSqkm = 0;
        public float diagonalKm = 0;
        public float widthKm = 0;
        public float heightKm = 0;
        public float widthPix = 0;
        public float heightPix = 0;
        public float textWidthPix = 0;
        public float textHeighthPix = 0;
        public float textMbytes = 0;
        public Vector2Int pixul;
        public Vector2Int pixur;
        public Vector2Int pixbl;
        public Vector2Int pixbr;
        public Vector2Int nqktiles;
        public Vector3 meshDeltaMeters = Vector3.zero;
        public QkmeshStatistics()
        {
        }
        public void CalcValues(LatLngBox box,MapExtentTypeE extent,Vector2Int nqk)
        {
            this.extent = extent;
            diagonalKm = box.diagonalInMeters / 1000.0f;
            widthKm = (float)box.extentMeters1.x / 1000.0f;
            heightKm = (float)box.extentMeters1.y / 1000.0f;
            widthPix = (float)box.extentPixels.x;
            heightPix = (float)box.extentPixels.y;
            areaSqkm = widthKm * heightKm;
            pixul = box.GetPixelUpperLeft(box.lod);
            pixur = box.GetPixelUpperRight(box.lod);
            pixbl = box.GetPixelBottomLeft(box.lod);
            pixbr = box.GetPixelBottomRight(box.lod);
            llbox = box;
            nqktiles = nqk;
        }
    }

    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class QmapMesh : MonoBehaviour
    {
        // Derived from https://wiki.unity3d.com/index.php/MeshCreationGrid
        public string descriptor;

        [Header("Providers")]
        public MapProvider mapprov;
        public ElevProvider elevprov;

        [Header("Statistics")]
        public QkmeshStatistics stats = new QkmeshStatistics();

        [Header("Map Tesellation")]
        public MapExtentTypeE mapExtent = MapExtentTypeE.SnapToTiles;
        public MeshSizeMethodE meshSizeMethod = MeshSizeMethodE.TilesPerQk;
        public int secsPerQkTile = 4;
        public int nHorzSecs = 12;
        public int nVertSecs = 12;
        public int nMeshes = 1;
        public int nHorzSecsPerMesh = 12;
        public int nVertSecsPerMesh = 12;
        public int maxVertsPerMesh = 5000;
        public bool limitQuadkeys = true;
        public Vector3 lambdaOrg = new Vector3(0.0f, 0, 0.0f);

        public string scenename;
        public string mapcoordname;
        public int levelOfDetail = 0;
        public int nQks = 0;

        [Header("Elevations")]
        [Range(0f, 10f)]
        public float hmult = 1;
        //public HeightTypeE heightType = HeightTypeE.Fetched;
        public HeightSource heightSource = HeightSource.Fetched;
        public HeightAdjust heightAdjust = HeightAdjust.Zeroed;
        public bool useElevationData;
        public QmapElevation qmapElev = null;
        public bool flatTriangles = false;
        public NormalAvgMethod normmethod = NormalAvgMethod.Avg;
        public int nElevSamples = 0;

        [Header("Garnish")]
        public bool regenMesh;
        public bool regenMeshNormals;
        public bool addViewer = true;
        public ViewerState viewHome = null;
        public enum sythTexMethod { Quadkeys, Synth, Hybrid }
        public sythTexMethod synthTex = sythTexMethod.Quadkeys;
        public string synthSpec = "goldenrod";
        public LayerMan layerman;
        public bool addMeshColliders = false;

        [Range(0.11f, 5f)]
        public float nodefak = 0.2f;

        [Header("Files")]
        public bool deleteSceneData;

        [Header("Misc")]
        public QkMan qkm = null;
        public Qtrilines qtt = null;
        public LatLongMap llmapqkcoords = null;
        public LatLongMap llmapuscoords = null;
        public LatLongMap llmapyacoords = null;

        int updcount = 0;
        MapExtentTypeE old_mapExtent;
        bool old_useElevationData;
        bool old_flatTris;
        bool old_addViewer;
        bool old_addMeshColliders;
        sythTexMethod old_synthTex;
        int old_maxVertsPerMesh;
        float old_hmult;
        float old_nodefak;
        int old_lod;
        int old_secsPerQkTile;
        NormalAvgMethod old_normmethod;
        MapProvider old_mappprov;
        //HeightTypeE old_heightType;
        HeightSource old_heightSource;
        HeightAdjust old_heightAdjust;

        bool initializationComplete = false;

        public void DisposeOfThings()
        {
            QMeshDestroyViewer();
        }

        public bool CheckWebReleventChange()
        {
            var chg = old_lod != levelOfDetail ||
                      old_secsPerQkTile != secsPerQkTile;
            if (updcount == 0 || chg)
            {
                old_lod = levelOfDetail;
                old_secsPerQkTile = secsPerQkTile;
            }
            return chg;

        }

        public bool CheckChange()
        {
            var chg = old_mapExtent != mapExtent ||
                      old_maxVertsPerMesh != maxVertsPerMesh ||
                      old_hmult != hmult ||
                      old_synthTex != synthTex ||
                      old_flatTris != flatTriangles ||
                      old_mappprov != mapprov ||
                      old_normmethod != normmethod ||
                      old_nodefak != nodefak ||
                      //old_heightType != heightType ||
                      old_heightSource != heightSource ||
                      old_heightAdjust != heightAdjust ||
                      old_useElevationData != useElevationData;

            //Debug.Log($"CheckChange:{chg} - hmult:{hmult}");

            if (updcount == 0 || chg)
            {
                old_mapExtent = mapExtent;
                old_flatTris = flatTriangles;
                old_hmult = hmult;
                old_useElevationData = useElevationData;
                old_mappprov = mapprov;
                old_normmethod = normmethod;
                old_nodefak = nodefak;
                old_synthTex = synthTex;
                old_maxVertsPerMesh = maxVertsPerMesh;
                old_addMeshColliders = addMeshColliders;
                //old_heightType = heightType;
                old_heightSource = heightSource;
                old_heightAdjust = heightAdjust;
            }
            return chg;
        }

        public void InitializeGrid(string scenename, LatLngBox llbox, string mapcoordname = "", MapProvider mapprov = MapProvider.BingSatelliteLabels, ElevProvider elevprov = ElevProvider.BingElev)
        {
            this.scenename = scenename;
            this.mapcoordname = mapcoordname;
            this.mapprov = mapprov;
            this.elevprov = elevprov;
            this.levelOfDetail = llbox.lod;
            //this.llmapqkcoords = this.gameObject.AddComponent<LatLongMap>();
            this.llmapqkcoords = new LatLongMap();
            llmapqkcoords.InitMapCoords("");
            //this.llmapuscoords = this.gameObject.AddComponent<LatLongMap>();
            this.llmapuscoords = new LatLongMap();
            llmapuscoords.InitMapCoords("");
            this.qmapElev = gameObject.AddComponent<QmapElevation>();
            this.qkm = new QkMan(this, this.mapcoordname, mapprov, llbox);
            this.qtt = this.gameObject.AddComponent<Qtrilines>();
            qtt.Init(this);
        }

        public void AddUserMapPoint(double lat,double lng, double x, double z,bool finished=false)
        {
            llmapuscoords.AddRowLatLng(lat, lng, x, z);
            if (finished)
            {
                FinishMapPoints();
            }
        }
        public void FinishMapPoints()
        {
            var cnt = llmapuscoords.mapcoord.mapdata.Count;
            if (cnt<3)
            {
                Debug.LogWarning($"llsmapuscoords finishing with less than 3 points :{cnt}");
                return;
            }
            llmapuscoords.CalcRegressionMaps();
            var zlat = llmapuscoords.maps.latmap.Map(0, 0);
            var zlng = llmapuscoords.maps.lngmap.Map(0, 0);
            var zx = llmapuscoords.maps.xmap.Map(0, 0);
            var zz = llmapuscoords.maps.zmap.Map(0, 0);
            //Debug.Log($"Finishmappoints zlat:{zlat} zlng:{zlng}   - zx:{zx}   zz:{zz}");
        }

        List<QmeshDeco> decolist = new List<QmeshDeco>();
        public GameObject decoParent;

        public T AddCompTemp<T>(string initstring = "") where T : QmeshDeco
        {
            var tpd = gameObject.AddComponent<T>();
            tpd.Init(this, decoParent, null, initstring);
            decolist.Add(tpd);
            return tpd;
        }
        public T AddCompTemp<T>(SimpleDf df) where T : QmeshDeco
        {
            var tpd = gameObject.AddComponent<T>();
            tpd.Init(this, decoParent, null, "", df);
            decolist.Add(tpd);
            return tpd;
        }
        private void InitDecos()
        {
            //var laygo = layerman.AddLayer("Decos");
            //decoParent = laygo.gameObject;
            //decoParent.transform.parent = transform.parent;

            AddCompTemp<TriPointDeco>();
            AddCompTemp<TemplateDeco>();
            AddCompTemp<SprinkleTrucksDeco>();
            AddCompTemp<SprinkleTowersDeco>();
            AddCompTemp<TrilinesDeco>();
            AddCompTemp<MeshNodesDeco>();
            AddCompTemp<CoordDefiningNodesDeco>();
            AddCompTemp<ExtendDefiningNodesDeco>();
            AddCompTemp<NativeMapNodesDeco>();
            AddCompTemp<FrameQuadkeysDeco>();
        }
        void Awake()
        {
            this.layerman = this.gameObject.AddComponent<LayerMan>();
            layerman.Init(this.transform.parent);
            InitDecos();
        }

        public Vector2 GetUv(int ix, int iz)
        {
            if (ix < 0)
            {
                Debug.LogWarning("GetUv ix<0:" + ix);
            }
            if (ix > nHorzSecs)
            {
                Debug.LogWarning("GetUv ix>nHorzSecs:" + ix);
            }
            if (iz < 0)
            {
                Debug.LogWarning("GetUv iz<0:" + iz);
            }
            if (iz > nVertSecs)
            {
                Debug.LogWarning("GetUv iz>nVertSecs:" + iz);
            }
            ix = Math.Max(0, Math.Min(nHorzSecs, ix));// do not subtract - 1 from this
            iz = Math.Max(0, Math.Min(nVertSecs, iz));
            var uv = uvslookup[ix, iz];
            return uv;
        }
        public bool rangeWarnings = false;
        public Vector3 GetVert(int ix, int iz)
        {
            if (rangeWarnings)
            {
                if (ix < 0)
                {
                    Debug.LogWarning("GetVert ix<0:" + ix);
                }
                if (ix > nHorzSecs)
                {
                    Debug.LogWarning("GetVert ix>nHorzSecs:" + ix + ">" + nHorzSecs);
                }
                if (iz < 0)
                {
                    Debug.LogWarning("GetVert iz<0:" + iz);
                }
                if (iz > nVertSecs)
                {
                    Debug.LogWarning("GetVert iz>nVertSecs:" + iz + ">" + nVertSecs);
                }
            }
            ix = Math.Max(0, Math.Min(nHorzSecs, ix));// do not subtract - 1 from this
            iz = Math.Max(0, Math.Min(nVertSecs, iz));
            var vert = verlookup[ix, iz];
            return vert;
        }
        // Compute barycentric coordinates (u, v, w) for
        // point p with respect to triangle (a, b, c)
        // https://gamedev.stackexchange.com/questions/23743/whats-the-most-efficient-way-to-find-barycentric-coordinates
        Vector3 Barycentric(Vector3 p, Vector3 a, Vector3 b, Vector3 c)
        {
            Vector3 v0 = b - a, v1 = c - a, v2 = p - a;
            float d00 = Vector3.Dot(v0, v0);
            float d01 = Vector3.Dot(v0, v1);
            float d11 = Vector3.Dot(v1, v1);
            float d20 = Vector3.Dot(v2, v0);
            float d21 = Vector3.Dot(v2, v1);
            float denom = d00 * d11 - d01 * d01;
            if (denom == 0) denom = 1;
            var v = (d11 * d20 - d01 * d21) / denom;
            var w = (d00 * d21 - d01 * d20) / denom;
            var u = 1.0f - v - w;
            var rv = new Vector3(v, w, u);
            return rv;
        }

        [HideInInspector] // these are for debugging with a decorator
        public Vector3 bpt1, bpt2, bpt3, bptm, bptmnorm;

        (Vector3, Vector3) Bary1(float x, float z, int ix1, int iz1, int ix2, int iz2, int ix3, int iz3)
        {
            //Debug.Log("Bary1 x:" + x + " z:" + z + " ix1:" + ix1 + " iz1:" + iz1 + " ix2:" + ix2 + " iz2:" + iz2 + " ix3:" + ix3 + " iz3:" + iz3);


            var fv1 = new Vector3(ix1, 0, iz1);
            var fv2 = new Vector3(ix2, 0, iz2);
            var fv3 = new Vector3(ix3, 0, iz3);
            var p = new Vector3(x, 0, z);
            var b = Barycentric(p, fv1, fv2, fv3);
            var nb = new Vector3(b.z, b.x, b.y);
            //rangeWarnings = true;
            if (rangeWarnings && (b.x < 0 || b.y < 0 || b.z < 0))
            {
                Debug.LogWarning("Bary1 coord out of range b.l1:" + b.x + " l2:" + b.y + " l3:" + b.z);
            }
            var v1 = GetVert(ix1, iz1);
            var v2 = GetVert(ix2, iz2);
            var v3 = GetVert(ix3, iz3);
            var vmid = v2;
            var vx = nb.x * v1.x + nb.y * vmid.x + nb.z * v3.x;
            //Debug.Log($"vx:{vx}  =  nb.x:{nb.x}*v1.x:{v1.x}  +  nb.y:{nb.y}*vmid.x:{vmid.x}  +  nb.z:{nb.z}*v3.x:{v3.x}");
            var vy = nb.x * v1.y + nb.y * vmid.y + nb.z * v3.y;
            var vz = nb.x * v1.z + nb.y * vmid.z + nb.z * v3.z;
            var barypt = new Vector3(vx, vy, vz);
            bpt1 = v1;
            bpt2 = v2;
            bpt3 = v3;
            bptm = barypt;
            //var bs = b.ToString("f3");
            //Debug.Log($"Bary1 b:{bs}  x:" + x + " z:" + z + " ix1:" + ix1 + " iz1:" + iz1 + " ix2:" + ix2 + " iz2:" + iz2 + " ix3:" + ix3 + " iz3:" + iz3+" bptm:"+bptm.ToString("f3"));
            var nrm = Vector3.Cross(v2 - v1, v3 - v1);
            nrm.Normalize();
            bptmnorm = nrm;
            return (barypt, nrm);
        }

        public (Vector3, Vector3, int) GetWcMeshPosFromLambda(float lambx, float lambz)
        {
            var xext = lambx * nHorzSecs;
            var zext = lambz * nVertSecs;
            var ix0 = (int)Math.Floor(xext);
            var iz0 = (int)Math.Floor(zext);
            ix0 = Math.Min(nHorzSecs-1, Math.Max(0, ix0));
            iz0 = Math.Min(nVertSecs-1, Math.Max(0, iz0));
            var ix1 = ix0 + 1;
            var iz1 = iz0 + 1;

            // Diagram showing how we choose between upperright and lowerleft triangles
            //
            //     x0z1         x1z1
            //     |  fz>fz    
            //     |        fx>fz
            //     x0z0---------x1z0

            var fx = xext - ix0;
            var fz = zext - iz0;

            Vector3 v, nrm;
            int istat;
            if (fx > fz)
            {
                // choose upperleft
                (v, nrm) = Bary1(xext, zext, ix0, iz0, ix1, iz0, ix1, iz1);
                istat = 1;
            }
            else
            {
                // choose lowerright
                (v, nrm) = Bary1(xext, zext, ix0, iz0, ix0, iz1, ix1, iz1);
                istat = 2;
            }
            return (v, nrm, istat);
        }

        public (float,float) GetLambMeshPosFromLatLng(LatLng ll)
        {
            var llbox = qkm.qllbox;
            if (mapExtent == MapExtentTypeE.AsSpecified)
            {
                llbox = qkm.llbox;
            }
            var (lamblng, lamblat) = llbox.Interpolate(ll);
            return (lamblng, lamblat);
        }

        public (Vector3, Vector3, int) GetQkWcMeshPosFromLatLng(LatLng ll)
        {
            float lamblng, lamblat;
            if (mapExtent == MapExtentTypeE.AsSpecified)
            {
                (lamblng, lamblat) = qkm.llbox.Interpolate(ll);
            }
            else
            {
                (lamblng, lamblat) = qkm.qllbox.Interpolate(ll);
            }
            var lngs = lamblng.ToString("f3");
            var lats = lamblat.ToString("f3");
            //Debug.Log($"GetQkWcMeshPosFromLng ll:{ll.ToString()}   lamblng:{lngs} lamblat:{lats}");
            var rv = GetWcMeshPosFromLambda(lamblng, lamblat);
            return rv;
        }

        public (Vector3 meshpos, Vector3 normal, int istat) GetWcMeshPosProjectedAlongYnew(Vector3 wcpos, QkCoordSys coordsys = QkCoordSys.UserWc, bool db =false, bool cliptocorners=false)
        {
            var ll = GetLngLatNew(wcpos,coordsys:coordsys);
            var (lambx, lambz) = GetLambMeshPosFromLatLng(ll);
            if (cliptocorners)
            {
                if (lambx < 0) lambx = 0;
                if (lambx > 1) lambx = 1;
                if (lambz < 0) lambz = 0;
                if (lambz > 1) lambz = 1;
            }
            var (meshpos, nrm, istat) = GetWcMeshPosFromLambda(lambx, lambz);
            if (db)
            {
                var lats = ll.lat.ToString("f8");
                var lngs = ll.lng.ToString("f8");
                var lxs = lambx.ToString("f4");
                var lzs = lambz.ToString("f4");
                var wcs = wcpos.ToString("f3");
                Debug.Log($"GetWcMeshPos Ynew- wc:{wcs}   ll:{lats} {lngs}   lambbx:{lxs} lambbz:{lzs}");
            }
            var nmeshpos = new Vector3(wcpos.x, meshpos.y, wcpos.z);
            return (nmeshpos, nrm, istat);
        }
        public LatLongMap GetLatLongMap(QkCoordSys coordsys)
        {
            var llmap = llmapyacoords;
            if (llmap == null || !llmap.isInited || coordsys == QkCoordSys.QkWc)
            {
                llmap = llmapqkcoords;
            }
            return llmap;
        }
        public LatLng GetLngLatNew(Vector3 wcpos, QkCoordSys coordsys)
        {

            var llmap = GetLatLongMap(coordsys);
            // long lat from world position
            var nlat = llmap.maps.latmap.Map(wcpos.x, wcpos.z);
            var nlng = llmap.maps.lngmap.Map(wcpos.x, wcpos.z);
            var nx = llmap.maps.xmap.Map(nlng, nlat);
            var nz = llmap.maps.zmap.Map(nlng, nlat);
            var errx = nx - wcpos.x;
            var errz = nz - wcpos.z;
            var err = errx*errx + errz*errz;
            if (err>1e-2)
            {
                Debug.LogError($"Error too large in GetLngLatNew:{err}");
            }
            var ll = new LatLng(nlat, nlng);
            return ll;
        }


        public (Vector3 meshpos, Vector3 normal, int istat) GetWcMeshPosProjectedAlongY(Vector3 wcpos)
        {
            var (lambx, lambz) = GetMeshLambdaFromXZ(wcpos.x, wcpos.z);
            Debug.Log($"GetWcMeshPosProjected lambx:{lambx} lzmbz:{lambz}");
            var (meshpos, nrm, istat) = GetWcMeshPosFromLambda(lambz, lambx);
            var nmeshpos = new Vector3(wcpos.x, meshpos.y, wcpos.z);
            return (nmeshpos, nrm, istat);
        }

        public LatLng GetLngLat(Vector3 wcpos)
        {
            // long lat from world position
            var nlat = llmapqkcoords.maps.latmap.Map(wcpos.x, wcpos.z);
            var nlng = llmapqkcoords.maps.lngmap.Map(wcpos.x, wcpos.z);
            var nx = llmapqkcoords.maps.xmap.Map(nlng, nlat);
            var nz = llmapqkcoords.maps.zmap.Map(nlng, nlat);
            var errx = nx - wcpos.x;
            var errz = nz - wcpos.z;
            var ll = new LatLng(nlat, nlng);
            return ll;
        }
        public float GetYvalLambDiscrete(float lambx, float lambz)
        {
            var xext = lambx * nHorzSecs;
            var zext = lambz * nVertSecs;
            var ix = (int)xext;
            var iz = (int)zext;
            var fx = xext - ix;
            var fz = zext - iz;
            var vert = verlookup[ix, iz];
            return vert.y;
        }
        public float GetYvalLamb(float lambx, float lambz)
        {
            var (meshpos, nrm, istat) = GetWcMeshPosFromLambda(lambz, lambx);
            return meshpos.y;
        }

        public float yvalmin = 0;
        public float yvalmidpt = 0;

        public float[,] meshyvals = null;

        void AdjustYvals(float adjustment, bool dogomfs = false)
        {
            //Debug.Log($"AdjustYvals:{adjustment}");
            var yvalmin_new = float.MaxValue;
            for (var iX = 0; iX <= nHorzSecs; iX++)
            {
                for (var iZ = 0; iZ <= nVertSecs; iZ++)
                {
                    meshyvals[iX, iZ] -= adjustment;
                    var v = verlookup[iX, iZ];
                    verlookup[iX, iZ] = new Vector3(v.x, v.y -= adjustment, v.z);
                    yvalmin_new = Math.Min(yvalmin_new, meshyvals[iX, iZ]);
                }
            }
            yvalmin = yvalmin_new;
            if (dogomfs)
            {
                if (gomflst != null)
                {
                    foreach (var gomf in gomflst)
                    {
                        gomf.AdjustHeights(adjustment);
                    }
                }
            }
            InitGetMeshLambdaFromXZ();
            var (lambx, lambz) = GetMeshLambdaFromXZ(0, 0);
            yvalmidpt = GetYvalLamb(lambx, lambz);
        }
        void GenYvals()
        {
            //Debug.Log("GenYvals - start ");
            meshyvals = new float[nHorzSecs + 1, nVertSecs + 1];
            var pi2 = 4 * Mathf.PI;
            //var pi =  Mathf.PI;
            GeotiffMan gtm = null;
            var useLidar = heightSource == HeightSource.FetchedPlusLidar;
            if (useLidar)
            {
                gtm = FindObjectOfType<GeotiffMan>();
                Geotiff.InitOorDict();
            }
            var yval = 0.0f;
            yvalmin = float.MaxValue;
            for (var iX = 0; iX <= nHorzSecs; iX++)
            {
                for (var iZ = 0; iZ <= nVertSecs; iZ++)
                {
                    yval = 0;
                    //switch (this.heightType)
                    switch (this.heightSource)
                    {
                        //case HeightTypeE.Random:
                        case HeightSource.Random:
                            yval = qut.GetRanFloat(0.95f, 1.05f) * 100 / 2;
                            break;
                        //case HeightTypeE.SineWave:
                        case HeightSource.SineWave:
                            var x = iX * pi2 / nHorzSecs;
                            var z = iZ * pi2 / nVertSecs;
                            var fak = 1.0f + (Mathf.Sin(x) * Mathf.Sin(z));
                            yval = fak * 100;
                            break;
                        //case HeightTypeE.FetchedAndOriginZeroed:
                        //case HeightTypeE.FetchedAndZeroed:
                        //case HeightTypeE.Fetched:
                        case HeightSource.Fetched:
                        case HeightSource.FetchedPlusLidar:
                            var stillNeedElev = true;
                            if (useLidar && gtm != null)
                            {
                                var p = GetMeshNodePos(iX, iZ);
                                if (gtm.InRange(p.x, p.z))
                                {
                                    (_, yval) = gtm.GetElev(p.x, p.z);
                                    stillNeedElev = false;
                                }
                            }
                            if (stillNeedElev && useElevationData)
                            {
                                var idx = iZ * (nHorzSecs + 1) + iX;
                                if (qmapElev==null)
                                {
                                    Debug.LogWarning($"QmapMesh.GenYvals - qmapElev==null");
                                    break;
                                }
                                if (qmapElev.heights == null)
                                {
                                    Debug.LogWarning($"QmapMesh.GenYvals - qmapElev.heights==null");
                                    break;
                                }
                                if (idx>=qmapElev.heights.Count)
                                {
                                    Debug.LogWarning($"QmapMesh.GenYvals - idx({idx}) out of range 0-{qmapElev.heights.Count}");
                                    break;
                                }
                                yval = this.qmapElev.heights[iZ * (nHorzSecs + 1) + iX];
                            }
                            break;
                    }
                    meshyvals[iX, iZ] = hmult * yval;
                    yvalmin = Math.Min(yvalmin, meshyvals[iX, iZ]);
                }
            }
            //yvalmidpt = meshyvals[nHorzSecs / 2, nVertSecs / 2];
            if (useLidar)
            {

            }

            InitGetMeshLambdaFromXZ();
            var (lambx, lambz) = GetMeshLambdaFromXZ(0, 0);
            yvalmidpt = GetYvalLamb(lambx, lambz);
            //Debug.Log($"lambx:{lambx} lambz:{lambz} yvalmidpt:{yvalmidpt}   yvalmin:{yvalmin}");
            //if (this.heightType == HeightTypeE.FetchedAndZeroed || this.heightType == HeightTypeE.FetchedAndOriginZeroed)
            switch (heightAdjust)
            {
                case HeightAdjust.Zeroed:
                    {
                        AdjustYvals(yvalmin, dogomfs: false);
                        break;
                    }
                case HeightAdjust.OriginZeroed:
                    {
                        AdjustYvals(yvalmidpt, dogomfs: false);
                        break;
                    }
                case HeightAdjust.NoAdjust:
                    {
                        AdjustYvals(0, dogomfs: false);
                        break;
                    }
            }
            //Debug.Log($"GenYvals done - HeightSource:{heightSource} HeightAdjust:{heightAdjust} yvalmin:{yvalmin}  yvalmidpt:{yvalmidpt}");
        }
        public LatLng GetMeshNodeLatLng(int ix, int iz)
        {
            var x = ix * 1f / nHorzSecs;
            var z = iz * 1f / nVertSecs;

            var rv = GetQktileBoxRelativeLatLng(z, x);
            return rv;
        }

        bool getMeshLambdaFromXZinited = false;
        Vector3 pt00 = Vector3.zero;
        Vector3 ptNV = Vector3.zero;
        Vector3 vkDif = Vector3.zero;

        public (float, float) GetMeshLambdaFromXZ(float x, float z)
        {
            if (!getMeshLambdaFromXZinited)
            {
                Debug.LogError("getMeshLambdaFromXZ not inited");
                return (0, 0);
            }
            var vdif = ptNV - pt00;

            float lambx = (x - pt00.x) / vdif.x;
            float lambz = (z - pt00.z) / vdif.z;
            return (lambx, lambz);
        }
        public void InitGetMeshLambdaFromXZ()
        {
            pt00 = GetMeshNodePos(0, 0);
            ptNV = GetMeshNodePos(nHorzSecs, nVertSecs);
            vkDif = ptNV - pt00;
            if (vkDif.x == 0)
            {
                Debug.LogError("vkDif z == 0");
            }
            else if (vkDif.z == 0)
            {
                Debug.LogError("vkDif.z  == 0");
            }
            else
            {
                getMeshLambdaFromXZinited = true;
                //Debug.Log($"getMeshLambdaFromXZ inited pt00:{pt00.ToString("f1")} ptNV:{ptNV.ToString("f1")}");
            }
        }
        public Vector3 GetMeshNodePos(int iX, int iZ)
        {
            if (iX < 0) iX = 0;
            if (iX > nHorzSecs) iX = nHorzSecs;
            if (iZ < 0) iZ = 0;
            if (iZ > nVertSecs) iZ = nVertSecs;
            var x = (iX * 1.0f / nHorzSecs) - this.lambdaOrg.x;
            var valy = meshyvals[iX, iZ];
            var z = (iZ * 1.0f / nVertSecs) - this.lambdaOrg.z;
            var rv = Vector3.zero;
            if (mapExtent == MapExtentTypeE.SnapToTiles)
            {
                rv = GetQktileBoxRelativePos(z, x, valy);
            }
            else
            {
                rv = GetLlboxRelativePos(z, x, valy);
            }
            return rv;
        }
        LatLng GetQktileBoxRelativeLatLng(float lambLat, float lambLng)
        {
            LatLng rv = null;
            if (mapExtent == MapExtentTypeE.SnapToTiles)
            {
                rv = qkm.qllbox.Interpolate(lambLat, lambLng);
            }
            else
            {
                rv = qkm.llbox.Interpolate(lambLat, lambLng);
            }
            return rv;
        }
        Vector3 GetQktileBoxRelativePos(float lambLat, float lambLng, float yval)
        {
            var llxy = qkm.qllbox.Interpolate(lambLat, lambLng);
            var rv = GetPosFromLatLng(llxy, yval);
            //Debug.Log("lambLat:" + lambLat + " Z:" + lambLng + "    ll.lat:" + llxy.lat + " y:" + llxy.lng + "    rv.x:" + rv.x + " z:" + rv.z);
            return rv;
        }
        Vector3 GetLlboxRelativePos(float lambLat, float lambLng, float yval)
        {
            var llxy = qkm.llbox.Interpolate(lambLat, lambLng);
            var rv = GetPosFromLatLng(llxy, yval);
            //Debug.Log("lambLat:" + lambLat + " Z:" + lambLng + "    ll.lat:" + llxy.lat + " y:" + llxy.lng + "    rv.x:" + rv.x + " z:" + rv.z);
            return rv;
        }
        public Vector3 GetPosFromLatLng(LatLng ll, float yval)
        {
            var v = llmapqkcoords.xycoord((float)ll.lng, (float)ll.lat);// backwards, see comments in xycoord code
            var rv = new Vector3(v.x, yval, v.z);
            //var rv = new Vector3(v.z, yval, v.x);
            //Debug.Log("ll.lat:" + ll.lat + " lng:" + ll.lng + "    rv.x:" + rv.x + " z:" + rv.z);
            return rv;
        }
        public Vector3 GetPosFromLatLng(LatLng ll)// wrong when in hierarchy?
        {
            (var rv, _, _) = GetQkWcMeshPosFromLatLng(ll);
            return rv;
        }

        public async Task<(bool, int)> GetElevations(bool execute = true, bool forceload = false)
        {
            var nelev = 0;
            var ok = false;
            List<float> heights = null;
            if (useElevationData)
            {
                var llbox = qkm.qllbox;
                if (mapExtent == MapExtentTypeE.AsSpecified)
                {
                    llbox = qkm.llbox;
                }
                qmapElev.InitElevs(scenename, this.elevprov, this.mapExtent, EarthHightModelE.sealevel, nVertSecs + 1, nHorzSecs + 1, llbox);
                (ok, nelev) = await qmapElev.RetrieveElevations(execute, forceload);
                if (ok)
                {
                    heights = qmapElev.heights;
                    var nexp1 = (nVertSecs + 1) * (nHorzSecs + 1);
                    var nexp2 = (nVertSecs + 2) * (nHorzSecs + 1);
                    if (heights.Count!=nexp1 && heights.Count!=nexp2)
                    {
                        // sometimes we have to retrieve one row too many since we cannot retrieve only one row
                        Debug.LogWarning($"Retrieved {heights.Count} bing heights but expected:{nexp1} or {nexp2}  -   nVertSecs:{nVertSecs} nHorzSecs:{nHorzSecs}");
                    }
                    if (heights.Count > 0)
                    {
                        //Debug.Log($"heights - count:{heights.Count} first:{heights[0]} last:{heights[heights.Count-1]}");
                    }
                }
                if (!ok)
                {
                    //if (this.heightType == HeightTypeE.Fetched || heightType == HeightTypeE.FetchedAndZeroed || heightType == HeightTypeE.FetchedAndOriginZeroed)
                    //{
                    //    this.heightType = HeightTypeE.Constant;
                    //}
                    heightSource = HeightSource.Constant;
                }
            }
            GenYvals();
            return (ok, nelev);
        }
        public int CalcVertNumber(int nh, int nv)
        {
            int rv = 0;
            if (flatTriangles)
            {
                // nh*nv sections, 2 triangles per section, and 3 verts per triangle
                rv = nh * nv * 2 * 3;
            }
            else
            {
                // one vertext per lattice point - and these frame the seconts
                rv = (nh + 1) * (nv + 1);
            }
            return rv;
        }

        public void CalculateMeshSize()
        {
            if (nHorzSecs <= 0) nHorzSecs = 12;
            if (nVertSecs <= 0) nVertSecs = 12;
            switch (meshSizeMethod)
            {
                case MeshSizeMethodE.NumTiles:
                    {
                        // do nothing as presumably they were specfied over members
                        break;
                    }
                case MeshSizeMethodE.TilesPerQk:
                    {
                        nHorzSecs = qkm.nqk.x * secsPerQkTile;
                        nVertSecs = qkm.nqk.y * secsPerQkTile;
                        break;
                    }
            }
            var nVerts = CalcVertNumber(nHorzSecs, nVertSecs);
            var fnMeshes = nVerts * 1.0 / maxVertsPerMesh;
            var nMeshes = (int)Math.Ceiling(fnMeshes);
            nHorzSecsPerMesh = nHorzSecs;
            nVertSecsPerMesh = nVertSecs / nMeshes;
            var nVertsPerMesh = CalcVertNumber(nHorzSecsPerMesh, nVertSecsPerMesh);
            //Debug.Log("CalcMeshSize - nHorzTiles:" + nHorzSecs + " nVertTiles:" + nVertSecs + " flatTris:" + flatTriangles);
            //Debug.Log("CalcMeshSize -     nVerts:" + nVerts + "  fnMeshes:" + fnMeshes.ToString("f2") + " nMeshes:" + nMeshes);
            //Debug.Log("CalcMeshSize -  qkm.nqk.x:" + qkm.nqk.x + " y:" + qkm.nqk.y + "  nVertSecsPerMesh: " + nVertSecsPerMesh + " nVertsPerMesh:" + nVertsPerMesh);
        }
        Vector3[,] verlookup = null;
        Vector2[,] uvslookup = null;
        public int numVertices = 0;
        public int numTriangles = 0;
        public int numBitmapTilesRetrieved = 0;
        public int numElevationSetsRetrieved = 0;
        public float triMeshDiag = 20;
        public float triMeshMinLeg = 20;
        public float triMeshMaxLeg = 20;

        List<MfWrap> gomflst = null;

        public void InitGomflst()
        {
            if (gomflst != null)
            {
                foreach (var gomf in gomflst)
                {
                    //Debug.Log("Destroying gomf:" + gomf.name);
                    Destroy(gomf.gameObject);
                }
            }
            //Debug.Log("Reallocing goflst");
            gomflst = new List<MfWrap>();
        }
        void UpdateGomflst()
        {
            if (gomflst != null)
            {
                foreach (var gomf in gomflst)
                {
                    gomf.UpdateStats();
                }
            }
        }
        public Viewer viewer = null;
        GameObject viewerobj = null;

        public void AddMeshColliders()
        {
            if (gomflst != null)
            {
                foreach (var gomf in gomflst)
                {
                    var mc = gomf.GetComponent<MeshCollider>();
                    if (addMeshColliders && mc == null)
                    {
                        //Debug.Log("Adding MeshCollider for " + gomf.name);
                        gomf.gameObject.AddComponent<MeshCollider>();
                    }
                    else if (!addMeshColliders)
                    {
                        //Debug.Log("Removing MeshCollider for " + gomf.name);
                        Destroy(mc);
                    }
                }
            }
            old_addMeshColliders = addMeshColliders;
        }

        public void RegenerateViewer()
        {
            QMeshDestroyViewer();
            if (!addViewer) return;

            QmeshBuildViewer();
        }
        void QMeshDestroyViewer()
        {
            if (viewerobj != null)
            {
                viewer = viewerobj.GetComponent<Viewer>();
                viewer.DeleteGos();
                Destroy(viewerobj);
                viewerobj = null;
            }
            Viewer.InvalidateViewerCamera();
            //Debug.LogWarning("Invalidated viewer");
        }
        public void QmeshBuildViewer()
        {
            QMeshDestroyViewer();
            viewerobj = new GameObject("Viewer");
            viewer = viewerobj.AddComponent<Viewer>();
            viewer.InitViewer(this,this.viewHome);
            //viewerobj.transform.SetParent(this.transform, worldPositionStays: true);
            //Debug.Log($"QmeshBuildViewer - Viewer rotation before SetParent  {viewerobj.transform.localRotation.eulerAngles}");
            viewerobj.transform.SetParent(this.transform, worldPositionStays: false);
            viewerobj.transform.SetAsFirstSibling();
            //Debug.Log($"QmeshBuildViewer - Viewer rotation after  SetParent  {viewerobj.transform.localRotation.eulerAngles}");
            addViewer = true;
            old_addViewer = true;
        }
        void UpdateStatistics()
        {
            var box = qkm.llbox;
            if (mapExtent == MapExtentTypeE.SnapToTiles)
            {
                box = qkm.qllbox;
            }
            stats.CalcValues(box,mapExtent,qkm.nqk);
            var meshq00 = GetMeshNodePos(0, 0);
            var meshq01 = GetMeshNodePos(0, 1);
            var meshq10 = GetMeshNodePos(1, 0);
            var meshq11 = GetMeshNodePos(1, 1);
            triMeshDiag = Vector3.Distance(meshq00, meshq11);
            var d01 = Vector3.Distance(meshq00, meshq01);
            var d10 = Vector3.Distance(meshq00, meshq10);
            triMeshMinLeg = Math.Min(d01, d10);
            triMeshMaxLeg = Math.Max(d01, d10);
            stats.meshDeltaMeters = GetMeshNodePos(1, 1) - meshq00;

        }
        MfWrap GetNewGomf(int srow, int nrow, int nhps, int nvps)
        {
            var gomfidx = gomflst.Count;
            var nname = "gomf-" + gomfidx;
            var gomfgo = new GameObject(nname);
            var gomf = gomfgo.AddComponent<MfWrap>();
            gomf.Init(this, srow, nrow, nhps, nvps);
            gomfgo.transform.SetParent(this.transform,worldPositionStays:false);

            gomflst.Add(gomf);
            return gomf;
        }
        void EditMeshNormals()
        {
            for (var i = 0; i < gomflst.Count - 1; i++)
            {
                var mfw1 = gomflst[i];
                var mfw2 = gomflst[i + 1];
                MfWrap.ZipUpNormals(mfw1, mfw2, normmethod);
            }
        }
        public static bool isLoading = false;
        public async Task<(int, int)> GenerateGrid(bool execute = true, bool forceload = true, bool limitQuadkeys = true)
        {
            initializationComplete = false;
            isLoading = true;

            InitGomflst();

            // Get base texture
            Debug.Log("GenerateGrid " + name);
            qkm.mapprov = mapprov;
            qkm.levelOfDetail = levelOfDetail;
            qkm.CalcQuadKeys(limitQuadkeys);

            CalculateMeshSize();
            //Debug.Log("synthTex:" + synthTex);
            (var tex, var nBmRetrieved) = await qkm.GetTexAsy(scenename, mapExtent, execute: execute, forceload: forceload, synthTex: synthTex, synthSpec: synthSpec);
            if (tex==null)
            {
                Debug.LogError($"GetTexAsy failed to retrieve tex - bitmaps retreived:{nBmRetrieved}");
                return (nBmRetrieved, 0);
            }
            if (execute)
            {
                stats.textHeighthPix = tex.height;
                stats.textWidthPix = tex.width;
                stats.textMbytes = qkm.last_loaded_texsize / 1000000.0f;
            }

            verlookup = new Vector3[nHorzSecs + 1, nVertSecs + 1];
            uvslookup = new Vector2[nHorzSecs + 1, nVertSecs + 1];

            // Elevations
            (var elok, var nElRetrived) = await GetElevations(execute, forceload);
            //Debug.Log($"Retrived {nElRetrived} elevations");
            QMeshDestroyViewer();

            var nVertRowsTodo = nVertSecs;
            var nVertRowsDone = 0;

            if (execute)
            {
                while (nVertRowsDone < nVertRowsTodo)
                {
                    //Debug.Log($"nVertRowsDone:{nVertRowsDone} nVertRowsTodo:{nVertRowsTodo}  Time:{Time.time}");
                    // need new lists
                    var vertices = new List<Vector3>();
                    var triangles = new List<int>();
                    var normals = new List<Vector3>();
                    var uvs = new List<Vector2>();

                    var testgap = 0;// test to see if the gap opens as predicted

                    var nVertRowsTodoPerStep = Math.Min(nVertSecsPerMesh, nVertRowsTodo - nVertRowsDone) - testgap;

                    //Debug.Log($"Top - nVertRowsTodoPerStep:{nVertRowsTodoPerStep} nVertRowsTodo:{nVertRowsTodo} nVertRowsDone:{nVertRowsDone} time:{Time.time}");

                    var gomf = GetNewGomf(nVertRowsDone, nVertRowsTodoPerStep, nHorzSecsPerMesh, nVertSecsPerMesh);
                    var mf = gomf.GetComponent<MeshFilter>();
                    var renderer = gomf.GetComponent<MeshRenderer>();

                    var shader = Shader.Find("Diffuse");
                    renderer.material = new Material(shader);
                    renderer.material.SetTexture("_MainTex", tex);

                    // now do grid
                    var mesh = new Mesh();
                    mf.mesh = mesh;


                    if (flatTriangles)
                    {
                        //Debug.Log("Flat triangles");
                        // Flat vertics, normals, triangles
                        var vertindex = 0;
                        for (var iZ = 0; iZ < nVertRowsTodoPerStep; iZ++)
                        {
                            var iZ1 = nVertRowsDone + iZ + testgap;
                            //Debug.Log("Flat - doing row:" + iZ1);
                            for (var iX = 0; iX < nHorzSecsPerMesh; iX++)
                            {
                                AddVerticesFlat(iX, iZ1, vertices);
                                vertindex = AddTrianglesFlat(vertindex, triangles);
                                AddNormalsFlat(normals);
                                AddUvsFlat(iX, iZ1, uvs);
                            }
                        }
                        mesh.vertices = vertices.ToArray();
                        mesh.normals = normals.ToArray();
                        mesh.triangles = triangles.ToArray();
                        mesh.uv = uvs.ToArray();
                        mesh.RecalculateNormals();
                        //Debug.Log("recalculated normals");
                    }
                    else
                    {
                        //Debug.Log("Smooth triangles");
                        // Smooth vertices, normals, and uvs
                        for (var iZ = 0; iZ <= nVertRowsTodoPerStep; iZ++)
                        {
                            var iZ1 = nVertRowsDone + iZ + testgap;
                            //Debug.Log("Smooth verts, normals, UVs - doing row:" + iZ1);
                            for (var iX = 0; iX <= nHorzSecsPerMesh; iX++)
                            {
                                //Debug.Log("iZ1:"+iZ1+" iX:" + iX);
                                AddVertexSmooth(iX, iZ1, vertices);
                                AddNormalsSmooth(normals);
                                AddUvsSmooth(iX, iZ1, uvs);
                            }
                        }
                        // Smooth Triangles
                        var vertindex = 0;
                        for (var iZ = 0; iZ < nVertRowsTodoPerStep; iZ++)
                        {
                            var iZ1 = nVertRowsDone + iZ + testgap;
                            //Debug.Log("Smooth tris - doing row:" + iZ1);
                            for (var iX = 0; iX < nHorzSecsPerMesh; iX++)
                            {
                                AddTrianglesSmooth(vertindex, iX, iZ1, triangles);
                                vertindex++;
                            }
                            vertindex++;
                        }
                        mesh.vertices = vertices.ToArray();
                        mesh.normals = normals.ToArray();
                        mesh.triangles = triangles.ToArray();
                        mesh.uv = uvs.ToArray();
                        mesh.RecalculateNormals();
                        //Debug.Log("recacluated normals");
                    }
                    var meshverts = mesh.vertices.Length;
                    var meshtris = mesh.triangles.Length / 3;
                    //Debug.Log("mesh verts:" + meshverts + "  tris:" + meshtris);
                    numVertices += meshverts;
                    numTriangles += meshtris;
                    nVertRowsDone += nVertSecsPerMesh;
                }
                //Debug.Log("Total NumVertices:" + numVertices + "  NumTriangles:" + numTriangles);
                InitGetMeshLambdaFromXZ();
            }
            //Debug.Log("nBmRetrieved:" + nBmRetrieved + "  nElRetrived:" + nElRetrived);

            if (!flatTriangles)
            {
                // in smooth case we need to average the normals at the stiches between the meshes 
                // or we have a discontinuity in shading which can be quite noticable
                EditMeshNormals();
            }
            qtt.GenerateTriLines();

            UpdateGomflst();
            UpdateStatistics();

            if (heightAdjust == HeightAdjust.OriginZeroed)
            {
                var (lambx, lambz) = GetMeshLambdaFromXZ(0, 0);
                yvalmidpt = GetYvalLamb(lambx, lambz);
                AdjustYvals(yvalmidpt, dogomfs: true);
                var nyvalmidpt = GetYvalLamb(lambx, lambz);
            }
            RegenerateViewer();
            AddMeshColliders();
            initializationComplete = true;
            isLoading = false;
            return (nBmRetrieved, nElRetrived);
        }

        public void CalcYaLLmap()
        {
            var cnt = llmapqkcoords.mapcoord.mapdata.Count;
            //Debug.Log($"CalcYaLLmap llmapqk pts:{cnt}");
            //var llya= this.gameObject.AddComponent<LatLongMap>();
            var llya = new LatLongMap();
            llya.InitMapCoords();
            int i = 0;
            foreach (var md in llmapqkcoords.mapcoord.mapdata)
            {
                var sname = "mc:" + i;
                var ll = new LatLng(md.lat, md.lng);
                var oripos = new Vector3((float)md.x, 0, (float)md.z);
                var go = new GameObject(sname);
                go.transform.position = oripos;
                go.transform.SetParent(transform, worldPositionStays: false);
                var newpos = go.transform.position;
                llya.AddRowLatLng(ll.lat, ll.lng, newpos.x, newpos.z);
                var ops = oripos.ToString("f3");
                var nps = newpos.ToString("f3");
                //Debug.Log($"  CalcYaLlmap {sname} {ll.ToString()}  orip:{ops}  newp:{nps}");
                i++;
            }
            llya.CalcRegressionMaps();
            llmapyacoords = llya;
        }

        private void AddVertexSmooth(int ix0, int iz0, ICollection<Vector3> vertices)
        {
            var v00 = GetMeshNodePos(ix0, iz0);
            verlookup[ix0, iz0] = v00;
            vertices.Add(v00);
        }
        private int AddTrianglesSmooth(int vertindex, int ix, int iz, ICollection<int> triangles)
        {
            int v0 = vertindex;
            int v1 = vertindex + 1;
            int v2 = vertindex + 1 + nHorzSecs + 1;
            int v3 = vertindex + 0 + nHorzSecs + 1;
            //Debug.Log("at1:"+vertindex +" ix:"+ ix+" iz:"+ iz+ " v0:" + v0 + "  v1:" + v1 + "  v2:" + v2 + "  v3:" + v3);
            triangles.Add(v0);
            triangles.Add(v2);
            triangles.Add(v1);
            triangles.Add(v0);
            triangles.Add(v3);
            triangles.Add(v2);
            vertindex += 4;
            return vertindex;
        }
        private void AddVerticesFlat(int ix0, int iz0, ICollection<Vector3> vertices)
        {
            var ix1 = ix0 + 1;
            var iz1 = iz0 + 1;

            var v00 = GetMeshNodePos(ix0, iz0);
            var v10 = GetMeshNodePos(ix1, iz0);
            var v11 = GetMeshNodePos(ix1, iz1);
            var v01 = GetMeshNodePos(ix0, iz1);
            verlookup[ix0, iz0] = v00;
            verlookup[ix1, iz0] = v10;
            verlookup[ix1, iz1] = v11;
            verlookup[ix0, iz1] = v01;
            vertices.Add(v00);
            vertices.Add(v10);
            vertices.Add(v11);
            vertices.Add(v01);
        }
        private int AddTrianglesFlat(int vidx, ICollection<int> triangles)
        {
            int v0 = vidx;
            int v1 = vidx + 1;
            int v2 = vidx + 2;
            int v3 = vidx + 3;
            //Debug.Log("at:" + vertindex + " v0:" + v0 + "  v1:" + v1 + "  v2:" + v2 + "  v3:" + v3);

            triangles.Add(vidx + 0);
            triangles.Add(vidx + 2);
            triangles.Add(vidx + 1);
            triangles.Add(vidx + 0);
            triangles.Add(vidx + 3);
            triangles.Add(vidx + 2);
            vidx += 4;
            return vidx;
        }
        private void AddNormalsFlat(ICollection<Vector3> normals)
        {
            normals.Add(Vector3.up);
            normals.Add(Vector3.up);
            normals.Add(Vector3.up);
            normals.Add(Vector3.up);
        }
        private void AddNormalsSmooth(ICollection<Vector3> normals)
        {
            normals.Add(Vector3.up);
        }
        private void AddUvsFlat(int ix0, int iz0, ICollection<Vector2> uvs)
        {
            float szux = 1.0f / nHorzSecs;
            float szvy = 1.0f / nVertSecs;
            var iz1 = iz0 + 1;
            var ix1 = ix0 + 1;
            var u0 = ix0 * szux;
            var v0 = iz0 * szvy;
            var u1 = ix1 * szux;
            var v1 = iz1 * szvy;
            var uv1 = new Vector2(u0, v0);
            var uv2 = new Vector2(u1, v0);// ix1 * szux, iz0 * szvy);
            var uv3 = new Vector2(u1, v1);// ix1 * szux, iz1 * szvy);
            var uv4 = new Vector2(u0, v1);// ix0 * szux, iz1 * szvy);
            uvslookup[ix0, iz0] = uv1;
            uvslookup[ix0, iz1] = uv2;
            uvslookup[ix1, iz1] = uv3;
            uvslookup[ix1, iz0] = uv4;
            uvs.Add(uv1);
            uvs.Add(uv2);
            uvs.Add(uv3);
            uvs.Add(uv4);
        }
        private void AddUvsSmooth(int ix0, int iz0, ICollection<Vector2> uvs)
        {
            float szux = 1.0f / nHorzSecs;
            float szvy = 1.0f / nVertSecs;
            var u0 = ix0 * szux;
            var v0 = iz0 * szvy;
            var uv1 = new Vector2(u0, v0);
            uvslookup[ix0, iz0] = uv1;
            uvs.Add(uv1);
        }

        public void EraseSceneDataFromDisk()
        {
            qkm.DeleteBitmapData(scenename, mapprov);
            qmapElev.DeleteElevData(scenename, mapprov);
            deleteSceneData = false;
        }

        void Update()
        {
            if (initializationComplete)
            {
                if (regenMesh || (CheckChange() && updcount > 0))
                {
                    _ = GenerateGrid(execute: true, forceload: false, limitQuadkeys: limitQuadkeys);
                    regenMesh = false;
                }
                if (regenMeshNormals)
                {
                    EditMeshNormals();
                    regenMeshNormals = false;
                }
                if (deleteSceneData)
                {
                    Debug.Log($"Deleting Scene Data {scenename} {mapprov}");
                    qkm.DeleteBitmapData(scenename, mapprov);
                    deleteSceneData = false;
                }
                if (CheckWebReleventChange())
                {
                    float nqks = this.qkm.nqk.x * this.qkm.nqk.y;
                    var qlod = this.qkm.levelOfDetail;
                    var req_lod = levelOfDetail;
                    var nnquk = (int)(nqks * Math.Pow(4, req_lod - qlod));
                    this.nQks = nnquk;
                    this.nElevSamples = (int)Math.Ceiling((this.nHorzSecs + 1) * ((this.nVertSecs + 1) / 1024.0));
                }
                if (addViewer != old_addViewer)
                {
                    RegenerateViewer();
                    old_addViewer = addViewer;
                }
                if (addMeshColliders != old_addMeshColliders)
                {
                    AddMeshColliders();
                }
            }
            updcount++;
        }
    }
}