using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using serilog_azure_claims_sample.Enrichers;

namespace serilog_azure_claims_sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseSerilog((context, config) =>
              {
                  config.ReadFrom.Configuration(context.Configuration);
                  config.Enrich.WithRole();
                  config.Enrich.FromLogContext();
              })
                .UseStartup<Startup>();
    }
}
