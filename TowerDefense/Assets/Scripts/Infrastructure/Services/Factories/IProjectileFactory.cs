using System;
using Systems.Projectile;
using Infrastructure.Services.World;
using Zenject;

namespace Infrastructure.Services.Factories
{
    internal interface IProjectileFactory
    {
        public void CreateProjectile(ProjectileTypeId[] projectilesTypeId);
    }

    internal class ProjectileFactory : IProjectileFactory
    {
        private readonly IWorldService _worldService;

        public ProjectileFactory(IWorldService worldService) => 
            _worldService = worldService;

        public void CreateProjectile(ProjectileTypeId[] projectilesTypeId)
        {
            foreach (ProjectileTypeId projectileTypeId in projectilesTypeId)
            {
                switch (projectileTypeId)
                {
                    case ProjectileTypeId.Arrow:
                        CreateArrow();
                        break;
                    case ProjectileTypeId.MagicBall:
                        CreateMagicBall();
                        break;
                }
            }
        }

        private void CreateMagicBall()
        {
            
        }

        private void CreateArrow()
        {
        }
    }
}