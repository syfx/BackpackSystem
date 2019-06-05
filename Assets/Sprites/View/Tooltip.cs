using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;

namespace PackSystem
{
    [LuaCallCSharp]
    public class Tooltip : MonoBehaviour
    {
        [Tooltip("控制提示框大小的Text组件")]
        public Text SizeText;
        [Tooltip("显示提示信息的Text组件")]
        public Text HintText;

        /// <summary>
        /// 更新提示框显示
        /// </summary>
        /// <param name="text"></param>
        public void UpdateToolTip(string text)
        {
            SizeText.text = text;
            HintText.text = text;
        }

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
}