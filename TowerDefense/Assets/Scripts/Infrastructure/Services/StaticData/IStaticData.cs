using UnityComponents.Configurations;
using UnityComponents.Configurations.Enemy;
using UnityComponents.Configurations.Level;
using UnityComponents.Configurations.Wave;
using UnityComponents.Enemies;

namespace Infrastructure.Services.StaticData
{
    internal interface IStaticData : IService
    {
        public EnemyConfiguration GetEnemyData(EnemyTypeId enemyTypeId);
        public void LoadEnemiesData();
        public WaveConfiguration GetWaveData();
        public void LoadLevelData();
        public LevelConfiguration GetLevelData(string sceneKey);
    }
}