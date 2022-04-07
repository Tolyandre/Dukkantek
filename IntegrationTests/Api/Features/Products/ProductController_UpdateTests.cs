using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VerifyXunit;
using Xunit;

namespace Dukkantek.IntegrationTests.Api.Controllers.ChargeStations
{
    [UsesVerify]
    [Collection("Database tests")]
    public class ProductController_UpdateTests : DukkantekVerifyBase, IClassFixture<ApiFixture>, IClassFixture<TestDatabaseFixture>
    {
        private readonly HttpClient _httpClient;

        public ProductController_UpdateTests(ApiFixture apiFixture, TestDatabaseFixture testDatabaseFixture)
        {
            _httpClient = apiFixture.HttpClient;
            var database = testDatabaseFixture.DbContext.Database;

            database.EnsureDeleted();
            database.EnsureCreated();
        }

        [Fact]
        public async Task HappyPath_UpdateStatusReturns200()
        {
            // Act
            var response = await _httpClient.PutAsync("/Products/barcode/A-0010-B/status", JsonContent.Create(new
            {
                Status = "Damaged",
            }));

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            await Verify(await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task BarcodeNotExist_UpdateReturns404()
        {
            // Act
            var response = await _httpClient.PutAsync("/Products/barcode/x-001-x/status", JsonContent.Create(new
            {
                Status = "Damaged",
            }));

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            await VerifyJson(await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task HappyPath_SellChangesStatus()
        {
            // Act
            var response = await _httpClient.PutAsync("/Products/barcode/A-0010-B/sell", JsonContent.Create(new object()));

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            await Verify(await response.Content.ReadAsStringAsync());
        }

        [Fact]
        public async Task ProductSold_SellReturns400()
        {
            // Act
            var response = await _httpClient.PutAsync("/Products/barcode/ABC-1234/sell", JsonContent.Create(new object()));

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            await VerifyJson(await response.Content.ReadAsStringAsync());
        }
    }
}
