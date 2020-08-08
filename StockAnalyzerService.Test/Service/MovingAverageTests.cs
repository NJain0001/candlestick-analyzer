using System.Collections.Generic;
using StockAnalyzerService.Model;
using Xunit;

namespace StockAnalyzerService.Test.Service {
    public class MovingAverageTests {
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
    }
}