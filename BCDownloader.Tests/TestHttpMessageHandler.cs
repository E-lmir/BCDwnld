using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
