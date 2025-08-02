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

    private void Start()
    {
        _gunModelScript.AmmoNumber = _gunModelScript.MaxAmmo;
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
            _gunView.BulletText(_gunModelScript.AmmoNumber);
        }
    }
}