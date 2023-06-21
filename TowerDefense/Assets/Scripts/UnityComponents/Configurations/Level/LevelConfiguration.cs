using System.Collections.Generic;
using UnityComponents.Configurations.Enemy;
using UnityEngine;

namespace UnityComponents.Configurations.Level
{
    [CreateAssetMenu(fileName = "newLevelData", menuName = "Data/Level")]
    public class LevelConfiguration : ScriptableObject
    {
        public List<SpawnerConfiguration> enemySpawnerData;
        public string sceneName;
    }
}