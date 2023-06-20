using Leopotam.Ecs;

namespace Infrastructure.Services.World
{
    internal interface IWorldService
    {
        public EcsWorld World { get; }
    }
}