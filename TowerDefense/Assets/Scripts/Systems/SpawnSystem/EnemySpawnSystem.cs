using Components.EnemySpawn;
using Infrastructure.Services.Factories;
using Leopotam.Ecs;

namespace Systems.SpawnSystem
{
    internal class EnemySpawnSystem : IEcsRunSystem
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly EcsWorld _world;

        private readonly EcsFilter<EnemySpawn, Wave, SpawnRequest> _filter;

        public EnemySpawnSystem(IEnemyFactory enemyFactory) =>
            _enemyFactory = enemyFactory;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref var wave = ref _filter.Get2(index);

                _enemyFactory.CreateEnemy(_world, wave.EnemiesTypeId, wave.AmountEnemies, wave.Position);
            }
        }
    }
}