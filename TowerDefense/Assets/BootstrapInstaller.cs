using Infrastructure;
using Infrastructure.Load;
using Infrastructure.Services.Coroutines;
using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private CoroutineRunner coroutineRunner;

    public override void InstallBindings()
    {
        BindCoroutineRunner();
        BindSceneLoader();
        BindGameStateMachine();
    }
    
    private void BindCoroutineRunner() => 
        Container.
            Bind<ICoroutineRunner>().
            To<CoroutineRunner>().
            FromComponentInNewPrefab(coroutineRunner).
            AsSingle();

    private void BindSceneLoader() =>
        Container.
            Bind<ISceneLoader>().
            To<SceneLoader>().
            AsSingle();

    private void BindGameStateMachine() =>
        Container
            .Bind<IGameStateMachine>()
            .FromSubContainerResolve()
            .ByInstaller<GameStateMachineInstaller>()
            .AsSingle();
}