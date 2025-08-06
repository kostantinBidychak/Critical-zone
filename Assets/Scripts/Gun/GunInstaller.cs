using UnityEngine;
using Zenject;

public class GunInstaller : MonoInstaller
{
    [SerializeField] private GunModel _gunModelScript;
    [SerializeField] private GunViewScript _gunView;

    [SerializeField] private GameObject _gameObject;
 
    public override void InstallBindings()
    {
        Container.Bind<GunModel>().FromInstance(_gunModelScript).AsSingle();
        Container.Bind<GunViewScript>().FromInstance(_gunView).AsSingle();

        Container.BindFactory<Bullet, Bullet.Factory>().FromComponentInNewPrefab(_gameObject);
    }
}