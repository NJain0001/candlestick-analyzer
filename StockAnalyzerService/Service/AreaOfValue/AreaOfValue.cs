using System;
using System.Collections.Generic;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {
    public class AreaOfValue: IAreaOfValue {
        private IMovingAverage _movingAverage;
        public AreaOfValue(IMovingAverage movingAverage) {
            _movingAverage = movingAverage;
        }
        public bool IsCandlestickInAreaOfValue(List<Candlestick> candlesticks) {
            if (candlesticks.Count != 50) {
                throw new Exception("The list of candlesticks needs to contain only the candlestick being analyzed and the 49 candlesticks before it.");
            }

            var sma = _movingAverage.CalculateSMA(candlesticks);
            double areaOfValueLowerBound = sma * .9;
            double areaOfValueUpperBound = sma * 1.1;

            return (candlesticks[49].ClosePrice >= areaOfValueLowerBound && candlesticks[49].ClosePrice <= areaOfValueUpperBound);
        }
    }
}