using Aiskwk.Dataframe;
using Aiskwk.Map;
// using Boo.Lang;
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
        //TestMsft();
        //TestMtten();
        TestSeattle();
        //TestFrisco();
        //Test4();
    }
    void TestMsft()
    {
        var latlngmap = new Aiskwk.Map.LatLongMap("Testmsft");
        latlngmap.InitMapFromSceneSelString("MsftRedwest");
        var hmo = new heightMocker(33);
        var pgvd = new PolyGenVekMapDel(hmo.ChangeHeight);
        bpg.LoadRegionOldForTesting(this.gameObject, "msftcampcore", 1f, pgvd: pgvd, llm: latlngmap);

    }

    void TestSeattle()
    {
        var latlngmap = new Aiskwk.Map.LatLongMap("Testmsft");
        latlngmap.InitMapFromSceneSelString("MsftRedwest");
        var hmo = new heightMocker(33);
        var pgvd = new PolyGenVekMapDel(hmo.ChangeHeight);
        bpg.LoadRegionOldForTesting(this.gameObject, "seattle", 1f, pgvd: pgvd, llm: latlngmap);

    }


    void TestMtten()
    {
        var latlngmap = new Aiskwk.Map.LatLongMap("Testmsft");
        latlngmap.InitMapFromSceneSelString("MsftRedwest");
        var hmo = new heightMocker(33);
        var pgvd = new PolyGenVekMapDel(hmo.ChangeHeight);
        //bpg.LoadRegionOld(this.gameObject, "tenmtn", 1f, pgvd: pgvd, llm: latlngmap);
        //bpg.LoadRegionOld(this.gameObject, "tenmtn", 1f, pgvd: pgvd, llm: latlngmap,buildingFilter:"house85",plotTessalation:true);
        bpg.LoadRegionOldForTesting(this.gameObject, "tenmtn", 1f, pgvd: pgvd, llm: latlngmap, buildingFilter: "house148", plotTessalation: true);
    }
    void TestFrisco()
    {
        var latlngmap = new Aiskwk.Map.LatLongMap("TestFrisco");
        var llb = new LatLngBox(new LatLng(37.774900, -122.419400), 2, 2);
        latlngmap.InitMapFromSceneSelString("", llb);
        var hmo = new heightMocker(33);
        var pgvd = new PolyGenVekMapDel(hmo.ChangeHeight);
        //bpg.LoadRegionOld(this.gameObject, "sanfrancisco", 1f, pgvd: pgvd, llm: latlngmap);
        bpg.LoadRegionOldForTesting(this.gameObject, "sanfrancisco", 1f, pgvd: pgvd, llm: latlngmap,buildingFilter:"yes304",plotTessalation:true);
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
        bpg.LoadRegionOldForTesting(this.gameObject, "eb12small", 1);
    }


}
