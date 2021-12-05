using UnityEngine;

[CreateAssetMenu(menuName = "Level Dufficult")]
public class LevelDifficult : ScriptableObject
{
    [Tooltip("Base character speed. Increase over time")]
    [SerializeField] [Range(0.1f, 10f)] private float _characterSpeed = 2f;
    [SerializeField] [Range(1.01f, 10f)] private float _characterAcceleration = 1.01f;
    [Tooltip("Frequency in seconds")]
    [SerializeField] [Range(0.1f, 100f)] private float _characterAccelerationFrequency = 10;

    [Tooltip("How often to build barricade walls")]
    [SerializeField] [Range(1f, 100f)] private float _wallSpawnFrequency = 10f;

    public float CharacterSpeed => _characterSpeed;
    public float CharacterAcceleration => _characterAcceleration;
    public float CharacterAccelerationFrequency => _characterAccelerationFrequency;
    public float WallSpawnFrequency => _wallSpawnFrequency;
}
