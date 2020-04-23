using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aiskwk.Map
{

    [System.Serializable]
    internal struct TextureCoord
    {
        public float u;
        public float v;
        public TextureCoord(float u, float v)
        {
            this.u = u;
            this.v = v;
        }
    }

    [System.Serializable]
    internal struct MeshCoord
    {
        public int i;
        public int j;
        public MeshCoord(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
    }

    [System.Serializable]
    public class QsphNodeInfo
    {
        internal MeshCoord globalMeshCoord;
        internal MeshCoord localMeshCoord;
        internal Vector3 vertCoord;
        internal TextureCoord textureCoord;
        internal Vector3 normal1;
        internal Vector3 normal2;
    }

    public class QsphInfo : MonoBehaviour
    {
        // Start is called before the first frame update
        public LatLng latLng = null;
        private QsphNodeInfo nodeInfo = null;
        public MapCoordPoint mapPoint = null;

        static GameObject sphgo = null;

        public static void DoInfoSphereSlimOld(GameObject parent, string sname, Vector3 pos, float ska, string color, LatLng ll = null)
        {
            if (sphgo == null)
            {
                sphgo = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //qut.SetColorOfGo(sphgo, color);
            }
            var spht = Instantiate(sphgo.transform);
            spht.parent = parent.transform;
            spht.position = pos;
            spht.localScale = new Vector3(ska, ska, ska);
        }
        public void SetNodeInfo(QsphNodeInfo spni)
        {
            this.nodeInfo = spni;
        }
        public static QsphInfo DoInfoSphereSlim(GameObject parent, string sname, Vector3 pos, float ska, string color, LatLng ll = null, bool addSphInfo = true)
        {
            var sphtran = GpuInst.CreateSphereGpu(sname, pos, ska, color);
            sphtran.transform.parent = parent.transform;
            QsphInfo spi = null;
            if (addSphInfo)
            {
                spi = sphtran.gameObject.AddComponent<QsphInfo>();
                spi.latLng = ll;
                spi.nodeInfo = null;
            }
            return spi;
        }
        public static QsphInfo DoInfoCubeSlim(GameObject parent, string sname, Vector3 pos, float ska, string color, LatLng ll = null, bool addQsphInfo = true)
        {
            var cubtran = GpuInst.CreateCubeGpu(sname, pos, ska, color);
            cubtran.transform.parent = parent.transform;
            QsphInfo spi = null;
            if (addQsphInfo)
            {
                spi = cubtran.gameObject.AddComponent<QsphInfo>();
                spi.latLng = ll;
                spi.nodeInfo = null;
            }
            return spi;
        }
        public static QsphInfo DoInfoCubeSlim(GameObject parent, string sname, Vector3 pos, Vector3 size, string color, LatLng ll = null, bool addQsphInfo = true)
        {
            var cubtran = GpuInst.CreateCubeGpu(sname, pos, size, color);
            cubtran.transform.parent = parent.transform;
            QsphInfo spi = null;
            if (addQsphInfo)
            {
                spi = cubtran.gameObject.AddComponent<QsphInfo>();
                spi.latLng = ll;
                spi.nodeInfo = null;
            }
            return spi;
        }
        public static QsphInfo DoInfoSphere(GameObject parent, string sname, Vector3 pos, float ska, string color, LatLng ll = null, bool addSphInfo = true)
        {
            var sphgo = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //var sph = Instantiate(sphgo);
            sphgo.name = sname;
            sphgo.transform.parent = parent.transform;
            sphgo.transform.position = pos;
            sphgo.transform.localScale = new Vector3(ska, ska, ska);
            qut.SetColorOfGo(sphgo, color);
            QsphInfo spi = null;
            if (addSphInfo)
            {
                spi = sphgo.AddComponent<QsphInfo>();
                spi.latLng = ll;
                spi.nodeInfo = null;
            }
            return spi;
        }
    }
}