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

namespace StockAnalyzerService.Test {
    public class StockAnalyzerTests {
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
            var httpCallsMock = new Mock<IHttpCalls>(MockBehavior.Strict);
            httpCallsMock.Setup(m => m.Get<List<StockMetadata>>(It.IsAny<HttpClient>(), It.IsAny<string>())).ReturnsAsync(new List<StockMetadata> { testStock });

            var httpClientFactory = new Mock<IHttpClientFactory>();

            // Act
            var stockAnalyzer = new StockAnalyzer(httpClientFactory.Object, httpCallsMock.Object);
            var stocks = await stockAnalyzer.GetStocksWithUsers();

            // Assert
            httpCallsMock.Verify(x => x.Get<List<StockMetadata>>(It.IsAny<HttpClient>(), It.IsAny<string>()), Times.Once);
            Assert.Equal(expectedValue, stocks);
        }
    }
}
