using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services.AssetManagement;
using UnityComponents.Configurations;
using UnityComponents.Configurations.Enemy;
using UnityComponents.Configurations.Level;
using UnityComponents.Configurations.Wave;
using UnityComponents.Enemies;

namespace Infrastructure.Services.StaticData
{
    internal class StaticData : IStaticData
    {
        private readonly IAssetProvider _assetProvider;

        private Dictionary<EnemyTypeId, EnemyConfiguration> _enemyData;
        private Dictionary<string, LevelConfiguration> _levelData;

        public StaticData(IAssetProvider assetProvider) =>
            _assetProvider = assetProvider;

        public void LoadEnemiesData() =>
            _enemyData = _assetProvider.LoadAllResources<EnemyConfiguration>(AssetPaths.EnemiesDataPath)
                .ToDictionary(x => x.EnemyTypeId, x => x);

        public WaveConfiguration GetWaveData() =>
            new WaveConfiguration();

        public LevelConfiguration GetLevelData(string sceneKey) =>
            _levelData.TryGetValue(sceneKey, out LevelConfiguration data) ? data : null;

        public void LoadLevelData() =>
            _levelData = _assetProvider.LoadAllResources<LevelConfiguration>(AssetPaths.LevelDataPath)
                .ToDictionary(x => x.sceneName, x => x);

        public EnemyConfiguration GetEnemyData(EnemyTypeId enemyTypeId) =>
            _enemyData.TryGetValue(enemyTypeId, out EnemyConfiguration data) ? data : null;
    }
}