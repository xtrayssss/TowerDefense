using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityComponents.Configurations.Level
{
    [CreateAssetMenu(fileName = "newLevelData", menuName = "Data/Level")]
    public class LevelConfiguration : ScriptableObject
    {
        public string sceneName;

        public List<SpawnConfiguration> spawnConfigurations;
    }

    [Serializable]
    public class WayPointData
    {
        public Vector2 position;

        public WayPointData(Vector2 position) =>
            this.position = position;
    }
}