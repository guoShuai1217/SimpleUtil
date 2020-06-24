/*
 *		Description: 
 *		
 *		ui管理类 , 这个类要保证最先执行 ;
 *		
 *		需要挂载UIBehaviour的组件 会在Awake里向此脚本注册 
 *		
 *		CreatedBy: guoShuai
 *
 *		DataTime: 2020.06.24
 *
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace guoShuai.UIHelper
{
    public class UIMgr : MonoBehaviour
    {

        public static UIMgr Instance;


        private Dictionary<string, Dictionary<string, UIBehaviour>> componentDic;

        private void Awake()
        {
            Instance = this;

            componentDic = new Dictionary<string, Dictionary<string, UIBehaviour>>();
        }


        /// <summary>
        /// 注册自己
        /// </summary>
        /// <param name="panelName"></param>
        /// <param name="componentName"></param>
        /// <param name="component"></param>
        public void RegistSelf(string panelName,string componentName, UIBehaviour component)
        {

            if (!componentDic.ContainsKey(panelName))
            {
                //Dictionary<string, GameObject> tmpDic = new Dictionary<string, GameObject>();
                //tmpDic.Add(componentName, component);
                //componentDic.Add(panelName, tmpDic);
                //return;

                 componentDic[panelName] = new Dictionary<string, UIBehaviour>();

            }

            componentDic[panelName].Add(componentName, component);

        }
  

        /// <summary>
        /// 获取panel下的子控件
        /// </summary>
        /// <param name="panelName">Panel名</param>
        /// <param name="componentName">组件名</param>
        /// <returns></returns>
        public T GetGameObject<T>(string panelName, string componentName) where T:Component
        {

            if (!componentDic.ContainsKey(panelName))
            {
                Debug.LogWarning("不包含该 panel : " + panelName);
                return null;
            }

            UIBehaviour tmp = componentDic[panelName][componentName];
            return tmp.GetComponent<T>();

        }


        #region 人家写的,我封装成泛型

        ///// <summary>
        ///// 获取panel下的子控件
        ///// </summary>
        ///// <param name="panelName">Panel名</param>
        ///// <param name="componentName">组件名</param>
        ///// <returns></returns>
        //public UIBehaviour GetGameObject(string panelName, string componentName)
        //{

        //    if (!componentDic.ContainsKey(panelName))
        //    {
        //        Debug.LogWarning("不包含该 panel : " + panelName);
        //        return null;
        //    }

        //    return componentDic[panelName][componentName];

        //}

        #endregion


        public void UnRegist(string panelName,string componentName)
        {
            if (componentDic.ContainsKey(panelName))
            {
                componentDic[panelName].Remove(componentName);
            }
        }

        public void UnRegist(string panelName)
        {
            if (componentDic.ContainsKey(panelName))
            {
                componentDic[panelName].Clear();
                componentDic[panelName] = null;
            }
        }


    }
}
