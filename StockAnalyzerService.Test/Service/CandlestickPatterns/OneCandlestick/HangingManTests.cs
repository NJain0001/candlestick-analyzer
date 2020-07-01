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
        public void Should_ReturnTrue_WhenAllConditionsAreMet() {
            var candlestick = new Candlestick() {
                HighPrice = 9.00,
                LowPrice = 1.25,
                OpenPrice = 9.50,
                ClosePrice = 9.00,
                Timestamp = DateTime.Now
            };

            var isPatternFound = _hangingMan.Apply(candlestick);

            Assert.True(isPatternFound);
        }

        [Fact]
        public void Should_ReturnFalse_WhenBodyIsTooLarge() {
            var candlestick = new Candlestick() {
                HighPrice = 10.00,
                LowPrice = 1.25,
                OpenPrice = 9.50,
                ClosePrice = 5.00,
                Timestamp = DateTime.Now
            };

            var isPatternFound = _hangingMan.Apply(candlestick);

            Assert.False(isPatternFound);
        }

        [Fact]
        public void Should_ReturnFalse_WhenUpperWickIsTooLarge() {
            var candlestick = new Candlestick() {
                HighPrice = 10.00,
                LowPrice = 0.25,
                OpenPrice = 9.00,
                ClosePrice = 8.50,
                Timestamp = DateTime.Now
            };

            var isPatternFound = _hangingMan.Apply(candlestick);

            Assert.False(isPatternFound);
        }
    }
}