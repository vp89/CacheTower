using System;
using System.IO;

namespace CacheTower
{
    /// <summary>
    /// This abstraction allows us to use different encoding formats
    /// </summary>
    public interface ICacheSerializer
    {
        /// <summary>
        /// Serialize a cache entry onto a MemoryStream
        /// </summary>
        /// <param name="expiry"></param>
        /// /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        MemoryStream SerializeCacheEntry<T>(DateTime expiry, T? value);

        /// <summary>
        /// Deserialize a cache entry from a MemoryStream
        /// </summary>
        /// <param name="stream"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ICacheEntry<T> DeserializeCacheEntry<T>(MemoryStream stream);
    }
}