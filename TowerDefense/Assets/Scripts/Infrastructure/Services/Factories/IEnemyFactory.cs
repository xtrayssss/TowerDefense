using Leopotam.Ecs;
using UnityComponents.Configurations.Enemy;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.Factories
{
    internal interface IEnemyFactory
    {
        public void SpawnEnemy(EcsWorld world, EnemyConfiguration enemyConfiguration,
            Vector2 spawnPosition, EcsEntity spawnerEntity, DiContainer diContainer);
    }
}