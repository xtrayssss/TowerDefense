using Components.Model;
using Components.Movement;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Move
{
    internal class CalculatedDirectionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MovementDirection, TargetComponent, RigidbodyComponent> _filter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref var movementDirection = ref _filter.Get1(index);
                ref var targetComponent = ref _filter.Get2(index);
                ref var rigidbodyComponent = ref _filter.Get3(index);

                Vector2 calculateDirection = CalculateDirection(ref targetComponent, rigidbodyComponent);

                movementDirection.Direction = calculateDirection.normalized;
                movementDirection.NotNormalizedDirection = calculateDirection;
            }
        }

        private Vector2 CalculateDirection(ref TargetComponent targetComponent,
            RigidbodyComponent rigidbodyComponent) =>
            (Vector3) targetComponent.Target - rigidbodyComponent.Rigidbody.transform.position;
    }
}