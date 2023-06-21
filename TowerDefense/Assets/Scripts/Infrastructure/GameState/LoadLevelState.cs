using Infrastructure.Load;
using Infrastructure.Services;
using Infrastructure.Services.Factories;
using Infrastructure.Services.StaticData;
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

        public LoadLevelState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader,
            IEnemySpawnerFactory enemySpawnerFactory, IStaticData staticData)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _enemySpawnerFactory = enemySpawnerFactory;
            _staticData = staticData;
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
        }

        private string GetActiveScene() =>
            SceneManager.GetActiveScene().name;

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState>
        {
        }
    }
}