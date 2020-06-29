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
    public class PlayerJump : FSMBase
    {

        public PlayerJump(Animator ani) : base(ani)
        {
            this.ani = ani;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("进入Jump状态");
            // ani.SetInteger("index", 4);
        }

        public override void OnExit()
        {
            base.OnExit();
            Debug.Log("离开Jump状态");
        }

        public override void OnStay()
        {
            base.OnStay();

        }
    }
}