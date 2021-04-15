using System.IO;

namespace CacheTower
{
    public interface ICacheSerializer
    {
        MemoryStream SerializeObject<T>(T cacheEntry);

        T DeserializeObject<T>(MemoryStream stream);
    }
}