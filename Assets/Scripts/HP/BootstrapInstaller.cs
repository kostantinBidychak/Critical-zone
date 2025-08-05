using UnityEngine;
using Zenject;

public class BootstrapHealthInstaller : MonoInstaller
{
    [SerializeField] private HealthUI[] _healthUI;  
    [SerializeField] private Health _health;  
    public override void InstallBindings()
    {
        Container.Bind<HealthUI>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Health>().FromComponentInHierarchy().AsSingle();
    }
}