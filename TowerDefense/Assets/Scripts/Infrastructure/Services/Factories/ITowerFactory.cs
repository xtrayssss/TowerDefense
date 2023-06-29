using UnityEngine;

namespace Infrastructure.Services.Factories
{
    public interface ITowerFactory
    {
        void CreateTower(TowerTypeId towerTypeId, Vector3 spawnPosition);
    }
}