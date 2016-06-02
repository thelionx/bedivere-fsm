using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Bedivere.FSM
{
    public class BFSMSystem : MonoBehaviour
    {
        [SerializeField] private List<BFSMState> registeredStates = new List<BFSMState>();

        [SerializeField] private BFSMState current;
        [SerializeField] private List<BFSMState> stack = new List<BFSMState>();

        public void RegisterState(BFSMState state)
        {
            if (!registeredStates.Contains(state)) {
                registeredStates.Add(state);
                state.Initialize();
            }
            else {
                Debug.LogErrorFormat("state {0} has been added previously", state);
            }
        }

        public void UnregisterState(BFSMState state)
        {
            registeredStates.Remove(state);
        }

        public void GoToState(BFSMState state, object customData = null)
        {
            if (registeredStates.Contains(state))
            {
                BFSMState previous = null;

                if (stack.Count > 0) {
                    previous = stack.Last();

                    previous.OnExit();
                    stack.Remove(previous);
                }

                current = state;
                current.OnEnter(customData);
                stack.Add(state);

                #if UNITY_EDITOR
                Debug.LogFormat("[Go to State] {0} -> {1}", previous, current);
                #endif

            }
            else
            {
                Debug.LogErrorFormat("Cannot go to {0} because it hasn't been added to the list.", state);
            }
        }

        public void PushState(BFSMState state, object customData = null)
        {
            if (registeredStates.Contains(state))
            {
                BFSMState previous = null;

                if (stack.Count > 0) {
                    previous = stack.Last();
                    previous.OnExit();
                }

                current = state;
                current.OnEnter(customData);
                stack.Add(state);

                #if UNITY_EDITOR
                Debug.LogFormat("[Push State] {0} -> {1}", previous, current);
                #endif
            }
            else
            {
                Debug.LogErrorFormat("Cannot go to {0} because it hasn't been added to the list.", state);
            }
        }

        public void PopState(object customData = null)
        {
            BFSMState previous = null;

            if (stack.Count > 0)
            {
                previous = stack.Last();
                previous.OnExit();

                stack.Remove(previous);

                if (stack.Count > 0)
                {
                    current = stack.Last();
                    current.OnEnter(customData);
                }
                else
                {
                    current = null;
                }

                #if UNITY_EDITOR
                Debug.LogFormat("[Pop State] {0} -> {1}", previous, current);
                #endif

            }
            else
            {
                Debug.LogFormat("[Pop] there is no more state to pop.");
            }
        }
    }
}

