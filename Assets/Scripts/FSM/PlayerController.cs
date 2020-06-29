using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace guoShuai.FSM
{
    public class PlayerController : MonoBehaviour
    {

        private FSMManager fsmmgr;

        private Animator ani;

        private void Awake()
        {
            fsmmgr = new FSMManager();
            ani = GetComponent<Animator>();

            addState();
        }

        void addState()
        {
            PlayerIdle idle = new PlayerIdle(ani);
            fsmmgr.AddState(AnimatorEnum.Idle, idle);

            PlayerWalk walk = new PlayerWalk(ani);
            fsmmgr.AddState(AnimatorEnum.Walk, walk);

            PlayerRun run = new PlayerRun(ani);
            fsmmgr.AddState(AnimatorEnum.Run, run);

            PlayerJump jump = new PlayerJump(ani);
            fsmmgr.AddState(AnimatorEnum.Jump, jump);

            PlayerAttack attack = new PlayerAttack(ani);
            fsmmgr.AddState(AnimatorEnum.Attack, attack);
        }


        private void Update()
        {
            if (fsmmgr != null)
                fsmmgr.Stay();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                fsmmgr.ChangeState(AnimatorEnum.Jump);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                fsmmgr.ChangeState(AnimatorEnum.Run);
            }
        }


    }
}
