using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guoShuai.FSM
{
    public class FSMManager
    {

        private Dictionary<AnimatorEnum, FSMBase> stateDic;

        // 当前状态
        private AnimatorEnum curState;


        public FSMManager()
        {
            stateDic = new Dictionary<AnimatorEnum, FSMBase>();

            curState = AnimatorEnum.None;
        }

        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddState(AnimatorEnum key,FSMBase value)
        {
            if (stateDic.ContainsKey(key))
                return;

            stateDic.Add(key, value);
        }

      
        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="stateId"></param>
        public void ChangeState(AnimatorEnum stateId)
        {
            if (curState == stateId) return;

            if(curState != AnimatorEnum.None)
            {
                // 如果当前状态不为None,就执行 离开当前状态的API
                stateDic[curState].OnExit();
            }

            curState = stateId;

            stateDic[curState].OnEnter(); // 进入要切换的状态
        }


        /// <summary>
        /// 当前状态中(Update里一直执行)
        /// </summary>
        public void Stay()
        {
            if (curState != AnimatorEnum.None)
                stateDic[curState].OnStay();
        }


    }
}
