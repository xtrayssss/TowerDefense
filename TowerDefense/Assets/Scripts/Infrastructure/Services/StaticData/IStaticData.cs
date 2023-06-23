using UnityComponents.Configurations;
using UnityComponents.Configurations.Enemy;
using UnityComponents.Configurations.Level;
using UnityComponents.Enemies;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
    internal interface IStaticData : IService
    {
        public EnemyConfiguration GetEnemyData(EnemyTypeId enemyTypeId);
        public void LoadEnemiesData();
        public void LoadLevelData();
        public LevelConfiguration GetLevelData(string sceneKey);
        public Vector3[] GetWayPoints();
        public PlayerConfiguration GetPlayerData();
    }
}