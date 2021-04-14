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

        protected override T Deserialize<T>(Stream stream)
        {
            return Serializer.DeserializeObject<T>(stream);
        }

        protected override Stream Serialize<T>(T value)
        {
            return Serializer.SerializeObject(value);
        }
    }
}