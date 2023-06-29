using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace UnityComponents.Containers
{
    public class SceneReferenceContainer : MonoBehaviour, IInitializable
    {
        [SerializeField] private ReferenceContainerData[] containers;
        private Dictionary<Type, ReferenceContainer> _containersMap;

        public T GetSubContainer<T>() where T : class =>
            _containersMap[typeof(T)] as T;
        
        public void Initialize()
        {
            _containersMap = InitializeOwnContainers();

            foreach (ReferenceContainerData container in containers)
            {
                container.referenceContainer.Initialize();
            }
        }

        private Dictionary<Type, ReferenceContainer> InitializeOwnContainers() =>
            containers.ToDictionary(x => x.referenceContainer.GetType(),
                x => x.referenceContainer);
    }

    [Serializable]
    public class ReferenceContainerData
    {
        public string name;
        public ReferenceContainer referenceContainer;
    }
}