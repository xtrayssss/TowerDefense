using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class PrefabContainerInstaller : MonoInstaller
    {
        [SerializeField] private PrefabContainer prefabContainer;

        public override void InstallBindings() =>
            BindPrefabContainer();

        private void BindPrefabContainer() =>
            Container.Bind<PrefabContainer>().FromInstance(prefabContainer);
    }
}