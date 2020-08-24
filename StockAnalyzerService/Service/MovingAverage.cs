using System.Collections.Generic;
using System.Linq;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {
    public class MovingAverage: IMovingAverage {
        public double CalculateSMA(List<Candlestick> candlesticks) {
            double sum = candlesticks.Sum(candlestick => candlestick.ClosePrice);

            return sum / candlesticks.Count;
        }
    }
}