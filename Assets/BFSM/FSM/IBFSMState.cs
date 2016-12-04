using UnityEngine;

namespace Bedivere.FSM
{
    public interface IBFSMState
    {
        // This method is called before the state is made the current state (see: OnExit())
        void OnEnter(IBFSMState previous, object customData, TransitionCause cause);

        // This method is called before leaving the current State by the FSM
        void OnExit(TransitionCause cause);
    }
}