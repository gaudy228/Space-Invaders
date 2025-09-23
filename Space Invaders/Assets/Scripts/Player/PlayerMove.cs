using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Control _control;
    private float _minX;
    private float _maxX;
    private void Awake()
    {
        _control = new Control();
        _maxX = Camera.main.orthographicSize * Camera.main.aspect - (transform.localScale.x / 2);
        _minX = -_maxX;
    }
    private void OnEnable()
    {
        _control.Enable();
    }
    private void OnDisable()
    {
        _control.Disable();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        Vector3 moveInput = _control.Main.PlayerMove.ReadValue<Vector2>().normalized;
        transform.position += moveInput * _speed * Time.deltaTime;
        Vector2 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, _minX, _maxX);
        transform.position = clampedPosition;
    }
}
