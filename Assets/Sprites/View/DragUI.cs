﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragUI : ItemUI {

    /// <summary>
    /// 显示提示框
    /// </summary>
    public void ShowToolTip()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 隐藏提示框
    /// </summary>
    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 设置位置
    /// </summary>
    /// <param name="position"></param>
    public void SetPosition(Vector2 position)
    {
        transform.localPosition = position;
    }
}