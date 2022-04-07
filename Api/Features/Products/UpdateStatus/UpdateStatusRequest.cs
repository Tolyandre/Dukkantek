using Dukkantek.Db.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dukkantek.Api.Features.Products.UpdateStatus
{
    public class UpdateStatusRequest : IRequest
    {
        [JsonIgnore]
        public string? Barcode { get; set; } = null!;

        [Required]
        public ProductStatusId StatusId { get; set; }
    }
}
