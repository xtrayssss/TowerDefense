using Leopotam.Ecs;

namespace Infrastructure.Services.World
{
    public interface IWorldService
    {
        public EcsWorld World { get; }
    }
}