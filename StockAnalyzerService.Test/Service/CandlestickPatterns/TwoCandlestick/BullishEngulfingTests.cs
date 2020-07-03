using Xunit;
using StockAnalyzerService.Model;
using StockAnalyzerService.Service;
using System;

namespace StockAnalyzerService.Test.Service {

    public class BullishEngulfingTests
    {
        private BullishEngulfing _bullishEngulfing;
        public BullishEngulfingTests()
        {
            _bullishEngulfing = new BullishEngulfing();
        }
        [Fact]
        public void Should_ReturnTrue_WhenAllConditionsMet()
        {
            //Arrange
            var timestamp = DateTime.Now;
            var firstCandle = new Candlestick()
            {
                HighPrice = 10,
                LowPrice = 2.5,
                OpenPrice = 5.5,
                ClosePrice = 3,
                Timestamp = timestamp
            };
            var secondCandle = new Candlestick()
            {
                HighPrice = 14,
                LowPrice = 2,
                OpenPrice = 2,
                ClosePrice = 11,
                Timestamp = timestamp.AddDays(-1)
            };
            var expectedValue = new CandlestickAnalysis() {
                Ticker = "MSFT",
                Timestamp = timestamp,
                Pattern = "Bullish Engulfing",
                Action = StockAction.Buy
            };

            //Act
            var analysis = _bullishEngulfing.Apply(firstCandle, secondCandle, "MSFT");

            //Assert
            Assert.Equal(expectedValue.Ticker, analysis.Ticker);
            Assert.Equal(expectedValue.Timestamp, analysis.Timestamp);
            Assert.Equal(expectedValue.Pattern, analysis.Pattern);
            Assert.Equal(expectedValue.Action, analysis.Action);
        }

        [Fact]
        public void Should_ReturnFalse_WhenFirstCandleIsGreen()
        {
            //Arrange
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

            //Act
            var analysis = _bullishEngulfing.Apply(firstCandle, secondCandle, "MSFT");

            //Assert
            Assert.Null(analysis);
        }

        [Fact]
        public void Should_ReturnFalse_WhenSecondCandleIsRed()
        {
            //Arrange
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

            //Act
            var analysis = _bullishEngulfing.Apply(firstCandle, secondCandle, "MSFT");

            //Assert
            Assert.Null(analysis);
        }
    
        [Fact]
        public void Should_ReturnFalse_WhenFirstHighIsGreaterThanSecondClose()
        {
            //Arrange
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

            //Act
            var analysis = _bullishEngulfing.Apply(firstCandle, secondCandle, "MSFT");

            //Assert
            Assert.Null(analysis);
        }
    
        [Fact]
        public void Should_ReturnFalse_WhenFirstLowIsLessThanSecondOpen()
        {
            //Arrange
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

            //Act
            var analysis = _bullishEngulfing.Apply(firstCandle, secondCandle, "MSFT");

            //Assert
            Assert.Null(analysis);
        }
    
        [Fact]
        public void Should_ReturnFalse_WhenFirstHighIsGreaterThanSecondClose_And_FirstLowIsLessThanSecondOpen()
        {
            //Arrange
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

            //Act
            var analysis = _bullishEngulfing.Apply(firstCandle, secondCandle, "MSFT");

            //Assert
            Assert.Null(analysis);
        }
    }
}