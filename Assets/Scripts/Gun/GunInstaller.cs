using UnityEngine;
using Zenject;

public class GunInstaller : MonoInstaller
{
    [SerializeField] private GunModelScript _gunModelScript;
    [SerializeField] private GunView _gunView;

    [SerializeField] private GameObject _gameObject;
   // [SerializeField] private Transform _transform;
    public override void InstallBindings()
    {
        Container.Bind<GunModelScript>().FromInstance(_gunModelScript).AsSingle().NonLazy();
        Container.Bind<GunView>().FromInstance(_gunView).AsSingle();

        Container.BindFactory<Bullet, Bullet.Factory>().FromComponentInNewPrefab(_gameObject);
    }
}