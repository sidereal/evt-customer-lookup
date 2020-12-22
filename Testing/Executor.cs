using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

using Serilog;

using CustomerLookup.Contracts;
using CustomerLookup.Models;
using CustomerLookup.BusinessLogic;
using System;

public class Executor
{
    private readonly ILogger<Executor> _logger;
    private readonly IConfiguration _config;
    private readonly ICustomerLookupCache _cache;
    private readonly CustomerLookupBusinessLogic _businessLogic;

    public Executor(ILogger<Executor> logger, IConfiguration config, ICustomerLookupCache customerLookupCache, CustomerLookupBusinessLogic customerLookupBusiness)
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
        if (x is not null) _logger.LogInformation($"{x.Id}...{x.BirthDate}");

        //380000000000000082461
    }

    public async Task Testing03Async()
    {
        var customer = "380000000000000082461";
        _logger.LogInformation("RUNNING");
        var x = _businessLogic.GetCustomer(customer);
        if (x is not null) _logger.LogInformation($"{x.Id}...{x.BirthDate}");
        var y = await _businessLogic.GetCustomerAsync(customer);
        if (y is not null) _logger.LogInformation($"{y.Id}...{y.BirthDate}");
    }

    public async Task Testing04Async()
    {
        var customer = "380000000000000082461";
        _logger.LogInformation("RUNNING");
        var aa = _businessLogic.GetCustomer(customer);
        if (aa is not null) _logger.LogInformation($"{aa.Id}...{aa.BirthDate}");
        var bb = await _businessLogic.GetCustomerAsync(customer);
        if (bb is not null) _logger.LogInformation($"{bb.Id}...{bb.BirthDate}");
        var cc = await _businessLogic.GetAllTxnAsync(customer);
        if (cc is not null) _logger.LogInformation($"Txn found -> {cc.Count}");
        var dd = await _businessLogic.GetAllTxnAsync(customer);
        if (dd is not null) _logger.LogInformation($"Txn found -> {dd.Count}");

        var ee = await _businessLogic.GetAllAgreementsAsync(customer);
        if (ee is not null) _logger.LogInformation($"Agreements found -> {ee.Count}");
        var ff = await _businessLogic.GetAllAgreementsAsync(customer);
        if (ff is not null) _logger.LogInformation($"Agreements found -> {ff.Count}");

        var gg = await _businessLogic.GetStatsByTypeAsync(customer, StatisticsTypes.s01);
        if (gg is not null) _logger.LogInformation($"Stats 01 found -> {gg.Count}");
        var hh = await _businessLogic.GetStatsByTypeAsync(customer, StatisticsTypes.s04);
        if (hh is not null) _logger.LogInformation($"Stats 04 found -> {hh.Count}");

        var ii = await _businessLogic.GetTxnPageAsync(customer, 1, 2);
        if (ii is not null) _logger.LogInformation($"Txn found -> {ii.Count}");
    }

    public async Task Testing05Async()
    {


        //var customer = "380000000000000082446";
        var customer = "380000000000000082461";
        _logger.LogInformation("RUNNING");

        var x = await _businessLogic.GetAllAgreementsAsync(customer);
        if (x is not null) _logger.LogInformation($"count > {x.Count}");

        _logger.LogInformation("DONE");
        Console.ReadLine();
    }

}
