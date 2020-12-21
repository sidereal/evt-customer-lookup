
using Microsoft.Extensions.Logging;

using CustomerLookup.Models.DataModels;
using CustomerLookup.Models.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CustomerLookup.BusinessLogic
{
    public partial class CustomerLookupBusinessLogic
    {

        string txnPrefix = "Txn";

        public List<TxnDto> GetAllTxn(string customerId)
        {
            var result = _cache.GetCacheValue<List<Txn>>(customerId, txnPrefix);

            if (result is null)
            {
                result = _context.GetTxnByCustomerIdAsync(customerId).Result;
                if (result is not null)
                {
                    _cache.SetCacheValue(customerId, result, txnPrefix);
                    _logger.LogInformation($"Txn > DB Hit for customer: {customerId}");
                }
                else _logger.LogInformation($"Txn > No Hit for customer: {customerId}");
            }
            else _logger.LogInformation($"Txn > Cache Hit for customer: {customerId}");

            return _mapper.Map<List<TxnDto>>(result);
        }

        public async Task<List<TxnDto>> GetAllTxnAsync(string customerId)
        {
            var result = await _cache.GetCacheValueAsync<List<Txn>>(customerId, txnPrefix);

            if (result is null)
            {
                result = await _context.GetTxnByCustomerIdAsync(customerId);
                if (result is not null)
                {
                    _cache.SetCacheValueAsync(customerId, result, txnPrefix);
                    _logger.LogInformation($"Txn > DB Hit for customer: {customerId}");
                }
                else _logger.LogInformation($"Txn > No Hit for customer: {customerId}");
            }
            else _logger.LogInformation($"Txn > Cache Hit for customer: {customerId}");

            return _mapper.Map<List<TxnDto>>(result);
        }
    }
}
