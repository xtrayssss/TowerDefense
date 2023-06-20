using UnityEngine;

namespace Infrastructure.Services.Spawn
{
    internal class SpawnService : ISpawnService
    {
        public GameObject Instantiate(GameObject prefab, Vector2 at, Transform parent) =>
            Object.Instantiate(prefab, at, Quaternion.identity, parent);

        public GameObject Instantiate(GameObject prefab, Vector2 at) =>
            Object.Instantiate(prefab, at, Quaternion.identity);

        public GameObject Instantiate(GameObject prefab) =>
            Object.Instantiate(prefab);

        public GameObject Instantiate(GameObject prefab, Transform parent) => 
            Object.Instantiate(prefab, parent);
    }
}