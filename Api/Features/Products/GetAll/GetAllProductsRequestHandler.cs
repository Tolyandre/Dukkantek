using Dukkantek.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dukkantek.Api.Features.Products.GetAll
{
    public class GetAllProductsRequestHandler : IRequestHandler<GetAllProductsRequest, GetAllProductsResponse[]>
    {
        private readonly DukkantekDbContext _dbContext;

        public GetAllProductsRequestHandler(DukkantekDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetAllProductsResponse[]> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var response = await _dbContext.Products
                .Select(x => new GetAllProductsResponse
                {
                    Barcode = x.Barcode,
                    Name = x.Name,
                    Description = x.Description,
                    Weight = x.Weight,
                    StatusId = x.StatusId,
                    CategoryId = x.CategoryId,
                })
                .ToArrayAsync();

            return response;
        }
    }
}
