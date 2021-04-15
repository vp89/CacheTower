﻿using System.IO;
using ProtoBuf;

namespace CacheTower.Serializers.Protobuf
{
	public class ProtobufCacheSerializer : ICacheSerializer
	{
		public MemoryStream SerializeObject<T>(T cacheEntry)
		{
			var stream = new MemoryStream();
			Serializer.Serialize(stream, cacheEntry);
			stream.Seek(0, SeekOrigin.Begin);
			return stream;
		}

		public T DeserializeObject<T>(MemoryStream stream)
		{
			return Serializer.Deserialize<T>(stream);
		}
	}
}
