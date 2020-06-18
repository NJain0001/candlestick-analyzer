using Microsoft.Extensions.Logging;
using StockAnalyzerService.Model;
using StockAnalyzerService.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StockAnalyzerService.Service {
	public class StockAnalyzer : IStockAnalyzer {
		public IHttpClientFactory clientFactory;
		public IHttpCalls httpCalls;
		public ILogger _logger;
		public StockAnalyzer(IHttpClientFactory _clientFactory, IHttpCalls _httpCalls, ILogger<StockAnalyzer> logger) {
			clientFactory = _clientFactory;
			httpCalls = _httpCalls;
			_logger = logger;
		}

		public async Task<List<StockMetadata>> GetStocksWithUsers() {
			try {
				string urlParameters = "stock/user";
				HttpClient stockAnalyzerClient = clientFactory.CreateClient("stockAnalyzer");
				return await httpCalls.Get<List<StockMetadata>>(stockAnalyzerClient, urlParameters);
			} catch (Exception ex) {
				_logger.LogError(ex, "An error was thrown trying to get a list of stocks with users");
				return new List<StockMetadata>();
			}
		}
	}
}
