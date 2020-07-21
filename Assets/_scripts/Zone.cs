using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace CampusSimulator
{
    public enum zSlotFormE { Full,FullNoBox,SignPerson,PersonFloor,Person, Node, Empty }


    public class Zone : MonoBehaviour
    {

        //static System.Random ranman = new System.Random(123);

        public ZoneMan zm = null;
        Dictionary<string,ZoneSlot> slots = new Dictionary<string,ZoneSlot>();
        public List<string> slotnames = new List<string>();
        public string gprefix = "";
        public double pctfullonstart = 0.5;
        public bool randompersgen = true;
        public bool showZoneDefinitionMarkers = true;
        public int startingperscount = 0;
        public float slot2slotdist = 0;
        public Vector3 zpt1;
        public Vector3 zpt2;
        public Vector3 apt1;
        public Vector3 apt2;
        GameObject alarmgo;
        public Building bld;

        public string SlotNodeNamePrefix()
        {
            return gprefix + "-dt-ps";
        }
        public string SlotNameNodeAuxPrefix(string auxname)
        {
            return gprefix + "-dt-" + auxname;
        }
        string slotnumformat = "D2";
        public string SlotNameNode(int i)
        {
            return SlotNodeNamePrefix() + (i+1).ToString(slotnumformat);
        }
        public string SlotName(int i)
        {
            return "ps" + (i+1).ToString(slotnumformat);
        }
        public string SlotAxuxNodeName(string auxname,int i)
        {
            return SlotNameNodeAuxPrefix(auxname) + (i+1).ToString(slotnumformat);
        }

        void AddSlot(string sname,int num, float x, float y, float ang)
        {
            //Debug.Log("addslot:"+sname+" " + num + "  x" + x + "  y:" + y + " ang:" + ang);

            var slot = new GameObject(sname);
            slot.transform.parent = this.transform;

            var zslt = slot.AddComponent<ZoneSlot>();

            zslt.Initialize(this, num, x, y, ang, 2.6f);


            zslt.CreateObjects();
            zslt.nodename = SlotNameNode(num);
            zm.AddSlot(zslt);
            //Debug.Log("nodename:" + zslt.nodename);
            slots[zslt.nodename] = zslt;
            slotnames.Add(zslt.nodename);
        }
        void DestroySlot(string name)
        {
            var slot = slots[name];
            zm.RemoveSlot(slot);
            slot.EmptyAndDestroy();
            Destroy(slot.gameObject);
        }

        public void CreateObjects()
        {
        }


        public void Empty()
        {
            DeleteGos();
            var namelist = new List<string>(slots.Keys);
            namelist.ForEach(name => DestroySlot(name));
            namelist.ForEach(name => slots.Remove(name));
            slotnames = null;
        }

        public Vector3 GetPosition()
        {
            Vector3 rv = Vector3.zero;
            if (slots.Count > 0)
            {
                foreach (var sm in slots.Values)
                {
                    rv += sm.GetPosition();
                }
                rv /= slots.Count;
            }
            return rv;
        }
    


        public ZoneSlot GetClosestAvailableSlot(Vector3 position)
        {
            float mindist = 9e10f;
            ZoneSlot minslot = null;
            foreach (var zslt in slots.Values)
            {
                if (zslt.slotstate==zslotstateE.available && zslt.connected)
                {
                    float d = Vector3.Distance(position, zslt.transform.position);
                    if (d <= mindist)
                    {
                        mindist = d;
                        minslot = zslt;
                    }
                }
            }
            return minslot;
        }

        public ZoneSlot GetClosestFreePerson(Vector3 position)
        {
            float mindist = 9e10f;
            ZoneSlot minslot = null;
            foreach (var zslt in slots.Values)
            {
                if (zslt.occupied && !zslt.slotreserved && zslt.connected)
                {
                    float d = Vector3.Distance(position, zslt.transform.position);
                    if (d <= mindist)
                    {
                        mindist = d;
                        minslot = zslt;
                    }
                }
            }
            return minslot;
        }

        public void Vacate(string nodename)
        {
            //Debug.Log("Vacating " + nodename);
            if (slots.ContainsKey(nodename))
            {
                slots[nodename].Vacate();
            }
            else
            {
                Debug.Log("In Vacate:" + nodename + " not found in "+this.name);
            }
        }

        public bool Reserve(string nodename)
        {
            //Debug.Log("Reserving " + nodename);
            if (slots.ContainsKey(nodename))
            {
                return slots[nodename].Reserve();
            }
            else
            {
                Debug.Log("In Reserve:" + nodename + " not found in " + this.name);
                return false;
            }
        }


        public void SetConnected(string nodename)
        {
            //Debug.Log("Occupying " + nodename);
            if (slots.ContainsKey(nodename))
            {
                slots[nodename].SetConnected();
            }
            else
            {
                Debug.Log("SetConnected could not find:" + nodename + " not found in " + this.name);
            }
        }

 
        public void GenSlots(string gprefix, int ncols, int nrows,  Vector3 pt1, Vector3 pt2)
        {
            var lc = zm.sman.lcman;
            var lclc = lc.GetGraphCtrl();

            this.gprefix = gprefix;
            var startnum = slotnames.Count;
            this.slotnumformat = ((ncols + startnum) < 100 ? "D2" : "D3");
            this.transform.position = Vector3.zero;
            this.zpt1 = pt1;
            this.zpt2 = pt2;
            this.apt1 = new Vector3( pt1.x, pt1.y+2, pt1.z );
            this.apt2 = new Vector3( pt2.x, pt2.y+2, pt2.z );
            var ndiv = Mathf.Max(1, ncols - 1);
            float x0 = pt1.x;
            float z0 = pt1.z;
            float dx = (pt2.x - pt1.x) / ndiv;
            float dz = (pt2.z - pt1.z) / ndiv;
            this.slot2slotdist = Mathf.Sqrt( dx*dx + dz*dz );
            float ang = (180/Mathf.PI)*Mathf.Atan2(-dz, dx);
            var mman = this.zm.sman.mpman;
            for (int j = 0; j < nrows; j++)
            {
                int jofs = j*ncols;
                for (int i = 0; i < ncols; i++)
                {
                    var idx = startnum + jofs + i;
                    var name = SlotName(idx);
                    var x = x0 + i*dx;
                    var z = z0 + i*dz;
                    AddSlot(name, idx, x,z,  ang);
                    var nname = SlotNameNode(idx);
                    //lclc.AddNodePtxy(nname, x, z);
                    var y = mman.GetHeight(x, z);
                    lclc.AddNode(nname,new Vector3(x,y,z),domodv:false);
                    //Debug.Log("Added zone slot node:" + nname+" idx:"+idx+" x:"+x.ToString("f1")+" z:"+z.ToString("f1"));
                }
                x0 = x0 - dz;
                z0 = z0 + dx;
            }
        }


        public List<Person> GetFreePeopleInZone()
        {
            var rv = new List<Person>();
            var slotlist = new List<ZoneSlot>(slots.Values);
            var pm = zm.sman.psman;
            foreach (var slot in slotlist)
            {
                var persname = slot.persname;
                if (persname!=null && persname!="")
                {
                    if (pm.IsPersonName(persname))
                    {
                        var pers = pm.GetPerson(persname);
                        rv.Add(pers);
                    }
                }
            }
            return rv;
        }

        public void SetAlarmState(bool newstate,bool justone,bool startstream)
        {
            Debug.Log($"Zone.SetAlarmState name:{name} - nestate:{newstate} justone:{justone} startstream:{startstream}");
            if (this.alarmgo != null)
            {
                var algot = this.alarmgo.transform;
                if (algot != null)
                {
                    var nalarm = algot.childCount;
                    for (var i = 0; i < nalarm; i++)
                    {
                        var ago = algot.GetChild(i);
                        var alarm = ago.GetComponent<BldEvacAlarm>();
                        if (alarm != null)
                        {
                            alarm.SetState(newstate);
                            if (startstream)
                            {
                                //Debug.Log("Setting color to yellow");
                                alarm.inAlarmAldeboColor = "yellow";
                                alarm.inAlarmEmissiveColor = "deeppurple";
                            }
                        }
                    }
                }
            }
            if (newstate)
            {
                if (startstream)
                {
                    Debug.Log("Starting stream for " + name);
                    StartStreamJourneys(5);
                }
                else
                {
                    Debug.Log("Trying to add an allclear journey for " + name);
                    var n = -1;
                    if (justone)
                    {
                        n = 1;
                    }
                    UnEvacN(n);
                }
            }

        }
        public void UnEvacN(int n)
        {
            if (n < 0) n = 999999;
            //zm.sman.jnman.journeyMessages = true;
            zm.sman.jnman.BatchAllClearJourneys(name, n);
        }

        public void StartStreamJourneys(int n)
        {
            if (n < 0) n = 999999;
            //zm.sman.jnman.journeyMessages = true;
            zm.sman.jnman.StartStreamingJourneys(name, bld);
        }

        //void AddAlarmToNode(GameObject parentnode, string alarmname, string nodename)
        //{
        //    var lc = zm.sman.linkcloudctrl;
        //    var lclc = lc.GetLinkCloud();
        //    var nodept = lclc.GetNode(nodename);
        //    if (nodept == null) return;

        //    var pt = nodept.pt;
        //    var apos = new Vector3(pt.x, pt.y + 2, pt.z);
        //    var ago = BldEvacAlarm.GetGo(alarmname, apos,  1.0f);
        //    ago.transform.parent = parentnode.transform;
        //    var beac = ago.AddComponent<BldEvacAlarm>();
        //    beac.Init(this, apos);
        //}

        public static List<string> GetZoneNames(string filter)
        {
            var l = new List<string>
            {
                "Ms-Redw-B-evac-1",
                "Ms-Redw-B-evac-2",
                "Ms-Redw-B-evac-3",
                "Ms-Redw-B-evac-4",
                "Ms-Redw-B-evac-5",
                "Ms-B19-evac-1",
                "Eb12-evac-1",
            };
            l.RemoveAll(item => !item.StartsWith(filter));
            return l;
        }

        public void AddSlots(ZoneMan zm)
        {
            this.zm = zm;
            string gname = this.name;
            switch (gname)
            {
                  case "Ms-Redw-B-evac-1":
                    {
                        var v1 = new Vector3(-2064.2f, 0, -1136.3f);
                        var v2 = new Vector3(-2070.1f, 0, -1117.9f);
                        GenSlots("z_"+gname, 30, 10, v1, v2);
                        zm.CreateZoneLinks(gname, "bRWB-os1-o00");
                        bld = zm.sman.bdman.GetBuilding("BldRWB");
                        break;
                    }
                case "Ms-Redw-B-evac-2":
                    {
                        var v1 = new Vector3(-2064.2f, 0, -1166.3f);
                        var v2 = new Vector3(-2070.1f, 0, -1147.9f);
                        GenSlots("z_"+gname, 30, 10, v1, v2);
                        zm.CreateZoneLinks(gname, "bRWB-os1-o02");
                        bld = zm.sman.bdman.GetBuilding("BldRWB");
                        break;
                    }
                case "Ms-Redw-B-evac-3":
                    {
                        var v1 = new Vector3(-1939.5f, 0, -1119.2f);
                        var v2 = new Vector3(-1963.5f, 0, -1126.6f);
                        GenSlots("z_"+gname, 30, 10, v1, v2);
                        zm.CreateZoneLinks(gname, "bRWB-os2-o01");
                        bld = zm.sman.bdman.GetBuilding("BldRWB");
                        break;
                    }
                case "Ms-Redw-B-evac-4":
                    {
                        var v1 = new Vector3(-1984.0f, 0, -1057.7f);
                        var v2 = new Vector3(-1978.7f, 0, -1076.5f);
                        GenSlots("z_"+gname, 24, 8, v1, v2);
                        zm.CreateZoneLinks(gname, "bRWB-os2-o04");
                        bld = zm.sman.bdman.GetBuilding("BldRWB");
                        break;
                    }
                case "Ms-Redw-B-evac-5":
                    {
                        var v1 = new Vector3(-2085.0f, 0, -1100.3f);
                        var v2 = new Vector3(-2086.6f, 0, -1086.0f);
                        GenSlots("z_"+gname, 24, 8, v1, v2);
                        zm.CreateZoneLinks(gname, "bRWB-os3-o02");
                        bld = zm.sman.bdman.GetBuilding("BldRWB");
                        break;
                    }
                case "Ms-B19-evac-1":
                    {
                        //var v1 = new Vector3(-450.0f, 0, 106.6f);
                        //var v2 = new Vector3(-443.0f, 0,  95.0f);
                        var v1 = new Vector3(-447.6f, 0, 102.4f);
                        var v2 = new Vector3(-441.4f, 0, 87.7f);
                        GenSlots("z_"+gname, 16, 8, v1, v2);
                        zm.CreateZoneLinks(gname, "b19-os2-o01");
                        bld = zm.sman.bdman.GetBuilding("Bld19");
                        break;
                    }
                case "Eb12-evac-1":
                    {
                        var v1 = new Vector3(36.0f, 0, 17.0f);
                        var v2 = new Vector3(48.0f, 0, 17.0f);
                        GenSlots("z_" + gname, 14, 8, v1, v2);
                        zm.CreateZoneLinks(gname, "eb12-oso01");
                        bld = zm.sman.bdman.GetBuilding("Eb12-22");
                        break;
                    }
            }
        }
        public void DeleteGos()
        {
            if (alarmgo!=null)
            {
                Destroy(alarmgo);
            }
            foreach (var slt in slots.Keys)
            {
                slots[slt].DeleteGos();
            }
        }
        public void CreateGos()
        {
            alarmgo = new GameObject("alarms");
            alarmgo.transform.parent = transform;

            var ago1 = BldEvacAlarm.GetGo("AllFreeAlarm1", apt1, 0.5f);
            var ago2 = BldEvacAlarm.GetGo("AllFreeAlarm2", apt2, 0.5f);
            ago1.transform.parent = alarmgo.transform;
            ago2.transform.parent = alarmgo.transform;
            var alarm1 = ago1.AddComponent<BldEvacAlarm>();
            var alarm2 = ago2.AddComponent<BldEvacAlarm>();
            alarm1.Init(this, apt1);
            alarm2.Init(this, apt2);

            if (showZoneDefinitionMarkers)
            {
                var ptgo1 = GraphAlgos.GraphUtil.CreateMarkerSphere(name+"p1 - start", zpt1, clr: "darkgreen", size: 0.2f);
                var ptgo2 = GraphAlgos.GraphUtil.CreateMarkerSphere(name+"p2 - stop", zpt2, clr: "darkred", size: 0.2f);
                ptgo2.transform.parent = alarmgo.transform;
                ptgo1.transform.parent = alarmgo.transform;
            }

            foreach (var slt in slots.Keys)
            {
                slots[slt].CreateGos();
            }
        }
        //void Start()
        //{
        //}

        //void Update()
        //{
        //}
    }
}