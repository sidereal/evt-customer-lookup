
using CustomerLookup.Contracts;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;




using AutoMapper;

namespace CustomerLookup.BusinessLogic
{
    public partial class CustomerLookupBusinessLogic
    {
        private readonly IConfiguration _config;
        private readonly ILogger<CustomerLookupBusinessLogic> _logger;
        private readonly ICustomerLookupContext _context;
        private readonly ICustomerLookupCache _cache;
        private readonly IMapper _mapper;

        public CustomerLookupBusinessLogic(IConfiguration config, ILogger<CustomerLookupBusinessLogic> logger, ICustomerLookupContext context, ICustomerLookupCache cache, IMapper mapper)
        {
            _config = config;
            _logger = logger;
            _context = context;
            _cache = cache;
            _mapper = mapper;
        }
    }
}
