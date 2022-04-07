using MediatR;
using System.Text.Json.Serialization;

namespace Dukkantek.Api.Features.Products.Sell
{
    public class SellRequest : IRequest
    {
        [JsonIgnore]
        public string? Barcode { get; set; } = null!;
    }
}
