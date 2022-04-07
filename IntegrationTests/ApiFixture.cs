using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;

namespace Dukkantek.IntegrationTests
{
    public class ApiFixture: IDisposable
    {
        private readonly WebApplicationFactory<Program> _webApplicationFactory;

        public ApiFixture()
        {
            _webApplicationFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                    });
                });

            HttpClient = _webApplicationFactory.CreateClient();
        }

        public HttpClient HttpClient { get; init; }

        public void Dispose()
        {
            _webApplicationFactory?.Dispose();
        }
    }
}
