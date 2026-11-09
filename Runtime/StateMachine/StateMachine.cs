using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns 
{
    public class StateMachine {
        StateNode currentNode;
        readonly Dictionary<IState, StateNode> nodes = new(); // keyed by instance so two states of the same class stay distinct
        readonly HashSet<Transition> anyTransitions = new();
        
        public IState CurrentState => currentNode?.State;

        public void Update() {
            if (currentNode == null) return;

            var transition = GetTransition();

            if (transition != null) {
                ChangeState(transition.To);
                foreach (var node in nodes.Values) {
                    ResetActionPredicateFlags(node.Transitions);
                }
                ResetActionPredicateFlags(anyTransitions);
            }

            currentNode.State?.Update();
        }

        static void ResetActionPredicateFlags(IEnumerable<Transition> transitions) {
            foreach (var transition in transitions.OfType<Transition<ActionPredicate>>()) {
                transition.condition.flag = false;
            }
        }
        
        public void FixedUpdate() {
            currentNode?.State?.FixedUpdate();
        }

        public void SetState(IState state)
        {
            var node = GetOrAddNode(state);
            var previousState = currentNode?.State;
            if (previousState == node.State) return;

            previousState?.OnExit();
            currentNode = node;
            node.State?.OnEnter(previousState);
        }

        void ChangeState(IState state) {
            if (state == currentNode.State)
                return;

            var previousState = currentNode.State;
            var nextNode = GetOrAddNode(state);

            previousState?.OnExit();
            nextNode.State.OnEnter(previousState);
            currentNode = nextNode;
        }

        public void AddTransition<T>(IState from, IState to, T condition) {
            GetOrAddNode(from).AddTransition(GetOrAddNode(to).State, condition);
        }

        public void AddAnyTransition<T>(IState to, T condition) {
            anyTransitions.Add(new Transition<T>(GetOrAddNode(to).State, condition));
        }

        Transition GetTransition() {
            // An any-transition into the current state is a no-op; don't let it shadow this state's own transitions.
            foreach (var transition in anyTransitions)
                if (transition.To != currentNode.State && transition.Evaluate())
                    return transition;

            foreach (var transition in currentNode.Transitions) {
                if (transition.Evaluate())
                    return transition;
            }

            return null;
        }

        StateNode GetOrAddNode(IState state) {
            var node = nodes.GetValueOrDefault(state);
            if (node == null) {
                node = new StateNode(state);
                nodes[state] = node;
            }

            return node;
        }
        
        class StateNode {
            public IState State { get; }
            public HashSet<Transition> Transitions { get; }

            public StateNode(IState state) {
                State = state;
                Transitions = new HashSet<Transition>();
            }

            public void AddTransition<T>(IState to, T predicate) {
                Transitions.Add(new Transition<T>(to, predicate));
            }
        }
    }
}