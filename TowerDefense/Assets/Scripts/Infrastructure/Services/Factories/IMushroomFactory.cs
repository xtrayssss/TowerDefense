using Leopotam.Ecs;
using UnityComponents.Configurations.Enemy;
using UnityComponents.Enemies;
using UnityEngine;

namespace Infrastructure.Services.Factories
{
    internal interface IMushroomFactory
    {
        public GameObject SpawnMushroom(EcsWorld world, EnemyTypeId enemyTypeId, EnemyConfiguration enemyConfiguration,
            Vector2 at);
    }
}