using UnityComponents.Enemies;
using UnityEngine;

namespace UnityComponents.Configurations.Enemy
{
    [CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy")]
    public class EnemyConfiguration : ScriptableObject
    {
        [SerializeField] [Range(1, 100)] private float health = 50;
        [SerializeField] [Range(1, 100)] private float damage = 20;
        [SerializeField] [Range(1, 100)] private float speed = 2;
        [SerializeField] private EnemyTypeId enemyTypeId;
        [SerializeField] private GameObject prefab;
        [SerializeField] private EnemyFactoryTypeId enemyFactoryTypeId;
        [SerializeField] private float minDistanceToPoint;

        public float MINDistanceToPoint => minDistanceToPoint;
        public EnemyFactoryTypeId EnemyFactoryTypeId => enemyFactoryTypeId;
        public GameObject Prefab => prefab;
        public EnemyTypeId EnemyTypeId => enemyTypeId;
        public float Health => health;
        public float Damage => damage;
        public float Speed => speed;
    }
}