using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UxUtils;

public class B121Willow : MonoBehaviour
{
    public enum b121_MaterialMode {  raw, materialed, glasswalls, glassfloors, glass };

    public UxSetting<bool> loadmodel = new UxSetting<bool>("B121_WillowModel", true);
    public UxSetting<bool> shell = new UxSetting<bool>("B121_shell", true);
    public UxSetting<bool> interiorwalls = new UxSetting<bool>("B121_interiorwalls", true);
    public UxSetting<bool> hvac = new UxSetting<bool>("B121_hvac", true);
    public UxSetting<bool> lighting = new UxSetting<bool>("B121_lights", true);
    public UxSetting<bool> plumbing = new UxSetting<bool>("B121_plumbing", true);
    public UxSetting<bool> osmbld = new UxSetting<bool>("B121_osmbld", false);

    public CampusSimulator.SceneMan sman;

    public UxEnumSetting<b121_MaterialMode> b121_materialMode = new UxEnumSetting<b121_MaterialMode>("B121_MaterialMode", b121_MaterialMode.glass);
    //   public UxSetting<bool> visibilityTiedToDetectability = new UxSetting<bool>("FrameVisibilityTiedToDetectability", true);
    // public B19_MaterialMode materialMode = B19_MaterialMode.materialed;


    CampusSimulator.Building bld;


    bool _b121_WillowModelLoaded = false;
    bool _b121_shell = false;
    bool _b121_interiorwalls = false;
    bool _b121_hvac = false;
    bool _b121_lighting = false;
    bool _b121_plumbing = false;
    bool _b121_osmbld = false;
    b121_MaterialMode lastMaterialMode;

    GameObject b121go = null;
    GameObject b121sgo = null;
    GameObject b121igo = null;
    GameObject b121hgo = null;
    GameObject b121lgo = null;
    GameObject b121pgo = null;

    public void InitializeValues(CampusSimulator.SceneMan sman,CampusSimulator.Building bld)
    {
        //Debug.Log("B121Willow.InitializeValues");
        this.sman = sman;
        this.bld = bld;
        b121_materialMode.GetInitial(b121_MaterialMode.glasswalls);
        loadmodel.GetInitial(true);
        _b121_shell = shell.GetInitial(true);
        _b121_interiorwalls = interiorwalls.GetInitial(true);
        _b121_hvac = hvac.GetInitial(false);
        _b121_lighting = lighting.GetInitial(false);
        _b121_plumbing = plumbing.GetInitial(false);
        _b121_osmbld = osmbld.GetInitial(false);
        lastMaterialMode = b121_materialMode.Get();
        //Debug.Log($"b121.loadmodel:{loadmodel.Get()}");
        //Debug.Log($"b121.shell:{shell.Get()}");
        //Debug.Log($"b121.interior:{interiorwalls.Get()}");
        //Debug.Log($"b121.hvac:{hvac.Get()}");
        //Debug.Log($"b121.lighting:{lighting.Get()}");
        //Debug.Log($"b121.plumbing:{plumbing.Get()}");
        //Debug.Log($"b121.osmbld:{osmbld.Get()}");
        //Debug.Log($"b121.materialmode:{b121_materialMode.Get()}");
    }



    bool ChangeHappened()
    {
        var chg = false;
        if (loadmodel.Get() != _b121_WillowModelLoaded) chg = true;
        if (shell.Get() != _b121_shell)
        {
            //Debug.Log($"b121 shell changed to {shell.Get()}");
            chg = true;
        }
        if (interiorwalls.Get() != _b121_interiorwalls)
        {
            //Debug.Log($"b121 interior changed to {interiorwalls.Get()}");
            chg = true;
        }
        if (hvac.Get() != _b121_hvac)
        {
            //Debug.Log($"b121 hvac changed to {hvac.Get()}");
            chg = true;
        }
        if (lighting.Get() != _b121_lighting)
        {
            //Debug.Log($"b121 lighting changed to {lighting.Get()}");
            chg = true;
        }
        if (plumbing.Get() != _b121_plumbing)
        {
            //Debug.Log($"b121 plumbing changed to {plumbing.Get()}");
            chg = true;
        }
        if (osmbld.Get() != _b121_osmbld)
        {
            //Debug.Log($"b121 osmbld changed to {osmbld.Get()}");
            chg = true;
        }
        if (b121_materialMode.Get() != lastMaterialMode)
        {
            //Debug.Log($"b121 material changed to {b121_materialMode.Get()}");
            chg = true;
        }
        return chg;
    }




    public GameObject LoadObjFile(GameObject parent,string resourcename,string objname,float ska=1,float xrot=0, float xoff = 0, float yoff = 0,float zoff=0)
    {
        var obprefab = Resources.Load<GameObject>(resourcename);
        if (obprefab != null)
        {
            var objgo = Instantiate<GameObject>(obprefab);
            var ftm = ska;
            objgo.name = objname;
            objgo.transform.localScale = new Vector3(ftm, ftm, ftm);
            objgo.transform.position = new Vector3(xoff, yoff, zoff);
            objgo.transform.Rotate(new Vector3(xrot, 0, 0));
            objgo.transform.SetParent(parent.transform, worldPositionStays: false);
            return objgo;
        }
        return null;
    }

    public void DestroyOneGo(ref GameObject bgo)
    {
        if (bgo != null)
        {
            Destroy(bgo);
            bgo = null;
        }
    }

    public void DestroyGos()
    {
        DestroyOneGo(ref b121sgo);
        DestroyOneGo(ref b121igo);
        DestroyOneGo(ref b121hgo);
        DestroyOneGo(ref b121lgo);
        DestroyOneGo(ref b121pgo);
        DestroyOneGo(ref b121go);
    }
    public void MakeItSo()
    {
        bool loadedThisTime = false;
        //Debug.Log($"MakeItSo loadModel:{loadmodel.Get()} _b19WillowModel:{_b19_WillowModelLoaded}");
        if (loadmodel.Get() && !_b121_WillowModelLoaded)
        {
            b121go = new GameObject("B121-Willow");
            var xofs = 0;
            var yofs = 0;
            //var yofs = -1;
            //var yoff = 5.8f;
            var zofs = 0;
            Vector3 defpos = new Vector3(-789 + xofs, yofs, -436 + zofs);
            if (sman != null)
            {
                var yheit = sman.mpman.GetHeight(defpos.x, defpos.z);
                //Debug.Log($"B19 yoff:{yoff}");
                defpos = new Vector3(defpos.x, yheit + defpos.y, defpos.z);
            }
            b121go.transform.Rotate(new Vector3(0, -20.15f, 0));
            b121go.transform.position = defpos;
            b121go.transform.SetParent(this.transform,worldPositionStays:false);

            _b121_shell = false;
            _b121_interiorwalls = false;
            _b121_hvac = false;
            _b121_lighting = false;
            _b121_plumbing = false;
            _b121_osmbld = sman.bdman.osmblds.Get();
            _b121_WillowModelLoaded = true;
            loadedThisTime = true;
        }
        else if(!loadmodel.Get() && _b121_WillowModelLoaded)
        {
            DestroyGos();

            loadmodel.SetAndSave( false );
            _b121_WillowModelLoaded = false;

            shell.SetAndSave(false);
            _b121_shell = false;

            interiorwalls.SetAndSave( false );
            _b121_interiorwalls = false;

            hvac.SetAndSave( false );
            _b121_hvac = false;

            lighting.SetAndSave(false);
            _b121_lighting = false;

            plumbing.SetAndSave(false);
            _b121_plumbing = false;
            _b121_osmbld = sman.bdman.osmblds.Get();

        }
        if (b121go)
        {
            if (osmbld.Get() != _b121_osmbld)
            {
                var stat = osmbld.Get();
                var bspec = sman.bdman.FindBldSpecByNameStart(bld.osmnamestart);
                
                if (bspec != null)
                {
                    sman.bdman.RegisterBsBld(bspec, bld);
                    bspec.isVisible = stat;
                    if (bspec.bgo != null)
                    {
                        bspec.bgo.SetActive(stat);
                    }
                }
                _b121_osmbld = stat;
            }
            var bshellska = 0.025f;
            var bang = -90;
            var bxoff = 1.6f;
            var bzoff = 1.3f;

            if (shell.Get() != _b121_shell)
            {
                var stat = shell.Get();
                //b121sgo.SetActive(stat);
                if (stat)
                {
                    b121sgo = LoadObjFile(b121go, "Willow/B121/1716045-BH-AR-BASE_R20", "shell", ska: bshellska);
                    loadedThisTime = true;
                }
                else
                {
                    DestroyOneGo(ref b121sgo);
                }
                _b121_shell = stat;
            }

            if (interiorwalls.Get() != _b121_interiorwalls)
            {
                var stat = interiorwalls.Get();
                if (stat)
                {
                    b121igo = LoadObjFile(b121go, "Willow/B121/1716045-BH-AR-INTERIOR_R20", "interior", ska: bshellska);
                    loadedThisTime = true;
                }
                else
                {
                    DestroyOneGo(ref b121igo);
                }
                _b121_interiorwalls = stat;
            }
            if (hvac.Get() != _b121_hvac)
            {
                var stat = hvac.Get();
                if (stat)
                {
                    b121hgo = LoadObjFile(b121go, "Willow/B121/1716045-BH-HVAC-B121_2020", "hvac", xrot: bang, zoff:bzoff, xoff:bxoff);
                    loadedThisTime = true;
                }
                else
                {
                    DestroyOneGo(ref b121hgo);
                }    
                _b121_hvac = stat;
            }
            if (lighting.Get() != _b121_lighting)
            {
                var stat = lighting.Get();
                if (stat)
                {
                    b121lgo = LoadObjFile(b121go, "Willow/B121/1716045-BH-LIGHTING-B121_2020", "lighting", xrot:bang, zoff: bzoff, xoff: bxoff);
                    loadedThisTime = true;
                }
                else
                {
                    DestroyOneGo(ref b121lgo);
                }
                _b121_lighting = stat;
            }
            if (plumbing.Get() != _b121_plumbing)
            {
                var stat = plumbing.Get();
                if (stat)
                {
                    b121pgo = LoadObjFile(b121go, "Willow/B121/1716045-BH-PLUMBING-B121_2020", "plumbing", xrot: bang, zoff: bzoff, xoff: bxoff);
                    loadedThisTime = true;
                }
                else
                {
                    DestroyOneGo(ref b121pgo);
                }
                _b121_plumbing = stat;
            }
            //Debug.Log($"loadedThisTime:{loadedThisTime}");
            if (loadedThisTime || b121_materialMode.Get() != lastMaterialMode)
            {
                
                ActuateMaterialMode();
            }
        }
    }
 
    public void WriteOutPartsAndMaterials()
    {
        if (this.b121sgo == null)
        {
            this.b121sgo = GameObject.Find("B19-Willow");
        }
        if (this.b121sgo == null)
        {
            Debug.LogWarning("Cound not find B19-Willow");
            return;
        }
        var lst = GraphAlgos.GraphUtil.HierarchyDescToText(this.b121sgo, "");
        var fname = "B19materials.txt";
        GraphAlgos.GraphUtil.writeListToFile(lst, fname);
        Debug.Log("Wrote " + lst.Count + " lines to " + fname);
    }

    public GameObject GetPart(GameObject root,string partname,bool canfail)
    {
        var parslh = partname.Split('/');
        var curgo = root;
        for(var i=0; i<parslh.Length; i++)
        {
            var part = parslh[i];
            if (i == 0) continue; // skip over root name
            var tform = curgo.transform.Find(part);
            if (tform == null)
            {
                if (!canfail)
                {
                    Debug.LogWarning("GetPart failed to find " + partname + "-  failed name part:" + part);
                }
                return null;
            }
            curgo = tform.gameObject;
        }
        return curgo;
    }

    public bool IsMonitor(string partname)
    {
        if (partname.Contains("Monitor_MS_Wall"))
        {
            return true;
        }
        return false;
    }

    public void AssignMonitorMat(GameObject pogo, string partname, string partfiltername)
    {
        var rend = pogo.GetComponent<Renderer>();
        var mats = new Material[rend.materials.Length];
        for (var j = 0; j < rend.materials.Length; j++)
        {
            mats[j] = GetMonitorMat(partname);
        }
        rend.materials = mats;
    }
    List<string> monitorMatNames = new List<string>()
    {
        "MavericWave",
        "Microsoft",
        "Caustic",
        "campsim",
        "EclipseSpectrum",
        "WinterScene1"
    };
    List<(string name,Material mat)> monitorMaterials = null;
    int matcount = 0;
    public void InitMonitorMaterials()
    {
        matcount = 0;
        monitorMaterials = new List<(string name, Material mat)>();
        foreach( var matname in monitorMatNames)
        {
            var fullmatname = $"Materials/{matname}";
            var newmat = Resources.Load<Material>(fullmatname);
            if (newmat!=null)
            {
                monitorMaterials.Add((fullmatname,newmat));
            }
            else
            {
                Debug.LogError($"Could not load material{fullmatname}");
            }
        }
    }
    public Material GetMonitorMat(string partname)
    {
        int mlen = monitorMaterials.Count;
        var rv = monitorMaterials[matcount % mlen];
        matcount++;
        //Debug.Log($"Got {rv.name} for {partname} matcount:{matcount}");
        return rv.mat;
    }

    public void AssignPartMat(GameObject rootgo,string partname,string partfiltername,string matname)
    {
        if (matname=="")
        {
            return; // do nothing - raw mode
        }
        //Debug.Log($"AssignPartMat rootgo:{rootgo.name} partname:{partname} matname:{matname}");
        var pogo = GetPart(rootgo, partname,canfail:true);
        if (pogo!=null)
        {
            ChangeMaterial(pogo, partfiltername, matname);
        }
    }
    void ChangeMaterial(GameObject pogo,string partfiltername,string matname)
    {
        var children = pogo.GetComponentsInChildren<Renderer>();
        //Debug.Log($"B121Willow.Change Material -Changing {pogo.name} children({children.Length}) to material:{newMat.name} - filter:{partfiltername}");
        var last = partfiltername.Length-1;
        if (partfiltername[last]=='*')
        {
            partfiltername = partfiltername.Remove(last);
        }
        var dodynmat = matname == "MonitorMat";
        Material newMat=null;
        if (!dodynmat)
        {
            var fullmatname = "Materials/" + matname;
            newMat = Resources.Load<Material>(fullmatname);
            if (!newMat)
            {
                Debug.LogWarning("Material " + fullmatname + " not found in Resources");
                return;
            }
        }
        //renderer.material = mat;
        var nhits = 0;
        foreach (var rend in children)
        {
            if (rend.name.StartsWith(partfiltername))
            {
                //if (rend.materials.Length>1)
                //{
                //    // Debug.Log("it is so"); // this never happens, but somehow renderers could have multiple materials
                //}
                var mats = new Material[rend.materials.Length];
                if (dodynmat)
                {
                    newMat = GetMonitorMat(rend.name);
                }
                for (var j = 0; j < rend.materials.Length; j++)
                {
                    mats[j] = newMat;
                }
                rend.materials = mats;
                nhits++;
            }
        }
        //Debug.Log($"Changing {pogo.name} children({children.Length}) to material:{newMat.name} - filter:{partfiltername} hits:{nhits}");
    }

    List<string> B121_parts = new List<string>
    {
        "b121/shell,*,_Wall_GenericMat",
        "b121/shell,Arch_Mullion*,_AluminiumMat",
        "b121/shell,Rectangular_Mullion*,_AluminiumMat",
        "b121/shell,System_Panel_Glazed,PC_Monitor_ColorMat",
        //"b121/shell,System_Panel_Glazed,DarkGlass",
        "b121/shell,Floor_Slab,FloorMaterial",
        "b121/interior,*,_Wall_GenericMat",
        "b121/interior,Monitor_MS_Wall_Mounted*,MonitorMat",
        "b121/hvac,*,_AluminiumMat",
        "b121/lighting,*,CopperMat",
        "b121/plumbing,*,_Metal_Stainless_Steel_-_PolishedMat",
    };

    Dictionary<string, string> bldmatmap = new Dictionary<string, string>
    {
        {"SolidMat","WallWhite"},
        {"Exhaust_Air_DuctMat","Aluminium"},
        {"Supply_Air_DuctMat","Aluminium"},
        {"Return_Air_DuctMat","Aluminium"},
        {"_Door_FrameMat","Plywood"},
        {"_Finish_Facade_Feature_WallMat","FacadeWall"},
        {"_Glazing_Glass_-_ClearMat","DustyGlass"},
        {"_Glazing_Glass","DustyGlass"},
        {"_Metal_Powdercoated_WhiteMat","Aluminium"},
        {"_Metal_Stainless_Steel_-_PolishedMat","Steel"},
        {"_Wall_GenericMat","WallMat"},
        {"_Fabric_Linen_PorcelainMat","WallMat"},
        {"","WallMat"},
        {"_Metal_AluminumMat","Aluminium"},
        {"_AluminiumMat","Aluminium"},
        {"Composite_PartMat","WallMat"},
        {"Computer_BasicMat","PlasticHololens"},
        {"Computer_Basic_2Mat","PlasticHololens"},
        {"Computer_Basic_3Mat","PlasticHololens"},
        {"Computer_GlassMat","ComputerGlass"},
        {"Computer_Light_(ON)Mat","BlueLight"},
        {"Computer_MetalMat","Aluminium"},
        {"Computer_Metal_2Mat","Aluminium"},
        {"PC_Monitor_ColorMat","ComputerGlass"},
        {"PC_Monitor_GlassMat","ComputerGlass"},
        {"MonitorMat","MonitorMat" },
        {"Generic_-_Plastic_-_BlackMat","PlasticHololens"},
        {"Generic_-_Plastic_-_GreyMat","PlasticHololens"},
        {"IKE080018_2Mat","Aluminium"},
        {"IKE080018_3Mat","Aluminium"},
        {"IKE160124_1Mat","Aluminium"},
        {"IKE160124_2Mat","Aluminium"},
        {"IKE160124_3Mat","Aluminium"},
        {"IKE160124_4Mat","Aluminium"},
        {"IKE160130_1Mat","Aluminium"},
        {"IKE160130_2Mat","Aluminium"},
        {"IKE160130_3Mat","Aluminium"},
        {"IKE160130_4Mat","Aluminium"},
        {"Metal-Chrome-CaromaMat","Steel"},
        {"Porcelain-White-CaromaMat","WallMat"},
        {"CopperMat","Copper"},
        {"Gas_PipeMat","Copper"},
        {"LineMat","WallMat"},
        {"FloorMaterial","FloorMaterial"},
    };


    public void ActuateMaterialMode(bool writepartlisttofile=true)
    {
        lastMaterialMode = b121_materialMode.Get();
        InitMonitorMaterials();
        var doit = true;
        if (doit)
        {
            foreach (var pname in B121_parts)
            {
                var parcom = pname.Split(',');
                var partname = parcom[0];
                var partfiltername = parcom[1];
                var partmat = parcom[2];
                var defmatname = "ComputerGlass";
                var matname = defmatname;
                switch (b121_materialMode.Get())
                {
                    case b121_MaterialMode.glass:
                        matname = "ComputerGlass";
                        break;
                    case b121_MaterialMode.materialed:
                        {
                            if (!bldmatmap.ContainsKey(partmat))
                            {
                                Debug.LogWarning($"Missing material:{partmat}");
                            }
                            else
                            {
                                matname = bldmatmap[partmat];
                            }
                            break;
                        }
                    case b121_MaterialMode.glasswalls:
                        {
                            var pnl = pname.ToLower();
                            if (pnl.Contains("interior") || pnl.Contains("door"))
                            {
                                matname = "ComputerGlass";
                            }
                            else
                            {
                                matname = bldmatmap[partmat];
                            }
                            break;
                        }
                    case b121_MaterialMode.glassfloors:
                        {
                            var pnl = pname.ToLower();
                            if (pnl.Contains("interior") || pnl.Contains("floor") || pnl.Contains("door"))
                            {
                                matname = "ComputerGlass";
                            }
                            else
                            {
                                matname = bldmatmap[partmat];
                            }
                            break;
                        }
                    case b121_MaterialMode.raw:
                        {
                            //matname = parcom[1];
                            matname = "";
                            break;
                        }
                }
                if (matname != "")
                {
                    AssignPartMat(this.b121go, partname, partfiltername, matname);
                }
            }
        }

        if (writepartlisttofile)
        {
            var lst = GraphAlgos.GraphUtil.HierarchyDescToText(this.b121go, "");
            var fname = "B121materials.txt";
            GraphAlgos.GraphUtil.writeListToFile(lst, fname);
            Debug.Log($"Wrote {lst.Count} lines to {fname}");
            var clst = ClassifyList(lst);
            var cfname = "B121materials_classified.txt";
            GraphAlgos.GraphUtil.writeListToFile(clst, cfname);
            Debug.Log($"Wrote {clst.Count} classified lines to {cfname}");
        }
    }

    public List<string> ClassifyList(List<string> ilst)
    {
        var nskipped = 0;
        var ldict = new Dictionary<string, int>();
        foreach( var line in ilst)
        {
            var sar = line.Split('/');
            if (sar.Length < 3)
            {
                nskipped++;
                continue;
            }
            var mline = sar[2];
            int i = 0;
            var ln = mline.Length;
            while (i < ln && !char.IsDigit(mline[i])) i++;
            var newmline = mline;
            if (i < mline.Length)
            {
                newmline = mline.Remove(i);
            }
            newmline = $"{sar[0]}/{sar[1]}/{newmline}";
            if (!ldict.ContainsKey(newmline))
            {
                ldict[newmline] = 0;
            }
            ldict[newmline]++;
        }
        var ccnt = 0;
        var rv = new List<string>();
        foreach(var line in ldict.Keys)
        {
            var nl = $"{line},{ldict[line]}";
            ccnt += ldict[line];
            rv.Add(nl);
        }
        var diff = ilst.Count - nskipped - ccnt;
        Debug.Log($"Classify orig count:{ilst.Count}  skipped:{nskipped}  sum classiffied:{ccnt} diff:{diff}");
        return rv;
    }    
    public bool ActuateChange()
    {
        var rv = ChangeHappened();
        if (rv)
        {
            MakeItSo();
        }
        return rv;
    }

    int updcount = 0;

    float timeinterval = 1e6f;
    float lasttimecheck = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lasttimecheck > timeinterval)
        {
            if (ChangeHappened())
            {
                Debug.Log($"ChangeHappened to B121 upd:{updcount} time:{Time.time:f2} - making it so");
                MakeItSo();
            }
            else
            {
                Debug.Log($"No Change to B121 upd:{updcount} time:{Time.time:f2}");
            }
            lasttimecheck = Time.time;
        }
        updcount++;
    }
}
