using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackPanel : MonoBehaviour {

    [Tooltip("格子集合")]
    public Transform[] GridTransforms;

    /// <summary>
    /// 返回一个没有装备的空装备栏的Transform
    /// </summary>
    /// <returns></returns>
    public Transform GetNullGrid()
    {
        foreach(Transform OneGrid in GridTransforms)
            if (OneGrid.childCount == 0)
                return OneGrid;
        return null;
    }

    /// <summary>
    /// 判断背包是否已满
    /// </summary>
    /// <returns></returns>
    public bool IsFull()
    {
        foreach (Transform OneGrid in GridTransforms)
            if (OneGrid.childCount == 0)
                return false;
        return true;
    }
}
