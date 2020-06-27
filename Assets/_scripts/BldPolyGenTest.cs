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
        //GenObj(ObjForm.circle, dowalls:false,doceil:true,dofloor:false,dbOutline:false);
        //GenObj(ObjForm.circle,onesided:false);
        var v = 4;
        var l1 = new Vector3(v, 0, v);
        GenBld(ObjForm.cross,"b11",l1,48,12,"dr");
        var l2 = new Vector3(-v, 0, v);
        GenBld(ObjForm.star, "b01", l2, 48, 12, "dg");
        var l3 = new Vector3(v, 0, -v);
        GenBld(ObjForm.circle, "b10", l3, 48, 12, "db");
        var l4 = new Vector3(-v, 0, -v);
        GenBld(ObjForm.cross, "b00", l4, 48, 12, "dy");
    }


    void GenBld(ObjForm objform,string bldname,Vector3 loc,float height,int levels,string clr)
    {
        bpg = new BldPolyGen();
        GenOutline(objform,loc);
        bpg.GenBld(this.gameObject, bldname, height, levels, clr, alf: 0.5f);
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
