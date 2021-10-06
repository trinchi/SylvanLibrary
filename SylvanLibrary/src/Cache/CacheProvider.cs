#nullable enable
using System;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace SylvanLibrary.Cache
{
    public abstract class CacheProvider
    {
        protected virtual int DEFAULT_TTL => 50;

        protected abstract IDistributedCache _cache { get; set; }

        public virtual T? Get<T>(string key) where T : class
        {
            byte[] cachedValueBytes = _cache.Get(key);
            if (cachedValueBytes == null) return null;

            string cachedValueStr = Encoding.UTF8.GetString(cachedValueBytes);
            if (typeof(T) == typeof(string))
            {
                return cachedValueStr as T;
            }

            return JsonConvert.DeserializeObject<T>(cachedValueStr);
        }

        public virtual void Set(string key, string value, int ttl)
        {
            _cache.Set(key, Encoding.UTF8.GetBytes(value), new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now + TimeSpan.FromSeconds(ttl)
            });
        }

        public void Set(string key, string value)
        {
            Set(key, value, DEFAULT_TTL);
        }

        public virtual void Set(string key, object value, int ttl)
        {
            string serializedValue = JsonConvert.SerializeObject(value);
            Set(key, serializedValue, ttl);
        }

        public virtual void Set(string key, object value)
        {
            Set(key, value, DEFAULT_TTL);
        }

        public virtual void Refresh(string key)
        {
            _cache.Refresh(key);
        }

        public virtual void Delete(string key)
        {
            _cache.Remove(key);
        }
    }
}