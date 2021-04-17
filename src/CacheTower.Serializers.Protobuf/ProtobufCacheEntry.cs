using System;
using ProtoBuf;

namespace CacheTower.Serializers.Protobuf
{
    [ProtoContract]
    public class ProtobufCacheEntry<T> : ICacheEntry<T>
    {
        [ProtoMember(1)]
        public DateTime Expiry { get; set; }

        [ProtoMember(2)]
        public T? Value { get; set; }
    }
}