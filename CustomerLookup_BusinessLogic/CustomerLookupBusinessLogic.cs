using System;
using System.Collections.Generic;
using System.Text;

using CustomerLookup.Contracts;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using CustomerLookup.Models.DataModels;
using System.Threading.Tasks;

namespace CustomerLookup.BusinessLogic
{
    public class CustomerLookupBusinessLogic
    {
        private readonly IConfiguration _config;
        private readonly ILogger<CustomerLookupBusinessLogic> _logger;
        private readonly ICustomerLookupContext _context;
        private readonly ICustomerLookupCache _cache;

        public CustomerLookupBusinessLogic(IConfiguration config, ILogger<CustomerLookupBusinessLogic> logger, ICustomerLookupContext context, ICustomerLookupCache cache)
        {
            _config = config;
            _logger = logger;
            _context = context;
            _cache = cache;
        }

        public Customer GetCustomer(string customerId)
        {
            var cacheResult = _cache.GetCacheValue<Customer>(customerId);

            if (cacheResult is null)
            {
                var dbResult = _context.GetCustomerByCustomerIdAsync(customerId).Result;
                if (dbResult is not null)
                {
                    _cache.SetCacheValue(customerId, dbResult);
                    _logger.LogInformation($"DB Hit for customer: {customerId}");
                }
                else _logger.LogInformation($"No Hit for customer: {customerId}");
                return dbResult;
            }
            _logger.LogInformation($"Cache Hit for customer: {customerId}");
            return cacheResult;
        }

        public async Task<Customer> GetCustomerAsync(string customerId)
        {
            var cacheResult = await _cache.GetCacheValueAsync<Customer>(customerId);

            if (cacheResult is null)
            {
                var dbResult = await _context.GetCustomerByCustomerIdAsync(customerId);
                if (dbResult is not null)
                {
                    _cache.SetCacheValueAsync(customerId, dbResult);
                    _logger.LogInformation($"DB Hit for customer: {customerId}");
                }
                else _logger.LogInformation($"No Hit for customer: {customerId}");
                return dbResult;
            }
            _logger.LogInformation($"Cache Hit for customer: {customerId}");
            return cacheResult;
        }
    }
}
