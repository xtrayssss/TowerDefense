using System.Collections.Generic;
using Components.EnemySpawn;
using Components.Movement;
using Components.WayPoints;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.World;
using Leopotam.Ecs;
using UnityComponents.Configurations.Level;

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

            List<SpawnConfiguration> spawnConfigurations = levelData.spawnConfigurations;

            foreach (var spawnConfiguration in spawnConfigurations)
            {
                EcsEntity entity = _worldService.World.NewEntity();
                
                ref var wave = ref entity.Get<Wave>();
                wave.Waves = spawnConfiguration.waveConfigurations;
                wave.CurrentWave = wave.Waves[wave.IndexWave];

                ref var enemySpawn = ref entity.Get<EnemySpawn>();
                enemySpawn.SpawnPosition = spawnConfiguration.position;
                enemySpawn.SpawnCoolDown = spawnConfiguration.waveConfigurations[0].SpawnCoolDown;
                
                ref var wayPoints = ref entity.Get<WayPoints>();
                wayPoints.AllWayPoints = spawnConfiguration.wayPoints;
                wayPoints.CurrentPoint = spawnConfiguration.wayPoints[0];

                entity.Get<TargetComponent>().Target = wayPoints.CurrentPoint;

                entity.Get<SelfSpawnRequest>();
            }
        }
    }
}