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
            upTrendCandlesticks = populateUpTrendCandlesticks();
            downTrendCandlesticks = populateDownTrendCandlesticks();
            flatTrendCandlesticks = populateFlatTrendCandlesticks();
            upwardTrendLine = populateUpwardTrendLine();
            downwardTrendLine = populateDownwardTrendLine();
            flatTrendLine = populateFlatwardTrendLine();
        }

        public void Dispose() {

        }

        public List<Candlestick> populateUpTrendCandlesticks() {
            List<Candlestick> returnList = new List<Candlestick>();
            for (int i = 0; i < 400; i++) {
                Candlestick candlestick = new Candlestick() {
                    OpenPrice = i / 2.0,
                    ClosePrice = i / 2.0,
                    HighPrice = i / 2.0,
                    LowPrice = i / 2.0
                };

                returnList.Add(candlestick);
            }

            return returnList;
        }

        public List<Candlestick> populateDownTrendCandlesticks() {
            List<Candlestick> returnList = new List<Candlestick>();
            for (int i = 400; i > 0; i--) {
                Candlestick candlestick = new Candlestick() {
                    OpenPrice = i / 2.0,
                    ClosePrice = i / 2.0,
                    HighPrice = i / 2.0,
                    LowPrice = i / 2.0
                };

                returnList.Add(candlestick);
            }

            return returnList;
        }

        public List<Candlestick> populateFlatTrendCandlesticks() {
            List<Candlestick> returnList = new List<Candlestick>();
            for (int i = 0; i < 400; i++) {
                Candlestick candlestick = new Candlestick() {
                    OpenPrice = i / 3.0,
                    ClosePrice = i / 3.0,
                    HighPrice = i / 3.0,
                    LowPrice = i / 3.0
                };

                returnList.Add(candlestick);
            }

            return returnList;
        }

        public List<double> populateUpwardTrendLine() {
            List<double> returnList = new List<double>();
            for (double i = 0.0; i <= 100.0; i+=.5) {
                returnList.Add(i+49.75);
            }

            return returnList;
        }

        public List<double> populateDownwardTrendLine() {
            List<double> returnList = new List<double>();
            for (double i = 100.0; i >= 0.0; i-=.5) {
                returnList.Add(i+49.75);
            }

            return returnList;
        }

        public List<double> populateFlatwardTrendLine() {
            List<double> returnList = new List<double>();
            for (double i = 0.0; i <= 100.0; i+=.5) {
                returnList.Add(45.00);
            }

            return returnList;
        }
    }
}