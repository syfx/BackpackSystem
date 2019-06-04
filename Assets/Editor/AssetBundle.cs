using System.Collections;
using System.IO;
using UnityEditor;

public class AssetBundle{

    /// <summary>
    /// 打包资源
    /// </summary>
    [MenuItem("AssetBundle/Build AssetBundles")]
    public static void Pack()
    {
        string filePath = @"AssetBundles\LuaScripts";
        if(!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        //将lua脚本打包当前工程的filePath路径下
        BuildPipeline.BuildAssetBundles(filePath, BuildAssetBundleOptions.None, BuildTarget.Android);
        AssetDatabase.Refresh();        //刷新
    }
}
