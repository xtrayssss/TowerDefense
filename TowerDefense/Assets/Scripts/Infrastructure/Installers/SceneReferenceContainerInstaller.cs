using Infrastructure.Services.Factories;
using UnityComponents.Containers;
using UnityComponents.Views;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    internal class SceneReferenceContainerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerView playerView;
        [SerializeField] private SceneReferenceContainer sceneReferenceContainer;

        public override void InstallBindings()
        {
            Container.Bind<SceneReferenceContainer>().FromInstance(sceneReferenceContainer).AsSingle();
            Container.Bind<IInitializable>().FromInstance(sceneReferenceContainer).AsSingle();
            BindPlayer();
            BindMushroomFactory();
            BindPyramidFactory();
            BindEnemyFactory();
            BindEnemySpawnerFactory();
        }

        private void BindPyramidFactory() =>
            Container.BindFactory<PyramidFactory, PyramidFactory.Factory>();

        private void BindEnemySpawnerFactory() =>
            Container.Bind<IEnemySpawnerFactory>().To<EnemySpawnerFactory>()
                .AsSingle();

        private void BindMushroomFactory() =>
            Container.BindFactory<MushroomFactory, MushroomFactory.Factory>();

        private void BindEnemyFactory() =>
            Container.Bind<IEnemyFactoryService>().To<EnemyFactory>()
                .AsSingle();

        private void BindPlayer()
        {
            PlayerView bindPlayerView = InstantiateBindPlayerView();
            BindPlayerFactory(bindPlayerView);
        }

        private void BindPlayerFactory(PlayerView view) =>
            Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle().WithArguments(view);

        private PlayerView InstantiateBindPlayerView()
        {
            PlayerView view = Container.InstantiatePrefabForComponent<PlayerView>(playerView);
            Container.Bind<PlayerView>().FromInstance(view);
            return view;
        }
    }
}