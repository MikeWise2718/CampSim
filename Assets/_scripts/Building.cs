using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Aiskwk.Map;

namespace CampusSimulator
{
    public partial class Building : MonoBehaviour
    {
        public BuildingMan bm;
        public LinkCloudMan lc;

        public string maingaragename;
        //public string walkstartnode;
        //public string drivestartnode;
        public List<string> destnodes = new List<string>();
        public List<string> roomspecs = new List<string>();
        public List<string> bldpadspecs = new List<string>();
        public string shortname;
        public int selectionweight;
        public Dictionary<string,BldRoom> roomdict=new Dictionary<string, BldRoom>();
        public Dictionary<string, BldDronePad> paddict = new Dictionary<string, BldDronePad>();
        //public LatLongMap llm;
        public GameObject roomlistgo;
        public float defAngAlign = 0f;
        public int defPeoplePerRoom = 2;
        public float defPercentFull = 1.0f;
        public float defRoomArea = 10;
        public float journeyChoiceWeight = 1;
        public string osmnamestart = "";
        public int adhocLevels = 1;
        public float adhocHeight = 4;
        public Vector3 adhocCen = Vector3.zero;
        public double adhocLat = 0;
        public double adhocLng = 0;


        B121Willow b121comp = null;
        B19Willow b19comp = null;

        //System.Random ranman = new System.Random();
        public Person GetRandomFreeToTravelPerson(string ranset="")
        {
            var peeps = GetFreePeopleInRooms();
            if (peeps.Count == 0)  return null;
            var i = GraphAlgos.GraphUtil.GetRanInt(peeps.Count,ranset);
            return peeps[i];
        }

        public Person GetRandomFreeToTravelDrone(string ranset = "")
        {
            var dronepeeps = GetFreeDronesInRooms();
            if (dronepeeps.Count == 0) return null;
            var i = GraphAlgos.GraphUtil.GetRanInt(dronepeeps.Count, ranset);
            return dronepeeps[i];
        }

        public BldRoom GetFirstFreeRoom()
        {
            var brooms = GetRooms();
            foreach(var broom in brooms)
            {
                if (broom.HasFreeRoomSlots())
                {
                    return broom;
                }
            }
            return null;
        }
        public BldRoom GetRandomRoom(string ranset="")
        {
            var brooms = GetRooms();
            if (brooms.Count == 0)
            {
                return null;
            }
            var i = GraphAlgos.GraphUtil.GetRanInt(brooms.Count,ranset);
            return brooms[i];
        }
        public BldDronePad GetRandomPad(string ranset = "")
        {
            var pads = GetPads();
            if (pads.Count==0)
            {
                return null;
            }
            var i = GraphAlgos.GraphUtil.GetRanInt(pads.Count, ranset);
            return pads[i];
        }



        public string GetRandomDest(string ranset="")
        {
            var i = GraphAlgos.GraphUtil.GetRanInt(destnodes.Count,ranset:"jnygen");
            return destnodes[i];
        }
        public List<string> GetRoomListFromNodes()
        {
            return destnodes;
        }
        public BldRoom GetRoom(string roomname)
        {
            if (!HasRoom(roomname)) return null;
            return roomdict[roomname];
        }
        public bool HasRoom(string roomname)
        {
            return roomdict.ContainsKey(roomname);
        }
        public void ReinitDests()
        {
            var destnodelst = new List<string>();
            switch (name)
            {
                case "Bld43":
                    {
                        destnodelst = bm.sman.lcman.FindNodes("b43-f01-rm");
                        break;
                    }
                case "BldRWB":
                    {
                        destnodelst = bm.sman.lcman.FindNodes("rwb-f03-rm");
                        break;
                    }
                default:
                    break;
            }
            if (destnodelst.Count > 0)
            {
                //Debug.Log("Found " + destnodelst.Count + " dests for " + name);
                destnodes = destnodelst;// in ReinitDests
            }
        }
        public void EmptyRooms()
        {
            foreach(var roomname in roomdict.Keys)
            {
                bm.UnRegisterRoom(roomname);
                var br = roomdict[roomname];
                br.EmptyRoom();
                Destroy(br.gameObject);// now delete the room
            }
            roomdict = new Dictionary<string, BldRoom>();
            bm.UpdateBldStats();
        }
        public void Empty()
        {
            EmptyRooms();
            DeleteGos();
        }

        public void EvacN(int n)
        {
            if (n < 0) n = 999999;
            Debug.Log(name + " evac " + n);
            //bm.sman.jman.journeyMessages = true;
            bm.sman.jnman.BatchEvacJourneys(name,n);
        }
        public void SetAlarmState(bool newstate,bool justone)
        {
            var algotrans = transform.Find("Alarms");
            if (algotrans==null)
            {
                Debug.Log("Can't find alarms for building "+name);
                return;
            }
            var nalarm = algotrans.childCount;
            for(var i=0; i<nalarm; i++)
            {
                var ago = algotrans.GetChild(i);
                var alarm = ago.GetComponent<BldEvacAlarm>();
                if (alarm != null)
                {
                    alarm.SetState(newstate);
                }
            }
            if (newstate)
            {
                Debug.Log("Trying to add an evac journey for " + name+" LeftShift:"+ Input.GetKeyDown(KeyCode.LeftShift));
                var n = -1;
                if (justone)
                {
                    n = 1;
                }
                EvacN(n);
                //Debug.Log("Did it");
            }
        }


        public int GetBuildingPopulationCapacity()
        {
            int ncap = 0;
            var roomlist = new List<BldRoom>(roomdict.Values);
            foreach (var broom in roomlist)
            {
                ncap += broom.personCap;
            }
            return ncap;
        }


        public List<Person> GetFreePeopleInRooms()
        {
            var roomlist = new List<BldRoom>(roomdict.Values);
            var peeplist = new List<Person>();
            foreach (var broom in roomlist)
            {
                var broompeeps = broom.GetFreePeopleInRoom();
                peeplist.AddRange(broompeeps);
            }
            return peeplist;
        }

        public List<Person> GetFreeDronesInRooms()
        {
            var padlist = new List<BldDronePad>(paddict.Values);
            var peeplist = new List<Person>();
            foreach (var broom in padlist)
            {
                var broompeeps = broom.GetFreePeopleInRoom();
                peeplist.AddRange(broompeeps);
            }
            return peeplist;
        }

        public List<Person> GetAllPeopleInRooms()
        {
            var roomlist = new List<BldRoom>(roomdict.Values);
            var peeplist = new List<Person>();
            foreach (var broom in roomlist)
            {
                var broompeeps = broom.GetAllPeopleInRoom();
                peeplist.AddRange(broompeeps);
            }
            return peeplist;
        }

        public List<BldRoom> GetRooms()
        {
            var roomlist = new List<BldRoom>(roomdict.Values);
            return roomlist;
        }
        public List<BldDronePad> GetPads()
        {
            var padlist = new List<BldDronePad>(paddict.Values);
            return padlist;
        }

        public void PopulateBuilding()
        {
            var cointoss_pctFull = defPercentFull;
            int npoped = 0;
            var roomlist = new List<BldRoom>(roomdict.Values);
            foreach (var broom in roomlist)
            {
                for (int i = 0; i < broom.personCap; i++)
                {
                    if (GraphAlgos.GraphUtil.FlipBiasedCoin(cointoss_pctFull,"popbld"))
                    {
                        var p = bm.sman.psman.MakeRandomPerson();
                        p.AssignHomeLocation(name,broom.name, broom.name);
                        broom.Occupy(p,regen:false);
                        npoped++;
                    }
                }
            }

            var padlist = new List<BldDronePad>(paddict.Values);
            foreach (var pad in padlist)
            {
                for (int i = 0; i < pad.personCap; i++)
                {
                    if (GraphAlgos.GraphUtil.FlipBiasedCoin(cointoss_pctFull, "popbld"))
                    {
                        var p = bm.sman.psman.MakeRandomPersonDrone();
                        p.AssignHomeLocation(name, pad.name, pad.name);
                        pad.Occupy(p, regen: false);
                        npoped++;
                    }
                }
            }
            //Debug.Log("Populated building " + name + " with "+npoped+" roomcount:" + roomlist.Count);
        }

        public void AddOneRoom(string roomname)
        {
            var roomgo = new GameObject(roomname);
            var roomcomp = roomgo.AddComponent<BldRoom>();
            roomcomp.Initialize(this,roomname,roomname);
            var roompt = this.transform.position;

            if (lc.IsNodeName(roomname))
            {
                var lpt = lc.GetNode(roomname);
                roompt = lpt.pt;
            }
            var alignang = defAngAlign;
            var pcap = defPeoplePerRoom;
            var area = defRoomArea;
            roomcomp.SetStatsArea(roompt, pcap, alignang, area,true);
            roomdict[roomname] = roomcomp;
            bm.RegisterRoom(roomname, roomcomp);
            roomgo.transform.parent = roomlistgo.transform;
        }

        public int StrToInt(string str,int defval)
        {
            var status = int.TryParse(str, out int val);
            return (status ? val : defval);
        }
        public float StrToFloat(string str, float devval)
        {
            var status = float.TryParse(str, out float val);
            return (status ? val : devval);
        }

        public void AddOneRoomFromStringRoomspec(string roomspec)
        {
            var rar = roomspec.Split(':');
            var roomname = rar[0];
            var roomnodename = roomname;
            if (!lc.IsNodeName(roomnodename))
            {
                Debug.LogError($"Building.AddOneRoomFromStringRoomspec - bad padspec{roomspec}");
                return;
            }
            var lpt = lc.GetNode(roomnodename);
            var roomgo = new GameObject(roomname);
            var roomcomp = roomgo.AddComponent<BldRoom>();
            roomcomp.Initialize(this, roomname, roomnodename);
            var roompt = lpt.pt;


            var pcap = StrToInt(rar[1], 1);//roomspecs
            var alignang = StrToFloat(rar[2],0);
            var length = StrToFloat(rar[3],2);
            var width = StrToFloat(rar[4],3);
            var frameit = rar[5].ToLower()[0] != 'f';
            roomcomp.SetStats(roompt, pcap, alignang, length,width,frameit);
            roomdict[roomname] = roomcomp;
            bm.RegisterRoom(roomname, roomcomp);
            roomgo.transform.parent = roomlistgo.transform;
        }

        public void AddOnePadFromStringPadspec(string padspec)
        {
            //Debug.Log("AddOneRoomSpec:" + roomspec);
            var rar = padspec.Split(':');
            var padname = rar[0];
            var padnodename = padname;
            if (padname.EndsWith("centertop"))
            {
                if (!isOsmGenerated)
                {
                    bm.sman.LggError($"Building.AddOnePadFromStringPadspec - cannot compute center of building without OsmBldSpec");
                    return;
                }
                var bs = bm.GetBldBs(this);
                var ptcen = bs.GetCenterTop();
                var gc = bm.sman.lcman.GetGraphCtrl();
                var ptcen1 = bm.sman.mpman.GetHeightVector3(ptcen);// we have to do this extra because we are post linkcloud
                gc.AddNodePtxyz(padnodename, ptcen1.x,ptcen1.y,ptcen1.z);
            }
            else if (!lc.IsNodeName(padnodename))
            { 
                bm.sman.LggError($"Building.AddOnePadFromStringPadspec - bad padspec{padspec}");
                return;
            }
            var lpt = lc.GetNode(padnodename);
            var padgo = new GameObject(padname);
            var padcomp = padgo.AddComponent<BldDronePad>();
            padcomp.Initialize(this, padname, padnodename);
            var roompt = lpt.pt;

            var pcap = StrToInt(rar[1], 1);//roomspecs
            var alignang = StrToFloat(rar[2], 0);
            var length = StrToFloat(rar[3], 2);
            var width = StrToFloat(rar[4], 3);
            var frameit = rar[5].ToLower()[0] != 'f';
            padcomp.SetStats(roompt, pcap, alignang, length, width, frameit);
            paddict[padname] = padcomp;
            bm.RegisterPad(padname, padcomp);
            padgo.transform.parent = roomlistgo.transform;
            bm.sman.drman.RegisterDronePad(padcomp);
        }

        public void AddRoomsToBuilding()
        {
            roomdict = new Dictionary<string,BldRoom>();
            roomlistgo = new GameObject("Rooms");
            roomlistgo.transform.parent = this.transform;
            this.lc = bm.sman.lcman;
            //Debug.Log($"AddRoomsToBuilding:{name} roomspecs.count:{roomspecs.Count} defAngAlign:{defAngAlign}");
            if (roomspecs.Count==0)
            {
                var rooms = GetRoomListFromNodes();
                rooms.ForEach(room => AddOneRoom(room));
            }
            else
            {
                roomspecs.ForEach(roomspec => AddOneRoomFromStringRoomspec(roomspec));
            }
            bldpadspecs.ForEach(padspec => AddOnePadFromStringPadspec(padspec));
            bm.UpdateBldStats();
        }

        public void DeleteGos()
        {
            var nbld = bldgos.Count;
            ActuallyDestroyObjects();
            //   Debug.Log("Deleted "+bldgos.Count + +" goes for building "+name);
            var roomlist = new List<BldRoom>(roomdict.Values);
            roomlist.ForEach(brm => brm.DeleteGos());
            var padlist = new List<BldDronePad>(paddict.Values);
            padlist.ForEach(pad => pad.DeleteGos());
        }
        public void CreateGos()
        {
            CreateObjects();
            //   Debug.Log("Created " + bldgos.Count + " gos for building "+name);
            var roomlist = new List<BldRoom>(roomdict.Values);
            roomlist.ForEach(brm => brm.CreateGos());
            var padlist = new List<BldDronePad>(paddict.Values);
            padlist.ForEach(pad => pad.CreateGos());
        }
        // Update is called once per frame
        //float lasttime = 0;
        //void Update()
        //{
        //    //if (name == "Bld34")
        //    //{
        //    //    if (Time.time - lasttime > 1)
        //    //    {
        //    //        Debug.Log($"{name} isAnOsmBld:{isAnOsmBld}");
        //    //        lasttime = Time.time;
        //    //    }
        //    //}
        //}
    }
}
