using System.Threading.Tasks;

namespace CustomerLookup.Contracts
{
    public interface ICustomerLookupCache
    {
        //Task<string> GetCacheValueAsync(string key);

        //Task SetCacheValueAsync(string key, string value);

        Task SetCacheValueAsync<T>(string key, T value, string prefix="");

        Task<T> GetCacheValueAsync<T>(string key, string prefix="");

        void SetCacheValue<T>(string key, T value, string prefix="");

        T GetCacheValue<T>(string key, string prefix="");
    }
}
