using Aiskwk.Map;
using System.Collections.Generic;
using UnityEngine;
using UxUtils;

public class B19Willow : MonoBehaviour
{
    public enum B19_MaterialMode {  raw, materialed, glass, glasswalls };

    public UxSetting<bool> loadmodel = new UxSetting<bool>("B19_WillowModel", true);
    public UxSetting<bool> level01 = new UxSetting<bool>("B19_level01", true);
    public UxSetting<bool> level02 = new UxSetting<bool>("B19_level02", true);
    public UxSetting<bool> level03 = new UxSetting<bool>("B19_level03", true);
    public UxSetting<bool> hvac = new UxSetting<bool>("B19_hvac", true);
    public UxSetting<bool> floors = new UxSetting<bool>("B19_floors", true);
    public UxSetting<bool> doors = new UxSetting<bool>("B19_doors", true);
    public UxSetting<bool> osmbld = new UxSetting<bool>("B19_osmbld", false);
    public UxSetting<bool> wilbld = new UxSetting<bool>("B19_wilbld", false);
    public UxSetting<bool> glasswalls = new UxSetting<bool>("B19_glasswalls", false);

    public CampusSimulator.SceneMan sman=null;
    public CampusSimulator.Building bld = null;

    public UxEnumSetting<B19_MaterialMode> b19_materialMode = new UxEnumSetting<B19_MaterialMode>("B19_MaterialMode", B19_MaterialMode.glass);
    //   public UxSetting<bool> visibilityTiedToDetectability = new UxSetting<bool>("FrameVisibilityTiedToDetectability", true);
    // public B19_MaterialMode materialMode = B19_MaterialMode.materialed;

    public OsmBldSpec bspec;

    public void InitializeValues(CampusSimulator.SceneMan sman,CampusSimulator.Building bld)
    {
        this.sman = sman;
        this.bld = bld;
        b19_materialMode.GetInitial(B19_MaterialMode.glasswalls);
        loadmodel.GetInitial(true);
        _b19_level01 = level01.GetInitial(true);
        _b19_level02 = level02.GetInitial(false);
        _b19_level03 = level03.GetInitial(false);
        _b19_hvac = hvac.GetInitial(false);
        _b19_floors = floors.GetInitial(false);
        _b19_doors = doors.GetInitial(false);
        _b19_osmbld = osmbld.GetInitial(false);
        _b19_wilbld = wilbld.GetInitial(false);
        _b19_glasswalls = glasswalls.GetInitial(false);
        lastMaterialMode = b19_materialMode.Get();
        bspec = sman.bdman.FindBldSpecByNameStart(bld.osmnamestart);
    }



    bool _b19_WillowModelLoaded = false;
    bool _b19_level01 = false;
    bool _b19_level02 = false;
    bool _b19_level03 = false;
    bool _b19_hvac = false;
    bool _b19_floors = false;
    bool _b19_doors = false;
    bool _b19_osmbld = false;
    bool _b19_wilbld = false;
    bool _b19_glasswalls = false;
    B19_MaterialMode lastMaterialMode;

    GameObject b19go = null;



    bool ChangeHappened()
    {
        var chg = false;
        if (loadmodel.Get() != _b19_WillowModelLoaded) chg = true;
        if (level01.Get() != _b19_level01)
        {
            chg = true;
            //Debug.Log("1");
        }
        if (level02.Get() != _b19_level02)
        {
            chg = true;
            //Debug.Log("2");
        }
        if (level03.Get() != _b19_level03)
        {
            chg = true;
            //Debug.Log("3");
        }
        if (floors.Get() != _b19_floors)
        {
            chg = true;
            //Debug.Log("floors");
        }
        if (doors.Get() != _b19_doors)
        {
            chg = true;
            //Debug.Log("floors");
        }
        if (hvac.Get() != _b19_hvac)
        {
            chg = true;
            //Debug.Log("floors");
        }
        if (osmbld.Get() != _b19_osmbld)
        {
            chg = true;
            //Debug.Log("floors");
        }
        if (wilbld.Get() != _b19_wilbld)
        {
            chg = true;
            //Debug.Log("floors");
        }
        if (b19_materialMode.Get()!= lastMaterialMode)
        {
            chg = true;
        }
        return chg;
    }


    void SetChildVis2(string childname, string grandchildname, bool active)
    {
        var legot = b19go.transform.Find(childname);
        if (legot != null)
        {
            var legot2 = legot.transform.Find(grandchildname);
            if (legot2 != null)
            {
                legot2.gameObject.SetActive(active);
            }
        }
    }

    void SetChildVis(string childname,bool active)
    {
        var legot = b19go.transform.Find(childname);
        if (legot!=null)
        {
            legot.gameObject.SetActive(active);
        }
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
        DestroyOneGo(ref b19go);
    }
    float ymapheight = 0.01f;
    public void MakeItSo()
    {
        bool loadedThisTime  = false;
        //Debug.Log($"MakeItSo loadModel:{loadmodel.Get()} _b19WillowModel:{_b19_WillowModelLoaded}");
        if (loadmodel.Get() && !_b19_WillowModelLoaded)
        {
            var xoff = -3;
            var zoff = -3;
            //var defpos = new Vector3(-474.3f+xoff, 4.72f, 87.6f+zoff);
            var defpos = new Vector3(-474.3f+xoff, 5.22f, 87.6f+zoff);
            ymapheight = sman.mpman.GetHeight(defpos.x, defpos.z);
            sman.Lgg($"B19 ymapheight:{ymapheight:f3}","orange");
            defpos = new Vector3(defpos.x, ymapheight+defpos.y, defpos.z);
            var obprefab = Resources.Load<GameObject>("Willow/B19/B19-Willow");
            if (obprefab != null)
            {
                b19go = Instantiate<GameObject>(obprefab);
                var ftm = 0.3048f;
                b19go.transform.localScale = new Vector3(ftm, ftm, ftm);
                b19go.transform.position = defpos;
                b19go.transform.Rotate(new Vector3(-90, 26, 0));
                b19go.transform.parent = this.transform;
                _b19_WillowModelLoaded = true;
                _b19_level01 = true;
                _b19_level02 = true;
                _b19_level03 = true;
                _b19_floors = true;
                _b19_doors = true;
                _b19_hvac = true;
                _b19_osmbld = sman.bdman.osmblds.Get();
                loadedThisTime = true;
            }
        }
        else if(!loadmodel.Get() && _b19_WillowModelLoaded)
        {
            DestroyGos();
            loadmodel.SetAndSave( false );
            _b19_WillowModelLoaded = false;
            level01.SetAndSave( false );
            _b19_level01 = false;
            level02.SetAndSave( false );
            _b19_level02 = false;
            level03.SetAndSave( false );
            _b19_level03 = false;
            hvac.SetAndSave( false );
            _b19_hvac = false;
            _b19_osmbld = sman.bdman.osmblds.Get(); 
        }
        if (b19go)
        {
            if (wilbld.Get() != _b19_wilbld)
            {
                var stat = wilbld.Get();
                ActuateWilStatus(stat);
                _b19_wilbld = stat;
            }
            if (osmbld.Get() != _b19_osmbld)
            {
                var stat = osmbld.Get();
                ActuateOsmStatus(stat);
                _b19_osmbld = stat;
            }
            if (level01.Get() != _b19_level01)
            {
                //Debug.Log("Fixing 1");
                var stat = level01.Get();
                SetChildVis("L01-AR", stat);
                //SetChildVis("L01-ME", stat);
                _b19_level01 = stat;
            }
            if (level02.Get() != _b19_level02)
            {
                //Debug.Log("Fixing 2");
                var stat = level02.Get();
                SetChildVis("L02-AR", stat);
                //SetChildVis("L02-ME", stat);
                _b19_level02 = stat;
            }
            if (level03.Get() != _b19_level03)
            {
                //Debug.Log("Fixing 3");
                var stat = level03.Get();
                SetChildVis("L03-AR", stat);
                //SetChildVis("L03-ME", stat);
                _b19_level03 = stat;
            }
            if (floors.Get() != _b19_floors)
            {
                //Debug.Log("Fixing floors");
                var stat = floors.Get();
                SetChildVis2("L01-AR", "Solid", stat);
                SetChildVis2("L02-AR", "Solid", stat);
                SetChildVis2("L03-AR", "Solid", stat);
                _b19_floors = stat;
            }
            if (doors.Get() != _b19_doors)
            {
                //Debug.Log("Fixing doors");
                var stat = doors.Get();
                SetChildVis2("L01-AR", "Composite_Part", stat);
                SetChildVis2("L02-AR", "Composite_Part", stat);
                SetChildVis2("L03-AR", "Composite_Part", stat);
                _b19_doors = stat;
            }
            if (hvac.Get() != _b19_hvac)
            {
                //Debug.Log("Fixing hvac");
                var stat = hvac.Get();
                SetChildVis("L01-ME", stat);
                SetChildVis("L02-ME", stat);
                SetChildVis("L03-ME", stat);
                _b19_hvac = stat;
            }
            if (loadedThisTime || lastMaterialMode != b19_materialMode.Get())
            {
                ActuateMaterialMode();
                lastMaterialMode = b19_materialMode.Get();
            }
        }
    }

    public void ActuateOsmStatus(bool stat)
    {
        if (bspec == null)
        {
            bspec = sman.bdman.FindBldSpecByNameStart(bld.osmnamestart);
        }
        if (bspec != null)
        {
            bspec.isVisible = stat;
            if (bspec.bgo != null)
            {
                bspec.bgo.SetActive(stat);
            }
        }
    }

    public void ActuateWilStatus(bool stat)
    {
        if (b19go != null)
        {
            b19go.SetActive(stat);
        }
    }

    public Vector3 GetCenterPoint(bool includeAltitude = true)
    {
        var ll = GetCenterLatLng();
        var (x, z) = sman.coman.lltoxz(ll.lat, ll.lng);
        var y = 0f;
        if (includeAltitude)
        {
            y += ymapheight;
        }
        var rv = new Vector3(x, y, z);

        return rv;
    }
    public LatLng GetCenterLatLng()
    {
        var rv = new LatLng(47.643010, -122.131305);// took it off the map
        return rv;
    }
    public (int, float) GetFloorsAndHeight()
    {
        return (2, 5f);
    }
    public float GetFloorHeight(int floor, bool includeAltitude = true)
    {
        var rv = bspec.GetFloorHeight(floor, includeAltitude: includeAltitude);
        return rv;
    }

    public float GetFloorHeightOld(int floor, bool includeAltitude = true)
    {
        var rv = 0.01f;
        if (floor < 0) floor = 0;
        if (floor > 2) floor = 2;
        switch (floor)
        {
            case 0:
            case 1:
                rv = 0.01f;
                break;
            case 2:
                rv = 2.11f;
                break;
        }
        if (includeAltitude)
        {
            //rv += ymapheight;
            if (bspec == null)
            {
                sman.LggError("B19Willow.GetFloorHeight - bspec null with includeAltitude=true");
            }
            else
            {
                rv += bspec.GetGround();
            }
        }
        return rv;
    }


    List<string> B19_parts = new List<string>
    {
        "B19-Willow/L03-ME/Exhaust_Air_Duct,Exhaust_Air_DuctMat",
        "B19-Willow/L03-ME/Solid,SolidMat",
        "B19-Willow/L03-ME/Supply_Air_Duct,Supply_Air_DuctMat",
        "B19-Willow/L01-AR/*Door_Frame,_Door_FrameMat",
        "B19-Willow/L01-AR/*Finish_Facade_Feature_Wall,_Finish_Facade_Feature_WallMat",
        "B19-Willow/L01-AR/*Glazing_Glass_-_Clear,_Glazing_Glass_-_ClearMat",
        "B19-Willow/L01-AR/*Metal_Aluminum,_Metal_AluminumMat",
        "B19-Willow/L01-AR/*Metal_Powdercoated_White,_Metal_Powdercoated_WhiteMat",
        "B19-Willow/L01-AR/*Metal_Stainless_Steel_-_Polished,_Metal_Stainless_Steel_-_PolishedMat",
        "B19-Willow/L01-AR/*Wall_Generic,_Wall_GenericMat",
        "B19-Willow/L01-AR/.Wall_Default,",
        "B19-Willow/L01-AR/_Aluminium,_AluminiumMat",
        "B19-Willow/L01-AR/Composite_Part,Composite_PartMat",
        "B19-Willow/L01-AR/Computer_Basic,Computer_BasicMat",
        "B19-Willow/L01-AR/Computer_Basic_2,Computer_Basic_2Mat",
        "B19-Willow/L01-AR/Computer_Basic_3,Computer_Basic_3Mat",
        "B19-Willow/L01-AR/Computer_Glass,Computer_GlassMat",
        "B19-Willow/L01-AR/Computer_Light_(ON),Computer_Light_(ON)Mat",
        "B19-Willow/L01-AR/Computer_Metal,Computer_MetalMat",
        "B19-Willow/L01-AR/Computer_Metal_2,Computer_Metal_2Mat",
        "B19-Willow/L01-AR/Generic_-_Plastic_-_Black,Generic_-_Plastic_-_BlackMat",
        "B19-Willow/L01-AR/Generic_-_Plastic_-_Grey,Generic_-_Plastic_-_GreyMat",
        "B19-Willow/L01-AR/IKE080018_2,IKE080018_2Mat",
        "B19-Willow/L01-AR/IKE080018_3,IKE080018_3Mat",
        "B19-Willow/L01-AR/IKE160124_1,IKE160124_1Mat",
        "B19-Willow/L01-AR/IKE160124_2,IKE160124_2Mat",
        "B19-Willow/L01-AR/IKE160124_3,IKE160124_3Mat",
        "B19-Willow/L01-AR/IKE160124_4,IKE160124_4Mat",
        "B19-Willow/L01-AR/IKE160130_1,IKE160130_1Mat",
        "B19-Willow/L01-AR/IKE160130_2,IKE160130_2Mat",
        "B19-Willow/L01-AR/IKE160130_3,IKE160130_3Mat",
        "B19-Willow/L01-AR/IKE160130_4,IKE160130_4Mat",
        "B19-Willow/L01-AR/Metal-Chrome-Caroma,Metal-Chrome-CaromaMat",
        "B19-Willow/L01-AR/PC_Monitor_Color,PC_Monitor_ColorMat",
        "B19-Willow/L01-AR/PC_Monitor_Glass,PC_Monitor_GlassMat",
        "B19-Willow/L01-AR/Porcelain-White-Caroma,Porcelain-White-CaromaMat",
        "B19-Willow/L01-AR/Solid,SolidMat",
        "B19-Willow/L01-ME/Copper,CopperMat",
        "B19-Willow/L01-ME/Gas_Pipe,Gas_PipeMat",
        "B19-Willow/L01-ME/Line,LineMat",
        "B19-Willow/L01-ME/Return_Air_Duct,Return_Air_DuctMat",
        "B19-Willow/L01-ME/Solid,SolidMat",
        "B19-Willow/L01-ME/Supply_Air_Duct,Supply_Air_DuctMat",
        "B19-Willow/L02-AR/*Door_Frame,_Door_FrameMat",
        "B19-Willow/L02-AR/*Fabric_Linen_Porcelain,_Fabric_Linen_PorcelainMat",
        "B19-Willow/L02-AR/*Finish_Facade_Feature_Wall,_Finish_Facade_Feature_WallMat",
        "B19-Willow/L02-AR/*Glazing_Glass_-_Clear,_Glazing_Glass_-_ClearMat",
        "B19-Willow/L02-AR/*Metal_Aluminum,_Metal_AluminumMat",
        "B19-Willow/L02-AR/*Wall_Generic,_Wall_GenericMat",
        "B19-Willow/L02-AR/.Wall_Default,",
        "B19-Willow/L02-AR/_Aluminium,_AluminiumMat",
        "B19-Willow/L02-AR/Composite_Part,Composite_PartMat",
        "B19-Willow/L02-AR/Metal-Chrome-Caroma,Metal-Chrome-CaromaMat",
        "B19-Willow/L02-AR/Porcelain-White-Caroma,Porcelain-White-CaromaMat",
        "B19-Willow/L02-AR/Solid,SolidMat",
        "B19-Willow/L02-ME/Exhaust_Air_Duct,Exhaust_Air_DuctMat",
        "B19-Willow/L02-ME/Return_Air_Duct,Return_Air_DuctMat",
        "B19-Willow/L02-ME/Solid,SolidMat",
        "B19-Willow/L02-ME/Supply_Air_Duct,Supply_Air_DuctMat",
        "B19-Willow/L03-AR/*Finish_Facade_Feature_Wall,_Finish_Facade_Feature_WallMat",
        "B19-Willow/L03-AR/*Wall_Generic,_Wall_GenericMat"
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
        if (this.b19go == null)
        {
            this.b19go = GameObject.Find("B19-Willow");
        }
        if (this.b19go == null)
        {
            Debug.Log("Cound not find B19-Willow");
            return;
        }
        var lst = GraphAlgos.GraphUtil.HierarchyDescToText(this.b19go, "");
        var fname = "B19materials.txt";
        GraphAlgos.GraphUtil.writeListToFile(lst, fname);
        Debug.Log("Wrote " + lst.Count + " lines to " + fname);
    }

    public GameObject GetPart(GameObject root,string partname)
    {
        var parslh = partname.Split('/');
        var curgo = root;
        for(var i=0; i<parslh.Length; i++)
        {
            var part = parslh[i];
            if (i == 0) continue;
            var tform = curgo.transform.Find(part);
            if (tform == null)
            {
                Debug.Log("GetPart failed to find " + partname + "-  failed name part" + part);
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
        var pogo = GetPart(rootgo, partname);
        if (pogo!=null)
        {
            var renderer = pogo.GetComponent<Renderer>();
            if (!renderer)
            {
                Debug.Log("No renderer found for " + partname+" pogo.name:"+pogo.name);
                return;
            }
            var fullmatname = "Materials/" + matname;
            var mat = Resources.Load<Material>(fullmatname);
            if (!mat)
            {
                Debug.Log("Material "+fullmatname+" not found in Resources");
                return;
            }
            renderer.material = mat;
        }
    }

    public void ActuateMaterialMode(bool writepartlisttofile=false)
    {
        if (this.b19go == null)
        {
            this.b19go = GameObject.Find("B19-Willow");
        }
        if (this.b19go == null)
        {
            Debug.Log("Cound not find B19-Willow");
            return;
        }
        foreach( var pname in B19_parts)
        {
            var parcom = pname.Split(',');
            var partname = parcom[0];
            var partmat = parcom[1];
            var defmatname = "ComputerGlass";
            var matname = defmatname;
            switch (b19_materialMode.Get())
            {
                case B19_MaterialMode.glass:
                    matname = "ComputerGlass";
                    break;
                case B19_MaterialMode.materialed:
                    matname = bldmatmap[parcom[1]];
                    break;
                case B19_MaterialMode.glasswalls:
                    var pnl = partname.ToLower();
                    if (pnl.Contains("solid") || pnl.Contains("wall") || pnl.Contains("door") || pnl.Contains("composite_part"))
                    {
                        matname = "ComputerGlass";
                    }
                    else
                    {
                        matname = bldmatmap[partmat];
                    }
                    break;
                case B19_MaterialMode.raw:
                    //matname = parcom[1];
                    matname = "";
                    break;
            }
            AssignPartMat(this.b19go,partname, matname);
        }
        if (writepartlisttofile)
        {
            var lst = GraphAlgos.GraphUtil.HierarchyDescToText(this.b19go, "");
            var fname = "B19materials.txt";
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
                Debug.Log($"ChangeHappened to B19 upd:{updcount}");
                MakeItSo();
            }
        }
        updcount++;
    }
}
