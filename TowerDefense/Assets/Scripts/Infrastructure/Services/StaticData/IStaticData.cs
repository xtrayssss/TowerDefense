using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services.AssetManagement;
using UnityComponents.Configurations.Enemy;
using UnityComponents.Enemies;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
    internal interface IStaticData : IService
    {
        public GameObject GetEnemySpawners();
        public EnemyConfiguration GetEnemyData(EnemyTypeId enemyTypeId);
        public void LoadEnemiesData();
    }

    internal class StaticData : IStaticData
    {
        private readonly IAssetProvider _assetProvider;

        private Dictionary<EnemyTypeId, EnemyConfiguration> _enemyData;

        public StaticData(IAssetProvider assetProvider) =>
            _assetProvider = assetProvider;

        public GameObject GetEnemySpawners() =>
            new GameObject();

        public void LoadEnemiesData() =>
            _enemyData = _assetProvider.LoadAllResources<EnemyConfiguration>(AssetPaths.EnemiesDataPath)
                .ToDictionary(x => x.EnemyTypeId, x => x);

        public EnemyConfiguration GetEnemyData(EnemyTypeId enemyTypeId) =>
            _enemyData.TryGetValue(enemyTypeId, out EnemyConfiguration data) ? data : null;
    }
}