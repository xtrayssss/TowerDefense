using UnityEngine;

namespace Infrastructure.Services.StaticData
{
    internal interface IStaticData : IService
    {
        public GameObject GetEnemySpawners();
    }
}