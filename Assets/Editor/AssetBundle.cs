using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class AssetBundle{

    /// <summary>
    /// 打包资源
    /// </summary>
    [MenuItem("AssetBundle/Build AssetBundles")]
	public static void Pack()
    {
        AssetImporter assetImporter = AssetImporter.GetAtPath(@"Assets/myAssets");
        assetImporter.assetBundleName = "UISkin";
    }
}
