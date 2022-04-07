using Dukkantek.Db.Models;

namespace Dukkantek.Api.Features.Products.GetAll
{
    public class GetAllProductsResponse
    {
        public string Barcode { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public float Weight { get; set; }

        public ProductStatusId StatusId { get; set; }

        public int CategoryId { get; set; }
    }
}
