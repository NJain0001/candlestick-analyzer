using System.Collections.Generic;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {
    public interface ITrendLine {
        double CalculateSMA(List<Candlestick> candlesticks);

        List<double> CalculateTrendLine(List<Candlestick> candlesticks);

        string DirectionOfTrendLine(List<double> trendLine);

        string EvaluateTrendLine(List<Candlestick> candlesticks, List<double> trendLine);
    }
}