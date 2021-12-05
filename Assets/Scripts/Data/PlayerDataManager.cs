using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;

    private void Awake() => _playerStats.Load();

    private void OnApplicationQuit() => _playerStats.Save();
}
