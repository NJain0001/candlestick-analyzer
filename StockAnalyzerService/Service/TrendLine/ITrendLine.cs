using System.Collections.Generic;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {
    public interface ITrendLine {
        List<double> CalculateTrendLine(List<Candlestick> candlesticks);
        string EvaluateTrendLine(List<Candlestick> candlesticks, List<double> trendLine);
    }
}