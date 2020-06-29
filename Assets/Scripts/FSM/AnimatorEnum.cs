using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guoShuai.FSM
{
    public enum AnimatorEnum
    {
        None = -1,

        Idle,
        Walk,
        Run,
        Jump,
        Attack,

        // 中间随意加


        MaxValue
    }
}
