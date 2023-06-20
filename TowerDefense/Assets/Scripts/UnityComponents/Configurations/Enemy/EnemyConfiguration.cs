using UnityComponents.Enemies;
using UnityEngine;

namespace UnityComponents.Configurations.Enemy
{
    [CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy")]
    public class EnemyConfiguration : ScriptableObject
    {
        [SerializeField] private float health;
        [SerializeField] private float damage;
        [SerializeField] private EnemyTypeId enemyTypeId;
        [SerializeField] private GameObject prefab;
        [SerializeField] private float speed;
        public GameObject Prefab => prefab;
        public EnemyTypeId EnemyTypeId => enemyTypeId;
        public float Health => health;
        public float Damage => damage;
        public float Speed => speed;
    }
}