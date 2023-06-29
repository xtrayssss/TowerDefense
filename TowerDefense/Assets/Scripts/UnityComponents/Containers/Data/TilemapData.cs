using System;
using UnityEngine.Tilemaps;

namespace UnityComponents.Containers.Data
{
    [Serializable]
    public class TilemapData
    {
        public string name;
        public TilemapTypeId tilemapTypeId;
        public Tilemap tilemap;
    }
}