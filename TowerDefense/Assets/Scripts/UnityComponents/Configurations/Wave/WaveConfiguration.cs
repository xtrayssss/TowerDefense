using UnityComponents.Enemies;
using UnityEngine;

namespace UnityComponents.Configurations.Wave
{
    [CreateAssetMenu(fileName = "newWaveData", menuName = "Data/Wave")]
    public class WaveConfiguration : ScriptableObject
    {
        [SerializeField] private float amountEnemies;
        [SerializeField] private EnemyTypeId[] enemiesTypeId;
        [SerializeField] private float spawnCoolDown;

        public float AmountEnemies => amountEnemies;
        public EnemyTypeId[] EnemiesTypeId => enemiesTypeId;
        public float SpawnCoolDown => spawnCoolDown;
    }
}