namespace Infrastructure.Services.Random
{
    internal class RandomService : IRandomService
    {
        public T GetRandomElement<T>(T[] array) => 
            array[UnityEngine.Random.Range(0, array.Length)];
    }
}