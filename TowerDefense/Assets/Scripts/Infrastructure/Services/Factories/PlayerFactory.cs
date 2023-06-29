using Systems.Build;
using Components.Build;
using Components.Camera;
using Components.Forms;
using Components.Grid;
using Components.Health;
using Components.Mouse;
using Infrastructure.Services.StaticData;
using Leopotam.Ecs;
using UnityComponents.Configurations;
using UnityComponents.Containers;
using UnityComponents.Containers.Data;
using UnityComponents.Views;
using UnityComponents.Windows;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Infrastructure.Services.Factories
{
    internal class PlayerFactory : IPlayerFactory
    {
        private readonly PlayerView _playerView;
        private readonly SceneReferenceContainer _sceneReferenceContainer;
        private readonly IWindowFactory _windowFactory;

        public PlayerFactory(PlayerView playerView, SceneReferenceContainer sceneReferenceContainer,
            IWindowFactory windowFactory)
        {
            _playerView = playerView;
            _sceneReferenceContainer = sceneReferenceContainer;
            _windowFactory = windowFactory;
        }

        public void CreatePlayer(EcsWorld world, IStaticData staticData)
        {
            EcsEntity entity = world.NewEntity();

            entity.Get<Cell>();
            entity.Get<Mouse>();

            Tilemap buildingPlaceTilemap = GetBuildingPlaceTilemap();
            Tilemap buildTilemap = GetBuildTilemap();

            PlayerConfiguration playerConfiguration = staticData.GetPlayerData();

            _playerView.Construct(entity);

            ref var health = ref entity.Get<Health>();
            health.CurrentHealth = playerConfiguration.Health;
            health.MaxHealth = playerConfiguration.Health;

            ref var tilemapComponent = ref entity.Get<TilemapComponent>();
            tilemapComponent.Tilemap = buildingPlaceTilemap;

            ref var cameraComponent = ref entity.Get<CameraComponent>();
            cameraComponent.Camera = Camera.main;

            ref var buildComponent = ref entity.Get<BuildComponent>();
            buildComponent.BuildingPlaceTilemap = buildingPlaceTilemap;
            buildComponent.BuildingTilemap = buildTilemap;

            ref var formComponent = ref entity.Get<FormComponent<BuildWindow>>();
            formComponent.Form =
                (BuildWindow) _windowFactory.CreateWindow<BuildWindowConfiguration>(FormTypeId.BuildWindow);
            formComponent.Form.Close();

            ref var diamante = ref entity.Get<Diamante>();
            diamante.Value = playerConfiguration.StartAmountDiamante;
        }

        private Tilemap GetBuildTilemap() =>
            _sceneReferenceContainer.GetSubContainer<TilemapContainer>()
                .GetTilemap(TilemapTypeId.Build);

        private Tilemap GetBuildingPlaceTilemap() =>
            _sceneReferenceContainer.GetSubContainer<TilemapContainer>()
                .GetTilemap(TilemapTypeId.BuildingPlace);
    }

    internal struct Diamante
    {
        public int Value;
    }
}