using UnityEngine;
using System.Collections;

namespace Bedivere.FSM.Examples
{
    [System.Serializable]
    public class FSMState_Walk : IBFSMState
    {
        public FSMManager fsm;
        public void OnEnter(IBFSMState previous, object customData, TransitionCause cause)
        {
            Debug.Log("Enter - Walk");
        }

        public void OnUpdate()
        {
            Debug.Log("Update - Walk");
        }

        public void OnExit(TransitionCause cause)
        {
            Debug.Log("Exit - Walk");
        }
    }
}
