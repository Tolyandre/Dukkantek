using MediatR;

namespace Dukkantek.Api.Features.Products.GetAll
{
    public class GetAllProductsRequest : IRequest<GetAllProductsResponse[]>
    {
    }
}
