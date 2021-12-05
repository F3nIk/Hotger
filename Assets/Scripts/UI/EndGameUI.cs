using System;

using UnityEngine;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private Text _currentTime;
    [SerializeField] private Text _playCount;

    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _changeDifficultButton;

    public Button Restart => _restartButton;
    public Button ChangeDifficult => _changeDifficultButton;

    public void SetCurrentTime(float time)
    {
        DateTime dt = new DateTime().AddSeconds(time);
        _currentTime.text = dt.ToLongTimeString();

    }

    public void SetPlayCount(int count) => _playCount.text = count.ToString();

}
