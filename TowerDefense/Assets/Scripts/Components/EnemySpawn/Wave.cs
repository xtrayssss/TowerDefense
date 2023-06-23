using System.Collections.Generic;
using UnityComponents.Configurations.Wave;

namespace Components.EnemySpawn
{
    internal struct Wave
    {
        public List<WaveConfiguration> Waves;

        public WaveConfiguration CurrentWave;

        public int IndexWave;
    }
}