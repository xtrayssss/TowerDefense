using Components.Grid;
using Components.Mouse;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Grid
{
    internal class ConvertWorldToCellSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Components.Mouse.Mouse, Cell, TilemapComponent, SelfConvertWorldToCellRequest>
            _filter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref var mouse = ref _filter.Get1(index);
                ref var cell = ref _filter.Get2(index);
                ref var tilemapComponent = ref _filter.Get3(index);

                cell.CellPosition =
                    tilemapComponent.Tilemap.WorldToCell(new Vector3(mouse.Position.x, mouse.Position.y, 1));
            }
        }
    }
}