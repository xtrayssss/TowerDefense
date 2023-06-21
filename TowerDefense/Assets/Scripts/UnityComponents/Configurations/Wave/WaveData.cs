using System;
using UnityComponents.Enemies;
using UnityEngine;

namespace UnityComponents.Configurations.Wave
{
    [Serializable]
    public class WaveData
    {
        public EnemyTypeId[] enemiesTypeId;
        public Vector3 position;

        public WaveData(EnemyTypeId[] enemiesTypeId, Vector3 position)
        {
            this.enemiesTypeId = enemiesTypeId;
            this.position = position;
        }
    }
}