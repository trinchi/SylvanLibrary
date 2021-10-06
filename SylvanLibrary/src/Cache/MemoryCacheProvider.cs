using Microsoft.Extensions.Caching.Distributed;

namespace SylvanLibrary.Cache
{
    public sealed class MemoryCacheProvider : CacheProvider
    {
        protected override IDistributedCache _cache { get; set; }
        
        public MemoryCacheProvider(MemoryDistributedCache cache)
        {
            _cache = cache;
        }

    }
}