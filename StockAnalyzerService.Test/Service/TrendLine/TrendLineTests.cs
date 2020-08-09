using Microsoft.VisualStudio.TestPlatform;
using Moq;
using StockAnalyzerService.Model;
using StockAnalyzerService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace StockAnalyzerService.Test.Service
{
    public class TrendLineTests {
        private CandlestickFixture _fixture;
        private Mock<IMovingAverage> _movingAverageMock;
        public TrendLineTests() {
            _movingAverageMock = new Mock<IMovingAverage>();
            _fixture = new CandlestickFixture();
        }

        [Fact]
        public void CalculateTrendLine_Should_ReturnListOfSMAs() {
            // Arrange
            List<double> expected = new List<double>();
            for (int i = 0; i < 201; i++) {
                expected.Add(5.0);
            }

            _movingAverageMock.Setup(m => m.CalculateSMA(It.IsAny<List<Candlestick>>())).Returns(5.0);
            var trendLine = new TrendLine(_movingAverageMock.Object);

            // Act
            List<double> actual = trendLine.CalculateTrendLine(_fixture.upTrendCandlesticks);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DirectionOfTrendLine_Should_ReturnUp() {
            // Arrange
            string expected = "Up";
            Type trendLineType = typeof(TrendLine);
            var trendLine = new TrendLine(_movingAverageMock.Object);
            var activator = Activator.CreateInstance(typeof(TrendLine), _movingAverageMock.Object);
            MethodInfo method = trendLineType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x => x.Name == "DirectionOfTrendLine" && x.IsPrivate)
            .First();
            
            // Act
            string actual = (string)method.Invoke(activator, new Object[] { _fixture.upwardTrendLine });

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DirectionOfTrendLine_Should_ReturnDown() {
            // Arrange
            string expected = "Down";
            Type trendLineType = typeof(TrendLine);
            var trendLine = new TrendLine(_movingAverageMock.Object);
            var activator = Activator.CreateInstance(typeof(TrendLine), _movingAverageMock.Object);
            MethodInfo method = trendLineType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x => x.Name == "DirectionOfTrendLine" && x.IsPrivate)
            .First();
            
            // Act
            string actual = (string)method.Invoke(activator, new Object[] { _fixture.downwardTrendLine });

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DirectionOfTrendLine_Should_ReturnFlat() {
            // Arrange
            string expected = "Flat";
            Type trendLineType = typeof(TrendLine);
            var trendLine = new TrendLine(_movingAverageMock.Object);
            var activator = Activator.CreateInstance(typeof(TrendLine), _movingAverageMock.Object);
            MethodInfo method = trendLineType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x => x.Name == "DirectionOfTrendLine" && x.IsPrivate)
            .First();
            
            // Act
            string actual = (string)method.Invoke(activator, new Object[] { _fixture.flatTrendLine });

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EvaluateTrendLine_Should_ThrowException() {
            // Arrange
            string expectedExceptionMessage = "Number of candlesticks must match length of trend line.";
            List<Candlestick> candlesticks = _fixture.upTrendCandlesticks.Take(100).ToList();
            var trendLine = new TrendLine(_movingAverageMock.Object);

            // Act
            Action action = () => trendLine.EvaluateTrendLine(candlesticks, _fixture.upwardTrendLine);

            // Assert
            var exception = Assert.Throws<Exception>(action);
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Fact]
        public void EvaluateTrendLineWithUpTrend_Should_ReturnUp() {
            // Arrange
            string expected = "Up";
            var trendLine = new TrendLine(_movingAverageMock.Object);

            // Act
            string actual = trendLine.EvaluateTrendLine(_fixture.upTrendCandlesticks.Skip(199).ToList(), _fixture.upwardTrendLine);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EvaluateTrendLineWithUpTrend_Should_ReturnNoTrend() {
            // Arrange
            string expected = "No Trend";
            var trendLine = new TrendLine(_movingAverageMock.Object);

            // Act
            string actual = trendLine.EvaluateTrendLine(_fixture.upTrendCandlesticks.Skip(199).ToList(), _fixture.flatTrendLine);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EvaluateTrendLineWithDownTrend_Should_ReturnDown() {
            // Arrange
            string expected = "Down";
            var trendLine = new TrendLine(_movingAverageMock.Object);

            // Act
            string actual = trendLine.EvaluateTrendLine(_fixture.downTrendCandlesticks.Skip(199).ToList(), _fixture.downwardTrendLine);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EvaluateTrendLineWithDownTrend_Should_ReturnNoTrend() {
            // Arrange
            string expected = "No Trend";
            var trendLine = new TrendLine(_movingAverageMock.Object);

            // Act
            string actual = trendLine.EvaluateTrendLine(_fixture.downTrendCandlesticks.Skip(199).ToList(), _fixture.flatTrendLine);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EvaluateTrendLineWithFlatTrend_Should_ReturnNoTrend() {
            // Arrange
            string expected = "No Trend";
            var trendLine = new TrendLine(_movingAverageMock.Object);

            // Act
            string actual = trendLine.EvaluateTrendLine(_fixture.flatTrendCandlesticks.Skip(199).ToList(), _fixture.flatTrendLine);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
