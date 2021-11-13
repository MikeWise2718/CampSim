using Aiskwk.Map;
using System.Collections.Generic;
using UnityEngine;
using UxUtils;

public class StaplesStadium : MonoBehaviour
{
    public enum StapStad_MaterialMode {  raw, materialed, glass, glasswalls };

    public UxSetting<bool> loadmodel = new UxSetting<bool>("StapStad_Model", true);
    public UxSetting<bool> roof = new UxSetting<bool>("StapStad_roof", true);
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
        _ss_roof = roof.GetInitial(false);
        _ss_floors = floors.GetInitial(false);
        _ss_doors = doors.GetInitial(false);
        _ss_osmbld = osmbld.GetInitial(false);
        _ss_cadbld = cadbld.GetInitial(false);
        _ss_glasswalls = glasswalls.GetInitial(false);
        lastMaterialMode = StapStad_materialMode.Get();
        bspec = sman.bdman.FindBldSpecByNameStart(bld.osmnamestart);
    }



    bool _ss_CadModelLoaded = false;
    bool _ss_roof = false;
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
        if (roof.Get() != _ss_roof)
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
                ssgo.name = "StapleStadium";
                var ska = 0.085f;
                ssgo.transform.localScale = new Vector3(ska,ska,ska);
                ssgo.transform.position = defpos;
                ssgo.transform.Rotate(new Vector3(-90, 26, -63));
                ssgo.transform.parent = this.transform;
                _ss_CadModelLoaded = true;
                _ss_floors = true;
                _ss_doors = true;
                _ss_roof = true;
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
            roof.SetAndSave( false );
            _ss_roof = false;
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
            if (floors.Get() != _ss_floors)
            {
                //Debug.Log("Fixing floors");
                var stat = floors.Get();
                _ss_floors = stat;
            }
            if (doors.Get() != _ss_doors)
            {
                //Debug.Log("Fixing doors");
                var stat = doors.Get();
                _ss_doors = stat;
            }
            if (roof.Get() != _ss_roof)
            {
                //Debug.Log("Fixing hvac");
                var stat = roof.Get();
                _ss_roof = stat;
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

    List<string> ss_parts = new List<string>
    {
        "StapleStadium/air_con,air_con (Instance)",
        "StapleStadium/air_con_stand,air_stand (Instance)",
        "StapleStadium/balcons,balcony (Instance)",
        "StapleStadium/balcons_floor,balcons_floor (Instance)",
        "StapleStadium/balcons_lamps,balcons_lamps (Instance)",
        "StapleStadium/balcony_building,balcony_building (Instance)",
        "StapleStadium/balustrade,balustrade (Instance)",
        "StapleStadium/balustrade2,balustrade (Instance)",
        "StapleStadium/bar_frame,white_frame (Instance)",
        "StapleStadium/bar_frame.000,white_frame (Instance)",
        "StapleStadium/base,base (Instance)",
        "StapleStadium/black_window_frame,black_window_frame (Instance)",
        "StapleStadium/bright_windows,bright_glass (Instance)",
        "StapleStadium/chairs_brown,chairs_brown (Instance)",
        "StapleStadium/chairs_tables_white,chairs_tables_white (Instance)",
        "StapleStadium/columns,columns (Instance)",
        "StapleStadium/Cube,Material (Instance)",
        "StapleStadium/Cube.001,Material.001 (Instance)",
        "StapleStadium/curtains,curtains (Instance)",
        "StapleStadium/dark_windows,dark_glass (Instance)",
        "StapleStadium/dome,dome (Instance)",
        "StapleStadium/doors,doors (Instance)",
        "StapleStadium/entry_columnB,entry_columnB (Instance)",
        "StapleStadium/entry_columnsW,entry_columnsW (Instance)",
        "StapleStadium/gray_ventilator,gray_wall1 (Instance)",
        "StapleStadium/gray_wall1,gray_wall2 (Instance)",
        "StapleStadium/gray_wall2,gray_wall2 (Instance)",
        "StapleStadium/gray_wall3,gray_wall2 (Instance)",
        "StapleStadium/gray_wall4,gray_wall2 (Instance)",
        "StapleStadium/gray_wall5,gray_wall2 (Instance)",
        "StapleStadium/gray_wall6,gray_wall2 (Instance)",
        "StapleStadium/gray_wall7,gray_wall2 (Instance)",
        "StapleStadium/gray_wall8,gray_wall2 (Instance)",
        "StapleStadium/gray_wall9,gray_wall2 (Instance)",
        "StapleStadium/gray_wall10,gray_wall2 (Instance)",
        "StapleStadium/gray_wall11,gray_wall2 (Instance)",
        "StapleStadium/gray_wall12,gray_wall2 (Instance)",
        "StapleStadium/gray_wall13,gray_wall2 (Instance)",
        "StapleStadium/gray_wall14,gray_wall2 (Instance)",
        "StapleStadium/gray_wall15,gray_wall2 (Instance)",
        "StapleStadium/gray_wall16,gray_wall2 (Instance)",
        "StapleStadium/gray_wall17,gray_wall2 (Instance)",
        "StapleStadium/gray_wall18,gray_wall2 (Instance)",
        "StapleStadium/gray_wall19,gray_wall2 (Instance)",
        "StapleStadium/gray_wall20,gray_wall2 (Instance)",
        "StapleStadium/gray_wall21,gray_wall2 (Instance)",
        "StapleStadium/ground1,wall_ground1 (Instance)",
        "StapleStadium/ground2,wall_ground2 (Instance)",
        "StapleStadium/ground3,wall_ground4 (Instance)",
        "StapleStadium/ground4,wall_ground4 (Instance)",
        "StapleStadium/ground5,wall_ground5 (Instance)",
        "StapleStadium/ground6,wall_ground6 (Instance)",
        "StapleStadium/ground7,wall_ground6 (Instance)",
        "StapleStadium/ground8,wall_ground8 (Instance)",
        "StapleStadium/ground9,wall_ground9 (Instance)",
        "StapleStadium/ground10,wall_ground10 (Instance)",
        "StapleStadium/ground11,wall_ground11 (Instance)",
        "StapleStadium/ground12,wall_ground12 (Instance)",
        "StapleStadium/ground13,wall_ground13 (Instance)",
        "StapleStadium/handrail,handrail (Instance)",
        "StapleStadium/hood,hood (Instance)",
        "StapleStadium/lakers_ad,lakers_logo (Instance)",
        "StapleStadium/lamp_globe,white_glass (Instance)",
        //"StapleStadium/Light",
        //"StapleStadium/Light.001",
        "StapleStadium/NE_wall,wall1 (Instance)",
        "StapleStadium/NE_wall1,gray_wall1 (Instance)",
        "StapleStadium/NE_wall2,wall_concrete_grey (Instance)",
        "StapleStadium/NE_wall3,wall2 (Instance)",
        "StapleStadium/NE_wall4,wall3 (Instance)",
        "StapleStadium/nike_ad,nike_ads (Instance)",
        "StapleStadium/northeastern_wall,wall7 (Instance)",
        "StapleStadium/office_pink,box_office (Instance)",
        "StapleStadium/poles,poles (Instance)",
        "StapleStadium/reflectors,reflectors (Instance)",
        "StapleStadium/restaurant_floor,restaurant_floor (Instance)",
        "StapleStadium/restaurant_floor_out,restaurant_floor_out (Instance)",
        "StapleStadium/restaurant_roof,restaurant_roof (Instance)",
        "StapleStadium/ring_roof,ring_roof (Instance)",
        "StapleStadium/roof,roof (Instance)",
        "StapleStadium/roof_bar,roof_stripe (Instance)",
        "StapleStadium/roof_door_frame,roof_door_frame (Instance)",
        "StapleStadium/roof_doors_frame,roof_doors (Instance)",
        "StapleStadium/roof_lamps,roof_lamps (Instance)",
        "StapleStadium/roof_red,red_roof (Instance)",
        "StapleStadium/roof_room,roof_room (Instance)",
        "StapleStadium/roof_room_floor,szpic (Instance)",
        "StapleStadium/roof_spitz,roof_spitz (Instance)",
        "StapleStadium/roof_stairs,stairs (Instance)",
        "StapleStadium/roof_wall,roof_wall (Instance)",
        "StapleStadium/S_building,S_building (Instance)",
        "StapleStadium/S_bulding_wall,gray_wall1 (Instance)",
        "StapleStadium/S_floor,S_floor (Instance)",
        "StapleStadium/S_floor2,S_floor (Instance)",
        "StapleStadium/S_roofDark,S_roofdark (Instance)",
        "StapleStadium/S_roofDark2,S_roofdark (Instance)",
        "StapleStadium/S_roofWhite,S_roofWhite (Instance)",
        "StapleStadium/S_wall1,S_bulding_wall (Instance)",
        "StapleStadium/S_wall2,S_wall (Instance)",
        "StapleStadium/S_wall3,S_bulding_wall (Instance)",
        "StapleStadium/S_wall4,S_wall4 (Instance)",
        "StapleStadium/S_wall5,S_wall5 (Instance)",
        "StapleStadium/S_wall6,S_wall6 (Instance)",
        "StapleStadium/S_wall7,white_frame (Instance)",
        "StapleStadium/S_wall8,white_frame (Instance)",
        "StapleStadium/S_wall9,b_w_wall (Instance)",
        "StapleStadium/S_wall10,gray_wall1 (Instance)",
        "StapleStadium/satellite_dishes,satellite_dishes (Instance)",
        "StapleStadium/solar_standB,solar_stand_black (Instance)",
        "StapleStadium/solar_standW,solar_white_stand (Instance)",
        "StapleStadium/solars,solars (Instance)",
        "StapleStadium/stairs,white_frame (Instance)",
        "StapleStadium/staple_stand,text_stands (Instance)",
        "StapleStadium/staples_handle,staples_handle (Instance)",
        "StapleStadium/staples_red,staples_red_text (Instance)",
        "StapleStadium/staples_roof,staples_roof (Instance)",
        "StapleStadium/storey,storey (Instance)",
        "StapleStadium/storey_buildings,storey_buildings (Instance)",
        "StapleStadium/storey_lamps,lamps (Instance)",
        "StapleStadium/tables_brown,tables (Instance)",
        "StapleStadium/teamLA,team_LA (Instance)",
        "StapleStadium/teamLA_ad,teamLA (Instance)",
        "StapleStadium/ticket_office,white_frame (Instance)",
        "StapleStadium/ticketoffice,white_frame (Instance)",
        "StapleStadium/TV_desktop,tv (Instance)",
        "StapleStadium/TV_frame,TV_frame (Instance)",
        "StapleStadium/TV_wall,wall7 (Instance)",
        "StapleStadium/ventilator,wire_255255255 (Instance)",
        "StapleStadium/ventilators,ventilators (Instance)",
        "StapleStadium/W_building1,W_building2 (Instance)",
        "StapleStadium/W_building2,W_building2 (Instance)",
        "StapleStadium/W_wall,grey_wall2 (Instance)",
        "StapleStadium/W_wall1,W_wall1 (Instance)",
        "StapleStadium/W_wall2,wall5 (Instance)",
        "StapleStadium/white_window_frame,white_frame (Instance)",
    };


    //Dictionary<string, string> bldmatmap = new Dictionary<string, string>
    //{
    //    {"SolidMat","WallWhite"},
    //    {"Exhaust_Air_DuctMat","Aluminium"},
    //    {"Supply_Air_DuctMat","Aluminium"},
    //    {"Return_Air_DuctMat","Aluminium"},
    //    {"_Door_FrameMat","Plywood"},
    //    {"_Finish_Facade_Feature_WallMat","FacadeWall"},
    //    {"_Glazing_Glass_-_ClearMat","DustyGlass"},
    //    {"_Metal_Powdercoated_WhiteMat","Aluminium"},
    //    {"_Metal_Stainless_Steel_-_PolishedMat","Steel"},
    //    {"_Wall_GenericMat","WallMat"},
    //    {"_Fabric_Linen_PorcelainMat","WallMat"},
    //    {"","WallMat"},
    //    {"_Metal_AluminumMat","Aluminium"},
    //    {"_AluminiumMat","Aluminium"},
    //    {"Composite_PartMat","WallMat"},
    //    {"Computer_BasicMat","PlasticHololens"},
    //    {"Computer_Basic_2Mat","PlasticHololens"},
    //    {"Computer_Basic_3Mat","PlasticHololens"},
    //    {"Computer_GlassMat","ComputerGlass"},
    //    {"Computer_Light_(ON)Mat","BlueLight"},
    //    {"Computer_MetalMat","Aluminium"},
    //    {"Computer_Metal_2Mat","Aluminium"},
    //    {"PC_Monitor_ColorMat","ComputerGlass"},
    //    {"PC_Monitor_GlassMat","ComputerGlass"},
    //    {"Generic_-_Plastic_-_BlackMat","PlasticHololens"},
    //    {"Generic_-_Plastic_-_GreyMat","PlasticHololens"},
    //    {"IKE080018_2Mat","Aluminium"},
    //    {"IKE080018_3Mat","Aluminium"},
    //    {"IKE160124_1Mat","Aluminium"},
    //    {"IKE160124_2Mat","Aluminium"},
    //    {"IKE160124_3Mat","Aluminium"},
    //    {"IKE160124_4Mat","Aluminium"},
    //    {"IKE160130_1Mat","Aluminium"},
    //    {"IKE160130_2Mat","Aluminium"},
    //    {"IKE160130_3Mat","Aluminium"},
    //    {"IKE160130_4Mat","Aluminium"},
    //    {"Metal-Chrome-CaromaMat","Steel"},
    //    {"Porcelain-White-CaromaMat","WallMat"},
    //    {"CopperMat","Copper"},
    //    {"Gas_PipeMat","Copper"},
    //    {"LineMat","WallMat"},
    //};



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
    public void AssignPartMat(GameObject rootgo,string partname,string matname,bool prefix=true,bool loadmat=true)
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
            if (!prefix)
            {
                fullmatname = matname;
            }
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
            Debug.Log(pname);
            var parcom = pname.Split(',');
            var partname = parcom[0];
            var partmat = parcom[1];
            var defmatname = "ComputerGlass";
            var matname = defmatname;
            var prefix = true;
            switch (StapStad_materialMode.Get())
            {
                case StapStad_MaterialMode.glass:
                    matname = "ComputerGlass";
                    break;
                case StapStad_MaterialMode.materialed:
                    // matname = bldmatmap[parcom[1]];
                    matname = parcom[1];
                    matname = matname.Replace(" (Instance)","");
                    prefix = true;
                    break;
                case StapStad_MaterialMode.glasswalls:
                    var pnl = partname.ToLower();
                    if (pnl.Contains("solid") || pnl.Contains("wall") || pnl.Contains("door") || pnl.Contains("composite_part"))
                    {
                        matname = "ComputerGlass";
                    }
                    else
                    {
                        // matname = bldmatmap[partmat];
                        matname = partmat;
                    }
                    break;
                case StapStad_MaterialMode.raw:
                    //matname = parcom[1];
                    matname = "";
                    break;
            }
            AssignPartMat(this.ssgo,partname, matname, prefix:prefix);
        }
        if (writepartlisttofile)
        {
            var lst = GraphAlgos.GraphUtil.HierarchyDescToText(this.ssgo, "");
            var fname = "StapStadium.txt";
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
                Debug.Log($"ChangeHappened to StapStad upd:{updcount}");
                MakeItSo();
            }
        }
        updcount++;
    }
}
