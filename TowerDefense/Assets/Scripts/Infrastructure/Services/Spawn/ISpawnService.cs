using UnityEngine;

namespace Infrastructure.Services.Spawn
{
    internal interface ISpawnService
    {
        public GameObject Instantiate(GameObject prefab, Vector2 at, Transform parent);
        public GameObject Instantiate(GameObject prefab, Vector2 at);
        public T Instantiate<T>(T prefab) where T :  Object;
        public GameObject Instantiate(GameObject prefab, Transform parent);
    }
}