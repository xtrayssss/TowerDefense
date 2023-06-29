using Components.Mouse;
using Leopotam.Ecs;
using UnityComponents.Pointers;

namespace Systems.Mouse
{
    internal class RightClickSystem : IEcsRunSystem
    {
        private readonly EcsFilter<RightClickEvent> _filter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                EcsEntity entity = _filter.GetEntity(index);

                entity.Get<SelfConvertWorldToCellRequest>();
                entity.Get<SelfConvertCellToWorldRequest>();
                entity.Get<ClickHandleSelfRequest>();
            }
        }
    }
}