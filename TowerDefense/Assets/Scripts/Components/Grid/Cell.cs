using UnityEngine;

namespace Components.Grid
{
    internal struct Cell
    {
        public Vector3Int CellPosition;
        public Vector3 WorldPosition;
        public bool FirstClick;
    }
}