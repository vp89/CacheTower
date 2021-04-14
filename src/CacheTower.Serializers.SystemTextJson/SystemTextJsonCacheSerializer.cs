using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace CacheTower.Serializers.SystemTextJson
{
    public class SystemTextJsonCacheSerializer : ICacheSerializer
    {
        public MemoryStream SerializeObject<T>(T cacheEntry)
        {
            var stream = new MemoryStream();

            using (var jsonWriter = new Utf8JsonWriter(stream))
            {
                JsonSerializer.Serialize(jsonWriter, cacheEntry);
            }

            return stream;
        }

        public T DeserializeObject<T>(Stream stream)
        {
            using (var streamReader = new StreamReader(stream, Encoding.UTF8, false, 1024))
            {
                streamReader
            }
            using (var jsonReader = new Utf8JsonReader())
            return JsonSerializer.Deserialize<T>()
        }
    }
}
