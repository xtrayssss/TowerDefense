using UnityEngine;

namespace Infrastructure.Services
{
    internal interface ISpawnService
    {
        public GameObject Instantiate(GameObject prefab, Vector2 at, Transform parent);
        public GameObject Instantiate(GameObject prefab, Vector2 at);
        public GameObject Instantiate(GameObject prefab);
        public GameObject Instantiate(GameObject prefab, Transform parent);
    }
}