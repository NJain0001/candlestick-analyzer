using Moq;
using StockAnalyzerService.Model;
using StockAnalyzerService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StockAnalyzerService.Test.Service
{
    public class TrendLineTests {
        private List<Candlestick> upTrendCandlesticks = new List<Candlestick>(); //TODO: Populate list
        private List<Candlestick> downTrendCandlesticks = new List<Candlestick>(); //TODO: Populate list
        private Mock<IMovingAverage> _movingAverageMock;
        public TrendLineTests() {
            _movingAverageMock = new Mock<IMovingAverage>();
        }

        [Fact]
        public void CalculateTrendLine_Should_ReturnListOfSMAs() {
            // Arrange
            List<double> expected = new List<double>();
            for (int i = 0; i < 400; i++) {
                expected.Add(5.0);
            }

            _movingAverageMock.Setup(m => m.CalculateSMA(It.IsAny<List<Candlestick>>())).Returns(5.0);
            ITrendLine _trendLine = new TrendLine(_movingAverageMock.Object);

            // Act
            List<double> actual = _trendLine.CalculateTrendLine(upTrendCandlesticks);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DirectionOfTrendLine_Should_ReturnUp() {
            // Arrange
            string expected = "Up";
            List<double> listToAnalyze = new List<double>(); //TODO: populate with upwards trend line
            
            // Act
            string actual = _trendLine.DirectionOfTrendLine(listToAnalyze);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DirectionOfTrendLine_Should_ReturnDown() {
            // Arrange
            string expected = "Down";
            List<double> listToAnalyze = new List<double>(); //TODO: populate with downwards trend line
            
            // Act
            string actual = _trendLine.DirectionOfTrendLine(listToAnalyze);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DirectionOfTrendLine_Should_ReturnFlat() {
            // Arrange
            string expected = "Flat";
            List<double> listToAnalyze = new List<double>(); //TODO: populate with flat trend line
            
            // Act
            string actual = _trendLine.DirectionOfTrendLine(listToAnalyze);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EvaluateTrendLine_Should_ThrowException() {
            // Arrange
            string expectedExceptionMessage = "Number of candlesticks must match length of trend line.";
            List<Candlestick> candlesticks = upTrendCandlesticks.Take(100).ToList();
            List<double> trendLineToAnalyze = new List<double>(); //TODO: Populate with actual data

            // Act
            Action action = () => _trendLine.EvaluateTrendLine(candlesticks, trendLineToAnalyze);

            // Assert
            var exception = Assert.Throws<Exception>(action);
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Fact]
        public void EvaluateTrendLineWithUpTrend_Should_ReturnUp() {
            // Arrange
            string expected = "Up";
            List<double> trendLineToAnalyze = new List<double>(); //TODO: Populate with actual data

            // Act
            string actual = _trendLine.EvaluateTrendLine(upTrendCandlesticks, trendLineToAnalyze);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EvaluateTrendLineWithUpTrend_Should_ReturnNoTrend() {
            // Arrange
            string expected = "No Trend";
            List<Candlestick> candlesticks = upTrendCandlesticks;
            //TODO: Manipulate candlesticks to make it not have a trend
            List<double> trendLineToAnalyze = new List<double>(); //TODO: Populate with actual data

            // Act
            string actual = _trendLine.EvaluateTrendLine(candlesticks, trendLineToAnalyze);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EvaluateTrendLineWithDownTrend_Should_ReturnDown() {
            // Arrange
            string expected = "Down";
            List<double> trendLineToAnalyze = new List<double>(); //TODO: Populate with actual data

            // Act
            string actual = _trendLine.EvaluateTrendLine(downTrendCandlesticks, trendLineToAnalyze);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EvaluateTrendLineWithDownTrend_Should_ReturnNoTrend() {
            // Arrange
            string expected = "No Trend";
            List<Candlestick> candlesticks = upTrendCandlesticks;
            //TODO: Manipulate candlesticks to make it not have a trend
            List<double> trendLineToAnalyze = new List<double>(); //TODO: Populate with actual data

            // Act
            string actual = _trendLine.EvaluateTrendLine(candlesticks, trendLineToAnalyze);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EvaluateTrendLineWithFlatTrend_Should_ReturnNoTrend() {
            // Arrange
            string expected = "No Trend";
            List<Candlestick> candlesticks = upTrendCandlesticks;
            //TODO: Manipulate candlesticks to make it not have a trend
            List<double> trendLineToAnalyze = new List<double>(); //TODO: Populate with actual data

            // Act
            string actual = _trendLine.EvaluateTrendLine(candlesticks, trendLineToAnalyze);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
