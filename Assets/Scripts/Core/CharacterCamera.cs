using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CharacterCamera : MonoBehaviour
{
    [SerializeField] [Range(0, 1000f)] private float _zDistance;

    private Transform _follow;
    private Camera _camera;

    private void Awake() => _camera = GetComponent<Camera>();

    private void FixedUpdate() => _camera.transform.position = new Vector3(_follow.position.x, transform.position.y, -_zDistance);

    public void Initialize(Transform follow) => _follow = follow;
}
