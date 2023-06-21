using System.Collections.Generic;
using UnityComponents.Configurations.Wave;
using UnityEngine;

namespace UnityComponents.Configurations.Enemy
{
    [CreateAssetMenu(fileName = "newEnemySpawnerData", menuName = "Data/EnemySpawner")]
    public class SpawnerConfiguration : ScriptableObject
    {
        public List<WaveConfiguration> waveData;
        public string sceneName;
        public Vector2 position;
    }
}