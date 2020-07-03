using System;
using StockAnalyzerService.Model;
using StockAnalyzerService.Service;
using Xunit;

namespace StockAnalyzerService.Test.Service {
    public class InvertedHammerTests {
        private InvertedHammer _invertedHammer;

        public InvertedHammerTests() {
            _invertedHammer = new InvertedHammer();
        }

        [Fact]
        public void Should_ReturnCandlestickAnalysisObject_WhenAllConditionsAreMet() {
            //Arrange
            var timestamp = DateTime.Now;
            var candlestick = new Candlestick() {
                HighPrice = 10.00,
                LowPrice = 1.25,
                OpenPrice = 1.50,
                ClosePrice = 3.00,
                Timestamp = timestamp
            };

            var expectedValue = new CandlestickAnalysis() {
                Ticker = "MSFT",
                Timestamp = timestamp,
                Pattern = "Inverted Hammer",
                Action = StockAction.Buy
            };

            //Act
            var analysis = _invertedHammer.Apply(candlestick, "MSFT");

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
                OpenPrice = 1.50,
                ClosePrice = 5.00,
                Timestamp = DateTime.Now
            };

            //Act
            var analysis = _invertedHammer.Apply(candlestick, "MSFT");

            //Assert
            Assert.Null(analysis);
        }

        [Fact]
        public void Should_ReturnNull_WhenLowerWickIsTooLarge() {
            //Arrange
            var candlestick = new Candlestick() {
                HighPrice = 10.00,
                LowPrice = 0.25,
                OpenPrice = 1.50,
                ClosePrice = 3.00,
                Timestamp = DateTime.Now
            };

            //Act
            var analysis = _invertedHammer.Apply(candlestick, "MSFT");

            //Assert
            Assert.Null(analysis);
        }
    }
}