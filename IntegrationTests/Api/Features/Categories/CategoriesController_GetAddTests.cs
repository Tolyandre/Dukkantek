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
    public class CategoriesController_GetAddTests : DukkantekVerifyBase, IClassFixture<ApiFixture>, IClassFixture<TestDatabaseFixture>
    {
        private readonly HttpClient _httpClient;

        public CategoriesController_GetAddTests(ApiFixture apiFixture, TestDatabaseFixture testDatabaseFixture)
        {
            _httpClient = apiFixture.HttpClient;
            var database = testDatabaseFixture.DbContext.Database;

            database.EnsureDeleted();
            database.EnsureCreated();
        }

        [Fact]
        public async Task HappyPath_ReturnsAddedCategory()
        {
            // Act
            var response = await _httpClient.PostAsync("/Categories", JsonContent.Create(new
            {
                Name = "Sports",
            }));

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            await VerifyJson(await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task WhenCategoryAdded_GetReturnsNewGroup()
        {
            // Act
            await _httpClient.PostAsync("/Categories", JsonContent.Create(new
            {
                Name = "Sports",
            }));

            // Assert
            var response = await _httpClient.GetAsync("/Categories/3");
            await VerifyJson(await response.Content.ReadAsStringAsync());
        }
    }
}
