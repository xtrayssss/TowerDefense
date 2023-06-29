using UnityComponents.Configurations;
using UnityComponents.Containers.Data;
using UnityComponents.Windows;

namespace Infrastructure.Services.Factories
{
    internal interface IWindowFactory
    {
        public BaseWindow CreateWindow<T>(FormTypeId formTypeId) where T : WindowConfiguration;
    }
}