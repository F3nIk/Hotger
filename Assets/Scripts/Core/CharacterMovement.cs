using System.Collections;

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CollisionEnter2DHandler))]
public class CharacterMovement : MonoBehaviour
{
    private float _speed = 0;
    private float _acceleration = 0;
    private float _accelerationFrequency = 0;
    private Vector3 _velocity = Vector3.zero;
    private Rigidbody2D _rigidbody = null;
    private bool _isMove = false;

    private Vector2 _baseVelocity = Vector2.right + Vector2.down;

    public CollisionEnter2DHandler CollisionHandler { get; private set; } = null;

    private void FixedUpdate()
    {
        if(_isMove) _rigidbody.MovePosition(transform.position + _velocity * _speed * Time.fixedDeltaTime);
    }

    public void Initialize(float speed, float acceleration, float accelerationFrequency)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        CollisionHandler = GetComponent<CollisionEnter2DHandler>();

        _speed = speed;
        _acceleration = acceleration;
        _accelerationFrequency = accelerationFrequency;
        _velocity = _baseVelocity;
    }

    public void StartMove()
    {
        _isMove = true;
        StartCoroutine(Acceleration());
    }

    public void StopMove()
    {
        _isMove = false;
        StopCoroutine(Acceleration());
    }

    public void InputButtonDown()
    {
        // _velocity = Vector3.right + Vector3.up;
        _velocity = _baseVelocity + Vector2.up * 2;
    }

    public void InputButtonUp()
    {
        //_velocity = Vector3.right + Vector3.down;
        _velocity = _baseVelocity;
    }

    private IEnumerator Acceleration()
    {
        while (gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(_accelerationFrequency);
            _speed = _speed * _acceleration;
        }
    }
}
