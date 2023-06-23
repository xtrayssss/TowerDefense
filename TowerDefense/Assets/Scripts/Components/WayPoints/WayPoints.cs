using UnityEngine;

namespace Components.WayPoints
{
    internal struct WayPoints
    {
        public Vector2 CurrentPoint;
        public Vector3[] AllWayPoints;
        public int IndexPoint;
        public float MinDistance;
    }
}