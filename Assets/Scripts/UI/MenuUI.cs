using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private DifficultSelector _difficultSelector;
    
    public Button StartButton => _startButton;
    public DifficultSelector DifficultSelector => _difficultSelector;
}
