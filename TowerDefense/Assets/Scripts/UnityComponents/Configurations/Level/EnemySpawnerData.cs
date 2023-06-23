using System;
using UnityEngine;

namespace UnityComponents.Configurations.Level
{
    [Serializable]
    public class EnemySpawnerData
    {
        public Vector3 position;

        public EnemySpawnerData(Vector3 position) => 
            this.position = position;
    }
}