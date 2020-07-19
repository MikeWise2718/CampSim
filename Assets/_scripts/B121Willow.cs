using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UxUtils;

public class B121Willow : MonoBehaviour
{
    public enum b121_MaterialMode {  raw, materialed, glass, glasswalls };

    public UxSetting<bool> loadmodel = new UxSetting<bool>("B121_WillowModel", true);
    public UxSetting<bool> shell = new UxSetting<bool>("B121_shell", true);
    public UxSetting<bool> interiorwalls = new UxSetting<bool>("B121_interiorwalls", true);
    public UxSetting<bool> hvac = new UxSetting<bool>("B121_hvac", true);
    public UxSetting<bool> lighting = new UxSetting<bool>("B121_lights", true);
    public UxSetting<bool> plumbing = new UxSetting<bool>("B121_plumbing", true);
    public UxSetting<bool> osmbld = new UxSetting<bool>("B121_osmbld", true);

    public CampusSimulator.SceneMan sman=null;

    public UxEnumSetting<b121_MaterialMode> b121_materialMode = new UxEnumSetting<b121_MaterialMode>("B121_MaterialMode", b121_MaterialMode.glass);
    //   public UxSetting<bool> visibilityTiedToDetectability = new UxSetting<bool>("FrameVisibilityTiedToDetectability", true);
    // public B19_MaterialMode materialMode = B19_MaterialMode.materialed;





    bool _b121_WillowModelLoaded = false;
    bool _b121_shell = false;
    bool _b121_interiorwalls = false;
    bool _b121_hvac = false;
    bool _b121_lighting = false;
    bool _b121_plumbing = false;
    bool _b121_osmbld = false;
    b121_MaterialMode lastMaterialMode;

    GameObject b121go = null;
    GameObject b121sgo = null;
    GameObject b121igo = null;
    GameObject b121hgo = null;
    GameObject b121lgo = null;
    GameObject b121pgo = null;

    public void InitializeValues(CampusSimulator.SceneMan sman)
    {
        Debug.Log("InitializeValues");
        this.sman = sman;
        b121_materialMode.GetInitial(b121_MaterialMode.glasswalls);
        loadmodel.GetInitial(true);
        _b121_shell = shell.GetInitial(true);
        _b121_interiorwalls = interiorwalls.GetInitial(true);
        _b121_hvac = hvac.GetInitial(false);
        _b121_lighting = lighting.GetInitial(false);
        _b121_plumbing = plumbing.GetInitial(false);
        _b121_osmbld = osmbld.GetInitial(false);
        lastMaterialMode = b121_materialMode.Get();
        Debug.Log($"b121.loadmodel:{loadmodel.Get()}");
        Debug.Log($"b121.shell:{shell.Get()}");
        Debug.Log($"b121.interior:{interiorwalls.Get()}");
        Debug.Log($"b121.hvac:{hvac.Get()}");
        Debug.Log($"b121.lighting:{lighting.Get()}");
        Debug.Log($"b121.plumbing:{plumbing.Get()}");
        Debug.Log($"b121.osmbld:{osmbld.Get()}");
        Debug.Log($"b121.materialmode:{b121_materialMode.Get()}");
    }



    bool ChangeHappened()
    {
        var chg = false;
        if (loadmodel.Get() != _b121_WillowModelLoaded) chg = true;
        if (shell.Get() != _b121_shell)
        {
            Debug.Log($"b121 shell changed to {shell.Get()}");
            chg = true;
        }
        if (interiorwalls.Get() != _b121_interiorwalls)
        {
            Debug.Log($"b121 interior changed to {interiorwalls.Get()}");
            chg = true;
        }
        if (hvac.Get() != _b121_hvac)
        {
            Debug.Log($"b121 hvac changed to {hvac.Get()}");
            chg = true;
        }
        if (lighting.Get() != _b121_lighting)
        {
            Debug.Log($"b121 lighting changed to {lighting.Get()}");
            chg = true;
        }
        if (plumbing.Get() != _b121_plumbing)
        {
            Debug.Log($"b121 plumbing changed to {plumbing.Get()}");
            chg = true;
        }
        if (osmbld.Get() != _b121_osmbld)
        {
            Debug.Log($"b121 osmbld changed to {osmbld.Get()}");
            chg = true;
        }
        if (b121_materialMode.Get() != lastMaterialMode)
        {
            Debug.Log($"b121 material changed to {b121_materialMode.Get()}");
            chg = true;
        }
        return chg;
    }




    public GameObject LoadObject(GameObject parent,string resourcename,string objname,float ska=1,float xrot=0)
    {
        var obprefab = Resources.Load<GameObject>(resourcename);
        var objgo = Instantiate<GameObject>(obprefab);
        var ftm = ska;
        objgo.name = objname;
        objgo.transform.localScale = new Vector3(ftm, ftm, ftm);
        objgo.transform.position = Vector3.zero;
        objgo.transform.Rotate(new Vector3(xrot, 0, 0));
        objgo.transform.SetParent(parent.transform,worldPositionStays:false);
        return objgo;
    }

    public void DestroyOneGo(ref GameObject bgo)
    {
        if (bgo != null)
        {
            Destroy(bgo);
            bgo = null;
        }
    }

    public void DestroyGos()
    {
        DestroyOneGo(ref b121sgo);
        DestroyOneGo(ref b121igo);
        DestroyOneGo(ref b121hgo);
        DestroyOneGo(ref b121lgo);
        DestroyOneGo(ref b121pgo);
        DestroyOneGo(ref b121go);
    }
    public void MakeItSo()
    {
        bool loadedThisTime = false;
        //Debug.Log($"MakeItSo loadModel:{loadmodel.Get()} _b19WillowModel:{_b19_WillowModelLoaded}");
        if (loadmodel.Get() && !_b121_WillowModelLoaded)
        {
            b121go = new GameObject("B121-Willow");
            var xoff = 0;
            var zoff = 0;
            Vector3 defpos = new Vector3(-789 + xoff, 0f, -436 + zoff);
            if (sman != null)
            {
                var yoff = sman.mpman.GetHeight(defpos.x, defpos.z);
                //Debug.Log($"B19 yoff:{yoff}");
                defpos = new Vector3(defpos.x, yoff + defpos.y, defpos.z);
            }
            b121go.transform.Rotate(new Vector3(0, -20.15f, 0));
            b121go.transform.position = defpos;
            b121go.transform.SetParent(this.transform,worldPositionStays:false);

            _b121_shell = false;
            _b121_interiorwalls = false;
            _b121_hvac = false;
            _b121_lighting = false;
            _b121_plumbing = false;
            _b121_osmbld = sman.bdman.osmblds.Get();
            _b121_WillowModelLoaded = true;
            loadedThisTime = true;
        }
        else if(!loadmodel.Get() && _b121_WillowModelLoaded)
        {
            DestroyGos();

            loadmodel.SetAndSave( false );
            _b121_WillowModelLoaded = false;

            shell.SetAndSave(false);
            _b121_shell = false;

            interiorwalls.SetAndSave( false );
            _b121_interiorwalls = false;

            hvac.SetAndSave( false );
            _b121_hvac = false;

            lighting.SetAndSave(false);
            _b121_lighting = false;

            plumbing.SetAndSave(false);
            _b121_plumbing = false;

        }
        if (b121go)
        {
            if (osmbld.Get() != _b121_osmbld)
            {
                var stat = osmbld.Get();
                var bspec = sman.bdman.FindBldSpecByNameStart("Microsoft Building 121 ");
                if (bspec != null)
                {
                    if (bspec.bgo != null)
                    {
                        bspec.bgo.SetActive(stat);
                    }
                }
                _b121_osmbld = stat;
            }
            if (shell.Get() != _b121_shell)
            {
                var stat = shell.Get();
                //b121sgo.SetActive(stat);
                b121sgo = LoadObject(b121go, "Willow/B121/1716045-BH-AR-BASE_R20","shell",ska: 0.025f);
                _b121_shell = stat;
            }
            if (interiorwalls.Get() != _b121_interiorwalls)
            {
                var stat = interiorwalls.Get();
                b121igo = LoadObject(b121go,"Willow/B121/1716045-BH-AR-INTERIOR_R20","interior", ska: 0.025f);
                _b121_interiorwalls = stat;
            }
            if (hvac.Get() != _b121_hvac)
            {
                var stat = hvac.Get();
                b121hgo = LoadObject(b121go, "Willow/B121/1716045-BH-HVAC-B121_2020","hvac", xrot: -90);
                _b121_hvac = stat;
            }
            if (lighting.Get() != _b121_lighting)
            {
                var stat = lighting.Get();
                b121lgo = LoadObject(b121go, "Willow/B121/1716045-BH-LIGHTING-B121_2020","lighting", xrot: -90);
                _b121_lighting = stat;
            }
            if (plumbing.Get() != _b121_plumbing)
            {
                var stat = plumbing.Get();
                b121pgo = LoadObject(b121go, "Willow/B121/1716045-BH-PLUMBING-B121_2020","plumbing", xrot: -90);
                _b121_plumbing = stat;
            }
            if (loadedThisTime || b121_materialMode.Get() != lastMaterialMode)
            {
                ActuateMaterialMode(b121sgo);
                lastMaterialMode = b121_materialMode.Get();
            }
        }
    }

    List<string> B121_parts = new List<string>
    {
        "b121/shell,_Finish_Facade_Feature_WallMat",
        "b121/interior,_Wall_GenericMat",
        "b121/hvac,_AluminiumMat",
        "b121/lighting,CopperMat",
        "b121/plumbing,_Metal_Stainless_Steel_-_PolishedMat",
    };

    Dictionary<string, string> bldmatmap = new Dictionary<string, string>
    {
        {"SolidMat","WallWhite"},
        {"Exhaust_Air_DuctMat","Aluminium"},
        {"Supply_Air_DuctMat","Aluminium"},
        {"Return_Air_DuctMat","Aluminium"},
        {"_Door_FrameMat","Plywood"},
        {"_Finish_Facade_Feature_WallMat","FacadeWall"},
        {"_Glazing_Glass_-_ClearMat","DustyGlass"},
        {"_Metal_Powdercoated_WhiteMat","Aluminium"},
        {"_Metal_Stainless_Steel_-_PolishedMat","Steel"},
        {"_Wall_GenericMat","WallMat"},
        {"_Fabric_Linen_PorcelainMat","WallMat"},
        {"","WallMat"},
        {"_Metal_AluminumMat","Aluminium"},
        {"_AluminiumMat","Aluminium"},
        {"Composite_PartMat","WallMat"},
        {"Computer_BasicMat","PlasticHololens"},
        {"Computer_Basic_2Mat","PlasticHololens"},
        {"Computer_Basic_3Mat","PlasticHololens"},
        {"Computer_GlassMat","ComputerGlass"},
        {"Computer_Light_(ON)Mat","BlueLight"},
        {"Computer_MetalMat","Aluminium"},
        {"Computer_Metal_2Mat","Aluminium"},
        {"PC_Monitor_ColorMat","ComputerGlass"},
        {"PC_Monitor_GlassMat","ComputerGlass"},
        {"Generic_-_Plastic_-_BlackMat","PlasticHololens"},
        {"Generic_-_Plastic_-_GreyMat","PlasticHololens"},
        {"IKE080018_2Mat","Aluminium"},
        {"IKE080018_3Mat","Aluminium"},
        {"IKE160124_1Mat","Aluminium"},
        {"IKE160124_2Mat","Aluminium"},
        {"IKE160124_3Mat","Aluminium"},
        {"IKE160124_4Mat","Aluminium"},
        {"IKE160130_1Mat","Aluminium"},
        {"IKE160130_2Mat","Aluminium"},
        {"IKE160130_3Mat","Aluminium"},
        {"IKE160130_4Mat","Aluminium"},
        {"Metal-Chrome-CaromaMat","Steel"},
        {"Porcelain-White-CaromaMat","WallMat"},
        {"CopperMat","Copper"},
        {"Gas_PipeMat","Copper"},
        {"LineMat","WallMat"},
    };



    public void WriteOutPartsAndMaterials()
    {
        if (this.b121sgo == null)
        {
            this.b121sgo = GameObject.Find("B19-Willow");
        }
        if (this.b121sgo == null)
        {
            Debug.Log("Cound not find B19-Willow");
            return;
        }
        var lst = GraphAlgos.GraphUtil.HierarchyDescToText(this.b121sgo, "");
        var fname = "B19materials.txt";
        GraphAlgos.GraphUtil.writeListToFile(lst, fname);
        Debug.Log("Wrote " + lst.Count + " lines to " + fname);
    }

    public GameObject GetPart(GameObject root,string partname,bool canfail)
    {
        var parslh = partname.Split('/');
        var curgo = root;
        for(var i=0; i<parslh.Length; i++)
        {
            var part = parslh[i];
            if (i == 0) continue; // skip over root name
            var tform = curgo.transform.Find(part);
            if (tform == null)
            {
                if (!canfail)
                {
                    Debug.LogWarning("GetPart failed to find " + partname + "-  failed name part:" + part);
                }
                return null;
            }
            curgo = tform.gameObject;
        }
        return curgo;
    }
    public void AssignPartMat(GameObject rootgo,string partname,string matname)
    {
        if (matname=="")
        {
            return; // do nothing - raw mode
        }
        Debug.Log($"AssignPartMat rootgo:{rootgo.name} partname:{partname} matname:{matname}");
        var pogo = GetPart(rootgo, partname,canfail:true);
        if (pogo!=null)
        {
            var fullmatname = "Materials/" + matname;
            var mat = Resources.Load<Material>(fullmatname);
            if (!mat)
            {
                Debug.Log("Material "+fullmatname+" not found in Resources");
                return;
            }
            //renderer.material = mat;
            ChangeMaterial(pogo, mat);
        }
    }
    void ChangeMaterial(GameObject pogo,Material newMat)
    {
        var children = pogo.GetComponentsInChildren<Renderer>();
        Debug.Log($"Changing {pogo.name} children({children.Length}) to material:{newMat.name}");
        foreach (var rend in children)
        {
            var mats = new Material[rend.materials.Length];
            for (var j = 0; j < rend.materials.Length; j++)
            {
                mats[j] = newMat;
            }
            rend.materials = mats;
        }
    }

    public void ActuateMaterialMode(GameObject go,bool writepartlisttofile=false)
    {
        var doit = true;
        if (doit)
        {
            foreach (var pname in B121_parts)
            {
                var parcom = pname.Split(',');
                var partname = parcom[0];
                var partmat = parcom[1];
                var defmatname = "ComputerGlass";
                var matname = defmatname;
                switch (b121_materialMode.Get())
                {
                    case b121_MaterialMode.glass:
                        matname = "ComputerGlass";
                        break;
                    case b121_MaterialMode.materialed:
                        matname = bldmatmap[parcom[1]];
                        break;
                    case b121_MaterialMode.glasswalls:
                        var pnl = partname.ToLower();
                        //if (pnl.Contains("solid") || pnl.Contains("wall") || pnl.Contains("door") || pnl.Contains("composite_part"))
                        if (pnl.Contains("shell") || pnl.Contains("interior"))
                        {
                            matname = "ComputerGlass";
                        }
                        else
                        {
                            matname = bldmatmap[partmat];
                        }
                        break;
                    case b121_MaterialMode.raw:
                        //matname = parcom[1];
                        matname = "";
                        break;
                }
                AssignPartMat(this.b121go, partname, matname);
            }
        }

        if (writepartlisttofile)
        {
            var lst = GraphAlgos.GraphUtil.HierarchyDescToText(this.b121go, "");
            var fname = "B121materials.txt";
            GraphAlgos.GraphUtil.writeListToFile(lst, fname);
            Debug.Log($"Wrote {lst.Count} lines to {fname}");
        }
    }


    public bool ActuateChange()
    {
        var rv = ChangeHappened();
        if (rv)
        {
            MakeItSo();
        }
        return rv;
    }

    int updcount = 0;

    float timeinterval = 1e6f;
    float lasttimecheck = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lasttimecheck > timeinterval)
        {
            if (ChangeHappened())
            {
                Debug.Log($"ChangeHappened to B121 upd:{updcount} time:{Time.time:f2} - making it so");
                MakeItSo();
            }
            else
            {
                Debug.Log($"No Change to B121 upd:{updcount} time:{Time.time:f2}");
            }
            lasttimecheck = Time.time;
        }
        updcount++;
    }
}
