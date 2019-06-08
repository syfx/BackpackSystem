using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using XLua;
using System.IO;
using System;

namespace PackSystem
{
    /// <summary>
    /// 中转站，在lua中不能直接调用的方法，通过这个类中的方法封装后进行访问
    /// </summary>
    [LuaCallCSharp]
    public class MiddleTier
    {
        /// <summary>
        /// 屏幕坐标转UI坐标
        /// </summary>
        /// <returns></returns>
        public static Vector2 ScreenPointToLocalPoint(Transform rect, Vector3 screenPos, Camera cam)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rect as RectTransform, screenPos, null, out position);
           return position;
        }
    }

    [LuaCallCSharp]
    public class LuaCallCs : MonoBehaviour
    {
        /// <summary>
        /// 用来储存当前脚本需要访问的其他游戏物体
        /// </summary>
        [System.Serializable]
        public class Injection
        {
            public string name;
            public GameObject value;
        }
        public Injection[] injections;
        /// <summary>
        /// 原始lua脚本
        /// </summary>
        public TextAsset luaScriptFile;

        private LuaEnv luaEnv;                                 //lua虚拟机
        private LuaTable scriptEnv;                          //当前脚本的lua环境
        private string luaText = string.Empty;         //从服务器加载的lua脚本的内容（非原始lua文件内容）

        private Action start;
        private Action update;

        private void Awake()
        {
            luaEnv = new LuaEnv();
            scriptEnv = luaEnv.NewTable();
            LuaTable metaTable = luaEnv.NewTable();

            //将lua全局环境当做表metaTable的元方法
            metaTable.Set("__index", luaEnv.Global);
            //将表metaTable设为scriptEnv的元表
            scriptEnv.SetMetaTable(metaTable);
            scriptEnv.Set("self", this);

            foreach(Injection obj in injections)
            {
                scriptEnv.Set(obj.name, obj.value);
            }

            if (luaText != string.Empty)
            {
                //执行上次热更后的版本
                luaEnv.DoString(luaText, "PackManager.Lua", scriptEnv);
            }
            else
            {
                //执行打包时的Lua脚本
                luaEnv.DoString(luaScriptFile.text, "PackManager.Lua", scriptEnv);
            }
            //将Lua中的start方法映射到当前start中
            start = scriptEnv.Get<Action>("start");
            //将Lua中的start方法映射到当前start中
            scriptEnv.Get("update", out update);
        }

        public void Start()
        {
            if (start != null)
            {
                start();
            }
        }
 
        private void Update()
        {
            if (update != null)
            {
                update();
            }
        }

        /// <summary>
        /// 数据加载
        /// </summary>
        private void Load(string resName, string resPath)
        {
            //从服务器加载PackManager.lua脚本
            StartCoroutine(UpdateLuaScript(resName, resPath, "luaText.txt"));
            LoadLuaScript("luaText.txt");
        }

        /// <summary>
        /// 从服务器获取Lua脚本并更新本地Lua脚本
        /// </summary>
        public IEnumerator UpdateLuaScript(string resName, string resPath, string localPath)
        {
            UnityWebRequest request = UnityWebRequest.GetAssetBundle("https://github.com/syfx/BackpackSystem/raw/master/AssetBundles/LuaScripts/" + resPath);
            yield return request.SendWebRequest();
            AssetBundle ab = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;
            if (ab != null)
            {
                luaScriptFile = ab.LoadAsset<TextAsset>(resName);
            }
            if (luaScriptFile != null)
            {
                Debug.Log("更新后重启程序");
                try
                {
                    StreamWriter sw;
                    //如果不存在则创建一个lua脚本文件
                    if (!File.Exists(Application.persistentDataPath + @"\" + localPath))
                    {
                        sw = File.CreateText(Application.persistentDataPath + @"\" + localPath);
                    }
                    else
                    {
                        //清空之前内容
                        sw = new StreamWriter(Application.persistentDataPath + @"\" + localPath, false);
                    }
                    //写入内容
                    sw.WriteLine(luaScriptFile.text);
                    //关闭并销毁流
                    sw.Close();
                    sw.Dispose();
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.Message);
                }
            }
        }
        /// <summary>
        /// 从本地加载lua脚本
        /// </summary>
        /// <param name="resName">文件在Application.persistentDataPath下的路径，不包括扩展名</param>
        public void LoadLuaScript(string localPath)
        {
            try
            {
                if (File.Exists(Application.persistentDataPath + @"\" + localPath))
                {
                    luaText = File.ReadAllText(Application.persistentDataPath + @"\" + localPath);
                }
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}
