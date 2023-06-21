using UnityComponents.Enemies;
using UnityEngine;

namespace Components.EnemySpawn
{
    internal struct Wave
    {
        public EnemyTypeId[] EnemiesTypeId;

        public float AmountEnemies;
        public Vector2 Position;
    }
}