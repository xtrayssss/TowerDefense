using Infrastructure.GameState;
using Infrastructure.Load;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.Coroutines;
using Infrastructure.Services.Factories;
using Infrastructure.Services.Random;
using Infrastructure.Services.Spawn;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.World;
using UnityComponents.Views;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner coroutineRunner;
        [SerializeField] private PlayerView playerView;

        public override void InstallBindings()
        {
            BindWorldService();
            BindCoroutineRunner();
            BindAssetProvider();
            BindSceneLoader();
            BindRandomService();
            BindStaticDataService();
            BindSpawnService();
            BindMushroomFactory();
            BindPyramidFactory();
            BindEnemyFactory();
            PlayerView bindPlayerView = InstantiateBindPlayerView();
            BindPlayerFactory(bindPlayerView);
            BindEnemySpawnerFactory();
            BindGameStateMachine();
        }

        private void BindPlayerFactory(PlayerView view) =>
            Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle().WithArguments(view);

        private PlayerView InstantiateBindPlayerView()
        {
            PlayerView view = Container.InstantiatePrefabForComponent<PlayerView>(this.playerView);
            Container.Bind<PlayerView>().FromInstance(view);
            return view;
        }

        private void BindPyramidFactory() =>
            Container.BindFactory<PyramidFactory, PyramidFactory.Factory>();

        private void BindWorldService() =>
            Container.Bind<IWorldService>().To<WorldService>().AsSingle().NonLazy();

        private void BindEnemySpawnerFactory() =>
            Container.Bind<IEnemySpawnerFactory>().To<EnemySpawnerFactory>()
                .AsSingle();

        private void BindSpawnService() =>
            Container.Bind<ISpawnService>().To<SpawnService>()
                .AsSingle();

        private void BindAssetProvider() =>
            Container.Bind<IAssetProvider>().To<AssetProvider>()
                .AsSingle();

        private void BindMushroomFactory() =>
            Container.BindFactory<MushroomFactory, MushroomFactory.Factory>();

        private void BindStaticDataService() =>
            Container.Bind<IStaticData>().To<StaticData>()
                .AsSingle();

        private void BindRandomService() =>
            Container.Bind<IRandomService>().To<RandomService>()
                .AsSingle();

        private void BindEnemyFactory() =>
            Container.Bind<IEnemyFactoryService>().To<EnemyFactory>()
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