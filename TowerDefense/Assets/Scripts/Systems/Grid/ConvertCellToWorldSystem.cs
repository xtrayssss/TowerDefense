using Components.Grid;
using Components.Mouse;
using Leopotam.Ecs;
using UnityComponents.Pointers;

namespace Systems.Grid
{
    internal class ConvertCellToWorldSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Cell, TilemapComponent, SelfConvertCellToWorldRequest> _filter;
        private readonly EcsFilter<BuildPointerTag> _pointerFilter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref var cell = ref _filter.Get1(index);
                ref var tilemapComponent = ref _filter.Get2(index);

                if (_pointerFilter.GetEntitiesCount() <= 0)
                    cell.WorldPosition = tilemapComponent.Tilemap.CellToWorld(cell.CellPosition);
            }
        }
    }
}