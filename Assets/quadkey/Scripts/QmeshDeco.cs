using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aiskwk.Dataframe;

namespace Aiskwk.Map
{
    public abstract class QmeshDeco : MonoBehaviour
    {
        public enum DecoType { Template, TriPoints, TriLines, MeshNodes, CoordDefNodes, ExtentDefNodes, NativeNodes, FrameQuadKeys, SprinklePrefabs, SprinkleTrucks, SprinkleTowers, SubMeshShowNodes, ShowGeoTiffFrames }
        public DecoType decotype;
        public string deconame = "deco";

        public bool showDeco;

        public GameObject decoroot = null;

        protected QmapMesh qmm;
        protected MfWrap mfw;
        protected GameObject preferedParent;
        protected Layer layer = null;
        protected string initstring;
        protected SimpleDf df = null;
        // Start is called before the first frame update

        public void Init(QmapMesh qmm, GameObject preferedParent, MfWrap mfw = null, string initstring = "", SimpleDf df = null)
        {
            this.qmm = qmm;
            this.mfw = mfw;
            this.df = df;
            this.preferedParent = preferedParent;
            this.initstring = initstring;
            InitDecoType();
        }

        public abstract void InitDecoType();


        public virtual void Destruct()
        {
            if (decoroot != null)
            {
                Destroy(decoroot);
                decoroot = null;
            }
        }

        public void ConstructBase()
        {
            decoroot = new GameObject("decoroot");
            AttachToParent();
        }
        public void AttachToParent()
        {
            decoroot.transform.parent = null;
            if (preferedParent != null)
            {
                //decoroot.transform.parent = preferedParent.transform;
                Debug.Log($"{decotype} decoroot gameobject attaching to parent");
                decoroot.transform.SetParent(preferedParent.transform, worldPositionStays: false);
            }
        }

        public virtual void Construct()
        {
            ConstructBase();
            //AttachToParent();
        }

        public virtual void EnsureExistence()
        {
            if (showDeco)
            {
                if (layer == null)
                {
                    layer = qmm.layerman.AddLayer(deconame);
                    preferedParent = layer.gameObject;
                }
                if (decoroot == null)
                {
                    Construct();
                }
            }
            else
            {
                Destruct();
            }
        }
        public void Refresh()
        {
            Destruct();
            Construct();
        }
        public virtual void UpdateState()
        {
        }
        public virtual void Update()
        {
            EnsureExistence();
            UpdateState();
        }
    }
    public class TemplateDeco : QmeshDeco
    {
        public GameObject sphere;
        public override void InitDecoType()
        {
            decotype = DecoType.Template;
            deconame = "template";
        }

        public override void Construct()
        {
            ConstructBase();

            sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.parent = decoroot.transform;
            qut.SetColorOfGo(sphere, Color.yellow);
        }
    }
    public class TriPointDeco : QmeshDeco
    {

        //public GameObject tpnode1;
        //public GameObject tpnode2;
        //public GameObject tpnode3;
        //public GameObject tpnodem;
        //public GameObject tpnoden;

        public GameObject tpmode1;
        public GameObject tpmode2;
        public GameObject tpmode3;
        public GameObject tpmodem;
        public GameObject tpmoden1;
        public GameObject tpmoden2;
        public Vector3 tpmonden_p1;
        public Vector3 tpmonden_p2;
        public Vector3 tpmodenorm;

        public override void InitDecoType()
        {
            decotype = DecoType.TriPoints;
            deconame = "tripoints";
        }

        public void DoOneNode(ref GameObject tpnobj, string nodename, Color color,Vector3 skavek, PrimitiveType ptype,bool wps=false)
        {
            tpnobj = GameObject.CreatePrimitive(ptype);
            skavek *= 0.7f;
            tpnobj.name = nodename;
            tpnobj.transform.localScale = skavek;

            //if (nodename == "tpmodem")
            //{
            //    var (s0, r0, p0) = UnpackTransform(tpmodem.transform);
            //    Debug.Log($"Start Time {Time.time}");
            //    Debug.Log($"Sca {s0}");
            //    Debug.Log($"Rot {r0}");
            //    Debug.Log($"Pos {p0}");
            //}
            tpnobj.transform.SetParent(decoroot.transform,worldPositionStays:wps);
            qut.SetColorOfGo(tpnobj, color);
        }

        public void DoOneNodeNormal(ref GameObject tpnobj, Vector3 tpnnorm, string nodename, Color color, float len, Vector3 skavek, PrimitiveType ptype,bool wps=false)
        {
            tpnobj = GameObject.CreatePrimitive(ptype);
            tpnobj.name = nodename;
            tpnobj.transform.localScale = skavek;
            var p1 = tpnobj.transform.position;
            var p2 = p1 + tpnnorm*len;
            tpnobj = GpuInst.CreateCylinderGpu(null, nodename, p1, p2, 1f, "yellow");

            //if (nodename == "tpmodem")
            //{
            //    var (s0, r0, p0) = UnpackTransform(tpmodem.transform);
            //    Debug.Log($"Start Time {Time.time}");
            //    Debug.Log($"Sca {s0}");
            //    Debug.Log($"Rot {r0}");
            //    Debug.Log($"Pos {p0}");
            //}
            tpnobj.transform.SetParent(decoroot.transform, worldPositionStays: wps);
            qut.SetColorOfGo(tpnobj, color);
        }


        public override void Construct()
        {
            ConstructBase();
            var ska = qmm.triMeshMinLeg * 0.04f;
            var skav = new Vector3(ska, ska, ska);

            //var ptypen = PrimitiveType.Sphere;
            //DoOneNode(ref tpnode1, "tpnode1", Color.red, skav, ptypen, wps:true);
            //DoOneNode(ref tpnode2, "tpnode2", Color.green, skav, ptypen, wps:true);
            //DoOneNode(ref tpnode3, "tpnode3", Color.blue, skav, ptypen, wps:true);
            //DoOneNode(ref tpnodem, "tpnodem", Color.cyan, skav, ptypen, wps:true);

            var ptype = PrimitiveType.Cube;

            DoOneNode(ref tpmode1, "tpmode1", Color.red, skav, ptype, wps:false);
            DoOneNode(ref tpmode2, "tpmode2", Color.green, skav, ptype, wps: false);
            DoOneNode(ref tpmode3, "tpmode3", Color.blue, skav, ptype, wps: false);
            //DoOneNode(ref tpmodem, "tpmodem", Color.cyan, skav, ptype, wps:false);
            //DoOneNodeNormal(ref tpmodem, tpmodenorm, "norm", Color.cyan, len, skav, PrimitiveType.Capsule, wps: false);



            //tpnode1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //tpnode1.name = "tpnode1";
            //tpnode1.transform.localScale = skav;
            //tpnode1.transform.parent = decoroot.transform;

            //tpnode2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //tpnode2.name = "tpnode2";
            //tpnode2.transform.localScale = skav;
            //tpnode2.transform.parent = decoroot.transform;

            //tpnode3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //tpnode3.name = "tpnode3";
            //tpnode3.transform.localScale = skav;
            //tpnode3.transform.parent = decoroot.transform;

            //tpnodem = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //tpnodem.name = "tpnodem";
            //tpnodem.transform.localScale = skam;
            //tpnodem.transform.parent = decoroot.transform;

            //qut.SetColorOfGo(tpnode1, Color.yellow);
            //qut.SetColorOfGo(tpnode2, Color.cyan);
            //qut.SetColorOfGo(tpnode3, Color.magenta);
            //qut.SetColorOfGo(tpnodem, Color.blue);
            Debug.Log("tpnodes constructed");
        }

        (Vector3, Vector3, Vector3) UnpackTransform(Transform t)
        {
            var v1= t.localScale;
            var v2 = t.localRotation.eulerAngles;
            var v3 = t.position;
            return (v1, v2, v3);
        }

        public void MoveObjectTo(Transform tran,Vector3 p)
        {
            var oldpartran = tran.parent;
            var r = tran.localEulerAngles;
            tran.parent = null;
            tran.position = p;
            tran.localEulerAngles = r;
            tran.SetParent(oldpartran, worldPositionStays: false);
        }
        public override void UpdateState()
        {
            if (decoroot != null)
            {
                //tpnode1.transform.position = qmm.bpt1;
                //tpnode2.transform.position = qmm.bpt2;
                //tpnode3.transform.position = qmm.bpt3;
                //tpnodem.transform.position = qmm.bptm;

                //MoveObjectTo(tpmode1.transform, qmm.bpt1);
                //MoveObjectTo(tpmode2.transform, qmm.bpt2);
                //MoveObjectTo(tpmode3.transform, qmm.bpt3);
                //MoveObjectTo(tpmodem.transform, qmm.bptm);

                //tpmode1.transform.parent = null;
                tpmode1.transform.SetParent(null, worldPositionStays: false);// must be false or will accumulate rotation
                tpmode1.transform.position = qmm.bpt1;
                tpmode1.transform.SetParent(decoroot.transform, worldPositionStays: false);

                //tpmode2.transform.parent = null;
                tpmode2.transform.SetParent(null, worldPositionStays: false);// must be false or will accumulate rotation
                tpmode2.transform.position = qmm.bpt2;
                tpmode2.transform.SetParent(decoroot.transform, worldPositionStays: false);


                //tpmode3.transform.parent = null;
                tpmode3.transform.SetParent(null, worldPositionStays: false);// must be false or will accumulate rotation
                tpmode3.transform.position = qmm.bpt3;
                tpmode3.transform.SetParent(decoroot.transform, worldPositionStays: false);

                tpmodenorm = qmm.bptmnorm;

                var d1 = Vector3.Distance(qmm.bpt1, qmm.bpt2);
                var d2 = Vector3.Distance(qmm.bpt2, qmm.bpt3);
                var d3 = Vector3.Distance(qmm.bpt3, qmm.bpt1);
                var len = Mathf.Max(new float[] { d1, d2, d3 })/4;

                var p1 = qmm.bptm - qmm.bptmnorm * len;
                var p2 = qmm.bptm + qmm.bptmnorm * len;

                var useQuatRot = false;
                var useQuatRot2 = true;
                var useDualPoint = true; ;
                if (tpmonden_p1 != p1 || tpmonden_p2 != p2)
                {
                    if (useQuatRot)
                    {
                        if (tpmoden1 != null)
                        {
                            Destroy(tpmoden1);
                        }
                        var pp1 = qmm.bptm - len * Vector3.up;
                        var pp2 = qmm.bptm + len * Vector3.up;
                        tpmoden1 = GpuInst.CreateCylinderGpu(null, "tp_normal_1", pp1, pp2, 1f, "purple");
                        tpmoden1.transform.SetParent(decoroot.transform, worldPositionStays: false);
                        var nrm = qmm.bptmnorm;
                        if (Vector3.Dot(Vector3.up, nrm) < 0)
                        {
                            nrm = -nrm;
                        }
                        var nrmrot = Quaternion.FromToRotation(Vector3.up, nrm);
                        tpmoden1.transform.localRotation = nrmrot;
                    }
                    if (useQuatRot2)
                    {
                        if (tpmoden1 != null)
                        {
                            Destroy(tpmoden1);
                        }
                        tpmoden1 = new GameObject("tp_modem_green");
                        tpmoden1.transform.position = qmm.bptm;
                        {
                            var rod = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                            var rodheight = len;
                            rod.transform.localScale = new Vector3(0.2f, rodheight, 0.2f);
                            rod.transform.position = new Vector3(0, rodheight * 0.75f, 0);
                            rod.transform.SetParent(tpmoden1.transform, worldPositionStays: false);
                            qut.SetColorOfGo(rod, Color.green);
                        }
                        tpmoden1.transform.SetParent(decoroot.transform, worldPositionStays: false);
                        var nrm = qmm.bptmnorm;
                        if (Vector3.Dot(Vector3.up, nrm) < 0)
                        {
                            nrm = -nrm;
                        }
                        var nrmrot = Quaternion.FromToRotation(Vector3.up, nrm);
                        tpmoden1.transform.localRotation = nrmrot;
                    }
                    if (useDualPoint)
                    {
                        if (tpmoden2 != null)
                        {
                            Destroy(tpmoden2);
                        }
                        var len2 = len / 2;
                        var pp1 = qmm.bptm - len2*qmm.bptmnorm;
                        var pp2 = qmm.bptm + len2*qmm.bptmnorm;
                        tpmoden2 = GpuInst.CreateCylinderGpu(null, "tp_normal_2", pp1, pp2, 2f, "yellow");
                        tpmoden2.transform.SetParent(decoroot.transform, worldPositionStays: false);
                    }
                    tpmonden_p1 = p1;
                    tpmonden_p2 = p2;
                    //Debug.Log($"d1:{d1} d2:{d2} d3:{d3} len:{len}");
                }

                //if (nodename == "tpmodem")
                //{
                //    var (s0, r0, p0) = UnpackTransform(tpmodem.transform);
                //    Debug.Log($"Start Time {Time.time}");
                //    Debug.Log($"Sca {s0}");
                //    Debug.Log($"Rot {r0}");
                //    Debug.Log($"Pos {p0}");
                //}

                //var (s0, r0, p0) = UnpackTransform(tpmodem.transform);
                ////tpmodem.transform.parent = null;
                //tpmodem.transform.SetParent(null, worldPositionStays: false);// must be false or will accumulate rotation
                //var (s1, r1, p1) = UnpackTransform(tpmodem.transform);
                //tpmodem.transform.position = qmm.bptm;
                ////tpmodem.transform.localEulerAngles = r0;
                //var (s2, r2, p2) = UnpackTransform(tpmodem.transform);
                //tpmodem.transform.SetParent(decoroot.transform, worldPositionStays: false);
                //var (s3, r3, p3) = UnpackTransform(tpmodem.transform);
                ////Debug.Log($"Time {Time.time}");
                //Debug.Log($"Sca {s0} {s1}  {s2}  {s3}");
                //Debug.Log($"Rot {r0} {r1}  {r2}  {r3}");
                //Debug.Log($"Pos {p0} {p1}  {p2}  {p3}");
            }
        }

    }

    public class SprinklePrefabs : QmeshDeco
    {
        public bool sprinkle;
        public string prefabName = "prefabs";
        public string[] sel = { "Dozer1" };

        public override void InitDecoType()
        {
            decotype = DecoType.SprinklePrefabs;
            deconame = "sprinkles";
        }

        string GetRandomPrefab()
        {
            int i = qut.GetRanInt(0, sel.Length, prefabName);
            var rv = "obj/" + sel[i];
            return rv;
        }

        public override void Construct()
        {
            ConstructBase();
        }

        int nobjs = 0;
        public void Sprinkle(int ndodo = 2)
        {
            var ska = 1.0f;
            var lambmin = 0.1f;
            var lambmax = 0.9f;
            for (int i = 0; i < ndodo; i++)
            {
                var prefabname = GetRandomPrefab();
                var lambx = qut.GetRanFloat(lambmin, lambmax, prefabname);
                var lambz = qut.GetRanFloat(lambmin, lambmax, prefabname);
                (var vv, _, var istat) = qmm.GetWcMeshPosFromLambda(lambz, lambx);
                var vvs = vv.ToString("f1");
                Debug.Log($"Prefab {i} ({prefabname}) at p:{vvs}");
                var pos = vv;
                var rot = qut.GetRanFloat(0, 360, prefabname);
                var prefab = Resources.Load<GameObject>(prefabname);
                if (prefab == null)
                {
                    Debug.Log($"Sprinkle could not load prefab {prefabname} i:{i}");
                    continue;
                }
                Transform t = UnityEngine.Object.Instantiate<Transform>(prefab.transform);
                t.transform.parent = preferedParent.transform;
                ska = 0.016f;
                if (prefabname.Contains("TS!"))
                {
                    ska = 1;
                }
                t.transform.localScale = new Vector3(ska, ska, ska);
                t.transform.localRotation = Quaternion.Euler(0, rot, 0);
                t.transform.position = pos;
                nobjs++;
            }
        }

        public override void UpdateState()
        {
            if (showDeco && sprinkle)
            {
                Sprinkle();
            }
            sprinkle = false;
        }
    }

    public class SprinkleTrucksDeco : SprinklePrefabs
    {
        public override void InitDecoType()
        {
            decotype = DecoType.SprinkleTrucks;
            deconame = "trucks";
            prefabName = "trucks";
            sel = new string[] { "Dozer1", "Dozer2", "Dozer3", "Minehaul1", "DumpTruck_TS1" };
        }
    }

    public class SprinkleTowersDeco : SprinklePrefabs
    {
        public override void InitDecoType()
        {
            decotype = DecoType.SprinkleTowers;
            deconame = "towers";
            prefabName = "towers";
            sel = new string[] { "Tower00", "Tower01", "Tower02", "Tower03", "Tower04" };
        }
    }

    public class TrilinesDeco : QmeshDeco
    {
        public int nHorzLines;
        public int nVertLines;
        public int nDiagLines;
        public int nTotalTriLines;
        public int nTriangles;
        public int nTotalElements;
        public float generationTime;
        public bool addRanPoints;
        public bool addRanLines;
        public bool earlyTerminate;
        public bool wps = true;

        public override void InitDecoType()
        {
            decotype = DecoType.TriLines;
            deconame = "trilines";
        }
        GameObject ranpoints = null;
        public int nranpts = 0;
        public void AddRandomPoints()
        {
            string[] clrs = { "black", "lilac", "yellow", "orange", "red" };
            if (ranpoints == null)
            {
                ranpoints = new GameObject("ranpoints");
                ranpoints.transform.position = Vector3.zero;
                ranpoints.transform.SetParent( preferedParent.transform, worldPositionStays:wps );
            }
            var ska = qmm.triMeshDiag * 0.025f;

            var lmn = -0.1f;
            var lmx = 1.1f;

            var addoutside = false;
            if (addoutside)
            {
                lmn = 0.1f;
                lmx = 0.9f;
            }
            for (int i = 0; i < 10000; i++)
            {
                var lambLat = qut.GetRanFloat(lmn, lmx, "ranpoints");
                var lambLng = qut.GetRanFloat(lmn, lmx, "ranpoints");
                (var vv, var nrm, var istat) = qmm.GetWcMeshPosFromLambda(lambLng, lambLat);
                var pos = vv;
                var name = "ranpt:" + nranpts;
                //QsphInfo.DoInfoSphere(ranpoints, name, pos, ska, clrs[istat], addQsphInfo: false);
                var sphgo = GpuInst.CreateSphereGpu(name, pos, ska, clrs[istat]);
                sphgo.transform.SetParent(ranpoints.transform, worldPositionStays: wps);
                nranpts++;
            }
        }

        GameObject ranlines = null;
        public int nranplines = 0;
        public void AddRandomLines(int nlines = 1)
        {
            string[] clrs = { "black", "lilac", "yellow", "orange", "red" };
            if (ranlines == null)
            {
                ranlines = new GameObject("ranlines");
                ranlines.transform.position = Vector3.zero;
                ranlines.transform.parent = preferedParent.transform;
            }
            var ska = qmm.triMeshDiag * 0.05f;
            //var lmn = 0.1f;
            //var lmx = 0.9f;
            var lmn = -0.1f;
            var lmx = 1.1f;
            for (int i = 0; i < nlines; i++)
            {
                var lambLat1 = qut.GetRanFloat(lmn, lmx, "ranlines");
                var lambLng1 = qut.GetRanFloat(lmn, lmx, "ranlines");
                (var vv1, _, _) = qmm.GetWcMeshPosFromLambda(lambLng1, lambLat1);
                var lambLat2 = qut.GetRanFloat(lmn, lmx, "ranlines");
                var lambLng2 = qut.GetRanFloat(lmn, lmx, "ranlines");
                (var vv2, _, _) = qmm.GetWcMeshPosFromLambda(lambLng2, lambLat2);
                var lname = "ranline:" + nranplines;
                qmm.qtt.AddFragLine(lname, vv1, vv2, ska, nclr: "black",wps:wps);
                nranplines++;
            }
        }

        public IEnumerator YieldingConstruct()
        {
            var sw = new StopWatch();
            ConstructBase();
            var qkm = qmm.qkm;
            var qtt = qmm.qtt;

            var ska = qmm.triMeshMinLeg * 0.02f;
            Debug.Log($"Construct Trilinesdeco - ska:{ska}  triDiag:{qmm.triMeshDiag}");


            var nHorzSecs = qmm.nHorzSecs;
            var nVertSecs = qmm.nVertSecs;
            var nDiagSecs = nHorzSecs + nVertSecs - 1;
            Vector3 p1, p2;
            string pname;
            int nlines = 0;
            int nhlines = 0;
            int nvlines = 0;
            int ndlines = 0;
            int nsegs = 0;
            bool wpsloc = false;
            for (int i = 0; i <= nHorzSecs; i++)
            {
                nlines++;
                p1 = qmm.GetMeshNodePos(i, 0);
                for (int j = 1; j <= nVertSecs; j++)
                {
                    p2 = qmm.GetMeshNodePos(i, j);
                    pname = $"horzseg_{i}_{j}";
                    var cgo = GpuInst.CreateCylinderGpu(pname, p1, p2, ska, "cyan");
                    cgo.transform.SetParent(decoroot.transform,worldPositionStays:wpsloc);
                    p1 = p2;
                    nsegs++;
                }
                nhlines++;
                if (sw.ElapfOverYieldTime())
                {
                    Debug.Log($"Yielding at horzlines step:{i}");
                    yield return null;
                    if (earlyTerminate) break;
                }
            }
            if (!earlyTerminate)
            {
                for (int i = 0; i <= nVertSecs; i++)
                {
                    nlines++;
                    p1 = qmm.GetMeshNodePos(0, i);
                    for (int j = 1; j <= nHorzSecs; j++)
                    {
                        p2 = qmm.GetMeshNodePos(j, i);
                        pname = $"vertseg_{j}_{i}";
                        var cgo = GpuInst.CreateCylinderGpu(pname, p1, p2, ska, "yellow");
                        cgo.transform.SetParent(decoroot.transform, worldPositionStays: wpsloc);
                        p1 = p2;
                        nsegs++;
                    }
                    nvlines++;
                    if (sw.ElapfOverYieldTime())
                    {
                        Debug.Log($"Yielding at vertlines step:{i}");
                        yield return null;
                        if (earlyTerminate) break;
                    }
                }
            }

            if (!earlyTerminate)
            {
                for (int i = 0; i < nHorzSecs; i++)
                {
                    nlines++;
                    for (int j = 0; j < nVertSecs; j++)
                    {
                        p1 = qmm.GetMeshNodePos(i, j);
                        p2 = qmm.GetMeshNodePos(i + 1, j + 1);
                        pname = $"crosseg_{i}_{j}";
                        var cgo = GpuInst.CreateCylinderGpu(pname, p1, p2, ska, "purple");
                        cgo.transform.SetParent(decoroot.transform, worldPositionStays: wpsloc);
                        nsegs++;
                    }
                    ndlines++;
                    if (sw.ElapfOverYieldTime())
                    {
                        Debug.Log($"Yielding at diaglines step:{i}");
                        yield return null;
                        if (earlyTerminate) break;
                    }
                }

            }


            this.nDiagLines = ndlines;
            this.nHorzLines = nhlines;
            this.nVertLines = nvlines;
            this.nTotalTriLines = nHorzLines + nVertLines + nDiagLines;
            this.nTriangles = (qtt.nHorzLines - 1) * (qtt.nVertLines - 1) * 2;
            this.nTotalElements = (nDiagLines - 1) * nVertLines + (nVertLines - 1) * nHorzLines + nTriangles;
            sw.Stop();
            Debug.Log($"Generating {nTotalTriLines} trilines with {nTotalElements} elements took {sw.ElapSecs(3)} secs");
            earlyTerminate = false;
            //qmm.layerman.Reattach(deconame);
            //AttachToParent();
            yield return null;
        }

        public override void Construct()
        {
            StartCoroutine(YieldingConstruct());
        }

        public override void UpdateState()
        {
            if (addRanPoints)
            {
                AddRandomPoints();
                addRanPoints = false;
            }
            if (addRanLines)
            {
                AddRandomLines();
                addRanLines = false;
            }
        }
    }

    public class MeshNodesDeco : QmeshDeco
    {
        public bool earlyTerminate;
        public bool interpColors;
        public bool largeNodes;
        public GeotiffMan gtm;
        public override void InitDecoType()
        {
            decotype = DecoType.MeshNodes;
            deconame = "meshnodes";
            interpColors = true;
            gtm = FindObjectOfType<GeotiffMan>();
        }

        IEnumerator YieldingConstruct()
        {
            if (gtm == null)
            {
                gtm = FindObjectOfType<GeotiffMan>();
            }
            var sw = new StopWatch();
            sw.Start();
            ConstructBase();
            var nHorzSecs = qmm.nHorzSecs;
            var nVertSecs = qmm.nVertSecs;
            var ska = qmm.triMeshDiag * 0.1f;
            if (largeNodes)
            {
                ska *= 4;
            }
            Geotiff.InitOorDict();
            ColorInterpolator clritrp = null;
            if (gtm != null)
            {
                var (minElev, maxElev, avgElev) = gtm.GetElevFiltStats();
                Debug.Log($"EN: minElev:{minElev} maxElev:{maxElev} avgElev:{avgElev}");
                clritrp = new ColorInterpolator(maxElev, avgElev, minElev);
                //clritrp.SetColors(Color.red, Color.yellow, Color.green);
            }


            int imn = 0;
            string cmt = "";
            for (int i = 0; i <= nHorzSecs; i++)
            {
                for (int j = 0; j <= nVertSecs; j++)
                {
                    var pos = qmm.GetMeshNodePos(i, j);
                    var sname = "nd:" + i + "-" + j;
                    var ll = qmm.GetMeshNodeLatLng(i, j);
                    var clr = "yellow";
                    var edb = false;
                    //if ((i == 128 && j == 83) || (i == 128 && j == 84))
                    //{
                    //    //edb = true;
                    //    //clr = "cyan";
                    //}
                    if (gtm != null)
                    {
                        var (isin, elev) = gtm.GetElev(pos.x, pos.z, edb);
                        if (edb)
                        {
                            Debug.Log($"GetElev {sname} isin:{isin}  elev:{elev}");
                        }
                        if (isin)
                        {
                            clr = clritrp.GetInterpColorHex(elev);
                        }
                        cmt = gtm.GetElevCmt(pos.x, pos.z);
                    }
                    var sphinfo = QsphInfo.DoInfoCubeSlim(decoroot, sname + " " + cmt, pos, ska, clr, ll,wps:false);
                    var info = new QsphNodeInfo();
                    info.vertCoord.x = i;
                    info.globalMeshCoord = new MeshCoord(i, j, nHorzSecs, nVertSecs);
                    sphinfo.SetNodeInfo(info);
                    imn++;
                }
                if (sw.ElapfOverYieldTime())
                {
                    //Debug.Log($"Yielding on node {imn}");
                    yield return null;
                    if (earlyTerminate) break;
                }
            }
            sw.Stop();
            Debug.Log($"Generated {imn} meshnodes in {sw.ElapSecs(3)} secs");
            Geotiff.ReportOorErrors();
            earlyTerminate = false;
            yield return null;
        }

        public override void Construct()
        {
            StartCoroutine(YieldingConstruct());
        }
    }

    public class CoordDefiningNodesDeco : QmeshDeco
    {

        public override void InitDecoType()
        {
            decotype = DecoType.CoordDefNodes;
            deconame = "coordefnodes";
        }

        public override void Construct()
        {
            ConstructBase();

            var ska = qmm.triMeshDiag * 0.5f;
            int i = 0;
            foreach (var md in qmm.llmapqkcoords.mapcoord.mapdata)
            {
                var sname = "mc:" + i;
                //var v = llmap.mapcoord.glbmap(md.x, 0, md.z);
                var ll = new LatLng(md.lat, md.lng);
                var posll = qmm.GetPosFromLatLng(ll);
                var pos = new Vector3((float)md.x, posll.y, (float)md.z);
                var spi = QsphInfo.DoInfoSphere(decoroot, sname, pos, ska, "orange", ll, wps:false);
                spi.mapPoint = md;
                i++;
            }
        }
    }

    public class ExtendDefiningNodesDeco : QmeshDeco
    {

        public override void InitDecoType()
        {
            decotype = DecoType.ExtentDefNodes;
            deconame = "extentdefnodes";
        }

        public override void Construct()
        {
            ConstructBase();

            var ska = qmm.triMeshDiag * 0.5f;
            var qkm = qmm.qkm;

            //var pos1 = GetPosFromLatLng(qkm.ll1, yval0);
            var pos1 = qmm.GetPosFromLatLng(qkm.ll1);
            var name1 = "ll1";
            QsphInfo.DoInfoSphere(decoroot, name1, pos1, ska, "red", qkm.ll1, wps:false);

            //var pos2 = GetPosFromLatLng(qkm.ll2, yval1);
            var pos2 = qmm.GetPosFromLatLng(qkm.ll2);
            var name2 = "ll2";
            QsphInfo.DoInfoSphere(decoroot, name2, pos2, ska, "red", qkm.ll2, wps: false);

            //var pos3 = GetPosFromLatLng(qkm.tileul.llul, yval0);
            var pos3 = qmm.GetPosFromLatLng(qkm.tileul.llul);
            var name3 = "qkt_ll_ul";
            QsphInfo.DoInfoSphere(decoroot, name3, pos3, ska, "blue", qkm.tileul.llul, wps: false);
            //var pos4 = GetPosFromLatLng(qkm.tilebr.llbr, yval1);
            var pos4 = qmm.GetPosFromLatLng(qkm.tilebr.llbr);
            var name4 = "qkt_ll_br";
            QsphInfo.DoInfoSphere(decoroot, name4, pos4, ska, "blue", qkm.tilebr.llbr, wps: false);
        }
    }

    public class NativeMapNodesDeco : QmeshDeco
    {

        public override void InitDecoType()
        {
            decotype = DecoType.NativeNodes;
            deconame = "nativemapnodes";
        }

        public override void Destruct()
        {
            qmm.llmapqkcoords.mapcoord.DestroyNativeCoordMarkers();
        }

        public override void Construct()
        {
            ConstructBase();
            var ska = qmm.qkm.llbox.diagonalInMeters / 250;
            qmm.llmapqkcoords.mapcoord.MakeNativeCoordMarkers(ska: ska, clr: "purple",wps:false);
        }
    }

    public class FrameQuadkeysDeco : QmeshDeco
    {
        public bool earlyTerminate = false;
        public bool singlepipe = false;
        public bool showQuadkeyLabels = false;
        public override void InitDecoType()
        {
            decotype = DecoType.FrameQuadKeys;
            deconame = "framequadkeys";
        }

        IEnumerator YieldingConstruct()
        {
            var sw = new StopWatch();
            sw.Start();
            ConstructBase();

            var qkm = qmm.qkm;

            var ska = qmm.triMeshDiag * 0.075f;
            ska = ska / 2;

            var qtt = qmm.qtt;
            int i = 0;
            GameObject pipeu, piper, pipeb, pipel;
            foreach (var qktile in qkm.qktiles)
            {
                var llul = qktile.llul;
                var llbr = qktile.llbr;
                //Debug.Log($"fqm {i}  llul:{llul.ToString()} llbr:{llbr}");
                var llur = new LatLng(llul.lat, llbr.lng);
                var llbl = new LatLng(llbr.lat, llul.lng);
                var pul = qmm.GetPosFromLatLng(llul);
                var pur = qmm.GetPosFromLatLng(llur);
                var pbl = qmm.GetPosFromLatLng(llbl);
                var pbr = qmm.GetPosFromLatLng(llbr);
                var puls = pul.ToString("f3");
                var pbrs = pbr.ToString("f3");
                //Debug.Log($"    {i}   pul:{puls} pbr:{pbrs}");
                var qkname = qktile.name;
                var qkgo = new GameObject(qkname);
                qkgo.transform.position = (pul + pur + pbl + pbr) / 4;

                //qkgo.transform.parent = decoroot.transform;

                if (singlepipe)
                {
                    QsphInfo.DoInfoSphere(qkgo, "pur" + i, pur, ska, "navyblue", llur);
                    pipeu = qtt.AddStraightLine(qkgo, qkname + "-u", pul, pur, ska, lclr: "orange", coordsys: QkCoordSys.QkWc);
                    piper = qtt.AddStraightLine(qkgo, qkname + "-r", pur, pbr, ska, lclr: "orange", coordsys: QkCoordSys.QkWc);
                    pipeb = qtt.AddStraightLine(qkgo, qkname + "-b", pbr, pbl, ska, lclr: "orange", coordsys: QkCoordSys.QkWc);
                    pipel = qtt.AddStraightLine(qkgo, qkname + "-l", pbl, pul, ska, lclr: "orange", coordsys: QkCoordSys.QkWc);

                    //pipeu = GpuInst.CreateCylinderGpu(qkgo, qkname + "-u", pul, pur, ska, "cyan");
                    //piper = GpuInst.CreateCylinderGpu(qkgo, qkname + "-r", pur, pbr, ska, "cyan");
                    //pipeb = GpuInst.CreateCylinderGpu(qkgo, qkname + "-b", pbr, pbl, ska, "cyan");
                    //pipel = GpuInst.CreateCylinderGpu(qkgo, qkname + "-l", pbl, pul, ska, "cyan");
                }
                else
                {
                    QsphInfo.DoInfoSphereSlim(qkgo, "pur" + i, pur, ska, "navyblue", llur);
                    pipeu = qtt.AddFragLine(qkgo, qkname + "-u", pul, pur, ska, lclr: "red",nclr:"blue",coordsys: QkCoordSys.QkWc);
                    piper = qtt.AddFragLine(qkgo, qkname + "-r", pur, pbr, ska, lclr: "blue",nclr:"red", coordsys: QkCoordSys.QkWc);
                    pipeb = qtt.AddFragLine(qkgo, qkname + "-b", pbr, pbl, ska, lclr: "green", nclr: "yellow", coordsys: QkCoordSys.QkWc);
                    pipel = qtt.AddFragLine(qkgo, qkname + "-l", pbl, pul, ska, lclr: "yellow", nclr: "green", coordsys: QkCoordSys.QkWc);
                }
                if (showQuadkeyLabels)
                {
                    qut.MakeTextGo(qkgo, qkname, yoff: 100, backoff: 0.01f, sfak: 20);
                }
                if (sw.ElapfOverYieldTime())
                {
                    //Debug.Log($"Yielding on qktile frame {i} of {qkm.qktiles.Count}");
                    yield return null;
                    if (earlyTerminate) break;
                }
                qkgo.transform.SetParent(decoroot.transform, worldPositionStays: false);

                i++;
            }
            sw.Stop();
            Debug.Log($"Framed {i} tiles in {sw.ElapSecs(3)} secs");
            earlyTerminate = false;
            //qmm.layerman.Reattach(deconame);
            yield return null;
        }

        public override void Construct()
        {
            StartCoroutine(YieldingConstruct());
        }
    }

    public class ShowSubMeshNodes : QmeshDeco
    {
        public bool showJustEdges = false;


        public override void InitDecoType()
        {
            decotype = DecoType.SubMeshShowNodes;
            deconame = "submeshnodes";
        }
        public string GetColor(int ix, int iz)
        {
            var clr = "black";
            if (ix == 0) clr = "blue";
            if (ix == mfw.nHorzSecsInMf) clr = "cyan";
            if (iz == 0) clr = "red";
            if (iz == mfw.nVertSecsInMf) clr = "yellow";
            return clr;
        }
        public override void Construct()
        {
            ConstructBase();

            var qkm = qmm.qkm;

            var ska = 4 * mfw.skamult * qmm.qkm.llbox.diagonalInMeters / 650;
            var cylsphthickratio = 10f;
            var normlength = 2 * ska;
            int imn = 0;
            bool drawnorm = true;
            var nVertSecs = mfw.nVertSecsInMf;
            var nHorzSecs = mfw.nHorzSecsInMf;
            var irowstart = mfw.irowstart;
            for (int iz = 0; iz <= nVertSecs; iz++)
            {
                var isOnEdgeZmn = (iz == 0);
                var isOnEdgeZmx = (iz == nVertSecs);
                var iz1 = irowstart + iz;
                for (int ix = 0; ix <= nHorzSecs; ix++)
                {
                    var isOnEdgeXmn = (ix == 0);
                    var isOnEdgeXmx = (ix == nHorzSecs);
                    var isOnEdge = isOnEdgeZmn || isOnEdgeZmx || isOnEdgeXmn || isOnEdgeXmx;
                    if (showJustEdges && !isOnEdge)
                    {
                        continue;
                    }
                    var pos = qmm.GetMeshNodePos(ix, iz1);
                    var sname = "node:" + ix + "-" + iz1 + "/" + iz;
                    //Debug.Log("making " + sname);
                    var ll = qmm.GetMeshNodeLatLng(ix, iz1);

                    var clr = GetColor(ix, iz);
                    var spi = QsphInfo.DoInfoSphereSlim(decoroot, sname, pos, ska, clr, ll,wps:false);

                    var spni = new QsphNodeInfo();
                    //meshnodespis[ix, iz] = spni;
                    spni.globalMeshCoord = new MeshCoord(ix, iz1, nHorzSecs,nVertSecs);
                    spni.localMeshCoord = new MeshCoord(ix, iz, nHorzSecs, nVertSecs);
                    var spos = mfw.GetPosLocal(ix, iz);
                    var snrm = mfw.GetNormalLocal(ix, iz);
                    spni.vertCoord = spos;
                    spni.normal1 = snrm;
                    if (drawnorm)
                    {
                        var nname = "vorm:" + ix + "-" + iz1 + "/" + iz;
                        var epos = spos + snrm * normlength;
                        //var nrmgo = qut.CreatePipe(nname, spos, epos, ska / cylsphthickratio, "yellow");
                        var nrmgo = GpuInst.CreateCylinderGpu(nname, spos, epos, size: ska / cylsphthickratio, "yellow");
                        nrmgo.transform.SetParent(decoroot.transform, worldPositionStays:false);
                    }

                    var uv = qmm.GetUv(ix, iz1);
                    spni.textureCoord = new TextureCoord(uv.x, uv.y);
                    spi.SetNodeInfo(spni);
                    imn++;
                }
            }
            Debug.Log("Generated " + imn + " meshwrapnodes");
        }
    }

    public class ShowGeotiffFrames : QmeshDeco
    {
        public bool showLabels;
        public bool showFrames;
        public bool showMarkers;
        public bool interpColors;
        public int nframes;
        GeotiffMan gtm = null;
        public override void InitDecoType()
        {
            decotype = DecoType.SubMeshShowNodes;
            deconame = "geotiffnodes";
            nframes = df.Nrow();
            showLabels = true;
            showFrames = true;
            showMarkers = false;
            interpColors = true;
        }
        public void InitGeotiff(GeotiffMan gtm)
        {
            this.gtm = gtm;
        }
        List<GameObject> fgos = null;

        public void CreateFgo(int index)
        {
            var gt = gtm.GetGeotiff(index);
            if (gt.loading) return;

            var ska = qmm.triMeshDiag * 0.3f;
            var fgo = new GameObject(gt.gname);
            fgo.transform.position = gt.transform.position;
            if (decoroot != null)
            {
                fgo.transform.parent = decoroot.transform;// probably wrong needs to be setparent false
            }

            var gname = gt.gname;

            var skan = ska * 2;
            gt.CalculateCornerPoints();
            QsphInfo.DoInfoSphere(fgo, "bl-ll1", gt.pbl, skan, "red", gt.ll1);
            QsphInfo.DoInfoSphere(fgo, "br-ll2", gt.pbr, skan, "green", gt.ll2);
            QsphInfo.DoInfoSphere(fgo, "ur-ll3", gt.pur, skan, "blue", gt.ll3);
            QsphInfo.DoInfoSphere(fgo, "ul-ll4", gt.pul, skan, "yellow", gt.ll4);

            if (showFrames)
            {
                var qtt = qmm.qtt;
                qtt.AddFragLine(fgo, $"b-{gname}", gt.pbl, gt.pbr, ska, lclr: "blue", nclr: "blue");
                qtt.AddFragLine(fgo, $"r-{gname}", gt.pbr, gt.pur, ska, lclr: "red", nclr: "red");
                qtt.AddFragLine(fgo, $"u-{gname}", gt.pur, gt.pul, ska, lclr: "purple", nclr: "purple");
                qtt.AddFragLine(fgo, $"l-{gname}", gt.pul, gt.pbl, ska, lclr: "green", nclr: "green");
            }

            if (showMarkers)
            {
                var (nrow, ncol, nfx, nfz) = gt.GetElevFiltDimension();
                var (minElev, maxElev, avgElev) = gt.GetElevFiltStats();
                ColorInterpolator clritrp = null;
                if (interpColors)
                {
                    clritrp = new ColorInterpolator(maxElev, avgElev, minElev);
                    //clritrp.SetColors(Color.red, Color.yellow, Color.green);
                }

                if (nrow > 0 && ncol > 0)
                {
                    for (int iCol = 0; iCol < nfx; iCol++)
                    {
                        for (int iRow = 0; iRow < nfz; iRow++)
                        {
                            var (p, sz, elev) = gt.GetElevFiltPosition(iCol, iRow);
                            var cubename = $"ev-{iCol}-{iRow}";
                            string cname = "red";
                            if (interpColors)
                            {
                                cname = clritrp.GetInterpColorHex(elev);
                            }
                            p.y = sz.y;
                            sz.y = 1;
                            QsphInfo.DoInfoCubeSlim(fgo, cubename, p, sz, cname, addQsphInfo: false);
                        }

                    }
                }
            }

            if (showLabels)
            {
                var elevmeans = gt.elevmean.ToString("f1");
                var lab = $"{gname}\n{elevmeans}";
                qut.MakeTextGo(fgo, lab, yoff: 100, backoff: 0.01f, sfak: 20, bkclr: "yellow");
            }
            fgos[index] = fgo;
        }


        public override void Construct()
        {
            ConstructBase();
            fgos = new List<GameObject>();
            var nfr = df.Nrow();
            for (int i = 0; i < nfr; i++)
            {
                fgos.Add(null);
            }
            UpdateFgos();
        }
        public void UpdateFgos()
        {
            //Debug.Log("UpdateFgos");
            if (fgos != null)
            {
                var nfr = df.Nrow();
                for (int idx = 0; idx < nfr; idx++)
                {
                    if (showDeco && gtm.activecol[idx])
                    {
                        if (fgos[idx] == null)
                        {
                            CreateFgo(idx);
                        }
                    }
                    else
                    {
                        if (fgos[idx] != null)
                        {
                            Destroy(fgos[idx]);
                            fgos[idx] = null;
                        }
                    }
                }
            }
        }
    }
}