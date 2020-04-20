using UnityEngine;

namespace Aiskwk.Map
{
    public class MfWrap : MonoBehaviour
    {
        public QmapMesh qmm;

        [Header("Extent and Tesellation")]
        public int irowstart;
        public int irowend;
        public int nrow;
        public int nHorzSecsInMf;
        public int nVertSecsInMf;
        public int totalVerts;
        public int totalTris;

        [Header("Garnish")]


        [Range(0f, 10f)]
        public float skamult = 1;
        ShowSubMeshNodes ssmn;

        public void Init(QmapMesh qkman, int irowstart, int nrow, int nHorzSecsInMf, int nVertSecsInMf)
        {
            this.qmm = qkman;
            gameObject.AddComponent<MeshFilter>();
            gameObject.AddComponent<MeshRenderer>();
            this.irowstart = irowstart;
            this.irowend = irowstart + nrow - 1;
            this.nrow = nrow;
            this.nHorzSecsInMf = nHorzSecsInMf;
            this.nVertSecsInMf = nVertSecsInMf;
            ssmn = this.gameObject.AddComponent<ShowSubMeshNodes>();
            ssmn.Init(qmm, qmm.decoParent, this);
            //Debug.Log($"InitMf - irowstart:{irowstart} nrow:{nrow} nHorzSecsInMf:{nHorzSecsInMf} nVertSecsInMf:{nVertSecsInMf}");
        }

        public void UpdateStats()
        {
            totalTris = GetComponent<MeshFilter>().mesh.triangles.Length;
            totalVerts = GetComponent<MeshFilter>().mesh.vertices.Length;
        }

        int GetVertIndex(int ix, int iz)
        {
            return iz * (nHorzSecsInMf + 1) + ix;
        }

        public void AdjustHeights(float adjustval)
        {
            var mf = GetComponent<MeshFilter>();
            if (mf == null) return;
            var verts = mf.mesh.vertices;
            var len = verts.Length;
            if (verts != null)
            {
                for (var idx = 0; idx < len; idx++)
                {
                    var v = verts[idx];
                    verts[idx] = new Vector3(v.x, v.y - adjustval, v.z);
                }
                mf.mesh.vertices = verts;
            }
        }

        int GetNormIndex(int ix, int iz)
        {
            return iz * (nHorzSecsInMf + 1) + ix;
        }

        public static void ZipUpNormals(MfWrap mfw1, MfWrap mfw2, NormalAvgMethod method)
        {
            //Debug.Log("Starting ZipUpNormalsOld - method:" + method);
            var sw = new StopWatch();
            if (method == NormalAvgMethod.DoNothing) return;

            if (mfw1.nHorzSecsInMf != mfw2.nHorzSecsInMf)
            {
                Debug.LogError("Can't zip up MfWrap normals if nHorzSecs are unequal");
                return;
            }
            var mf1 = mfw1.GetComponent<MeshFilter>();
            var mf2 = mfw2.GetComponent<MeshFilter>();
            var norms1 = mf1.mesh.normals;
            var norms2 = mf2.mesh.normals;
            var iz1 = mfw1.nVertSecsInMf;
            var iz2 = 0;
            for (var ix = 0; ix <= mfw1.nHorzSecsInMf; ix++)
            {
                var idx1 = mfw1.GetNormIndex(ix, iz1);
                var idx2 = mfw1.GetNormIndex(ix, iz2);
                var n1 = norms1[idx1];
                var n2 = norms2[idx2];
                var n3 = Vector3.up;
                switch (method)
                {
                    case NormalAvgMethod.Norm1:
                        n3 = n1;
                        break;
                    case NormalAvgMethod.Norm2:
                        n3 = n2;
                        break;
                    case NormalAvgMethod.Avg:
                        n3 = n1 + n2;
                        break;
                    case NormalAvgMethod.AlwaysUp:
                        n3 = Vector3.up;
                        break;
                    case NormalAvgMethod.AlwaysUpLeft:
                        n3 = new Vector3(1, 1, 0);
                        break;
                    case NormalAvgMethod.Zero:
                        n3 = Vector3.zero;
                        break;
                }
                n3 = n3.normalized;
                norms1[idx1] = n3;
                norms2[idx2] = n3;
            }
            mf1.mesh.normals = norms1;
            mf2.mesh.normals = norms2;
            sw.Stop();
            //Debug.Log("Did ZipUpNormals - method:" + method+" elap:"+sw.ElapSecs(5)+" secs");
        }

        public Vector3[,] GetNormalBlock()
        {
            var newblock = new Vector3[nHorzSecsInMf + 1, nVertSecsInMf + 1];
            for (int iz = 0; iz <= nVertSecsInMf; iz++)
            {
                for (int ix = 0; ix <= nHorzSecsInMf; ix++)
                {
                    newblock[ix, iz] = GetNormalLocal(ix, iz);
                }
            }
            return newblock;
        }
        public Vector3[] GetNormalBlockOneDim()
        {
            var newblock = new Vector3[(nHorzSecsInMf + 1) * (nVertSecsInMf + 1)];
            for (int iz = 0; iz <= nVertSecsInMf; iz++)
            {
                for (int ix = 0; ix <= nHorzSecsInMf; ix++)
                {
                    var idx = iz * (nHorzSecsInMf + 1) + ix;
                    newblock[idx] = GetNormalLocal(ix, iz);
                }
            }
            return newblock;
        }

        public void SetNormalBlockOneDimOld(Vector3[] newblock)
        {
            for (int iz = 0; iz <= nVertSecsInMf; iz++)
            {
                for (int ix = 0; ix <= nHorzSecsInMf; ix++)
                {
                    var ix1 = ix;
                    var iz1 = iz;
                    //if (ix > 5) ix1 -= 5;
                    //if (iz > 5) iz1 -= 5;
                    var idx = iz * (nHorzSecsInMf + 1) + ix;
                    SetNormalLocal(ix1, iz1, newblock[idx]);
                    //SetNormalLocal(ix1, iz1, Vector3.zero);
                }
            }
        }
        public void SetNormalBlockOneDim(Vector3[] newblock)
        {
            var norms = GetComponent<MeshFilter>().mesh.normals;
            //for (int iz = 0; iz <= nVertSecs; iz++)
            //{
            //    for (int ix = 0; ix <= nHorzSecs; ix++)
            //    {
            //        var idx = iz * (nHorzSecs + 1) + ix;
            //        norms[idx] = newblock[idx];
            //    }
            //}
            GetComponent<MeshFilter>().mesh.normals = newblock;
        }

        GameObject meshnodes = null;
        public void DeleteMeshNodes()
        {
            if (meshnodes != null)
            {
                Destroy(meshnodes);
                meshnodes = null;
            }
        }


        bool CheckLocalIdx(int locIx, int locIz, bool complain = true)
        {
            if (locIx < 0 || nHorzSecsInMf < locIx)
            {
                if (complain)
                {
                    Debug.LogError("MfWratp.GetPos ix out of range ix:" + locIx + " nHorzSecs:" + nHorzSecsInMf);
                }
                return false;
            }
            if (locIz < 0 || nVertSecsInMf < locIz)
            {
                if (complain)
                {
                    Debug.LogError("MfWratp.GetPos iz out of range iz:" + locIz + " nVertSecs:" + nVertSecsInMf);
                }
                return false;
            }
            return true;
        }

        public Vector3 GetPosLocal(int ix, int iz)
        {
            if (!CheckLocalIdx(ix, iz)) return Vector3.zero;
            var verts = GetComponent<MeshFilter>().mesh.vertices;
            var idx = ix + iz * (nHorzSecsInMf + 1);
            return verts[idx];
        }
        public Vector3 GetNormalLocal(int ix, int iz)
        {
            if (!CheckLocalIdx(ix, iz)) return Vector3.zero;
            var norms = GetComponent<MeshFilter>().mesh.normals;
            var idx = ix + iz * (nHorzSecsInMf + 1);
            return norms[idx];
        }
        void SetNormalLocal(int ix, int iz, Vector3 newNorm)
        {
            if (!CheckLocalIdx(ix, iz)) return;
            var norms = GetComponent<MeshFilter>().mesh.normals;
            var locidx = ix + iz * (nHorzSecsInMf + 1);
            norms[locidx] = newNorm;
            //Debug.Log("Setting normal " + locidx);
            GetComponent<MeshFilter>().mesh.normals = norms;// this is necessary, probably triggers something
        }


        int updcount = 0;

        void Update()
        {
            updcount++;
        }
    }
}