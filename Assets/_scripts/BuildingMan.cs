using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UxUtils;
using Aiskwk.Map;
using System.Data.Common;
using UnityEngine.Rendering;

namespace CampusSimulator
{

    public class BuildingMan : MonoBehaviour
    {

        Dictionary<string, Building> bldalias = new Dictionary<string, Building>();
        Dictionary<string, Building> bldmasterlist = new Dictionary<string, Building>();
        List<string> bldnames = new List<string>(); // maintain a sorted list of buildings with destinations
        List<string> wtdbldnames = new List<string>(); // maintain a sorted weighted list of buildings with destinations
        List<string> dronebldnames = new List<string>(); // maintain a  weighted list of buildings with drone destinations

        Dictionary<string, BldRoom> noderoomlookup = new Dictionary<string, BldRoom>(); // a home for fixed nodes that need to know their building
        Dictionary<string, BldRoom> roomlookup = new Dictionary<string, BldRoom>();
        Dictionary<string, BldDronePad> nodepadlookup = new Dictionary<string, BldDronePad>(); // a home for fixed nodes that need to know their building
        Dictionary<string, BldDronePad> padlookup = new Dictionary<string, BldDronePad>();


        public SceneMan sman = null;

        // Stats for Inspector 
        public int nBuildings;
        public int nDroneBuildings;
        public int nSkippedBuildingsWithoutOsmPoints;
        public int nRooms;
        public int nPads;
        public int nPeople;
        public int nPeopleInRooms;
        public int nDrones;
        public int nDronesOnPads;
        public int nVehicles;

        public bool showPersRects;

        public List<OsmBldSpec> bldspecs;
        public List<string> scene_padspecs;


        public UxSettingBool walllinks = new UxSettingBool("walllinks", false);
        public UxSettingBool osmblds = new UxSettingBool("osmblds", true);
        public UxSettingBool osmbldstrans = new UxSettingBool("osmbldstrans", true);
        public UxSettingBool osmbldpolygons = new UxSettingBool("osmbldpolygons", true);
        public UxSettingBool fixedblds = new UxSettingBool("fixedblds", false);
        public UxSettingBool osmoutline = new UxSettingBool("osmoutline", true);
        public UxSettingBool osmgroundoutline = new UxSettingBool("osmgroundoutline", true);
        public UxSetting<string> selectedbldname = new UxSetting<string>("selectedbldname", "");

        // To do - get rid of bldmode and treemode regions in BuildingMan
        #region bldMode
        public enum BldModeE { none, full };
        public UxEnumSetting<BldModeE> bldMode = new UxEnumSetting<BldModeE>("BuildingMode",BldModeE.full);

        public void AssociateNodeWithRoom(string nodename,BldRoom broom)
        {
            noderoomlookup[nodename] = broom;
        }

        public BldRoom GetAssociatedRoom(string nodename)
        {
            if (IsRoom(nodename))
            {
                return roomlookup[nodename];
            }
            else if (IsRoomAssociatedNode(nodename))
            {
                return noderoomlookup[nodename];
            }
            else
            {
                Debug.Log("Bad Associated Room lookup  - " + nodename);
                return null;
            }
        }

        public BldDronePad GetAssociatedPad(string nodename)
        {
            if (IsPad(nodename))
            {
                return padlookup[nodename];
            }
            else if (IsPadAssociatedNode(nodename))
            {
                return nodepadlookup[nodename];
            }
            else
            {
                Debug.Log("Bad Associated Room lookup  - " + nodename);
                return null;
            }
        }


        public BldRoom GetBroom(string roomname,bool expectFailure=false)
        {
            if (!roomlookup.ContainsKey(roomname))
            {
                if (!expectFailure)
                {
                    sman.LggError($"Bad roomname lookup {roomname}");
                }
                return null;
            }
            return roomlookup[roomname];
        }
        public List<BldRoom> GetBrooms()
        {
            return new List<BldRoom>(roomlookup.Values);
        }

        public BldDronePad GetBpad(string padname, bool expectFailure = false)
        {
            if (!padlookup.ContainsKey(padname))
            {
                if (!expectFailure)
                {
                    sman.LggError($"Bad padname lookup {padname}");
                }
                return null;
            }
            return padlookup[padname];
        }
        public List<BldDronePad> GetDronePads()
        {
            return new List<BldDronePad>(padlookup.Values);
        }

        public List<string> GetDronePadNames()
        {
            var padlst = GetDronePads();
            var rv = new List<string>();
            foreach(var pd in padlst)
            {
                rv.Add(pd.name);
            }
            return rv;
        }
        public void ToggleBld()
        {
            if (bldMode.Get() == BldModeE.full)
            {
                bldMode.Set(BldModeE.none);
            }
            else
            {
                bldMode.Set(BldModeE.full);
            }
        }
        #endregion bldMode

        #region treeMode
        public enum TreeModeE {  none, full };
        public UxEnumSetting<TreeModeE> treeMode = new UxEnumSetting<TreeModeE>("TreeMode",TreeModeE.full);

        public void ToggleTrees()
        {
            if (treeMode.Get()==TreeModeE.full)
            {
                treeMode.Set(TreeModeE.none);
            }
            else
            {
                treeMode.Set(TreeModeE.full);
            }
        }
        #endregion treeMode

        public void InitPhase0()
        {
        }
        Dictionary<OsmBldSpec, Building> bsDict;
        Dictionary<Building, OsmBldSpec> bsRevDict;

        public void RegisterBsBld(OsmBldSpec bs, Building bld)
        {
            bsDict[bs] = bld;
            bsRevDict[bld] = bs;
        }
        public Building GetBsBld(OsmBldSpec bs)
        {
            if (!bsDict.ContainsKey(bs))
            {
                return null;
            }
            return bsDict[bs];
        }
        public OsmBldSpec GetBldBs(Building bld)
        {
            if (!bsRevDict.ContainsKey(bld))
            {
                return null;
            }
            return bsRevDict[bld];
        }

        public OsmBldSpec FindBldSpecByNameStart(string namestart)
        {
            if (bldspecs != null)
            {
                foreach (var bs in bldspecs)
                {
                    if (bs.osmname.StartsWith(namestart))
                    {
                        //Debug.Log($"Found \"{bs.osmname}\" starts with \"{namestart}\"");
                        return bs;
                    }
                }
            }
            sman.LggWarning($"FindBldSpecByNameStart - Found nothing that starts with \"{namestart}\"");
            return null;
        }

        public OsmBldSpec FindBldSpecByWid(string seekwid)
        {
            if (bldspecs != null)
            {
                foreach (var bs in bldspecs)
                {
                    if (bs.wid==seekwid)
                    {
                        //Debug.Log($"Found {bs.wid}");
                        return bs;
                    }
                }
            }
            sman.LggWarning($"FindBldSpecByWid - Cound not find {seekwid}");
            return null;
        }

        public void ModelInitialize(SceneSelE newregion)
        {
            bldmasterlist = new Dictionary<string, Building>();
            bldalias = new Dictionary<string, Building>();
            bldnames = new List<string>(); // maintain a sorted list of buildings with destinations
            wtdbldnames = new List<string>(); // maintain a sorted weighted list of buildings with destinations
            dronebldnames = new List<string>(); // maintain a  weighted list of buildings with drone destinations

            noderoomlookup = new Dictionary<string, BldRoom>(); // a home for fixed nodes that need to know their building
            roomlookup = new Dictionary<string, BldRoom>();
            nodepadlookup = new Dictionary<string, BldDronePad>(); // a home for fixed nodes that need to know their building
            padlookup = new Dictionary<string, BldDronePad>();
            bldspecs = new List<OsmBldSpec>();
            bsDict = new Dictionary<OsmBldSpec, Building>();
            bsRevDict = new Dictionary<Building, OsmBldSpec>();

            InitializeValues();
        }

        void InitializeValues()
        {
            //treeMode = GetInitialTreeMode();
            treeMode.GetInitial(TreeModeE.full);
            bldMode.GetInitial(BldModeE.full);
            walllinks.GetInitial(false);
            osmblds.GetInitial(true);
            osmbldstrans.GetInitial(true);
            osmbldpolygons.GetInitial(true);
            osmoutline.GetInitial(true);
            osmgroundoutline.GetInitial(true);
            selectedbldname.GetInitial("");
            fixedblds.GetInitial(false);
            scene_padspecs = new List<string>();
            sman.Lgg($"BuildingMan.InitializeValues walllinks:{walllinks.Get()} osmblds:{osmblds.Get()} osmbldstrans:{osmbldstrans.Get()}   fixedblds:{fixedblds.Get()}","pink");
        }


        public List<string> GetFilteredPadSpecs(string prefix)
        {
            var rv = new List<string>();
            foreach (var ps in scene_padspecs)
            {
                if (ps.StartsWith(prefix))
                {
                    rv.Add(ps);
                }
            }
            return rv;
        }
        public B19Willow GetB19()
        {
            var bld19 = GetBuilding("Bld19", couldFail: true);
            if (bld19 == null)
            {
                //sman.LggError($"No Bld19 in scene"); // not all scenes even have B19
                return null;
            }
            var b19comp = bld19.GetComponent<B19Willow>();
            if (b19comp == null)
            {
                sman.LggError($"No B19 Component attached to Bld19 in scene");
                return null;
            }
            return b19comp;
        }

        public void ToggleB19Level1()
        {
            var b19comp = GetB19();
            var curval = b19comp.level01.Get();
            b19comp.level01.SetAndSave(!curval);
            b19comp.MakeItSo();
        }
        public void ToggleB19Level2()
        {
            var b19comp = GetB19();
            var curval = b19comp.level02.Get();
            b19comp.level02.SetAndSave(!curval);
            b19comp.MakeItSo();
        }
        public void ToggleB19Level3()
        {
            var b19comp = GetB19();
            var curval = b19comp.level03.Get();
            b19comp.level03.SetAndSave(!curval);
            b19comp.MakeItSo();
        }

        public void ToggleB19Doors()
        {
            var b19comp = GetB19();
            var curval = b19comp.doors.Get();
            b19comp.doors.SetAndSave(!curval);
            b19comp.MakeItSo();
        }
        public void ToggleB19Floors()
        {
            var b19comp = GetB19();
            var curval = b19comp.floors.Get();
            b19comp.floors.SetAndSave(!curval);
            b19comp.MakeItSo();
        }
        public void ToggleB19hvac()
        {
            var b19comp = GetB19();
            var curval = b19comp.hvac.Get();
            b19comp.hvac.SetAndSave(!curval);
            b19comp.MakeItSo();
        }
        public void ToggleB19osm()
        {
            var b19comp = GetB19();
            var curval = b19comp.osmbld.Get();
            curval = !curval;
            b19comp.ActuateOsmStatus(curval);
            b19comp.osmbld.SetAndSave(curval);
            //Debug.Log($"Togglingb19osm new val{curval}");
            b19comp.MakeItSo();
        }
        public void ToggleB19wil()
        {
            var b19comp = GetB19();
            var curval = b19comp.wilbld.Get();
            curval = !curval;
            b19comp.ActuateWilStatus(curval);
            b19comp.wilbld.SetAndSave(curval);
            //Debug.Log($"Togglingb19osm new val{curval}");
            b19comp.MakeItSo();
        }

        public void ToggleB19glassmode()
        {
            var b19comp = GetB19();
            var mat = b19comp.b19_materialMode.Get();
            B19Willow.B19_MaterialMode newmat;
            if (mat == B19Willow.B19_MaterialMode.glass)
            {
                newmat = B19Willow.B19_MaterialMode.materialed;
            }
            else
            {
                newmat = B19Willow.B19_MaterialMode.glass;
            }
            b19comp.b19_materialMode.SetAndSave(newmat);
            b19comp.glasswalls.SetAndSave(newmat == B19Willow.B19_MaterialMode.glass);
            b19comp.MakeItSo();
        }


        public B121Willow GetB121()
        {
            var bld121 = GetBuilding("Bld121", couldFail: true);
            if (bld121 == null)
            {
                //sman.LggError($"No Bld121 in scene"); // not all scenes even have B121
                return null;
            }
            var b121comp = bld121.GetComponent<B121Willow>();
            if (b121comp == null)
            {
                sman.LggError($"No B121 Component attached to Bld121 in scene");
                return null;
            }
            return b121comp;
        }

        public void ToggleB19glassmodeExtra()
        {
            var b19comp = GetB19();
            var mat = b19comp.b19_materialMode.Get();
            B19Willow.B19_MaterialMode newmat;
            if (mat == B19Willow.B19_MaterialMode.glass)
            {
                newmat = B19Willow.B19_MaterialMode.materialed;
            }
            else
            {
                newmat = B19Willow.B19_MaterialMode.glass;
            }
            b19comp.b19_materialMode.SetAndSave(newmat);
            b19comp.glasswalls.SetAndSave(newmat == B19Willow.B19_MaterialMode.glass);
            b19comp.MakeItSo();
        }


        public void ToggleB121glassmode()
        {
            var b121comp = GetB121();
            var mat = b121comp.b121_materialMode.Get();
            B121Willow.B121_MaterialMode newmat;
            if (mat == B121Willow.B121_MaterialMode.glasswalls)
            {
                newmat = B121Willow.B121_MaterialMode.materialed;
            }
            else
            {
                newmat = B121Willow.B121_MaterialMode.glasswalls;
            }
            b121comp.b121_materialMode.SetAndSave(newmat);
            b121comp.glasswalls.SetAndSave(newmat == B121Willow.B121_MaterialMode.glasswalls);
            b121comp.ActuateMaterialMode();
        }

        public void ToggleB121hvac()
        {
            var b121comp = GetB121();
            b121comp.ToggleHvac();
        }
        public void ToggleB121lighting()
        {
            var b121comp = GetB121();
            b121comp.ToggleLighting();
        }

        public void ToggleB121plumbing()
        {
            var b121comp = GetB121();
            b121comp.TogglePlumbing();
        }

        public void ShowBld121OsmButton()
        {
            var b121comp = GetB121();
            b121comp.ToggleOsm();
        }

        public void ShowBld121WilButton()
        {
            var b121comp = GetB121();
            b121comp.ToggleWil();
        }


        public BldPolyGen bpg = null;

        public void ModelBuild()
        {
            nBuildings = 0;
            nSkippedBuildingsWithoutOsmPoints = 0;
            nRooms = 0;
            nPeople = 0;
            nVehicles = 0;
            Debug.Log($"BuildingMan.SetScene {sman.curscene}");

            var doosmblds = osmblds.Get();
            //Debug.Log($"doosmblds:{doosmblds} osmloadspec{osmloadspec}");
            if (doosmblds)
            {
                var pgvd = new PolyGenVekMapDel(sman.mpman.GetHeightVector3);
                bpg = new BldPolyGen();
                var llm = sman.mpman.GetLatLongMap();
                var (waysdflst, linksdflist, nodesdflist) = sman.dfman.GetSdfs();
                var osmbs = bpg.GetBuildspecsInRegion(waysdflst, linksdflist, nodesdflist, llm:llm,pgvd:pgvd);
                //var osmbs = bpg.GenBuildingsInRegion(osmroot, waysdflst, linksdflist, nodesdflist, pgvd: pgvd, llm: llm);
                bldspecs.AddRange(osmbs);
            }

            switch (sman.curscene)
            {
                case SceneSelE.MsftRedwest:
                case SceneSelE.MsftCoreCampus:
                case SceneSelE.MsftB33focused:
                case SceneSelE.MsftB19focused:
                case SceneSelE.MsftB121focused:
                    scene_padspecs = Building.MsftDronePadspec;
                    MakeBuildings("Bld");
                    break;
                case SceneSelE.MsftDublin:
                    MakeBuildings("Dub");
                    break;
                case SceneSelE.Eb12small:
                case SceneSelE.Eb12:
                    scene_padspecs = Building.Eb12DronePadspec;
                    MakeBuildings("Eb");
                    break;
                case SceneSelE.TeneriffeMtn:
                    MakeBuildings("MtTen");
                    break;
                case SceneSelE.MsftSmall:
                default:
                    MakeBuildings("");
                    break;
                case SceneSelE.None:
                    // do nothing
                    break;
            }
        }
        Dictionary<string, int> floordict = new Dictionary<string, int>()
        {
            { "f00",0 },
            { "f01",0 },
            { "f02",1 },
            { "f03",2 },
            { "f04",3 },
            { "f05",4 },
            { "f06",5 },
            { "f07",6 },
            { "f08",7 },
            { "f09",8 },
        };
        public void UpdateFloorHeights()
        {
            var sw = new Aiskwk.Map.StopWatch();
            foreach(var bldname in bldnames)
            {
                var bld = GetBuilding(bldname);
                bld.UpdateFloorHeightArray();
            }

            var grc = sman.lcman.GetGraphCtrl();
            var nnlst = grc.nodenamelist;
            var nnodes = nnlst.Count;
            var updnodes = 0;
            var bldcache = new Dictionary<string, Building>();
            var bbadnamedict = new Dictionary<string, bool>();
            foreach (var nname in nnlst)
            {
                var node = grc.GetNode(nname);
                var nnamear = nname.Split('-');
                if (nnamear.Length>2)
                {
                    var bname = nnamear[0];
                    var fname = nnamear[1];
                    Building bd;
                    if (bldcache.ContainsKey(bname))
                    {
                        bd = bldcache[bname];
                    }
                    else
                    {
                        bd = sman.bdman.GetBuilding(bname, couldFail: true);
                        if (bd == null)
                        {
                            bd = sman.bdman.GetBuildingFromAlias(bname, couldFail: true);
                        }
                        if (bd != null)
                        {
                            bldcache[bname] = bd;
                        }
                        else
                        {
                            bbadnamedict[bname] = true;
                        }
                    }
                    if (bd != null)
                    {
                        //if (bd.name == "Bld121" && fname=="f01")
                        //{
                        //    Debug.Log($"here is {bd.name} {fname}");
                        //}
                        if (floordict.ContainsKey(fname))
                        {
                            var iflr = floordict[fname];
                            var h = bd.GetZeroBasedFloorAltitude(iflr);
                            var x = node.pt.x;
                            var z = node.pt.z;
                            //var y = sman.lcman.GetHeight(x,z);
                            var pt = new Vector3(x, h, z);
                            node.pt = pt;
                            //var nmsg = $"{nname} bld:{bname}  flr:{fname}  node.pt:{pt}";
                            //sman.Lgg(nmsg, "orange");
                            updnodes++;
                        }
                   }
                }
            }
            sw.Stop();
            var nbadnames = bbadnamedict.Count;
            var msg = $"nodes: {nnodes}  blds:{bldcache.Count} nbadnames:{nbadnames} updated floor nodes:{updnodes} secs:{sw.ElapSecs()}";
            //foreach(var bn in bbadnamedict.Keys)
            //{
            //    sman.Lgg($"   {bn}","lilac");
            //}
            //sman.Lgg(msg, "pink");
        }

        public void ModelBuildPostLinkCloud()
        {
            UpdateFloorHeights();
            ReinitDests();
            AddRoomsToBuildings();
            PopulateBuildings();
            AddExtraPeople();
            dronebldnames = new List<string>();
            foreach (var bld in bldmasterlist.Values)
            {
                var npads = bld.GetPads().Count;
                if (npads > 0)
                {
                    dronebldnames.Add(bld.name);
                    dronebldnames.Sort();
                }
            }
            UpdateBldStats();
        }
        public void UpdateBldStats()
        {
            nBuildings = bldmasterlist.Count;
            nDroneBuildings = dronebldnames.Count;
            nRooms = roomlookup.Count;
            nPads = padlookup.Count;
            nPeople = sman.psman.GetPersonCount();
            nPeopleInRooms = 0;
            foreach( var broom in roomlookup.Values )
            {
                nPeopleInRooms += broom.GetAllPeopleInRoom().Count;
            }
            nVehicles = sman.veman.GetVehicleCount();
            nDrones = 0;
            foreach (var pad in padlookup.Values)
            {
                nDronesOnPads += pad.GetAllPeopleInRoom().Count;
            }
        }
        public void MakeBuildings(string predeffiltername)
        {
            if (predeffiltername != "")
            {
                var bldlst = Building.GetPredefinedBuildingNames(predeffiltername);
                bldlst.ForEach(mbname => MakeBuilding(mbname));
            }
            bldspecs.ForEach(osmbs => MakeOsmBuilding(osmbs));
        }
        public string presetEvacBldName = "";
        public void EvacPresetBld()
        {
            var bld = GetBuilding(presetEvacBldName);
            if (!bld)
            {
                Debug.Log("Bad default evac bld set:"+presetEvacBldName);
                return;
            }
            bld.SetAlarmState(newstate:true,justone:false);
        }
        public void UnevacPresetBld()
        {
            var zones = sman.znman.GetZones(presetEvacBldName);
            if (zones.Count==0)
            {
                sman.LggError("No evac zones found for:" + presetEvacBldName);
                return;
            }
            foreach (var z in zones)
            {
                z.SetAlarmState(newstate:true, justone:false,startstream:false);
            }
        }
        public void AddExtraPeople()
        {
            var newscene = sman.curscene;
            switch (newscene)
            {
                case SceneSelE.MsftRedwest:
                case SceneSelE.MsftCoreCampus:
                case SceneSelE.MsftB33focused:
                case SceneSelE.MsftB19focused:
                case SceneSelE.MsftB121focused:
                    presetEvacBldName = "Bld19";
                    if (newscene == SceneSelE.MsftRedwest)
                    {
                        presetEvacBldName = "BldRWB";
                    }
                    //var bld = GetBuilding("BldRWB");
                    //bld.AddRedwestBAlarms();
                    sman.lcman.grctrl.AddLateLink("rwb-f03-cv0-e", "bRWB-os1-o02", GraphAlgos.LinkUse.walkway, "walkway link for garage-RedwestB - 1");
                    sman.lcman.grctrl.AddLateLink("rwb-f03-cv0-s", "bRWB-os2-o01", GraphAlgos.LinkUse.walkway, "walkway link for garage-RedwestB - 2");
                    sman.lcman.grctrl.AddLateLink("rwb-f03-cv3-s", "bRWB-os2-o04", GraphAlgos.LinkUse.walkway, "walkway link for garage-RedwestB -3");
                    sman.lcman.grctrl.AddLateLink("rwb-f03-cv3-e", "bRWB-os3-o02", GraphAlgos.LinkUse.walkway, "walkway link for garage-RedwestB- 4");
                    //                    if (sman.fastMode)
                    //                    {
                    sman.lcman.grctrl.AddLateLink("rwb-f03-rm3342", "g_RWB_eee-dt-wpsdoor004", GraphAlgos.LinkUse.walkway, "walkway link for garage-RedwestB- 5");
                    //                    }
                    sman.lcman.grctrl.AddLateLink("dw-RWB-c18", "g_RWB_eee-dt-dps013", GraphAlgos.LinkUse.driveway, "driveway link for garage at RedwestB - 1");
                    sman.lcman.grctrl.AddLateLink("dw-RWB-c28", "g_RWB_eee-dt-dps006", GraphAlgos.LinkUse.driveway, "driveway link for garage at RedwestB - 2");
                    sman.lcman.grctrl.AddLateLink("dw-RWB-c28", "g_RWB_eee-dt-dps007", GraphAlgos.LinkUse.driveway, "driveway link for garage at RedwestB - 3");
                    sman.lcman.grctrl.AddLateLink("dw-RWB-c38", "g_RWB_eee-dt-dps001", GraphAlgos.LinkUse.driveway, "driveway link for garage at RedwestB - 4");
                    sman.psman.AddPersonToBuildingAtNode(PersonMan.GenderE.male, "b19-f01-lobby", "b19-f01-cp0b1", "Arnie Schwarzwald", "Businessman004",
                                                         PersonMan.empStatusE.Security, "IdleUnarmed", false, 180, hasHololens: true, hasCamera: true, flagged: true);
                    sman.psman.AddPersonToBuildingAtNode(PersonMan.GenderE.female, "b19-f01-lobby", "b19-f01-sp1003", "Audrey Hepburn", "Girl005",
                                                         PersonMan.empStatusE.FullTimeEmp, "Typing", false, 45, hasHololens: false, hasCamera: false, flagged: true);
                    sman.psman.AddPersonToBuildingAtNode(PersonMan.GenderE.male, "b19-f01-lobby", "b19-f01-sp1030", "Clark Gabel", "Man004",
                                                         PersonMan.empStatusE.Contractor, "Typing", false, -48f, hasHololens: false, hasCamera: false, flagged: true);
                    sman.psman.AddPersonToBuildingAtNode(PersonMan.GenderE.male, "b19-f01-lobby", "b19-f01-sp1029", "Anthony Hopkins", "Man010",
                                                         PersonMan.empStatusE.FullTimeEmp, "Typing", false, 40f, hasHololens: false, hasCamera: false, flagged: true);




                    break;
                case SceneSelE.MsftDublin:
                    break;
                case SceneSelE.Eb12small:
                case SceneSelE.Eb12:
                    presetEvacBldName = "Eb0814";
                    sman.psman.AddPersonToBuildingAtNode(PersonMan.GenderE.male, "eb0814-f01-12-lob", "eb12-oso1a", "Arnie Schwarzwald", "Businessman004",
                                                         PersonMan.empStatusE.Security, "IdleUnarmed", false, 0, hasHololens: true, hasCamera: true, flagged: true);
                    break;
                default:
                case SceneSelE.None:
                    break;
                case SceneSelE.TeneriffeMtn:
                    //"m|Jane Doe Found|Girl03|unknown|nothing",

                    sman.psman.AddPersonToBuildingAtNode(PersonMan.GenderE.female, "found-spot", "found-spot-dog", "Connie Haines Found Dog", "shepherd",
                                                         PersonMan.empStatusE.Unknown, "IdleUnarmed", false, 0, hasHololens: false, hasCamera: true, flagged: true);
                    sman.psman.AddPersonToBuildingAtNode(PersonMan.GenderE.female, "found-spot", "found-spot", "Connie Haines Found", "Girl010",
                                                         PersonMan.empStatusE.Unknown, "IdleUnarmed", false, 0, hasHololens: false, hasCamera: true, flagged: true);
                    sman.psman.AddPersonToBuildingAtNode(PersonMan.GenderE.female, "lastseen-spot", "lastseen-spot-dog", "Connie Haines Lastseen Dog", "shepherd",
                                                         PersonMan.empStatusE.Unknown, "IdleUnarmed", false, 0, hasHololens: false, hasCamera: true, flagged: true);
                    sman.psman.AddPersonToBuildingAtNode(PersonMan.GenderE.female, "lastseen-spot", "lastseen-spot", "Connie Haines Lastseen", "Girl010",
                                                         PersonMan.empStatusE.Unknown, "IdleUnarmed", false, 0, hasHololens: false, hasCamera: true, flagged: true);
                    break;
            }
        }

        public string GetRandomBldName(string notthisone="",string ranset="")
        {
            var choosen = "nope!!!";
            var ntries = 0;
            var maxtries = 10;
            while (ntries==0 || (choosen==notthisone && ntries<maxtries))
            {
                var diceroll = GraphAlgos.GraphUtil.GetRanInt(wtdbldnames.Count,ranset);
                choosen = wtdbldnames[diceroll];
                ntries++;
            }
            //Debug.Log("Choose " + choosen + " after " + ntries + " tries");
            return choosen;
        }
        public string GetRandomDroneBldName(string notthisone = "", string ranset = "")
        {
            var choosen = "nope!!!";
            var ntries = 0;
            var maxtries = 10;
            while (ntries == 0 || (choosen == notthisone && ntries < maxtries))
            {
                var diceroll = GraphAlgos.GraphUtil.GetRanInt(dronebldnames.Count, ranset);
                choosen = dronebldnames[diceroll];
                ntries++;
            }
            //Debug.Log("Choose " + choosen + " after " + ntries + " tries");
            return choosen;
        }
        public Building GetRandomBld(string notthisone = "",string ranset="")
        {
            var bname = GetRandomBldName(notthisone,ranset);
            return GetBuilding(bname);
        }
        public void AddRoomsToBuildings()
        {
            var bldlst = new List<Building>(bldmasterlist.Values);
            //bldlst.ForEach(bld => bld.DefineBuildingConstants());
            bldlst.ForEach(bld => bld.AddRoomsToBuilding());
        }
        public void PopulateBuildings()
        {
            var bldlst = new List<Building>(bldmasterlist.Values);
            bldlst.ForEach(bld => bld.PopulateBuilding());
        }
        public void MakeOsmBuilding(OsmBldSpec bldspec)
        {
            if (bldspec.GetOutline().Count<3)
            {
                nSkippedBuildingsWithoutOsmPoints += 1;
                return;
            }
            var mbname = bldspec.osmname;
            var bld = GetBsBld(bldspec);
            if (bld == null)
            {
                // we need to make a new one if this wasn't reserved from a fixed building
                var bgo = new GameObject(mbname);
                bgo.transform.position = Vector3.zero;
                bgo.transform.parent = this.transform;
                bld = bgo.AddComponent<Building>();
                RegisterBsBld(bldspec, bld);
            }
            if (bldspec.shortname == "Bld34")
            {
                Debug.Log("Bld34");
            }
            //sman.Lgg($"MakeOsmBuilding name:{name} bs.shortname:{bldspec.shortname} bs.osmname:{bldspec.osmname}","lilac");
            bld.AddOsmBldDetails(this, bldspec);
            AddBuildingToCollection(bld,mightAlreadyExist:true);

            //bld.llm = bgo.AddComponent<LatLongMap>(); // todo uncomment
            //var origin = $"BuildingMan.MakeOsmBuilding(\"{mbname}\")";
            //bld.llm = new LatLongMap(origin); // todo uncomment
            //bld.llm.AddLlmDetails();
            //sman.jnman.AddViewerJourneyNodes(bld.destnodes, prefix: $"{mbname}/");
        }
        public void MakeBuilding(string mbname)
        {
            var bgo = new GameObject(mbname);
            bgo.transform.position = Vector3.zero;
            bgo.transform.parent = this.transform;
            var bld = bgo.AddComponent<Building>();
            bld.AddBldDetails(this);
            AddBuildingToCollection(bld);

            //bld.llm = bgo.AddComponent<LatLongMap>(); // todo uncomment
            //var origin = $"BuildingMan.MakeBuilding(\"{mbname}\")";
            //bld.llm = new LatLongMap(origin); // todo uncomment
            //bld.llm.AddLlmDetails();
            sman.jnman.AddViewerJourneyNodes(bld.destnodes,prefix:$"{mbname}/");
        }
        public void DelBuildings()
        {
            //Debug.Log("DelBuildings called");
            if (bldmasterlist != null)
            {
                var namelist = new List<string>(bldmasterlist.Keys);
                namelist.ForEach(name => DelBuilding(name));
            }
            bldmasterlist = null;
            if (bldspecs != null)
            {
                bldspecs.ForEach(bs => Destroy(bs.bgo));
            }
            bldspecs = null;

            bldmasterlist = null;
            bldnames = null;
            wtdbldnames = null;
            dronebldnames = null;

            noderoomlookup = null;
            roomlookup = null;
            nodepadlookup = null;
            padlookup = null;
            bsDict = null;
            bsRevDict = null;
        }
        public void DelBuilding(string name)
        {
            //Debug.Log($"Deleting building {name} nbld:{bldlookup.Count}");
            //var go = GameObject.Find(name);
            if (!bldmasterlist.ContainsKey(name)) return;

            var bld = bldmasterlist[name];
            bld.Empty(); // destroys game object as well
            bldmasterlist.Remove(name);
            UpdateBldStats();
            Destroy(bld.gameObject);
            //Debug.Log($"After deleting building {name} nbld:{bldlookup.Count}");
        }
        public Building GetBuilding(string bname,bool couldFail=false)
        {
            if (bname.Contains("/"))
            {
                var sar = bname.Split('/');
                bname = sar[0];
            }
            if (!bldmasterlist.ContainsKey(bname))
            {
                if (!couldFail)
                {
                    sman.LggError("Bad building lookup:" + bname);
                }
                return null;
            }
            return bldmasterlist[bname];
        }
        public Building GetBuildingFromAlias(string bname,bool couldFail=false)
        {
            if (!bldalias.ContainsKey(bname))
            {
                if (!couldFail)
                {
                    sman.LggError("Bad building lookup:" + bname);
                }
                return null;
            }
            return bldalias[bname];
        }

        public void AddBuildingAlias(string alias,Building building)
        {
            if (bldmasterlist.ContainsKey(alias))
            {
                sman.LggError("AddBUildingAlisas - Tried to add duplicate alias to bldmasterlist:" + building.name); 
                return;
            }
            if (bldalias.ContainsKey(alias))
            {
                sman.LggError("AddBUildingAlisas - Tried to add duplicate alias to bldalias:" + building.name); 
                return;
            }
            bldalias[alias] = building;
        }
        public void AddBuildingToCollection(Building building,bool mightAlreadyExist=false)
        {
            if (bldmasterlist.ContainsKey(building.name))
            {
                if (!mightAlreadyExist)
                {
                    sman.LggError("AddBuildingToCollection - tried to add duplicate building:" + building.name); // this can happen with osmbuildings
                }
                return;
            }
            var ndests = building.GetRoomListFromNodes().Count;
            if (ndests > 0)
            {
                bldnames.Add(building.name);
                bldnames.Sort();
                for (int i=0; i < building.selectionweight; i++ )
                {
                    wtdbldnames.Add(building.name);// duplicate name selectionweight times (not vey elegant)
                }
                wtdbldnames.Sort();
            }
            bldmasterlist[building.name] = building;
            //Debug.Log("Added bld " + building.name);
        }

        public Building FindBuildingWithHitobject(string hitname)
        {
            sman.Lgg($"FindBuildingWithHitObject: {hitname}");
            var bnar = hitname.Split('/');
            foreach (var bn in bnar)
            {
                if (bldmasterlist.ContainsKey(bn))
                {
                    var bld = GetBuilding(bn);
                    return bld;
                }
            }
            sman.Lgg($"FindBuildingWithHitobject cound not find {hitname} in in building master list", "orange");
            return null;
        }

        public void SetSelectedBuilding(string hitname)
        {
            var bld = FindBuildingWithHitobject(hitname);
            if (bld != null)
            {
                sman.Lgg($"selectedbldname.SetAndSave {bld.name}","amber");
                selectedbldname.SetAndSave(bld.name);
            }
        }

        public List<string> GetBuildingsWithDestinations()
        {
            return bldnames;
        }
        public int GetDestinationBuildingCount()
        {
            return bldnames.Count;
        }
        public List<string> GetAllBuildings()
        {
            var rv = new List<string>(bldmasterlist.Keys);
            return rv;
        }
        public int GetAllBuildingsCount()
        {
            var rv = bldmasterlist.Count;
            return rv;
        }
        public int GetBroomCount()
        {
            if (roomlookup == null) return 0;
            return roomlookup.Count;
        }
        public void ReinitDests()
        {
            foreach( var bld in bldmasterlist.Values)
            {
                bld.ReinitDests();
            }
        }
        public void RegisterRoom(string roomname,BldRoom bldRoom)
        {
            if (roomlookup.ContainsKey(roomname))
            {
                sman.LggError($"In BuildingMan - Room being registered twice:{roomname}");
            }
            roomlookup[roomname] = bldRoom;
        }
        public void UnRegisterRoom(string roomname)
        {
            if (!roomlookup.ContainsKey(roomname))
            {
                sman.LggError($"In BuildingMan - Room being unregistered that was not registered:{roomname}");
            }
            roomlookup.Remove(roomname);
        }
        public bool IsRoom(string nodename)
        {
            var rv = roomlookup.ContainsKey(nodename);
            return rv;
        }
        public bool IsPad(string nodename)
        {
            var rv = padlookup.ContainsKey(nodename);
            return rv;
        }
        public bool IsRoomAssociatedNode(string nodename)
        {
            return noderoomlookup.ContainsKey(nodename);
        }
        public void RegisterPad(string padname, BldDronePad pad)
        {
            if (padlookup.ContainsKey(padname))
            {
                sman.LggError($"In BuildingMan - Pad being registered twice:{padname}");
            }
            padlookup[padname] = pad;
        }
        public void UnRegisterPad(string padname)
        {
            if (!padlookup.ContainsKey(padname))
            {
                sman.LggError($"In BuildingMan - Pad being unregistered that was not registered:{padname}");
            }
            padlookup.Remove(padname);
        }

        public bool IsPadAssociatedNode(string nodename)
        {
            return nodepadlookup.ContainsKey(nodename);
        }
        public bool IsRoomlike(string nodename)
        {
            return IsRoom(nodename) || IsRoomAssociatedNode(nodename) || IsPad(nodename) || IsPadAssociatedNode(nodename);
        }
        public bool IsPadlike(string nodename)
        {
            return IsPad(nodename) || IsPadAssociatedNode(nodename);
        }
        public void OccupyNode(string destnode, Person person)
        {
            var broom = this.GetAssociatedRoom(destnode);
            if (broom != null)
            {
                person.AssignCurLocation(broom.bld.name, broom.name, destnode);
                broom.Occupy(person);
            }
            else
            {
                var bpad = this.GetAssociatedPad(destnode);
                if (bpad!=null)
                {
                    person.AssignCurLocation(bpad.bld.name, bpad.name, destnode);
                    bpad.Occupy(person);
                }
            }

        }
        public void ForceFrameAllRooms(bool doit)
        {
            foreach(var room in roomlookup.Values)
            {
                if (doit)
                {
                    room.initEnableFrames = room.enableFrames;
                    room.enableFrames = true;
                }
                else
                {
                    room.enableFrames = room.initEnableFrames;
                }
            }
        }
        public void VacateNode(string vacnode, Person person)
        {
            var broom = GetAssociatedRoom(vacnode);
            if (!broom)
            {
                var bpad = GetAssociatedPad(vacnode);
                if (!bpad)
                {
                    sman.LggWarning($"BuildingMan cannot find vacnode as room or pad - can not vacate slot:{vacnode}");
                    return;
                }
                bpad.Vacate(person);
                return;
            }
            broom.Vacate(person);
            //person.AssignCurLocation(vacnode, vacnode);
        }

        public void DeleteGos()
        {
            foreach (var bname in bldmasterlist.Keys)
            {
                bldmasterlist[bname].DeleteGos();
            }
        }
        public void CreateGos()
        {
            foreach (var bname in bldmasterlist.Keys)
            {
                bldmasterlist[bname].CreateGos();
            }
        }
        public void RefreshGos()
        {
            DeleteGos();
            CreateGos();
        }
    }
}