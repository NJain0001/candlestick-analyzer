using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StockAnalyzerService.Service;
using Serilog;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace StockAnalyzerService {
    public class Program {
        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) {
            var host = Host.CreateDefaultBuilder(args);
            host = ConfigureLogging(host);
            host = ConfigureServices(host);
            return host.UseWindowsService();
        }

        public static IHostBuilder ConfigureLogging(IHostBuilder host) {
            return host.ConfigureLogging(configureLogging => {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger();
            });
        }

        public static IHostBuilder ConfigureServices(IHostBuilder host) {
            return host.ConfigureServices((hostContext, services) => {
                services.AddHostedService<Worker>();
                services.AddLogging(l => l.AddSerilog());
                services.AddHttpClient("stockAnalyzer", c => {
                    c.BaseAddress = new Uri("http://localhost:3000/api/");
                    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                });
                services.AddSingleton<IStockAnalyzer, StockAnalyzer>();
                services.AddSingleton<IHttpCalls, HttpCalls>();
            });
        }
    }
}
