using UnityEngine;
using System.Collections;

namespace Bedivere.FSM.Examples
{
    public class FSMEventListener : MonoBehaviour
    {
        public BFSMSystem fsm;

        void OnEnable()
        {
            fsm.onStateChangeE += OnStateChange;            
        }

        void OnStateChange (IBFSMState oldState, IBFSMState newState, TransitionCause cause)
        {
            Debug.LogFormat("[State Change] : {0} -> {1}, by {2}", oldState, newState, cause);
        }

        void OnDisable()
        {
            fsm.onStateChangeE -= OnStateChange;
        }
    }
}