using UnityEngine;
using System.Collections;

namespace Bedivere.FSM.Examples
{
    [System.Serializable]
    public class FSMState_Idle : IBFSMState
    {
        public FSMManager fsm;
        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            Debug.Log("Enter - Idle");
        }

        public void OnUpdate()
        {
            Debug.Log("Update - Idle");
        }

        public void OnExit(TransitionCause cause)
        {
            Debug.Log("Exit - Idle");
        }
    }
}
