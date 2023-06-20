using UnityEngine;

namespace Infrastructure.Services.AssetManagement
{
    internal interface IAssetProvider : IService
    {
        public GameObject LoadResource(string path);
    }
}