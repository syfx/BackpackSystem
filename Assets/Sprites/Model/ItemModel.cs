using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModel
{
    private static Dictionary<string, Item> ModelList = new Dictionary<string, Item>();      //数据字典

    /// <summary>
    /// 储存数据
    /// </summary>
    /// <param name="name"></param>
    /// <param name="theitem"></param>
    public static void StoreData(string name, Item theitem)
    {
        RemoveDate(name);
        ModelList.Add(name, theitem);
    }

    /// <summary>
    /// 得到数据
    /// </summary>
    /// <param name="name"></param>
    public static Item GetData(string name)
    {
        if (ModelList.ContainsKey(name))
            return ModelList[name];
        else
            return null;
    }

    /// <summary>
    /// 移除数据
    /// </summary>
    /// <param name="name"></param>
    public static void RemoveDate(string name)
    {
        if (ModelList.ContainsKey(name))
            ModelList.Remove(name);
    }
}
