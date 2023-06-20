namespace Infrastructure.Services.Random
{
    internal interface IRandomService
    {
        public T GetRandomElement<T>(T[] array);
    }
}