using System;
using System.IO;
using ProtoBuf;
using ProtoBuf.Meta;

namespace CacheTower.Providers.FileSystem.Protobuf
{
	/// <remarks>
	/// The <see cref="ProtobufFileCacheLayer"/> uses <a href="https://github.com/protobuf-net/protobuf-net">protobuf-net</a> to serialize and deserialize the cache items to the file system.
	/// <para>
	/// When caching custom types, you will need to <a href="https://github.com/protobuf-net/protobuf-net#1-first-decorate-your-classes">decorate your class</a> with <c>[ProtoContact]</c> and <c>[ProtoMember]</c> attributes per protobuf-net's documentation.
	/// While this can be inconvienent, using protobuf-net ensures high performance and low allocations for serializing.
	/// </para>
	/// </remarks>
	/// <inheritdoc/>
	[Obsolete]
	public class ProtobufFileCacheLayer : FileCacheLayerBase<ProtobufManifestEntry>
	{
		private static readonly object RuntimeTypeLock = new object();

		/// <summary>
		/// Creates a <see cref="ProtobufFileCacheLayer"/>, using the given <paramref name="directoryPath"/> as the location to store the cache.
		/// </summary>
		/// <param name="directoryPath"></param>
		public ProtobufFileCacheLayer(string directoryPath) : base(directoryPath, ".bin")
		{
			lock (RuntimeTypeLock)
			{
				if (!RuntimeTypeModel.Default.IsDefined(typeof(IManifestEntry)))
				{
					RuntimeTypeModel.Default.Add(typeof(IManifestEntry))
						.AddSubType(1, typeof(ProtobufManifestEntry));
				}
			}
		}

		/// <inheritdoc/>
		protected override T Deserialize<T>(MemoryStream stream)
		{
			return Serializer.Deserialize<T>(stream);
		}

		/// <inheritdoc/>
		protected override MemoryStream Serialize<T>(T value)
		{
			var stream = new MemoryStream();
			Serializer.Serialize(stream, value);
			return stream;
		}
	}
}
