using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Dapper;
using System.Data.SqlClient;

using CustomerLookup.Models.DataModels;
using CustomerLookup.Contracts;

namespace CustomerLookup.Context
{
    public class CustomerLookupContext : ICustomerLookupContext
    {
        private readonly IConfiguration _config;
        private readonly ILogger<CustomerLookupContext> _logger;

        public CustomerLookupContext(IConfiguration config, ILogger<CustomerLookupContext> logger)
        {
            _config = config;
            _logger = logger;

        }

        public async Task<List<Txn>> GetTxnByCustomerIdAsync(string customerId)
        {
            var connString = _config.GetConnectionString("RAsty_exp_edm");
            using (var conn = new SqlConnection(connString))
            {
                var txn = await conn.QueryAsync<Txn>("dbo.Lookup_Txn_GetByCustomerId @CustomerId", new { CustomerId = customerId });
                return txn.ToList();
            }

        }

        public async Task<Customer> GetCustomerByCustomerIdAsync(string customerId)
        {
            var connString = _config.GetConnectionString("RAsty_exp_edm");
            using (var conn = new SqlConnection(connString))
            {
                return await conn.QueryFirstOrDefaultAsync<Customer>("dbo.Lookup_Customer_GetByCustomerId @CustomerId", new { CustomerId = customerId });
            }
        }

        public async Task GetStatsByCustomerIdAsync(string customerId)
        {
            throw new NotImplementedException();
        }
    }
}
