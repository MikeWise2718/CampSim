using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UxUtils;
using Aiskwk.Map;

namespace CampusSimulator
{

    public class BuildingMan : MonoBehaviour
    {

        Dictionary<string, Building> bldlookup = new Dictionary<string, Building>();
        List<string> bldnames = new List<string>(); // maintain a sorted list of buildings with destinations
        List<string> wtdbldnames = new List<string>(); // maintain a sorted weighted list of buildings with destinations
        Dictionary<string, BldRoom> noderoomlookup = new Dictionary<string, BldRoom>(); // a home for fixed nodes that need to know their building
        Dictionary<string, BldRoom> roomlookup = new Dictionary<string, BldRoom>();
       

        public SceneMan sman = null;

        public int nBuildings;
        public int nRooms;
        public int nPeople;
        public int nPeopleInRooms;

        public bool showPersRects;

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
            else if (IsAssociatedNode(nodename))
            {
                return noderoomlookup[nodename];
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
                    Debug.Log("Bad roomname lookup " + roomname);
                }
                return null;
            }
            return roomlookup[roomname];
        }
        public List<BldRoom> GetBrooms()
        {
            return new List<BldRoom>(roomlookup.Values);
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

        System.Random ranman = new System.Random();

        public void SetScene(SceneSelE newregion)
        {
            if (bldlookup.Count > 0)
            {
                DelBuildings();
            }
            switch (newregion)
            {
                case SceneSelE.MsftRedwest:
                case SceneSelE.MsftCoreCampus:
                case SceneSelE.MsftB19focused:
                    MakeBuildings("Bld");
                    break;
                case SceneSelE.MsftDublin:
                    MakeBuildings("Dub");
                    break;
                case SceneSelE.Eb12:
                    MakeBuildings("Eb");
                    break;
                default:
                case SceneSelE.None:
                    // DelBuildings called above already
                    break;
            }
        }
        public void UpdateBldStats()
        {
            nBuildings = bldlookup.Count;
            nRooms = roomlookup.Count;
            nPeople = sman.psman.GetPersonCount();
            nPeopleInRooms = 0;
            foreach( var broom in roomlookup.Values )
            {
                nPeopleInRooms += broom.GetAllPeopleInRoom().Count;
            }
        }
        public void MakeBuildings(string filtername)
        {
            var bldlst = Building.GetPredefinedBuildingNames(filtername);
            bldlst.ForEach(item => MakeBuilding(item));
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
                Debug.Log("No evac zones found for:" + presetEvacBldName);
                return;
            }
            foreach (var z in zones)
            {
                z.SetAlarmState(newstate:true, justone:false,startstream:false);
            }
        }
        public void SetScenePostLinkCloud(SceneSelE newregion)
        {
            ReinitDests();
            AddRoomsToBuildings();
            PopulateBuildings();
            switch (newregion)
            {
                case SceneSelE.MsftRedwest:
                case SceneSelE.MsftCoreCampus:
                case SceneSelE.MsftB19focused:
                    presetEvacBldName = "Bld19";
                    if (newregion == SceneSelE.MsftRedwest)
                    {
                        presetEvacBldName = "BldRWB";
                    }
                    //var bld = GetBuilding("BldRWB");
                    //bld.AddRedwestBAlarms();
                    sman.linkcloudman.grctrl.AddLateLink("rwb-f03-cv0-e", "bRWB-os1-o02",GraphAlgos.LinkUse.walkway);
                    sman.linkcloudman.grctrl.AddLateLink("rwb-f03-cv0-s", "bRWB-os2-o01", GraphAlgos.LinkUse.walkway);
                    sman.linkcloudman.grctrl.AddLateLink("rwb-f03-cv3-s", "bRWB-os2-o04", GraphAlgos.LinkUse.walkway);
                    sman.linkcloudman.grctrl.AddLateLink("rwb-f03-cv3-e", "bRWB-os3-o02", GraphAlgos.LinkUse.walkway);
//                    if (sman.fastMode)
//                    {
                        sman.linkcloudman.grctrl.AddLateLink("rwb-f03-rm3342", "g_RWB_eee-dt-wpsdoor004", GraphAlgos.LinkUse.walkway);
//                    }
                    sman.linkcloudman.grctrl.AddLateLink("dw-RWB-c18", "g_RWB_eee-dt-dps013", GraphAlgos.LinkUse.driveway);
                    sman.linkcloudman.grctrl.AddLateLink("dw-RWB-c28", "g_RWB_eee-dt-dps006", GraphAlgos.LinkUse.driveway);
                    sman.linkcloudman.grctrl.AddLateLink("dw-RWB-c28", "g_RWB_eee-dt-dps007", GraphAlgos.LinkUse.driveway);
                    sman.linkcloudman.grctrl.AddLateLink("dw-RWB-c38", "g_RWB_eee-dt-dps001",GraphAlgos.LinkUse.driveway);
                    sman.psman.AddPersonToBuildingAtNode(PersonMan.GenderE.male,"b19-f01-lobby", "b19-f01-cp0b1", "Arnie Schwarzwald", "Businessman004",
                                                         PersonMan.empStatusE.Security, "IdleUnarmed", false,180,hasHololens:true,hasCamera:true,flagged:true);
                    sman.psman.AddPersonToBuildingAtNode(PersonMan.GenderE.female, "b19-f01-lobby", "b19-f01-sp1003", "Audrey Hepburn", "Girl005",
                                                         PersonMan.empStatusE.FullTimeEmp, "Typing", false, 45, hasHololens: false, hasCamera: false, flagged: true);
                    sman.psman.AddPersonToBuildingAtNode(PersonMan.GenderE.male, "b19-f01-lobby", "b19-f01-sp1030", "Clark Gabel", "Man004",
                                                         PersonMan.empStatusE.Contractor, "Typing", false, -48f, hasHololens: false, hasCamera: false, flagged: true);
                    sman.psman.AddPersonToBuildingAtNode(PersonMan.GenderE.male, "b19-f01-lobby", "b19-f01-sp1029", "Owen Wilson", "Man010",
                                                         PersonMan.empStatusE.FullTimeEmp, "Typing", false, 40f, hasHololens: false, hasCamera: false, flagged: true);
                    //sman.psman.b19idchange("Dave Agarwal","Visitor",flagged:true);
                    //sman.psman.b19idchange("Liam Lee", "Visitor", flagged: true);
                    //sman.psman.b19idchange("Aditi Wilcox", "Visitor", flagged: true);
                    //sman.psman.b19idchange("Adidi Blanc", "Visitor", flagged: true);
                    //sman.psman.b19idchange("Gabriel Suzuki", "Contractor", flagged: true);
                    //sman.psman.b19idchange("Ava Wilson", "Unknown", flagged: true);
                    //sman.psman.b19idchange("Qi Brown", "Contractor", flagged: true);


                    break;
                case SceneSelE.MsftDublin:
                    break;
                case SceneSelE.Eb12:
                    presetEvacBldName = "Eb12-22";
                    sman.psman.AddPersonToBuildingAtNode(PersonMan.GenderE.male, "eb12-16-lob", "eb12-oso1a", "Arnie Schwarzwald", "Businessman004",
                                                         PersonMan.empStatusE.Security, "IdleUnarmed", false, 0, hasHololens:true, hasCamera: true, flagged: true);
                    break;
                default:
                case SceneSelE.None:
                    break;
            }
            UpdateBldStats();
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
        public Building GetRandomBld(string notthisone = "",string ranset="")
        {
            var bname = GetRandomBldName(notthisone,ranset);
            return GetBuilding(bname);
        }
        public void AddRoomsToBuildings()
        {
            var bldlst = new List<Building>(bldlookup.Values);
            bldlst.ForEach(bld => bld.AddRoomsToBuilding());
        }
        public void PopulateBuildings()
        {
            var bldlst = new List<Building>(bldlookup.Values);
            bldlst.ForEach(bld => bld.PopulateBuilding());
        }

        public void MakeBuilding(string name)
        {
            var bgo = new GameObject(name);
            bgo.transform.position = Vector3.zero;
            bgo.transform.parent = this.transform;
            var bld = bgo.AddComponent<Building>();
            bld.AddBldDetails(this);
            AddBuildingToCollection(bld); /// has to be afterwards because of the sorted names for journeys
            bld.llm = bgo.AddComponent<LatLongMap>(); // todo uncomment
            //bld.llm.AddLlmDetails();
            UpdateBldStats();
        }
        public void DelBuildings()
        {
            Debug.Log("DelBuildings called");
            var namelist = new List<string>(bldlookup.Keys);
            namelist.ForEach(name => DelBuilding(name));
        }
        public void DelBuilding(string name)
        {
            //Debug.Log($"Deleting building {name} nbld:{bldlookup.Count}");
            //var go = GameObject.Find(name);

            var bld = bldlookup[name];
            bld.Empty(); // destroys game object as well
            bldlookup.Remove(name);
            UpdateBldStats();
            Destroy(bld.gameObject);
            //Debug.Log($"After deleting building {name} nbld:{bldlookup.Count}");
        }
        public Building GetBuilding(string name,bool couldFail=false)
        {
            if (!bldlookup.ContainsKey(name))
            {
                if (!couldFail)
                {
                    Debug.Log("Bad building lookup:" + name);
                }
                return null;
            }
            return bldlookup[name];
        }



        public void AddBuildingToCollection(Building building)
        {
            if (bldlookup.ContainsKey(building.name))
            {
                Debug.Log("Tried to add duplicate building:" + building.name);
                return;
            }
            var ndests = building.GetRoomListFromNodes().Count;
            if (ndests > 0)
            {
                bldnames.Add(building.name);
                bldnames.Sort();
                for (int i=0; i < building.selectionweight; i++ )
                {
                    wtdbldnames.Add(building.name);
                }
                wtdbldnames.Sort();
            }
            bldlookup[building.name] = building;
            //Debug.Log("Added bld " + building.name);
        }

        public List<string> GetBuildingList()
        {
            return bldnames;
        }
        public int GetBuildingCount()
        {
            return bldnames.Count;
        }
        public int GetBroomCount()
        {
            return roomlookup.Count;
        }
        public void ReinitDests()
        {
            foreach( var bld in bldlookup.Values)
            {
                bld.ReinitDests();
            }
        }
        public void RegisterRoom(string roomname,BldRoom bldRoom)
        {
            if (roomlookup.ContainsKey(roomname))
            {
                Debug.LogError("In BuildingMan - Room being registered twice:" + roomname);
            }
            roomlookup[roomname] = bldRoom;
        }
        public void UnRegisterRoom(string roomname)
        {
            if (!roomlookup.ContainsKey(roomname))
            {
                Debug.LogError("In BuildingMan - Room being unregistered that was not registered:" + roomname);
            }
            roomlookup.Remove(roomname);
        }
        public bool IsRoom(string nodename)
        {
            return roomlookup.ContainsKey(nodename);
        }
        public bool IsAssociatedNode(string nodename)
        {
            return noderoomlookup.ContainsKey(nodename);
        }
        public bool IsRoomlike(string nodename)
        {
            return IsRoom(nodename) || IsAssociatedNode(nodename);
        }
        public void OccupyNode(string destnode, Person person)
        {
            var broom = this.GetAssociatedRoom(destnode);
            person.AssignCurLocation(broom.bld.name, broom.name, destnode);
            broom.Occupy(person);
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
                Debug.Log("Can't vacate slot:" + vacnode);
            }
            broom.Vacate(person);
            //person.AssignCurLocation(vacnode, vacnode);
        }

        public void DeleteGos()
        {
            foreach (var bname in bldlookup.Keys)
            {
                bldlookup[bname].DeleteGos();
            }
        }
        public void CreateGos()
        {
            foreach (var bname in bldlookup.Keys)
            {
                bldlookup[bname].CreateGos();
            }
        }
        public void RefreshGos()
        {
            DeleteGos();
            CreateGos();
        }

        private void Awake()
        {
            sman = FindObjectOfType<SceneMan>();
        }

        // Use this for initialization
        void Start()
        {
            //treeMode = GetInitialTreeMode();
            treeMode.GetInitial();
            bldMode.GetInitial();
        }

        // Update is called once per frame
        void Update()
        {

        }



    }
}