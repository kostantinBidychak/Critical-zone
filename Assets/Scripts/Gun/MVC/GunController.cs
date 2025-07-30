using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class GunController : MonoBehaviour
{
    private Bullet.Factory _factory;
    [SerializeField] private Transform _transform;

    private float _timeShoot;

    private GunView _gunView;
    private GunModelScript _gunModelScript;

    [Inject]
    private void Constructor(GunModelScript model, GunView gunView,Bullet.Factory factory)
    {
        _factory = factory;
        _gunModelScript = model;
        _gunView = gunView;
    }

    private void Start() => _gunModelScript.AmmoNumber = _gunModelScript.MaxAmmo;

    private void Update()
    {
        _timeShoot += Time.deltaTime;
        if (Mouse.current.leftButton.isPressed && _gunModelScript.TimeOfRecherge <= _timeShoot)
        {
            Shoot();
        }
        if (Keyboard.current.rKey.isPressed)
        {
            Reload();
        }
    }

    private void Shoot()
    {
        if (_gunModelScript.AmmoNumber > 0)
        {
         var Bullet = _factory.Create();
            Bullet.transform.position =_transform.position;

            _gunView.BulletText(_gunModelScript.AmmoNumber);
            _gunModelScript.AmmoNumber--;
            _timeShoot = 0f;
        }
    }

    private void Reload()
    {
        if (_gunModelScript.ReloadBullets > 0)
        {
            int differemce = _gunModelScript.MaxAmmo - _gunModelScript.AmmoNumber;
            _gunModelScript.AmmoNumber += differemce;
            _gunModelScript.ReloadBullets -= differemce;
        }
    }
}