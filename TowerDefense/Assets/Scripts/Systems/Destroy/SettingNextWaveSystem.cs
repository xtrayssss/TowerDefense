using Components.Destroy;
using Components.EnemySpawn;
using Components.Tags;
using Leopotam.Ecs;
using UnityComponents.Configurations.Wave;

namespace Systems.Destroy
{
    internal class SettingNextWaveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CheckAliveEnemiesRequest> _checkingFilter;
        private readonly EcsFilter<EnemyTag> _enemyFilter;
        private readonly EcsFilter<Wave> _waveFilter;

        public void Run()
        {
            foreach (int index in _checkingFilter)
            {
                if (!CheckAllEnemiesDead()) continue;

                foreach (int indexWaveEntity in _waveFilter)
                {
                    ref var wave = ref _waveFilter.Get1(indexWaveEntity);

                    if (!TryGetNextWave(ref wave, out WaveConfiguration waveConfiguration)) continue;
                    
                    wave.CurrentWave = waveConfiguration;
                    _waveFilter.GetEntity(indexWaveEntity).Get<SelfSpawnRequest>();
                }

                _checkingFilter.GetEntity(index).Get<SelfDestroyRequest>();
            }
        }

        private bool TryGetNextWave(ref Wave wave, out WaveConfiguration waveConfiguration)
        {
            if (wave.IndexWave + 1 < wave.Waves.Count)
            {
                waveConfiguration = GetNextWave(ref wave);
                return true;
            }

            waveConfiguration = wave.CurrentWave;

            return false;
        }

        private WaveConfiguration GetNextWave(ref Wave wave) =>
            wave.Waves[++wave.IndexWave];

        private bool CheckAllEnemiesDead() =>
            _enemyFilter.GetEntitiesCount() == 0;
    }
}