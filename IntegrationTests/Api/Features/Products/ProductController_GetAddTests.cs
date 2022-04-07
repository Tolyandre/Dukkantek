using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace Dukkantek.IntegrationTests.Api.Controllers.Groups
{
    [UsesVerify]
    [Collection("Database tests")]
    public class ProductController_GetAddTests : DukkantekVerifyBase, IClassFixture<ApiFixture>, IClassFixture<TestDatabaseFixture>
    {
        private readonly HttpClient _httpClient;

        public ProductController_GetAddTests(ApiFixture apiFixture, TestDatabaseFixture testDatabaseFixture)
        {
            _httpClient = apiFixture.HttpClient;
            var database = testDatabaseFixture.DbContext.Database;

            database.EnsureDeleted();
            database.EnsureCreated();
        }

        [Fact]
        public async Task HappyPath_ReturnsCountPerStatus()
        {
            // Act
            var response = await _httpClient.GetAsync("/Products/count-per-status");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            await VerifyJson(await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task HappyPath_ReturnsAddedProduct()
        {
            // Act
            var response = await _httpClient.PostAsync("/Products", JsonContent.Create(new
            {
                CategoryId = 2,
                Name = "Charge Station",
                Description = "Beautiful charge station",
                Barcode = "A-0050-C",
                Weight = 2.5f,
                StatusId = "InStock",
            }));

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            await VerifyJson(await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task WhenProductAdded_GetReturnsThat()
        {
            // Act
            await _httpClient.PostAsync("/Products", JsonContent.Create(new
            {
                CategoryId = 2,
                Name = "Charge Station",
                Description = "Beautiful charge station",
                Barcode = "A-0050-C",
                Weight = 2.5f,
                StatusId = "InStock",
            }));

            // Assert
            var getResponse = await _httpClient.GetAsync("/Products");
            await VerifyJson(await getResponse.Content.ReadAsStringAsync());
        }
    }
}
