using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace CacheTower.Serializers.NewtonsoftJson
{
	/// <inheritdoc />
	public class NewtonsoftJsonCacheSerializer : ICacheSerializer
	{
		private JsonSerializer Serializer { get; }

		/// <summary>
		/// An implementation of ICacheSerializer that uses Newtonsoft.Json
		/// </summary>
		public NewtonsoftJsonCacheSerializer()
		{
			Serializer = new JsonSerializer();
		}

		private MemoryStream Serialize<T>(T cacheEntry)
		{
			var stream = new MemoryStream();

			using (var streamWriter = new StreamWriter(stream, Encoding.UTF8, 1024, true))
			using (var jsonWriter = new JsonTextWriter(streamWriter))
			{
				Serializer.Serialize(jsonWriter, cacheEntry);
			}

			return stream;
		}

		public MemoryStream SerializeCacheEntry<T>(DateTime expiry, T? value)
		{
			var cacheEntry = new NewtonsoftJsonCacheEntry<T>()
			{
				Expiry = expiry,
				Value = value
			};

			return Serialize(cacheEntry);
		}

		public ICacheEntry<T> DeserializeCacheEntry<T>(MemoryStream stream)
		{
			using (var streamReader = new StreamReader(stream, Encoding.UTF8, false, 1024))
			using (var jsonReader = new JsonTextReader(streamReader))
			{
				return Serializer.Deserialize<NewtonsoftJsonCacheEntry<T>>(jsonReader);
			}
		}
	}
}
