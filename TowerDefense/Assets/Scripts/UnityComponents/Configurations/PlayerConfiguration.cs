using UnityEngine;

namespace UnityComponents.Configurations
{
    [CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player")]
    internal class PlayerConfiguration : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] [Range(1, 100)] private float health = 50;

        public GameObject Prefab => prefab;

        public float Health => health;
    }
}