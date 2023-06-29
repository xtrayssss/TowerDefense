using Systems.Move;
using Infrastructure.Services.Factories;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class TowerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject FooPrefab;

        public override void InstallBindings()
        {
            Container.Bind<IBar>().To<Bar>().AsSingle();
            Container.BindMemoryPool<Foo, Foo.Pool>()
                .WithInitialSize(5)
                .FromComponentInNewPrefab(FooPrefab)
                .UnderTransformGroup("Foos");

            BindTowerFactory();
        }

        private void BindTowerFactory() =>
            Container.Bind<ITowerFactory>().To<TowerFactory>().AsSingle();
    }
}