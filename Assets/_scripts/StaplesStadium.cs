using Aiskwk.Map;
using System.Collections.Generic;
using UnityEngine;
using UxUtils;

public class StaplesStadium : MonoBehaviour
{
    public enum StapStad_MaterialMode {  raw, materialed, glass, glasswalls };

    public UxSetting<bool> loadmodel = new UxSetting<bool>("StapStad_Model", true);
    public UxSetting<bool> ssroof = new UxSetting<bool>("StapStad_roof", true);
    public UxSetting<bool> ssfloors = new UxSetting<bool>("StapStad_floors", true);
    public UxSetting<bool> sswalls = new UxSetting<bool>("StapStad_walls", true);
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
        _ss_roof = ssroof.GetInitial(false);
        _ss_floors = ssfloors.GetInitial(false);
        _ss_walls = sswalls.GetInitial(false);
        _ss_osmbld = osmbld.GetInitial(false);
        _ss_cadbld = cadbld.GetInitial(false);
        _ss_glasswalls = glasswalls.GetInitial(false);
        lastMaterialMode = StapStad_materialMode.Get();
        bspec = sman.bdman.FindBldSpecByNameStart(bld.osmnamestart);
    }



    bool _ss_CadModelLoaded = false;
    bool _ss_roof = false;
    bool _ss_floors = false;
    bool _ss_walls = false;
    bool _ss_osmbld = false;
    bool _ss_cadbld = false;
    bool _ss_glasswalls = false;
    StapStad_MaterialMode lastMaterialMode;

    GameObject ssgo = null;



    bool ChangeHappened()
    {
        var chg = false;
        if (loadmodel.Get() != _ss_CadModelLoaded) chg = true;
        if (ssfloors.Get() != _ss_floors)
        {
            chg = true;
            //Debug.Log("floors");
        }
        if (sswalls.Get() != _ss_walls)
        {
            chg = true;
            //Debug.Log("floors");
        }
        if (ssroof.Get() != _ss_roof)
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
                _ss_walls = true;
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
            ssroof.SetAndSave( false );
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
            if (ssfloors.Get() != _ss_floors)
            {
                //Debug.Log("Fixing floors");
                var stat = ssfloors.Get();
                _ss_floors = stat;
            }
            if (sswalls.Get() != _ss_walls)
            {
                //Debug.Log("Fixing doors");
                var stat = sswalls.Get();
                _ss_walls = stat;
            }
            if (ssroof.Get() != _ss_roof)
            {
                //Debug.Log("Fixing hvac");
                var stat = ssroof.Get();
                _ss_roof = stat;
            }
            if (loadedThisTime || lastMaterialMode != StapStad_materialMode.Get())
            {
                ActuateMaterialMode();
                ActuatePartVisMode();
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
        "StapleStadium/air_con,air_con",
        "StapleStadium/air_con_stand,air_stand",
        "StapleStadium/balcons,balcony",
        "StapleStadium/balcons_floor,balcons_floor",
        "StapleStadium/balcons_lamps,balcons_lamps",
        "StapleStadium/balcony_building,balcony_building",
        "StapleStadium/balustrade,balustrade",
        "StapleStadium/balustrade2,balustrade",
        "StapleStadium/bar_frame,white_frame",
        "StapleStadium/bar_frame.000,white_frame",
        "StapleStadium/base,base",
        "StapleStadium/black_window_frame,black_window_frame",
        "StapleStadium/bright_windows,bright_glass",
        "StapleStadium/chairs_brown,chairs_brown",
        "StapleStadium/chairs_tables_white,chairs_tables_white",
        "StapleStadium/columns,columns",
        "StapleStadium/Cube,Material",
        "StapleStadium/Cube.001,Material.001",
        "StapleStadium/curtains,curtains",
        "StapleStadium/dark_windows,dark_glass",
        "StapleStadium/dome,dome",
        "StapleStadium/doors,doors",
        "StapleStadium/entry_columnB,entry_columnB",
        "StapleStadium/entry_columnsW,entry_columnsW",
        "StapleStadium/gray_ventilator,gray_wall1",
        "StapleStadium/gray_wall1,gray_wall2",
        "StapleStadium/gray_wall2,gray_wall2",
        "StapleStadium/gray_wall3,gray_wall2",
        "StapleStadium/gray_wall4,gray_wall2",
        "StapleStadium/gray_wall5,gray_wall2",
        "StapleStadium/gray_wall6,gray_wall2",
        "StapleStadium/gray_wall7,gray_wall2",
        "StapleStadium/gray_wall8,gray_wall2",
        "StapleStadium/gray_wall9,gray_wall2",
        "StapleStadium/gray_wall10,gray_wall2",
        "StapleStadium/gray_wall11,gray_wall2",
        "StapleStadium/gray_wall12,gray_wall2",
        "StapleStadium/gray_wall13,gray_wall2",
        "StapleStadium/gray_wall14,gray_wall2",
        "StapleStadium/gray_wall15,gray_wall2",
        "StapleStadium/gray_wall16,gray_wall2",
        "StapleStadium/gray_wall17,gray_wall2",
        "StapleStadium/gray_wall18,gray_wall2",
        "StapleStadium/gray_wall19,gray_wall2",
        "StapleStadium/gray_wall20,gray_wall2",
        "StapleStadium/gray_wall21,gray_wall2",
        "StapleStadium/ground1,wall_ground1",
        "StapleStadium/ground2,wall_ground2",
        "StapleStadium/ground3,wall_ground4",
        "StapleStadium/ground4,wall_ground4",
        "StapleStadium/ground5,wall_ground5",
        "StapleStadium/ground6,wall_ground6",
        "StapleStadium/ground7,wall_ground6",
        "StapleStadium/ground8,wall_ground8",
        "StapleStadium/ground9,wall_ground9",
        "StapleStadium/ground10,wall_ground10",
        "StapleStadium/ground11,wall_ground11",
        "StapleStadium/ground12,wall_ground12",
        "StapleStadium/ground13,wall_ground13",
        "StapleStadium/handrail,handrail",
        "StapleStadium/hood,hood",
        "StapleStadium/lakers_ad,lakers_logo",
        "StapleStadium/lamp_globe,white_glass",
        //"StapleStadium/Light",
        //"StapleStadium/Light.001",
        "StapleStadium/NE_wall,wall1",
        "StapleStadium/NE_wall1,gray_wall1",
        "StapleStadium/NE_wall2,wall_concrete_grey",
        "StapleStadium/NE_wall3,wall2",
        "StapleStadium/NE_wall4,wall3",
        "StapleStadium/nike_ad,nike_ads",
        "StapleStadium/northeastern_wall,wall7",
        "StapleStadium/office_pink,box_office",
        "StapleStadium/poles,poles",
        "StapleStadium/reflectors,reflectors",
        "StapleStadium/restaurant_floor,restaurant_floor",
        "StapleStadium/restaurant_floor_out,restaurant_floor_out",
        "StapleStadium/restaurant_roof,restaurant_roof",
        "StapleStadium/ring_roof,ring_roof",
        "StapleStadium/roof,roof",
        "StapleStadium/roof_bar,roof_stripe",
        "StapleStadium/roof_door_frame,roof_door_frame",
        "StapleStadium/roof_doors_frame,roof_doors",
        "StapleStadium/roof_lamps,roof_lamps",
        "StapleStadium/roof_red,red_roof",
        "StapleStadium/roof_room,roof_room",
        "StapleStadium/roof_room_floor,szpic",
        "StapleStadium/roof_spitz,roof_spitz",
        "StapleStadium/roof_stairs,stairs",
        "StapleStadium/roof_wall,roof_wall",
        "StapleStadium/S_building,S_building",
        "StapleStadium/S_bulding_wall,gray_wall1",
        "StapleStadium/S_floor,S_floor",
        "StapleStadium/S_floor2,S_floor",
        "StapleStadium/S_roofDark,S_roofdark",
        "StapleStadium/S_roofDark2,S_roofdark",
        "StapleStadium/S_roofWhite,S_roofWhite",
        "StapleStadium/S_wall1,S_bulding_wall",
        "StapleStadium/S_wall2,S_wall",
        "StapleStadium/S_wall3,S_bulding_wall",
        "StapleStadium/S_wall4,S_wall4",
        "StapleStadium/S_wall5,S_wall5",
        "StapleStadium/S_wall6,S_wall6",
        "StapleStadium/S_wall7,white_frame",
        "StapleStadium/S_wall8,white_frame",
        "StapleStadium/S_wall9,b_w_wall",
        "StapleStadium/S_wall10,gray_wall1",
        "StapleStadium/satellite_dishes,satellite_dishes",
        "StapleStadium/solar_standB,solar_stand_black",
        "StapleStadium/solar_standW,solar_white_stand",
        "StapleStadium/solars,solars",
        "StapleStadium/stairs,white_frame",
        "StapleStadium/staple_stand,text_stands",
        "StapleStadium/staples_handle,staples_handle",
        "StapleStadium/staples_red,staples_red_text",
        "StapleStadium/staples_roof,staples_roof",
        "StapleStadium/storey,storey",
        "StapleStadium/storey_buildings,storey_buildings",
        "StapleStadium/storey_lamps,lamps",
        "StapleStadium/tables_brown,tables",
        "StapleStadium/teamLA,team_LA",
        "StapleStadium/teamLA_ad,teamLA",
        "StapleStadium/ticket_office,white_frame",
        "StapleStadium/ticketoffice,white_frame",
        "StapleStadium/TV_desktop,tv",
        "StapleStadium/TV_frame,TV_frame",
        "StapleStadium/TV_wall,wall7",
        "StapleStadium/ventilator,wire_255255255",
        "StapleStadium/ventilators,ventilators",
        "StapleStadium/W_building1,W_building2",
        "StapleStadium/W_building2,W_building2",
        "StapleStadium/W_wall,grey_wall2",
        "StapleStadium/W_wall1,W_wall1",
        "StapleStadium/W_wall2,wall5",
        "StapleStadium/white_window_frame,white_frame",
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
    public void AssignPartMat(GameObject rootgo,string partname,string matname,bool prefix=true)
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
        var newmode = StapStad_materialMode.Get();
        var sw = new Aiskwk.Dataframe.StopWatch();
        var nglass = 0;
        var nmat = 0;
        foreach ( var pname in ss_parts)
        {
            //Debug.Log(pname);
            var parcom = pname.Split(',');
            var partname = parcom[0];
            var partmat = parcom[1];
            var defmatname = "ComputerGlass";
            var matname = defmatname;
            switch (newmode)
            {
                case StapStad_MaterialMode.glass:
                    matname = "ComputerGlass";
                    nglass++;
                    break;
                case StapStad_MaterialMode.materialed:
                    // matname = bldmatmap[parcom[1]];
                    matname = parcom[1];
                    nmat++;
                    break;
                case StapStad_MaterialMode.glasswalls:
                    var pnl = partname.ToLower();
                    if (pnl.Contains("wall") || pnl.Contains("door"))
                    {
                        matname = "ComputerGlass";
                        nglass++;
                    }
                    else
                    {
                        // matname = bldmatmap[partmat];
                        matname = partmat;
                        nmat++;
                    }
                    break;
                case StapStad_MaterialMode.raw:
                    matname = parcom[1];
                    nmat++;
                    //matname = "";
                    break;
            }
            AssignPartMat(this.ssgo,partname, matname);
        }
        sw.Stop();
        sman.Lgg($"SS Materials reassignment to {newmode} took {sw.ElapSecs()} secs nmat:{nmat} nglass:{nglass}","darkblue");
        if (writepartlisttofile)
        {
            var lst = GraphAlgos.GraphUtil.HierarchyDescToText(this.ssgo, "");
            var fname = "StapStadium.txt";
            GraphAlgos.GraphUtil.writeListToFile(lst, fname);
            Debug.Log($"Wrote {lst.Count} lines to {fname}");
        }
    }

    public void ActuatePartVisMode()
    {
        var sw = new Aiskwk.Dataframe.StopWatch();
        var roofon = ssroof.Get();
        var wallson = sswalls.Get();
        var floorson = ssfloors.Get();
        foreach (var pname in ss_parts)
        {
            var parcom = pname.Split(',');
            var partname = parcom[0];
            if (partname.Contains("roof") || partname.Contains("solar"))
            {
                var go = GetPart(this.ssgo, partname);
                if (go != null)
                {
                    go.SetActive(roofon);
                }
                else
                {
                    Debug.LogError($"SS ActuatPartVisMode could not find part {partname} while actuating roof status");
                }
            }
            if (partname.Contains("floor") )
            {
                var go = GetPart(this.ssgo, partname);
                if (go != null)
                {
                    go.SetActive(floorson);
                }
                else
                {
                    Debug.LogError($"SS ActuatPartVisMode could not find part {partname} while actuating floor status");
                }
            }
            if (partname.Contains("wall"))
            {
                var go = GetPart(this.ssgo, partname);
                if (go != null)
                {
                    go.SetActive(wallson);
                }
                else
                {
                    Debug.LogError($"SS ActuatPartVisMode could not find part {partname} while actuating wall status");
                }
            }
        }
        sw.Stop();
        sman.Lgg($"SS Part Visiblity actuation took {sw.ElapSecs()} secs","darkblue");
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
