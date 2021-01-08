using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CustomerLookup.Models.DataModels;
using CustomerLookup.Models.Dto;

using Microsoft.Extensions.Logging;

namespace CustomerLookup.BusinessLogic
{
    public partial class CustomerLookupBusinessLogic
    {
        public async Task<List<StatisticDto>> GetStatsByTypeAsync(string customerId, StatisticsTypes type)
        {

            string prefix = type.ToString();

            var result = await _cache.GetCacheValueAsync<List<Statistics>>(customerId, prefix);

            if (result is null)
            {
                switch (type)
                {
                    case StatisticsTypes.s01:
                        result = await _context.GetStatistics01ByCustomerIdAsync(customerId);
                        break;
                    case StatisticsTypes.s04:
                        result = await _context.GetStatistics04ByCustomerIdAsync(customerId);
                        break;
                    case StatisticsTypes.s05:
                        result = await _context.GetStatistics05ByCustomerIdAsync(customerId);
                        break;
                    case StatisticsTypes.s06:
                        result = await _context.GetStatistics06ByCustomerIdAsync(customerId);
                        break;
                    default:
                        return null;
                }

                if (result.Count > 0)
                {
                    //_cache.SetCacheValueAsync(customerId, result, prefix);
                    _logger.LogInformation($"Stats {prefix} > DB Hit for customer: {customerId}");
                    _ = PrecacheAsync(customerId);
                }
                else _logger.LogInformation($"Stats {prefix} > No Hit for customer: {customerId}");
            }
            else _logger.LogInformation($"Stats {prefix} > Cache Hit for customer: {customerId}");

            return _mapper.Map<List<StatisticDto>>(result);
        }
    }

    public enum StatisticsTypes { s01 = 1, s04 = 4, s05 = 5, s06 = 6 }
}

