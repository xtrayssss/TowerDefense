using Components.Health;
using Infrastructure.Installers;
using Infrastructure.Services.Spawn;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.World;
using Leopotam.Ecs;
using UnityComponents.Configurations;
using UnityComponents.Views;

namespace Infrastructure.Services.Factories
{
    internal class PlayerFactory : IPlayerFactory
    {
        private readonly PlayerView _playerView;

        public PlayerFactory(PlayerView playerView) =>
            _playerView = playerView;

        public void CreatePlayer(IWorldService worldService, ISpawnService spawnService, IStaticData staticData)
        {
            EcsEntity entity = worldService.World.NewEntity();

            PlayerConfiguration playerConfiguration = staticData.GetPlayerData();

            _playerView.Construct(entity);

            ref var health = ref entity.Get<Health>();
            health.CurrentHealth = playerConfiguration.Health;
            health.MaxHealth = playerConfiguration.Health;
        }
    }
}