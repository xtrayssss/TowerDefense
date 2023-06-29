using UnityEngine;

namespace UnityComponents.Configurations
{
    [CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player")]
    public class PlayerConfiguration : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] [Range(1, 100)] private float health = 50;
        [SerializeField] private int startAmountDiamante = 100;
        public int StartAmountDiamante => startAmountDiamante;

        public GameObject Prefab => prefab;
        public float Health => health;
    }
}