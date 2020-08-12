using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// GraphAlgos.cs  - This file contains Graph algorithems that we need. It is fairly self-contained. 
/// </summary>

namespace GraphAlgos
{


    public class StatusMsg
    {
        public bool ok;
        public string status;
        public StatusMsg(bool ok, string status)
        {
            this.ok = ok;
            this.status = status;
        }
        public string fullstatus()
        {
            var msg = "ok:" + ok + " " + status;
            return msg;
        }
    }
    public class Range
    {
        public float min;
        public float max;

        public Range(float min = 0, float max = 0)
        {
            this.min = min;
            this.max = max;
        }
        public float clamp(float val)
        {
            return (System.Math.Min(max, System.Math.Max(min, val)));
        }
    }

    #region basics - Weg,LcNode,LcLink

    [Serializable]
    public class LcNode
    {
        public GraphCtrl grc;
        public string name;
        public Vector3 pt;
        public Transform transform;
        public int transformSetCount = 0;
        public HashSet<Weg> wegtos;
        public int regid;
        public LinkUse usetype;
        public string comment;
        public int regionStepIdx;
        

        public LcNode cameFrom;
        public float fScore;
        public float gScore;

        public float lng;
        public float lat;

        public GameObject go;

        //private static int newnamenumber = 0;
        //public static string genuniquename()
        //{
        //    var newname = "uniqnodename-" + newnamenumber;
        //    newnamenumber++;
        //    return newname;
        //}

        public static string NormName(string name)
        {
            if (name.EndsWith("-sph"))
            {
                return name.Substring(0, name.Length - 4);
            }
            else
            {
                return name;
            }
        }

        public LcNode(GraphCtrl grc, string name, Vector3 pt,LinkUse usetype,ref NodeRegion nodeRegion,string comment="")
        {
            this.grc = grc;
            this.name = name;
            this.pt = pt;
            this.usetype = usetype;
            this.regid = nodeRegion.regid;
            this.comment = comment;
            regionStepIdx = nodeRegion.GetCurStepIdx();
            wegtos = null;
            AstarInit();
        }
        public bool IsInRegion(int regid)
        {
            return this.regid == regid;
        }
        public void ResetWegs()
        {
            wegtos = null;
        }
        public float heuristic_cost_estimate(LcNode topt)
        {
            var f = Vector3.Distance(pt, topt.pt);
            return (f);
        }
        public void AddWeg(Weg weg)
        {
            if (wegtos == null)
            {
                wegtos = new HashSet<Weg>();
            }
            wegtos.Add(weg);
        }
        public void DelWeg(Weg weg)
        {
            if (wegtos == null)
            {
                wegtos = new HashSet<Weg>();
            }
            wegtos.Remove(weg);
        }
        public void AstarInit()
        {
            cameFrom = null;
            gScore = 9e30f;
            fScore = 9e30f;
        }
        public bool WasMoved()
        {
            var rv = false;
            if (go != null)
            {
                var gpt = go.transform.position;
                if (gpt.x != pt.x || gpt.y != pt.y || gpt.z != pt.z)
                {
                    //Debug.Log(name + " moved from " + pt + " to " + gpt);
                    rv = true;
                }
            }
            return rv;
        }
        public void SyncToGo(bool lockYval)
        {
            if (go != null)
            {
                var gpt = go.transform.position;
                if (lockYval)
                {
                    pt = new Vector3(gpt.x,pt.y,gpt.z);
                    go.transform.position = pt;
                    //Debug.Log(name + " synced to " + pt);
                }
                else
                {
                    pt = gpt;
                }
            }
        }
    }

    public enum LcCapType { walk, drive, waterflow, elecflow, anything, fly }
    public enum LinkUse { legacy, highway, road, slowroad, driveway, walkway, walkwaynoshow, marker, excavation, waterpipe, recwaterpipe,sewerpipe, elecpipe,commspipe,oilgaspipe, bldwall, trackperson,trackheli,trackdrone, droneway }

    [Serializable]
    public class LcLink
    {
        public GraphCtrl grc;
        public GameObject lgo;

        public static bool CanDoCapFromUse(LcCapType cap,LinkUse use)
        {
            if (cap == LcCapType.anything) return true;
            if (!candodict.ContainsKey(cap)) return false;
            var curdict = candodict[cap];
            var rv = curdict.ContainsKey(use);
            return rv;
        }

        public static Dictionary<LinkUse, float> walkcost = new Dictionary<LinkUse, float>()
        {
            {LinkUse.legacy,1.0f },
            {LinkUse.walkwaynoshow,1.0f },
            {LinkUse.walkway,1.0f },
            {LinkUse.driveway,10.0f },
            {LinkUse.trackperson,1.0f },
        };
        public static Dictionary<LinkUse, float> drivecost = new Dictionary<LinkUse, float>()
        {
            {LinkUse.legacy,1.0f },
            {LinkUse.highway,0.5f },
            {LinkUse.road,1.0f },
            {LinkUse.slowroad,2.0f },
            {LinkUse.driveway,4.0f },
        };
        public static Dictionary<LinkUse, float> watercost = new Dictionary<LinkUse, float>()
        {
            {LinkUse.waterpipe,1.0f },
        };
        public static Dictionary<LinkUse, float> eleccost = new Dictionary<LinkUse, float>()
        {
            {LinkUse.elecpipe,1.0f },
        };

        public static Dictionary<LinkUse, float> flycost = new Dictionary<LinkUse, float>()
        {
            {LinkUse.trackheli,1.0f },
            {LinkUse.trackdrone,1.0f },
        };

        public static Dictionary<LcCapType, Dictionary<LinkUse, float>> candodict = new Dictionary<LcCapType, Dictionary<LinkUse, float>>()
        {
            {LcCapType.walk,walkcost},
            {LcCapType.drive,drivecost},
            {LcCapType.waterflow,watercost},
            {LcCapType.elecflow,eleccost},
            {LcCapType.fly,flycost},
        };

        public LinkUse usetype;

        public string name;
        public string node1spec;
        public string node2spec;
        public LcNode node1;
        public LcNode node2;
        public float len;
        public Weg w1;
        public Weg w2;
        public string comment;
        public int regionStepIdx;
        public int regid;

        public static string NormName(string name)
        {
            if (name.EndsWith("-cyl"))
            {
                return name.Substring(0, name.Length - 4);
            }
            else
            {
                return name;
            }
        }

        public LcLink(GraphCtrl grc, string name, LcNode node1, LcNode node2, LinkUse usetype=LinkUse.legacy,string comment="")
        {
            this.grc = grc;
            this.usetype = usetype;
            this.name = name;
            this.node1 = node1;
            this.node2 = node2;
            this.node1spec = "";
            this.node2spec = "";
            this.comment = "";
            var regid = grc.regman.curNodeRegion.regid;
            if (node1.regid==node2.regid)
            {
                regid = node1.regid;
            }
            this.regid = regid;
            this.regionStepIdx = grc.regman.curNodeRegion.GetCurStepIdx();
            len = Vector3.Distance(node1.pt, node2.pt);
            LinkLink();
        }
        public void SetNode1Spec(string spec)
        {
            this.node1spec = spec;
        }
        public void SetNode2Spec(string spec)
        {
            this.node2spec = spec;
        }
        public bool IsInRegion(int regid)
        {
            return this.regid==regid;
        }
        public float Cost(LcCapType cap, LinkUse usetyp)
        {
            if (cap == LcCapType.anything) return 1;
            if (!candodict.ContainsKey(cap)) return -1;
            var curdict = candodict[cap];
            if (curdict.ContainsKey(usetyp)) return -1;
            return curdict[usetyp];
        }
        public void LinkLink()
        {
            w1 = new GraphAlgos.Weg(this, this.node2, this.node1);
            w2 = new GraphAlgos.Weg(this, this.node1, this.node2);
            node1.AddWeg(w1);
            node2.AddWeg(w2);
        }
        public void UnlinkLink()
        {
            node1.DelWeg(w1);
            node2.DelWeg(w2);
        }
        public Vector3 LambPt(float l)
        {
            var p1wc = node1.pt; // we use this to build our grids before the transforms have been defined
            var p2wc = node2.pt;
            if (node1.transform != null)
            {
             //   p1wc = node1.transform.TransformPoint(node1.pt);
             //   p2wc = node2.transform.TransformPoint(node2.pt);
            }
            //var rpt = (lp2.pt-lp1.pt)*l + lp1.pt;
            var rpt = (p2wc - p1wc) * l + p1wc;
            //Debug.Log("float rpt:" + rpt.ToString("f4"));
            return (rpt);
        }
        public Vector3 LambPt(double l)
        {
            var p1wc = node1.pt; // we use this to build our grids before the transforms have been defined
            var p2wc = node2.pt;
            if (node1.transform != null)
            {
                //   p1wc = node1.transform.TransformPoint(node1.pt);
                //   p2wc = node2.transform.TransformPoint(node2.pt);
            }
            //var rpt = (lp2.pt-lp1.pt)*l + lp1.pt;
            var dblx = (p2wc.x-p1wc.x)*l + p1wc.x;
            var dbly = (p2wc.y-p1wc.y)*l + p1wc.y;
            var dblz = (p2wc.z-p1wc.z)*l + p1wc.z;
            var rpt = new Vector3((float)dblx,(float)dbly,(float)dblz);
            //Debug.Log("double rpt:" + rpt.ToString("f4"));
            return (rpt);
        }
        public double FindClosestLamb(Vector3 pt)
        {
            var p1wc = node1.pt;
            var p2wc = node2.pt;
            if (node1.transform != null)
            {
             //   p1wc = node1.transform.TransformPoint(node1.pt);
             //   p2wc = node2.transform.TransformPoint(node2.pt);
            }
            return (GraphUtil.FindClosestLambClampedTo01(pt, p1wc, p2wc));
        }
        public float FindClosestLambBruteForce(Vector3 pt)
        {
            float mindist = 9e30f;
            float minlamb = 0;
            var nres = 16;
            float nresf = nres;
            Vector3 dlt = (node2.pt - node1.pt);
            for (int i = 0; i <= nres; i++)
            {
                float lamb = i / nresf;
                var lpt = dlt * lamb + node1.pt;
                float dist = Vector3.Distance(pt, lpt);
                if (dist < mindist)
                {
                    mindist = dist;
                    minlamb = lamb;
                }
            }
            return (minlamb);
        }
        public Vector3 FindClosestPointOnLink(Vector3 pt)
        {
            double ld = FindClosestLamb(pt);
            //float lf = (float)ld;           
            //Debug.Log("lf:"+lf+"  ld:"+ld);
            //var rf = LambPt(lf);
            var rd = LambPt(ld);
            //       GraphUtil.Log(" minlamb:" + l);
            return rd;
        }
    }
    public class Weg
    {
        public Guid id=Guid.NewGuid();
        public LcLink link;
        public LcNode frNode;
        public LcNode toNode;
        public float distance;
        public Weg(LcLink link, LcNode tonode, LcNode frnode)
        {
            this.link = link;
            this.toNode = tonode;
            this.frNode = frnode;
            this.distance = Vector3.Distance(frnode.pt, tonode.pt);
        }
        public Vector3 GetWegDirection(bool normalized = true)
        {
            var p1 = frNode.pt;
            var p2 = toNode.pt;
            var wdir = p2 - p1;
            if (normalized)
            {
                wdir = Vector3.Normalize(wdir);
            }
            return (wdir);
        }
        public Vector3 LambPt(float lamb)
        {
            var dlt = toNode.pt - frNode.pt;
            var rv = lamb * dlt + frNode.pt;
            return (rv);
        }
    }
    public class PathPos
    {
        public Path path;
        public Vector3 pt;
        public Weg weg;
        public int index;
        public float lambda;
        public float wegDistSoFar;
        public bool OnPath
        {
            get
            {
                return (0 <= lambda && lambda <= 1);
            }
        }
        public PathPos(Path path, Vector3 pt, Weg weg, int index, float lambda)
        {
            this.path = path;
            this.pt = pt;
            this.weg = weg;
            this.index = index;
            this.lambda = lambda;
            this.wegDistSoFar = weg.distance * lambda;
        }
    }
    public class Path
    {
        public Vector3 startpt = Vector3.zero;
        public Vector3 endpt = Vector3.zero;
        public Vector3 weg1Pt1 = Vector3.zero;
        public Vector3 weg1Pt2 = Vector3.zero;
        public Vector3 weg1FrPt = Vector3.zero;
        public Vector3 weg1ToPt = Vector3.zero;
        public LcNode start;
        public LcNode end;
        public List<Weg> waypts = new List<Weg>();
        public PathPos pathPos = null;
        public Path(LcNode start)
        {
            this.start = start;
            startpt = start.pt;
        }
        public void AddWaypt(Weg w)
        {
            // should control to see if additions are consistent
            waypts.Add(w);
            if (waypts.Count == 1)
            {
                weg1Pt1 = w.link.node1.pt;
                weg1Pt2 = w.link.node2.pt;
                weg1FrPt = w.frNode.pt;
                weg1ToPt = w.toNode.pt;
            }
        }
        public void Finish()
        {
            if (waypts.Count<=0)
            {
                Debug.LogError($"Can't finish genAstar when the node count is zero");
                return;
            }
            end = waypts[waypts.Count - 1].toNode;
            endpt = end.pt;
        }
        float _plen = -1;
        public float pathLength
        {
            // returns total path length
            get
            {
                if (_plen < 0)
                {
                    _plen = 0;
                    foreach (var w in waypts)
                    {
                        _plen += w.distance;
                    }
                }
                return (_plen);
            }
        }
        public PathPos MovePositionAlongPath(float targetDist)
        {
            // returns the position on the path after moving "target" units along the path
            float dst = 0;
            int i = 0;
            float lmd = 0;
            var p1 = start.pt;
            var p2 = p1;
            foreach (var weg in waypts)
            {
                p2 = weg.toNode.pt;
                //GraphUtil.Log("mpp i:" + i + "  p1wc:" + p1wc + "  p2wc:" + p2wc);
                var ndst = dst + weg.distance;
                if (ndst > targetDist)
                {
                    lmd = (targetDist - dst) / weg.distance;
                    var pt = lmd * (p2 - p1) + p1;
                    //GraphUtil.Log("mpp i:" + i + " lmd:" + lmd + "ptwc:"+ptwc);
                    var pp1 = new PathPos(this, pt, weg, i, lmd);
                    return (pp1);
                }
                dst = ndst;
                p1 = p2;
                i++;
            }
            // Edge cases - at start and end of path
            PathPos pp2;
            var wcnt = waypts.Count;
            if (wcnt == 0)
            {
                // at the start
                pp2 = new PathPos(this, p2, null, wcnt - 1, 1);
            }
            else
            {
                // at the end
                var ww = waypts[wcnt - 1];
                pp2 = new PathPos(this, p2, ww, wcnt - 1, 1);
            }
            return (pp2);
        }
    }

    #endregion
}

