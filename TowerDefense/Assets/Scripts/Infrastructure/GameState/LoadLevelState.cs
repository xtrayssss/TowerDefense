using Infrastructure.Load;
using Infrastructure.Services;
using Infrastructure.Services.Factories;
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

        public LoadLevelState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter() =>
            _sceneLoader.Load(1, OnLoaded);

        public void Exit()
        {
        }

        private void OnLoaded()
        {
        }

        private string GetActiveScene() =>
            SceneManager.GetActiveScene().name;

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState>
        {
        }
    }
}