using Leopotam.Ecs;
using UnityComponents.Enemies;

namespace Infrastructure.Services.Factories
{
    internal interface IEnemyFactory
    {
        public void CreateEnemy(EcsWorld world, EnemyTypeId[] enemiesTypeId, float amountEnemies);
    }
}