using Infrastructure.Services.Spawn;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.World;
using Zenject;

namespace Infrastructure.Services.Factories
{
    internal interface IPlayerFactory
    {
        public void CreatePlayer(IWorldService worldService, ISpawnService spawnService, IStaticData staticData);
    }
}