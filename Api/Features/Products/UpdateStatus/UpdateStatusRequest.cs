using Dukkantek.Db.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dukkantek.Api.Features.Products.UpdateStatus
{
    public class UpdateStatusRequest : IRequest
    {
        [Required]
        public string Barcode { get; set; } = null!;

        [Required]
        public ProductStatusId StatusId { get; set; }
    }
}
