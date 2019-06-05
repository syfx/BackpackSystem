using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace PackSystem
{
    [LuaCallCSharp]
    public class DragUI : ItemUI
    {

        /// <summary>
        /// 显示若拽UI
        /// </summary>
        public void ShowDrag()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// 隐藏提示框
        /// </summary>
        public void HideDrag()
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
}