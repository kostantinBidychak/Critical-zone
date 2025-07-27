using UnityEngine;
using Zenject;

public class GunInstaller : MonoInstaller
{
    [SerializeField] private GunModel _gunModel;
    [SerializeField] private GunView _gunView;

    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Transform _transform;
    public override void InstallBindings()
    {
        Container.Bind<GunModel>().FromInstance(_gunModel).AsSingle();
        Container.Bind<GunView>().FromInstance(_gunView).AsSingle();

        Container.BindIFactory<Bullet, Bullet.Factory>().FromComponentInNewPrefab(_gameObject).UnderTransform(_transform);
    }
}