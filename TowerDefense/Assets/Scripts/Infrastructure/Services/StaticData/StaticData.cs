using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Systems.Build;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.Factories;
using UnityComponents.Configurations;
using UnityComponents.Configurations.Enemy;
using UnityComponents.Configurations.Level;
using UnityComponents.Containers.Data;
using UnityComponents.Enemies;

namespace Infrastructure.Services.StaticData
{
    internal class StaticData : IStaticData
    {
        private readonly IAssetProvider _assetProvider;

        private Dictionary<EnemyTypeId, EnemyConfiguration> _enemiesData;
        private Dictionary<string, LevelConfiguration> _levelsData;
        private Dictionary<FormTypeId, WindowConfiguration> _windowsData;
        private Dictionary<TowerTypeId, TowerConfiguration> _towersData;

        public StaticData(IAssetProvider assetProvider) =>
            _assetProvider = assetProvider;

        public void LoadEnemiesData() =>
            _enemiesData = _assetProvider.LoadAllResources<EnemyConfiguration>(AssetPaths.EnemiesDataPath)
                .ToDictionary(x => x.EnemyTypeId, x => x);

        public void LoadFormData() =>
            _windowsData = _assetProvider.LoadAllResources<WindowConfiguration>(AssetPaths.WindowPath)
                .ToDictionary(x => x.FormTypeId, x => x);

        public TowerConfiguration GetTowerData(TowerTypeId towerTypeId) => 
            _towersData.TryGetValue(towerTypeId, out TowerConfiguration data) ? data : null;

        public void LoadTowerData() =>
            _towersData = _assetProvider.LoadAllResources<TowerConfiguration>(AssetPaths.TowerDataPath)
                .ToDictionary(x => x.TowerTypeId, x => x);

        public LevelConfiguration GetLevelData(string sceneKey) =>
            _levelsData.TryGetValue(sceneKey, out LevelConfiguration data) ? data : null;

        public PlayerConfiguration GetPlayerData() =>
            _assetProvider.LoadResource<PlayerConfiguration>(AssetPaths.PlayerPath);

        public void LoadLevelData() =>
            _levelsData = _assetProvider.LoadAllResources<LevelConfiguration>(AssetPaths.LevelDataPath)
                .ToDictionary(x => x.sceneName, x => x);

        public WindowConfiguration GetWindowData(FormTypeId formTypeId) =>
            _windowsData[formTypeId];

        public EnemyConfiguration GetEnemyData(EnemyTypeId enemyTypeId) =>
            (_enemiesData.TryGetValue(enemyTypeId, out EnemyConfiguration data) ? data : null);
    }
}