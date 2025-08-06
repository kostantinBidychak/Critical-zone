using Zenject;

public class BootstrapHealthInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<HealthUI>().FromComponentInHierarchy().AsSingle();
    }
}