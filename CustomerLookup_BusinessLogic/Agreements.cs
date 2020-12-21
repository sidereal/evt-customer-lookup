
using Microsoft.Extensions.Logging;

using CustomerLookup.Models.DataModels;
using CustomerLookup.Models.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CustomerLookup.BusinessLogic
{
    public partial class CustomerLookupBusinessLogic
    {

        string agreementPrefix = "Agreements";

        public List<AgreementDto> GetAllAgreements(string customerId)
        {
            var result = _cache.GetCacheValue<List<Agreement>>(customerId, agreementPrefix);

            if (result is null)
            {
                result = _context.GetAgreementsByCustomerIdAsync(customerId).Result;
                if (result is not null)
                {
                    _cache.SetCacheValue(customerId, result, agreementPrefix);
                    _logger.LogInformation($"Agreements > DB Hit for customer: {customerId}");
                }
                else _logger.LogInformation($"Agreements > No Hit for customer: {customerId}");
            }
            else _logger.LogInformation($"Agreements > Cache Hit for customer: {customerId}");

            return _mapper.Map<List<AgreementDto>>(result);
        }

        public async Task<List<AgreementDto>> GetAllAgreementsAsync(string customerId)
        {
            var result = await _cache.GetCacheValueAsync<List<Agreement>>(customerId, agreementPrefix);

            if (result is null)
            {
                result = await _context.GetAgreementsByCustomerIdAsync(customerId);
                if (result is not null)
                {
                    _cache.SetCacheValueAsync(customerId, result, agreementPrefix);
                    _logger.LogInformation($"Agreements > DB Hit for customer: {customerId}");
                }
                else _logger.LogInformation($"Agreements > No Hit for customer: {customerId}");
            }
            else _logger.LogInformation($"Agreements > Cache Hit for customer: {customerId}");

            return _mapper.Map<List<AgreementDto>>(result);
        }
    }
}
