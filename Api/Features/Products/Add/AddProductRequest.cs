using Dukkantek.Db.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dukkantek.Api.Features.Products.Add
{
    public class AddProductRequest : IRequest<AddProductResponse>
    {
        [Required]
        [MaxLength(20)]
        public string Barcode { get; set; } = null!;

        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Range(0, 1000)]
        public float Weight { get; set; }

        [Required]
        public ProductStatusId StatusId { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
