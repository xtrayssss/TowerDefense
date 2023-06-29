using Infrastructure.Services.StaticData;
using Leopotam.Ecs;
using UnityComponents.Containers;

namespace Infrastructure.Services.Factories
{
    internal interface IPlayerFactory
    {
        public void CreatePlayer(EcsWorld world, IStaticData staticData);
    }
}