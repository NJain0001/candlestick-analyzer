using Xunit;
using StockAnalyzerService.Model;
using StockAnalyzerService.Service;
using System;

namespace StockAnalyzerService.Test.Service {

    public class BullishEngulfingTests
    {
        private BullishEngulfing _bullingEngulfing;
        public BullishEngulfingTests()
        {
            _bullingEngulfing = new BullishEngulfing();
        }
        [Fact]
        public void Should_ReturnTrue_WhenAllConditionsMet()
        {
            var firstCandle = new Candlestick()
            {
                HighPrice = 10,
                LowPrice = 2.5,
                OpenPrice = 5.5,
                ClosePrice = 3,
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
            var isPatternFound = _bullingEngulfing.Apply(firstCandle, secondCandle);

            Assert.True(isPatternFound);
        }

        [Fact]
        public void Should_ReturnFalse_WhenFirstCandleIsGreen()
        {
            var firstCandle = new Candlestick()
            {
                HighPrice = 10,
                LowPrice = 2.5,
                OpenPrice = 5.5,
                ClosePrice = 7,
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
            var isPatternFound = _bullingEngulfing.Apply(firstCandle, secondCandle);

            Assert.False(isPatternFound);
        }

        [Fact]
        public void Should_ReturnFalse_WhenSecondCandleIsRed()
        {
            var firstCandle = new Candlestick()
            {
                HighPrice = 10,
                LowPrice = 2.5,
                OpenPrice = 5.5,
                ClosePrice = 3,
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
            var isPatternFound = _bullingEngulfing.Apply(firstCandle, secondCandle);

            Assert.False(isPatternFound);
        }
    
        [Fact]
        public void Should_ReturnFalse_WhenFirstHighIsGreaterThanSecondClose()
        {
            var firstCandle = new Candlestick()
            {
                HighPrice = 11.01,
                LowPrice = 2.5,
                OpenPrice = 5.5,
                ClosePrice = 3,
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
            var isPatternFound = _bullingEngulfing.Apply(firstCandle, secondCandle);

            Assert.False(isPatternFound);
        }
    
        [Fact]
        public void Should_ReturnFalse_WhenFirstLowIsLessThanSecondOpen()
        {
            var firstCandle = new Candlestick()
            {
                HighPrice = 10,
                LowPrice = 2.5,
                OpenPrice = 5.5,
                ClosePrice = 3,
                Timestamp = DateTime.Now
            };
            var secondCandle = new Candlestick()
            {
                HighPrice = 14,
                LowPrice = 2,
                OpenPrice = 5,
                ClosePrice = 11,
                Timestamp = DateTime.Now
            };
            var isPatternFound = _bullingEngulfing.Apply(firstCandle, secondCandle);

            Assert.False(isPatternFound);
        }
    
        [Fact]
        public void Should_ReturnFalse_WhenFirstHighIsGreaterThanSecondClose_And_FirstLowIsLessThanSecondOpen()
        {
            var firstCandle = new Candlestick()
            {
                HighPrice = 11.01,
                LowPrice = 2.5,
                OpenPrice = 5.5,
                ClosePrice = 3,
                Timestamp = DateTime.Now
            };
            var secondCandle = new Candlestick()
            {
                HighPrice = 14,
                LowPrice = 2,
                OpenPrice = 5,
                ClosePrice = 11,
                Timestamp = DateTime.Now
            };
            var isPatternFound = _bullingEngulfing.Apply(firstCandle, secondCandle);

            Assert.False(isPatternFound);
        }
    }
}