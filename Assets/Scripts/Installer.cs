using Assets.Plugins.SimpleStore;
using Assets.Scripts.Models;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
    public class Installer : MonoInstaller<Installer>
    {
        public override void InstallBindings()
        {
            Container.Bind<IStoreItemGenerator>().To<ArmorGenerator>().AsSingle();
            Container.Bind<IStoreItemGenerator>().To<WeaponGenerator>().AsSingle();
            Container.Bind<IStoreService>().To<StoreService>().AsSingle();
            Container.BindInstance(new System.Random());
        }
    }
}