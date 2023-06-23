using Components.Movement;
using General;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.WayPoints
{
    internal class WayPointSettingSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Components.WayPoints.WayPoints, TargetComponent, MovementDirection> _filter;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref var wayPoints = ref _filter.Get1(index);
                ref var targetComponent = ref _filter.Get2(index);
                ref var movementDirection = ref _filter.Get3(index);

                if (movementDirection.NotNormalizedDirection.GetAbsVector().x < wayPoints.MinDistance ||
                    movementDirection.NotNormalizedDirection.GetAbsVector().y < wayPoints.MinDistance)
                {
                    wayPoints.CurrentPoint = wayPoints.AllWayPoints[
                        wayPoints.IndexPoint + 1 != wayPoints.AllWayPoints.Length
                            ? wayPoints.IndexPoint++
                            : wayPoints.IndexPoint];
                    
                    targetComponent.Target = wayPoints.CurrentPoint;

                    _filter.GetEntity(index).Get<SelfCalculatedDirectionRequest>();
                }
            }
        }
    }
}