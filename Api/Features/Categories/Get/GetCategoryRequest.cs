using MediatR;

namespace Dukkantek.Api.Features.Categories.Get
{
    public class GetCategoryRequest : IRequest<GetCategoryResponse>
    {
        public int Id { get; set; }
    }
}
