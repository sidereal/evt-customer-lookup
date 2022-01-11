
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
        string txnCountPrefix = "TxnCount";

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
                if (result.Count > 0)
                {
                    //_ = _cache.SetCacheValueAsync(customerId, result, txnPrefix);
                    _logger.LogInformation($"Txn > DB Hit for customer: {customerId}");
                    _ = PrecacheAsync(customerId);
                }
                else _logger.LogInformation($"Txn > No Hit for customer: {customerId}");
            }
            else _logger.LogInformation($"Txn > Cache Hit for customer: {customerId}");

            return _mapper.Map<List<TxnDto>>(result);
        }

        public async Task<List<TxnDto>> GetTxnPageAsync(string customerId, int page, int size)
        {
            if (page == 0) page = 1; if (size == 0) size = 50;
            
            var result = await _cache.GetCacheValueAsync<List<Txn>>(customerId, txnPrefix);

            if (result is null)
            {
                result = await _context.GetTxnByCustomerIdAsync(customerId);
                if (result.Count > 0)
                {
                    _logger.LogInformation($"Txn > DB Hit for customer: {customerId}");
                    _ = PrecacheAsync(customerId);
                }

                else { _logger.LogInformation($"Txn > No Hit for customer: {customerId}"); return new List<TxnDto>(); }
            }
            else _logger.LogInformation($"Txn > Cache Hit for customer: {customerId}");

            //Handle edge out of range exceptions
            var records = result.Count;

            var maxPages = (records - 1) / size + 1;
            if (maxPages < page) page = maxPages;

            var remaining = records - (size * (page - 1));
            if (remaining < size) size = remaining;

            var pagedResult = result.GetRange(size * (page - 1), size);
            return _mapper.Map<List<TxnDto>>(pagedResult);
        }
    
        public async Task<int> GetTxnCountAsync(string customerId)
        {
            //return await _context.GetTxnCountByCustomerIdAsync(customerId);

            var result = await _cache.GetCacheValueAsync<int>(customerId, txnCountPrefix);

            if (result ==0)
            {
                result = await _context.GetTxnCountByCustomerIdAsync(customerId);
                if (result > 0)
                {
                    //_ = _cache.SetCacheValueAsync(customerId, result, txnPrefix);
                    _logger.LogInformation($"Txn > DB Hit for customer: {customerId}");
                    //_ = PrecacheAsync(customerId);
                }
                else _logger.LogInformation($"Txn > No Hit for customer: {customerId}");
            }
            else _logger.LogInformation($"Txn > Cache Hit for customer: {customerId}");

            return result;
        }    
    }
}
