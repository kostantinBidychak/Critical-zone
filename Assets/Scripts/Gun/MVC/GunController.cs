using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class GunController : MonoBehaviour
{
    private Bullet.Factory _factory;
    [SerializeField] private Transform _BulletPoint;

    private float _timeShoot;

    private GunViewScript _gunView;
    private GunModel _gunModel;

   private AudioSource _audioSource;
    [Inject]
    private void Constructor(GunModel model, GunViewScript gunView,Bullet.Factory factory)
    {
        _factory = factory;
        _gunModel = model;
        _gunView = gunView;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _gunModel.Ammo = _gunModel.MaxAmmo;

        _gunView.ReloadAmmoText(_gunModel.ReloadAmmo);
        _gunView.BulletText(_gunModel.Ammo);
    }

    private void Update()
    {
        _timeShoot += Time.deltaTime;
        if (Mouse.current.leftButton.isPressed && _gunModel.TimeOfShoot <= _timeShoot)
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
        if (_gunModel.CanShoot)
        {
         var Bullet = _factory.Create();
            Bullet.transform.position =_BulletPoint.position;
            Bullet.transform.rotation = _BulletPoint.rotation;
            Bullet.Init(_gunModel.Damage);

            _gunModel.Ammo--;
            _gunView.BulletText(_gunModel.Ammo);
        
            _timeShoot = 0f;
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }

    private void Reload()
    {
        if (_gunModel.ReloadAmmo > 0)
        {
            _gunModel.Reload();
            _gunView.ReloadAmmoText(_gunModel.ReloadAmmo);
            _gunView.BulletText(_gunModel.Ammo);
        }
    }
}