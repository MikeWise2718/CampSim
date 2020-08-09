using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;  // just for mathf and vector3?
using CampusSimulator;

namespace GraphAlgos
{
    public enum graphSceneE
    {
        gen_none, gen_circ, gen_sphere, gen_b43_1, gen_b43_2, gen_b43_3, gen_b43_4, gen_b43_1p2,
        gen_bho, gen_small, gen_redwb_3, gen_json_file, gen_campus, gen_eb12, gen_eb12_json, gen_eb12_small,
        gen_dublin,gen_tukwila,gen_tenmtn
    };

    public class GenGlobeParameters
    {
        public int nlng;
        public int nlat;
        public float radius;
        public float height;
        public GenGlobeParameters(int nlng = 12, int nlat = 12, float radius = 10, float height = 10)
        {
            this.nlng = nlng;
            this.nlat = nlat;
            this.radius = radius;
            this.height = height;
        }
    }
    public class GenCircParameters
    {
        public int npoints;
        public float radius;
        public float height;

        public GenCircParameters(int npoints = 6, float radius = 10, float height = 0)
        {
            this.npoints = npoints;
            this.radius = radius;
            this.height = height;
        }
    }
    public class GenFileParameters
    {
        public string fullfilename;

        public GenFileParameters()
        {
            this.fullfilename = "";
        }
        public string getFullFileName()
        {
            string rv = fullfilename;
            return rv;
        }
    }
    public class MapGenParameters
    {
        public GenGlobeParameters glopar = new GenGlobeParameters();
        public GenCircParameters circpar = new GenCircParameters();
        public GenFileParameters filepar = new GenFileParameters();
    }
    public class LcMapMaker
    {
        GraphCtrl grc;
        MapGenParameters mgp = new MapGenParameters();
        LcMapData lmd;
        public LcMapMaker(GraphCtrl grc, MapGenParameters mgp = null)
        {
            if (mgp != null)
            {
                this.mgp = mgp;
            }
            this.grc = grc;
            lmd = new LcMapData(this,grc);
        }
        static Dictionary<string, int> modelcount = new Dictionary<string, int>();
        public static void Reset()
        {
            modelcount = new Dictionary<string, int>();
        }
        public string getmodelprefix(string modelprefix, bool forcecount = false)
        {
            if (modelcount.ContainsKey(modelprefix))
            {
                var ncount = modelcount[modelprefix]++;
                return modelprefix + (ncount + 1) + "-";
            }
            else
            {
                modelcount[modelprefix] = 0;
                if (forcecount)
                {
                    return modelprefix + "0-";
                }
                else
                {
                    return modelprefix;
                }
            }
        }
        public int maxVoiceKeywords = 100;
        public int nVoiceKeywords = 0;

   
        public bool voiceEnabled(string roomname)
        {
            return grc.nodekeywords.Values.Contains<string>(roomname);
        }
        public void addRedwestB3names(string template)
        {
            grc.nodekeywords.Add("lobby 1", "f01-st-st1");
            grc.nodekeywords.Add("brad", template + "3271");
            grc.nodekeywords.Add("brent", template + "3279");
            grc.nodekeywords.Add("sue", template + "3281");
            grc.nodekeywords.Add("laura", template + "3342");
            grc.nodekeywords.Add("simon", template + "3336");
            grc.nodekeywords.Add("travis", template + "3358");
            grc.nodekeywords.Add("scott", template + "3072");
            grc.nodekeywords.Add("J D", template + "3182");
            grc.nodekeywords.Add("dina", template + "3189");
            grc.nodekeywords.Add("pradeep", template + "3309");
            grc.nodekeywords.Add("bill", template + "3231");
            grc.nodekeywords.Add("mark", template + "3370");
            grc.nodekeywords.Add("fred pace", template + "3372");
            grc.nodekeywords.Add("kiyoshi", template + "3377");
            grc.nodekeywords.Add("liz", template + "3380");
            grc.nodekeywords.Add("tyson", template + "3362");
            grc.nodekeywords.Add("brigitte", template + "3191");
            grc.nodekeywords.Add("spyros", template + "3210");
            grc.nodekeywords.Add("bruce", template + "3258");
            grc.nodekeywords.Add("rimes", template + "3256");
            grc.nodekeywords.Add("rhymes", template + "3256");
            grc.nodekeywords.Add("ramesh", template + "3170");
            grc.nodekeywords.Add("anand", template + "3254");
            grc.nodekeywords.Add("peter", template + "3353");
            grc.nodekeywords.Add("marc merc", template + "3268");
            grc.nodekeywords.Add("kitchen", template + "3033");
            grc.nodekeywords.Add("printer", template + "3399");
            grc.nodekeywords.Add("central stairs", template + "3033");
            grc.nodekeywords.Add("elevator", template + "3033");
            grc.nodekeywords.Add("mens room", template + "3393");
            grc.nodekeywords.Add("womans room", template + "3039");
        }
        public static string voiceEnabledRooms = "3271,3279,3281,3342,3336,3358,3072,3182,3189,3309,3231,3370,3372,3377,3380,3362,3191,3210,3258,3256,3170,3254,3353,3268,3144,3146";
        public void addVoiceKeywords(string template)
        {
            int ntotadded = 0;
            int nwildadded = 0;
            int nmustadd = voiceEnabledRooms.Split(',').Count<string>();
            int wildtoadd = maxVoiceKeywords - nmustadd;
            foreach (var nname in grc.nodenamelist)
            {
                if (nname.StartsWith(template))
                {
                    var snum = nname.Remove(0, template.Length);
                    var key = "room " + snum;
                    bool mustadd = voiceEnabledRooms.IndexOf(snum) >= 0;
                    if (mustadd || nwildadded < wildtoadd)
                    {
                        grc.nodekeywords.Add(key, nname);
                        ntotadded += 1;
                        if (!mustadd) nwildadded += 1;
                    }
                    // GraphUtil.Log("Key:" + key + "  Node:" + nname);
                }
            }
            // GraphUtil.Log("Added " + ntotadded + " voice keywords - wildones:" + nwildadded);
            // GraphUtil.Log( "  wildtoadd:" + wildtoadd + "  maxVoiceKeywords:" + maxVoiceKeywords);

            nVoiceKeywords = ntotadded;
            // GraphUtil.Log("Added " + ntotadded + " voice keywords - wildones:" + nwildadded);
        }
        public void CreatePointsForTukwila()
        {
            //lc.SetCurUseType(LcUseType.driveway);
            //lc.AddNodePtxy("tuk-ssm-dw00", -1, 4.4);
            //lc.LinkTooPtxz("tuk-ssm-dw01", -1, -60.7);
            grc.regman.SetRegion("tukwila");

            grc.SetCurUseType(LinkUse.sewerpipe);
            grc.AddNodePtxz("tuk-ssm-sp00", -1.5, 4.4);
            grc.LinkToPtxz("tuk-ssm-sp01", -1.5, -10.0);
            grc.LinkToPtxz("tuk-ssm-sp02", -1.5, -60.7);
            grc.NewAnchorLinkToxz("tuk-ssm-sp01", "tuk-ssm-sp11", -7.6, -16.42);
            grc.LinkToPtxz("tuk-ssm-sp12", -18.79, -20.23);
            grc.NewAnchorLinkToxz("tuk-ssm-sp01", "tuk-ssm-sp21", 8.0, -14.0);

            grc.SetCurUseType(LinkUse.marker);
            grc.AddNodePtxz("tuk-ssm-mk00", -13.73, -17.8);
            grc.LinkToPtxz("tuk-ssm-mk01", -13.73, -10.1);
            grc.LinkToPtxz("tuk-ssm-mk02", -8.31, -6.53);
            grc.LinkToPtxz("tuk-ssm-mk03", -8.31, -14.2);
            grc.AddLinkByNodeName("tuk-ssm-mk03", "tuk-ssm-mk00");

            grc.SetCurUseType(LinkUse.elecpipe);
            grc.AddNodePtxz("tuk-ssm-el01", 60, -69.0);
            grc.LinkToPtxz("tuk-ssm-el02", 20, -69.0);
            grc.LinkToPtxz("tuk-ssm-el02", 8.01, -29.0);
            grc.LinkToPtxz("tuk-ssm-lp00", 5.6, -29.0);
            grc.LinkToPtxz("tuk-ssm-el03", -9.5, -29.1);
            grc.LinkToPtxz("tuk-ssm-el04", -9.5, -12.6);
            grc.LinkToPtxz("tuk-ssm-el05", -11.25, -12.6);

            grc.SetCurUseType(LinkUse.commspipe);
            grc.AddNodePtxz("tuk-ssm-cm00", -12.44, -10.65);
            grc.LinkToPtxz("tuk-ssm-cm01", -12.44, -12.91);
            grc.LinkToPtxz("tuk-ssm-cm02", -12.44, -89.5);
            grc.regman.SetRegion("default");
        }

        public void CreatePointsForTenMtn()
        {
            //lc.SetCurUseType(LcUseType.driveway);
            //lc.AddNodePtxy("tuk-ssm-dw00", -1, 4.4);
            //lc.LinkTooPtxz("tuk-ssm-dw01", -1, -60.7);
            grc.regman.NewNodeRegion("tenmtn-x","blue",false);
            grc.AddNodePtll("found-spot-dog", 47.520250, -121.721548); // where she was found
            grc.LinkToPtll("found-spot", 47.520249, -121.721548); // where she was found
            grc.AddLinkByNodeName("found-spot", "reg:tenmtn", LinkUse.walkway);
            grc.AddNodePtll("lastseen-spot-dog", 47.507195, -121.698050); // where she was found
            grc.LinkToPtll("lastseen-spot", 47.507194, -121.698050); // where she was found
            grc.AddLinkByNodeName("lastseen-spot", "reg:tenmtn", LinkUse.walkway);

            //grc.AddNodePtll("llmd", 47.5016149, -121.7083454);// these are just for debugging the ll->xz mapping
            //grc.LinkToPtll( "llul", 47.5465240, -121.7748213);
            //grc.LinkToPtll( "llur", 47.5465240, -121.6418695);
            //grc.LinkToPtll( "llbr", 47.4567059, -121.6418695);
            //grc.LinkToPtll( "llbl", 47.4567059, -121.7748213);



            //grc.SetCurUseType(LinkUse.sewerpipe);
            //grc.AddNodePtxz("tuk-ssm-sp00", -1.5, 4.4);
            //grc.LinkToPtxz("tuk-ssm-sp01", -1.5, -10.0);
            //grc.LinkToPtxz("tuk-ssm-sp02", -1.5, -60.7);
            //grc.NewAnchorLinkToxz("tuk-ssm-sp01", "tuk-ssm-sp11", -7.6, -16.42);
            //grc.LinkToPtxz("tuk-ssm-sp12", -18.79, -20.23);
            //grc.NewAnchorLinkToxz("tuk-ssm-sp01", "tuk-ssm-sp21", 8.0, -14.0);

            //grc.SetCurUseType(LinkUse.marker);
            //grc.AddNodePtxz("tuk-ssm-mk00", -13.73, -17.8);
            //grc.LinkToPtxz("tuk-ssm-mk01", -13.73, -10.1);
            //grc.LinkToPtxz("tuk-ssm-mk02", -8.31, -6.53);
            //grc.LinkToPtxz("tuk-ssm-mk03", -8.31, -14.2);
            //grc.AddLinkByNodeName("tuk-ssm-mk03", "tuk-ssm-mk00");

            //grc.SetCurUseType(LinkUse.elecpipe);
            //grc.AddNodePtxz("tuk-ssm-el01", 60, -69.0);
            //grc.LinkToPtxz("tuk-ssm-el02", 20, -69.0);
            //grc.LinkToPtxz("tuk-ssm-el02", 8.01, -29.0);
            //grc.LinkToPtxz("tuk-ssm-lp00", 5.6, -29.0);
            //grc.LinkToPtxz("tuk-ssm-el03", -9.5, -29.1);
            //grc.LinkToPtxz("tuk-ssm-el04", -9.5, -12.6);
            //grc.LinkToPtxz("tuk-ssm-el05", -11.25, -12.6);

            //grc.SetCurUseType(LinkUse.commspipe);
            //grc.AddNodePtxz("tuk-ssm-cm00", -12.44, -10.65);
            //grc.LinkToPtxz("tuk-ssm-cm01", -12.44, -12.91);
            //grc.LinkToPtxz("tuk-ssm-cm02", -12.44, -89.5);
            grc.regman.SetRegion("default");
        }

        public void CreateEb12GarageLinks()
        {
            grc.regman.SetRegion("default"); // as long as the garages are defined in code, their links probably should be too

            CreateGarageLinks("Eb12_block/west", "eb12-oso02", "eb12-dw02",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 5f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.front, w_len: 5f);

            CreateGarageLinks("Eb12_block/east", "eb12-oso04", "eb12-dw02",
            d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 5f,
            w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 5f);

            // lc.regman.SetRegion("eb12-retail");
            CreateGarageLinks("Eb12_Rewe_1", "eb12-rw04", "eb12-rw04",
            d_order: connectOrderE.dec, d_exit: exitDirE.back, d_len: 6f,
            w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);

            CreateGarageLinks("Eb12_Rewe_2", "eb12-rewe-os21", "eb12-rw01",
            d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 6f,
            w_order: connectOrderE.inc, w_exit: exitDirE.back, w_len: 4f);
        }
        public void CreatePointsForDublin()
        {
            grc.yfloor = 0;
            grc.AddNodePtxz("dub-oso01", 32.0f, 24f);
            grc.LinkToPtxz("dub-oso02", 46.9f,14.7f);

            grc.AddNodePtxz("dub-dw01", 38.8f, 49.7f);
            grc.LinkToPtxz("dub-dw02", 37.3f, 56.1f);
        }

  
        public void CreateCircPoints(int npoints = 10, float rad = 5.0f, float heit = 0)
        {
            grc.gm.initmods();
            grc.gm.mod_name_pfx = getmodelprefix("circ-", forcecount: true);
            var ooname = "Node-0";
            var oname = "";
            for (int i = 0; i < npoints; i++)
            {
                var nname = "Node-" + i;
                float ang = Mathf.PI * (360f * i / npoints) / 180;
                var z = rad * Mathf.Sin(ang);
                var x = rad * Mathf.Cos(ang);
                var y = heit;
                var pt = new Vector3(x, y, z);
                grc.AddNode(nname, pt);
                if (i > 0)
                {
                    var lname = "Link-" + i;
                    grc.AddLinkByNodeName(oname, nname, lname);
                }
                oname = nname;
            }
            grc.AddLinkByNodeName(oname, ooname, "Link-0");
        }
        public void CreateSpherePoints(int nlng = 10, int nlat = 10, float rad = 5.0f, float heit = 0)
        {
            grc.gm.initmods();
            grc.gm.mod_name_pfx = getmodelprefix("sph-", forcecount: true);
            var optar = new LcNode[nlng, nlat];
            for (int i = 0; i < nlat; i++)
            {
                float alat = Mathf.PI * (90 - (i * 180f / (nlat - 1))) / 180;
                float y = rad * Mathf.Sin(alat) + heit;
                float crad = rad * Mathf.Cos(alat);
                for (int j = 0; j < nlng; j++)
                {
                    float alng = Mathf.PI * (j * 360f / nlng) / 180;
                    float z = crad * Mathf.Sin(alng);
                    float x = crad * Mathf.Cos(alng);
                    var pt = new Vector3(x, y, z);
                    var pname = "pt." + i.ToString() + "." + j.ToString();
                    LcNode npt = grc.AddNode(pname, pt);
                    optar[i, j] = npt;
                }
            }
            for (int i = 0; i < nlat; i++)
            {
                for (int j = 0; j < nlng; j++)
                {
                    var jto = (j + 1) % nlng;
                    var lname = "lk.h." + i + "." + j;
                    grc.AddLink(lname, optar[i, j], optar[i, jto]);
                    if (i > 0)
                    {
                        var lname1 = "lk.v." + i + "." + j;
                        grc.AddLink(lname1, optar[i - 1, j], optar[i, j]);
                    }
                }
            }
        }
        public void AddBhoRooms()
        {
            grc.addRoomLink("4092", 27.6f, -11.4f, "NA");
            grc.addRoomLink("4093", 55.3f, -24.8f, "NA");
            grc.addRoomLink("4094", 30.0f, 22.8f, "NA");
            grc.addRoomLink("4095", 26.7f, 3.3f, "NA");

            grc.addRoomLink("FrontDesk", 33.76f, -6.5f, "NA");
            grc.addRoomLink("Elevator 1", 40.1f, -13.3f, "Elevator");
            grc.addRoomLink("Elevator 2", 42.2f, -13.3f, "NA");
            grc.addRoomLink("Stairs401", 38.0f, -10.0f, "NA");
            grc.addRoomLink("Stairs402", 28.4f, -8.3f, "NA");
            grc.addRoomLink("Stairs404", 36.0f, 24.3f, "NA");


            grc.addRoomLink("4003", 32.0f, -14.0f, "NA");
            grc.addRoomLink("4004", 32.0f, -15.6f, "NA");
            grc.addRoomLink("4005", 34.0f, -25.2f, "NA");
            grc.addRoomLink("4006", 40.2f, -28.7f, "NA");
            grc.addRoomLink("4007", 46.6f, -32.1f, "NA");
            grc.addRoomLink("4008", 50.6f, -32.7f, "NA");
            grc.addRoomLink("4009", 50.1f, -25.6f, "NA");
            grc.addRoomLink("4010", 48.3f, -23.7f, "NA");
            grc.addRoomLink("4011", 53.8f, -21.1f, "NA");
            grc.addRoomLink("4012", 49.2f, -22.4f, "NA");
            grc.addRoomLink("4014", 54.0f, -16.6f, "NA");
            grc.addRoomLink("4016", 54.1f, -9.9f, "NA");
            grc.addRoomLink("4017", 47.1f, -9.9f, "NA");
            grc.addRoomLink("4018", 50.7f, -7.3f, "NA");
            grc.addRoomLink("4019", 55.0f, -0.1f, "NA");
            grc.addRoomLink("4020", 50.4f, -2.1f, "NA");
            grc.addRoomLink("4021", 47.8f, -2.1f, "NA");
            grc.addRoomLink("4022", 43.6f, -4.0f, "NA");
            grc.addRoomLink("4023", 39.3f, -2.2f, "NA");
            grc.addRoomLink("4024", 37.7f, -2.2f, "NA");
            grc.addRoomLink("4026", 35.2f, -2.0f, "Mens room");
            grc.addRoomLink("4027", 33.2f, -2.0f, "NA");
            grc.addRoomLink("4028", 31.2f, -1.5f, "Womens room");
            grc.addRoomLink("4029", 28.2f, -6.0f, "NA");
            grc.addRoomLink("4030", 28.2f, -4.0f, "NA");
            grc.addRoomLink("4031", 37.4f, 3.5f, "NA");
            grc.addRoomLink("4032", 40.6f, 1.6f, "NA");
            grc.addRoomLink("4033", 43.7f, 1.7f, "NA");
            grc.addRoomLink("4034", 41.9f, 4.4f, "NA");
            grc.addRoomLink("4035", 45.7f, 4.4f, "NA");
            grc.addRoomLink("4036", 48.0f, 1.1f, "NA");
            grc.addRoomLink("4037", 51.3f, 1.1f, "NA");
            grc.addRoomLink("4038", 51.3f, 5.2f, "NA");
            grc.addRoomLink("4039", 49.6f, 6.5f, "NA");
            grc.addRoomLink("4040", 49.6f, 10.6f, "NA");
            grc.addRoomLink("4042", 53.9f, 13.3f, "NA");
            grc.addRoomLink("4043", 49.6f, 12.0f, "NA");
            grc.addRoomLink("4044", 48.0f, 15.0f, "NA");
            grc.addRoomLink("4045", 47.4f, 17.2f, "NA");
            grc.addRoomLink("4046", 55.0f, 23.7f, "NA");
            grc.addRoomLink("4047", 50.9f, 22.2f, "Mens Room 2");
            grc.addRoomLink("4048", 49.0f, 21.4f, "NA");
            grc.addRoomLink("4049", 47.1f, 22.2f, "Womans Room 2");
            grc.addRoomLink("4050", 44.6f, 21.4f, "NA");
            grc.addRoomLink("4051", 41.1f, 21.4f, "NA");
            grc.addRoomLink("4052", 43.2f, 18.8f, "NA");
            grc.addRoomLink("4053", 39.0f, 18.8f, "NA");
            grc.addRoomLink("4054", 38.0f, 21.4f, "NA");
            grc.addRoomLink("4055", 35.0f, 21.4f, "NA");
            grc.addRoomLink("4056", 33.1f, 25.8f, "NA");
            grc.addRoomLink("4057", 33.7f, 28.4f, "NA");
            grc.addRoomLink("4058", 41.6f, 25.3f, "NA");
            grc.addRoomLink("4059", 47.0f, 25.7f, "NA");
            grc.addRoomLink("4060", 51.3f, 25.7f, "NA");



        }
        public void CreatePointsForBho()
        {
            grc.gm.initmods();
            grc.yfloor = 0;

            float[] Fz = { -30.23f, -27.81f, -23.21f, -11.4f, -7.81f, -0.4f, 23.2f };
            float[] Fx = { 30.0f, 33.9f, 35.0f, 48.5f, 52.3f };
            grc.gm.mod_name_pfx = getmodelprefix("bho-f05-");
            grc.AddNodePtxz("cv1-s", Fx[0], Fz[5]);
            grc.LinkToPtxz("cv1-e", Fx[0], Fz[4], lname: "cv1");
            grc.LinkToPtxz("cv1-d", Fx[2], Fz[3], lname: "cd1");
            grc.LinkToPtxz("cv2-e", Fx[2], Fz[2], lname: "cv2");
            grc.LinkToPtxz("ch1-e", Fx[3], Fz[0], lname: "ch1");
            grc.LinkToPtxz("cd2-3", Fx[4], Fz[1], lname: "cd2");
            grc.LinkToPtxz("cv3-e", Fx[4], Fz[3], lname: "cv3");
            grc.LinkToPtxz("cv4-e", Fx[4], Fz[5], lname: "cv4");
            grc.LinkToPtxz("cv5-e", Fx[4], Fz[6], lname: "cv5");
            grc.LinkToPtxz("ch4-e", Fx[1], Fz[6], lname: "ch4");

            grc.AddLinkByNodeName("cv1-d", "cv3-e", "ch2");
            grc.AddLinkByNodeName("cv1-s", "cv4-e", "ch3");

            grc.addSpurLink("out92", 31.3f, -10.8f);
            grc.addSpurLink("out93", 55.0f, -22.6f);
            grc.addSpurLink("out91a", 36.8f, 2.7f);
            grc.addSpurLink("out91b", 34.1f, 3.7f);
            grc.addSpurLink("out91c", 30.1f, 3.7f);

            grc.addSpurLink("4044", 48.4f, 16.0f);
            grc.addSpurLink("4050", 43.2f, 21.4f);
            grc.addSpurLink("4054", 39.0f, 21.4f);

            AddBhoRooms();

        }
 
        public void GenCampusGarageLinks()
        {
            grc.regman.SetRegion("default"); // as long as the garages are defined in code, their links probably should be too

            //// Garage 11
            //CreateGarageLinks("MsGarage11_1", "b11-os1-o03", "dw-B11-c01",
            //              d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 5f,
            //              w_order: connectOrderE.inc, w_exit: exitDirE.back, w_len: 7f);

            // Garage 121
            CreateGarageLinks("MsGarage121_1", "b121-os1-o005", "b121-dw-d01",
                          d_order: connectOrderE.dec, d_exit: exitDirE.front, d_len: 5f,
                          w_order: connectOrderE.inc, w_exit: exitDirE.back, w_len: 7f);

            // Garage 19
            CreateGarageLinks("MsGarage19_1", "b19-os1-o03", "dw-B19-c02",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 5f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.front, w_len: 7f);

            // Garage 40
            CreateGarageLinks("MsGarage40_1", "b40-os1-o03", "dw-B40-c01",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 7f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.front, w_len: 5f);

            // Garage 43
            CreateGarageLinks("MsGarage43_1", "b43-os1-o06", "dw-B43-c04",
                          d_order: connectOrderE.dec, d_exit: exitDirE.back, d_len: 7f,
                          w_order: connectOrderE.inc, w_exit: exitDirE.front, w_len: 5f);

            // Studio X
            CreateGarageLinks("MsGarageX_1", "bSX-os1-o00", "dw-SX-o01",
                          d_order: connectOrderE.dec, d_exit: exitDirE.back, d_len: 7f,
                          w_order: connectOrderE.inc, w_exit: exitDirE.front, w_len: 5f);


            // B99
            CreateGarageLinks("MsGarage99_1", "b99-os1-o04", "dw-b99-o00",
                          d_order: connectOrderE.dec, d_exit: exitDirE.back, d_len: 7f,
                          w_order: connectOrderE.inc, w_exit: exitDirE.front, w_len: 5f);

            // Redwest B
            CreateGarageLinks("MsGarageRWB/eee", "bRWB-os1-o05", "dw-RWB-c18",
                          d_order: connectOrderE.dec, d_exit: exitDirE.back, d_len: 7f,
                          w_order: connectOrderE.inc, w_exit: exitDirE.back, w_len: 4f);

            CreateGarageLinks("MsGarageRWB/nnn", "bRWB-os1-o05", "dw-RWB-c31",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 7f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);


            CreateGarageLinks("MsGarageRWB/nnw", "bRWB-os1-o05", "dw-RWB-c31",
                           d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 7f,
                           w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);

            CreateGarageLinks("MsGarageRWB/wnw", "bRWB-os1-o10", "dw-RWB-c06",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 7f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);




            CreateGarageLinks("MsGarageRWB/cneen", "bRWB-os1-o05", "dw-RWB-c38",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 6f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);

            CreateGarageLinks("MsGarageRWB/cncen", "bRWB-os1-o05", "dw-RWB-c36",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 6f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);

            CreateGarageLinks("MsGarageRWB/cncwn", "bRWB-os1-o05", "dw-RWB-c34",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 6f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);

            CreateGarageLinks("MsGarageRWB/cnwwn", "bRWB-os1-o05", "dw-RWB-c31",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 7f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);


            CreateGarageLinks("MsGarageRWB/csees", "bRWB-os1-o07", "dw-RWB-c18",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 6f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);

            CreateGarageLinks("MsGarageRWB/csces", "bRWB-os1-o07", "dw-RWB-c16",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 6f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);

            CreateGarageLinks("MsGarageRWB/cscws", "bRWB-os1-o07", "dw-RWB-c14",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 6f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);

            CreateGarageLinks("MsGarageRWB/cswws", "bRWB-os1-o07", "dw-RWB-c12",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 7f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);


            CreateGarageLinks("MsGarageRWB/sss", "bRWB-os1-o07", "dw-RWB-c11",
                          d_order: connectOrderE.dec, d_exit: exitDirE.back, d_len: 7f,
                          w_order: connectOrderE.inc, w_exit: exitDirE.back, w_len: 4f);

            CreateGarageLinks("MsGarageRWB/ssw", "bRWB-os1-o07", "dw-RWB-c11",
                           d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 7f,
                           w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);

            CreateGarageLinks("MsGarageRWB/wsw", "bRWB-os1-o09", "dw-RWB-c06",
                          d_order: connectOrderE.dec, d_exit: exitDirE.back, d_len: 7f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);



            CreateGarageLinks("MsGarageRWB/cnees", "bRWB-os1-o06", "dw-RWB-c28",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 6f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);

            CreateGarageLinks("MsGarageRWB/cnces", "bRWB-os1-o06", "dw-RWB-c26",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 6f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);

            CreateGarageLinks("MsGarageRWB/cncws", "bRWB-os1-o06", "dw-RWB-c24",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 6f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);

            CreateGarageLinks("MsGarageRWB/cnwws", "bRWB-os1-o06", "dw-RWB-c06",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 7f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);



            CreateGarageLinks("MsGarageRWB/cseen", "bRWB-os1-o06", "dw-RWB-c28",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 6f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);

            CreateGarageLinks("MsGarageRWB/cscen", "bRWB-os1-o06", "dw-RWB-c26",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 6f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);

            CreateGarageLinks("MsGarageRWB/cscdn", "bRWB-os1-o06", "dw-RWB-c26",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 6f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);


            CreateGarageLinks("MsGarageRWB/cscwn", "bRWB-os1-o06", "dw-RWB-c24",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 6f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);

            CreateGarageLinks("MsGarageRWB/csccn", "bRWB-os1-o06", "dw-RWB-c22",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 6f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);

            CreateGarageLinks("MsGarageRWB/cswwn", "bRWB-os1-o06", "dw-RWB-c06",
                          d_order: connectOrderE.inc, d_exit: exitDirE.back, d_len: 7f,
                          w_order: connectOrderE.dec, w_exit: exitDirE.back, w_len: 4f);

        }

        void AddRedwestCalibrationMarkers()
        {
            var cman = GameObject.FindObjectOfType<CalibMan>();
            if (cman != null)
            {
                cman.org = new Vector3(-2035.0f, 0, -1176.6f);
                cman.AddCalibMarker("Pt0", -2028.51, 0, -1183.76, "green");
                cman.AddCalibMarker("Pt1", -2030.95, 0, -1175, "green");
                cman.AddCalibMarker("Pt2", -2036.50, 0, -1185.4, "green");
                cman.AddCalibMarker("Pt0a", -2027.1, 0, -1188.5, "green");
                cman.AddCalibMarker("Pt2a", -2016.8, 0, -1218.5, "green");
                cman.AddCalibMarker("Pt2b", -2007.8, 0, -1270.1, "green");
                cman.AddCalibMarker("Pt0c", -2000.3, 0, -1213.3, "green");
                cman.AddCalibMarker("Pt1a", -1998.4, 0, -1164.2, "green");
                cman.AddCalibMarker("Pt1b", -2010.6, 0, -1183.2, "green");
                cman.AddCalibMarker("Pt3", -1977.1, 0, -1250.3, "green");
                cman.AddCalibMarker("Pt4", -1981.33, 0, -1253.31, "green");
                cman.AddCalibMarker("Pt5", -1998.99, 0, -1259.28, "green");
                cman.AddCalibMarker("Pt6", -1991.55, 0, -1265.88, "green");
                cman.AddCalibMarker("Pt7", -1980.75, 0, -1240.05, "green");
                cman.AddCalibMarker("Pt8", -1969.19, 0, -1256.69, "green");
                cman.AddCalibMarker("Pt11", -1987.25, 0, -1253.84, "darkgreen");
                cman.AddCalibMarker("Pt12", -1988.50, 0, -1249.10, "darkgreen");
                cman.AddCalibMarker("Pt13", -1990.52, 0, -1243.25, "darkgreen");
                cman.AddCalibMarker("Pt14", -1994.76, 0, -1256.47, "darkgreen");
                cman.AddCalibMarker("Pt15", -1995.53, 0, -1251.63, "darkgreen");
                cman.AddCalibMarker("Pt16", -1997.62, 0, -1245.90, "darkgreen");
                cman.AddCalibMarker("Pt17", -2004.17, 0, -1259.71, "darkgreen");
                cman.AddCalibMarker("Pt18", -2006.02, 0, -1255.47, "darkgreen");
                cman.AddCalibMarker("Pt19", -2007.77, 0, -1249.87, "darkgreen");
            }
        }



        //public void AddCalibrationMarker(string name,Vector3 org,double x,double y,double z,string clrname)
        //{
        //    var pname = "CalibMarkers";
        //    var parent = GameObject.Find(pname);
        //    if (parent==null)
        //    {
        //        parent = new GameObject(pname);
        //        parent.AddComponent<CalibMan>();
        //    }
        //    var cman = parent.GetComponent<CalibMan>();
        //    cman.AddCalibMarker(name, (float)x, (float)y, (float)z, "green");
        //}

        public enum connectOrderE { dec, inc };
        public enum exitDirE { front, back };
        public void CreateGarageLinks(string gname, string walknode, string drivenode,
                                   connectOrderE d_order = connectOrderE.dec, exitDirE d_exit = exitDirE.back, float d_len = 6f,
                                   connectOrderE w_order = connectOrderE.inc, exitDirE w_exit = exitDirE.front, float w_len = 6f)
        {
            var gm = GameObject.FindObjectOfType<GarageMan>();
            var garage = gm.GetGarage(gname);
            if (garage == null)
            {
                Debug.Log("Garage " + gname + " not found in CreateGarageLinks");
                return;
            }
            int nslots = garage.slotnames.Count;
            var pslotnodename = new string[nslots];
            var pslotpos = new Vector3[nslots];

            garage.SetWalkAndDriveNodes(walknode, drivenode);


            //Debug.Log("Creating links for " + gname);

            // add parking slot nodes and set them as connected
            grc.SetCurUseType(LinkUse.driveway);
            for (int i = 0; i < nslots; i++)
            {
                pslotnodename[i] = garage.SlotNameNode(i);
                pslotpos[i] = garage.GetSlotPosition(i);
                grc.AddNodePtxz(pslotnodename[i], pslotpos[i].x, pslotpos[i].z);
                garage.SetConnectedToGrid(pslotnodename[i]);
            }

            // do drive paths
            grc.SetCurUseType(LinkUse.driveway);
            var d_nodeprev = (d_order == connectOrderE.dec ? "" : drivenode);
            var d_ang = (d_exit == exitDirE.front ? 0 : 180);
            for (int i = 0; i < nslots; i++)
            {
                var d_pslotnodename = garage.SlotAxuxNodeName("dps", i);
                var d_slotpos = garage.GetSlotPosition1(i, d_ang, d_len);
                grc.NewAnchorLinkToxz(pslotnodename[i], d_pslotnodename, d_slotpos.x, d_slotpos.z);
                //AddLink(pslotnodename[i], d_pslotnodename);
                if (d_nodeprev != "")
                {
                    grc.AddLinkByNodeName(d_pslotnodename, d_nodeprev);
                }
                d_nodeprev = d_pslotnodename;
            }
            if (d_order == connectOrderE.dec)
            {
                grc.AddLinkByNodeName(d_nodeprev, drivenode);
            }

            // do walk paths
            grc.SetCurUseType(LinkUse.walkway);
            var w_nodeprev = (w_order == connectOrderE.dec ? "" : walknode);
            var w_ang = (w_exit == exitDirE.front ? 0 : 180);
            for (int i = 0; i < nslots; i++)
            {
                var w_pslotnodename_door = garage.SlotAxuxNodeName("wpsdoor", i);
                var w_slotpos_door = garage.GetSlotPosition1(i, -90, 1.0f);
                grc.NewAnchorLinkToxz(pslotnodename[i], w_pslotnodename_door, w_slotpos_door.x, w_slotpos_door.z);

                var w_pslotnodename = garage.SlotAxuxNodeName("wps", i);
                var w_slotpos = garage.GetSlotPosition2(i, w_ang, w_len, -90, 1.0f);
                grc.LinkToPtxz(w_pslotnodename, w_slotpos.x, w_slotpos.z);
                if (w_nodeprev != "")
                {
                    grc.AddLinkByNodeName(w_pslotnodename, w_nodeprev);
                }
                w_nodeprev = w_pslotnodename;
            }
            if (w_order == connectOrderE.dec)
            {
                grc.AddLinkByNodeName(w_nodeprev, walknode);
            }
        }
        public void CreatePointsSmall()
        {
            grc.gm.initmods();
            grc.gm.mod_name_pfx = getmodelprefix("small-", forcecount: true);
            var p1 = grc.AddNode("pt1", new Vector3(0, 0, 0));
            var p2 = grc.AddNode("pt2", new Vector3(-4, 10, 20));
            var p3 = grc.AddNode("pt3", new Vector3(10, 10, 0));
            grc.AddLink("l1", p1, p2);
            grc.AddLink("l2", p2, p3);
        }

        public void CreateLinksFromRegionFiles(string prefix)
        {
            var mask = prefix+"*.region";
            var fnames = System.IO.Directory.GetFiles(grc.graphdir, mask);
            Debug.Log("CreateLinksFromRegionFiles graphdir:" + grc.graphdir + " maskL" + mask + " found " + fnames.Length + " files");
            foreach (var fn in fnames)
            {
                var jsonlc1 = JsonLinkCloud.ReadFromFile(fn);
                AddJsonToLinkCloud(jsonlc1, grc);
            }
        }

        public GenGlobeParameters globpar = new GenGlobeParameters(12, 12, 10, 10);
        public GenCircParameters circpar = new GenCircParameters(12, 10, 0);
        public Range LinkFloor = new Range(0, 0);
        public void AddGraphToLinkCloud(graphSceneE graphScene,GraphGenerationModeE genMode,bool addWallLinks)
        {
            grc.maxRanHeight = LinkFloor.max;
            grc.minRanHeight = LinkFloor.min;
            switch (graphScene)
            {
                case graphSceneE.gen_circ:
                    {
                        //Debug.Log("globpar " + glopar.nlat + " " + glopar.nlng + " _" + glopar.height);
                        CreateCircPoints(npoints: circpar.npoints, rad: circpar.radius, heit: circpar.height);
                        break;
                    }
                case graphSceneE.gen_sphere:
                    {
                        Debug.Log("globpar " + globpar.nlat + " " + globpar.nlng + " _" + globpar.height);
                        CreateSpherePoints(nlng: globpar.nlat, nlat: globpar.nlng, rad: globpar.height, heit: globpar.height);
                        break;
                    }
                case graphSceneE.gen_campus:
                    {
                        switch (genMode)
                        {
                            case GraphGenerationModeE.GenFromCode:
                                lmd.createPointsFor_msft_b19();
                                lmd.createPointsFor_msft_b121();
                                lmd.createPointsFor_msft_b40();
                                lmd.createPointsFor_msft_b43();
                                lmd.createPointsFor_msft_b43_f1();
                                lmd.createPointsFor_msft_b99();
                                lmd.createPointsFor_msft_bredwb();
                                lmd.createPointsFor_msft_bredwb_f3();
                                lmd.createPointsFor_msft_bsx();
                                //lmd.createPointsFor_msft_campus();
                                //if (addfixedStreetLinks)
                                //{
                                //    lmd.CreateGraphForOsmImport_msft_streets();
                                //}
                                //if (genOsmStreetLinks)
                                //{
                                //    lmd.CreateGraphForOsmImport_msft_streets_df("msft-campus", "blue");
                                //}

                                //lmd.CreateGraphForOsmImport_MsftCampusBldSmall();
                                if (addWallLinks)
                                { 
                                    lmd.CreateGraphForOsmImport_msftb19area();
                                    lmd.CreateGraphForOsmImport_msftcommons();
                                    lmd.CreateGraphForOsmImport_msftredwest();
                                }

                                AddRedwestCalibrationMarkers();
                                var template = grc.gm.addprefix("rm");
                                addVoiceKeywords(template);
                                addRedwestB3names(template);
                                break;
                            case GraphGenerationModeE.ReadFromFile:
                                CreateLinksFromRegionFiles("msft");
                                break;
                        }
                        GenCampusGarageLinks();
                        grc.AddLinkByNodeName("bRWB-f01-lobby", "rwb-f03-rm3999");// stairway (sort of)
                        break;
                    }
                case graphSceneE.gen_b43_1:
                    {
                        lmd.CreatePointsForB43RoomsFloor1();
                        var rot = new Vector3(0, -90, 0);
                        var trn = new Vector3(35.42f, 0, -8.72f);
                        grc.floorMan.SetMaterialPlane("US-043-1", 7266, 3599, rot, trn);
                        break;
                    }
                case graphSceneE.gen_b43_2:
                    {
                        lmd.CreatePointsForB43RoomsFloor1();
                        var rot = new Vector3(0, -90, 0);
                        var trn = new Vector3(35.42f, 0, -8.72f);
                        grc.floorMan.SetMaterialPlane("US-043-2", 7266, 3599, rot, trn);
                        break;
                    }
                case graphSceneE.gen_b43_3:
                    {
                        lmd.CreatePointsForB43RoomsFloor1();
                        var rot = new Vector3(0, -90, 0);
                        var trn = new Vector3(35.42f, 0, -8.72f);
                        grc.floorMan.SetMaterialPlane("US-043-3", 7266, 3599, rot, trn);
                        break;
                    }
                case graphSceneE.gen_b43_4:
                    {
                        lmd.CreatePointsForB43RoomsFloor1();
                        var rot = new Vector3(0, -90, 0);
                        var trn = new Vector3(35.42f, 0, -8.72f);
                        grc.floorMan.SetMaterialPlane("US-043-4", 7266, 3599, rot, trn);
                        break;
                    }
                case graphSceneE.gen_bho:
                    {
                        CreatePointsForBho();
                        var rot = new Vector3(0, -90, 0);
                        var trn = new Vector3(35.42f, 0, -8.72f);
                        grc.floorMan.SetMaterialPlane("DE-BHO-4", 7266, 4223, rot, trn, scalefak: 1 / 2.086667f);
                        break;
                    }
                case graphSceneE.gen_b43_1p2:
                    {
                        lmd.CreatePointsForB43RoomsFloor1();
                        lmd.CreatePointsForB43RoomsFloor2();
                        grc.AddLinkByNodeName("f01-wp-c01", "f02-wp-c03");
                        grc.AddLinkByNodeName("f01-wp-c12", "f02-wp-c13");
                        break;
                    }
                case graphSceneE.gen_redwb_3:
                    {
                        lmd.CreatePointsForBredwB3floor();
                        var sca = new Vector3(10.294f, 1, 10.004f);
                        var rot = new Vector3(0, -90, 0);
                        var trn = new Vector3(35.42f, 0, -8.72f);
                        grc.floorMan.SetMaterialPlane("US-RDB-3", 5255, 5099, sca, rot, trn);
                        break;
                    }
                case graphSceneE.gen_small:
                    {
                        CreatePointsSmall();
                        break;
                    }
                case graphSceneE.gen_eb12:
                    {
                        switch (genMode)
                        {
                            case GraphGenerationModeE.GenFromCode:
                                //lmd.CreatePointsForEb12streets1();
                                //lmd.CreatePointsForEb12resident1();
                                //lmd.CreatePointsForEb12streets2();
                                //lmd.CreatePointsForEb12retail();
                                //lmd.CreatePointsForEb12resident2();

                                //if (addfixedStreetLinks)
                                //{
                                //    lmd.CreateGraphForOsmImport_eb12_orig();
                                //}

                                if (addWallLinks)
                                {
                                    lmd.CreateGraphForOsmImport_Eb12small();
                                }
                                //if (genOsmStreetLinks)
                                //{
                                //    lmd.CreateGraphForOsmImport_msft_streets_df("EB12 Area", "blue");
                                //}

                                //lmd.createPointsFor_eb12_streets();
                                lmd.createPointsFor_eb12_resident();
                                lmd.createPointsFor_eb12_retail();
                                break;
                            case GraphGenerationModeE.ReadFromFile:
                                CreateLinksFromRegionFiles("eb12");
                                break;
                        }
                        CreateEb12GarageLinks();
                        break;
                    }
                case graphSceneE.gen_eb12_small:
                    {
                        switch (genMode)
                        {
                            case GraphGenerationModeE.GenFromCode:

                                if (addWallLinks)
                                {
                                    lmd.CreateGraphForOsmImport_Eb12small();
                                }
                                //lmd.CreateGraphForOsmImport_eb12_small();
                                //lmd.createPointsFor_eb12_streets();
                                lmd.createPointsFor_eb12_resident();
                                lmd.createPointsFor_eb12_retail();
                                break;
                            case GraphGenerationModeE.ReadFromFile:
                                CreateLinksFromRegionFiles("eb12");
                                break;
                        }
                        CreateEb12GarageLinks();
                        break;
                    }
                case graphSceneE.gen_tukwila:
                    {
                        CreatePointsForTukwila();
                        break;
                    }
                case graphSceneE.gen_tenmtn:
                    {
                        CreatePointsForTenMtn();
                        break;
                    }
                case graphSceneE.gen_dublin:
                    {
                        CreatePointsForDublin();
                        CreateGarageLinks("MsDublin1", "dub-oso02", "dub-dw01",
                                      d_order: connectOrderE.dec, d_exit: exitDirE.back, d_len: 5f,
                                      w_order: connectOrderE.inc, w_exit: exitDirE.back, w_len: 5f);

                        break;
                    }
            }
        }

        public void CreatePointsForDublinJunk()
        {
            grc.yfloor = 0;
            grc.AddNodePtxz("dub-oso01", 32.0, 24);
            grc.LinkToPtxz("dub-oso02", 23.6, 24);

            grc.AddNodePtxz("dub-dw01", 38.8f, 49.7f);
            grc.AddNodePtxz("dub-dw02", 37.3f, 56.1f);
        }
        public static void SaveToFile(GraphCtrl grc, string fname,ref NodeRegion region)
        {
            var jsonlc = LcMapMaker.MakeJson(grc, ref region);
            JsonLinkCloud.WriteToFile(jsonlc, fname);
        }

        public GraphCtrl getLinkCloud()
        {
            return grc;
        }
        public static JsonLinkCloud MakeJson(GraphCtrl lc,ref NodeRegion region)
        {
            int nnodes = 0;
            int nlinks = 0;
            var jsonlc = new JsonLinkCloud(region, lc.floorMan);
            var regionFilter = region.regid;
            if (region.name=="default")
            {
                regionFilter = 0;
            }
            foreach (var nname in lc.nodenamelist)
            {
                var node = lc.GetNode(nname);
                if (node.IsInRegion(region.regid))
                {
                    jsonlc.AddNode(node.name, node.pt);
                    nnodes += 1;
                }
            }
            foreach (var lname in lc.linknamelist)
            {
                var link = lc.GetLink(lname);
                if (link.node1.IsInRegion(regionFilter) && link.node2.IsInRegion(regionFilter))
                {
                    jsonlc.AddLink(link.name, link.node1.name, link.node2.name, link.usetype.ToString());
                    nlinks += 1;
                }
            }
            //GraphUtil.Log("MakeJson nnodes:" + nnodes + " nlinks:" + nlinks);
            //Debug.Log("MakeJson nnodes:" + nnodes + " nlinks:" + nlinks);
            return jsonlc;
        }
        public static void AddJsonToLinkCloud(JsonLinkCloud jsonlc, GraphCtrl grc)
        {
            var reg = jsonlc.region;
            Debug.Log("   AddJsonToLinkCloud reg.name:" + reg.name);
            var nreg = grc.regman.NewNodeRegion(reg.name, reg.color,saveToFile:true, makeCurrent: true);
            foreach (var node in jsonlc.nodes.list)
            {
                if (grc.nodeExists(node.name))
                {
                    Debug.LogWarning("Node " + node.name + " already exists");
                }
                else
                {
                    grc.AddNode(node.name, node.pt);
                }
            }
            foreach (var jslink in jsonlc.links.list)
            {
                var lnk = grc.AddLinkByNodeName(jslink.n1, jslink.n2, jslink.name);
                if (jslink.usetype!=null)
                {
                    System.Enum.TryParse<LinkUse>(jslink.usetype, true, out lnk.usetype);
                }
            }
            grc.floorMan = jsonlc.floorplan;
            return;
        }
    }
}
