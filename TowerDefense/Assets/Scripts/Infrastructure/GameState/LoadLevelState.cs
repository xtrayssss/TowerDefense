using Infrastructure.Load;
using Infrastructure.Services;
using Infrastructure.Services.Factories;
using Infrastructure.Services.World;
using Zenject;

namespace Infrastructure.GameState
{
    internal class LoadLevelState : IGameState, IService
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IEnemySpawnerFactory _enemySpawnerFactory;
        private readonly IWorldService _worldService;

        public LoadLevelState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader,
            IEnemySpawnerFactory enemySpawnerFactory, IWorldService worldService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _enemySpawnerFactory = enemySpawnerFactory;
            _worldService = worldService;
        }

        public void Enter() =>
            _sceneLoader.Load(1, OnLoaded);

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            //Debug.Log(_worldService.CreateWorld());
            //_enemySpawnerFactory.CreateSpawner();
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState>
        {
        }
    }
}