using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using GraphAlgos;
using CampusSimulator;
using UnityEngine.UIElements;

public class AboutPanel : MonoBehaviour
{
    public SceneMan sman;
    UiMan uiman;

    Text aboutTabText;
    Canvas aboutTextCanvas;

    UnityEngine.UI.Button closeButton;
    UnityEngine.UI.Button copyClipboardButton;
    UnityEngine.UI.Button deleteSettingsButton;
    UnityEngine.UI.Button deleteCachedMapsButton;

    System.Diagnostics.PerformanceCounter cpuCounter;
    System.Diagnostics.PerformanceCounter ramCounter;
    public float myCPU;
    public float myRAM;



    void LinkObjectsAndComponents()
    {
        uiman = sman.uiman;
        aboutTextCanvas = transform.Find("AboutTextCanvas").GetComponent<Canvas>();
        closeButton = transform.Find("CloseButton").gameObject.GetComponent<UnityEngine.UI.Button>();
        copyClipboardButton = transform.Find("CopyClipboardButton").gameObject.GetComponent<UnityEngine.UI.Button>();
        deleteSettingsButton = transform.Find("DeleteSettingsButton").gameObject.GetComponent<UnityEngine.UI.Button>();
        deleteCachedMapsButton = transform.Find("DeleteCachedMapsButton").gameObject.GetComponent<UnityEngine.UI.Button>();

        closeButton.onClick.AddListener(delegate { uiman.ClosePanel(); });
        copyClipboardButton.onClick.AddListener(delegate { ButtonClick(copyClipboardButton.name); });
        deleteSettingsButton.onClick.AddListener(delegate { ButtonClick(deleteSettingsButton.name); });
        deleteCachedMapsButton.onClick.AddListener(delegate { ButtonClick(deleteCachedMapsButton.name); });
    }

    public void Init0()
    {
        LinkObjectsAndComponents();
        sman.uiman.ttman.WireUpToolTip(closeButton.gameObject, "aboutpanel-closepanel", "Close Panel");
        sman.uiman.ttman.WireUpToolTip(copyClipboardButton.gameObject, "aboutpanel-copyclipboard", "Copy text to clipboard");
        sman.uiman.ttman.WireUpToolTip(deleteSettingsButton.gameObject, "aboutpanel-deletesettings", "Delete all saved settings for this app\nDangerous - can lose work!!",danger:true);
        sman.uiman.ttman.WireUpToolTip(deleteCachedMapsButton.gameObject, "aboutpanel-deletecachedmaps", "Delete all saved maps and elevations for this app\nDangerous - it takes time to load these!!", danger: true);
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
            Debug.LogError($"Could Not init perf counters");
            Debug.LogError(ex.ToString());
            cpuCounter = null;
            ramCounter = null;
        }

        Debug.Log("Initing AboutPanel done");
    }

    void ButtonClick(string buttonname)
    {
        Debug.Log($"{buttonname} clicked:" + Time.time);
        switch (buttonname)
        {
            case "DeleteSettingsButton":
                {
                    Debug.LogWarning("PlayerPref Settings Deleted");
                    PlayerPrefs.DeleteAll();
                    break;
                }
            case "DeleteCachedMapsButton":
                {
                    Debug.LogWarning("Deleteing Cached Maps");
                    sman.mpman.DeleteCachedMaps();
                    break;
                }
            case "CloseButton":
                {
                    var spcomp = FindObjectOfType<StatusPanel>();
                    spcomp.OptionsButton();
                    break;
                }
            case "CopyClipboardButton":
                {
                    Aiskwk.Map.qut.CopyTextToClipboard(aboutTabText.text);
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

            msg += $"\n\nDisplays:{Display.displays.Length}";
            for (int i = 0; i < Display.displays.Length; i++)
            {
                var dd = Display.displays[i];
                msg += $" \n  {i+1}  native: {dd.systemWidth},{dd.systemHeight}";
                msg += $"       rendering: {dd.renderingWidth},{dd.renderingHeight}";
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
            msg += $"\n\\nnWindows Identity:{winname}";
            msg += $"\nEnvironment.UserName:{username} DomainName:{userdomname}";


        }
        catch (Exception ex)
        {
            msg += "\n" + ex.Message;
            Debug.LogError("Error filling about box text");
            Debug.LogError(ex.ToString());
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
