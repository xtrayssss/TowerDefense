using Infrastructure.GameState;
using Infrastructure.Services.Coroutines;
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
}