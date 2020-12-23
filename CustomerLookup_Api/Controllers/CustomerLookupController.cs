using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using CustomerLookup.Models;
using CustomerLookup.BusinessLogic;


namespace CustomerLookup.Api.Controllers
{
    [Route("api/Lookup")]
    [ApiController]
    public class CustomerLookupController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogger<CustomerLookupController> _logger;
        private readonly CustomerLookupBusinessLogic _businessLogic;

        public CustomerLookupController(IConfiguration config, ILogger<CustomerLookupController> logger, CustomerLookupBusinessLogic businessLogic)
        {
            _config = config;
            _logger = logger;
            _businessLogic = businessLogic;
        }

        [HttpGet("customer")]
        public async Task<IActionResult> GetCustomerAsync(string id)
        {

            var customer = await _businessLogic.GetCustomerAsync(id);
            if (customer == null) return NotFound(new { message = $"Customer {id} not found" });

            return Ok(customer);
        }

        [HttpGet("customer/agreements")]
        public async Task<IActionResult> GetCustomerAgreementsAsync(string id)
        {

            var agreements = await _businessLogic.GetAllAgreementsAsync(id);
            if (agreements == null) return NotFound(new { message = $"Agreements for Customer {id} not found" });

            return Ok(agreements);
        }

        [HttpGet("customer/txn")]
        public async Task<IActionResult> GetCustomerTxnAsync(string id)
        {

            var txn = await _businessLogic.GetAllTxnAsync(id);
            if (txn == null) return NotFound(new { message = $"Txn for Customer {id} not found" });

            return Ok(txn);
        }

        [HttpGet("customer/txnpage")]
        public async Task<IActionResult> GetCustomerTxnByPageAsync(string id, int page, int size)
        {

            var txn = await _businessLogic.GetTxnPageAsync(id, page, size);
            if (txn == null) return NotFound(new { message = $"Txn for Customer {id} not found" });

            return Ok(txn);
        }

        [HttpGet("customer/stats")]
        public async Task<IActionResult> GetCustomerStatsAsync(string id, StatisticsTypes type)
        {
            _logger.LogInformation(type.ToString());
            var stats = await _businessLogic.GetStatsByTypeAsync(id, type);
            if (stats == null) return NotFound(new { message = $"Stats for Customer {id} not found" });

            return Ok(stats);
        }

    }
}
