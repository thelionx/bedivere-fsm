using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Bedivere.FSM
{
    public class BFSMSystem : MonoBehaviour
    {
        public bool isLogged = true;
        public IBFSMState current;
        public List<IBFSMState> stack = new List<IBFSMState>();
        private List<IBFSMState> registeredStates = new List<IBFSMState>();

        #region events
        public delegate void StateChangeDelegate(IBFSMState oldState, IBFSMState newState, TransitionCause cause);
        public event StateChangeDelegate onStateChangeE;
        public void OnStateChange(IBFSMState oldState, IBFSMState newState, TransitionCause cause) { if (onStateChangeE != null) onStateChangeE(oldState, newState, cause); }
        #endregion

        public void RegisterState(IBFSMState state)
        {
            if (!registeredStates.Contains(state)) {
                registeredStates.Add(state);
            }
            else {
                Debug.LogErrorFormat("state {0} has been added previously", state);
            }
        }

        public void UnregisterState(IBFSMState state)
        {
            registeredStates.Remove(state);
        }

        public void GoToState(IBFSMState state, object customData = null)
        {
            if (registeredStates.Contains(state))
            {
                IBFSMState previous = null;

                if (stack.Count > 0) {
                    previous = stack.Last();

                    previous.OnExit();
                    stack.Remove(previous);
                }

                TransitionCause cause = TransitionCause.GoTo;

                current = state;
                current.OnEnter(previous, customData, cause);
                stack.Add(state);

                OnStateChange(previous, current, cause);

                if (isLogged)
                    Debug.LogFormat("[Go to State] {0} -> {1}", previous, current);

            }
            else
            {
                Debug.LogErrorFormat("Cannot go to {0} because it hasn't been added to the list.", state);
            }
        }

        public void PushState(IBFSMState state, object customData = null)
        {
            if (registeredStates.Contains(state))
            {
                IBFSMState previous = null;

                if (stack.Count > 0) {
                    previous = stack.Last();
                    previous.OnExit();
                }

                TransitionCause cause = TransitionCause.Push;

                current = state;
                current.OnEnter(previous, customData, cause);
                stack.Add(state);

                OnStateChange(previous, current, cause);

                if (isLogged)
                    Debug.LogFormat("[Push State] {0} -> {1}", previous, current);
            }
            else
            {
                Debug.LogErrorFormat("Cannot go to {0} because it hasn't been added to the list.", state);
            }
        }

        public void PopState(object customData = null)
        {
            IBFSMState previous = null;

            if (stack.Count > 0)
            {
                previous = stack.Last();
                previous.OnExit();

                stack.Remove(previous);

                if (stack.Count > 0)
                {
                    TransitionCause cause = TransitionCause.Pop;

                    current = stack.Last();
                    current.OnEnter(previous, customData, cause);

                    OnStateChange(previous, current, cause);
                }
                else
                {
                    current = null;
                }

                if (isLogged)
                    Debug.LogFormat("[Pop State] {0} -> {1}", previous, current);

            }
            else
            {
                Debug.LogError("[Pop] there is no more state to pop.");
            }
        }
    }

    public enum TransitionCause
    {
        GoTo,
        Push,
        Pop
    }
}

