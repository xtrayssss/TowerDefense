namespace Infrastructure.GameState
{
    internal interface IGameStateSwitcher
    {
        public void SwitchState<T>() where T : IGameState;
    }
}