using System;
using UnityComponents.Windows;

namespace UnityComponents.Containers.Data
{
    [Serializable]
    internal class Data : GenericData<BaseWindow>
    {
        public FormTypeId formTypeId;
    }

    internal class GenericData<T> where T : BaseWindow
    {
        public string Name;
        public T Value;
    }
}