using UnityEngine;

namespace Infrastructure.Services.AssetManagement
{
    internal class AssetProvider : IAssetProvider
    {
        public GameObject LoadResource(string path) => 
            (GameObject) Resources.Load(path);

        public T[] LoadAllResources<T>(string path) where T : Object => 
            Resources.LoadAll<T>(path);
    }
}