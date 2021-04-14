using System.IO;

namespace CacheTower
{
    public interface ICacheSerializer
    {
        Stream SerializeObject<T>(T cacheEntry);

        T DeserializeObject<T>(Stream stream);
    }
}