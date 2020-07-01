using System;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {

    public interface ITwoCandlestickPattern
    {
        Boolean Apply(Candlestick firstCandle, Candlestick secondCandle);
    }
}