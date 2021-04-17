using System;

namespace CacheTower
{
    public interface ICacheEntry<T>
    {
        public DateTime Expiry { get; set; }

        public T? Value { get; set; }
    }
}
