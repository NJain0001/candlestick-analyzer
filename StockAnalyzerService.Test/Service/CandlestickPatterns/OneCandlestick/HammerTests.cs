using System;
using StockAnalyzerService.Model;
using StockAnalyzerService.Service;
using Xunit;

namespace StockAnalyzerService.Test.Service {
    public class HammerTests {
        private Hammer _hammer;

        public HammerTests() {
            _hammer = new Hammer();
        }

        [Fact]
        public void Should_ReturnCandlestickAnalysisObject_WhenAllConditionsAreMet() {
            //Arrange
            var timestamp = DateTime.Now;
            var candlestick = new Candlestick() {
                HighPrice = 9.00,
                LowPrice = 1.25,
                OpenPrice = 9.00,
                ClosePrice = 9.50,
                Timestamp = timestamp
            };
            var expectedValue = new CandlestickAnalysis() {
                Ticker = "MSFT",
                Timestamp = timestamp,
                Pattern = "Hammer",
                Action = StockAction.Sell
            };

            //Act
            var analysis = _hammer.Apply(candlestick, "MSFT");

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
                OpenPrice = 5.00,
                ClosePrice = 9.50,
                Timestamp = DateTime.Now
            };

            //Act
            var analysis = _hammer.Apply(candlestick, "MSFT");

            //Assert
            Assert.Null(analysis);
        }

        [Fact]
        public void Should_ReturnNull_WhenUpperWickIsTooLarge() {
            //Arrange
            var candlestick = new Candlestick() {
                HighPrice = 10.00,
                LowPrice = 0.25,
                OpenPrice = 8.50,
                ClosePrice = 9.00,
                Timestamp = DateTime.Now
            };

            //Act
            var analysis = _hammer.Apply(candlestick, "MSFT");

            //Assert
            Assert.Null(analysis);
        }
    }
}