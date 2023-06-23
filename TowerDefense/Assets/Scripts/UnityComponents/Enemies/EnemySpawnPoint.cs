using General;
using UnityEngine;

namespace UnityComponents.Enemies
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [Range(0, Constants.MaxSpawnerId)] public int id;
    }
}