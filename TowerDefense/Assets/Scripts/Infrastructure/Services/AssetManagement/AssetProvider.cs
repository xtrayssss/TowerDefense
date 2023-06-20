using UnityEngine;

namespace Infrastructure.Services.AssetManagement
{
    internal class AssetProvider : IAssetProvider
    {
        public GameObject LoadResource(string path) => 
            (GameObject) Resources.Load(path);
    }
}