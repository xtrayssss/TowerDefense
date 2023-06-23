using System.Diagnostics.Contracts;
using Zenject;

namespace Infrastructure.Installers
{
    public class WorldInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Debug.Log(Container.Resolve<IWorldService>());
        }
    }
}