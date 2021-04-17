using System;
using System.IO;
using ProtoBuf;

namespace CacheTower.Serializers.Protobuf
{
	/// <remarks>
	/// <para>
	/// When caching custom types, you will need to <a href="https://github.com/protobuf-net/protobuf-net#1-first-decorate-your-classes">decorate your class</a> with <c>[ProtoContact]</c> and <c>[ProtoMember]</c> attributes per protobuf-net's documentation.<br/>
	/// Additionally, as the Protobuf format doesn't have a way to represent an empty collection, these will be returned as <c>null</c>.
	/// </para>
	/// </remarks>
	/// <inheritdoc />
	public class ProtobufCacheSerializer : ICacheSerializer
	{
		private MemoryStream Serialize<T>(T cacheEntry)
		{
			var stream = new MemoryStream();
			Serializer.Serialize(stream, cacheEntry);
			stream.Seek(0, SeekOrigin.Begin);
			return stream;
		}

		/// <inheritdoc />
		public MemoryStream SerializeCacheEntry<T>(DateTime expiry, T? value)
		{
			var cacheEntry = new ProtobufCacheEntry<T>
			{
				Expiry = expiry,
				Value = value
			};

			return Serialize(cacheEntry);
		}

		public ICacheEntry<T> DeserializeCacheEntry<T>(MemoryStream stream)
		{
			return Serializer.Deserialize<ProtobufCacheEntry<T>>(stream);
		}
	}
}
