using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;

namespace SylvanLibrary.Cache
{
    public class RedisCacheProvider : CacheProvider
    {
        protected override IDistributedCache _cache { get; set; }
        
        public RedisCacheProvider(RedisCache cache)
        {
            _cache = cache;
        }
        
    }
}