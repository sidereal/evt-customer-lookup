
using CustomerLookup.Contracts;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;




using AutoMapper;
using System.Collections.Generic;

namespace CustomerLookup.BusinessLogic
{
    public partial class CustomerLookupBusinessLogic
    {
        private readonly IConfiguration _config;
        private readonly ILogger<CustomerLookupBusinessLogic> _logger;
        private readonly ICustomerLookupContext _context;
        private readonly ICustomerLookupCache _cache;
        private readonly IMapper _mapper;
        private readonly object _cacheLock;
        private readonly HashSet<string> _usersBeingCached;

        public CustomerLookupBusinessLogic(IConfiguration config, ILogger<CustomerLookupBusinessLogic> logger, ICustomerLookupContext context, ICustomerLookupCache cache, IMapper mapper)
        {
            _config = config;
            _logger = logger;
            _context = context;
            _cache = cache;
            _mapper = mapper;
            _cacheLock = new object();
            _usersBeingCached = new HashSet<string>();
        }
    }
}
