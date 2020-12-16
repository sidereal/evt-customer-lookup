using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

using Serilog;

using CustomerLookup.Contracts;
using CustomerLookup.Cache;
using CustomerLookup.Models;
using CustomerLookup.Business;


public class Executor
{
    private readonly ILogger<Executor> _logger;
    private readonly IConfiguration _config;
    private readonly ICustomerLookupCache _cache;
    private readonly CustomerLookupBusiness _businessLogic;

    public Executor(ILogger<Executor> logger, IConfiguration config, ICustomerLookupCache customerLookupCache , CustomerLookupBusiness customerLookupBusiness)
    {
        _logger = logger;
        _config = config;
        _cache = customerLookupCache;
        _businessLogic = customerLookupBusiness;
        _logger = logger;
    }
    public async Task Testing01Async()
    {
        _logger.LogInformation("RUNNING");

        SimpleTestModel test1 = new SimpleTestModel() { MyIndex = 1, MyValue = "hello" };
        SimpleTestModel test2 = new SimpleTestModel() { MyIndex = 2, MyValue = "there" };
        SimpleTestModel test3 = new SimpleTestModel() { MyIndex = 3, MyValue = "general" };
        SimpleTestModel test4 = new SimpleTestModel() { MyIndex = 4, MyValue = "kenobi" };

        await _cache.SetCacheValueAsync<SimpleTestModel>("test1", test1);
        await _cache.SetCacheValueAsync<SimpleTestModel>("test2", test2);
        var x = await _cache.GetCacheValueAsync<SimpleTestModel>("test1");
        _logger.LogInformation($"{x.MyIndex}...{x.MyValue}");
        await _cache.SetCacheValueAsync<SimpleTestModel>("test1", test3);
        var y = await _cache.GetCacheValueAsync<SimpleTestModel>("test1");
        _logger.LogInformation($"{y.MyIndex}...{y.MyValue}");

        //await _customerLookupCache.SetCacheValueAsync("hello", "general");
        //_logger.LogInformation(await _customerLookupCache.GetCacheValueAsync("hello"));
        //int i = 99;
        //await _customerLookupCache.SetCacheValue2Async<int>("hello", i);
        //_logger.LogInformation(await _customerLookupCache.GetCacheValueAsync("hello"));

    }

    public void Testing02()
    {
        var customer = "380000000000000082461";
        _logger.LogInformation("RUNNING");
        var x = _businessLogic.GetCustomer(customer);
        if(x is not null) _logger.LogInformation($"{x.CUSTOMER_ID}...{x.CUST_BIRTH_DATE}");

        //380000000000000082461
    }

    public async Task Testing03Async()
    {
        var customer = "380000000000000082461";
        _logger.LogInformation("RUNNING");
        var x = await _businessLogic.GetCustomerAsync(customer);
        if (x is not null) _logger.LogInformation($"{x.CUSTOMER_ID}...{x.CUST_BIRTH_DATE}");
    }
}