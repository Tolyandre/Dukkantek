using Dukkantek.Api.Exceptions;
using Dukkantek.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dukkantek.Api.Features.Products.Update
{
    public class GetProductRequestHandler : IRequestHandler<GetProductRequest, GetProductResponse>
    {
        private readonly DukkantekDbContext _dbContext;

        public GetProductRequestHandler(DukkantekDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var response = await _dbContext.Products
                .Select(x => new GetProductResponse
                {
                    Barcode = x.Barcode,
                    Name = x.Name,
                    Description = x.Description,
                    Weight = x.Weight,
                    StatusId = x.StatusId,
                    CategoryId = x.CategoryId,
                })
                .FirstOrDefaultAsync(x => x.Barcode == request.Barcode, cancellationToken);

            return response ?? throw new RespondNotFoundException();
        }
    }
}
