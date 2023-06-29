using Leopotam.Ecs;
using UnityComponents.Views;

namespace UnityComponents.Towers
{
    public class TowerView : EntityView
    {
        public override EcsEntity Entity { get; protected set; }

        public void Init(EcsEntity entity) => 
            Entity = entity;
    }
}