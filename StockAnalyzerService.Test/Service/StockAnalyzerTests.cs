using System;
using Xunit;
using Moq;
using StockAnalyzerService;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using Moq.Protected;
using System.Threading;
using System.Collections.Generic;
using StockAnalyzerService.Service;
using StockAnalyzerService.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace StockAnalyzerService.Test.Service {
    public class StockAnalyzerTests {

        private Mock<IHttpCalls> httpCallsMock;
        private Mock<IHttpClientFactory> httpClientFactoryMock;
        private Mock<ILogger<StockAnalyzer>> loggerMock;
        private Mock<IConfiguration> configurationMock;

        public StockAnalyzerTests()
        {
            httpCallsMock = new Mock<IHttpCalls>(MockBehavior.Strict);
            httpClientFactoryMock = new Mock<IHttpClientFactory>();
            loggerMock = new Mock<ILogger<StockAnalyzer>>();
            configurationMock = new Mock<IConfiguration>();
        }
        [Fact]
        public async void GetStocksWithUsers_Should_ReturnListOfStockMetadataObjects() {
            // Arrange
            User testUser = new User {
                FirstName = "Harsh",
                LastName = "Jain",
                EmailAddress = "jainh9999@gmail.com"
            };
            StockMetadata testStock = new StockMetadata {
                Ticker = "MSFT",
                CompanyName = "Microsoft",
                Users = new List<User> { testUser }
            };

            List<StockMetadata> expectedValue = new List<StockMetadata> { testStock };
            httpCallsMock.Setup(m => m.Get<List<StockMetadata>>(It.IsAny<HttpClient>(), It.IsAny<string>()))
                         .ReturnsAsync(new List<StockMetadata> { testStock });

            // Act
            var stockAnalyzer = new StockAnalyzer(httpClientFactoryMock.Object, 
                                                  httpCallsMock.Object, 
                                                  null, 
                                                  configurationMock.Object);
            var stocks = await stockAnalyzer.GetStocksWithUsers();

            // Assert
            httpCallsMock.Verify(x => x.Get<List<StockMetadata>>(It.IsAny<HttpClient>(), It.IsAny<string>()), Times.Once);
            Assert.Equal(expectedValue, stocks);
        }

        [Fact]
        public async void GetStocksWithUsers_Should_CatchErrorAndReturnEmptyList() {
            // Arrange
            List<StockMetadata> expectedValue = new List<StockMetadata>();
            var httpCallsMock = new Mock<IHttpCalls>(MockBehavior.Strict);
            httpCallsMock.Setup(m => m.Get<List<StockMetadata>>(It.IsAny<HttpClient>(), It.IsAny<string>()))
                         .Throws(new Exception());

            // Act
            var stockAnalyzer = new StockAnalyzer(httpClientFactoryMock.Object, 
                                                  httpCallsMock.Object, 
                                                  loggerMock.Object, 
                                                  configurationMock.Object);
            var stocks = await stockAnalyzer.GetStocksWithUsers();

            // Assert
            httpCallsMock.Verify(x => x.Get<List<StockMetadata>>(It.IsAny<HttpClient>(), It.IsAny<string>()), Times.Once);
            Assert.Equal(expectedValue, stocks);
        }
    }
}
