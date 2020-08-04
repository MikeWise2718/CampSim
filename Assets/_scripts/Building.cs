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
        public string shortname;
        public int selectionweight;
        public Dictionary<string,BldRoom> roomdict=new Dictionary<string, BldRoom>();
        public LatLongMap llm;
        public GameObject roomlistgo;
        public float defAngAlign = 0f;
        public int defPeoplePerRoom = 2;
        public float defPercentFull = 1.0f;
        public float defRoomArea = 10;
        public float journeyChoiceWeight = 1;

        //System.Random ranman = new System.Random();
        public Person GetRandomFreeToTravelPerson(string ranset="")
        {
            var peeps = GetFreePeopleInRooms();
            var npeeps = peeps.Count;
            if (peeps.Count == 0)  return null;
            var i = GraphAlgos.GraphUtil.GetRanInt(peeps.Count,ranset);
            return peeps[i];
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
            var i = GraphAlgos.GraphUtil.GetRanInt(brooms.Count,ranset);
            return brooms[i];
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
                destnodes = destnodelst;
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
            int val;
            var status = int.TryParse(str, out val);
            return (status ? val : defval);
        }
        public float StrToFloat(string str, float devval)
        {
            float val;
            var status = float.TryParse(str, out val);
            return (status ? val : devval);
        }

        public void AddOneRoomSpec(string roomspec)
        {
            //Debug.Log("AddOneRoomSpec:" + roomspec);
            var rar = roomspec.Split(':');
            var roomname = rar[0];

            var roomgo = new GameObject(roomname);
            var roomcomp = roomgo.AddComponent<BldRoom>();
            roomcomp.Initialize(this, roomname, roomname);
            var roompt = this.transform.position;

            if (lc.IsNodeName(roomname))
            {
                var lpt = lc.GetNode(roomname);
                roompt = lpt.pt;
            }
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
                roomspecs.ForEach(roomspec => AddOneRoomSpec(roomspec));
            }
            bm.UpdateBldStats();
        }

        public void DeleteGos()
        {
            var nbld = bldgos.Count;
            ActuallyDestroyObjects();
            //   Debug.Log("Deleted "+bldgos.Count + +" goes for building "+name);
            var roomlist = new List<BldRoom>(roomdict.Values);
            roomlist.ForEach(brm => brm.DeleteGos());
        }
        public void CreateGos()
        {
            CreateObjects();
            //   Debug.Log("Created " + bldgos.Count + " gos for building "+name);
            var roomlist = new List<BldRoom>(roomdict.Values);
            roomlist.ForEach(brm => brm.CreateGos());
        }
        // Update is called once per frame
        //void Update()
        //{
        //}
    }
}
