using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dukkantek.Api.Features.Products.Update
{
    public class GetProductRequest : IRequest<GetProductResponse>
    {
        [Required]
        public string Barcode { get; set; } = null!;
    }
}
