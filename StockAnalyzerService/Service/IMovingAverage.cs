using System.Collections.Generic;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {
    public interface IMovingAverage {
        double CalculateSMA(List<Candlestick> candlesticks);
    }
}