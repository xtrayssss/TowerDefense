using System;
using System.Collections.Generic;
using System.Linq;
using UnityComponents.Containers.Data;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityComponents.Containers
{
    public class TilemapContainer : ReferenceContainer
    {
        [SerializeField] private TilemapData[] tilemaps;

        private Dictionary<TilemapTypeId, Tilemap> _allTilemap;

        public Tilemap GetTilemap(TilemapTypeId tilemapTypeId) =>
            _allTilemap[tilemapTypeId];

        public override void Initialize() =>
            _allTilemap = tilemaps.ToDictionary(x => x.tilemapTypeId, x => x.tilemap);
    }
}