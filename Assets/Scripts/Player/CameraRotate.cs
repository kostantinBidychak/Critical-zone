using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector2 _vector2;
   [SerializeField] private float _sensity;

    private InputSystem_Actions _actions;

    private float _xRotation = 0;
    
    private void Awake()
    {
        _actions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _actions.Enable();
        _actions.Player.Look.performed += ctx => _vector2 = ctx.ReadValue<Vector2>();
        _actions.Player.Look.canceled += ctx => _vector2 = Vector2.zero;
    }

    private void OnDisable()
    {
        _actions.Disable();
    }

    private void Update()
    {
        float xMouse = _vector2.x * _sensity * Time.deltaTime;
        float yMouse = _vector2.y * _sensity * Time.deltaTime;

        _xRotation -= yMouse;

        _xRotation = Mathf.Clamp(_xRotation,-90f, 90f);
        transform.localRotation = Quaternion.Euler(_xRotation,0,0);
        _player.Rotate(Vector3.up * xMouse);
        
    }
}
