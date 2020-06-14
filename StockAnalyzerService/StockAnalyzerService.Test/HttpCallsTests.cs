using Moq;
using Moq.Protected;
using StockAnalyzerService.Model;
using StockAnalyzerService.Service;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace StockAnalyzerService.Test {
    public class HttpCallsTests {
        [Fact]
        public async void Get_Should_ReturnOneStockMetadataObject() {
            // Arrange
            User testUser = new User {
                FirstName = "Harsh",
                LastName = "Jain",
                EmailAddress = "jainh9999@gmail.com"
            };
            StockMetadata expectedValue = new StockMetadata {
                Ticker = "MSFT",
                CompanyName = "Microsoft",
                Users = new List<User> { testUser }
            };
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{Ticker: \"MSFT\", CompanyName: \"Microsoft\", Users: [{FirstName: \"Harsh\", LastName: \"Jain\", EmailAddress: \"jainh9999@gmail.com\"}]}", Encoding.UTF8, "application/json") //Add in mock response message
            };

            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object) { 
                BaseAddress = new Uri("https://test.com")
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Act
            var httpCalls = new HttpCalls();
            var result = await httpCalls.Get<StockMetadata>(httpClient, "test");

            // Assert
            Assert.Equal(result.Ticker, expectedValue.Ticker);
            Assert.Equal(result.CompanyName, expectedValue.CompanyName);
            Assert.Equal(result.Users[0].FirstName, expectedValue.Users[0].FirstName);
            Assert.Equal(result.Users[0].LastName, expectedValue.Users[0].LastName);
            Assert.Equal(result.Users[0].EmailAddress, expectedValue.Users[0].EmailAddress);
        }

        [Fact]
        public async void Get_Should_ReturnListOfStockMetadataObjects() {
            // Arrange
            User testUser = new User {
                FirstName = "Harsh",
                LastName = "Jain",
                EmailAddress = "jainh9999@gmail.com"
            };
            StockMetadata stock = new StockMetadata {
                Ticker = "MSFT",
                CompanyName = "Microsoft",
                Users = new List<User> { testUser }
            };
            List<StockMetadata> expectedValue = new List<StockMetadata>() { stock };
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("[{Ticker: \"MSFT\", CompanyName: \"Microsoft\", Users: [{FirstName: \"Harsh\", LastName: \"Jain\", EmailAddress: \"jainh9999@gmail.com\"}]}]", Encoding.UTF8, "application/json") //Add in mock response message
            };

            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object) { 
                BaseAddress = new Uri("https://test.com")
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Act
            var httpCalls = new HttpCalls();
            var result = await httpCalls.Get<List<StockMetadata>>(httpClient, "test");

            // Assert
            Assert.Equal(result[0].Ticker, expectedValue[0].Ticker);
            Assert.Equal(result[0].CompanyName, expectedValue[0].CompanyName);
            Assert.Equal(result[0].Users[0].FirstName, expectedValue[0].Users[0].FirstName);
            Assert.Equal(result[0].Users[0].LastName, expectedValue[0].Users[0].LastName);
            Assert.Equal(result[0].Users[0].EmailAddress, expectedValue[0].Users[0].EmailAddress);
        }
    }
}
