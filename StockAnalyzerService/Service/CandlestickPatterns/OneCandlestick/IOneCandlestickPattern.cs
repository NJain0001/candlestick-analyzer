using System;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {
    public interface IOneCandlestickPattern {
        CandlestickAnalysis Apply(Candlestick candlestick, string ticker);
    }
}