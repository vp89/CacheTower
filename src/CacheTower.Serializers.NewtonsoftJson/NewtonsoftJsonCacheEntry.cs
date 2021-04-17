using System;
using System.Runtime.Serialization;

namespace CacheTower.Serializers.NewtonsoftJson
{
    [DataContract]
    public class NewtonsoftJsonCacheEntry<T> : ICacheEntry<T>
    {
        [DataMember(Name = "expiry")]
        public DateTime Expiry { get; set; }

        [DataMember(Name = "value")]
        public T? Value { get; set; }
    }
}