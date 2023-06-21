using UnityEngine;

namespace UnityComponents.Configurations.Wave
{
    [CreateAssetMenu(fileName = "newWaveData", menuName = "Data/Wave")]
    public class WaveConfiguration : ScriptableObject
    {
        public float amountEnemies;
        public WaveData spawnData;
    }
}