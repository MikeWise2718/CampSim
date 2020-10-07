using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using GraphAlgos;
using CampusSimulator;
using Microsoft.Win32;// for registry
using UnityEngine.UIElements;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.CodeDom;

public class AboutPanel : MonoBehaviour
{
    public SceneMan sman;
    UiMan uiman;

    Text aboutTabText;
    Canvas aboutTextCanvas;

    UnityEngine.UI.Button closeButton;
    UnityEngine.UI.Button infoCopyClipboardButton;
    UnityEngine.UI.Button settingsCopyClipboardButton;
    UnityEngine.UI.Button deleteSettingsButton;
    UnityEngine.UI.Button deleteCachedMapsButton;
    UnityEngine.UI.Button deleteScenarioKeysButton;
    UnityEngine.UI.Text statusMessageText;
    UnityEngine.UI.Text currentScenarioText;
    UnityEngine.UI.Toggle enableDangerToggle;

    System.Diagnostics.PerformanceCounter cpuCounter;
    System.Diagnostics.PerformanceCounter ramCounter;
    public float myCPU;
    public float myRAM;



    void LinkObjectsAndComponents()
    {
        uiman = sman.uiman;
        aboutTextCanvas = transform.Find("AboutTextCanvas").GetComponent<Canvas>();
        closeButton = transform.Find("CloseButton").gameObject.GetComponent<UnityEngine.UI.Button>();
        infoCopyClipboardButton = transform.Find("InfoCopyClipboardButton").gameObject.GetComponent<UnityEngine.UI.Button>();
        settingsCopyClipboardButton = transform.Find("SettingsCopyClipboardButton").gameObject.GetComponent<UnityEngine.UI.Button>();
        deleteSettingsButton = transform.Find("DeleteSettingsButton").gameObject.GetComponent<UnityEngine.UI.Button>();
        deleteCachedMapsButton = transform.Find("DeleteCachedMapsButton").gameObject.GetComponent<UnityEngine.UI.Button>();
        deleteScenarioKeysButton = transform.Find("DeleteScenarioKeysButton").gameObject.GetComponent<UnityEngine.UI.Button>();
        statusMessageText = transform.Find("StatusMessageText").gameObject.GetComponent<UnityEngine.UI.Text>();
        currentScenarioText = transform.Find("CurrentScenarioText").gameObject.GetComponent<UnityEngine.UI.Text>();
        enableDangerToggle = transform.Find("EnableDangerToggle").gameObject.GetComponent<UnityEngine.UI.Toggle>();

        closeButton.onClick.AddListener(delegate { uiman.ClosePanel(); });
        infoCopyClipboardButton.onClick.AddListener(delegate { ButtonClick(infoCopyClipboardButton.name); });
        settingsCopyClipboardButton.onClick.AddListener(delegate { ButtonClick(settingsCopyClipboardButton.name); });
        deleteSettingsButton.onClick.AddListener(delegate { ButtonClick(deleteSettingsButton.name); });
        deleteCachedMapsButton.onClick.AddListener(delegate { ButtonClick(deleteCachedMapsButton.name); });
        deleteScenarioKeysButton.onClick.AddListener(delegate { ButtonClick(deleteScenarioKeysButton.name); });
    }


    public Dictionary<string, (object,string,string)> GetRegistrySubKeys(string keyname)
    {
        var values = new Dictionary<string, (object, string, string)>();
        try
        {
            using (var rootKey = Registry.CurrentUser.OpenSubKey(keyname))
            {
                if (rootKey != null)
                {
                    string[] valueNames = rootKey.GetValueNames();
                    foreach (string currSubKey in valueNames)
                    {
                        var valuekind = rootKey.GetValueKind(currSubKey);
                        object value = rootKey.GetValue(currSubKey);
                        var valuestr = value.ToString();
                        values.Add(currSubKey, (value,valuekind.ToString(),valuestr));
                    }
                    rootKey.Close();
                }
                else
                {
                    Debug.LogError($"In GraphUtil Registry.CurrentUser.OpenSubKey(\"{keyname}\") returned null");
                }
            }
        }
        catch (Exception ex)
        {
            sman.LggError($"Error reading registry key:{keyname} - ex.msg:{ex.Message}");
        }
        return values;
    }

    public (bool,string) DeleteKeysStartingWithFilterString(string keyname,string startStringFilter,bool actuallyDoDelete=false)
    {
        var rmsg = "";
        var emsg = "";
        var ndel = 0;
        var error = false;
        var values = new Dictionary<string, (object, string, string)>();
        try
        {
            using (var rootKey = Registry.CurrentUser.OpenSubKey(keyname,writable:true))
            {
                if (rootKey != null)
                {
                    string[] valueNames = rootKey.GetValueNames();
                    foreach (string curValue in valueNames)
                    {
                        if (curValue.StartsWith(startStringFilter))
                        {
                            if (actuallyDoDelete)
                            {
                                rootKey.DeleteValue(curValue);
                                ndel++;
                                sman.LggWarning($"{ndel} Deleting value {curValue}");
                            }
                            else
                            {
                                sman.LggWarning($"Pretending to delete value {curValue}");
                            }
                        }
                    }
                    rootKey.Close();
                }
                else
                {
                    emsg = $"In GraphUtil Registry.CurrentUser.OpenSubKey(\"{keyname}\") returned null";
                    error = true;
                }
            }
        }
        catch (Exception ex)
        {
            emsg = $"Error reading registry key:{keyname} - ex.msg:{ex.Message}";
            sman.LggError(emsg);
            error = true;
        }
        if (error)
        {
            rmsg = emsg;
        }
        else if (actuallyDoDelete)
        {
            rmsg = $"Deleted {ndel} values for scenariop {startStringFilter}";
        }
        else
        {
            rmsg = $"Pretended to deleted {ndel} values for scenariop {startStringFilter}";
        }
        return (!error,rmsg);
    }

    public void Init0()
    {
        LinkObjectsAndComponents();
        sman.uiman.ttman.WireUpToolTip(closeButton.gameObject, "aboutpanel-closepanel", "Close Panel");
        sman.uiman.ttman.WireUpToolTip(infoCopyClipboardButton.gameObject, "aboutpanel-copyclipboard", "Copy text to clipboard");
        sman.uiman.ttman.WireUpToolTip(deleteSettingsButton.gameObject, "aboutpanel-deletesettings", "Delete all saved settings for this app\nDangerous - can lose work!!",isDangerous:true);
        sman.uiman.ttman.WireUpToolTip(deleteCachedMapsButton.gameObject, "aboutpanel-deletecachedmaps", "Delete all saved maps and elevations for this app\nDangerous - it takes time to load these!!", isDangerous: true);
    }

    public void SetScene(CampusSimulator.SceneSelE curscene)
    {
    }

    public float getCurrentCpuUsage()
    {
        var rv = 0f;
        if (cpuCounter!=null) rv = cpuCounter.NextValue();
        return rv;
    }

    public float getAvailableRAM()
    {
        var rv = 0f;
        if (ramCounter != null) rv = ramCounter.NextValue();
        return rv;
    }


    /// <summary>
    /// Find out about which monitors are made available by the system.
    /// </summary>
  

    void Init()
    {
        Debug.Log("Initing AboutPanel");
        try
        {
            cpuCounter = new System.Diagnostics.PerformanceCounter();

            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            ramCounter = new System.Diagnostics.PerformanceCounter("Memory", "Available MBytes");
        }
        catch(Exception ex)
        {
            sman.LggError($"Could Not init perf counters");
            sman.LggError(ex.ToString());
            cpuCounter = null;
            ramCounter = null;
        }

        currentScenarioText.text = $"{sman.curscene}";
        enableDangerToggle.isOn = false;
        SetStatusMessage("", error: false);


        Debug.Log("Initing AboutPanel done");
    }

    public void SetStatusMessage(string message, bool error)
    {
        statusMessageText.text = message;
        if (error)
        {
            statusMessageText.color = Color.red;
        }
        else
        {
            statusMessageText.color = Color.black;
        }
    }


    public bool RunningInEditor()
    {
#if UNITY_EDITOR
        bool iseditor = true;
#else
        bool iseditor = false;
#endif
        return iseditor;
    }

    public (bool,string,List<string>) GetRegistryInfoAsStringList()
    {
        var ok = true;
        var rmsg = "";
        var rv = new List<string>();
        var nkeys = 0;
        var iseditor = RunningInEditor();
        var fullregkey = GraphAlgos.GraphUtil.GetUserPrefRegKey(entirekey: true, editor: iseditor);
        var regkey = GraphAlgos.GraphUtil.GetUserPrefRegKey(entirekey:false,editor:iseditor);
        rv.Add(fullregkey);
        var nowtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff UTC zz");
        var sysinfo = $"system:{sman.hostname} time: {nowtime}";
        rv.Add(sysinfo);
        rv.Add("Application Registry Dump:");
        var dict = GetRegistrySubKeys(regkey);
        var s3 = "";
        int dword;
        foreach (var k in dict.Keys)
        {
            nkeys++;
            object o1;
            var s2 = "";
            var s = "";
            try
            {
                (o1, s2, _) = dict[k];
                switch (s2)
                {
                    case "DWord":
                        {
                            dword = (int)o1;
                            s3 = dword.ToString();
                            break;
                        }
                    default:
                        {
                            var bar = o1 as byte[];
                            var s3b = "";
                            var s3s = "";
                            if (bar != null)
                            {
                                int ngood = 0;
                                foreach (var b in bar)
                                {
                                    char c = '.';
                                    if (b >= 32)
                                    {
                                        c = (char)b;
                                        ngood++;
                                    }
                                    s3b += $"{b:x2} ";
                                    s3s += c;
                                }
                                var isProbablyString = ngood >= bar.Length - 1;
                                if (isProbablyString)
                                {
                                    s3 = s3s;
                                    s2 = "NullTerminatedString";
                                }
                                else
                                {
                                    s3 = s3b;
                                    s2 = "ByteArray";
                                }
                            }
                            break;
                        }
                }
                s = $"{nkeys}:{k}:{s2}:{s3}";
            }
            catch (Exception ex)
            {
                ok = false;;
                rmsg = ex.Message;
                s = $"{nkeys}:{k}:{s2}:{ex.Message}";
            }
            rv.Add(s);
        }
        var msg = $"Dumped {nkeys} registry values";
        rv.Add(msg);
        if (ok)
        {
            rmsg = $"Retrived {nkeys} registry values";
        }
        return (ok,rmsg,rv);
    }
    (bool,string) DeleteScenarioKeys(SceneSelE scnene)
    {
        var startSTringFilter = scnene.ToString();
        var iseditor = RunningInEditor();
        var regkey = GraphAlgos.GraphUtil.GetUserPrefRegKey(entirekey: false, editor: iseditor);

        var (ok,rv) = DeleteKeysStartingWithFilterString(regkey, startSTringFilter,actuallyDoDelete:true);
        return (ok,rv);
    }

    void CopyRegToClipboard()
    {
        var (ok,rmsg,lsl) = GetRegistryInfoAsStringList();
        Aiskwk.Map.qut.CopyTextToClipboard(lsl);
        SetStatusMessage(rmsg, !ok);
    }

    void ButtonClick(string buttonname)
    {
        Debug.Log($"{buttonname} clicked:" + Time.time);
        var dangerEnabled = enableDangerToggle.isOn;
        switch (buttonname)
        {
            case "DeleteSettingsButton":
                {
                    if (dangerEnabled)
                    {
                        PlayerPrefs.DeleteAll();
                        var msg = $"PlayerPref Settings Deleted";
                        SetStatusMessage(msg, error: false);
                    }
                    else
                    {
                        var msg = $"Danger must be enabled to delete all settings";
                        SetStatusMessage(msg, error: true);
                    }
                    break;
                }
            case "DeleteCachedMapsButton":
                {
                    if (dangerEnabled)
                    {
                        sman.mpman.DeleteCachedMaps();
                        var msg = $"Cached Maps Deleted";
                        SetStatusMessage(msg, error: false);
                    }
                    else
                    {
                        var msg = $"Danger must be enabled to delete cached maps";
                        SetStatusMessage(msg, error: true);
                    }
                    break;
                }
            case "DeleteScenarioKeysButton":
                {
                    if (dangerEnabled)
                    {
                        var (ok,msg) = DeleteScenarioKeys(sman.curscene);
                        SetStatusMessage(msg,error:!ok);
                    }
                    else
                    {
                        var msg = $"Danger must be enabled to delete scenario keys for {sman.curscene}";
                        SetStatusMessage(msg, error:true);
                    }
                    break;
                }
            case "CloseButton":
                {
                    var tbpcomp = FindObjectOfType<TopButtonPanel>();
                    tbpcomp.CloseButton();
                    break;
                }
            case "InfoCopyClipboardButton":
                {
                    Debug.Log($"InfoCopyClipboard");
                    Aiskwk.Map.qut.CopyTextToClipboard(aboutTabText.text);
                    var msg = $"Copyied sysinfo to clipboard (length:{aboutTabText.text.Length})";
                    SetStatusMessage(msg, error: false);
                    break;
                }
            case "SettingsCopyClipboardButton":
                {
                    CopyRegToClipboard();
                    break;
                }
        }
    }

    public Tuple<float, float> GetMemUsed()
    {
        var gcmem = (float)(GC.GetTotalMemory(true) / 1e6);
        var proc = System.Diagnostics.Process.GetCurrentProcess();
        var totprivmem = (float)(proc.PrivateMemorySize64 / 1e6);
        proc.Dispose();
        return new Tuple<float, float>(gcmem, totprivmem);
    }


    public Tuple<string, string> GetRuntimeVersion()
    {
        try
        {
            var frmver = Assembly
            .GetEntryAssembly()?
            .GetCustomAttribute<System.Runtime.Versioning.TargetFrameworkAttribute>()?
            .FrameworkName;

            var rv = new Tuple<string, string>(
                System.Runtime.InteropServices.RuntimeInformation.OSDescription,
                frmver);
            return rv;
        }
        catch (Exception)
        {
            return new Tuple<string, string>("??", "??");
        }
    }
    public Tuple<string, string, string> GetSecurityPrincipalNames()
    {
        var winname = "??";
        var username = "??";
        var userdomainname = "??";
        try
        {
            username = Environment.UserName;
            userdomainname = Environment.UserDomainName;
            winname = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            return new Tuple<string, string, string>(winname, username, userdomainname);
        }
        catch (Exception)
        {
            return new Tuple<string, string, string>(winname, username, userdomainname);
        }
    }

    public string DevicePciIdString()
    {
        var id = SystemInfo.graphicsDeviceVendorID;
        var sid = id + " (0x" + id.ToString("x") + ")";
        // Values from PCI ID Regstry at https://pci-ids.ucw.cz/read/PC/
        switch (id)
        {
            default: break;
            case 0x8086: sid += " Intel"; break;
            case 0x10de: sid += " NVIDIA Corporation"; break;
            case 0x1002: sid += " AMD"; break;
        }
        return sid;
    }


    public string GetAboutText()
    {
        var sysver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        var utc = System.DateTime.UtcNow;
        string msg = "System Info";
        try
        {
            msg += "\n\nTime Now: " + utc.ToString("yyyy-MM-dd HH:mm:ss UTC");
            msg += "\n\nVersion: "+GraphUtil.GetVersionString();

            //            aboutText.text += "\n\nDevice Name:" + Util.GetDeviceName();
            msg += "\nOS Family:" + SystemInfo.operatingSystemFamily;
            msg += "\nOS:" + SystemInfo.operatingSystem;
            msg += "\n.NET Version: " + System.Environment.Version.ToString();
            var (osdesc, frmver) = GetRuntimeVersion();
            msg += "\nOS description: " + osdesc + " framework-ver:" + frmver;

            msg += "\n\nProcessor count:" + SystemInfo.processorCount +
                                 " type:" + SystemInfo.processorType +
                                 " freq:" + SystemInfo.processorFrequency;
            msg += "\nDevice name:" + SystemInfo.deviceName +
                           " type:" + SystemInfo.deviceType +
                          " model:" + SystemInfo.deviceModel;
            msg += "\nPerfcount - Mem Used MB:" + myRAM + "  CPU Used:" + myCPU;
            var (gcmem, privmem) = GetMemUsed();
            msg += "\nGC MB used:" + gcmem.ToString("f1") + "  Private MB Used:" + privmem.ToString("f1");

            msg += "\n\nGPU name:" + SystemInfo.graphicsDeviceName;
            msg += "\nGPU type:" + SystemInfo.graphicsDeviceType;
            msg += "\nGPU vendorID:" + DevicePciIdString();
            msg += "\nGPU version:" + SystemInfo.graphicsDeviceVersion;
            msg += "\nGPU mem:" + SystemInfo.graphicsMemorySize +
                        " shaderlev:" + SystemInfo.graphicsShaderLevel;
            msg += "\nBattery status:" + SystemInfo.batteryStatus +
                             " level:" + SystemInfo.batteryLevel;
            msg += "\nGyroscope available:" + SystemInfo.supportsGyroscope;
            if (SystemInfo.supportsGyroscope)
            {
                msg += "  enabled:" + Input.gyro.enabled;
            }

            msg += $"\n\nDisplay information";
            msg += $"\nScreen.width:{Screen.width} height:{Screen.height} dpi:{Screen.dpi} brightness:{Screen.brightness}";
            var fsmode = Screen.fullScreenMode;
            msg += $"\nScreen.fullScreen:{Screen.fullScreen} Screen.fullSScreenMode:{fsmode}";
            var fsmodes = Enum.GetValues(typeof(FullScreenMode));
            var fsmodestr = "";
            foreach (var fs in fsmodes)
            {
                fsmodestr += " " + fs;
            }

            msg += $"\nThere are {fsmodes.Length} possible FullscreenModes:   {fsmodestr}";

            msg += $"\n\nDisplays:{Display.displays.Length}";
            for (int i = 0; i < Display.displays.Length; i++)
            {
                var dd = Display.displays[i];
                msg += $" \n  {i+1}  native: {dd.systemWidth},{dd.systemHeight}";
                msg += $"   render: {dd.renderingWidth},{dd.renderingHeight}";
                msg += $"   active: {dd.active}";
            }
            var usm = PlayerPrefs.GetInt("UnitySelectMonitor");
            msg += $"\nPlayerPrefs - Current monitor:{usm+1} (zero-based UnitySelectMonitor:{usm})";

#if UNITY_EDITOR
            var svc = UnityEditor.SceneView.lastActiveSceneView.camera;
            if (svc != null)
            {
                var t = svc.transform;
                msg += "\n\nScene Cam Pos:" + t.position.ToString("F3");
                msg += " Rot:" + t.rotation.eulerAngles.ToString("F1");
                msg += " FOV:" + svc.fieldOfView.ToString("F1");
            }
            else
            {
                msg += "\nScene Cam lastActiveSceneView is null";
            }
#endif
            msg += $"\n\nUnity Version: {Application.unityVersion}";
            msg += $"\nUnity Platform:{Application.platform}";

            msg += $"\n\nBuild Version :{GraphUtil.GetVersionString()}";
            msg += $"\nAssembly Date:{GraphUtil.GetBuildDate()}";

            msg += $"\n\nSystemInfo.maxTextureSize:{SystemInfo.maxTextureSize}";

            var (winname, username, userdomname) = GetSecurityPrincipalNames();
            msg += $"\n\nWindows Identity:{winname}";
            msg += $"\nEnvironment.UserName:{username} DomainName:{userdomname}";


        }
        catch (Exception ex)
        {
            msg += "\n" + ex.Message;
            sman.LggError("Error filling about box text");
            sman.LggError(ex.ToString());
        }
        return msg;
    }


    public List<string> GetAboutTextAsList()
    {
        var msg = GetAboutText();
        var rv = new List<string>(msg.Split('\n'));
        return rv;
    }
    public void FillAboutPanel()
    {
        if (aboutTabText == null)
        {
            Init();
        }

        var sysver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        var utc = System.DateTime.UtcNow;
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        var go = GameObject.Find("AboutTabText");
        aboutTabText = go.GetComponent<Text>();
        aboutTabText.font = arial;
        aboutTabText.fontSize = 24;
        aboutTabText.alignment = TextAnchor.UpperLeft;
        aboutTabText.verticalOverflow = VerticalWrapMode.Truncate;
        //var sv = aboutTextCanvas.GetComponent<ScrollView>();
        //var label = new UnityEngine.UIElements.TextField();
        //label.value = msg;
        //sv.contentContainer.Add(label);
        aboutTabText.text = GetAboutText();
        //Debug.Log("msg:" + msg);
    }


    // Update is called once per frame
    void Update()
    {
        myCPU = getCurrentCpuUsage();
        myRAM = getAvailableRAM();
    }
}
