using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class GunController : MonoBehaviour
{
    private Bullet.Factory _factory;
    [SerializeField] private Transform _transform;

    private float _timeShoot;

    private GunView _gunView;
    private GunModel _gunModelScript;
    private Bullet _bullet;

    [Inject]
    private void Constructor(GunModel model, GunView gunView,Bullet.Factory factory)
    {
        _factory = factory;
        _gunModelScript = model;
        _gunView = gunView;
    }

    private void Start()
    {
        _gunModelScript.AmmoNumber = _gunModelScript.MaxAmmo;

        _gunView.ReloadAmmoText(_gunModelScript.ReloadBullets);
        _gunView.BulletText(_gunModelScript.AmmoNumber);
    }

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
        if (_gunModelScript.CanShoot)
        {
         var Bullet = _factory.Create();
            Bullet.transform.position =_transform.position;
            Bullet.transform.rotation = _transform.rotation;
            Bullet.Init(_gunModelScript.Damage);

            _gunModelScript.AmmoNumber--;
            _gunView.BulletText(_gunModelScript.AmmoNumber);
        
            _timeShoot = 0f;
        }
    }

    private void Reload()
    {
        if (_gunModelScript.ReloadBullets > 0)
        {
            _gunModelScript.Reload();
            _gunView.ReloadAmmoText(_gunModelScript.ReloadBullets);
        }
    }
}