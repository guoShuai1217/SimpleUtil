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

        private UISubMgr subMgr;
      
        private void Start()
        {
            loginModel = new LoginModel();
            loginLogic = new LoginLogic(loginModel);

           
            Ninput_Account = GetGameObject<InputField>("Ninput_Account");
            Ninput_Psd = GetGameObject<InputField>("Ninput_Psd");

            AddButtonListener("Nbtn_Login", loginLogic.OnClick);

            AddInputFieldEndEditListener("Ninput_Account", loginLogic.AccountEndEdit);
            AddInputFieldEndEditListener("Ninput_Psd", loginLogic.PasswordEndEdit);

            SetText("Ntxt", "赋值text");


            OnEventHandler("Ntxt", EventTriggerType.Drag, DragCallback);


            subMgr = GetGameObject<UISubMgr>("itemName");
            subMgr.SetText("txt_C","laowang");
             
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
        private LoginModel model;
        public LoginLogic(LoginModel tmp)
        {
            model = tmp;
        }
 
        public void AccountEndEdit(string account)
        {
            if (string.IsNullOrEmpty(account))
                return;

            model.Account = account;
        }

        public void PasswordEndEdit(string psd)
        {
            if (string.IsNullOrEmpty(psd))
                return;

            model.Password = psd;
        }

        public void  OnClick()
        {
            if (string.IsNullOrEmpty(model.Account))
                return;
            if (string.IsNullOrEmpty(model.Password))
                return;

            // 登陆请求

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