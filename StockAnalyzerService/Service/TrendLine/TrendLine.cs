using System;
using System.Collections.Generic;
using System.Linq;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {
    public class TrendLine {
        public TrendLine() {

        }

        public double CalculateSMA(List<Candlestick> candlesticks) {
            double sum = candlesticks.Sum(candlestick => candlestick.ClosePrice);

            return sum / candlesticks.Count;
        }

        public List<double> CalculateTrendLine(List<Candlestick> candlesticks) {
            List<Candlestick> trendLineCandlesticks = candlesticks.Skip(199).ToList();
            List<double> trendLine = new List<double>();
            foreach (var candlestick in trendLineCandlesticks) {
                trendLine.Add(CalculateSMA(candlesticks.Take(200).ToList()));
                candlesticks.RemoveAt(0);
            }

            return trendLine;
        }

        public string DirectionOfTrendLine(List<double> trendLine) {
            var DateMean = trendLine.Average();
            var ClosePriceMean = (trendLine.Count - 1) / 2;

            double xyDeltaSum = 0.0;
            double xSqauredDeltaSum = 0.0;
            for (int i = 0; i < trendLine.Count; i++) {
                xyDeltaSum += (trendLine[i] - DateMean) * (i - ClosePriceMean);
                xSqauredDeltaSum += Math.Pow(trendLine[i] - DateMean, 2);
            }

            double slope = xyDeltaSum / xSqauredDeltaSum;

            if (slope >= .5) {
                return "Up";
            } else if (slope <= -.5) {
                return "Down";
            } else {
                return "Flat";
            }
        }

        public string EvaluateTrendLine(List<Candlestick> candlesticks, List<double> trendLine) {
            if (candlesticks.Count != trendLine.Count) {
                throw new Exception("Number of candlesticks must match length of trend line.");
            }
            int numOfAbove = 0;
            int numOfBelow = 0;
            for (int i = 0; i < candlesticks.Count; i++) {
                if (candlesticks[i].ClosePrice >= trendLine[i]) {
                    numOfAbove += 1;
                } else {
                    numOfBelow += 1;
                }
            }
            string direction = DirectionOfTrendLine(trendLine);
            if (direction == "Up" && (numOfAbove / trendLine.Count) >= .8) {
                return "Up";
            } else if (direction == "Down" && (numOfBelow / trendLine.Count) >= .8) {
                return "Down";
            }

            return "No Trend";
        }
    }
}