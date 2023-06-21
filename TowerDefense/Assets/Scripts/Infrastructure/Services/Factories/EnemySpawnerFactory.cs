using Components.EnemySpawn;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.World;
using Leopotam.Ecs;
using UnityComponents.Configurations;
using UnityComponents.Configurations.Enemy;
using UnityComponents.Configurations.Level;
using UnityEngine;

namespace Infrastructure.Services.Factories
{
    internal class EnemySpawnerFactory : IEnemySpawnerFactory
    {
        private readonly IWorldService _worldService;
        private IAssetProvider _assetProvider;
        private readonly IStaticData _staticData;

        public EnemySpawnerFactory(IWorldService worldService, IStaticData staticData)
        {
            _worldService = worldService;
            _staticData = staticData;
        }

        public void CreateSpawners(string sceneKey)
        {
            LevelConfiguration levelData = _staticData.GetLevelData(sceneKey);

            foreach (SpawnerConfiguration spawnerData in levelData.enemySpawnerData)
            {
                EcsEntity entity = _worldService.World.NewEntity();

                ref var wave = ref entity.Get<Wave>();
                ref var enemySpawn = ref entity.Get<EnemySpawn>();
                wave.AmountEnemies = spawnerData.waveData[0].amountEnemies;
                wave.EnemiesTypeId = spawnerData.waveData[0].spawnData.enemiesTypeId;
                wave.Position = spawnerData.position;
                entity.Get<SpawnRequest>();
            }
        }
    }
}