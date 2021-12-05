using System.Collections;

using UnityEngine;

public class WallBuilder : MonoBehaviour
{
    [SerializeField] private Transform _upperWallParent;
    [SerializeField] private Transform _bottomWallParent;
    [SerializeField] private PooledMonoBehaviour _wallPrefab = null;

    [SerializeField] [Range(1, 512)] private int _wallPoolCapacity;
    [SerializeField] [Range(1, 512)] private int _barricadesPoolCapacity;
    [SerializeField] [Range(1, 1024)] private int _cellSize;

    private MonoBehaviourPool _upperWallPool;
    private MonoBehaviourPool _bottomWallPool;
    private MonoBehaviourPool _barricadesPool;

    private MonoBehaviourPool _wallPool;

    private float _characterSpeed = 0;
    private float _barricadeFrequency = 0;
    private float _barricadeTimeRemaining = 0;
    private float _nextWallPosition = 0;


    private void OnDisable() => DestroyWallPool();

    public void Initialize(float characterSpeed, float barricadeFrequency)
    {
        _characterSpeed = characterSpeed;
        _barricadeFrequency = barricadeFrequency;
        _barricadeTimeRemaining = _barricadeFrequency;
        InitializeWallPool();
    }

    public void Stop() => StopAllCoroutines();

    public void InitializeWallPool()
    {
        _wallPool = new MonoBehaviourPool(_wallPrefab, transform, _wallPoolCapacity);

        _upperWallPool = new MonoBehaviourPool(_wallPrefab, _upperWallParent, _wallPoolCapacity / 2);

        _bottomWallPool = new MonoBehaviourPool(_wallPrefab, _bottomWallParent, _wallPoolCapacity / 2);

        _barricadesPool = new MonoBehaviourPool(_wallPrefab, transform, _barricadesPoolCapacity);
        InitializeBuild();
    }

    public void DestroyWallPool() => _upperWallPool.Destroy();

    private void InitializeBuild()
    {
        StartCoroutine(BuildingWalls());
        StartCoroutine(BuildingBarricades());
    }

    private IEnumerator BuildingWalls()
    {
        float step = (1f / _characterSpeed) * Time.fixedDeltaTime;

        for (int i = 0; i < _wallPoolCapacity / 2; i++)
        {
            yield return new WaitForSeconds(step);

            BuildWall(step);
        }

        while (gameObject.activeInHierarchy)
        {
            yield return new WaitUntil(() => _wallPool.Count >= 2);

            BuildWall(step);
        }
    }

    private IEnumerator BuildingBarricades()
    {
        while (gameObject.activeInHierarchy)
        {
            _barricadeTimeRemaining -= Time.fixedDeltaTime;

            if (_barricadeTimeRemaining <= 0)
            {
                BuildBarricade();
                _barricadeTimeRemaining = _barricadeFrequency;
            }

            yield return new WaitForFixedUpdate();
        }
    }

    private void BuildWall()
    {
        PooledMonoBehaviour upperwall = _wallPool.TakeActivated();
        PooledMonoBehaviour bottomWall = _wallPool.TakeActivated();

        upperwall.transform.position = new Vector3(_nextWallPosition, _upperWallParent.position.y, transform.position.z);
        bottomWall.transform.position = new Vector3(_nextWallPosition, _bottomWallParent.position.y, transform.position.z);
    }

    private void BuildBarricade()
    {
        PooledMonoBehaviour barricade = _barricadesPool.TakeActivated();

        float randomY = Random.Range(_upperWallParent.position.y - 1, _bottomWallParent.position.y + 1);

        barricade.transform.position = new Vector3(_nextWallPosition, randomY, transform.position.z);
    }

    private void BuildWall(float step)
    {
        _nextWallPosition++;
        BuildWall();
    }
}
