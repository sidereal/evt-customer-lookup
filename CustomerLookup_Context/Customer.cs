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
        public async Task<Customer> GetCustomerByCustomerIdAsync(string customerId)
        {
            var connString = _config.GetConnectionString("RAsty_exp_edm");
            using (var conn = new SqlConnection(connString))
            {
                return await conn.QueryFirstOrDefaultAsync<Customer>("dbo.Lookup_Customer_GetByCustomerId @CustomerId", new { CustomerId = customerId });
            }
        }
    }
}
