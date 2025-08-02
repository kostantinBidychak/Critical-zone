using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private float _speed;

    private void Update()
    {
        Vector3 forward = _player.forward;
        forward.y = 0;

        if (forward.sqrMagnitude > 0.001)
        {
            Quaternion quaternion = Quaternion.LookRotation(forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, _speed * Time.deltaTime);
        }
    }
}
