using System.Collections.Generic;
using System.Threading.Tasks;

using CustomerLookup.Models.DataModels;
 
namespace CustomerLookup.Contracts
{
    public interface ICustomerLookupContext
    {
        Task<Customer> GetCustomerByCustomerIdAsync(string customerId);
        
        Task<List<Txn>> GetTxnByCustomerIdAsync(string customerId);
        Task<List<Txn>> GetTxnPageByCustomerIdAsync(string customerId, int page, int size);
        Task<List<Agreement>> GetAgreementsByCustomerIdAsync(string customerId);

        Task<List<Statistics>> GetStatistics01ByCustomerIdAsync(string customerId);
        Task<List<Statistics>> GetStatistics04ByCustomerIdAsync(string customerId);
        Task<List<Statistics>> GetStatistics05ByCustomerIdAsync(string customerId);
        Task<List<Statistics>> GetStatistics06ByCustomerIdAsync(string customerId);
    }
}