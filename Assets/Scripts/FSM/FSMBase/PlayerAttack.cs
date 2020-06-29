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
    public class PlayerAttack : FSMBase
    {
        public PlayerAttack(Animator ani):base(ani)
        {
            this.ani = ani;

        }

        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("进入Attack状态");
            // ani.SetInteger("index", 5);
        }

        public override void OnExit()
        {
            base.OnExit();
            Debug.Log("离开Attack状态");
        }

        public override void OnStay()
        {
            base.OnStay();

        }

    }
}