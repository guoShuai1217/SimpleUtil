using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace guoShuai.FSM
{
    public class PlayerIdle : FSMBase
    {

        public PlayerIdle(Animator ani) : base(ani)
        {
            this.ani = ani;
        }
       
        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("进入Idle状态");

            // 写动画进入的 API 
            // ani.SetInteger("index", 1);
        }

        public override void OnExit()
        {
            base.OnExit();
            Debug.Log("离开Idle状态");
        }

        public override void OnStay()
        {
            base.OnStay();
          
        }

    }
}
