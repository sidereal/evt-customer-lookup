﻿using System.Threading.Tasks;
using Microsoft.Extensions.Logging;



namespace CustomerLookup.BusinessLogic
{
    public partial class CustomerLookupBusinessLogic
    {

        private async Task PrecacheAsync(string customerId)
        {
            _logger.LogInformation("Precache customer {customerid} STARTED", customerId);

            
            lock (_cacheLock)
            {
                //check to see if caching for this user is already in progress
                if (_usersBeingCached.Contains(customerId))
                {
                    _logger.LogInformation("Precache customer {customerid} detected caching in process .", customerId);
                    return;
                }
                //set caching status
                _usersBeingCached.Add(customerId);
            }


            _logger.LogInformation("Precache customer {customerid} INFO started", customerId);
            var customerTask = _context.GetCustomerByCustomerIdAsync(customerId).ContinueWith((t) =>
            {
                _cache.SetCacheValueAsync(customerId, t.Result);
                _logger.LogInformation("Precache customer {customerid} INFO done", customerId);
            });


            _logger.LogInformation("Precache customer {customerid} AGREEMENTS started", customerId);
            var agreementsTask = _context.GetAgreementsByCustomerIdAsync(customerId).ContinueWith((t) =>
            {
                _cache.SetCacheValueAsync(customerId, t.Result, agreementPrefix);
                _logger.LogInformation("Precache customer {customerid} AGREEMENTS done", customerId);
            });

            _logger.LogInformation("Precache customer {customerid} TXN started", customerId);
            var txnTask = _context.GetTxnByCustomerIdAsync(customerId).ContinueWith((t) =>
            {
                _cache.SetCacheValueAsync(customerId, t.Result, txnPrefix);
                _logger.LogInformation("Precache customer {customerid} TXN done", customerId);
            });

            _logger.LogInformation("Precache customer {customerid} TXN count started, customerId", customerId);

            var txnCountTask = _context.GetTxnCountByCustomerIdAsync(customerId).ContinueWith((t) =>
            {
                _cache.SetCacheValueAsync(customerId, t.Result, txnCountPrefix);
                _logger.LogInformation("Precache customer {customerid} TXN count done", customerId);
            });

            _logger.LogInformation("Precache customer {customerid} STATS01 started", customerId);
            var stats01Task = _context.GetStatistics01ByCustomerIdAsync(customerId).ContinueWith((t) =>
            {
                _cache.SetCacheValueAsync(customerId, t.Result, StatisticsTypes.s01.ToString());
                _logger.LogInformation("Precache customer {customerid} STATS01 done", customerId);
            });

            _logger.LogInformation("Precache customer {customerid} STATS04 started", customerId);
            var stats04Task = _context.GetStatistics04ByCustomerIdAsync(customerId).ContinueWith((t) =>
            {
                _cache.SetCacheValueAsync(customerId, t.Result, StatisticsTypes.s04.ToString());
                _logger.LogInformation("Precache customer {customerid} STATS04 done", customerId);
            });

            _logger.LogInformation("Precache customer {customerid} STATS05 started", customerId);
            var stats05Task = _context.GetStatistics05ByCustomerIdAsync(customerId).ContinueWith((t) =>
            {
                _cache.SetCacheValueAsync(customerId, t.Result, StatisticsTypes.s05.ToString());
                _logger.LogInformation("Precache customer {customerid} STATS05 done", customerId);
            });

            _logger.LogInformation("Precache customer {customerid} STATS06 started", customerId);
            var stats06Task = _context.GetStatistics06ByCustomerIdAsync(customerId).ContinueWith((t) =>
            {
                _cache.SetCacheValueAsync(customerId, t.Result, StatisticsTypes.s06.ToString());
                _logger.LogInformation("Precache customer {customerid} STATS06 done", customerId);
            });

            await Task.WhenAll(customerTask, agreementsTask, txnTask, txnCountTask, stats01Task, stats04Task, stats05Task, stats06Task);
            
            //clear caching status when we're done
            lock (_cacheLock) _usersBeingCached.Remove(customerId);

            _logger.LogInformation("Precache customer {customerid} ENDED", customerId);
            
        }
    }
}
