using Components.Model;
using Components.Movement;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Move
{
    internal class RotationSystem : IEcsRunSystem
    {
        private EcsFilter<RigidbodyComponent, TargetComponent> _filter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref var rigidbodyComponent = ref _filter.Get1(index);
                ref var targetComponent = ref _filter.Get2(index);

                if (targetComponent.TargetModel != null)
                {
                    Vector2 direction = (Vector2) targetComponent.TargetModel.transform.position -
                                        rigidbodyComponent.Rigidbody.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    Quaternion lookRotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
                    rigidbodyComponent.Rigidbody.transform.rotation = Quaternion.Slerp(
                        rigidbodyComponent.Rigidbody.transform.rotation, lookRotation, Time.deltaTime * 300);
                }
            }
        }
    }
}