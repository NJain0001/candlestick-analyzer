using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockAnalyzerService.Service {
    public class HttpCalls: IHttpCalls {
        public HttpCalls() { }

        public async Task<T> Get<T>(HttpClient httpClient, string urlParameters) {
            try {
                string url = httpClient.BaseAddress + urlParameters;
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode) {
                    return await response.Content.ReadAsAsync<T>();
                }
                return default;
            } catch {
                return default;
            }

        }
    }
}
