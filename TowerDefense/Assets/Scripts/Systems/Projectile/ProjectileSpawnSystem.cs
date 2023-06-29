using Components.Model;
using Components.Movement;
using Infrastructure.Services.Factories;
using Leopotam.Ecs;
using UnityComponents.Towers;

namespace Systems.Projectile
{
    internal class ProjectileSpawnSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CalculateDistanceProgress, TargetComponent, Model, SpawnProjectile>.Exclude<
            SpawnProjectileBlock> _filter;
        private readonly IProjectileFactory _projectileFactory;
        private readonly EcsWorld _world;

        public ProjectileSpawnSystem(IProjectileFactory projectileFactory) => 
            _projectileFactory = projectileFactory;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref var spawnProjectile = ref _filter.Get4(index);
                _projectileFactory.CreateProjectile(spawnProjectile.ProjectileTypeId);
            }
        }
    }

    internal struct SpawnProjectile
    {
        public ProjectileTypeId[] ProjectileTypeId;
    }

    internal enum ProjectileTypeId
    {
        Arrow,
        MagicBall
    }

    internal struct SpawnProjectileBlock
    {
        public float Cooldown;
    }
}