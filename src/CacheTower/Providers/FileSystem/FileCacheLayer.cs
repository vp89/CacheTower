using System.IO;

namespace CacheTower.Providers.FileSystem
{
    public class FileCacheLayer : FileCacheLayerBase<ManifestEntry>
    {
        private ICacheSerializer Serializer { get; }

        public FileCacheLayer(string directoryPath, string? fileExtension, ICacheSerializer serializer) : base(directoryPath, fileExtension)
        {
            Serializer = serializer;
        }

        protected override T Deserialize<T>(MemoryStream stream)
        {
            return Serializer.DeserializeObject<T>(stream);
        }

        protected override MemoryStream Serialize<T>(T value)
        {
            return Serializer.SerializeObject(value);
        }
    }
}