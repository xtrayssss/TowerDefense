using Infrastructure.Load;
using Infrastructure.Services;
using Infrastructure.Services.Factories;
using Infrastructure.Services.Spawn;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.World;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.GameState
{
    internal class LoadLevelState : IGameState, IService
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IEnemySpawnerFactory _enemySpawnerFactory;
        private readonly IStaticData _staticData;
        private readonly IEnemyFactoryService _enemyFactoryService;
        private readonly IPlayerFactory _playerFactory;
        private readonly IWorldService _worldService;
        private readonly ISpawnService _spawnService;

        public LoadLevelState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader,
            IEnemySpawnerFactory enemySpawnerFactory, IStaticData staticData, IEnemyFactoryService enemyFactoryService,
            IPlayerFactory playerFactory, IWorldService worldService, ISpawnService spawnService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _enemySpawnerFactory = enemySpawnerFactory;
            _staticData = staticData;
            _enemyFactoryService = enemyFactoryService;
            _playerFactory = playerFactory;
            _worldService = worldService;
            _spawnService = spawnService;
        }

        public void Enter() =>
            _sceneLoader.Load(1, OnLoaded);

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            _staticData.LoadLevelData();
            _staticData.LoadEnemiesData();
            _enemySpawnerFactory.CreateSpawners(GetActiveScene());
            _playerFactory.CreatePlayer(_worldService, _spawnService, _staticData);
        }

        private string GetActiveScene() =>
            SceneManager.GetActiveScene().name;

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState>
        {
        }
    }
}