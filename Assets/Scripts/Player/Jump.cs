using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5;
    private Rigidbody _rigidbody;
    private bool _isJumping;

    private InputSystem_Actions _action;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _action = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _action.Enable();
        _action.Player.Jump.performed += JumpAction;
    }
    private void OnDisable()
    {
        _action.Player.Jump.performed -= JumpAction;
        _action.Disable();
    }

    private void JumpAction(InputAction.CallbackContext callbackContext)
    {
        if (_isJumping)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
        _isJumping = false;
    }

    private void OnCollisionEnter() => _isJumping = true;
}