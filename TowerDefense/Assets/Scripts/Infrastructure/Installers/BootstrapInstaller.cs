using Infrastructure.GameState;
using Infrastructure.Load;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.Coroutines;
using Infrastructure.Services.Factories;
using Infrastructure.Services.Random;
using Infrastructure.Services.Spawn;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.World;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner coroutineRunner;

        public override void InstallBindings()
        {
            BindWorldService();
            BindCoroutineRunner();
            BindAssetProvider();
            BindSceneLoader();
            BindRandomService();
            BindStaticDataService();
            BindSpawnService();
            BindGameStateMachine();
        }

        private void BindWorldService() =>
            Container.Bind<IWorldService>().To<WorldService>().AsSingle();
        
        private void BindSpawnService() =>
            Container.Bind<ISpawnService>().To<SpawnService>()
                .AsSingle();

        private void BindAssetProvider() =>
            Container.Bind<IAssetProvider>().To<AssetProvider>()
                .AsSingle();

        private void BindStaticDataService() =>
            Container.Bind<IStaticData>().To<StaticData>()
                .AsSingle();

        private void BindRandomService() =>
            Container.Bind<IRandomService>().To<RandomService>()
                .AsSingle();

        private void BindCoroutineRunner() =>
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromComponentInNewPrefab(coroutineRunner)
                .AsSingle();

        private void BindSceneLoader() =>
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();

        private void BindGameStateMachine() =>
            Container
                .Bind<IGameStateMachine>()
                .FromSubContainerResolve()
                .ByInstaller<GameStateMachineInstaller>()
                .AsSingle();
    }
}