/*
 *		Description: 需要做交互的组件,都需要挂载这个类 ;
 *		
 *		组件的名字 约定 N 开头
 *		
 *
 *		CreatedBy: guoShuai
 *
 *		DataTime: 2020.06.24
 *
 */
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace guoShuai.UIHelper
{
    public class UIBehaviour : MonoBehaviour
    {

        private void Awake()
        {
            UIBase tmpBase = transform.GetComponentInParent<UIBase>();
            UIMgr.Instance.RegistSelf(tmpBase.name, transform.name, gameObject);
        }


        #region 组件监听事件

    
        public void AddButtonListener(UnityAction action)
        {
            Button btn = GetComponent<Button>();
            if (btn != null)
                btn.onClick.AddListener(action);
        }

        public void AddToggleListener(UnityAction<bool> action)
        {
            Toggle tog = GetComponent<Toggle>();
            if (tog != null)
                tog.onValueChanged.AddListener(action);
        }

        public void AddInputFieldEndEditListener(UnityAction<string> action)
        {
            InputField input = GetComponent<InputField>();
            if (input != null)
                input.onEndEdit.AddListener(action);
        }

        public void AddInputFieldValueChangedListener(UnityAction<string> action)
        {
            InputField input = GetComponent<InputField>();
            if (input != null)
                input.onValueChanged.AddListener(action);
        }

        public void AddSliderListener(UnityAction<float> action)
        {
            Slider slider = GetComponent<Slider>();
            if (slider != null)
                slider.onValueChanged.AddListener(action);
        }


        public void SetText(string str)
        {
            Text txt = GetComponent<Text>();
            if (txt != null)
                txt.text = str;
        }

        public void SetImage(Sprite spr)
        {
            Image ima = GetComponent<Image>();
            if (ima != null)
                ima.sprite = spr;
        }


        public void SetRawImage(Texture spr)
        {
            RawImage raw = GetComponent<RawImage>();
            if (raw != null)
                raw.texture = spr;
        }

        #endregion

        #region 接口监听事件

        /// <summary>
        /// 添加接口监听事件
        /// </summary>
        /// <param name="eventType">接口类型</param>
        /// <param name="action">回调函数</param>
        public void EventHandler(EventTriggerType eventType, UnityAction<BaseEventData> action)
        {
            // 获取事件系统
            EventTrigger trigger = GetComponent<EventTrigger>();
            if (trigger == null)
                trigger = gameObject.AddComponent<EventTrigger>();

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

    }
}
