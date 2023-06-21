using Leopotam.Ecs;
using UnityComponents.Enemies;
using UnityEngine;

namespace Infrastructure.Services.Factories
{
    internal interface IEnemyFactory
    {
        public void CreateEnemy(EcsWorld world, EnemyTypeId[] enemiesTypeId, float amountEnemies, Vector2 position);
    }
}