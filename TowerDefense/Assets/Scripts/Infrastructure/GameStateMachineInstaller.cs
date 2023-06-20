using Infrastructure.GameState;
using Zenject;

namespace Infrastructure
{
    internal class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            BindLoadLevelGameState();
            BindStateMachine();
        }

        private void BindStateMachine() => 
            Container.
                Bind<IGameStateMachine>().
                To<GameStateMachine>().
                AsSingle();

        private void BindLoadLevelGameState() => 
            Container.
                BindFactory<IGameStateMachine, LoadLevelState, LoadLevelState.Factory>();
    }
}