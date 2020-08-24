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
        private Boolean _disposed;
        public CandlestickFixture() {
            upTrendCandlesticks = populateUpTrendCandlesticks();
            downTrendCandlesticks = populateDownTrendCandlesticks();
            flatTrendCandlesticks = populateFlatTrendCandlesticks();
            upwardTrendLine = populateUpwardTrendLine();
            downwardTrendLine = populateDownwardTrendLine();
            flatTrendLine = populateFlatwardTrendLine();
        }

        public void Dispose() 
        {
            Dispose(true);

            // Use SupressFinalize in case a subclass
            // of this type implements a finalizer.
            GC.SuppressFinalize(this);      
        }

        protected virtual void Dispose(bool disposing)
        {
            // If you need thread safety, use a lock around these 
            // operations, as well as in your methods that use the resource.
            if (!_disposed)
            {
                if (disposing) {
                    upTrendCandlesticks.Clear();
                    downTrendCandlesticks.Clear();
                    flatTrendCandlesticks.Clear();
                    upwardTrendLine.Clear();
                    downwardTrendLine.Clear();
                    flatTrendLine.Clear();
                }

                // Indicate that the instance has been disposed.
                _disposed = true;   
            }
        }

        ~CandlestickFixture() {
            Dispose(false);
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