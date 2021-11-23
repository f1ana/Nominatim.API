using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Nominatim.API.Tests
{
    internal class MockHttpHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> mockConfig;

        public MockHttpHandler(Func<HttpRequestMessage, HttpResponseMessage> mockConfig)
        {
            this.mockConfig = mockConfig;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {            
            return Task.FromResult(mockConfig(request));
        }
    }
}