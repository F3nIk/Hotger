using F3Lib.Patterns.State;

using UnityEngine;

public class EndGameState : StateBase
{
    [SerializeField] private EndGameUI _endGameUIPrefab;
    [SerializeField] private PlayerStats _playerStats;

    private GameTimeData _gameTimeData;
    private EndGameUI _endGameUI;

    public override void Execute()
    {
        _endGameUI = Instantiate(_endGameUIPrefab);
        _endGameUI.Restart.onClick.AddListener(OnRestart);
        _endGameUI.ChangeDifficult.onClick.AddListener(OnChangeDifficult);

        _endGameUI.SetCurrentTime(_gameTimeData.Time);
        _endGameUI.SetPlayCount(_playerStats.playCount);
    }

    private void OnRestart()
    {
        SetDefaults();
        StateMachine.Fire(StateChangeTrigger.StartGame);
    }

    private void OnChangeDifficult()
    {
        SetDefaults();
        StateMachine.Fire(StateChangeTrigger.Return);
    }

    private void SetDefaults()
    {
        _endGameUI.Restart.onClick.RemoveListener(OnRestart);
        _endGameUI.ChangeDifficult.onClick.RemoveListener(OnChangeDifficult);
        Destroy(_endGameUI.gameObject);
    }

    public override void SetData(ITransitionalData data) => _gameTimeData = (GameTimeData)data;
}
