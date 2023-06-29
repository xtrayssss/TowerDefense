using UnityComponents.Containers.Data;
using UnityComponents.Windows;
using UnityEngine;

namespace UnityComponents.Configurations
{
    internal class WindowConfiguration : ScriptableObject
    {
        [SerializeField] private FormTypeId formTypeId;
        [SerializeField] private BaseWindow prefab;

        public BaseWindow Prefab => prefab;
        public FormTypeId FormTypeId => formTypeId;
    }

    [CreateAssetMenu(fileName = "newBuild", menuName = "Data/Window")]
    internal class BuildWindowConfiguration : WindowConfiguration
    {
        
    }
}