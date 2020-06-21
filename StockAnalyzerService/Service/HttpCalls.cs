using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.WebUtilities;
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

        public async Task<IEnumerable<T>> GetFromCsv<T>(HttpClient httpClient, Dictionary<string, string> urlParameters) {

            var url = string.Empty;

            try
            {
                url = QueryHelpers.AddQueryString(httpClient.BaseAddress.ToString(), urlParameters);
                
                using (var reader = new StreamReader(await httpClient.GetStreamAsync(url)))
                {
                    var csvr = new CsvReader(reader, CultureInfo.InvariantCulture);
                    return csvr.GetRecords<T>().ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when making a http GET call to {url}");
                throw;
            }
        }
    }
}
