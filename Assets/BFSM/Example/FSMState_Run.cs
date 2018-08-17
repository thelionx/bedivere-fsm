using UnityEngine;
using System.Collections;

namespace Bedivere.FSM.Examples
{
    [System.Serializable]
    public class FSMState_Run : IBFSMState
    {
        public FSMManager fsm;
        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            Debug.Log("Enter - Run");
        }

        public void OnUpdate()
        {
            Debug.Log("Update - Run");
        }

        public void OnExit(TransitionCause cause)
        {
            Debug.Log("Exit - Run");
        }
    }
}
