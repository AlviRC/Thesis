using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System.IO;
using System.Linq;

public class FastWebGLBuildAndServe
{
    private static readonly string BuildRoot = "Builds";
    private static readonly string BuildFolderName = "HopefulBuild3";
    private static readonly string FullBuildPath = Path.Combine(BuildRoot, BuildFolderName);

    [MenuItem("Tools/Fast WebGL Build, Serve & Run")]
    public static void BuildAndServe()
    {
        // Ensure target is WebGL
        if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.WebGL)
        {
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.WebGL, BuildTarget.WebGL);
        }

        EditorUserBuildSettings.development = false;
        EditorUserBuildSettings.allowDebugging = false;
        EditorUserBuildSettings.connectProfiler = false;

        // 🔹 Force Brotli compression (best for iOS and production)
        PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Brotli;
        PlayerSettings.WebGL.linkerTarget = WebGLLinkerTarget.Wasm;
        PlayerSettings.WebGL.exceptionSupport = WebGLExceptionSupport.None;
        PlayerSettings.WebGL.debugSymbolMode = WebGLDebugSymbolMode.External;
        PlayerSettings.stripEngineCode = true;

        // Ensure build directory exists
        if (!Directory.Exists(FullBuildPath))
            Directory.CreateDirectory(FullBuildPath);

        // Build the WebGL player
        BuildPlayerOptions buildOptions = new BuildPlayerOptions
        {
            scenes = GetEnabledScenes(),
            locationPathName = FullBuildPath,
            target = BuildTarget.WebGL,
            options = BuildOptions.None
        };

        BuildReport report = BuildPipeline.BuildPlayer(buildOptions);

        if (report.summary.result == BuildResult.Succeeded)
        {
            Debug.Log("✅ Build succeeded. Launching local Brotli server...");
            // StartLocalServer();
        }
        else
        {
            Debug.LogError("❌ Build failed.");
        }
    }

    private static string[] GetEnabledScenes()
    {
        return EditorBuildSettings.scenes
            .Where(scene => scene.enabled)
            .Select(scene => scene.path)
            .ToArray();
    }

    private static void StartLocalServer()
    {
        string workingDir = Path.GetFullPath(FullBuildPath);  // Builds/HopefulBuild3 folder
        string url = "http://localhost:8000";

        // 🔹 Use Node.js http-server with Brotli
        System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
        {
            FileName = "http-server",
            Arguments = "-p 8000 --brotli",
            UseShellExecute = false,
            CreateNoWindow = true
        };

        try
        {
            System.Diagnostics.Process.Start(psi);
            Debug.Log($"🌐 Local Brotli server started at: {url}, serving folder: {workingDir}");
            Application.OpenURL(url);
        }
        catch (System.Exception e)
        {
            Debug.LogError("⚠️ Failed to start Brotli server. Make sure Node.js is installed and in PATH.\n" + e.Message);
        }
    }
}

// using UnityEditor;
// using UnityEditor.Build.Reporting;
// using UnityEngine;
// using System.IO;
// using System.Linq;

// public class FastWebGLBuildAndServe
// {
//     private static readonly string BuildRoot = "Builds";
//     private static readonly string BuildFolderName = "HopefulBuild3";
//     private static readonly string FullBuildPath = Path.Combine(BuildRoot, BuildFolderName);

//     [MenuItem("Tools/Fast WebGL Build, Serve & Run (Gzip)")]
//     public static void BuildAndServe()
//     {
//         // Ensure target is WebGL
//         if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.WebGL)
//         {
//             EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.WebGL, BuildTarget.WebGL);
//         }

//         EditorUserBuildSettings.development = false;
//         EditorUserBuildSettings.allowDebugging = false;
//         EditorUserBuildSettings.connectProfiler = false;

//         // 🔹 Force Gzip compression (faster decompression, slightly bigger files)
//         // PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Gzip;
//         PlayerSettings.WebGL.linkerTarget = WebGLLinkerTarget.Wasm;
//         PlayerSettings.WebGL.exceptionSupport = WebGLExceptionSupport.None;
//         PlayerSettings.WebGL.debugSymbolMode = WebGLDebugSymbolMode.External;
//         PlayerSettings.stripEngineCode = true;

//         // Ensure build directory exists
//         if (!Directory.Exists(FullBuildPath))
//             Directory.CreateDirectory(FullBuildPath);

//         // Build the WebGL player
//         BuildPlayerOptions buildOptions = new BuildPlayerOptions
//         {
//             scenes = GetEnabledScenes(),
//             locationPathName = FullBuildPath,
//             target = BuildTarget.WebGL,
//             options = BuildOptions.None
//         };

//         BuildReport report = BuildPipeline.BuildPlayer(buildOptions);

//         if (report.summary.result == BuildResult.Succeeded)
//         {
//             Debug.Log("✅ Build succeeded. Launching local Gzip server...");
//             StartLocalServer();
//         }
//         else
//         {
//             Debug.LogError("❌ Build failed.");
//         }
//     }

//     private static string[] GetEnabledScenes()
//     {
//         return EditorBuildSettings.scenes
//             .Where(scene => scene.enabled)
//             .Select(scene => scene.path)
//             .ToArray();
//     }

//     private static void StartLocalServer()
//     {
//         string workingDir = Path.GetFullPath(FullBuildPath);  // Builds/HopefulBuild3 folder
//         string url = "http://localhost:8000";

//         // 🔹 Use Node.js http-server with Gzip
//         System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
//         {
//             FileName = "http-server",
//             // Arguments = "-p 8000 --gzip",
//             Arguments = "-p 8000",
//             UseShellExecute = false,
//             CreateNoWindow = true
//         };

//         try
//         {
//             System.Diagnostics.Process.Start(psi);
//             Debug.Log($"🌐 Local Gzip server started at: {url}, serving folder: {workingDir}");
//             Application.OpenURL(url);
//         }
//         catch (System.Exception e)
//         {
//             Debug.LogError("⚠️ Failed to start Gzip server. Make sure Node.js is installed and in PATH.\n" + e.Message);
//         }
//     }
// }
