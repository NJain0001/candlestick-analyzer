using System.Collections.Generic;
using System.Linq;
using Moq;
using StockAnalyzerService.Model;
using StockAnalyzerService.Service;
using Xunit;

namespace StockAnalyzerService.Test.Service {
    public class MovingAverageTests {
        private CandlestickFixture _fixture;
        public MovingAverageTests() {
            _fixture = new CandlestickFixture();
        }
        [Fact]
        public void CalculateSMA_Should_ReturnAverageOfListOfSize50() {
            // Arrange
            double expectedValue = 12.25; //TODO: Put in actual average
            List<Candlestick> listToAnalyze = _fixture.upTrendCandlesticks.Take(50).ToList();
            MovingAverage movingAverage = new MovingAverage();

            // Act
            double actualValue = movingAverage.CalculateSMA(listToAnalyze);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void CalculateSMA_Should_ReturnAverageOfListOfSize200() {
            // Arrange
            double expectedValue = 49.75; //TODO: Put in actual average
            List<Candlestick> listToAnalyze = _fixture.upTrendCandlesticks.Take(200).ToList();
            MovingAverage movingAverage = new MovingAverage();

            // Act
            double actualValue = movingAverage.CalculateSMA(listToAnalyze);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }
    }
}