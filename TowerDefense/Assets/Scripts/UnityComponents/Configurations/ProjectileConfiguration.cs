using UnityEngine;

namespace UnityComponents.Configurations
{
    [CreateAssetMenu(fileName = "newProjectileData", menuName = "Data/Projectile")]
    public class ProjectileConfiguration : ScriptableObject
    {
        [SerializeField] private GameObject prefab;
    }
}