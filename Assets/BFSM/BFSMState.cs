using UnityEngine;

namespace Bedivere.FSM
{
    [System.Serializable]
    public class BFSMState
    {
        public string name = string.Empty;
        public BFSMSystem fsmSystem;

        public void Initialize(BFSMSystem fsmSystem)
        {
            this.name = this.GetType().Name;
            this.fsmSystem = fsmSystem;
        }

        // This method is called before the state is made the current state (see: OnExit())
        public virtual void OnEnter(BFSMState previous, object customData) {}

        // This method is called before leaving the current State by the FSM
        public virtual void OnExit() {}
    }
}