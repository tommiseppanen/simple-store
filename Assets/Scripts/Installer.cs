using Models;
using Plugins.SimpleStore;
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
            Container.Bind<GameCharacter>().AsSingle();
            Container.Bind<Store>().AsSingle();
            Container.BindInstance(new System.Random());
        }
    }
}