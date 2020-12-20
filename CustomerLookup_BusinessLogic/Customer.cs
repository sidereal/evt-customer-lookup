
using Microsoft.Extensions.Logging;

using CustomerLookup.Models.DataModels;
using CustomerLookup.Models.Dto;
using System.Threading.Tasks;



namespace CustomerLookup.BusinessLogic
{
    public partial class CustomerLookupBusinessLogic
    {

        public CustomerDto GetCustomer(string customerId)
        {
            var result = _cache.GetCacheValue<Customer>(customerId);

            if (result is null)
            {
                result = _context.GetCustomerByCustomerIdAsync(customerId).Result;
                if (result is not null)
                {
                    _cache.SetCacheValue(customerId, result);
                    _logger.LogInformation($"DB Hit for customer: {customerId}");
                }
                else _logger.LogInformation($"No Hit for customer: {customerId}");
            }
            else _logger.LogInformation($"Cache Hit for customer: {customerId}");

            return _mapper.Map<CustomerDto>(result);
        }

        public async Task<CustomerDto> GetCustomerAsync(string customerId)
        {
            var result = await _cache.GetCacheValueAsync<Customer>(customerId);

            if (result is null)
            {
                result = await _context.GetCustomerByCustomerIdAsync(customerId);
                if (result is not null)
                {
                    _cache.SetCacheValueAsync(customerId, result);
                    _logger.LogInformation($"DB Hit for customer: {customerId}");
                }
                else _logger.LogInformation($"No Hit for customer: {customerId}");
            }
            else _logger.LogInformation($"Cache Hit for customer: {customerId}");

            return _mapper.Map<CustomerDto>(result);

        }
    }
}
