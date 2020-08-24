using System.Collections.Generic;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {
    public interface IAreaOfValue {
        bool IsCandlestickInAreaOfValue(List<Candlestick> candlesticks);
    }
}