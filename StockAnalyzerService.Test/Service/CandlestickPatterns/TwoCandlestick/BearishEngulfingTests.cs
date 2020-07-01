using Xunit;
using StockAnalyzerService.Model;
using StockAnalyzerService.Service;
using System;

namespace StockAnalyzerService.Test.Service {

    public class BearishEngulfingTests
    {
        private BearishEngulfing _bearishEngulfing;
        public BearishEngulfingTests()
        {
            _bearishEngulfing = new BearishEngulfing();
        }

        [Fact]
        public void Should_ReturnTrue_WhenAllConditionsMet()
        {
            var firstCandle = new Candlestick()
            {
                HighPrice = 10,
                LowPrice = 2.5,
                OpenPrice = 2.5,
                ClosePrice = 6,
                Timestamp = DateTime.Now
            };
            var secondCandle = new Candlestick()
            {
                HighPrice = 14,
                LowPrice = 2,
                OpenPrice = 11,
                ClosePrice = 2,
                Timestamp = DateTime.Now
            };

            var isPatternFound = _bearishEngulfing.Apply(firstCandle, secondCandle);

            Assert.True(isPatternFound);
        }
    
        [Fact]
        public void Should_ReturnFalse_WhenFirstCandleIsRed()
        {
            var firstCandle = new Candlestick()
            {
                HighPrice = 10,
                LowPrice = 2.5,
                OpenPrice = 6,
                ClosePrice = 2.5,
                Timestamp = DateTime.Now
            };
            var secondCandle = new Candlestick()
            {
                HighPrice = 14,
                LowPrice = 2,
                OpenPrice = 11,
                ClosePrice = 2,
                Timestamp = DateTime.Now
            };

            var isPatternFound = _bearishEngulfing.Apply(firstCandle, secondCandle);

            Assert.False(isPatternFound);
        }
    
        [Fact]
        public void Should_ReturnFalse_WhenSecondCandleIsGreen()
        {
            var firstCandle = new Candlestick()
            {
                HighPrice = 10,
                LowPrice = 2.5,
                OpenPrice = 2.5,
                ClosePrice = 6,
                Timestamp = DateTime.Now
            };
            var secondCandle = new Candlestick()
            {
                HighPrice = 14,
                LowPrice = 2,
                OpenPrice = 2,
                ClosePrice = 11,
                Timestamp = DateTime.Now
            };

            var isPatternFound = _bearishEngulfing.Apply(firstCandle, secondCandle);

            Assert.False(isPatternFound);
        }
    
        [Fact]
        public void Should_ReturnFalse_WhenFirstHighIsGreaterThanSecondOpen()
        {
            var firstCandle = new Candlestick()
            {
                HighPrice = 12,
                LowPrice = 2.5,
                OpenPrice = 2.5,
                ClosePrice = 6,
                Timestamp = DateTime.Now
            };
            var secondCandle = new Candlestick()
            {
                HighPrice = 14,
                LowPrice = 2,
                OpenPrice = 11,
                ClosePrice = 2,
                Timestamp = DateTime.Now
            };

            var isPatternFound = _bearishEngulfing.Apply(firstCandle, secondCandle);

            Assert.False(isPatternFound);
        }
    
        [Fact]
        public void Should_ReturnFalse_WhenFirstLowIsLessThanSecondClose()
        {
            var firstCandle = new Candlestick()
            {
                HighPrice = 10,
                LowPrice = 1.5,
                OpenPrice = 2.5,
                ClosePrice = 6,
                Timestamp = DateTime.Now
            };
            var secondCandle = new Candlestick()
            {
                HighPrice = 14,
                LowPrice = 2,
                OpenPrice = 11,
                ClosePrice = 2,
                Timestamp = DateTime.Now
            };

            var isPatternFound = _bearishEngulfing.Apply(firstCandle, secondCandle);

            Assert.False(isPatternFound);
        }
    
        [Fact]
        public void Should_ReturnFalse_WhenFirstHighIsGreaterThanSecondOpen_And_FirstLowIsLessThanSecondClose()
        {
            var firstCandle = new Candlestick()
            {
                HighPrice = 12,
                LowPrice = 1.5,
                OpenPrice = 2.5,
                ClosePrice = 6,
                Timestamp = DateTime.Now
            };
            var secondCandle = new Candlestick()
            {
                HighPrice = 14,
                LowPrice = 2,
                OpenPrice = 11,
                ClosePrice = 2,
                Timestamp = DateTime.Now
            };

            var isPatternFound = _bearishEngulfing.Apply(firstCandle, secondCandle);

            Assert.False(isPatternFound);
        }
    }
}