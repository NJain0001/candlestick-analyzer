using System.Collections.Generic;
using System.Linq;
using Moq;
using StockAnalyzerService.Model;
using StockAnalyzerService.Service;
using Xunit;

namespace StockAnalyzerService.Test.Service {
    public class AreaOfValueTests {
        private CandlestickFixture candlestickFixture;
        private Mock<IMovingAverage> _movingAverageMock;

        public AreaOfValueTests() {
            candlestickFixture = new CandlestickFixture();
            _movingAverageMock = new Mock<IMovingAverage>();
        }

        [Fact]
        public void IsCandlestickInAreaOfValue_Should_ReturnTrue() {
            // Arrange
            bool expected = true;
            List<Candlestick> listToAnalyze = candlestickFixture.upTrendCandlesticks.Take(50).ToList();
            _movingAverageMock.Setup(m => m.CalculateSMA(It.IsAny<List<Candlestick>>())).Returns(25.0);
            AreaOfValue areaOfValue = new AreaOfValue(_movingAverageMock.Object);


            // Act
            bool actual = areaOfValue.IsCandlestickInAreaOfValue(listToAnalyze);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsCandlestickInAreaOfValue_Should_ReturnFalseWhenHigherThanHigherBound() {
            // Arrange
            bool expected = false;
            List<Candlestick> listToAnalyze = candlestickFixture.upTrendCandlesticks.Take(50).ToList();
            _movingAverageMock.Setup(m => m.CalculateSMA(It.IsAny<List<Candlestick>>())).Returns(20.0);
            AreaOfValue areaOfValue = new AreaOfValue(_movingAverageMock.Object);


            // Act
            bool actual = areaOfValue.IsCandlestickInAreaOfValue(listToAnalyze);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsCandlestickInAreaOfValue_Should_ReturnFalseWhenLowerThanLowerBound() {
            // Arrange
            bool expected = false;
            List<Candlestick> listToAnalyze = candlestickFixture.upTrendCandlesticks.Take(50).ToList();
            _movingAverageMock.Setup(m => m.CalculateSMA(It.IsAny<List<Candlestick>>())).Returns(30.0);
            AreaOfValue areaOfValue = new AreaOfValue(_movingAverageMock.Object);


            // Act
            bool actual = areaOfValue.IsCandlestickInAreaOfValue(listToAnalyze);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}