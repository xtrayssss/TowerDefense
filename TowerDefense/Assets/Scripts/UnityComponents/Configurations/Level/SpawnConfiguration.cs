using System.Collections.Generic;
using General;
using UnityComponents.Configurations.Wave;
using UnityEngine;

namespace UnityComponents.Configurations.Level
{
    [CreateAssetMenu(fileName = "newSpawnData", menuName = "Data/Spawn")]
    public class SpawnConfiguration : ScriptableObject
    {
        [SerializeField] [Range(0, Constants.MaxSpawnerId)]
        private int id;

        public Vector3 position;

        public List<WaveConfiguration> waveConfigurations;

        public Vector3[] wayPoints;
        public int ID => id;
    }
}