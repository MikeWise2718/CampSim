using Aiskwk.Dataframe;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.UI;

public class BldPolyGenTest : MonoBehaviour
{
    BldPolyGen bpg;
    // Start is called before the first frame update
    void Start()
    {
        bpg = new BldPolyGen();
        TestMsft();
    }
    void TestMsft()
    {
        bpg.LoadRegion(this.gameObject, "msftb19area,msftcommons,msftredwest");
        //bpg.LoadRegion(this.gameObject, "eb12");
        //bpg.LoadRegion(this.gameObject, "eb12small");
        //bpg.LoadRegion(this.gameObject, "SanFrancisco", ptscale: 1000);
        //bpg.LoadRegionOneBld(this.gameObject, "SanFrancisco","w256586268",ptscale:1000);
        //bpg.LoadRegionOneBld(this.gameObject, "eb12small","w203793425");
    }

    float lastDumpTime;
    private void Update()
    {
        //if (Time.time-lastDumpTime>2)
        //{
        //    var pct = 100*GrafPolyGen.reverses*1f / GrafPolyGen.reverseOpps;
        //    Debug.Log($"ReverseOpps:{GrafPolyGen.reverseOpps} Reverses:{GrafPolyGen.reverses} pct:{pct:f1}");
        //    lastDumpTime = Time.time;
        //}

    }

}
