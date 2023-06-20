﻿using Infrastructure.GameState;

namespace Infrastructure.Services.Factories
{
    internal interface IEnemySpawnerFactory : IService
    {
        public void CreateSpawner();
    }
}