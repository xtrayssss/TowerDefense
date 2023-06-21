using UnityEngine;

namespace Infrastructure.Services.AssetManagement
{
    internal interface IAssetProvider : IService
    {
        public GameObject LoadResource(string path);
        public T LoadResource<T>(string path) where T : Object;
        public T[] LoadAllResources<T>(string path) where T : Object;
    }
}