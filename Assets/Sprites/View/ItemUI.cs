﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour {

    public Image TheImage;

    /// <summary>
    /// 设置装备图片
    /// </summary>
    /// <param name="Item_Sprite">装备图片</param>
    public void Set_Item(Sprite Item_Sprite)
    {
        if (Item_Sprite == null)
            return;
        TheImage.sprite = Item_Sprite;
    }
}
