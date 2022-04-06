using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dukkantek.Api.Features.Categories.Add
{
    public class AddCategoryRequest : IRequest<AddCategoryResponse>
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
