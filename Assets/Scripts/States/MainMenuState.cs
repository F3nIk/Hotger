
using F3Lib.Patterns.State;

using UnityEngine;

public class MainMenuState : StateBase
{
    [SerializeField] private MenuUI _menuUIPrefab;
    private MenuUI _menuUI;

    public override void Execute()
    {
        _menuUI = Instantiate(_menuUIPrefab);
        _menuUI.StartButton.onClick.AddListener(StartButtonClick);
    }

    public override void SetData(ITransitionalData data) => throw new System.NotImplementedException();

    public void StartButtonClick()
    {
        _menuUI.StartButton.onClick.AddListener(StartButtonClick);
        Destroy(_menuUI.gameObject);
        StateMachine.Fire(StateChangeTrigger.StartGame, _menuUI.DifficultSelector);
    }

}
