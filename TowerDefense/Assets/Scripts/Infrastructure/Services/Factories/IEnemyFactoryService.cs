using Leopotam.Ecs;
using UnityComponents.Enemies;
using UnityEngine;

namespace Infrastructure.Services.Factories
{
    internal interface IEnemyFactoryService
    {
        public void CreateEnemy(EcsWorld world, EnemyTypeId[] enemiesTypeId, float amountEnemies,
            Vector3 spawnPosition, EcsEntity spawnerEntity, float coolDown);
    }
}