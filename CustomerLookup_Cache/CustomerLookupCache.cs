using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        int lifeSpan = 120;

        public CustomerLookupCache(IConfiguration config, ILogger<CustomerLookupCache> logger, IDistributedCache distributedCache)
        {
            _config = config;
            _logger = logger;
            _distributedCache = distributedCache;
        }

        public async Task<T> GetCacheValueAsync<T>(string key)
        {
            var cacheValue = await _distributedCache.GetStringAsync(FullKey(key));
            //return JsonSerializer.Deserialize<T>(cacheValue);
            return cacheValue != null ? JsonSerializer.Deserialize<T>(cacheValue) : default;
        }

        public async Task SetCacheValueAsync<T>(string key, T value)
        {
            var options = new DistributedCacheEntryOptions();
            var cacheValue = JsonSerializer.Serialize(value);
            
            
            options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(lifeSpan);
            await _distributedCache.SetStringAsync(FullKey(key), cacheValue, options);
        }

        public void SetCacheValue<T>(string key, T value)
        {
            var options = new DistributedCacheEntryOptions();
            var cacheValue = JsonSerializer.Serialize(value);
            options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(lifeSpan);
            _distributedCache.SetString(FullKey(key), cacheValue, options);
        }

        public T GetCacheValue<T>(string key)
        {
            var cacheValue = _distributedCache.GetString(FullKey(key));
            
            return cacheValue !=null ? JsonSerializer.Deserialize<T>(cacheValue):default;
        }

        //public async Task SetCacheValueAsync(string key, string value)
        //{
        //    var options = new DistributedCacheEntryOptions();
        //    options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60);
        //    await _distributedCache.SetStringAsync(key, value, options);
        //}

        string FullKey(string key)
        {
            var dateStamp = DateTime.Now.ToString("yyyy.MM.dd");
            return $"{dateStamp}_{key}";

        }


    }
}
