using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace guoShuai.UIHelper
{
    public class UISubMgr : MonoBehaviour
    {
        // key: item名字 , value: item.transform
        private Dictionary<string, Transform> itemDic;

        void Awake()
        {

            UIBase panel = transform.GetComponentInParent<UIBase>();
            UIMgr.Instance.RegistSelf(panel.name, transform.name, gameObject);

            itemDic = new Dictionary<string, Transform>();

            Transform[] traArr = GetComponentsInChildren<Transform>();
            for (int i = 0; i < traArr.Length; i++)
            {
                Transform tmp = traArr[i];
                if (tmp.name.EndsWith("_C")) // 约定 item 里需要交互的组件,以_C结尾
                {
                    itemDic.Add(tmp.name, tmp);
                }
            }
        }


        /// <summary>
        /// 获取子控件
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Transform GetChildTransform(string name)
        {
            if (!itemDic.ContainsKey(name))
                return null;

            return itemDic[name];
        }


        #region 组件监听事件


        public void AddButtonListener(string btnName, UnityAction action)
        {
            Transform btnTra = GetChildTransform(btnName);
            if (btnTra != null)
            {
                Button btn = btnTra.GetComponent<Button>();

                if (btn != null)
                    btn.onClick.AddListener(action);
            }

        }

        public void AddToggleListener(string togName, UnityAction<bool> action)
        {
            Transform btnTra = GetChildTransform(togName);
            if (btnTra != null)
            {
                Toggle tog = btnTra.GetComponent<Toggle>();
                if (tog != null)
                    tog.onValueChanged.AddListener(action);
            }
        }

        public void AddInputFieldEndEditListener(string inputName, UnityAction<string> action)
        {
            Transform btnTra = GetChildTransform(inputName);
            if (btnTra != null)
            {
                InputField input = btnTra.GetComponent<InputField>();
                if (input != null)
                    input.onEndEdit.AddListener(action);
            }
        }

        public void AddInputFieldValueChangedListener(string inputName, UnityAction<string> action)
        {
            Transform btnTra = GetChildTransform(inputName);
            if (btnTra != null)
            {
                InputField input = btnTra.GetComponent<InputField>();
                if (input != null)
                    input.onValueChanged.AddListener(action);
            }
        }

        public void AddSliderListener(string sliderName, UnityAction<float> action)
        {
            Transform btnTra = GetChildTransform(sliderName);
            if (btnTra != null)
            {
                Slider slider = btnTra.GetComponent<Slider>();
                if (slider != null)
                    slider.onValueChanged.AddListener(action);
            }
        }


        public void SetText(string txtName, string str)
        {
            Transform btnTra = GetChildTransform(txtName);
            if (btnTra != null)
            {
                Text txt = btnTra.GetComponent<Text>();
                if (txt != null)
                    txt.text = str;
            }
        }

        public void SetImage(string spriteName, Sprite spr)
        {
            Transform btnTra = GetChildTransform(spriteName);
            if (btnTra != null)
            {
                Image ima = btnTra.GetComponent<Image>();
                if (ima != null)
                    ima.sprite = spr;
            }
        }


        public void SetRawImage(string rawImageName , Texture tex)
        {
            Transform btnTra = GetChildTransform(rawImageName);
            if (btnTra != null)
            {
                RawImage raw = btnTra.GetComponent<RawImage>();
                if (raw != null)
                    raw.texture = tex;
            }
        }

        #endregion

        #region 接口监听事件

        /// <summary>
        /// 添加接口监听事件
        /// </summary>
        /// <param name="eventType">接口类型</param>
        /// <param name="action">回调函数</param>
        public void EventHandler(string childName, EventTriggerType eventType, UnityAction<BaseEventData> action)
        {
            Transform tra = GetChildTransform(childName);
            if (tra == null) return;

            // 获取事件系统
            EventTrigger trigger = tra.GetComponent<EventTrigger>();
            if (trigger == null)
                trigger = tra.gameObject.AddComponent<EventTrigger>();

            // 事件实体
            EventTrigger.Entry entry = new EventTrigger.Entry();

            // 事件类型
            entry.eventID = eventType;

            // 事件回调
            entry.callback = new EventTrigger.TriggerEvent();

            // 添加回调函数
            entry.callback.AddListener(action);

            // 监听事件
            trigger.triggers.Add(entry);

        }


        #endregion


        private void OnDestroy()
        {
            itemDic.Clear();
            itemDic = null;
        }

    }
}
