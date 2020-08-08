using System;
using System.Collections.Generic;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Test.Service {
    public class CandlestickFixture : IDisposable {
        public List<Candlestick> upTrendCandlesticks;
        public List<Candlestick> downTrendCandlesticks;
        public List<Candlestick> flatTrendCandlesticks;
        public List<double> upwardTrendLine;
        public List<double> downwardTrendLine;
        public List<double> flatTrendLine;
        public CandlestickFixture() {
            upTrendCandlesticks = new List<Candlestick>();
            downTrendCandlesticks = new List<Candlestick>();
            flatTrendCandlesticks = new List<Candlestick>();
            upwardTrendLine = new List<double>();
            downwardTrendLine = new List<double>();
            flatTrendLine = new List<double>();
        }

        public void Dispose() {

        }
    }
}