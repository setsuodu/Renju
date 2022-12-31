using System.IO;
using System.Diagnostics;
using UnityEngine;
using UnityEditor;
using Debug = UnityEngine.Debug;

public partial class MenuTools : Editor
{
    // 执行批处理文件
    protected static void ExecuteBatch(string fileName, string args)
    {
        Process proc = new Process();
        proc.StartInfo.FileName = fileName; //初始化可执行文件名
        proc.StartInfo.Arguments = args; //初始化可执行文件名
        proc.Start();
    }

    [MenuItem("Tools/打包/Windows", false, 1)]
    static void BuildRes_Win64()
    {
        BundleTools.BuildRes(BuildTarget.StandaloneWindows64);
    }
    [MenuItem("Tools/打包/Single", false, 1)]
    static void BuildRes_Single()
    {
        // 自动收集整个项目中的标签，进行打包
        //Object mainAsset0 = Selection.activeGameObject;
        string output = Application.streamingAssetsPath;
        if (Directory.Exists(output) == false)
            Directory.CreateDirectory(output);
        BuildPipeline.BuildAssetBundles(output, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
        return;

        /*
        //①依赖资源
        BuildPipeline.PushAssetDependencies();
        {
            //string filePath = Path.Combine(Application.dataPath, "Bundles/Atlas");
            //BuildPipeline.BuildAssetBundles(filePath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
            Object mainAsset = AssetDatabase.LoadMainAssetAtPath("Assets/Bundles/Atlas/SP_Atlas_1.spriteatlas"); //资源位置
            string pathName = Path.Combine(Application.streamingAssetsPath, "sp_atlas_1.unity3d"); //输出位置
            BuildPipeline.BuildAssetBundle(mainAsset, null, pathName, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
            
            //②Main资源
            BuildPipeline.PushAssetDependencies();
            {
                //string filePath1 = Path.Combine(Application.dataPath, "Bundles/UI_Login");
                //BuildPipeline.BuildAssetBundles(filePath1, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
                string pathName1 = Path.Combine(Application.streamingAssetsPath, "ui_login.unity3d"); //输出位置
                Object mainAsset1 = AssetDatabase.LoadMainAssetAtPath("Assets/Bundles/UI/UI_Login.prefab");
                BuildPipeline.BuildAssetBundle(mainAsset1, null, pathName1, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
            }
            BuildPipeline.PopAssetDependencies();

            BuildPipeline.PushAssetDependencies();
            {
                //string filePath2 = Path.Combine(Application.dataPath, "Bundles/UI_Game");
                //BuildPipeline.BuildAssetBundles(filePath2, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
                string pathName2 = Path.Combine(Application.streamingAssetsPath, "ui_game.unity3d"); //输出位置
                Object mainAsset2 = AssetDatabase.LoadMainAssetAtPath("Assets/Bundles/UI/UI_Game.prefab");
                BuildPipeline.BuildAssetBundle(mainAsset2, null, pathName2, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
            }
            BuildPipeline.PopAssetDependencies();
        }
        BuildPipeline.PopAssetDependencies();
        */
    }
}