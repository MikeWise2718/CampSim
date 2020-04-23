using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace CampusSimulator
{

    public class BldRoomOccMan : MonoBehaviour
    {
        public enum roomSlotStatE { free, reserved, occupied };
        public roomSlotStatE[] occlookup = null;
        float rad;
        float length;
        float width;

        int ncap;
        int orincap;
        int maxcap;
        BldRoom room;
        public bool slotsCanExpand;
        const float d2r = Mathf.PI / 180;
        const float r2d = 180 / Mathf.PI;


        public Dictionary<string, Person> occDict = new Dictionary<string, Person>();
        public List<Person> occList = new List<Person>();


        public List<int> GetShuffledList(int n)
        { // TODO: should cache a few of these and reuse until n changes
            var ramp = new List<int>();
            for (int i = 0; i < n; i++)
            {
                ramp.Add(i);
            }
            var random = new System.Random();
            ramp.Sort((x, y) => random.Next(-1, 1));
            return ramp;
        }

        public List<Person> GetPersons()
        {
            var rv = new List<Person>(occDict.Values);
            return rv;
        }
        public int GetPersonCount()
        {
            return occList.Count;
        }
        public Person GetPersonN(int i)
        {
            return occList[i];
        }

        public List<Person> GetFreeToTravelPeopleInRoom()
        {
            var rv =  new List<Person>(occList.Where(pers => pers.personState==PersonStateE.freeToTravel));
            return rv;
        }

        public List<Person> GetAllPeopleInRoom()
        {
            return occList;
        }
        public void AddPerson(Person pers)
        {
            if (!occList.Contains(pers))
            {
                occList.Add(pers);
            }
            else
            {
                Debug.Log("BldRoomOccman - Trying to add person twice:" + pers.name+" in room "+room.roomFullName);
            }
            occDict[pers.personName] = pers;
        }
        public void DelPerson(Person pers)
        {
            occList.Remove(pers);
            occDict.Remove(pers.personName);
        }
        public void init(BldRoom room, int ncap, float length, float width, bool slotsCanExpand)
        {
            occlookup = new roomSlotStatE[ncap];
            this.room = room;
            this.length = length;
            this.width = width;
            this.rad = 0.8f * Mathf.Min(length, width) / 2;
            this.slotsCanExpand = slotsCanExpand;
            this.ncap = ncap;
            this.orincap = ncap;
            occDict = new Dictionary<string, Person>();
        }
        public void OccupyFixedNode(Person pers)
        {
            //var idx = GetFreeIndex(markasoccupied: true);
            pers.roomPlaceFixed = true;
            //Debug.Log("OccupyFixedNode for "+room.roomFullName+" pers:" + pers.personName );
            AddPerson(pers);
        }
        public void OccupyFreeSlot(Person pers)
        {
            var idx = GetFreeIndex(markasoccupied: true);
            pers.roomPlaceIdx = idx;
            //Debug.Log("OccupyFreeSlot for "+room.fullname+" pers:" + pers.personName + " idx:" + idx);
            AddPerson(pers);
        }
        public void Occupy(Person pers)
        {
            if (pers.IsInHomeRoom() && pers.roomPlaceFixed)
            {
                OccupyFixedNode(pers);
            }
            else
            {
                OccupyReservedSlot(pers);
            }
        }
        public void OccupyReservedSlot(Person pers)
        {
            var idx = GetReservedIndex(markasoccupied: true);
            //Debug.Log("OccupyReservedSlot for " + room.fullname + " pers:" + pers.personName + " idx:" + idx);
            if (idx == -1)
            {
                //Debug.Log("GetFreeIndex invoked");
                idx = GetFreeIndex(markasoccupied: true);// this should force the free slots to expand
            }
            //Debug.Log("OccupyReservedSlot assigning to " + pers.personName + " idx:" + idx);
            pers.roomPlaceIdx = idx;
            AddPerson(pers);
            //if (Nfree() <= 1)
            //{
            //    DoubleNcap();
            //}
        }
        public void Vacate(Person pers)
        {
            if (pers.roomPlaceIdx >= 0)
            {
                if (pers.roomPlaceIdx >= occlookup.Length)
                {
                    Debug.Log("BldRoomOccman index out of range (" + pers.roomPlaceIdx + ">=" + occlookup.Length + " in room " + room.roomFullName);
                }
                else
                {
                    occlookup[pers.roomPlaceIdx] = roomSlotStatE.free;
                }
            }
            DelPerson(pers);
        }
        public void Reserve(int i)
        {
            occlookup[i] = roomSlotStatE.reserved;
        }
        public void UnReserve(int i)
        {
            if (occlookup[i] == roomSlotStatE.reserved)
            {
                occlookup[i] = roomSlotStatE.free;
            }
        }



        public List<int>GetOcclistIndexes(roomSlotStatE filterval)
        {
            var fltIdxList = new List<int>( 
                occlookup.Select((p, i) => new { p, i })
                                          .Where(z => z.p == filterval)
                                          .Select(z => (z.i)));
            return fltIdxList;
        }
        public int GetReservedIndex(bool markasoccupied)
        {
            var foundIdxList = GetOcclistIndexes(roomSlotStatE.reserved);
            if (foundIdxList.Count > 0)
            {
                var fidx = GraphAlgos.GraphUtil.GetRanInt(foundIdxList.Count);
                var idx = foundIdxList[fidx];
                if (markasoccupied)
                {
                    occlookup[idx] = roomSlotStatE.occupied;
                }
                return idx;
            }
            return -1;
        }
        public int GetFreeIndex(bool markasoccupied = false, bool markasreserved = false,int nrecur=0)
        {
            if (nrecur > 2 )
            {
                return -1;// this should never happen
            }
            var foundIdxList = GetOcclistIndexes(roomSlotStatE.free);
            if (foundIdxList.Count > 0)
            {
                var fidx = GraphAlgos.GraphUtil.GetRanInt(foundIdxList.Count);
                var idx = foundIdxList[fidx];
                if (markasoccupied)
                {
                    occlookup[idx] = roomSlotStatE.occupied;
                }
                if (markasreserved)
                {
                    occlookup[idx] = roomSlotStatE.reserved;
                }
                return idx;
            }
            DoubleNcap();
            return GetFreeIndex(markasoccupied, markasreserved, nrecur:nrecur+1);
        }
        public int Nocc()
        {
            var cnt = occlookup.Where(p => p == roomSlotStatE.occupied).Count();
            return cnt;
        }
        public int Nfree()
        {
            var cnt = occlookup.Where(p => p == roomSlotStatE.free).Count();
            return cnt;
        }
        public int Nreserved()
        {
            var cnt = occlookup.Where(p => p == roomSlotStatE.reserved).Count();
            return cnt;
        }
        public List<roomSlotStatE> GetFreeSlots()
        {
            var rv = new List<roomSlotStatE>( occlookup.Where(p => p == roomSlotStatE.free) );
            return rv;
        }
        public List<roomSlotStatE> GetReservedSlots()
        {
            var rv = new List<roomSlotStatE>(occlookup.Where(p => p == roomSlotStatE.reserved));
            return rv;
        }
        public List<roomSlotStatE> GetOccupiedSlots()
        {
            var rv = new List<roomSlotStatE>(occlookup.Where(p => p == roomSlotStatE.occupied));
            return rv;
        }

        public List<int> GetFreeSlotIndexes()
        {
            var rv = new List<int>();
            for (int i = 0; i < ncap; i++)
            {
                if (occlookup[i] == roomSlotStatE.free)
                {
                    rv.Add(i);
                }
            }
            return rv;
        }
        public int GetFreeRoomSlot(bool markAsReserved)
        {
            var FreeSlots = GetFreeSlotIndexes();
            if (FreeSlots.Count>0)
            { 
                var idx = GraphAlgos.GraphUtil.GetRanInt(FreeSlots.Count);
                return FreeSlots[idx];
            }
            return 0;// default is just show it in
        }
        public int GetFreeSlotOld(bool markAsReserved)
        {
            for (int i = 0; i < ncap; i++)
            {
                if (occlookup[i] == roomSlotStatE.free)
                {
                    if (markAsReserved)
                    {
                        occlookup[i] = roomSlotStatE.reserved;
                    }
                    return i;
                }
            }
            return 0;
        }
        public bool DoubleNcap()
        {
            if (!slotsCanExpand) return false;
            var ocap = ncap;
            //Debug.Log("Room " + room.name + " doubling cap from " + ncap + " to " + 2*ncap + " nocc:" + Nocc() + " nres:" + Nreserved() + " nfree:" + Nfree());
            var nocclookup = new roomSlotStatE[ 2*ncap ];
            for (int i = 0; i < ncap; i++)
            {
                nocclookup[ 2*i] = occlookup[i];
                nocclookup[ 2*i + 1 ] = roomSlotStatE.free;
            }
            foreach (Person pers in occDict.Values)
            {
                pers.roomPlaceIdx = 2*pers.roomPlaceIdx;
            }
            occlookup = nocclookup;
            ncap = 2*ncap;
            //Debug.Log("Room " + room.name + " doubled  cap from " + ocap + " to " + ncap + " nocc:" + Nocc()+" nres:" + Nreserved() + " nfree:" + Nfree());
            return true;
        }
        public bool IsOccupied(int i)
        {
            return occlookup[i] == roomSlotStatE.occupied;
        }
        public bool IsFree(int i)
        {
            return occlookup[i] == roomSlotStatE.free;
        }
        public bool IsReserved(int i)
        {
            return occlookup[i] == roomSlotStatE.reserved;
        }
        public Vector3 GetOccPosition(int i)
        {
            var ang = GetOccAngle(i);
            var x = rad * Mathf.Cos(ang);
            var y = 0;
            var z = rad * Mathf.Sin(ang);
            var rv = new Vector3(x, y, z);
            return rv;
        }
        public float GetOccAngle(int i)
        {
            var ang = d2r * (i * 360.0f / ncap);
            return ang;
        }
        public void CreateNodes()
        {
            for (int i = 0; i < ncap; i++)
            {
                var v = GetOccPosition(i);
                var pt = room.roomformgo.transform.position + v;
                var clr = "green";
                if (IsOccupied(i)) clr = "red";
                if (IsReserved(i)) clr = "yellow";
                var sgo = GraphAlgos.GraphUtil.CreateMarkerSphere("c" + i, pt, clr: clr);
                sgo.transform.parent = room.roomformgo.transform;
            }
        }
        public void EmptyRoom()
        {
            var peeps = new List<Person>(GetAllPeopleInRoom());// deep copy needed
            foreach (var peep in peeps)
            {
                Vacate(peep);
            }
        }
        // Start is called before the first frame update
        void Start()
        {
        }

        public bool doDoubleCap=false;
        // Update is called once per frame
        void Update()
        {
            if (doDoubleCap)
            {
                DoubleNcap();
                room.bm.sman.RequestRefresh("BldRoomOccman-Update on doDoubleCap");
                doDoubleCap = false;
            }

        }
    }


}