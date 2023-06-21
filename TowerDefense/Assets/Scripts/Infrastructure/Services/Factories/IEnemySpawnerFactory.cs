namespace Infrastructure.Services.Factories
{
    public interface IEnemySpawnerFactory : IService
    {
        public void CreateSpawners(string sceneKey);
    }
}