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
        private readonly IConfiguration _config;
        private readonly ILogger<CustomerLookupContext> _logger;

        public CustomerLookupContext(IConfiguration config, ILogger<CustomerLookupContext> logger)
        {
            _config = config;
            _logger = logger;

        }

        
    }
}
