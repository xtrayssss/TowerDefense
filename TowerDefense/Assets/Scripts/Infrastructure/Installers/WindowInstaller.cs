using Systems.Build;
using Infrastructure.Services.Factories;
using Zenject;

namespace Infrastructure.Installers
{
    public class WindowInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle();
    }
}