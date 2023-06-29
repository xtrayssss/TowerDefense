using Infrastructure.Services.Factories;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.World;
using Leopotam.Ecs;
using UnityEngine.SceneManagement;

namespace Systems.Init
{
    internal class InitLevelSystem : IEcsInitSystem
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly IWorldService _worldService;
        private readonly IStaticData _staticData;
        private readonly IEnemySpawnerFactory _enemySpawnerFactory;

        public InitLevelSystem(IPlayerFactory playerFactory, IWorldService worldService, IStaticData staticData,
            IEnemySpawnerFactory enemySpawnerFactory)
        {
            _playerFactory = playerFactory;
            _worldService = worldService;
            _staticData = staticData;
            _enemySpawnerFactory = enemySpawnerFactory;
        }

        public void Init()
        {
            _staticData.LoadLevelData();
            _staticData.LoadEnemiesData();
            _staticData.LoadFormData();
            _staticData.LoadTowerData();

            _enemySpawnerFactory.CreateSpawners(GetActiveScene());
            _playerFactory.CreatePlayer(_worldService.World, _staticData);
        }

        private string GetActiveScene() =>
            SceneManager.GetActiveScene().name;
    }
}