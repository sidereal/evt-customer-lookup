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


        public async Task<List<Txn>> GetTxnByCustomerIdAsync(string customerId)
        {
            var connString = _config.GetConnectionString("RAsty_exp_edm");
            using (var conn = new SqlConnection(connString))
            {
                var txn = await conn.QueryAsync<Txn>("dbo.Lookup_Txn_GetByCustomerId @CustomerId", new { CustomerId = customerId });
                return txn.ToList();
            }
        }

        public async Task<List<Txn>> GetTxnPageByCustomerIdAsync(string customerId, int page, int size)
        {
            var connString = _config.GetConnectionString("RAsty_exp_edm");
            using (var conn = new SqlConnection(connString))
            {
                var txn = await conn.QueryAsync<Txn>("dbo.Lookup_Txn_GetPageByCustomerId @CustomerId @Page @Size",
                    new { CustomerId = customerId, Page = page, Size = size });
                return txn.ToList();
            }
        }

        public async Task<int> GetTxnCountByCustomerIdAsync(string customerId)
        {
            var connString = _config.GetConnectionString("RAsty_exp_edm");
            var sql = "SELECT COUNT(*) FROM TXN WHERE [CUSTOMER_ID] = @CustomerId";
            using (var conn = new SqlConnection(connString))
            {
                return await conn.QueryFirstOrDefaultAsync<int>(sql, new { CustomerId = customerId });
            }
        }
    }
}

