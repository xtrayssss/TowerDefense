using Components.EnemySpawn;
using Infrastructure.Services.Factories;
using Leopotam.Ecs;

namespace Systems.SpawnSystem
{
    internal class EnemySpawnSystem : IEcsRunSystem
    {
        private readonly IEnemyFactoryService _enemyFactoryService;
        private readonly EcsWorld _world;

        private readonly EcsFilter<EnemySpawn, Wave, SelfSpawnRequest> _filter;

        public EnemySpawnSystem(IEnemyFactoryService enemyFactoryService) =>
            _enemyFactoryService = enemyFactoryService;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);

                ref var wave = ref _filter.Get2(index);
                ref var enemySpawn = ref _filter.Get1(index);

                _enemyFactoryService.CreateEnemy(_world, wave.CurrentWave.EnemiesTypeId, wave.CurrentWave.AmountEnemies,
                    enemySpawn.SpawnPosition, entity, enemySpawn.SpawnCoolDown);
            }
        }
    }
}