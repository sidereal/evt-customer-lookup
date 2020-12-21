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
    public partial class CustomerLookupContext : ICustomerLookupContext
    {
        public async Task<List<Statistics>> GetStatistics01ByCustomerIdAsync(string customerId)
        {
                var connString = _config.GetConnectionString("RAsty_exp_edm");
                using (var conn = new SqlConnection(connString))
                {
                    var result = await conn.QueryAsync<Statistics>("dbo.Lookup_Statistics01_GetByCustomerId @CustomerId", new { CustomerId = customerId });
                    return result.ToList();
                }
           
        }

        public async Task<List<Statistics>> GetStatistics04ByCustomerIdAsync(string customerId)
        {
            var connString = _config.GetConnectionString("RAsty_exp_edm");
            using (var conn = new SqlConnection(connString))
            {
                var result = await conn.QueryAsync<Statistics>("dbo.Lookup_Statistics04_GetByCustomerId @CustomerId", new { CustomerId = customerId });
                return result.ToList();
            }

        }

        public async Task<List<Statistics>> GetStatistics05ByCustomerIdAsync(string customerId)
        {
            var connString = _config.GetConnectionString("RAsty_exp_edm");
            using (var conn = new SqlConnection(connString))
            {
                var result = await conn.QueryAsync<Statistics>("dbo.Lookup_Statistics05_GetByCustomerId @CustomerId", new { CustomerId = customerId });
                return result.ToList();
            }

        }

        public async Task<List<Statistics>> GetStatistics06ByCustomerIdAsync(string customerId)
        {
            var connString = _config.GetConnectionString("RAsty_exp_edm");
            using (var conn = new SqlConnection(connString))
            {
                var result = await conn.QueryAsync<Statistics>("dbo.Lookup_Statistics06_GetByCustomerId @CustomerId", new { CustomerId = customerId });
                return result.ToList();
            }

        }




    }
}