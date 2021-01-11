using System.IO;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using Microsoft.Extensions.DependencyInjection;

using Serilog;

using CustomerLookup.Contracts;
using CustomerLookup.Cache;
using CustomerLookup.BusinessLogic;
using CustomerLookup.Context;
using CustomerLookup.Models.Maps;
using AutoMapper;



var builder = new ConfigurationBuilder();
BuildConfig(builder);

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Build())
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();


Log.Logger.Information("Launching");


var host = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
{
    services.AddTransient<Executor>();
    services.AddAutoMapper(cfg =>
    {
        cfg.AddProfile<CustomerProfile>();
        cfg.AddProfile<TxnProfile>();
        cfg.AddProfile<AgreementProfile>();
        cfg.AddProfile<StatisticProfile>();
    });
    services.AddSingleton<ICustomerLookupCache, CustomerLookupCache>();
    services.AddSingleton<ICustomerLookupContext, CustomerLookupContext>();
    services.AddSingleton<CustomerLookupBusinessLogic>();
    //services.AddDistributedMemoryCache();
    services.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = context.Configuration.GetValue<string>("RedisConnection");
        options.InstanceName = context.Configuration.GetValue<string>("RedisPrefix");
    });

}).UseSerilog().Build();



var executor = ActivatorUtilities.CreateInstance<Executor>(host.Services);
await executor.Testing06Async();
//executor.Testing02();


static void BuildConfig(IConfigurationBuilder builder)
{
    builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
}