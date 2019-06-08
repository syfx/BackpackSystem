using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace PackSystem
{
    [LuaCallCSharp]
    public class ButtonAddItem : MonoBehaviour
    {
        private SpriteRenderer render;          //按钮的渲染器

        private void Awake()
        {
            render = GetComponent<SpriteRenderer>();
        }

        /// <summary>
        /// 切换按钮皮肤
        /// </summary>
        public void ChangeSkin(Sprite sprite)
        {
            render.sprite = sprite;
        }
    }
}