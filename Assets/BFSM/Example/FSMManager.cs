using UnityEngine;
using System.Collections;

namespace Bedivere.FSM.Examples
{
    public class FSMManager : BFSMSystem 
    {
        public FSMState_Idle stateIdle;
        public FSMState_Walk stateWalk;
        public FSMState_Run stateRun;

        void Start()
        {
            RegisterStates();
        }

        void RegisterStates()
        {
            stateIdle.fsm = this;
            stateWalk.fsm = this;
            stateRun.fsm = this;

            RegisterState(stateIdle);
            RegisterState(stateWalk);
            RegisterState(stateRun);

            GoToState(stateIdle);
        }

        public void GoToIdle()
        {
            GoToState(stateIdle);
        }

        public void GoToWalk()
        {
            GoToState(stateWalk);
        }

        public void GoToRun()
        {
            GoToState(stateRun);
        }

        public void PushWalk()
        {
            PushState(stateWalk);
        }

        public void Pop()
        {
            PopState();
        }
    }
}
