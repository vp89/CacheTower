using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace CacheTower.Serializers.NewtonsoftJson
{
	public class NewtonsoftJsonCacheSerializer : ICacheSerializer
	{
		private JsonSerializer Serializer { get; }

		public NewtonsoftJsonCacheSerializer()
		{
			Serializer = new JsonSerializer();
		}

		public MemoryStream SerializeObject<T>(T cacheEntry)
		{
			var stream = new MemoryStream();

			using (var streamWriter = new StreamWriter(stream, Encoding.UTF8, 1024, true))
			using (var jsonWriter = new JsonTextWriter(streamWriter))
			{
				Serializer.Serialize(jsonWriter, cacheEntry);
			}

			return stream;
		}

		public T DeserializeObject<T>(MemoryStream stream)
		{
			using (var streamReader = new StreamReader(stream, Encoding.UTF8, false, 1024))
			using (var jsonReader = new JsonTextReader(streamReader))
			{
				return Serializer.Deserialize<T>(jsonReader);
			}
		}
	}
}
