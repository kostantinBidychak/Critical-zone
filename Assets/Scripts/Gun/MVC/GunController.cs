using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class GunController : MonoBehaviour
{
    private Bullet.Factory _factory;

    private float _timeShoot;

    private GunView _gunView;
    private GunModel _gunModel;
    private void Start() => _gunModel.AmmoNumber = _gunModel.MaxAmmo;
    [Inject]
    private void Constructor(GunModel model, GunView gunView,Bullet.Factory factory)
    {
        _factory = factory;
        _gunModel = model;
        _gunView = gunView;
    }

    private void Update()
    {
        _timeShoot += Time.deltaTime;
        if (Mouse.current.leftButton.isPressed && _gunModel.TimeOfRecherge <= _timeShoot)
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
        if (_gunModel.AmmoNumber >= 0)
        {
            _factory.Create();
           _gunView.BulletText( _gunModel.AmmoNumber);
            _gunModel.AmmoNumber--;
        }
    }

    private void Reload()
    {
        if (_gunModel.ReloadBullets >= 0)
        {
            int differemce = _gunModel.MaxAmmo - _gunModel.AmmoNumber;
            _gunModel.AmmoNumber += differemce;
            _gunModel.ReloadBullets -= differemce;
        }
    }
}