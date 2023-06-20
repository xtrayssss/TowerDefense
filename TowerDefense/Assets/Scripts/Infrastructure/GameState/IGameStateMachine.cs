using Infrastructure.Services;

namespace Infrastructure.GameState
{
    internal interface IGameStateMachine : IService
    {
        public void SwitchState<T>() where T : IGameState;
    }
}