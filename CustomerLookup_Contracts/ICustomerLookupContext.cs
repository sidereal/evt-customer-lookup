using System.Collections.Generic;
using System.Threading.Tasks;

using CustomerLookup.Models.DataModels;
 
namespace CustomerLookup.Contracts
{
    public interface ICustomerLookupContext
    {
        Task<Customer> GetCustomerByCustomerIdAsync(string customerId);
        Task GetStatsByCustomerIdAsync(string customerId);
        Task<List<Txn>> GetTxnByCustomerIdAsync(string customerId);
        Task<List<Agreement>> GetAgreementsByCustomerIdAsync(string customerId);
    }
}