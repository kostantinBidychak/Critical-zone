using UnityEngine;
using UnityEngine.InputSystem;

public class Go : MonoBehaviour
{
  private InputSystem_Actions _action;
  private Vector2 _vector2;

  [SerializeField] private float _speed;

    private void Awake()
    {
        _action = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _action.Enable();
        _action.Player.Move.performed += ReadMove;
        _action.Player.Move.canceled += ReadMove;
    }
    private void OnDisable()
    {       
        _action.Player.Move.performed -= ReadMove;
        _action.Player.Move.canceled -= ReadMove;
        _action.Disable();
    }

    private void ReadMove(InputAction.CallbackContext callbackContext) => _vector2 = callbackContext.ReadValue<Vector2>();

    private void Update()
    {
        Vector3 vector3 = new Vector3(_vector2.x, 0, _vector2.y);
        transform.Translate(vector3 * _speed*Time.deltaTime);
    }
}
