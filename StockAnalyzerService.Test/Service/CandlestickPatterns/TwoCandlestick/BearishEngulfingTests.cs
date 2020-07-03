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
            //Arrange
            var timestamp = DateTime.Now;
            var firstCandle = new Candlestick()
            {
                HighPrice = 10,
                LowPrice = 2.5,
                OpenPrice = 2.5,
                ClosePrice = 6,
                Timestamp = timestamp
            };
            var secondCandle = new Candlestick()
            {
                HighPrice = 14,
                LowPrice = 2,
                OpenPrice = 11,
                ClosePrice = 2,
                Timestamp = timestamp.AddDays(-1)
            };
            var expectedValue = new CandlestickAnalysis() {
                Ticker = "MSFT",
                Timestamp = timestamp,
                Pattern = "Bearish Engulfing",
                Action = StockAction.Sell
            };

            //Act
            var analysis = _bearishEngulfing.Apply(firstCandle, secondCandle, "MSFT");

            //Assert
            Assert.Equal(expectedValue.Ticker, analysis.Ticker);
            Assert.Equal(expectedValue.Timestamp, analysis.Timestamp);
            Assert.Equal(expectedValue.Pattern, analysis.Pattern);
            Assert.Equal(expectedValue.Action, analysis.Action);
        }
    
        [Fact]
        public void Should_ReturnFalse_WhenFirstCandleIsRed()
        {
            //Arrange
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

            //Act
            var analysis = _bearishEngulfing.Apply(firstCandle, secondCandle, "MSFT");

            //Assert
            Assert.Null(analysis);
        }
    
        [Fact]
        public void Should_ReturnFalse_WhenSecondCandleIsGreen()
        {
            //Arrange
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

            //Act
            var analysis = _bearishEngulfing.Apply(firstCandle, secondCandle, "MSFT");

            //Assert
            Assert.Null(analysis);
        }
    
        [Fact]
        public void Should_ReturnFalse_WhenFirstHighIsGreaterThanSecondOpen()
        {
            //Arrange
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

            //Act
            var analysis = _bearishEngulfing.Apply(firstCandle, secondCandle, "MSFT");

            //Assert
            Assert.Null(analysis);
        }
    
        [Fact]
        public void Should_ReturnFalse_WhenFirstLowIsLessThanSecondClose()
        {
            //Arrange
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

            //Act
            var analysis = _bearishEngulfing.Apply(firstCandle, secondCandle, "MSFT");

            //Assert
            Assert.Null(analysis);
        }
    
        [Fact]
        public void Should_ReturnFalse_WhenFirstHighIsGreaterThanSecondOpen_And_FirstLowIsLessThanSecondClose()
        {
            //Arrange
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

            //Act
            var analysis = _bearishEngulfing.Apply(firstCandle, secondCandle, "MSFT");

            //Assert
            Assert.Null(analysis);
        }
    }
}