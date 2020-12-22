
using System.Collections.Generic;
using System.Threading.Tasks;

using CustomerLookup.Contracts;
using CustomerLookup.Models.DataModels;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;



namespace CustomerLookup.BusinessLogic
{
    public partial class CustomerLookupBusinessLogic
    {

        async Task PrecacheAsync(string customerId)
        {

            var customerTask = _context.GetCustomerByCustomerIdAsync(customerId).ContinueWith((t) =>
            {
                    _logger.LogInformation("customer started");
                    _cache.SetCacheValueAsync(customerId, t.Result);
                    _logger.LogInformation("customer done");
            });

            var agreementsTask = _context.GetAgreementsByCustomerIdAsync(customerId).ContinueWith((t) =>
            {
                _logger.LogInformation("agreements started");
                _cache.SetCacheValueAsync(customerId, t.Result, agreementPrefix);
                _logger.LogInformation("agreements done");
            });

            var txnTask = _context.GetTxnByCustomerIdAsync(customerId).ContinueWith((t) =>
            {
                _logger.LogInformation("txn started");
                _cache.SetCacheValueAsync(customerId, t.Result, txnPrefix);
                _logger.LogInformation("txn done");
            });


            var stats01Task = _context.GetStatistics01ByCustomerIdAsync(customerId).ContinueWith((t) =>
            {
                _logger.LogInformation("stats01 started");
                _cache.SetCacheValueAsync(customerId, t.Result, StatisticsTypes.s01.ToString());
                _logger.LogInformation("stats01 done");
            });

            var stats04Task = _context.GetStatistics04ByCustomerIdAsync(customerId).ContinueWith((t) =>
            {
                _logger.LogInformation("stats04 started");
                _cache.SetCacheValueAsync(customerId, t.Result, StatisticsTypes.s04.ToString());
                _logger.LogInformation("stats04 done");
            });

            var stats05Task = _context.GetStatistics05ByCustomerIdAsync(customerId).ContinueWith((t) =>
            {
                _logger.LogInformation("stats05 started");
                _cache.SetCacheValueAsync(customerId, t.Result, StatisticsTypes.s05.ToString());
                _logger.LogInformation("stats05 done");
            });


            var stats06Task = _context.GetStatistics06ByCustomerIdAsync(customerId).ContinueWith((t) =>
            {
                _logger.LogInformation("stats06 started");
                _cache.SetCacheValueAsync(customerId, t.Result, StatisticsTypes.s06.ToString());
                _logger.LogInformation("stats06 done");
            });

            await Task.WhenAll(customerTask, agreementsTask, txnTask, stats01Task, stats04Task, stats05Task, stats06Task);
            _logger.LogInformation("all done");
        }
    }
}
