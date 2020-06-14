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
		public StockAnalyzer(IHttpClientFactory _clientFactory, IHttpCalls _httpCalls) {
			clientFactory = _clientFactory;
			httpCalls = _httpCalls;
		}

		public async Task<List<StockMetadata>> GetStocksWithUsers() {
			try {
				string urlParameters = "stock/user";
				HttpClient stockAnalyzerClient = clientFactory.CreateClient("stockAnalyzer");
				return await httpCalls.Get<List<StockMetadata>>(stockAnalyzerClient, urlParameters);
			} catch {
				return null;
			}
		}
	}
}
