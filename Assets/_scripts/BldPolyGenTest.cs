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
        GenStar(dowalls:false,doceil:true,dofloor:false,dbOutline:true);
    }

    void GenCylinder()
    {
        var alf = 0.5f;
        alf = 1;

        bpg = new BldPolyGen();
        bpg.GenCylinderOutline(Vector3.zero, 20, 1f);
        bpg.SetGenForm(BldPolyGenForm.wallsmesh);
        var walgo = bpg.GenMesh("walls",2, clr: "red", alf:alf);
        walgo.transform.parent = this.transform;
        bpg.SetGenForm(BldPolyGenForm.tesselate);
        var ceigo = bpg.GenMesh("ceiling", 2, clr: "blue", alf:alf);
        ceigo.transform.parent = this.transform;
        bpg.SetGenForm(BldPolyGenForm.tesselate);
        var fl1go = bpg.GenMesh("floor1", 1, clr: "green", alf:alf);
        fl1go.transform.parent = this.transform;
    }

    void GenStar(bool dowalls=true,bool doceil=true,bool dofloor=true,bool dbOutline=false)
    {
        var alf = 0.5f;
        //alf = 1;

        bpg = new BldPolyGen();
        bpg.GenStarOutline(Vector3.zero, 8, 0.5f,3f);
        if (dowalls)
        {
            bpg.SetGenForm(BldPolyGenForm.wallsmesh);
            var walgo = bpg.GenMesh("walls", 2, clr: "blue", alf: alf,dbout:dbOutline);
            walgo.transform.parent = this.transform;
        }
        if (doceil)
        {
            bpg.SetGenForm(BldPolyGenForm.tesselate);
            var ceigo = bpg.GenMesh("ceiling", 2, clr: "blue", alf: alf, dbout: dbOutline);
            ceigo.transform.parent = this.transform;
        }
        if (dofloor)
        {
            bpg.SetGenForm(BldPolyGenForm.tesselate);
            var fl1go = bpg.GenMesh("floor1", 1, clr: "blue", alf: alf, dbout: dbOutline);
            fl1go.transform.parent = this.transform;
        }
    }


    void GenCross()
    {
        var alf = 0.5f;
        alf = 1;

        bpg = new BldPolyGen();
        bpg.GenCrossOutline(Vector3.zero, 2);
        bpg.SetGenForm(BldPolyGenForm.walls);
        var walgo = bpg.GenMesh("walls", 2, clr: "red", alf:alf);
        walgo.transform.parent = this.transform;
        bpg.SetGenForm(BldPolyGenForm.tesselate);
        //var ceigo = bpg.GenMesh("ceiling", 2, clr: "blue", alf:alf);
        //ceigo.transform.parent = this.transform;
        var fl1go = bpg.GenMesh("floor1", 1, clr: "green", alf:alf);
        fl1go.transform.parent = this.transform;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
