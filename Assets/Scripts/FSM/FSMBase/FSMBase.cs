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
    public class FSMBase
    {
        protected Animator ani;

        public FSMBase(Animator ani)
        {
            this.ani = ani;
        }

        public virtual void OnEnter() { }

        public virtual void OnStay() { }

        public virtual void OnExit() { }

    }
}
