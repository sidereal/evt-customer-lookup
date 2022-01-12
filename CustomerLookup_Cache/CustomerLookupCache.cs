using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using CustomerLookup.Contracts;
using Microsoft.Extensions.Caching.Distributed;

namespace CustomerLookup.Cache
{
    public class CustomerLookupCache : ICustomerLookupCache
    {
        private readonly IConfiguration _config;
        private readonly ILogger<CustomerLookupCache> _logger;
        private readonly IDistributedCache _distributedCache;
        private int _lifeSpan = 24;

        public CustomerLookupCache(IConfiguration config, ILogger<CustomerLookupCache> logger, IDistributedCache distributedCache)
        {
            _config = config;
            _logger = logger;
            _distributedCache = distributedCache;
        }

        public async Task<T> GetCacheValueAsync<T>(string key, string prefix = "")
        {
            var cacheValue = await _distributedCache.GetStringAsync(FullKey(key, prefix));
            //return JsonSerializer.Deserialize<T>(cacheValue);
            return cacheValue != null ? JsonSerializer.Deserialize<T>(cacheValue) : default;
        }

        public async Task SetCacheValueAsync<T>(string key, T value, string prefix = "")
        {
            var options = new DistributedCacheEntryOptions();
            var cacheValue = JsonSerializer.Serialize(value);


            options.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(_lifeSpan);
            await _distributedCache.SetStringAsync(FullKey(key, prefix), cacheValue, options);
        }

        public void SetCacheValue<T>(string key, T value, string prefix = "")
        {
            var options = new DistributedCacheEntryOptions();
            var cacheValue = JsonSerializer.Serialize(value);
            options.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(_lifeSpan);
            _distributedCache.SetString(FullKey(key, prefix), cacheValue, options);
        }

        public T GetCacheValue<T>(string key, string prefix = "")
        {
            var cacheValue = _distributedCache.GetString(FullKey(key, prefix));

            return cacheValue != null ? JsonSerializer.Deserialize<T>(cacheValue) : default;
        }

        //public async Task SetCacheValueAsync(string key, string value)
        //{
        //    var options = new DistributedCacheEntryOptions();
        //    options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);
        //    await _distributedCache.SetStringAsync(key, value, options);
        //}

        private static string FullKey(string key, string prefix = "")
        {
            if (!string.IsNullOrEmpty(prefix)) prefix += "_";
            var dateStamp = DateTime.Now.ToString("yyyy.MM.dd");
            var fullKey = $"{dateStamp}_{prefix}{key}";
            return fullKey;
        }
    }
}
