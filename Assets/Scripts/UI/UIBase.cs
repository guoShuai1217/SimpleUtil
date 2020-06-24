/*
 *		Description: 
 *		
 *		UI基类 , 所有 UI 以Panel划分 , 
 *		
 *		也就是Panel上的类都要继承 UIBase
 *				
 *		CreatedBy: guoShuai
 *
 *		DataTime: 2020.06.24
 *
 */
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace guoShuai.UIHelper
{
    public class UIBase : MonoBehaviour
    {

        private void Awake()
        {
            Transform[] traArr = GetComponentsInChildren<Transform>();
            for (int i = 0; i < traArr.Length; i++)
            {
                Transform tmp = traArr[i];
                // 约定 需要挂载UIBehaviour脚本的组件, 都要以 N 开头
                if (tmp.name.StartsWith("N"))
                {
                    tmp.gameObject.AddComponent<UIBehaviour>();
                }
            }
        }

        /// <summary>
        /// 获取组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="componentName"></param>
        /// <returns></returns>
        public T GetGameObject<T>(string componentName) where T : Component
        {
            return UIMgr.Instance.GetGameObject<T>(transform.name, componentName);
        }

        #region 人家写的,我把这两个方法写成泛型

        ///// <summary>
        ///// 获取子物体
        ///// </summary>
        ///// <param name="componentName"></param>
        ///// <returns></returns>
        //public UIBehaviour GetBehaviour(string componentName)
        //{
        //    return UIMgr.Instance.GetGameObject(transform.name, componentName);          
        //}

        ///// <summary>
        ///// 获取子物体的 UIBehaviour 组件
        ///// </summary>
        ///// <param name="componentName"></param>
        ///// <returns></returns>
        //public UIBehaviour GetBehaviour(string componentName)
        //{
        //    GameObject oo = GetGameObject(componentName);
        //    if (oo != null)
        //        return oo.GetComponent<UIBehaviour>();

        //    return null;
        //}

        #endregion

        #region 下层API

        public void AddButtonListener(string componentName, UnityAction action)
        {
            UIBehaviour tmp = GetGameObject<UIBehaviour>(componentName);
            if (tmp != null)
                tmp.AddButtonListener(action);
        }

        public void AddToggleListener(string componentName, UnityAction<bool> action)
        {
            UIBehaviour tmp = GetGameObject<UIBehaviour>(componentName);
            if (tmp != null)
                tmp.AddToggleListener(action);
        }

        public void AddInputFieldEndEditListener(string componentName, UnityAction<string> action)
        {
            UIBehaviour tmp = GetGameObject<UIBehaviour>(componentName);
            if (tmp != null)
                tmp.AddInputFieldEndEditListener(action);
        }

        public void AddInputFieldValueChangedListener(string componentName, UnityAction<string> action)
        {
            UIBehaviour tmp = GetGameObject<UIBehaviour>(componentName);
            if (tmp != null)
                tmp.AddInputFieldValueChangedListener(action);
        }

        public void AddSliderListener(string componentName, UnityAction<float> action)
        {
            UIBehaviour tmp = GetGameObject<UIBehaviour>(componentName);
            if (tmp != null)
                tmp.AddSliderListener(action);
        }


        public void SetText(string componentName, string str)
        {
            UIBehaviour tmp = GetGameObject<UIBehaviour>(componentName);
            if (tmp != null)
                tmp.SetText(str);
        }

        public void SetImage(string componentName, Sprite spr)
        {
            UIBehaviour tmp = GetGameObject<UIBehaviour>(componentName);
            if (tmp != null)
                tmp.SetImage(spr);
        }


        public void SetRawImage(string componentName, Texture spr)
        {
            UIBehaviour tmp = GetGameObject<UIBehaviour>(componentName);
            if (tmp != null)
                tmp.SetRawImage(spr);
        }


        /// <summary>
        /// 接口监听事件
        /// </summary>
        /// <param name="componentName">组件名字</param>
        /// <param name="eventType">继承接口类型</param>
        /// <param name="action">回调</param>
        public void OnEventHandler(string componentName, EventTriggerType eventType, UnityAction<BaseEventData> action)
        {
            UIBehaviour tmp = GetGameObject<UIBehaviour>(componentName);
            if (tmp != null)
                tmp.EventHandler(eventType,action);
        }


        #endregion


        private void OnDestroy()
        {
            UIMgr.Instance.UnRegist(transform.name);
        }
    }
}
