/*
 *		Description: 
 *
 *		CreatedBy: guoShuai
 *
 *		DataTime: #DATE#
 *
 */
using guoShuai.UIHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace guoShuai.UIHelper
{
    // View 类 , 只用来显示
    public class LoginPage : UIBase  
    {

        LoginModel loginModel;
        LoginLogic loginLogic;

        private InputField Ninput_Account;

        private InputField Ninput_Psd;

      
        private void Start()
        {
            loginModel = new LoginModel();
            loginLogic = new LoginLogic(this);

           
            Ninput_Account = GetGameObject<InputField>("Ninput_Account");
            Ninput_Psd = GetGameObject<InputField>("Ninput_Psd");

            AddButtonListener("Nbtn_Login", loginLogic.OnClick);

            AddInputFieldEndEditListener("Ninput_Account", loginLogic.OnEditAction);
            AddInputFieldEndEditListener("Ninput_Psd", loginLogic.OnEditAction);

            SetText("Ntxt", "赋值text");


            OnEventHandler("Ntxt", EventTriggerType.Drag, DragCallback);

        }


        private void DragCallback(BaseEventData arg0)
        {
            // 回调需要把参数 强转一下
            PointerEventData tmp = (PointerEventData)arg0;
           
        }

        
    }


    // Logic 类 , 处理逻辑
    public class LoginLogic
    {
        private UIBase view;
        public LoginLogic(UIBase tmp)
        {
            view = tmp;
        }

        public void OnEditAction(string arg0)
        {
            Debug.Log(arg0);
        }

        public void OnClick()
        {
            Debug.Log("Click LoginBtn");
            
        }
    }



    // Model 类, 数据模型
    [Serializable]
    public class LoginModel
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }

}