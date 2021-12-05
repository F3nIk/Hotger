
using UnityEngine;
using UnityEngine.Profiling;

public class PooledMonoBehaviour : MonoBehaviour
{
    public MonoBehaviourPool OwnPool { get; set; }

    public void ReturnToPool()
    {
        Profiler.BeginSample("ReturnToPool");
        OwnPool.Return(this);
        Profiler.EndSample();
    }
}
