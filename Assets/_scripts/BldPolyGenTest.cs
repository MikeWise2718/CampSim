using Aiskwk.Dataframe;
using Boo.Lang;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.UI;


public class heightMocker
{
    //
    // mocking this:             var y = sman.mpman.GetHeight(x, z);
    //

    float fixedVal = 2;
    public heightMocker(float height)
    {
        fixedVal = height;
    }
    public float GetHeight(float x,float z)
    {
        return fixedVal;
    }
    public Vector3 ChangeHeight(Vector3 ipv)
    {
        var rv = new Vector3(ipv.x, ipv.y+fixedVal, ipv.z);
        return rv;
    }
}


public class BldPolyGenTest : MonoBehaviour
{
    BldPolyGen bpg;
    // Start is called before the first frame update
    void Start()
    {
        bpg = new BldPolyGen();
        //TestEb12();
        TestMsft();
        //Test4();
    }
    void TestMsft()
    {
        var latlngmap = new Aiskwk.Map.LatLongMap("Testmsft");
        latlngmap.InitMapFromSceneSelString("MsftRedwest");
        var hmo = new heightMocker(33);
        var pgvd = new PolyGenVekMapDel(hmo.ChangeHeight);
        //bpg.LoadRegionOld(this.gameObject, "msftb19area,msftcommons,msftredwest", 1f, pgvd: pgvd, llm: latlngmap);
        //bpg.LoadRegionOld(this.gameObject, "msftcampcore", 1f, pgvd: pgvd, llm: latlngmap);
        bpg.LoadRegionOld(this.gameObject, "tenmtn", 1f, pgvd: pgvd, llm: latlngmap,buildingFilter:"house148",plotTessalation:true);
        //bpg.LoadRegion(this.gameObject, "eb12");
        //bpg.LoadRegion(this.gameObject, "eb12small");
        //bpg.LoadRegion(this.gameObject, "SanFrancisco", ptscale: 1000);
        //bpg.LoadRegionOneBld(this.gameObject, "SanFrancisco","w256586268",ptscale:1000);
        //bpg.LoadRegionOneBld(this.gameObject, "eb12small","w203793425");
    }

    void Test4()
    {
        var hmo = new heightMocker(10);
        var pgvd = new PolyGenVekMapDel(hmo.ChangeHeight);
        bpg.Test4(this.gameObject, 1, pgvd: pgvd);
    }

    void TestEb12()
    {
        //bpg.LoadRegion(this.gameObject, "eb12small", 0.5f);
        bpg.LoadRegionOld(this.gameObject, "eb12small", 1);
    }


}
