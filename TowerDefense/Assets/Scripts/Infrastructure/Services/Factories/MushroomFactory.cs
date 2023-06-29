using Components.Damage;
using Components.Health;
using Components.Model;
using Components.Movement;
using Components.Tags;
using Leopotam.Ecs;
using UnityComponents.Configurations.Enemy;
using UnityComponents.Views;
using UnityEngine;
using Zenject;
using WayPoints = Components.WayPoints.WayPoints;

namespace Infrastructure.Services.Factories
{
    internal class MushroomFactory : IMushroomFactory
    {
        public void SpawnEnemy(EcsWorld world, EnemyConfiguration enemyConfiguration,
            Vector2 spawnPosition,
            EcsEntity spawnerEntity, DiContainer diContainer, Transform parent)
        {
            EcsEntity entity = world.NewEntity();

            GameObject mushroomGO =
                diContainer.InstantiatePrefab(enemyConfiguration.Prefab, spawnPosition, Quaternion.identity, parent);

            entity.Get<EnemyTag>();
            entity.Get<Model>().ModelGO = mushroomGO;

            mushroomGO.GetComponent<EntityView>().Construct(entity);

            ref var wayPoints = ref entity.Get<WayPoints>();
            wayPoints = spawnerEntity.Get<WayPoints>();
            wayPoints.MinDistance = enemyConfiguration.MINDistanceToPoint;

            entity.Get<TargetComponent>().Target = wayPoints.CurrentPoint;

            entity.Get<MovementDirection>();

            entity.Get<SelfCalculatedDirectionRequest>();

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

        public class Factory : PlaceholderFactory<MushroomFactory>
        {
        }
    }
}