using F3Lib.Patterns.State;

using UnityEngine;

public enum StateChangeTrigger { Return, StartGame, EndGame }

public class StateController : MonoBehaviour
{
    [SerializeField] private MainMenuState _mainMenuState;
    [SerializeField] private GameState _gameState;
    [SerializeField] private EndGameState _endGameState;

    private StateMachine<StateChangeTrigger, StateBase> _stateMachine;



    private void Awake()
    {
        _stateMachine = new StateMachine<StateChangeTrigger, StateBase>(_mainMenuState);
        _stateMachine.Configure(_mainMenuState).Bind(StateChangeTrigger.StartGame, _gameState);
        _stateMachine.Configure(_gameState).Bind(StateChangeTrigger.EndGame, _endGameState);
        _stateMachine.Configure(_endGameState).Bind(StateChangeTrigger.Return, _mainMenuState);
        _stateMachine.Configure(_endGameState).Bind(StateChangeTrigger.StartGame, _gameState);
    }
}
