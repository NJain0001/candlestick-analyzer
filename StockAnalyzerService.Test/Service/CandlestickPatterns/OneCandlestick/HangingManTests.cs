using System;
using StockAnalyzerService.Model;
using StockAnalyzerService.Service;
using Xunit;

namespace StockAnalyzerService.Test.Service {
    public class HangingManTests {
        private HangingMan _hangingMan;

        public HangingManTests() {
            _hangingMan = new HangingMan();
        }

        [Fact]
        public void Should_ReturnCandlestickAnalysisObject_WhenAllConditionsAreMet() {
            //Arrange
            var timestamp = DateTime.Now;
            var candlestick = new Candlestick() {
                HighPrice = 9.00,
                LowPrice = 1.25,
                OpenPrice = 9.50,
                ClosePrice = 9.00,
                Timestamp = timestamp
            };
            var expectedValue = new CandlestickAnalysis() {
                Ticker = "MSFT",
                Timestamp = timestamp,
                Pattern = "Hanging Man",
                Action = StockAction.Sell
            };

            //Act
            var analysis = _hangingMan.Apply(candlestick, "MSFT");

            //Assert
            Assert.Equal(expectedValue.Ticker, analysis.Ticker);
            Assert.Equal(expectedValue.Timestamp, analysis.Timestamp);
            Assert.Equal(expectedValue.Pattern, analysis.Pattern);
            Assert.Equal(expectedValue.Action, analysis.Action);
        }

        [Fact]
        public void Should_ReturnNull_WhenBodyIsTooLarge() {
            //Arrange
            var candlestick = new Candlestick() {
                HighPrice = 10.00,
                LowPrice = 1.25,
                OpenPrice = 9.50,
                ClosePrice = 5.00,
                Timestamp = DateTime.Now
            };

            //Act
            var analysis = _hangingMan.Apply(candlestick, "MSFT");

            //Assert
            Assert.Null(analysis);
        }

        [Fact]
        public void Should_ReturnNull_WhenUpperWickIsTooLarge() {
            //Arrange
            var candlestick = new Candlestick() {
                HighPrice = 10.00,
                LowPrice = 0.25,
                OpenPrice = 9.00,
                ClosePrice = 8.50,
                Timestamp = DateTime.Now
            };

            //Act
            var analysis = _hangingMan.Apply(candlestick, "MSFT");

            //Assert
            Assert.Null(analysis);
        }
    }
}