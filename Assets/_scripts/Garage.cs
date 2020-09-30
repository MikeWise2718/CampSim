using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace CampusSimulator
{
    public enum SlotFormE { Full,FullNoBox,PiSignCar,CarFloor,Car, NodeFloor, Node, Empty }


    public class Garage : MonoBehaviour
    {

        static System.Random ranman = new System.Random(123);

        public GarageMan gm = null;
        Dictionary<string,GarageSlot> slots = new Dictionary<string,GarageSlot>();
        public List<string> slotnames = new List<string>();
        public string gprefix = "";
        public double pctfullonstart = 0.5;
        public bool randomcargen = true;
        public int startingcarcount = 0;
        public float slot2slotdist = 0;

        public string walknode;
        public string drivenode;
        public Vector3 wlkpt;
        public Vector3 drvpt;

        public string fullname;
        public string slotnumformat = "D2";
        public int slotstartnumber = 0;
        public float defPercentFull = 0.75f;

        GameObject miscgo;
        public Vector3 zpt1;
        public Vector3 zpt2;

        public Garage parentGarage;
        public List<Garage> childGarages;
        public GraphAlgos.LcNode dnode;
        public GraphAlgos.LcNode wnode;

        public void Initialize(GarageMan gm)
        {
            this.gm = gm;
            parentGarage = null;
            childGarages = new List<Garage>();
            fullname = name;
            slotnumformat = "D2";
        }
        public void AddChild(Garage newchild)
        {
            foreach( var gar in childGarages )
            {
                if (gar.name==newchild.name)
                {
                    Debug.Log("Duplicate garage child:"+gar.name+" - exiting:");
                    return;
                }        
            }
            childGarages.Add(newchild);
            newchild.parentGarage = this;
            slotnumformat = "D3";
            newchild.transform.parent = this.transform;
            newchild.fullname = this.name+"/"+newchild.name;
            newchild.slotnumformat = slotnumformat;
        }
        public string SlotNodeNamePrefix()
        {
            return gprefix + "-dt-ps";
        }
        public string SlotNameNodeAuxPrefix(string auxname)
        {
            return gprefix + "-dt-" + auxname;
        }
        public int slotDisplayNumber(int i)
        {
            var rv = i + 1 + slotstartnumber;
            return rv;
        }
        public string SlotNameNode(int i)
        {
            return SlotNodeNamePrefix() + slotDisplayNumber(i).ToString(slotnumformat);
        }
        public string SlotName(int i)
        {
            return "ps" + slotDisplayNumber(i).ToString(slotnumformat);
        }
        public string SlotAxuxNodeName(string auxname,int i)
        {
            return SlotNameNodeAuxPrefix(auxname) + (i+1).ToString(slotnumformat);
        }

        public void SetWalkAndDriveNodes(string walknode, string drivenode)
        {
            this.walknode = walknode;
            this.drivenode = drivenode;
            var lclc = gm.sman.lcman.GetGraphCtrl();
            wnode = lclc.GetNode(walknode);
            dnode = lclc.GetNode(drivenode);
            if (wnode != null)
            {
                this.wlkpt = wnode.pt;
            }
            if (dnode != null)
            {
                this.drvpt = dnode.pt;
            }
        }
        //bool slotpopulate = false;
        //int ticktock = 0;
        void AddSlot(int num, float x, float y, float ang, string group)
        {
            //Debug.Log("addslot:" + num + "  x" + x + "  y:" + y + " ang:" + ang);

            var slot = new GameObject(SlotName(num));
            slot.transform.parent = this.transform;

            var sm = slot.AddComponent<GarageSlot>();

            sm.Initialize(this, num, x, y, ang, 2.6f,group);

            sm.CreateObjects();
            sm.nodename = SlotNameNode(num);
            gm.AddSlot(sm);
            //Debug.Log("nodename:" + sm.nodename);
            slots[sm.nodename] = sm;
            slotnames.Add(sm.nodename);
            //Debug.Log("nodename:" + sm.nodename);
        }
        public void PopulateGarageWithVehicles()
        {
            var cointoss_pctFull = defPercentFull;
            int npoped = 0;
            var veman = gm.sman.veman;
            var slotlist = new List<GarageSlot>(slots.Values);
            foreach (var slot in slotlist)
            {
                if (GraphAlgos.GraphUtil.FlipBiasedCoin(cointoss_pctFull))
                {
                    var v = veman.MakeVehicle();
                    v.AssignHomeLocation(name, slot.name);
                    slot.VehicleOccupy(v);
                    npoped++;
                }
            }
            //Debug.Log("Populated garage " + name + " with "+npoped+" vehicles - slots:" + slots.Count);
        }
        void DestroySlot(string name)
        {
            var slot = slots[name];
            gm.RemoveSlot(slot);
            slot.EmptyAndDestroy();
            Destroy(slot.gameObject);
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
        public Vector3 GetSlotPosition(int i)
        {
            if (i<0 || slots.Count<=i)
            {
                return Vector3.zero;
            }
            return slots[slotnames[i]].GetPosition();
        }
        public Vector3 GetSlotPosition(int i,slotPosE slotPos)
        {
            if (i < 0 || slots.Count <= i)
            {
                return Vector3.zero;
            }
            return slots[slotnames[i]].GetPosition(slotPos);
        }
        public Vector3 GetSlotPosition1(int i, float angle, float len)
        {
            if (i < 0 || slots.Count <= i)
            {
                return Vector3.zero;
            }
            return slots[slotnames[i]].GetPosition1(angle,len);
        }
        public Vector3 GetSlotPosition2(int i, float angle1,float len1, float angle2, float len2)
        {
            if (i < 0 || slots.Count <= i)
            {
                return Vector3.zero;
            }
            return slots[slotnames[i]].GetPosition2(angle1,len1, angle2,len2);
        }

        static int carcount = 0;
        const int maxcar = 7;
        string GetCarFormname(bool random)
        {
            string rv = "";
            int idx = (carcount % maxcar) + 1;
            if (random)
            {
                idx = ranman.Next(maxcar) + 1;
            }
            rv = "car" + idx.ToString("D3");
            //Debug.Log("GetCarformname:" + rv+" ccnt:"+carcount+" idx:"+idx);
            carcount++;
            return rv;
        }


        public GarageSlot GetClosestAvailableSlot(Vector3 position)
        {
            float mindist = 9e10f;
            GarageSlot minslot = null;
            foreach (var sm in slots.Values)
            {
                if (sm.connectedToGrid && sm.slotstate==slotstateE.slot_free)
                {
                    float d = Vector3.Distance(position, sm.transform.position);
                    if (d <= mindist)
                    {
                        mindist = d;
                        minslot = sm;
                    }
                }
            }
            return minslot;
        }

        public GarageSlot GetClosestFreeCar(Vector3 position)
        {
            float mindist = 9e10f;
            GarageSlot minslot = null;
            foreach (var sm in slots.Values)
            {
                if (sm.connectedToGrid && sm.slotstate==slotstateE.car_free)
                {
                    float d = Vector3.Distance(position, sm.transform.position);
                    if (d <= mindist)
                    {
                        mindist = d;
                        minslot = sm;
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

        //public bool Reserve(string nodename)
        //{
        //    //Debug.Log("Reserving " + nodename);
        //    if (slots.ContainsKey(nodename))
        //    {
        //        return slots[nodename].ReserveSlot();
        //    }
        //    else
        //    {
        //        Debug.Log("In Reserve:" + nodename + " not found in " + this.name);
        //        return false;
        //    }
        //}


        public void SetConnectedToGrid(string nodename)
        {
            if (slots.ContainsKey(nodename))
            {
                slots[nodename].SetConnectedToGrid();
            }
            else
            {
                Debug.Log("SetConnected could not find:" + nodename + " not found in " + this.name);
            }
        }

        public int GetChildSlotCount()
        {
            var sum = 0;
            foreach (var cg in this.childGarages)
            {
                sum += cg.slots.Count;
            }
            return sum;
        }
        public void GenSlots(string gprefix, int nslots, float x0, float z0, float dx, float dz, float ang, string group = "",bool resetSlotStartNumber=true,int slotsAlreadyIn=0, bool revOrd = false,bool revInd=false,bool revPos = false)
        {
            //Debug.Log("Generating (1) " + nslots + " slots for " + name);
            zpt1 = new Vector3(x0, 0, z0);
            zpt2 = new Vector3(x0 + nslots * dx, 0, z0 + nslots * dz);
            this.gprefix = gprefix;
            if (resetSlotStartNumber)
            {
                this.slotstartnumber = 0;
                if (parentGarage)
                {
                    this.slotstartnumber = parentGarage.GetChildSlotCount();
                }
            }
            this.transform.position = Vector3.zero;

            if (revOrd)
            {
                for (int i = nslots-1; i>=0; i--)
                {
                    var ip = i;
                    if (revPos) ip = nslots - ip - 1;
                    var ii = nslots - i - 1 - 1;
                    if (revInd) ii = nslots - ii;
                    AddSlot(ii+slotsAlreadyIn, x0 + ip*dx, z0 + ip*dz, ang, group);
                }
            }
            else
            {
                for (int i = 0; i < nslots; i++)
                {
                    var ip = i;
                    if (revPos) ip = nslots - ip - 1;
                    var ii = i;
                    if (revInd) ii = nslots - ii - 1;
                    AddSlot(ii+slotsAlreadyIn, x0 + ip*dx, z0 + ip*dz, ang, group);
                }
            }

        }
        public void GenSlots(string gprefix, int nslots, Vector3 p1, Vector3 p2, bool resetSlotStartNumber=true, string group = "", bool revOrd=false, bool revInd = false, bool revPos = false)
        {
            //Debug.Log("Generating (2) " + nslots + " slots for " + name);
            this.gprefix = gprefix;
            zpt1 = p1;
            zpt2 = p2;
            if (resetSlotStartNumber)
            {
                this.slotstartnumber = 0;
                if (this.parentGarage)
                {
                    this.slotstartnumber = parentGarage.GetChildSlotCount();
                    //Debug.Log(name+" reset this.slotstartnumber:" + this.slotstartnumber);
                }
            }
            this.transform.position = Vector3.zero;
            var ndiv = Mathf.Max(1,nslots - 1);
            float x0 = p1.x;
            float z0 = p1.z;
            float dx = (p2.x - p1.x) / ndiv;
            float dz = (p2.z - p1.z) / ndiv;
            this.slot2slotdist = Mathf.Sqrt( dx*dx + dz*dz );
            float ang = (180/Mathf.PI)*Mathf.Atan2(-dz, dx);
            if (revOrd)
            {
                for (int i = nslots-1; i>=0; i--)
                {
                    var ip = i;
                    if (revPos) ip = nslots - ip - 1;
                    var ii = nslots - i - 1;
                    if (revInd) ii = nslots - ii - 1;
                    AddSlot(ii, x0 + ip*dx, z0 + ip*dz, ang, group);
                }
            }
            else
            {
                for (int i = 0; i < nslots; i++)
                {
                    var ip = i;
                    if (revPos) ip = nslots - ip - 1;
                    var ii = i;
                    if (revInd) ii = nslots - ii - 1;
                    AddSlot(ii, x0 + ip*dx, z0 + ip*dz, ang, group);
                }
            }
        }
        public static List<string> GetGarageNames(string filter)
        {
            var l = new List<string>
            {
                "Eb12_block/west",
                "Eb12_block/east",
                "Eb12_Rewe_1",
                "Eb12_Rewe_2",
                "MsDublin1",

                //"MsGarageRWB",
                "MsGarageRWB/nnw",
                "MsGarageRWB/nnn",
                "MsGarageRWB/eee",
                "MsGarageRWB/sss",
                "MsGarageRWB/ssw",
                "MsGarageRWB/wsw",
                "MsGarageRWB/wnw",

                "MsGarageRWB/cnwwn", // CE_TErow - cnwwn
                "MsGarageRWB/cncwn", // CE_SErow - cncwn
                "MsGarageRWB/cncen", // CE_NErow - cncen
                "MsGarageRWB/cneen", // CE_MErow - cneen

                "MsGarageRWB/cnwws", // CE_TWrow - cnwws
                "MsGarageRWB/cncws", // CE_SWrow - cncws
                "MsGarageRWB/cnces", // CE_NWrow - cnces
                "MsGarageRWB/cnees", // CE_MWrow - cnees

                "MsGarageRWB/cswwn", // CW_TErow - cswwn
                "MsGarageRWB/csccn", //            csccn
                "MsGarageRWB/cscwn", // CW_SErow - cscwn
                "MsGarageRWB/cscen", // CW_NErow - cscen
                "MsGarageRWB/cscdn", //            cscdn
                "MsGarageRWB/cseen", // CW_MErow - cseen

                "MsGarageRWB/cswws", // CW_TWrow - cswws
                "MsGarageRWB/cscws", // CW_SWrow - cscws
                "MsGarageRWB/csces", // CW_NWrow - csces
                "MsGarageRWB/csees", // CW_MWrow - csees

                "MsGarage121_1",
                "MsGarage33_1",
                "MsGarage19_1",
                "MsGarage11_1",
                "MsGarage40_1",
                "MsGarage43_1",
                "MsGarage99_1",
                "MsGarageX_1",

            };
            l.RemoveAll(item => !item.StartsWith(filter));
            return l;
        }
        public void AddSlotsRedwB(string subgname)
        {
            float xoff = 0;
            float zoff = 0;
            pctfullonstart = 0.9f;
            if (subgname.StartsWith("cs"))
            {
                xoff = 17.0f;
                zoff = 5.7f;
            }
            var rssn = true;
            var slotnameprefix = "g_RWB_" + subgname;
            switch(subgname)
            {
                case "nnw":
                    {
                        var v1 = new Vector3(-2013.3f, 0, -1263.0f);
                        var v2 = new Vector3(-2010.8f, 0, -1269.9f);
                        GenSlots(slotnameprefix,  4, v1, v2, resetSlotStartNumber: rssn, group: subgname, revOrd: true);
                        break;
                    }
                case "nnn":
                    {
                        var v1 = new Vector3(-2041.3f, 0, -1180.2f);
                        var v2 = new Vector3(-2014.2f, 0, -1260.7f);
                        GenSlots(slotnameprefix, 34, v1, v2, resetSlotStartNumber: rssn, group: subgname, revOrd:true);
                        break;
                    }
                case "eee":
                    {
                        var v1 = new Vector3(-2000.2f, 0, -1162.7f);
                        var v2 = new Vector3(-2034.1f, 0, -1173.1f);
                        GenSlots(slotnameprefix, 14, v1, v2, resetSlotStartNumber: rssn, group:subgname, revOrd: true);
                        break;
                    }

                case "sss":
                    {
                        //var v1 = new Vector3(-1968.5f, 0, -1243.0f);
                        var v1 = new Vector3(-1967.8f, 0, -1245.2f);
                        var v2 = new Vector3(-1995.4f, 0, -1164.6f);
                        GenSlots(slotnameprefix, 34, v1, v2, resetSlotStartNumber: rssn, group: subgname, revOrd: true);
                        break;
                    }
                case "ssw":
                    {
                        var v1 = new Vector3(-1964.8f, 0, -1254.0f);
                        var v2 = new Vector3(-1967.0f, 0, -1247.3f);
                        GenSlots(slotnameprefix,  4, v1, v2, resetSlotStartNumber: rssn, group: subgname, revOrd: true);
                        break;
                    }

                case "wsw":
                    {
                        var v1 = new Vector3(-1981.4f, 0, -1263.8f);
                        var v2 = new Vector3(-1972.5f, 0, -1261.0f);
                        GenSlots(slotnameprefix, 5, v1, v2, resetSlotStartNumber: rssn, group: subgname, revOrd: true);
                        break;
                    }
                case "wnw":
                    {
                        var v1 = new Vector3(-2006.0f, 0, -1272.5f);
                        var v2 = new Vector3(-1994.9f, 0, -1269.0f);
                        GenSlots(slotnameprefix, 6, v1, v2, resetSlotStartNumber: rssn, group: subgname, revOrd: true);
                        break;
                    }

                case "cnwwn": // CE_TErow - cnwwn
                    {
                        var v1 = new Vector3(-2002.33f + xoff, 0, -1257.9f + zoff);
                        var v2 = new Vector3(-2003.4f + xoff, 0,  -1254.9f + zoff);
                        GenSlots(slotnameprefix, 2, v1, v2, resetSlotStartNumber: rssn, group: subgname);
                        break;
                    }
                case "cswwn": // CW_TErow - cswwn
                    {
                        var v1 = new Vector3(-1985.3f, 0, -1251.8f);
                        var v2 = new Vector3(-1986.0f, 0, -1249.9f);// eyeballed
                        GenSlots(slotnameprefix, 1, v1, v2, resetSlotStartNumber: rssn, group: subgname);
                        break;
                    }
                case "cncwn": // CE_SErow - cncwn
                    {
                        var v1 = new Vector3(-2005.1f + xoff, 0, -1246.5f + zoff);
                        var v2 = new Vector3(-2013.0f + xoff, 0, -1224.8f + zoff);
                        GenSlots(slotnameprefix, 11, v1, v2, resetSlotStartNumber: rssn, group: subgname);
                        break;
                    }
                case "csccn": // CW_SErow - csccn
                    {
                        var v1 = new Vector3(-2005.1f + xoff, 0, -1246.5f + zoff);
                        var v2 = new Vector3(-1989.9f , 0, -1236.0f );// no offset because I eyeballed them
                        GenSlots(slotnameprefix, 3, v1, v2, resetSlotStartNumber: rssn, group: subgname);
                        break;
                    }
                case "cscwn": // CW_SErow - cscwn
                    {
                        var v1 = new Vector3(-1990.4f , 0, -1234.1f );// no offset because I eyeballed them
                        var v2 = new Vector3(-2013.0f + xoff, 0, -1224.8f + zoff);
                        GenSlots(slotnameprefix,7, v1, v2, resetSlotStartNumber: rssn, group: subgname);
                        break;
                    }

                case "cncen": // CE_NErow - cncen
                    {
                        var v1 = new Vector3(-2015.6f + xoff, 0, -1216.2f + zoff);
                        var v2 = new Vector3(-2022.86f + xoff, 0, -1194.7f + zoff);
                        GenSlots(slotnameprefix, 11, v1, v2, resetSlotStartNumber: rssn, group: subgname);
                        break;
                    }
                case "cscen": // CW_NErow - cscen
                    {
                        var v1 = new Vector3(-2015.6f + xoff, 0, -1216.2f + zoff);
                        var v2 = new Vector3(-2003.4f , 0, -1196.2f);// no offset because I eyeballed them
                        GenSlots(slotnameprefix, 7, v1, v2, resetSlotStartNumber: rssn, group: subgname);
                        break;
                    }
                case "cscdn": // CW_NErow - cscdn
                    {
                        var v1 = new Vector3(-2004.2f, 0, -1193.8f );
                        var v2 = new Vector3(-2005.85f, 0, -1189.1f);// no offset because I eyeballed them
                        GenSlots(slotnameprefix, 3, v1, v2, resetSlotStartNumber: rssn, group: subgname);
                        break;
                    }
                case "cneen": // CE_MErow - cneen
                    {
                        var v1 = new Vector3(-2025.2f + xoff, 0, -1186.5f + zoff);
                        var v2 = new Vector3(-2026.0f + xoff, 0, -1184.3f + zoff);
                        GenSlots(slotnameprefix, 2, v1, v2, resetSlotStartNumber: rssn, group: subgname);
                        break;
                    }
                case "cseen": // CW_MErow - cseen
                    {
                        var v1 = new Vector3(-2025.4f + xoff, 0, -1185.9f + zoff);
                        var v2 = new Vector3(-2026.3f + xoff, 0, -1183.2f + zoff);
                        GenSlots(slotnameprefix, 1, v1, v2, resetSlotStartNumber: rssn, group: subgname);
                        break;
                    }
                case "cnwws": // CE_TWrow - cnwws
                case "cswws": // CW_TWrow - cswws
                    {
                        var v1 = new Vector3(-1997.97f+xoff, 0, -1253.1f +zoff );
                        var v2 = new Vector3(-1996.8f+xoff, 0, -1256.1f +zoff );
                        GenSlots(slotnameprefix, 2, v1, v2, resetSlotStartNumber: rssn, group: subgname,revPos:true);
                        break;
                    }
                case "cncws": // CE_SWrow - cncws
                case "cscws": // CW_SWrow - cscws
                    {
                        var v1 = new Vector3(-2008.1f + xoff, 0, -1222.9f + zoff);
                        var v2 = new Vector3(-2000.06f + xoff, 0, -1244.78f + zoff);
                        GenSlots(slotnameprefix, 11, v1, v2, resetSlotStartNumber: rssn, group: subgname, revPos: true);
                        break;
                    }
                case "cnces": // CE_NWrow - cnces
                case "csces": // CW_NWrow - csces
                    {
                        var v1 = new Vector3(-2018.0f + xoff, 0, -1193.1f + zoff);
                        var v2 = new Vector3(-2010.8f + xoff, 0, -1214.7f + zoff);
                        GenSlots(slotnameprefix, 11, v1, v2, resetSlotStartNumber: rssn, group: subgname, revPos: true);
                        break;
                    }
                case "cnees": // CE_MWrow - cnees
                    {
                        var v1 = new Vector3(-2021.3f + xoff, 0, -1182.6f + zoff);
                        var v2 = new Vector3(-2020.6f + xoff, 0, -1184.9f + zoff);
                        GenSlots(slotnameprefix, 2, v1, v2, resetSlotStartNumber: rssn, group: subgname, revPos: true);
                        break;
                    }
                case "csees": // CW_MWrow - csees
                    {
                        var rev = subgname == "cnees";
                        var v1 = new Vector3(-2021.4f + xoff, 0, -1181.8f + zoff);
                        var v2 = new Vector3(-2020.6f + xoff, 0, -1184.2f + zoff);
                        GenSlots(slotnameprefix, 1, v1, v2, resetSlotStartNumber: rssn, group: subgname, revPos: true);
                        break;
                    }
            }
        }
        public void AddSlots()
        {
            //Debug.Log("Adding slots for " + name);
            carcount = 0; // start with the red car always
            string gname = this.fullname;
            if (gname.StartsWith("MsGarageRWB"))
            {
                if (gm.sman.curscene == SceneSelE.MsftB19focused || gm.sman.curscene == SceneSelE.MsftB121focused || gm.sman.curscene == SceneSelE.MsftB33focused)
                {
                    defPercentFull = 0.05f;
                }
                else
                {
                    defPercentFull = 0.75f;
                }
                AddSlotsRedwB(this.name);
                return;
            }
            switch (gname)
            {
                case "Eb12_block/west":
                    pctfullonstart = 0.6f;
                    GenSlots("g_b12_1", 3, 7.7f, 3.8f, 2.7f, 0.0f, 180);
                    GenSlots("g_b12_1", 4, 19.4f, 3.8f, 2.7f, 0.0f, 180,resetSlotStartNumber:false,slotsAlreadyIn:3);
                    break;
                case "Eb12_block/east":
                    pctfullonstart = 0.6f;
                    GenSlots("g_eb12_2", 1, 8.3f, -7.5f, 2.9f, 0.0f, 0);
                    GenSlots("g_eb12_2", 8,11.6f, -7.5f, 2.9f, 0.0f, 0,resetSlotStartNumber: false, slotsAlreadyIn: 1);
                    break;
                case "Eb12_Rewe_1":
                    {
                        var v1 = new Vector3(280.0f, 0, 118.0f);
                        var v2 = new Vector3(264.05f, 0, 147.7f);
                        GenSlots("g_rewe_1", 13, v1, v2);
                    }
                    break;
                case "Eb12_Rewe_2":
                    {
                        var v1 = new Vector3(235.6f, 0, 144.4f);
                        var v2 = new Vector3(241.7f, 0, 107.1f);
                        GenSlots("g_rewe_2", 17, v1, v2);
                    }
                    break;
                case "MsGarage19_1":
                    defPercentFull = 0.9f;
                    GenSlots("g_19_1", 15, -518.00f, 112.00f, 3.00f, 1.0f, 160);
                    break;
                case "MsGarage121_1":
                    defPercentFull = 0.9f;
                    GenSlots("g_121_1", 16, -836f, -542.00f, 1.12f, -3.0f, 70);
                    break;
                case "MsGarage33_1":
                    defPercentFull = 0.9f;
                    GenSlots("g_33_1", 8, -558.3f, 412.40f, -2.55f,-0.48f, -20);
                    break;
                case "MsGarage11_1":
                    GenSlots("g_11_1", 22, -102.35f, 247.10f, 3.00f, 1.0f,160);
                    break;
                case "MsGarage40_1":
                    GenSlots("g_40_1", 18, 199.29f, 99.13f, 2.515152f, 0.8284848f,160);
                    break;
                case "MsGarage43_1":
                    gprefix = "g43_1";
                    slotnumformat = "D3";
                    this.transform.position = Vector3.zero;
                    var group = gprefix;
                    AddSlot(0, 14.50f, 31.25f, 2f, group);
                    AddSlot(1, 16.74f, 31.18f, 1.5f,group);
                    AddSlot(2, 20.87f, 31.18f, 1f,group);
                    AddSlot(3, 23.09f, 31.18f, 0.5f, group);
                    AddSlot(4, 27.37f, 31.43f, -6f, group);
                    AddSlot(5, 30.07f, 31.43f, -8f, group);
                    AddSlot(6, 32.68f, 31.60f, -10f, group);
                    AddSlot(7, 35.42f, 32.06f, -16f, group);
                    AddSlot(8, 38.32f, 32.85f, -20f, group);
                    AddSlot(9, 40.89f, 33.85f, -24f, group);
                    AddSlot(10, 43.46f, 34.97f, -26f, group);
                    AddSlot(11, 45.95f, 36.33f, -30f, group);
                    AddSlot(12, 48.32f, 37.82f, -34f, group);
                    AddSlot(13, 50.48f, 39.34f, -36f, group);
                    AddSlot(14, 52.66f, 41.01f, -38f, group);
                    break;
                case "MsGarage99_1":
                    GenSlots("g_99_1", 17, -132.23f, -557.94f, 2.515152f, 0.4f, 170);
                    break;
                case "MsGarageX_1":
                    GenSlots("g_X_1", 13, -139.84f, -165.13f, 2.515152f, 0f, 180);
                    break;
                case "MsDublin1":
                    {
                        var v1 = new Vector3(53.6f, 0, 20f);
                        var v2 = new Vector3(44.0f, 0, 51.0f);
                        GenSlots("g_ms_dub", 13, v1, v2);
                        break;
                    }
            }
        }
        public void DeleteGos()
        {
            if (miscgo!=null)
            {
                Destroy(miscgo);
                miscgo = null;
            }
            foreach (var slt in slots.Keys)
            {
                slots[slt].DeleteGos();
            }
        }
        public void CreateGos()
        {
            miscgo = new GameObject("misc");
            miscgo.transform.parent = transform;

            if (gm.garageDefinitionMarkersShown)
            {
                var ptgo1 = GraphAlgos.GraphUtil.CreateMarkerSphere(name+" p1 - start", zpt1, clr: "darkgreen", size:0.5f);
                //Debug.Log("Made pt1go " + ptgo1.name + " zpt1:" + zpt1.ToString("f3"));
                var ptgo2 = GraphAlgos.GraphUtil.CreateMarkerSphere(name+" p2 - stop", zpt2, clr: "darkred", size: 0.5f);
                ptgo1.transform.parent = miscgo.transform;
                ptgo2.transform.parent = miscgo.transform;

                var wlkgo = GraphAlgos.GraphUtil.CreateMarkerSphere(name + " wlknode", wlkpt, clr: "magenta", size: 0.5f);
                //Debug.Log("Made pt1go " + ptgo1.name + " zpt1:" + zpt1.ToString("f3"));
                var drvgo = GraphAlgos.GraphUtil.CreateMarkerSphere(name + " drvnode", drvpt, clr: "brown", size: 0.5f);
                wlkgo.transform.parent = miscgo.transform;
                drvgo.transform.parent = miscgo.transform;

            }

            foreach (var slt in slots.Keys)
            {
                slots[slt].CreateGos();
            }
        }
        //void Start()
        //{
        //}

        //// Update is called once per frame
        //void Update()
        //{
        //    //if (  oldshowcarrects != showCarRects )
        //    //{
        //    //    DeleteGos();
        //    //    CreateGos();
        //    //    oldshowcarrects = showCarRects;
        //    //}
        //}
    }
}