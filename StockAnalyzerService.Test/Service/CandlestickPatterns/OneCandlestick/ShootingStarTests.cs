using System;
using StockAnalyzerService.Model;
using StockAnalyzerService.Service;
using Xunit;

namespace StockAnalyzerService.Test.Service {
    public class ShootingStarTests {
        private ShootingStar _shootingStar;

        public ShootingStarTests() {
            _shootingStar = new ShootingStar();
        }

        [Fact]
        public void Should_ReturnCandlestickAnalysisObject_WhenAllConditionsAreMet() {
            // Arrange
            var timestamp = DateTime.Now;
            var candlestick = new Candlestick() {
                HighPrice = 10.00,
                LowPrice = 1.25,
                OpenPrice = 3.00,
                ClosePrice = 1.50,
                Timestamp = timestamp
            };
            var expectedValue = new CandlestickAnalysis() {
                Ticker = "MSFT",
                Timestamp = timestamp,
                Pattern = "Shooting Star",
                Action = StockAction.Buy
            };

            // Act
            var analysis = _shootingStar.Apply(candlestick, "MSFT");

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
                ClosePrice = 1.50,
                Timestamp = DateTime.Now
            };

            //Act
            var analysis = _shootingStar.Apply(candlestick, "MSFT");

            //Assert
            Assert.Null(analysis);
        }

        [Fact]
        public void Should_ReturnNull_WhenLowerWickIsTooLarge() {
            //Arrange
            var candlestick = new Candlestick() {
                HighPrice = 10.00,
                LowPrice = 0.25,
                OpenPrice = 3.00,
                ClosePrice = 1.50,
                Timestamp = DateTime.Now
            };

            //Act
            var analysis = _shootingStar.Apply(candlestick, "MSFT");

            //Assert
            Assert.Null(analysis);
        }
    }
}