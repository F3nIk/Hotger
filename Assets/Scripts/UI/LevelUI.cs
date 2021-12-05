using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private InteractableElement _movementButton;
    [SerializeField] private Timer _timer;

    public InteractableElement MovementButton => _movementButton;
    public Timer Timer => _timer;

}
