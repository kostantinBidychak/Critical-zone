using UnityEngine;
using Zenject;

public class ShopInstaller : MonoInstaller
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private ShopUI _shopUI;
    public override void InstallBindings()
    {
        Container.Bind<ShopUI>().FromInstance(_shopUI).AsSingle();
        Container.Bind<Wallet>().FromInstance(_wallet).AsSingle();
    }
}