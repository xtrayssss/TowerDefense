using Infrastructure.Services.Factories;
using UnityEngine;

namespace UnityComponents.Configurations
{
    public class TowerConfiguration : ScriptableObject
    {
        [SerializeField] private float cooldownAttack = 1.0f;
        [SerializeField] private TowerTypeId towerTypeId;
        [SerializeField] private GameObject prefab;

        [SerializeField] [Range(1, 100)]
        private float damage = 5.0f;

        public float Damage => damage;
        public GameObject Prefab => prefab;
        public TowerTypeId TowerTypeId => towerTypeId;
        public float CooldownAttack => cooldownAttack;
    }
}