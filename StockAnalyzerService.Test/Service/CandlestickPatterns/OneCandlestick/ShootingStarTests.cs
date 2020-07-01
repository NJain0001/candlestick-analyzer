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
        public void Should_ReturnTrue_WhenAllConditionsAreMet() {
            var candlestick = new Candlestick() {
                HighPrice = 10.00,
                LowPrice = 1.25,
                OpenPrice = 3.00,
                ClosePrice = 1.50,
                Timestamp = DateTime.Now
            };

            var isPatternFound = _shootingStar.Apply(candlestick);

            Assert.True(isPatternFound);
        }

        [Fact]
        public void Should_ReturnFalse_WhenBodyIsTooLarge() {
            var candlestick = new Candlestick() {
                HighPrice = 10.00,
                LowPrice = 1.25,
                OpenPrice = 5.00,
                ClosePrice = 1.50,
                Timestamp = DateTime.Now
            };

            var isPatternFound = _shootingStar.Apply(candlestick);

            Assert.False(isPatternFound);
        }

        [Fact]
        public void Should_ReturnFalse_WhenLowerWickIsTooLarge() {
            var candlestick = new Candlestick() {
                HighPrice = 10.00,
                LowPrice = 0.25,
                OpenPrice = 3.00,
                ClosePrice = 1.50,
                Timestamp = DateTime.Now
            };

            var isPatternFound = _shootingStar.Apply(candlestick);

            Assert.False(isPatternFound);
        }
    }
}