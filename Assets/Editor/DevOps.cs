
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

#if UNITY_2018_1_OR_NEWER
using UnityEditor.Build.Reporting;
#endif

public class DevOps
{
    private static string outputFileName = @"CampusSim";
    private static bool developmentBuild = false;
    private static string locationPathName = @"Build\Linux64";
    private static string[] includedScenes = null;

    [MenuItem("Applied Innovation/Azure DevOps Tools/Perform Build")]
    public static void PerformBuild()
    {
        try
        {
            if (includedScenes == null || includedScenes.Length == 0)
            {
                EditorBuildSettingsScene[] editorConfiguredBuildScenes = EditorBuildSettings.scenes;
                includedScenes = new string[editorConfiguredBuildScenes.Length];

                for (int i = 0; i < editorConfiguredBuildScenes.Length; i++)
                {
                    includedScenes[i] = editorConfiguredBuildScenes[i].path;
                }
            }

#if UNITY_2018_1_OR_NEWER
            BuildReport buildReport = default(BuildReport);
#else
                    string buildReport = "ERROR";
#endif

            if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.StandaloneLinux64)
            {
                PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.Mono2x);
            }
            else
            {
                PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.IL2CPP);
            }


            buildReport = BuildPipeline.BuildPlayer(new BuildPlayerOptions
            {
                scenes = includedScenes,
                target = EditorUserBuildSettings.activeBuildTarget,
                locationPathName = Path.Combine(locationPathName, GetBuildTargetOutputFileNameAndExtension()),
                targetGroup = EditorUserBuildSettings.selectedBuildTargetGroup,
                options = developmentBuild ? BuildOptions.Development : BuildOptions.None
            });


#if UNITY_2018_1_OR_NEWER
            switch (buildReport.summary.result)
            {
                case BuildResult.Succeeded:
                    EditorApplication.Exit(0);
                    break;
                case BuildResult.Unknown:
                case BuildResult.Failed:
                case BuildResult.Cancelled:
                default:
                    EditorApplication.Exit(1);
                    break;
            }
#else
                    if (buildReport.StartsWith("Error"))
                    {
                        EditorApplication.Exit(1);
                    }
                    else
                    {
                        EditorApplication.Exit(0);
                    }
#endif
        }
        catch (Exception ex)
        {
            Debug.Log("BUILD FAILED: " + ex.Message);
            EditorApplication.Exit(1);
        }
    }

    private static string GetBuildTargetOutputFileNameAndExtension()
    {
        switch (EditorUserBuildSettings.activeBuildTarget)
        {
            case BuildTarget.StandaloneLinux64:
                return string.Format("{0}", outputFileName);
            case BuildTarget.Android:
                return string.Format("{0}.apk", outputFileName);
            case BuildTarget.StandaloneWindows64:
            case BuildTarget.StandaloneWindows:
                return string.Format("{0}.exe", outputFileName);
#if UNITY_2018_1_OR_NEWER
            case BuildTarget.StandaloneOSX:
#endif
#if !UNITY_2017_3_OR_NEWER
                    case BuildTarget.StandaloneOSXIntel:
                    case BuildTarget.StandaloneOSXIntel64:
#endif
                return string.Format("{0}.app", outputFileName);
            case BuildTarget.iOS:
            case BuildTarget.tvOS:
#if !UNITY_2019_2_OR_NEWER
            case BuildTarget.StandaloneLinux:
#endif
            case BuildTarget.WebGL:
            case BuildTarget.WSAPlayer:
#if !UNITY_2019_2_OR_NEWER
            case BuildTarget.StandaloneLinuxUniversal:
#endif
#if !UNITY_2018_3_OR_NEWER
                    case BuildTarget.PSP2:    
#endif
            case BuildTarget.PS4:
            case BuildTarget.XboxOne:
#if !UNITY_2017_3_OR_NEWER
                    case BuildTarget.SamsungTV:
#endif
#if !UNITY_2018_1_OR_NEWER
                    case BuildTarget.N3DS:
                    case BuildTarget.WiiU:
#endif
            case BuildTarget.Switch:
            case BuildTarget.NoTarget:
            default:
                return string.Empty;
        }
    }
}