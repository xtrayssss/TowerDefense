using Components.Destroy;
using Leopotam.Ecs;

namespace Systems.Destroy
{
    internal class DestroySystem : IEcsRunSystem
    {
        private readonly EcsFilter<SelfDestroyRequest> _filter;

        public void Run()
        {
            foreach (int index in _filter)
                _filter.GetEntity(index).Destroy();
        }
    }
}