using System.Collections;

using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TimerLabel _timerLabel;
    private GameTimeData _data;

    public GameTimeData Data => _data;

    private void Awake() => _data = new GameTimeData();

    public void Play() => StartCoroutine(CalculateTime());

    public void Stop() => StopCoroutine(CalculateTime());

    private IEnumerator CalculateTime()
    {
        while (gameObject.activeInHierarchy)
        {
            _data.Time += Time.deltaTime;
            _timerLabel.SetTime(_data.Time);
            yield return null;
        }
    }
}
