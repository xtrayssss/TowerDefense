using Systems.Build;
using Infrastructure.Services.Factories;
using UnityComponents.Configurations;
using UnityComponents.Configurations.Enemy;
using UnityComponents.Configurations.Level;
using UnityComponents.Containers.Data;
using UnityComponents.Enemies;

namespace Infrastructure.Services.StaticData
{
    internal interface IStaticData : IService
    {
        public EnemyConfiguration GetEnemyData(EnemyTypeId enemyTypeId);
        public void LoadEnemiesData();
        public void LoadLevelData();
        public LevelConfiguration GetLevelData(string sceneKey);
        public PlayerConfiguration GetPlayerData();
        public WindowConfiguration GetWindowData(FormTypeId formTypeId);
        public void LoadFormData();
        public TowerConfiguration GetTowerData(TowerTypeId towerTypeId);
        public void LoadTowerData();
    }
}