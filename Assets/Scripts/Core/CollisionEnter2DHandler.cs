using UnityEngine;
using UnityEngine.Events;

public class CollisionEnter2DHandler : MonoBehaviour
{
    public UnityEvent collisionEnter = new UnityEvent();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionEnter?.Invoke();
    }
}
