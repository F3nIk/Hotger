using F3Lib.Patterns.State;

using System.Collections.Generic;
using System.Linq;

public interface IStateMachine<TTrigger, TState>
{
    void Fire(TTrigger trigger);
    void Fire(TTrigger trigger, ITransitionalData data);
}

namespace F3Lib.Patterns.State
{
    public class StateMachine<TTrigger, TState> : IStateMachine<TTrigger, IState<TTrigger>> where TState : IState<TTrigger>
    {
        private readonly List<Transition<TTrigger, TState>> _transitions = new List<Transition<TTrigger, TState>>();
        private TState _currentState;

        public StateMachine(TState initState)
        {
            _currentState = initState;
            _currentState.StateMachine = this;
            _currentState.Execute();
            _transitions.Add(new Transition<TTrigger, TState>(initState));
        }

        public ITransition<TTrigger, TState> Configure(TState state)
        {
            state.StateMachine = this;

            Transition<TTrigger, TState> configureable =
                _transitions.FirstOrDefault(transition => transition.GetState().Equals(state));

            Transition<TTrigger, TState> transition = new Transition<TTrigger, TState>(state);
            _transitions.Add(transition);
            configureable = transition;

            if (configureable == null)
            {
            }

            return configureable;
        }

        public void Fire(TTrigger trigger)
        {
            UpdateTarget(trigger);
            _currentState.Execute();
        }

        public void Fire(TTrigger trigger, ITransitionalData data)
        {
            UpdateTarget(trigger);
            _currentState.SetData(data);
            _currentState.Execute();
        }

        private void UpdateTarget(TTrigger trigger)
        {
            Transition<TTrigger, TState> target
                = _transitions.First(transition => transition.GetState().Equals(_currentState) &&
                transition.GetTrigger().Equals(trigger));

            _currentState = target.GetTarget();
        }
    }
}