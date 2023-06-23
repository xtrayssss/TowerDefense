using System;
using System.Collections.Generic;

namespace Infrastructure.GameState
{
    internal class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IGameState> _states = new Dictionary<Type, IGameState>();

        private IGameState _activeState;
       
        public GameStateMachine(LoadLevelState.Factory loadLevelFactory)
        {
            LoadLevelState loadLevelState = loadLevelFactory.Create(this);

            _states.Add(typeof(LoadLevelState), loadLevelState);
        }
        
        public void SwitchState<T>() where T : IGameState
        {
            _activeState?.Exit();
            IGameState newState = _states[typeof(T)];
            _activeState = newState;
            _activeState.Enter();
        }
    }

    internal class LoadProgressState : IGameState
    {
        // => level, rating (stars), amount defeat enemies
        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }
}