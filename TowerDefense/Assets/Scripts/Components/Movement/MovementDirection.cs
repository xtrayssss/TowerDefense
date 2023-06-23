using UnityEngine;

namespace Components.Movement
{
    internal struct MovementDirection
    {
        public Vector2 Direction;
        public Vector2 MovementVector;
        public Vector2 NotNormalizedDirection;
        public int X;
        public Vector2 OldDirection;
    }
}