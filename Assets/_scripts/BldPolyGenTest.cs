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
        bpg = new BldPolyGen();
        // debug one layer only
        //GenObj(ObjForm.circle, dowalls:false,doceil:true,dofloor:false,dbOutline:false);
        //GenObj(ObjForm.circle,onesided:false);
        GenBld(ObjForm.cross,48,12,"dr");
    }


    void GenBld(ObjForm objform,float height,int levels,string clr)
    {
        GenOutline(objform);
        bpg.GenBld(this.gameObject, "bld00", height, levels, clr, alf: 0.5f);
    }

    void GenOutline(ObjForm objform)
    {
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
                    bpg.GenCrossOutline(Vector3.zero, 2f);
                    break;
                }
            case ObjForm.circle:
                {
                    bpg.GenCylinderOutline(Vector3.zero, 20, 1f);
                    break;
                }
        }
    }

    enum ObjForm { star, cross, circle }
    void GenObj(ObjForm objform, bool dowalls = true, bool doroof = true, bool dofloor = true, bool dbOutline = false, bool onesided=false)
    {
        var alf = 0.5f;
        //alf = 1;
        GenOutline(objform);
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
