using Aiskwk.Map;
using System.Collections.Generic;
using UnityEngine;
using UxUtils;

public class StaplesStadium : MonoBehaviour
{
    public enum StapStad_MaterialMode {  raw, materialed, glass, glasswalls };

    public UxSetting<bool> loadmodel = new UxSetting<bool>("StapStad_Model", true);
    public UxSetting<bool> level01 = new UxSetting<bool>("StapStad_level01", true);
    public UxSetting<bool> level02 = new UxSetting<bool>("StapStad_level02", true);
    public UxSetting<bool> level03 = new UxSetting<bool>("StapStad_level03", true);
    public UxSetting<bool> hvac = new UxSetting<bool>("StapStad_hvac", true);
    public UxSetting<bool> floors = new UxSetting<bool>("StapStad_floors", true);
    public UxSetting<bool> doors = new UxSetting<bool>("StapStad_doors", true);
    public UxSetting<bool> osmbld = new UxSetting<bool>("StapStad_osmbld", false);
    public UxSetting<bool> cadbld = new UxSetting<bool>("StapStad_wilbld", false);
    public UxSetting<bool> glasswalls = new UxSetting<bool>("StapStad_glasswalls", false);

    public CampusSimulator.SceneMan sman=null;
    public CampusSimulator.Building bld = null;

    public UxEnumSetting<StapStad_MaterialMode> StapStad_materialMode = new UxEnumSetting<StapStad_MaterialMode>("StapStad_MaterialMode", StapStad_MaterialMode.glass);

    public OsmBldSpec bspec;
    public OsmBldSpec bspecaux;

    public void InitializeValues(CampusSimulator.SceneMan sman,CampusSimulator.Building bld)
    {
        this.sman = sman;
        this.bld = bld;
        StapStad_materialMode.GetInitial(StapStad_MaterialMode.glasswalls);
        loadmodel.GetInitial(true);
        _ss_level01 = level01.GetInitial(true);
        _ss_level02 = level02.GetInitial(false);
        _ss_level03 = level03.GetInitial(false);
        _ss_hvac = hvac.GetInitial(false);
        _ss_floors = floors.GetInitial(false);
        _ss_doors = doors.GetInitial(false);
        _ss_osmbld = osmbld.GetInitial(false);
        _ss_cadbld = cadbld.GetInitial(false);
        _ss_glasswalls = glasswalls.GetInitial(false);
        lastMaterialMode = StapStad_materialMode.Get();
        bspec = sman.bdman.FindBldSpecByNameStart(bld.osmnamestart);
    }



    bool _ss_CadModelLoaded = false;
    bool _ss_level01 = false;
    bool _ss_level02 = false;
    bool _ss_level03 = false;
    bool _ss_hvac = false;
    bool _ss_floors = false;
    bool _ss_doors = false;
    bool _ss_osmbld = false;
    bool _ss_cadbld = false;
    bool _ss_glasswalls = false;
    StapStad_MaterialMode lastMaterialMode;

    GameObject ssgo = null;



    bool ChangeHappened()
    {
        var chg = false;
        if (loadmodel.Get() != _ss_CadModelLoaded) chg = true;
        if (level01.Get() != _ss_level01)
        {
            chg = true;
            //Debug.Log("1");
        }
        if (level02.Get() != _ss_level02)
        {
            chg = true;
            //Debug.Log("2");
        }
        if (level03.Get() != _ss_level03)
        {
            chg = true;
            //Debug.Log("3");
        }
        if (floors.Get() != _ss_floors)
        {
            chg = true;
            //Debug.Log("floors");
        }
        if (doors.Get() != _ss_doors)
        {
            chg = true;
            //Debug.Log("floors");
        }
        if (hvac.Get() != _ss_hvac)
        {
            chg = true;
            //Debug.Log("floors");
        }
        if (osmbld.Get() != _ss_osmbld)
        {
            chg = true;
            //Debug.Log("floors");
        }
        if (cadbld.Get() != _ss_cadbld)
        {
            chg = true;
            //Debug.Log("floors");
        }
        if (StapStad_materialMode.Get()!= lastMaterialMode)
        {
            chg = true;
        }
        return chg;
    }


    void SetChildVis2(string childname, string grandchildname, bool active)
    {
        var legot = ssgo.transform.Find(childname);
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
        var legot = ssgo.transform.Find(childname);
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
        DestroyOneGo(ref ssgo);
    }
    float ymapheight = 0.01f;
    public void MakeItSo()
    {
        bool loadedThisTime  = false;
        sman.Lgg($"MakeItSo loadModel:{loadmodel.Get()} _ss_CadModelLoaded:{_ss_CadModelLoaded}",color:"violet");
        if (loadmodel.Get() && !_ss_CadModelLoaded)
        {
            //var xoff = -3;
            //var zoff = -3;
            var xoff = 0;
            var zoff = 0;
            var bsheit = GetZeroBasedFloorHeight(0, includeAltitude: true);

            //var defpos = new Vector3(-474.3f + xoff, bsheit+5.22f-0.79f, 87.6f + zoff);
            //var defpos = new Vector3(-15.69f + xoff, bsheit, -25.17f + zoff);
            var defpos = new Vector3(26.7f + xoff, bsheit-1.0f, 38.5f + zoff);
            sman.Lgg($"MakeItSo StapleStadium bsheit:{bsheit} defpos:{defpos}","orange");
            //var obprefab = Resources.Load<GameObject>("Willow/B19/B19-Willow");
            //var obprefab = Resources.Load<GameObject>("Stadiums/StaplesCenter02");
            var obprefab = Resources.Load<GameObject>("Stadiums/StaplesStadium03");
            if (obprefab==null)
            {
                sman.Lgg($"MakeItSo StapleStadium obprefab is null", "orange");
            }
            if (obprefab != null)
            {
                ssgo = Instantiate<GameObject>(obprefab);
                var ska = 0.085f;
                ssgo.transform.localScale = new Vector3(ska,ska,ska);
                ssgo.transform.position = defpos;
                ssgo.transform.Rotate(new Vector3(-90, 26, -63));
                ssgo.transform.parent = this.transform;
                _ss_CadModelLoaded = true;
                _ss_level01 = true;
                _ss_level02 = true;
                _ss_level03 = true;
                _ss_floors = true;
                _ss_doors = true;
                _ss_hvac = true;
                _ss_osmbld = sman.bdman.osmblds.Get();
                _ss_cadbld = true;
                loadedThisTime = true;
            }
        }
        else if(!loadmodel.Get() && _ss_CadModelLoaded)
        {
            DestroyGos();
            loadmodel.SetAndSave( false );
            _ss_CadModelLoaded = false;
            level01.SetAndSave( false );
            _ss_level01 = false;
            level02.SetAndSave( false );
            _ss_level02 = false;
            level03.SetAndSave( false );
            _ss_level03 = false;
            hvac.SetAndSave( false );
            _ss_hvac = false;
            _ss_osmbld = sman.bdman.osmblds.Get(); 
        }
        if (ssgo)
        {
            if (cadbld.Get() != _ss_cadbld)
            {
                var stat = cadbld.Get();
                ActuateCadStatus(stat);
                _ss_cadbld = stat;
            }
            if (osmbld.Get() != _ss_osmbld)
            {
                var stat = osmbld.Get();
                ActuateOsmStatus(stat);
                _ss_osmbld = stat;
            }
            if (level01.Get() != _ss_level01)
            {
                //Debug.Log("Fixing 1");
                var stat = level01.Get();
                SetChildVis("L01-AR", stat);
                //SetChildVis("L01-ME", stat);
                _ss_level01 = stat;
            }
            if (level02.Get() != _ss_level02)
            {
                //Debug.Log("Fixing 2");
                var stat = level02.Get();
                SetChildVis("L02-AR", stat);
                //SetChildVis("L02-ME", stat);
                _ss_level02 = stat;
            }
            if (level03.Get() != _ss_level03)
            {
                //Debug.Log("Fixing 3");
                var stat = level03.Get();
                SetChildVis("L03-AR", stat);
                //SetChildVis("L03-ME", stat);
                _ss_level03 = stat;
            }
            if (floors.Get() != _ss_floors)
            {
                //Debug.Log("Fixing floors");
                var stat = floors.Get();
                SetChildVis2("L01-AR", "Solid", stat);
                SetChildVis2("L02-AR", "Solid", stat);
                SetChildVis2("L03-AR", "Solid", stat);
                _ss_floors = stat;
            }
            if (doors.Get() != _ss_doors)
            {
                //Debug.Log("Fixing doors");
                var stat = doors.Get();
                SetChildVis2("L01-AR", "Composite_Part", stat);
                SetChildVis2("L02-AR", "Composite_Part", stat);
                SetChildVis2("L03-AR", "Composite_Part", stat);
                _ss_doors = stat;
            }
            if (hvac.Get() != _ss_hvac)
            {
                //Debug.Log("Fixing hvac");
                var stat = hvac.Get();
                SetChildVis("L01-ME", stat);
                SetChildVis("L02-ME", stat);
                SetChildVis("L03-ME", stat);
                _ss_hvac = stat;
            }
            if (loadedThisTime || lastMaterialMode != StapStad_materialMode.Get())
            {
                ActuateMaterialMode();
                lastMaterialMode = StapStad_materialMode.Get();
            }
        }
    }

    public void ActuateOsmStatus(bool stat)
    {
        if (bspec == null)
        {
            bspec = sman.bdman.FindBldSpecByNameStart(bld.osmnamestart);
        }
        if (bspecaux == null)
        {
            bspecaux = sman.bdman.FindBldSpecByNameStart("Staples");
        }
        if (bspec != null)
        {
            bspec.isVisible = stat;
            if (bspec.bgo != null)
            {
                bspec.bgo.SetActive(stat);
            }
        }
        if (bspecaux != null)
        {
            bspecaux.isVisible = stat;
            if (bspecaux.bgo != null)
            {
                bspecaux.bgo.SetActive(stat);
            }
        }
    }

    public void ActuateCadStatus(bool stat)
    {
        if (ssgo != null)
        {
            ssgo.SetActive(stat);
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
    public float GetZeroBasedFloorHeight(int floor, bool includeAltitude = true)
    {
        var rv = bspec.GetZeroBasedFloorHeight(floor, includeAltitude: includeAltitude);
        return rv;
    }

    //public float GetFloorHeightOld(int floor, bool includeAltitude = true)
    //{
    //    var rv = 0.01f;
    //    if (floor < 0) floor = 0;
    //    if (floor > 2) floor = 2;
    //    switch (floor)
    //    {
    //        case 0:
    //        case 1:
    //            rv = 0.01f;
    //            break;
    //        case 2:
    //            rv = 2.11f;
    //            break;
    //    }
    //    if (includeAltitude)
    //    {
    //        //rv += ymapheight;
    //        if (bspec == null)
    //        {
    //            sman.LggError("B19Willow.GetFloorHeight - bspec null with includeAltitude=true");
    //        }
    //        else
    //        {
    //            rv += bspec.GetGround();
    //        }
    //    }
    //    return rv;
    //}


    List<string> ss_parts = new List<string>
    {
        //"B19-Willow/L03-ME/Exhaust_Air_Duct,Exhaust_Air_DuctMat",
        //"B19-Willow/L03-ME/Solid,SolidMat",
        //"B19-Willow/L03-ME/Supply_Air_Duct,Supply_Air_DuctMat",
        //"B19-Willow/L01-AR/*Door_Frame,_Door_FrameMat",
        //"B19-Willow/L01-AR/*Finish_Facade_Feature_Wall,_Finish_Facade_Feature_WallMat",
        //"B19-Willow/L01-AR/*Glazing_Glass_-_Clear,_Glazing_Glass_-_ClearMat",
        //"B19-Willow/L01-AR/*Metal_Aluminum,_Metal_AluminumMat",
        //"B19-Willow/L01-AR/*Metal_Powdercoated_White,_Metal_Powdercoated_WhiteMat",
        //"B19-Willow/L01-AR/*Metal_Stainless_Steel_-_Polished,_Metal_Stainless_Steel_-_PolishedMat",
        //"B19-Willow/L01-AR/*Wall_Generic,_Wall_GenericMat",
        //"B19-Willow/L01-AR/.Wall_Default,",
        //"B19-Willow/L01-AR/_Aluminium,_AluminiumMat",
        //"B19-Willow/L01-AR/Composite_Part,Composite_PartMat",
        //"B19-Willow/L01-AR/Computer_Basic,Computer_BasicMat",
        //"B19-Willow/L01-AR/Computer_Basic_2,Computer_Basic_2Mat",
        //"B19-Willow/L01-AR/Computer_Basic_3,Computer_Basic_3Mat",
        //"B19-Willow/L01-AR/Computer_Glass,Computer_GlassMat",
        //"B19-Willow/L01-AR/Computer_Light_(ON),Computer_Light_(ON)Mat",
        //"B19-Willow/L01-AR/Computer_Metal,Computer_MetalMat",
        //"B19-Willow/L01-AR/Computer_Metal_2,Computer_Metal_2Mat",
        //"B19-Willow/L01-AR/Generic_-_Plastic_-_Black,Generic_-_Plastic_-_BlackMat",
        //"B19-Willow/L01-AR/Generic_-_Plastic_-_Grey,Generic_-_Plastic_-_GreyMat",
        //"B19-Willow/L01-AR/IKE080018_2,IKE080018_2Mat",
        //"B19-Willow/L01-AR/IKE080018_3,IKE080018_3Mat",
        //"B19-Willow/L01-AR/IKE160124_1,IKE160124_1Mat",
        //"B19-Willow/L01-AR/IKE160124_2,IKE160124_2Mat",
        //"B19-Willow/L01-AR/IKE160124_3,IKE160124_3Mat",
        //"B19-Willow/L01-AR/IKE160124_4,IKE160124_4Mat",
        //"B19-Willow/L01-AR/IKE160130_1,IKE160130_1Mat",
        //"B19-Willow/L01-AR/IKE160130_2,IKE160130_2Mat",
        //"B19-Willow/L01-AR/IKE160130_3,IKE160130_3Mat",
        //"B19-Willow/L01-AR/IKE160130_4,IKE160130_4Mat",
        //"B19-Willow/L01-AR/Metal-Chrome-Caroma,Metal-Chrome-CaromaMat",
        //"B19-Willow/L01-AR/PC_Monitor_Color,PC_Monitor_ColorMat",
        //"B19-Willow/L01-AR/PC_Monitor_Glass,PC_Monitor_GlassMat",
        //"B19-Willow/L01-AR/Porcelain-White-Caroma,Porcelain-White-CaromaMat",
        //"B19-Willow/L01-AR/Solid,SolidMat",
        //"B19-Willow/L01-ME/Copper,CopperMat",
        //"B19-Willow/L01-ME/Gas_Pipe,Gas_PipeMat",
        //"B19-Willow/L01-ME/Line,LineMat",
        //"B19-Willow/L01-ME/Return_Air_Duct,Return_Air_DuctMat",
        //"B19-Willow/L01-ME/Solid,SolidMat",
        //"B19-Willow/L01-ME/Supply_Air_Duct,Supply_Air_DuctMat",
        //"B19-Willow/L02-AR/*Door_Frame,_Door_FrameMat",
        //"B19-Willow/L02-AR/*Fabric_Linen_Porcelain,_Fabric_Linen_PorcelainMat",
        //"B19-Willow/L02-AR/*Finish_Facade_Feature_Wall,_Finish_Facade_Feature_WallMat",
        //"B19-Willow/L02-AR/*Glazing_Glass_-_Clear,_Glazing_Glass_-_ClearMat",
        //"B19-Willow/L02-AR/*Metal_Aluminum,_Metal_AluminumMat",
        //"B19-Willow/L02-AR/*Wall_Generic,_Wall_GenericMat",
        //"B19-Willow/L02-AR/.Wall_Default,",
        //"B19-Willow/L02-AR/_Aluminium,_AluminiumMat",
        //"B19-Willow/L02-AR/Composite_Part,Composite_PartMat",
        //"B19-Willow/L02-AR/Metal-Chrome-Caroma,Metal-Chrome-CaromaMat",
        //"B19-Willow/L02-AR/Porcelain-White-Caroma,Porcelain-White-CaromaMat",
        //"B19-Willow/L02-AR/Solid,SolidMat",
        //"B19-Willow/L02-ME/Exhaust_Air_Duct,Exhaust_Air_DuctMat",
        //"B19-Willow/L02-ME/Return_Air_Duct,Return_Air_DuctMat",
        //"B19-Willow/L02-ME/Solid,SolidMat",
        //"B19-Willow/L02-ME/Supply_Air_Duct,Supply_Air_DuctMat",
        //"B19-Willow/L03-AR/*Finish_Facade_Feature_Wall,_Finish_Facade_Feature_WallMat",
        //"B19-Willow/L03-AR/*Wall_Generic,_Wall_GenericMat"
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
        if (this.ssgo == null)
        {
            this.ssgo = GameObject.Find("StaplesStadium");
        }
        if (this.ssgo == null)
        {
            Debug.Log("Cound not find StaplesStadium");
            return;
        }
        var lst = GraphAlgos.GraphUtil.HierarchyDescToText(this.ssgo, "");
        var fname = "stapstad_materials.txt";
        //GraphAlgos.GraphUtil.writeListToFile(lst, fname);
        //Debug.Log("Wrote " + lst.Count + " lines to " + fname);
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
        if (this.ssgo == null)
        {
            this.ssgo = GameObject.Find("B19-Willow");
        }
        if (this.ssgo == null)
        {
            Debug.Log("Cound not find B19-Willow");
            return;
        }
        foreach( var pname in ss_parts)
        {
            var parcom = pname.Split(',');
            var partname = parcom[0];
            var partmat = parcom[1];
            var defmatname = "ComputerGlass";
            var matname = defmatname;
            switch (StapStad_materialMode.Get())
            {
                case StapStad_MaterialMode.glass:
                    matname = "ComputerGlass";
                    break;
                case StapStad_MaterialMode.materialed:
                    matname = bldmatmap[parcom[1]];
                    break;
                case StapStad_MaterialMode.glasswalls:
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
                case StapStad_MaterialMode.raw:
                    //matname = parcom[1];
                    matname = "";
                    break;
            }
            AssignPartMat(this.ssgo,partname, matname);
        }
        if (writepartlisttofile)
        {
            var lst = GraphAlgos.GraphUtil.HierarchyDescToText(this.ssgo, "");
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
