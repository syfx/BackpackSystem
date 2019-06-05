using UnityEngine;
using UnityEngine.EventSystems;
using System;
using XLua;

namespace PackSystem
{
    [LuaCallCSharp]
    public class GridUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,
                    IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        /// <summary>
        /// 鼠标进入格子时的监听
        /// </summary>
        static public Action<Transform> OnEnter;
        /// <summary>
        /// 鼠标离开格子时的监听
        /// </summary>
        static public Action OnExit;
        /// <summary>
        /// 开始拖拽格子时的监听
        /// </summary>
        static public Action<Transform> OnLeftBeginDrag;
        /// <summary>
        /// 结束拖拽格子时的监听
        /// </summary>
        static public Action<Transform, Transform> OnLeftEndDrag;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (OnEnter != null)
                OnEnter(transform);
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            if (OnExit != null)
                OnExit();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
                if (OnLeftBeginDrag != null)
                    OnLeftBeginDrag(transform);
        }
        public void OnDrag(PointerEventData eventData)
        {
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            if (OnLeftEndDrag != null)
            {
                if (eventData.pointerEnter == null)
                    OnLeftEndDrag(transform, null);
                else
                    OnLeftEndDrag(transform, eventData.pointerEnter.transform);
            }
        }
    }
}