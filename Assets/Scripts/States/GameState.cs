using F3Lib.Patterns.State;

using System.Collections;

using UnityEngine;

public class GameState : StateBase
{
    [SerializeField] private CharacterMovement _characterPrefab;
    [SerializeField] private CharacterCamera _characterCameraPrefab;
    [SerializeField] private WallBuilder _wallBuilderPrefab;
    [SerializeField] private LevelUI _levelUIPrefab;
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] [Range(0, 60f)] private float _delayBeforeCharacterMove = 3;

    private CharacterMovement _characterMovement;
    private CharacterCamera _characterCamera;
    private WallBuilder _wallBuilder;
    private LevelUI _levelUI;
    private DifficultSelector _difficultSelector;

    public override void Execute() => StartCoroutine(DelayExecuting());

    public void OnCharacterCollision()
    {
        _levelUI.Timer.Stop();
        _characterMovement.StopMove();
        _wallBuilder.Stop();

        _characterMovement.CollisionHandler.collisionEnter.RemoveListener(OnCharacterCollision);

        Destroy(_levelUI.gameObject);
        Destroy(_characterCamera.gameObject);
        Destroy(_characterMovement.gameObject);
        Destroy(_wallBuilder.gameObject);

        StateMachine.Fire(StateChangeTrigger.EndGame, _levelUI.Timer.Data);
    }

    public override void SetData(ITransitionalData data) => _difficultSelector = (DifficultSelector)data;

    private IEnumerator DelayExecuting()
    {
        _characterMovement = Instantiate(_characterPrefab);
        _characterCamera = Instantiate(_characterCameraPrefab);
        _wallBuilder = Instantiate(_wallBuilderPrefab);
        _levelUI = Instantiate(_levelUIPrefab);

        LevelDifficult currentDifficult = _difficultSelector.Selected;

        _characterMovement.Initialize(currentDifficult.CharacterSpeed, currentDifficult.CharacterAcceleration, currentDifficult.CharacterAccelerationFrequency);
        _characterCamera.Initialize(_characterMovement.transform);
        _wallBuilder.Initialize(_difficultSelector.Selected.CharacterSpeed, _difficultSelector.Selected.WallSpawnFrequency);

        _levelUI.MovementButton.pointerDown.AddListener(_characterMovement.InputButtonDown);
        _levelUI.MovementButton.pointerClick.AddListener(_characterMovement.InputButtonUp);
        _levelUI.Timer.Play();

        yield return new WaitForSeconds(_delayBeforeCharacterMove);

        _playerStats.playCount++;

        _characterMovement.StartMove();
        _characterMovement.CollisionHandler.collisionEnter.AddListener(OnCharacterCollision);


    }
}
