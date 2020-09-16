using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Aiskwk.Map;
using GraphAlgos;
using CampusSimulator;

[Serializable]
public class NodeRegion
{
    public string name;
    public string color;
    public int regid;
    public bool saveToFile;
    public int maxDefStepIdx;
    public GameObject reggo;
    public NodeRegion()
    {
        maxDefStepIdx = 1;
        reggo = null;
    }
    public int GetCurStepIdx()
    {
        return maxDefStepIdx;
    }

    public void IncDefStepIdx()
    {
        maxDefStepIdx++;
    }
}

public class NodeRegionMan : MonoBehaviour
{

    GraphCtrl grc;
    Dictionary<string, NodeRegion> regionDict;
    public NodeRegion curNodeRegion;
    public int nnodes;
    public int nlinks;
    public int nregions;
    public List<string> regiondesc = null;
    public int regionNodeSum;
    public string NodeMultiplicty = "";
    public bool dumpMultiNodes = false;


    public void Init(GraphCtrl grc)
    {
        this.grc = grc;
        regionDict = new Dictionary<string, NodeRegion>();
        curNodeRegion = NewNodeRegion("default", "red", false);
    }
    public void RefreshVals()
    {
        nregions = GetNodeRegionCount();
        regiondesc = GetNodeRegionsDesc();
        regionNodeSum = GetNodeRegionCountSum();
        NodeMultiplicty = GetMultiplicityDesc();
        nnodes = grc.GetNodeCount();
        nlinks = grc.GetLinkCount();
    }

    public List<NodeRegion> GetRegions()
    {
        var rv = new List<NodeRegion>(regionDict.Values);
        return rv;
    }
    public NodeRegion NewNodeRegion(string name, string color, bool saveToFile, bool makeCurrent = true, bool warnondups = false)
    {
        //Debug.Log($"NewNodeRegion:{name}");
        NodeRegion newRegion;
        if (regionDict.ContainsKey(name))
        {
            if (warnondups)
            {
                Debug.LogWarning("NewNodeRegion " + name + " already exists");
            }
            newRegion = regionDict[name];
        }
        else
        {
            newRegion = new NodeRegion { name = name, color = color, saveToFile = saveToFile, regid = regionDict.Count + 2000 };
            regionDict[name] = newRegion;
        }
        if (makeCurrent)
        {
            curNodeRegion = newRegion;
        }
        return newRegion;
    }
    public bool SetRegion(string name)
    {
        if (!regionDict.ContainsKey(name))
        {
            Debug.LogWarning("NodeRegion man does not contain a region:" + name);
            return false;
        }
        curNodeRegion = regionDict[name];
        return true;
    }
    public NodeRegion GetRegion(string name)
    {
        if (!regionDict.ContainsKey(name))
        {
            Debug.LogWarning("Unknown regionname:" + name + " in GetRegion");
            return null;
        }
        var rv = regionDict[name];
        return rv;
    }
    public NodeRegion GetRegion(int regid)
    {
        foreach (var reg in regionDict.Values)
        {
            if (reg.regid == regid)
            {
                return reg;
            }
        }
        return null;
    }
    public NodeRegion GetCurrent()
    {
        return curNodeRegion;
    }
    public int GetNodeRegionCount()
    {
        return regionDict.Count;
    }
    public List<int> GetNodeRegionCounts()
    {
        var rv = new List<int>();
        foreach (var r in regionDict.Values)
        {
            var ncnt = grc.GetNodeCount(r.regid);
            rv.Add(ncnt);
        }
        return rv;
    }
    public int GetNodeRegionCountSum()
    {
        var cnts = GetNodeRegionCounts();
        return cnts.Sum();
    }
    public List<string> GetNodeRegionsDesc()
    {
        var cnts = GetNodeRegionCounts();
        var rv = new List<string>();
        foreach (var r in regionDict.Values)
        {
            var ncnt = grc.GetNodeCount(r.regid);
            var msg = "Region " + r.name + " " + r.color + " id:" + r.regid + " nodes:" + ncnt;
            rv.Add(msg);
        }
        return rv;
    }
    static string ListToStr(List<int> ilist)
    {
        var rv = "";
        ilist.ForEach(x => rv += x.ToString() + " ");
        return rv;
    }
    public string GetMultiplicityDesc()
    {
        var maxcnt = 5;
        var cnt = new int[maxcnt];
        foreach (var n in grc.GetLcNodes())
        {
            var multi = 0;
            if (n.regid != 0)
            {
                multi = 1;
            }
            if (multi > maxcnt) multi = maxcnt;
            cnt[multi]++;
        }
        var rv = "Node Regions Multiplicity: ";
        for (int i = 0; i < maxcnt; i++)
        {
            if (i == maxcnt - 1)
            {
                rv += i + "+:" + cnt[i] + "   ";
            }
            else
            {
                rv += i + ":" + cnt[i] + "   ";
            }
        }
        rv += "   sum:" + cnt.Sum();
        return rv;
    }
    public void DumpMultiNodes()
    {
        //foreach (var n in grc.GetLcNodes())
        //{
        //    var multi = n.regions.Count();
        //    if (multi==0 || multi>1)
        //    {
        //        Debug.Log("Node "+n.name+" n:"+multi+"  ids:"+ListToStr(n.regions));
        //    }
        //}
    }




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dumpMultiNodes)
        {
            grc.regman.DumpMultiNodes();
            dumpMultiNodes = false;
        }

    }
}
