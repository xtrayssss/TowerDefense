using Leopotam.Ecs;

namespace Infrastructure.Services.World
{
    internal class WorldService : IWorldService
    {
        public EcsWorld World { get; private set; }

        public WorldService() =>
            InitializeWorld();

        private void InitializeWorld() =>
            World = new EcsWorld();
    }
}