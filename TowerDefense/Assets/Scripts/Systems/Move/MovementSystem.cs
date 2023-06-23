using Components.Model;
using Components.Movement;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Move
{
    internal class MovementSystem : IEcsRunSystem
    {
        private EcsFilter<RigidbodyComponent, MovementDirection, Speed> _filter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref var rigidbodyComponent = ref _filter.Get1(index);
                ref var movementDirection = ref _filter.Get2(index);
                ref var speedComponent = ref _filter.Get3(index);

                movementDirection.MovementVector.Set(movementDirection.Direction.x,
                    movementDirection.Direction.y);

                rigidbodyComponent.Rigidbody.velocity =
                    movementDirection.MovementVector * (speedComponent.CurrentSpeed * Time.deltaTime);
            }
        }
    }
}