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
        public void Should_ReturnTrue_WhenAllConditionsAreMet() {
            var candlestick = new Candlestick() {
                HighPrice = 10.00,
                LowPrice = 1.25,
                OpenPrice = 1.50,
                ClosePrice = 3.00,
                Timestamp = DateTime.Now
            };

            var isPatternFound = _invertedHammer.Apply(candlestick);

            Assert.True(isPatternFound);
        }

        [Fact]
        public void Should_ReturnFalse_WhenBodyIsTooLarge() {
            var candlestick = new Candlestick() {
                HighPrice = 10.00,
                LowPrice = 1.25,
                OpenPrice = 1.50,
                ClosePrice = 5.00,
                Timestamp = DateTime.Now
            };

            var isPatternFound = _invertedHammer.Apply(candlestick);

            Assert.False(isPatternFound);
        }

        [Fact]
        public void Should_ReturnFalse_WhenLowerWickIsTooLarge() {
            var candlestick = new Candlestick() {
                HighPrice = 10.00,
                LowPrice = 0.25,
                OpenPrice = 1.50,
                ClosePrice = 3.00,
                Timestamp = DateTime.Now
            };

            var isPatternFound = _invertedHammer.Apply(candlestick);

            Assert.False(isPatternFound);
        }
    }
}