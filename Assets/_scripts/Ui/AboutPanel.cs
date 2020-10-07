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

    public void DeleteKeysStartingWithFilterString(string keyname,string startStringFilter,bool actuallyDoDelete=false)
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
                        if (currSubKey.StartsWith(startStringFilter))
                        {
                            if (actuallyDoDelete)
                            {
                                rootKey.DeleteSubKey(currSubKey);
                                sman.LggWarning($"Deleting subkey {currSubKey}");
                            }
                            else
                            {
                                sman.LggWarning($"Pretending to delete subkey {currSubKey}");
                            }
                        }
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
    public abstract class WindowsMultiDisplayTools
    {
        #region Multi-Display Detection
        private delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData);

        [DllImport("user32.dll")]
        private static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, MonitorEnumDelegate lpfnEnum, IntPtr dwData);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct MonitorInfo
        {
            public uint Size;
            public RectNative Monitor;
            public RectNative WorkArea;
            public uint Flags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string DeviceName;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RectNative
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern bool GetMonitorInfo(IntPtr hmon, ref MonitorInfo monitorinfo);
        #endregion

        /// <summary>
        /// The struct that contains the display information
        /// </summary>
        public class DisplayInfo
        {
            public string Availability { get; set; }
            public int ScreenHeight { get; set; }
            public int ScreenWidth { get; set; }
            public Rect MonitorArea { get; set; }
            public int MonitorTop { get; set; }
            public int MonitorLeft { get; set; }
            public string DeviceName { get; set; }
            public string FriendlyName { get; set; }
            public string VendorsName { get; set; }
        }

        /// <summary>
        /// Returns the number of Displays using the Win32 functions.
        /// </summary>
        /// <returns>A collection of DisplayInfo with information about each monitor.</returns>
        public static List<DisplayInfo> QueryDisplays()
        {
            var Monitors = new List<DisplayInfo>();

            // Get the all Display Monitors.
            EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero,
                delegate (IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData)
                {
                    MonitorInfo monitor = new MonitorInfo();
                    monitor.Size = (uint)Marshal.SizeOf(monitor);
                    monitor.DeviceName = null;
                    bool Success = GetMonitorInfo(hMonitor, ref monitor);
                    if (Success)
                    {
                        DisplayInfo displayinfo = new DisplayInfo();
                        displayinfo.ScreenWidth = monitor.Monitor.Right - monitor.Monitor.Left;
                        displayinfo.ScreenHeight = monitor.Monitor.Bottom - monitor.Monitor.Top;
                        displayinfo.MonitorArea = new Rect(monitor.Monitor.Left, monitor.Monitor.Top, displayinfo.ScreenWidth, displayinfo.ScreenHeight);
                        displayinfo.MonitorTop = monitor.Monitor.Top;
                        displayinfo.MonitorLeft = monitor.Monitor.Left;
                        displayinfo.Availability = monitor.Flags.ToString();
                        displayinfo.DeviceName = monitor.DeviceName;
                        displayinfo.FriendlyName = QueryDisplaysFriendlyName(monitor.DeviceName);
                        displayinfo.VendorsName = QueryDisplaysVendorName(monitor.DeviceName);
                        Monitors.Add(displayinfo);
                    }
                    return true;
                }, IntPtr.Zero);
            return Monitors;
        }
        /// <summary>
        /// Returns the Friendly Name of a target Display using the Win32 functions.
        /// </summary>
        /// <returns>A string of with FriendlyName from DeviceName.</returns>
        private static string QueryDisplaysFriendlyName(string DeviceName)
        {
            string FriendlyName = null;

            // Get Friendly Name for the Device code goes here.
            FriendlyName = "Friendly Name";

            return FriendlyName;
        }
        /// <summary>
        /// Returns the Vendors Name of a target Display using the Win32 functions.
        /// </summary>
        /// <returns>A string of with VendorName from DeviceName.</returns>
        private static string QueryDisplaysVendorName(string DeviceName)
        {
            string VendorName = null;

            // Get Vendors Name for the Device code goes here.
            VendorName = "Vendor Name";


            return VendorName;
        }
    }


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

        Debug.Log("Initing AboutPanel done");
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

    public List<string> GetRegistryInfoAsStringList()
    {
        var rv = new List<string>();
        var iseditor = RunningInEditor();
        var fullregkey = GraphAlgos.GraphUtil.GetUserPrefRegKey(entirekey: true, editor: iseditor);
        var regkey = GraphAlgos.GraphUtil.GetUserPrefRegKey(entirekey:false,editor:iseditor);
        rv.Add(fullregkey);
        var dict = GetRegistrySubKeys(regkey);
        var s3 = "";
        int dword;
        foreach (var k in dict.Keys)
        {
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
                s = $"{k}:{s2}:{s3}";
            }
            catch (Exception ex)
            {
                s = $"{k}:{s2}:{ex.Message}";
            }
            rv.Add(s);
        }
        return rv;
    }
    void DeleteScenarioKeys(SceneSelE scnene)
    {
        var startSTringFilter = scnene.ToString();
        var iseditor = RunningInEditor();
        var regkey = GraphAlgos.GraphUtil.GetUserPrefRegKey(entirekey: false, editor: iseditor);

        DeleteKeysStartingWithFilterString(regkey, startSTringFilter,actuallyDoDelete:true);
    }

    void ButtonClick(string buttonname)
    {
        Debug.Log($"{buttonname} clicked:" + Time.time);
        switch (buttonname)
        {
            case "DeleteSettingsButton":
                {
#if UNITY_EDITOR
                    var msg = $"Delete ALL the settings for this Unity Application ?";
                    var ok = UnityEditor.EditorUtility.DisplayDialog("Deleting PlayerPref Settings", msg, "Ok to delete", "Cancel");
#else
                    var ok = true;
#endif
                    if (ok)
                    {
                        PlayerPrefs.DeleteAll();
                        sman.LggWarning($"PlayerPref Settings Deleted");
                    }
                    break;
                }
            case "DeleteCachedMapsButton":
                {
                    Debug.LogWarning($"Deleteing Cached Maps");
                    sman.mpman.DeleteCachedMaps();
                    break;
                }
            case "DeleteScenarioKeysButton":
                {
#if UNITY_EDITOR
                    var msg = $"Delete scenario keys for {sman.curscene} ?";
                    var ok = UnityEditor.EditorUtility.DisplayDialog("Deleting scenario keys", msg, "Ok to delete", "Cancel");
#else
                    var ok = true;
#endif
                    if (ok)
                    {
                        DeleteScenarioKeys(sman.curscene);
                        sman.LggWarning($"Deleteing scenario keys for {sman.curscene}");
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
                    break;
                }
            case "SettingsCopyClipboardButton":
                {
                    Debug.Log($"SettingsCopyClipboard");
                    var lsl = GetRegistryInfoAsStringList();
                    Debug.Log($"Registry log elements:{lsl.Count}");
                    Aiskwk.Map.qut.CopyTextToClipboard(lsl);
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
