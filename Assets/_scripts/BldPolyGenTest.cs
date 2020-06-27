using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BldPolyGenTest : MonoBehaviour
{
    BldPolyGen bpg;
    // Start is called before the first frame update
    void Start()
    {
        // debug one layer only
        GenObj(ObjForm.circle, dowalls:false,doceil:true,dofloor:false,dbOutline:false);
        //GenObj(ObjForm.circle,onesided:false);
    }


    enum ObjForm { star, cross, circle }
    void GenObj(ObjForm objform, bool dowalls = true, bool doceil = true, bool dofloor = true, bool dbOutline = false, bool onesided=false)
    {
        var alf = 0.5f;
        //alf = 1;

        bpg = new BldPolyGen();
        switch (objform)
        {
            default:
            case ObjForm.star:
                {
                    bpg.GenStarOutline(Vector3.zero, 8, 0.5f, 3f);
                    break;
                }
            case ObjForm.cross:
                {
                    bpg.GenCrossOutline(Vector3.zero,  2f );
                    break;
                }
            case ObjForm.circle:
                {
                    bpg.GenCylinderOutline(Vector3.zero, 20, 1f);
                    break;
                }
        }
        if (dowalls)
        {
            bpg.SetGenForm(BldPolyGenForm.wallsmesh);
            var walgo = bpg.GenMesh("walls", height: 2, clr: "blue", alf: alf,dbout:dbOutline, onesided:onesided);
            walgo.transform.parent = this.transform;
        }
        if (doceil)
        {
            bpg.SetGenForm(BldPolyGenForm.tesselate);
            var ceigo = bpg.GenMesh("ceiling", height: 2, clr: "blue", alf: alf, dbout: dbOutline, onesided: onesided);
            ceigo.transform.parent = this.transform;
        }
        if (dofloor)
        {
            bpg.SetGenForm(BldPolyGenForm.tesselate);
            var fl1go = bpg.GenMesh("floor1", height: 1, clr: "blue", alf: alf, dbout: dbOutline, onesided: onesided);
            fl1go.transform.parent = this.transform;
        }
    }
}
