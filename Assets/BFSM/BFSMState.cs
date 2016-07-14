using UnityEngine;

namespace Bedivere.FSM
{
    [System.Serializable]
    public class BFSMState
    {
        // This method is called before the state is made the current state (see: OnExit())
        public virtual void OnEnter(BFSMState previous, object customData, TransitionCause cause) {}

        // This method is called before leaving the current State by the FSM
        public virtual void OnExit() {}
    }
}