using System;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {

    public interface ITwoCandlestickPattern
    {
        CandlestickAnalysis Apply(Candlestick firstCandle, Candlestick secondCandle, string ticker);
    }
}