using Leopotam.Ecs;
using UnityEngine;

namespace UnityComponents.Views
{
    public abstract class EntityView : MonoBehaviour
    {
        public abstract EcsEntity Entity { get; protected set; }

        public virtual void Construct(EcsEntity entity) =>
            Entity = entity;
    }
}