/*
 *		Description: 
 *
 *		CreatedBy: guoShuai
 *
 *		DataTime: #DATE#
 *
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace guoShuai.FSM
{
    public class PlayerRun : FSMBase
    {
        public PlayerRun(Animator tmp):base(tmp)
        {
            ani = tmp;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("进入Run状态");
            // ani.SetInteger("index", 3);
        }

        public override void OnExit()
        {
            base.OnExit();
            Debug.Log("离开Run状态");
        }

        public override void OnStay()
        {
            base.OnStay();

        }
    }  
}