using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using GraphAlgos;
using CampusSimulator;

public class AboutPanel : MonoBehaviour
{
    Text aboutText;

    Button closeButton;
    Button copyClipboardButton;
    Button deleteSettingsButton;
    bool buttonsInited = false;

    System.Diagnostics.PerformanceCounter cpuCounter;
    System.Diagnostics.PerformanceCounter ramCounter;
    public float myCPU;
    public float myRAM;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }


    void LinkObjectsAndComponents()
    {
        var go = gameObject;
        var name = go.name;
        aboutText = transform.Find("AboutText").GetComponent<Text>();
        closeButton = transform.Find("CloseButton").gameObject.GetComponent<Button>();
        copyClipboardButton = transform.Find("CopyClipboardButton").gameObject.GetComponent<Button>();
        deleteSettingsButton = transform.Find("DeleteSettingsButton").gameObject.GetComponent<Button>();
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
        cpuCounter = new System.Diagnostics.PerformanceCounter();

        cpuCounter.CategoryName = "Processor";
        cpuCounter.CounterName = "% Processor Time";
        cpuCounter.InstanceName = "_Total";

        ramCounter = new System.Diagnostics.PerformanceCounter("Memory", "Available MBytes");

        //FillAboutPanel();
        if (!buttonsInited)
        {
            closeButton.onClick.AddListener(delegate { ButtonClick(closeButton.name); });
            copyClipboardButton.onClick.AddListener(delegate { ButtonClick(copyClipboardButton.name); });
            deleteSettingsButton.onClick.AddListener(delegate { ButtonClick(deleteSettingsButton.name); });
            buttonsInited = true;
        }
        Debug.Log("Initing AboutPanel done");
    }

    void ButtonClick(string buttonname)
    {
        Debug.Log($"{buttonname} clicked:" + Time.time);
        switch (buttonname)
        {
            case "CloseButton":
                {
                    var spcomp = FindObjectOfType<StatusPanel>();
                    spcomp.OptionsButton();
                    break;
                }
            case "CopyClipboardButton":
                {
                    Aiskwk.Map.qut.CopyTextToClipboard(aboutText.text);
                    break;
                }
            case "DeleteSettingsButton":
                {
                    Debug.LogWarning("PlayerPref Settings Deleted");
                    PlayerPrefs.DeleteAll();
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

    public void FillAboutPanel()
    {
        if (aboutText == null)
        {
            LinkObjectsAndComponents();
            Init();
        }

        var sysver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        var utc = System.DateTime.UtcNow;
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        aboutText.font = arial;
        aboutText.fontSize = 24;
        aboutText.alignment = TextAnchor.UpperLeft;
        aboutText.verticalOverflow = VerticalWrapMode.Overflow;
        string msg = "System Info";
        try
        {
            msg += "\n\nTime Now: " + utc.ToString("yyyy-MM-dd HH:mm:ss UTC");

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

#if UNITY_EDITOR
            var svc = UnityEditor.SceneView.lastActiveSceneView.camera;
            if (svc != null)
            {
                var t = svc.transform;
                msg += "\nScene Cam Pos:" + t.position.ToString("F3");
                msg += " Rot:" + t.rotation.eulerAngles.ToString("F1");
                msg += " FOV:" + svc.fieldOfView.ToString("F1");
            }
            else
            {
                msg += "\nScene Cam lastActiveSceneView is null";
            }
#endif

            msg += "\n\nUnity Version: " + Application.unityVersion;
            msg += "\nUnity Platform:" + Application.platform;

            msg += "\n\nBuild Version :" + GraphUtil.GetVersionString();
            msg += "\nAssembly Date:" + GraphUtil.GetBuildDate();

            var (winname, username, userdomname) = GetSecurityPrincipalNames();
            msg += "\n\nWindows Identity:" + winname;
            msg += "\nEnvironment.UserName:" + username + " DomainName:" + userdomname;
        }
        catch (Exception ex)
        {
            msg += "\n" + ex.Message;
        }
        aboutText.text = msg;
        //Debug.Log("msg:" + msg);
    }


    // Update is called once per frame
    void Update()
    {
        myCPU = getCurrentCpuUsage();
        myRAM = getAvailableRAM();
    }
}
