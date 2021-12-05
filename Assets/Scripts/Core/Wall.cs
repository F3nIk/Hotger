using UnityEngine;
using UnityEngine.Profiling;

public class Wall : PooledMonoBehaviour
{
    private void OnBecameInvisible()
    {
        if(gameObject.activeInHierarchy) ReturnToPool();
    }
}
