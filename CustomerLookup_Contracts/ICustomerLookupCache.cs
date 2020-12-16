using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLookup.Contracts
{
    public interface ICustomerLookupCache
    {
        //Task<string> GetCacheValueAsync(string key);

        //Task SetCacheValueAsync(string key, string value);

        Task SetCacheValueAsync<T>(string key, T value);

        Task<T> GetCacheValueAsync<T>(string key);

        void SetCacheValue<T>(string key, T value);

        T GetCacheValue<T>(string key);
    }
}
