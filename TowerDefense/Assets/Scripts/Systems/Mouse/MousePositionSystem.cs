using Components.Camera;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Mouse
{
    internal class MousePositionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Components.Mouse.Mouse, CameraComponent> _filter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref var mouse = ref _filter.Get1(index);
                ref var cameraComponent = ref _filter.Get2(index);
                mouse.Position = cameraComponent.Camera.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }
}