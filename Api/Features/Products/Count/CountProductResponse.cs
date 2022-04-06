using Dukkantek.Db.Models;

namespace Dukkantek.Api.Features.Products.Count
{
    public class CountProductResponse
    {
        public Dictionary<ProductStatusId, int> CountPerStatus { get; set; } = null!;
    }
}
