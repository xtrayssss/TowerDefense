using Infrastructure.Services.StaticData;
using UnityComponents.Configurations;
using UnityComponents.Containers.Data;
using UnityComponents.Windows;
using Zenject;

namespace Infrastructure.Services.Factories
{
    internal class WindowFactory : IWindowFactory
    {
        private readonly IStaticData _staticData;
        private readonly DiContainer _diContainer;

        public WindowFactory(IStaticData staticData, DiContainer diContainer)
        {
            _staticData = staticData;
            _diContainer = diContainer;
        }

        public BaseWindow CreateWindow<T>(FormTypeId formTypeId) where T : WindowConfiguration
        {
            WindowConfiguration windowConfiguration = _staticData.GetWindowData(formTypeId);

            return _diContainer.InstantiatePrefab(windowConfiguration.Prefab).GetComponent<BaseWindow>();
        }
    }
}