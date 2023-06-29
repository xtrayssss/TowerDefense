using System.Collections.Generic;
using Components.Model;
using Components.Movement;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Move
{
    internal class CalculatedDirectionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MovementDirection, TargetComponent, RigidbodyComponent>
            _filter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref var movementDirection = ref _filter.Get1(index);
                ref var targetComponent = ref _filter.Get2(index);
                ref var rigidbodyComponent = ref _filter.Get3(index);

                if (targetComponent.TargetModel == null)
                {
                    Vector2 calculateDirection = CalculateDirection(ref targetComponent.Target, rigidbodyComponent);
                    movementDirection.Direction = calculateDirection.normalized;
                    movementDirection.NotNormalizedDirection = calculateDirection;
                }
                else
                {
                    Vector2 calculateDirection2 =
                        CalculateDirection(targetComponent.TargetModel.transform.position, rigidbodyComponent);

                    movementDirection.Direction = calculateDirection2.normalized;
                    movementDirection.NotNormalizedDirection = calculateDirection2;
                }
            }
        }

        private Vector2 CalculateDirection(ref Vector2 target,
            RigidbodyComponent rigidbodyComponent) =>
            (Vector3) target - rigidbodyComponent.Rigidbody.transform.position;

        private Vector2 CalculateDirection(Vector2 target,
            RigidbodyComponent rigidbodyComponent) =>
            (Vector3) target - rigidbodyComponent.Rigidbody.transform.position;
    }
}