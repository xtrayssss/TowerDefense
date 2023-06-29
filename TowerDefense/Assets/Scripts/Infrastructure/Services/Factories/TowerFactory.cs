using Components.Model;
using Components.Tags;
using Infrastructure.Installers;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.World;
using Leopotam.Ecs;
using Unity.Mathematics;
using UnityComponents.Configurations;
using UnityComponents.Towers;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.Factories
{
    internal class TowerFactory : ITowerFactory
    {
        private readonly DiContainer _diContainer;
        private readonly IStaticData _staticData;
        private readonly PrefabContainer _prefabContainer;
        private readonly IWorldService _worldService;

        public TowerFactory(DiContainer diContainer, IStaticData staticData, PrefabContainer prefabContainer,
            IWorldService worldService)
        {
            _diContainer = diContainer;
            _staticData = staticData;
            _prefabContainer = prefabContainer;
            _worldService = worldService;
        }

        public void CreateTower(TowerTypeId towerTypeId, Vector3 spawnPosition)
        {
            TowerConfiguration towerConfiguration = _staticData.GetTowerData(towerTypeId);

            switch (towerTypeId)
            {
                case TowerTypeId.Archer:
                    CreateArcherTower(towerConfiguration, spawnPosition);
                    break;
                case TowerTypeId.Wizard:
                    CreateWizardTower(towerConfiguration, spawnPosition);
                    break;
                case TowerTypeId.Barrack:
                    CreateBarrackTower(towerConfiguration, spawnPosition);
                    break;
            }
        }

        private void CreateArcherTower(TowerConfiguration towerConfiguration, Vector3 spawnPosition) =>
            CreateBaseTower(towerConfiguration, spawnPosition, out EcsEntity entity);

        private void CreateBarrackTower(TowerConfiguration towerConfiguration, Vector3 spawnPosition) =>
            CreateBaseTower(towerConfiguration, spawnPosition, out EcsEntity entity);


        private void CreateWizardTower(TowerConfiguration towerConfiguration, Vector3 spawnPosition) =>
            CreateBaseTower(towerConfiguration, spawnPosition, out EcsEntity entity);

        private void CreateBaseTower(TowerConfiguration towerConfiguration, Vector3 spawnPosition, out EcsEntity entity)
        {
            entity = _worldService.World.NewEntity();

            GameObject towerGO = _diContainer.InstantiatePrefab(towerConfiguration.Prefab, spawnPosition,
                quaternion.identity,
                _prefabContainer.transform);

            entity.Get<Model>().ModelGO = towerGO;
            entity.Get<TowerTag>();
            entity.Get<CalculateDistanceProgress>();
            towerGO.GetComponent<TowerView>().Init(entity);
            entity.Get<QueueEnemies>().Initialize();
        }
    }
}