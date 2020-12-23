using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CustomerLookup.BusinessLogic;
using CustomerLookup.Contracts;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;


using CustomerLookup.Cache;
using CustomerLookup.Context;
using AutoMapper;
using CustomerLookup.Models.Maps;
using Serilog;

namespace CustomerLookup.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

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
                options.Configuration = Configuration.GetValue<string>("RedisConnection");
                options.InstanceName = Configuration.GetValue<string>("RedisPrefix");
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerLookup_Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerLookup_Api v1"));
            }

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
