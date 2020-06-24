using Microsoft.Extensions.Logging;
using StockAnalyzerService.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace StockAnalyzerService.Service {
	public class StockAnalyzer : IStockAnalyzer {
		private IHttpClientFactory clientFactory;
		private IHttpCalls httpCalls;
		private ILogger _logger;
		private string _apiKey;
		public StockAnalyzer(IHttpClientFactory _clientFactory, 
							 IHttpCalls _httpCalls, 
							 ILogger<StockAnalyzer> logger,
							 IConfiguration configuration) {
			clientFactory = _clientFactory;
			httpCalls = _httpCalls;
			_logger = logger;
			_apiKey = configuration["VantageApiKey"];
		}

		public async Task<List<StockMetadata>> GetStocksWithUsers() {

			try {
				string urlParameters = "stocks/users";
				HttpClient stockAnalyzerClient = clientFactory.CreateClient("stockAnalyzer");
				return await httpCalls.Get<List<StockMetadata>>(stockAnalyzerClient, urlParameters);
			} catch (Exception ex) {
				_logger.LogError(ex, "An error was thrown trying to get a list of stocks with users");
				return new List<StockMetadata>();
			}
		}

		public async Task<IEnumerable<Candlestick>> GetStockCandlestickData(StockMetadata stock)
		{
			try
			{
				HttpClient vantageApi = clientFactory.CreateClient("vantageApi");
				var httpParams = new Dictionary<string, string>() {
					{ "function", "TIME_SERIES_INTRADAY" },
					{ "symbol", stock.Ticker},
					{ "interval", "60min" },
					{ "apikey", _apiKey},
					{ "datatype", "csv"}
				};
				var candlestickData = await httpCalls.GetFromCsv<Candlestick>(vantageApi, httpParams);
				return candlestickData;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while retrieving data from vantage");
				return new List<Candlestick>();
			}
		}

		public void PostCandlestickData(StockCandlestickViewModel candlestickData)
		{
			HttpClient client = clientFactory.CreateClient("stockAnalyzer");
			httpCalls.Post<StockCandlestickViewModel>(client, "stocks/analysis-data", candlestickData);
		}
	}
}
