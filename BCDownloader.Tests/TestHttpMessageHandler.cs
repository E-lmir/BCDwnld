using System.Net;
using System.Text;

namespace BCDownloader.Tests
{
    internal class TestHttpMessageHandler (string document) : HttpMessageHandler
    {
        private readonly string _document = document;

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(_document, Encoding.UTF8),
            };

            return Task.FromResult(response);
        }
    }
}
