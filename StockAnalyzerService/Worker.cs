using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StockAnalyzerService.Model;
using StockAnalyzerService.Service;

namespace StockAnalyzerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger _logger;
        private readonly IStockAnalyzer _analyzer;

        public Worker(ILogger<Worker> logger, IStockAnalyzer analyzer)
        {
            _logger = logger;
            _analyzer = analyzer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                StockCandlestickViewModel data = new StockCandlestickViewModel()
                {
                    Ticker = "MSFT",
                    Candlesticks = new List<Candlestick>()
                    {
                        new Candlestick()
                        {
                            HighPrice = 10,
                            LowPrice = 5,
                            ClosePrice = 8,
                            OpenPrice = 3
                        }
                    }
                };

                _analyzer.PostCandlestickData(data);
                
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
