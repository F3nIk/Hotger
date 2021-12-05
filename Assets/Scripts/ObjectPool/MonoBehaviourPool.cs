using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class MonoBehaviourPool
{
    private readonly Queue<PooledMonoBehaviour> _pool;

    public UnityEvent itemTaken = new UnityEvent();
    public UnityEvent itemReturned = new UnityEvent();

    public MonoBehaviourPool(PooledMonoBehaviour reference, Transform parent, int capacity)
    {
        Capacity = capacity;
        _pool = new Queue<PooledMonoBehaviour>(Capacity);

        for (int i = 0; i < capacity; i++)
        {
            PooledMonoBehaviour newObj = GameObject.Instantiate(reference, parent);
            newObj.OwnPool = this;
            newObj.gameObject.SetActive(false);

            _pool.Enqueue(newObj);
        }
    }

    public int Capacity { get; }
    public int Count => _pool.Count;

    public PooledMonoBehaviour Take()
    {
        if (_pool.Count <= 0) throw new IndexOutOfRangeException();

        itemTaken?.Invoke();

        return _pool.Dequeue();
    }

    public PooledMonoBehaviour TakeActivated()
    {
        if (_pool.Count <= 0) throw new IndexOutOfRangeException();

        itemTaken?.Invoke();
        PooledMonoBehaviour pooled = _pool.Dequeue();
        pooled.gameObject.SetActive(true);
        return pooled;
    }

    public void Return(PooledMonoBehaviour item)
    {
        if (item.OwnPool != this) throw new InvalidOperationException();
        if (item.gameObject == null) return;
        item.gameObject.SetActive(false);
        _pool.Enqueue(item);

        itemReturned?.Invoke();
    }

    public void Destroy()
    {
        foreach (PooledMonoBehaviour item in _pool)
        {
            UnityEngine.Object.Destroy(item);
        }
    }
}
