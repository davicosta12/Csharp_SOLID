using System.Net;
using Moq;
using Moq.Protected;

namespace Alura.Adopet.Testes.Builder
{
    public class HttpClientClienteMockBuilder
    {
        public static Mock<HttpClient> GetMock(string content)
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(content),
            };
            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new Mock<HttpClient>(MockBehavior.Default, handlerMock.Object);
            httpClient.Object.BaseAddress = new Uri("http://localhost:5057");
            return httpClient;
        }
    }
}