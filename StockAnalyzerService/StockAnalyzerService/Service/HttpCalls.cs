using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace StockAnalyzerService.Service {
    public class HttpCalls: IHttpCalls {

        private readonly ILogger _logger;
        public HttpCalls(ILogger<HttpCalls> logger) {
            _logger = logger;
        }

        public async Task<T> Get<T>(HttpClient httpClient, string urlParameters) {
            string url = httpClient.BaseAddress + urlParameters;
            try {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode) {
                    return await response.Content.ReadAsAsync<T>();
                }
                return default;
            } catch (Exception ex) {
                _logger.LogError(ex, $"Error when making a http GET call to {url}");
                throw;
            }

        }
    }
}
