using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using StockAnalyzerService.Model;
using StockAnalyzerService.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StockAnalyzerService.Test.Service {
    public class TrendLineTests {
        private List<Candlestick> upTrendCandlesticks = new List<Candlestick>(); //TODO: Populate list
        private List<Candlestick> downTrendCandlesticks = new List<Candlestick>(); //TODO: Populate list
        private Mock<ITrendLine> trendLineMock;
        public TrendLineTests() {
            trendLineMock = new Mock<ITrendLine>();
        }

        [Fact]
        public void CalculateSMA_Should_ReturnAverageOfListOfSize50() {
            // Arrange
            double expectedValue = 0.0; //TODO: Put in actual average
            List<Candlestick> listToAnalyze = upTrendCandlesticks.Take(50).ToList();
            TrendLine trendLine = new TrendLine();

            // Act
            double actualValue = trendLine.CalculateSMA(listToAnalyze);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void CalculateSMA_Should_ReturnAverageOfListOfSize200() {
            // Arrange
            double expectedValue = 0.0; //TODO: Put in actual average
            List<Candlestick> listToAnalyze = upTrendCandlesticks.Take(200).ToList();
            var trendLine = new TrendLine();

            // Act
            double actualValue = trendLine.CalculateSMA(listToAnalyze);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void CalculateTrendLine_Should_ReturnListOfSMAs() {
            // Arrange
            List<double> expected = new List<double>();
            for (int i = 0; i < 400; i++) {
                expected.Add(5.0);
            }

            trendLineMock.Setup(m => m.CalculateSMA(It.IsAny<List<Candlestick>>())).Returns(5.0);
            var trendLine = new TrendLine();

            // Act
            List<double> actual = trendLine.CalculateTrendLine(upTrendCandlesticks);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DirectionOfTrendLine_Should_ReturnUp() {
            // Arrange
            string expected = "Up";
            List<double> listToAnalyze = new List<double>(); //TODO: populate with upwards trend line
            var trendLine = new TrendLine();
            
            // Act
            string actual = trendLine.DirectionOfTrendLine(listToAnalyze);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DirectionOfTrendLine_Should_ReturnDown() {
            // Arrange
            string expected = "Down";
            List<double> listToAnalyze = new List<double>(); //TODO: populate with downwards trend line
            var trendLine = new TrendLine();
            
            // Act
            string actual = trendLine.DirectionOfTrendLine(listToAnalyze);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DirectionOfTrendLine_Should_ReturnFlat() {
            // Arrange
            string expected = "Flat";
            List<double> listToAnalyze = new List<double>(); //TODO: populate with flat trend line
            var trendLine = new TrendLine();
            
            // Act
            string actual = trendLine.DirectionOfTrendLine(listToAnalyze);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EvaluateTrendLine_Should_ThrowException() {
            // Arrange
            string expectedExceptionMessage = "Number of candlesticks must match length of trend line.";
            List<Candlestick> candlesticks = upTrendCandlesticks.Take(100).ToList();
            List<double> trendLineToAnalyze = new List<double>(); //TODO: Populate with actual data
            var trendLine = new TrendLine();

            // Act
            Action action = () => trendLine.EvaluateTrendLine(candlesticks, trendLineToAnalyze);

            // Assert
            var exception = Assert.Throws<Exception>(action);
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }

        [Fact]
        public void EvaluateTrendLineWithUpTrend_Should_ReturnUp() {
            // Arrange
            string expected = "Up";
            List<double> trendLineToAnalyze = new List<double>(); //TODO: Populate with actual data
            var trendLine = new TrendLine();

            // Act
            string actual = trendLine.EvaluateTrendLine(upTrendCandlesticks, trendLineToAnalyze);

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
            var trendLine = new TrendLine();
            trendLineMock.Setup(m => m.DirectionOfTrendLine(It.IsAny<List<double>>())).Returns("Up");

            // Act
            string actual = trendLine.EvaluateTrendLine(candlesticks, trendLineToAnalyze);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EvaluateTrendLineWithDownTrend_Should_ReturnDown() {
            // Arrange
            string expected = "Down";
            List<double> trendLineToAnalyze = new List<double>(); //TODO: Populate with actual data
            var trendLine = new TrendLine();

            // Act
            string actual = trendLine.EvaluateTrendLine(downTrendCandlesticks, trendLineToAnalyze);

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
            var trendLine = new TrendLine();
            trendLineMock.Setup(m => m.DirectionOfTrendLine(It.IsAny<List<double>>())).Returns("Down");

            // Act
            string actual = trendLine.EvaluateTrendLine(candlesticks, trendLineToAnalyze);

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
            var trendLine = new TrendLine();
            trendLineMock.Setup(m => m.DirectionOfTrendLine(It.IsAny<List<double>>())).Returns("Flat");

            // Act
            string actual = trendLine.EvaluateTrendLine(candlesticks, trendLineToAnalyze);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
