using Components.Destroy;
using Components.Model;
using Leopotam.Ecs;

namespace Systems.Destroy
{
    internal class DestroyModelSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SelfDestroyModelRequest, Model> _filter;

        public void Run()
        {
            foreach (int index in _filter)
                _filter.Get2(index).ModelGO.SetActive(false);
        }
    }
}