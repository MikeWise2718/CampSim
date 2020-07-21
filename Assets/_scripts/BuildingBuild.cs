using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CampusSimulator
{
    public partial class Building : MonoBehaviour
    {
        List<GameObject> bldgos;
        List<BldEvacAlarm> bldalarms;

        void ActuallyDestroyObjects()
        {
            if (bldgos == null)
            {
                Debug.Log("bldgo is null");
            }
            foreach (var go in bldgos)
            {
                Object.Destroy(go);
            }
        }
        public static List<string> GetPredefinedBuildingNames(string filter)
        {
            var l = new List<string>
            {
                //"Bld11",
                "Bld19",
                "Bld121",
                "Bld40",
                "Bld43",
                "BldSX",
                "Bld99",
                "BldRWB",
                "Eb12-22",
                //"Eb12-test",
                "Eb12-carport",
                "Eb30",
                "Eb17",
                "Eb19",
                "EbIdb25",
                "EbIdb35",
                "EbOphome",
                "EbRewe",
                "DubBld1",
            };
            l.RemoveAll(item => !item.StartsWith(filter));
            return l;
        }
        List<string> B121roomspec = new List<string>()
        {
            "b121-f01-lobby:6:-18.5:4:4:T",
        };

        // defPeoplePerRoom = 8;
        // defPercentFull = 0.80f;
        // defRoomArea = 16;
        // defAngAlign = 24.0f;
        List<string> B19roomspec = new List<string>()
        {
            "b19-f01-lobby:1:-18.5:4:4:T",
            "b19-f01-rm1001:8:-18.5:4:4:T",
            "b19-f01-rm1002:5:-18.5:4:4:T",
            "b19-f01-rm1003:8:-18.5:4:4:T",
            "b19-f01-rm1004:4:-18.5:2:3:T",
            "b19-f01-rm1005:5:-18.5:2:3:T",
            "b19-f01-rm1006:4:-18.5:2:3:T",
            "b19-f01-rm1012:3:-18.5:3:2:T",
            "b19-f01-rm1012a:3:-18.5:3:2:T",
            "b19-f01-rm1013:4:-18.5:3:2:T",
            "b19-f01-rm1014:3:-18.5:3:1.5:T",
            "b19-f01-rm1015:4:-18.5:3:2:T",
            "b19-f01-rm1016:5:-18.5:3:2:T",
            "b19-f01-rm1017:4:-18.5:3:3:T",
            "b19-f01-rm1018:5:-18.5:2.5:2.5:T",
            "b19-f01-rm1019:4:-18.5:2.5:2.5:T",


            "b19-f01-rm1021:4:-18.5:3:3:T",
            "b19-f01-rm1022:3:-18.5:3:3:T",
            "b19-f01-rm1023:4:-18.5:3:3:T",
            "b19-f01-rm1024:5:-18.5:3:3:T",
            "b19-f01-rm1025:4:-18.5:3:3:T",
            "b19-f01-rm1026:3:-18.5:3:3:T",
            "b19-f01-rm1027:4:26.5:3:3:T",
            "b19-f01-rm1028:5:26.5:3:3:T",
            "b19-f01-rm1029:4:26.5:3:3:T",

            "b19-f01-rm1030:5:-18.5:2.6:2.6:T",
            "b19-f01-rm1031:2:-18.5:2.6:2.6:T",
            "b19-f01-rm1032:5:-18.5:2.6:2.6:T",
            "b19-f01-rm1033:4:-18.5:2.6:2.6:T",
            "b19-f01-rm1033a:4:-18.5:2.6:2.6:T",
            "b19-f01-rm1034:5:-18.5:2.6:2.6:T",
            "b19-f01-rm1035:5:-18.5:2.6:2.6:T",
            "b19-f01-rm1036:3:-18.5:2.6:2.6:T",
            "b19-f01-rm1037:4:-18.5:2.6:2.6:T",
            "b19-f01-rm1038:5:-18.5:2.6:2.6:T",
            "b19-f01-rm1039:3:-18.5:2.6:2.6:T",
        };

        List<string> Eb12roomspec = new List<string>()
        {
            "eb12-08-lob:11:0.0:4:4:T",
            "eb12-10-lob:15:0.0:4:4:T",
            "eb12-12-lob:7:0.0:4:4:T",
            "eb12-14-lob:9:0.0:4:4:T",
            "eb12-16-lob:15:0.0:4:4:T",
            "eb12-18-lob:9:0.0:4:4:T",
            "eb12-20-lob:7:0.0:4:4:T",
            "eb12-22-lob:9:0.0:4:4:T",
        };

        public List<string> SplitOutDestNodes(List<string> specs)
        {
            var dnodes = new List<string>();
            foreach( var sp in specs )
            {
                var sar = sp.Split(':');
                dnodes.Add(sar[0]);
            }
            return dnodes;
        }
        public void AddBldDetails(BuildingMan bm)
        {
            this.bm = bm;
            bldgos = new List<GameObject>();
            maingaragename = "";
            selectionweight = 1;
            destnodes = new List<string>();
            switch (name)
            {
                //case "Bld11":
                //    {
                //        maingaragename = "Garage11_1";
                //        destnodes = new List<string> { "b11-f01-lobby" };
                //        shortname = "b11";
                //        break;
                //    }
                case "Bld19":
                    {
                        maingaragename = "Garage19_1";
                        roomspecs = B19roomspec;
                        destnodes = SplitOutDestNodes(roomspecs);
                        shortname = "b19";
                        journeyChoiceWeight = 20;
                        var b19comp = this.transform.gameObject.AddComponent<B19Willow>();
                        b19comp.InitializeValues(bm.sman);
                        b19comp.MakeItSo();
                        break;
                    }
                case "Bld121":
                    {
                        maingaragename = "Garage121_1";
                        roomspecs = B121roomspec;
                        destnodes = SplitOutDestNodes(roomspecs);
                        shortname = "b121";
                        journeyChoiceWeight = 20;
                        var b121comp = this.transform.gameObject.AddComponent<B121Willow>();
                        b121comp.InitializeValues(bm.sman);
                        b121comp.MakeItSo();
                        break;
                    }
                case "Bld40":
                    {
                        maingaragename = "Garage40_1";
                        destnodes = new List<string> { "b40-f01-lobby" };
                        shortname = "b40";
                        break;
                    }
                case "Bld43":
                    {
                        maingaragename = "Garage43_1";
                        destnodes = new List<string> { "b43-f01-rm1001", "b43-f01-rm1002", "b43-f01-rm1003" };
                        shortname = "b43";
                        break;
                    }
                case "BldSX":
                    {
                        maingaragename = "GarageX_1";
                        destnodes = new List<string> { "bSX-f01-lobby" };
                        shortname = "bSX";
                        break;
                    }
                case "Bld99":
                    {
                        maingaragename = "Garage99_1";
                        destnodes = new List<string> { "b99-f01-lobby" };
                        shortname = "b99";
                        break;
                    }
                case "BldRWB":
                    {
                        maingaragename = "GarageRWB_1";
                        selectionweight = 10;
                        destnodes = new List<string> { "bRWB-f01-lobby", "rwb-f03-rm3999" };
                        SceneMan sman = FindObjectOfType<SceneMan>();
                        //var destnodelst = sman.linkcloudctrl.FindNodes("rwb-f03-rm");
                        //Debug.Log("Found " + destnodelst.Count + "destinations for "+name);
                        shortname = "bRWB";
                        break;
                    }
                case "Eb12-22":
                    {
                        maingaragename = "Eb12_1";
                        roomspecs = Eb12roomspec;
                        destnodes = new List<string> { "eb12-08-lob", "eb12-10-lob", "eb12-12-lob","eb12-14-lob",
                                                       "eb12-16-lob", "eb12-18-lob", "eb12-20-lob","eb12-22-lob" };
                        shortname = "eb12";
                        break;
                    }
                case "Eb12-test":
                    {
                        shortname = "test";
                        break;
                    }
                case "Eb12-carport":
                    {
                        shortname = "carport";
                        break;
                    }
                case "Eb17":
                    {
                        shortname = "Eb17";
                        break;
                    }
                case "Eb19":
                    {
                        shortname = "Eb19";
                        break;
                    }
                case "Eb30":
                    {
                        shortname = "Eb30";
                        break;
                    }
                case "EbIdb25":
                    {
                        shortname = "EbIdb25";
                        break;
                    }
                case "EbIdb35":
                    {
                        shortname = "EbIdb35";
                        break;
                    }
                case "EbOphome":
                    {
                        shortname = "Ophm";
                        break;
                    }
                case "EbRewe":
                    {
                        maingaragename = "Eb12_Rewe";
                        destnodes = new List<string> { "eb12-rewe-lob", "eb12-rewe-rm01", "eb12-rewe-rm02" };
                        shortname = "Rewe";
                        break;
                    }
                case "DubBld1":
                    {
                        shortname = "DubBld1";
                        destnodes = new List<string> { "dub-oso01" };
                        break;
                    }
                default:
                    {
                        throw new UnityException("bad building name:" + name);
                    }
            }
        }



        void AddQuad(GameObject pgo, string name, Vector3 bscale, Vector3 brot, Vector3 bpos, string cname = "")
        {
            var bgo = GameObject.CreatePrimitive(PrimitiveType.Quad);
            bgo.name = name;
            bgo.transform.localScale = bscale;
            bgo.transform.Rotate((float)brot.x, (float)brot.y, (float)brot.z);
            bgo.transform.position = bpos;
            bgo.transform.parent = pgo.transform;
            if (cname != "")
            {
                var rrenderer = bgo.GetComponent<Renderer>();
                rrenderer.material.color = GraphAlgos.GraphUtil.GetColorByName(cname,alpha:0.7f);
                rrenderer.material.shader = Shader.Find("Transparent/Diffuse");
            }
        }
        void AddQuadHouse(string name, Vector3 bscale, double brot, Vector3 bpos, string sidecolor = "white", string rufcolor = "dirtyred")
        {
            //       Debug.Log("Adding house of quads " + name);
            var yelev = bm.sman.mpman.GetHeight(bpos.x, bpos.z);
            bpos = bpos + yelev*Vector3.up;

            var sq2 = Mathf.Sqrt(2);
            bscale = new Vector3(bscale.x, bscale.y / sq2, bscale.z / sq2); // the rooftop is higher than the top floor
            var sq22 = sq2 / 2;
            var zero = Vector3.zero;
            var ones = Vector3.one;
            var sq2v = ones * sq22;
            var xoff = Vector3.right / 2;
            //var yoff = new Vector3(0, yelev + 0.5f, 0);
            var yoff =  Vector3.up / 2;
            var zoff = Vector3.forward / 2;
            var pgo = new GameObject(name);
            AddQuad(pgo, "floor", ones, new Vector3(-90, 0, 0), -yoff, sidecolor);
            AddQuad(pgo, "ceil", ones, new Vector3(+90, 0, 0), yoff, sidecolor);
            AddQuad(pgo, "front", ones, new Vector3(0, 180, 0), zoff, sidecolor);
            AddQuad(pgo, "back", ones, new Vector3(0, 0, 0), -zoff, sidecolor);
            AddQuad(pgo, "left", ones, new Vector3(0, -90, 0), xoff, sidecolor);
            AddQuad(pgo, "right", ones, new Vector3(0, 90, 0), -xoff, sidecolor);
            // now roof structure
            AddQuad(pgo, "rufback", new Vector3(1, sq22, 1), new Vector3(+45, 0, 0), new Vector3(0, 0.75f, -0.25f), rufcolor);
            AddQuad(pgo, "ruffront", new Vector3(1, sq22, 1), new Vector3(135, 0, 0), new Vector3(0, 0.75f, 0.25f), rufcolor);
            AddQuad(pgo, "sideleft", sq2v, new Vector3(0, -90, 45), xoff + yoff, sidecolor);
            AddQuad(pgo, "sideright", sq2v, new Vector3(0, 90, 45), -xoff + yoff, sidecolor);

            pgo.transform.localScale = bscale;
            pgo.transform.Rotate(0, (float)brot, 0);
            pgo.transform.position = bpos + Vector3.up / 2;
            bldgos.Add(pgo);
            pgo.transform.parent = this.transform;

        }
        // AddFlatQuadHouse("blk2", new Vector3(26.9f, 5, 16.7f), -3.4, new Vector3(56.53f, 4f, -35.05f));
        void AddFlatQuadHouse(string name, Vector3 bscale, double brot, Vector3 bpos, string sidecolor = "white", string rufcolor = "dimgray")
        {
            var yelev = bm.sman.mpman.GetHeight(bpos.x, bpos.z);
            bpos = bpos + yelev * Vector3.up;
            //      Debug.Log("Adding flat house of quads " + name);
            var sq2 = Mathf.Sqrt(2);
            //bscale = new Vector3(bscale.x, bscale.y / sq2, bscale.z / sq2); // the rooftop is higher than the top floor
            bscale = new Vector3(bscale.x, bscale.y*2, bscale.z / sq2); // the rooftop is higher than the top floor
            var sq22 = sq2 / 2;
            var zero = Vector3.zero;
            var ones = Vector3.one;
            var sq2v = ones * sq22;
            var xoff = Vector3.right / 2;
            var yoff = Vector3.up / 2;
            var zoff = Vector3.forward / 2;
            var pgo = new GameObject(name);
            AddQuad(pgo, "floor", ones, new Vector3(-90, 0, 0), -yoff, sidecolor);
            AddQuad(pgo, "roof", ones, new Vector3(+90, 0, 0), yoff, rufcolor);
            AddQuad(pgo, "front", ones, new Vector3(0, 180, 0), zoff, sidecolor);
            AddQuad(pgo, "back", ones, new Vector3(0, 0, 0), -zoff, sidecolor);
            AddQuad(pgo, "left", ones, new Vector3(0, -90, 0), xoff, sidecolor);
            AddQuad(pgo, "right", ones, new Vector3(0, 90, 0), -xoff, sidecolor);


            pgo.transform.localScale = bscale;
            pgo.transform.Rotate(0, (float)brot, 0);
            //pgo.transform.position = bpos + Vector3.up / 2;
            pgo.transform.position = bpos;
            bldgos.Add(pgo);
            pgo.transform.parent = this.transform;

        }

        void AddMfCube(string name, Vector3 bscale, double brot, Vector3 bpos, string cname = "")
        {
            var yelev = bm.sman.mpman.GetHeight(bpos.x, bpos.z);
            bpos = bpos + yelev * Vector3.up;

            //       Debug.Log("Adding mfcube " + name);
            var zero = Vector3.zero;
            var ones = Vector3.one;
            var xoff = Vector3.right / 2;
            var yoff = Vector3.up / 2;
            var zoff = Vector3.forward / 2;
            var pgo = new GameObject(name);
            AddQuad(pgo, "floor", ones, new Vector3(-90, 0, 0), -yoff, "red");
            AddQuad(pgo, "ceil", ones, new Vector3(+90, 0, 0), yoff, "blue");
            AddQuad(pgo, "front", ones, new Vector3(0, 180, 0), zoff, "green");
            AddQuad(pgo, "back", ones, new Vector3(0, 0, 0), -zoff, "yellow");
            AddQuad(pgo, "left", ones, new Vector3(0, -90, 0), xoff, "cyan");
            AddQuad(pgo, "right", ones, new Vector3(0, +90, 0), -xoff, "magenta");
            pgo.transform.localScale = bscale;
            pgo.transform.Rotate(0, (float)brot, 0);
            pgo.transform.position = bpos;
            bldgos.Add(pgo);
            pgo.transform.parent = this.transform;
        }


        void AddBlock(string name, Vector3 bscale, double brot, Vector3 bpos, string cname = "")
        {
            var yelev = bm.sman.mpman.GetHeight(bpos.x, bpos.z);
            bpos = bpos + yelev * Vector3.up;


            var bgo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            bgo.name = name;
            bgo.transform.localScale = bscale;
            bgo.transform.Rotate(0, (float)brot, 0);
            bgo.transform.position = bpos;
            bgo.transform.parent = this.transform;
            if (cname != "")
            {
                var rrenderer = bgo.GetComponent<Renderer>();
                rrenderer.material.color = GraphAlgos.GraphUtil.GetColorByName(cname);
            }
            bldgos.Add(bgo);
        }
        void AddBlockR(string name, Vector3 bscale, Vector3 brot, Vector3 bpos, string cname = "")
        {
            var yelev = bm.sman.mpman.GetHeight(bpos.x, bpos.z);
            bpos = bpos + yelev * Vector3.up;

            var bgo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            bgo.name = name;
            bgo.transform.localScale = bscale;
            bgo.transform.Rotate((float)brot.x, (float)brot.y, (float)brot.z);
            bgo.transform.position = bpos;
            bgo.transform.parent = this.transform;
            if (cname != "")
            {
                var rrenderer = bgo.GetComponent<Renderer>();
                rrenderer.material.color = GraphAlgos.GraphUtil.GetColorByName(cname);
            }
            bldgos.Add(bgo);
        }
        void AddBldResource(string name, string rname, Vector3 bscale, double brot, Vector3 bpos)
        {
            var yelev = bm.sman.mpman.GetHeight(bpos.x, bpos.z);
            bpos = bpos + yelev * Vector3.up;


            var objPrefab = Resources.Load<GameObject>(rname);
            var rgo = Instantiate<GameObject>(objPrefab) as GameObject;
            rgo.name = name;
            rgo.transform.localScale = bscale;
            rgo.transform.Rotate(0, (float)brot, 0);
            rgo.transform.position = bpos;
            rgo.transform.parent = this.transform;
            bldgos.Add(rgo);
        }

        void AddBldMarker(string name, float lat, float lng)
        {
            var bgo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            bgo.name = name;
            var glbllm = this.bm.sman.glbllm;
            bgo.transform.parent = this.transform;
            bgo.transform.position = glbllm.xycoord(lat, lng);
            bldgos.Add(bgo);
        }
        int pnum = 0;
        void AddLineOfResources(string pname, string resourcename, int n, Vector3 p1, Vector3 p2, bool randomrotate, bool randomscale, float minheit, float maxheit, float aspectx, float aspectz)
        {
            var yelev1 = bm.sman.mpman.GetHeight(p1.x, p1.z);
            p1 = p1 + yelev1 * Vector3.up;
            var yelev2 = bm.sman.mpman.GetHeight(p2.x, p2.z);
            p2 = p2 + yelev2 * Vector3.up;


            int nm1 = n - 1;
            if (nm1 <= 0) nm1 = 1;
            var d1 = p2 - p1;
            var dltheit = maxheit - minheit;
            var sy = (minheit + maxheit) / 2;
            float ang = 0;
            for (int i = 0; i < n; i++)
            {
                var pos = p1 + i * d1 / nm1;
                if (randomscale)
                {
                    sy = GraphAlgos.GraphUtil.GetRanFloat(minheit,maxheit);
                }
                var sx = aspectx * sy;
                var sz = aspectz * sy;
                if (randomrotate)
                {
                    ang = GraphAlgos.GraphUtil.GetRanFloat(0,360);
                }
                string rname = pname + pnum;
                pnum++;
                AddBldResource(pname, resourcename, new Vector3(sx, sy, sz), ang, pos);
            }
            //AddResource("pine2", "TreesAndShrubs/PineTree", new Vector3(0.4f, 0.4f, 0.4f), 180, new Vector3(-1959.9f, 0, -1242.6f));
        }
        void AddLineOfPines(string pname, int n, Vector3 p1, Vector3 p2, bool randomrotate = true, bool randomscale = true, float minheit = 0.35f, float maxheit = 0.6f, float aspectx = 1, float aspectz = 1)
        {
            var yelev1 = bm.sman.mpman.GetHeight(p1.x, p1.z);
            p1 = p1 + yelev1 * Vector3.up;
            var yelev2 = bm.sman.mpman.GetHeight(p2.x, p2.z);
            p2 = p2 + yelev2 * Vector3.up;

            AddLineOfResources(pname, "TreesAndShrubs/PineTree", n, p1, p2, randomrotate, randomscale, minheit, maxheit, aspectx, aspectz);
        }
        void AddLineOfBushes(string pname, int n, Vector3 p1, Vector3 p2, bool randomrotate = false, bool randomscale = true, float minheit = 1.0f, float maxheit = 1.4f, float aspectx = 2.5f, float aspectz = 3.5f)
        {
            var yelev1 = bm.sman.mpman.GetHeight(p1.x, p1.z);
            p1 = p1 + yelev1 * Vector3.up;
            var yelev2 = bm.sman.mpman.GetHeight(p2.x, p2.z);
            p2 = p2 + yelev2 * Vector3.up;
            AddLineOfResources(pname, "TreesAndShrubs/BigBush", n, p1, p2, randomrotate, randomscale, minheit, maxheit, aspectx, aspectz);
        }
        void AddBldPoleCamera(string name, float xpos, float zpos, float ang, float heit)
        {
            // add a camera on a pole at xpos,heit,ypos, y-rotated by ang
            var yelev = bm.sman.mpman.GetHeight(xpos,zpos);
            heit = heit + yelev;

            // add a cylinder scaled by 0.1,heit,0.1
            // add a camera to the end, and tip it down
            // rotate the cylinder
            // add to the scene
            var v = new Vector3(xpos, heit, zpos);
            
           return;
        }
        void AddBld43Ref()
        {
            // add a empty game obect at 0,0.5,0
            // Load in Models/B4model prefab underneath it
        }
        void AddAlarmToNode(GameObject parentnode,string alarmname,string nodename,float almheight=2)
        {
            var lc = bm.sman.lcman;
            var lclc = lc.GetGraphCtrl();
            if (!lc.IsNodeName(nodename)) return;

            var nodept = lclc.GetNode(nodename);
            if (nodept == null) return;

            var pt = nodept.pt;
            var yelev = bm.sman.mpman.GetHeight(pt.x, pt.z);

            var apos = new Vector3(pt.x, yelev + almheight, pt.z);
            var ago = BldEvacAlarm.GetGo(alarmname, apos, 0.5f );
            ago.transform.parent = parentnode.transform;
            var beac = ago.AddComponent<BldEvacAlarm>();
            beac.Init(this, apos);  
        }
        public void DefineBuildingConstants()
        {
            defPeoplePerRoom = 2;
            defPercentFull = 1.0f;
            defRoomArea = 10;
            var bmode = bm.bldMode.Get();
            switch (name)
            {

                case "Eb12-22":
                    {
                        defPeoplePerRoom = 10;
                        defPercentFull = 1.0f;
                        defRoomArea = 10;
                        defAngAlign = 0;
                        break;
                    }
                case "EbRewe":
                    {
                        defPeoplePerRoom = 5; // 20
                        defPercentFull = 1.0f;
                        defRoomArea = 100;
                        break;
                    }
                case "BldRWB":
                    { 
                        defPeoplePerRoom = 2;
                        if (bm.sman.curscene == SceneSelE.MsftB19focused || bm.sman.curscene == SceneSelE.MsftB121focused  )
                        {
                            defPercentFull = 0.05f;
                        }
                        else
                        {
                            defPercentFull = 0.95f;
                        }
                        defRoomArea = 10;
                        defAngAlign = -10;
                        if (bm.sman.curscene == SceneSelE.MsftRedwest)
                        {
                            bm.sman.jnman.preferedJourneyBuildingName = name;
                        }
                        break;
                    }
                case "Bld11":
                    {
                        defPeoplePerRoom = 20;
                        defPercentFull = 1.0f;
                        defRoomArea = 40;
                        break;
                    }
                case "Bld19":
                    {
                        if (bm.sman.curscene == SceneSelE.MsftB19focused)
                        {
                            bm.sman.jnman.preferedJourneyBuildingName = name;
                        }
                        defPeoplePerRoom = 8;
                        defPercentFull = 0.80f;
                        defRoomArea = 16;
                        defAngAlign = 24.0f;
                        break;
                    }
                case "Bld121":
                    {
                        if (bm.sman.curscene == SceneSelE.MsftB121focused)
                        {
                            bm.sman.jnman.preferedJourneyBuildingName = name;
                        }
                        defPeoplePerRoom = 8;
                        defPercentFull = 0.80f;
                        defRoomArea = 16;
                        defAngAlign = 24.0f;
                        break;
                    }
                case "Bld40":
                    {
                        defPeoplePerRoom = 20;
                        defPercentFull = 1.0f;
                        defRoomArea = 40;
                        break;
                    }
                case "Bld43":
                    {
                        defPeoplePerRoom = 4;
                        defPercentFull = 1.0f;
                        defRoomArea = 15;
                        break;
                    }
                case "Bld99":
                    {
                        defPeoplePerRoom = 20;
                        defPercentFull = 1.0f;
                        defRoomArea = 40;
                        break;
                    }
                case "BldSX":
                    {
                        defPeoplePerRoom = 20;
                        defPercentFull = 1.0f;
                        defRoomArea = 40;
                        break;
                    }
                default:
                    {
                        //Debug.Log("No building gos for " + name);
                        break;
                    }
            }
            //AddPeopleToRooms();
        }


        public void CreateObjects()
        {
            bldgos = new List<GameObject>();
            var bmode = bm.bldMode.Get();
            var tmode = bm.treeMode.Get();
            var fixedbuildings = bm.fixedblds.Get();
            var dofixed = fixedbuildings && bmode == BuildingMan.BldModeE.full;
            //Debug.Log($"{name} fixedbuildings:{fixedbuildings}  bmode:{bmode}  => dofixed:{dofixed}");
            switch (name)
            {
                case "DubBld1":
                    {
                        if (dofixed)
                        {
                            AddBlock("blk1", new Vector3(108, 20, 80), 23.3, new Vector3(-60.9f, 10, 18.9f));
                            AddBlock("blk2", new Vector3(40, 10, 22), -15.5, new Vector3(12.6f, 5, 21.8f));
                        }
                        break;
                    }
                case "Eb12-test":
                    {
                        //AddHouse("testhouse", Vector3.one, 0, new Vector3(-6.6f, 1, -97.6f));
                        if (dofixed)
                        {
                            AddQuadHouse("testhouse", Vector3.one, 0, Vector3.zero);
                        }
                        break;
                    }
                case "Eb12-22":
                    {
                        if (bm.sman.curscene == SceneSelE.Eb12 || bm.sman.curscene == SceneSelE.Eb12small)
                        {
                            bm.sman.jnman.preferedJourneyBuildingName = name;
                        }
                        AddEb12Alarms();
                        if (dofixed)
                        {
                            AddQuadHouse("blk1", new Vector3(23, 8, 14), -1.343, new Vector3(15.26f, 2f, 34.92f), rufcolor: "darkslategray");
                            AddQuadHouse("blk2", new Vector3(23, 8, 14), -1.343, new Vector3(38.16f, 2f, 38.23f), rufcolor: "darkslategray");
                        }

                        if (tmode == BuildingMan.TreeModeE.full)
                        {
                            AddBldResource("tree1", "TreesAndShrubs/Winter Oak", new Vector3(1, 1, 1), 0, new Vector3(8, 0, 17));
                            AddBldResource("tree2", "TreesAndShrubs/Winter Oak", new Vector3(0.9f, 0.9f, 0.9f), 45, new Vector3(12, 0, 20));
                            AddBldResource("tree3", "TreesAndShrubs/Winter Oak", new Vector3(0.7f, 0.7f, 0.7f), 90, new Vector3(30.8f, 0, 7.0f));
                            AddBldResource("tree4", "TreesAndShrubs/Winter Oak", new Vector3(0.7f, 0.7f, 0.7f), 95, new Vector3(31.2f, 0, 4.4f));
                            AddBldResource("tree5", "TreesAndShrubs/Winter Oak", new Vector3(0.2f, 0.2f, 0.2f), 100, new Vector3(15.8f, 0, 11.6f));
                            AddBldResource("tree6", "TreesAndShrubs/Winter Oak", new Vector3(0.2f, 0.18f, 0.2f), 25, new Vector3(16.4f, 0, 6.4f));
                            AddBldResource("tree7", "TreesAndShrubs/Winter Oak", new Vector3(0.2f, 0.2f, 0.2f), 180, new Vector3(26.6f, 0, 20.4f));
                            AddBldResource("tree8", "TreesAndShrubs/Winter Oak", new Vector3(0.5f, 0.5f, 0.5f), 267, new Vector3(34.6f, 0, -3.1f));
                            AddBldResource("tree9", "TreesAndShrubs/Winter Oak", new Vector3(1, 1, 1), 180, new Vector3(41.5f, 0, -49.8f));
                            AddBldResource("pine1", "TreesAndShrubs/PineTree", new Vector3(0.4f, 0.4f, 0.4f), 180, new Vector3(7.5f, 0, -13.8f));
                            AddBldResource("pine2", "TreesAndShrubs/PineTree", new Vector3(0.2f, 0.2f, 0.2f), 80, new Vector3(36.2f, 0, -19.4f));
                            AddBldResource("bush1", "TreesAndShrubs/SmallBush", new Vector3(0.5f, 0.5f, 0.5f), 0, new Vector3(17.7f, 0, 5.8f));
                            AddBldResource("bush2", "TreesAndShrubs/SmallBush", new Vector3(0.5f, 0.5f, 0.5f), 0, new Vector3(16.0f, 0, 5.8f));
                            AddBldResource("bush3", "TreesAndShrubs/BigBush", new Vector3(1f, 1f, 1f), 0, new Vector3(31.7f, 0, 5.3f));
                            AddBldResource("bush4", "TreesAndShrubs/BigBush", new Vector3(1.5f, 1.0f, 1.5f), 0, new Vector3(4.17f, 0, -7.6f));
                            AddBldResource("lightpole0", "Models/lightpole1", new Vector3(1.2f, 1.00f, 1.2f), 0, new Vector3(0f, 0, 0f));
                            AddBldResource("lightpole1", "Models/lightpole1", new Vector3(1.2f, 0.76f, 1.2f), 0, new Vector3(15.84f, 0, 21.28f));
                            AddBldResource("lightpole2", "Models/lightpole1", new Vector3(1.2f, 0.76f, 1.2f), 0, new Vector3(38.03f, 0, 23.72f));
                            AddBldResource("lightpole3", "Models/lightpole1", new Vector3(1.2f, 0.76f, 1.2f), -90, new Vector3(32.86f, 0, 11.38f));
                        }
                        break;
                    }
                case "Eb12-carport":
                    {
                        if (dofixed)
                        {
                            AddBlock("carport1", new Vector3(23.5f, 2, 0.1f), 0, new Vector3(21.9f, 1, -11.1f), "darkbrown");
                            AddBlock("carport2", new Vector3(0.1f, 2, 6.7f), 0, new Vector3(10.2f, 1, -7.7f), "darkbrown");
                            AddBlock("carport3", new Vector3(0.1f, 2, 6.7f), 0, new Vector3(33.6f, 1, -7.7f), "darkbrown");
                            AddBlockR("carport4", new Vector3(23.8f, 0.2f, 6.7f), new Vector3(-4.4f, 0, 0), new Vector3(21.6f, 2.5f, -7.7f), "silver");
                            float x = 10.2f;
                            for (int i = 1; i < 8; i++)
                            {
                                x += 2.925f;
                                AddBlock("carportpole" + i, new Vector3(0.1f, 2.7f, 0.1f), 0, new Vector3(x, 1.35f, -4.65f), "darkbrown");
                            }
                        }
                        break;
                    }
                case "Eb17":
                    {
                        if (dofixed)
                        {
                            AddQuadHouse("blk1", new Vector3(25.75f, 6.5f, 14.67f), -3.4 + 90, new Vector3(-17.8f, 3.25f, 34.7f), rufcolor: "dimgray");
                        }
                        break;
                    }
                case "Eb19":
                    {
                        if (dofixed)
                        {
                            AddFlatQuadHouse("blk1", new Vector3(14.91f, 6.5f, 6.48f), -3.4, new Vector3(-24.2f, 3.25f, 9.5f), rufcolor: "dimgray");
                        }
                        break;
                    }
                case "Eb30":
                    {

                        if (dofixed)
                        {
                            AddQuadHouse("blk1", new Vector3(15.7f, 6.5f, 12.17f), -3.4, new Vector3(-11.2f, 3.25f, -6.2f), rufcolor: "dimgray");
                        }
                        break;
                    }
                case "EbIdb25":
                    {
                        if (dofixed)
                        {
                            AddQuadHouse("haus", new Vector3(28.6f, 13f, 13.91f), -3.4, new Vector3(18.9f, 3.25f, -30.1f));
                            //AddBlock("blk1", new Vector3(28.6f, 6.5f, 13.91f), -3.4, new Vector3(18.9f, 3.25f, -30.1f));
                            //AddBlockR("ruf1", new Vector3(28.6f, 0.1f, 10f), new Vector3(+45, -3.4f, 0), new Vector3(18.7f, 10f, -26.6f), "red");
                            //AddBlockR("ruf2", new Vector3(28.6f, 0.1f, 10f), new Vector3(-45, -3.4f, 0), new Vector3(19.1f, 10f, -33.6f), "red");
                            //AddBlockR("sid1", new Vector3(10f, 0.1f, 10f), new Vector3(45, -3.4f, 90), new Vector3(33.1f, 6.3f, -29.1f), "white");
                            //AddBlockR("sid2", new Vector3(10f, 0.1f, 10f), new Vector3(45, -3.4f, 90), new Vector3(4.8f, 6.4f, -31.0f), "white");
                        }
                        break;
                    }
                case "EbIdb35":
                    {
                        if (dofixed)
                        {
                            AddQuadHouse("haus", new Vector3(26.0f, 13f, 13.91f), -3.4, new Vector3(-14.6f, 3.25f, -31.7f));
                            //AddBlock("blk1", new Vector3(26.0f, 6.5f, 13.91f),                 -3.4,     new Vector3(-14.6f, 3.25f, -31.7f));
                            //AddBlockR("ruf1", new Vector3(26.0f, 0.1f, 10f), new Vector3(+45, -3.4f, 0), new Vector3(-14.8f, 10f, -28.2f), "red");
                            //AddBlockR("ruf2", new Vector3(26.0f, 0.1f, 10f), new Vector3(-45, -3.4f, 0), new Vector3(-14.4f, 10f, -35.2f), "red");
                            //AddBlockR("sid1", new Vector3(10f, 0.1f, 10f), new Vector3(45, -3.4f, 90),   new Vector3(-1.7f,  6.3f,-31.0f), "white");
                            //AddBlockR("sid2", new Vector3(10f, 0.1f, 10f), new Vector3(45, -3.4f, 90), new Vector3(-27.5f, 6.4f, -32.5f), "white");
                        }
                        break;
                    }
                case "EbOphome":
                    {
                        if (dofixed)
                        {
                            AddFlatQuadHouse("blk1", new Vector3(26.9f, 5, 16.7f), -3.4, new Vector3(54.6f, 4f, -2.7f));
                            AddFlatQuadHouse("blk2", new Vector3(26.9f, 5, 16.7f), -3.4, new Vector3(56.53f, 4f, -35.05f));
                            AddFlatQuadHouse("blk3", new Vector3(10.75f, 5, 66.87f), -3.4, new Vector3(74.1f, 4f, -8.5f));
                            AddFlatQuadHouse("blk4", new Vector3(15.88f, 5, 20.17f), -3.4, new Vector3(66.3f, 4f, 34.8f));
                        }
                        break;
                    }
                case "EbRewe":
                    {
                        if (dofixed)
                        {
                            AddQuadHouse("blk1", new Vector3(60, 5, 60), -28.82 + 90, new Vector3(300.5f, 2.5f, 156.1f), rufcolor: "darkgreen");
                        }
                        break;
                    }
                case "BldRWB":
                    {
                        //AddResource("pine1", "TreesAndShrubs/PineTree", new Vector3(0.4f, 0.4f, 0.4f), 180, new Vector3(-1987.0f, 0, -1167.7f));
                        //AddResource("pine2", "TreesAndShrubs/PineTree", new Vector3(0.4f, 0.4f, 0.4f), 180, new Vector3(-1959.9f, 0, -1242.6f));
                        if (bm.sman.curscene == SceneSelE.MsftB19focused || bm.sman.curscene == SceneSelE.MsftB121focused)
                        {
                            defPercentFull = 0.05f;
                        }
                        else
                        {
                            defPercentFull = 0.95f;
                        }
                        if (tmode == BuildingMan.TreeModeE.full)
                        {
                            var pnm = "rwgpine";
                            AddLineOfPines(pnm, 14, new Vector3(-1987.0f, 0, -1167.7f), new Vector3(-1956.1f, 0, -1260.4f));
                            AddLineOfPines(pnm, 6, new Vector3(-2039.6f, 0, -1169.0f), new Vector3(-2005.8f, 0, -1157.4f));
                            AddLineOfPines(pnm, 1, new Vector3(-1996.4f, 0, -1161.4f), new Vector3(-1996.4f, 0, -1161.4f));
                            AddLineOfPines(pnm, 3, new Vector3(-2047.4f, 0, -1179.1f), new Vector3(-2043.6f, 0, -1192.9f));
                            AddLineOfPines(pnm, 5, new Vector3(-2037.1f, 0, -1211.1f), new Vector3(-2025.8f, 0, -1248.1f));
                            AddLineOfPines(pnm, 3, new Vector3(-2021.2f, 0, -1262.3f), new Vector3(-2016.3f, 0, -1275.4f));
                            AddLineOfPines(pnm, 2, new Vector3(-2004.7f, 0, -1278.8f), new Vector3(-1993.9f, 0, -1275.5f));
                            AddLineOfPines(pnm, 2, new Vector3(-1976.9f, 0, -1272.3f), new Vector3(-1966.9f, 0, -1269.0f));
                            var bnm = "rwgbush";
                            AddLineOfBushes(bnm, 2, new Vector3(-2024.2f, 0, -1190.3f), new Vector3(-2019.1f, 0, -1188.8f));
                            AddLineOfBushes(bnm, 2, new Vector3(-2007.2f, 0, -1184.7f), new Vector3(-2002.5f, 0, -1182.8f));
                            AddLineOfBushes(bnm, 2, new Vector3(-2014.3f, 0, -1220.5f), new Vector3(-2009.3f, 0, -1219.4f));
                            AddLineOfBushes(bnm, 2, new Vector3(-1998.2f, 0, -1215.4f), new Vector3(-1992.3f, 0, -1213.5f));
                            AddLineOfBushes(bnm, 2, new Vector3(-2004.6f, 0, -1251.2f), new Vector3(-1998.8f, 0, -1249.2f));
                            AddLineOfBushes(bnm, 2, new Vector3(-1987.1f, 0, -1245.3f), new Vector3(-1980.9f, 0, -1243.3f));
                        }
                        AddBldMarker("BldRWBmark", 47.639217f, -122.140190f);
                        AddRedwestBAlarms();
                        break;
                    }
                case "Bld11":
                    {
                        AddBldMarker("Bld11mark", 47.639792f, -122.131383f);
                        AddBldPoleCamera("Bld11raspipole", -131.42f, 223.8f, 0f, 2f);
                        break;
                    }
                case "Bld19":
                    {
                        AddBldMarker("Bld19mark", 47.643061f, -122.131348f);
                        AddBldPoleCamera("Bld19raspipole", -451.5f, 98.3f,-44.0f, 2f);
                        AddB19Alarms();
                        break;
                    }
                case "Bld40":
                    {
                        AddBldMarker("Bld40mark", 47.636579f, -122.133196f);
                        break;
                    }
                case "Bld43":
                    {
                        AddBldMarker("Bld43mark", 47.659378f, -122.133196f);
                        AddBldPoleCamera("Bld43raspipole", 35.87f, -13.31f, -160.8f,2f);
                        break;
                    }
                case "Bld99":
                    {
                        AddBldMarker("Bld99mark", 47.642388f, -122.142093f);
                        break;
                    }
                case "BldSX":
                    {
                        AddBldMarker("BldSXmark", 47.641363f, -122.136217f);
                        break;
                    }
                default:
                    {
                        //Debug.Log("No building gos for " + name);
                        break;
                    }
            }
        }
        public void AddRedwestBAlarms()
        {
            string[] anodes = {
                "rwb-f03-cv0-s",  "rwb-f03-cv0-e", "rwb-f03-cv1-s", "rwb-f03-cv1-e",
                "rwb-f03-cv2-s",  "rwb-f03-cv2-e", "rwb-f03-cv3-s", "rwb-f03-cv3-e",
                "rwb-f03-ch11-0", "rwb-f03-ch10-0", "rwb-f03-ch10-0" };
            var ago = new GameObject("Alarms");
            bldgos.Add(ago);
            ago.transform.parent = transform;
            foreach(var ade in anodes)
            {
                AddAlarmToNode(ago, "BldEvacAlarm" + ade, ade);
            }
        }
        public void AddB19Alarms()
        {
            string[] anodes = {
                "b19-os1-o03",
//                "b19-f01-lobby",
            };
            var ago = new GameObject("Alarms");
            bldgos.Add(ago);
            ago.transform.parent = transform;
            foreach (var ade in anodes)
            {
                AddAlarmToNode(ago, "BldEvacAlarm" + ade, ade);
            }
        }
        public void AddEb12Alarms()
        {
            string[] anodes = {
                "eb12-el-lp04b",   };
            var ago = new GameObject("Alarms");
            bldgos.Add(ago);
            ago.transform.parent = transform;
            foreach (var ade in anodes)
            {
                AddAlarmToNode(ago, "BldEvacAlarm" + ade, ade,almheight:3);
            }
        }
    }
}
