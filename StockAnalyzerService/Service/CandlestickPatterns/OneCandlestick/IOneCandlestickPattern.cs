using System;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {
    public interface IOneCandlestickPattern {
        Boolean Apply(Candlestick candlestick);
    }
}