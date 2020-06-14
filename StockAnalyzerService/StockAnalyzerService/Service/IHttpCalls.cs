using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzerService.Service {
    public interface IHttpCalls {
        Task<T> Get<T>(HttpClient httpClient, string urlParameters);
    }
}
