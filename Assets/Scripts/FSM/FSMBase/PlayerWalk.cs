using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace guoShuai.FSM
{
    public class PlayerWalk : FSMBase
    {
        public PlayerWalk(Animator ani) : base(ani)
        {
            this.ani = ani;
        }

        private FSMManager fsm;

        public PlayerWalk(Animator ani,FSMManager fsm) :base(ani)
        {
            this.ani = ani;
            this.fsm = fsm;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("进入Walk状态");

            // this.ani.SetInteger("index", 2);
        }

        public override void OnExit()
        {
            base.OnExit();
            Debug.Log("离开Walk状态");
           
        }

        public override void OnStay()
        {
            base.OnStay();


            // 达到特定条件后,切换回idle状态
            // fsm.ChangeState(AnimatorEnum.Idle);

        }
    }
}
