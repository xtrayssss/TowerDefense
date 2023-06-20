using Infrastructure.GameState;
using Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine) =>
            _gameStateMachine = gameStateMachine;

        private void Awake()
        {
            _gameStateMachine.SwitchState<LoadLevelState>();
            DontDestroyOnLoad(gameObject);
        }
    }

    internal interface IGameStateMachine : IService
    {
        public void SwitchState<T>() where T : IGameState;
    }
}