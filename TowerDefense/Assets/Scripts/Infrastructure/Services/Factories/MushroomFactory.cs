using Components.Damage;
using Components.Health;
using Components.Movement;
using Infrastructure.Services.Spawn;
using Leopotam.Ecs;
using UnityComponents.Configurations.Enemy;
using UnityComponents.Enemies;
using UnityEngine;

namespace Infrastructure.Services.Factories
{
    internal class MushroomFactory : IMushroomFactory
    {
        private readonly ISpawnService _spawnService;

        public MushroomFactory(ISpawnService spawnService) =>
            _spawnService = spawnService;

        public GameObject SpawnMushroom(EcsWorld world, EnemyTypeId enemyTypeId, EnemyConfiguration enemyConfiguration,
            Vector2 position)
        {
            switch (enemyTypeId)
            {
                case EnemyTypeId.MushroomLevel1:
                    return CreateMushroomFirstLevel(world, enemyConfiguration, position);
                case EnemyTypeId.MushroomLevel2:
                    return CreateMushroomSecondLevel(world, enemyConfiguration, position);
                case EnemyTypeId.MushroomLevel3:
                    return CreateMushroomThirdLevel(world, enemyConfiguration, position);
            }

            return null;
        }

        private GameObject CreateMushroomFirstLevel(EcsWorld world, EnemyConfiguration enemyConfiguration,
            Vector2 position)
        {
            EcsEntity entity = world.NewEntity();

            GameObject mushroomGO = _spawnService.Instantiate(enemyConfiguration.Prefab);

            BaseConfiguration(entity, mushroomGO, enemyConfiguration, at: position);

            return mushroomGO;
        }

        private GameObject CreateMushroomSecondLevel(EcsWorld world, EnemyConfiguration enemyConfiguration,
            Vector2 position)
        {
            EcsEntity entity = world.NewEntity();

            GameObject mushroomGO = _spawnService.Instantiate(enemyConfiguration.Prefab);

            BaseConfiguration(entity, mushroomGO, enemyConfiguration, at: position);

            return mushroomGO;
        }

        private GameObject CreateMushroomThirdLevel(EcsWorld world, EnemyConfiguration enemyConfiguration,
            Vector2 position)
        {
            EcsEntity entity = world.NewEntity();

            GameObject mushroomGO = _spawnService.Instantiate(enemyConfiguration.Prefab);

            BaseConfiguration(entity, mushroomGO, enemyConfiguration, at: position);

            return mushroomGO;
        }

        private void BaseConfiguration(EcsEntity entity, GameObject mushroomGO, EnemyConfiguration enemyConfiguration,
            Vector2 at)
        {
            mushroomGO.transform.position = at;

            ref var damage = ref entity.Get<Damage>();
            damage.AppliedDamage = enemyConfiguration.Damage;

            ref var health = ref entity.Get<Health>();
            health.CurrentHealth = enemyConfiguration.Health;
            health.MaxHealth = enemyConfiguration.Health;

            ref var speed = ref entity.Get<Speed>();
            speed.CurrentSpeed = enemyConfiguration.Speed;

            ref var rigidbodyComponent = ref entity.Get<RigidbodyComponent>();
            rigidbodyComponent.Rigidbody = mushroomGO.GetComponent<Rigidbody2D>();
        }
    }
}