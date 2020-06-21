using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockAnalyzerService.Service {
    public interface IHttpCalls {
        Task<T> Get<T>(HttpClient httpClient, string urlParameters);
        Task<IEnumerable<T>> GetFromCsv<T>(HttpClient httpClient, Dictionary<string, string> urlParameters);
    }
}
