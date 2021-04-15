using System.IO;

namespace CacheTower
{
    public interface ICacheSerializer
    {
        MemoryStream Serialize<T>(T cacheEntry);

        T Deserialize<T>(MemoryStream stream);
    }
}