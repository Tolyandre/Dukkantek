using Dukkantek.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dukkantek.Api.Features.Products.Count
{
    public class CountProductsRequestHandler : IRequestHandler<CountProductsRequest, CountProductResponse>
    {
        private readonly DukkantekDbContext _dbContext;

        public CountProductsRequestHandler(DukkantekDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CountProductResponse> Handle(CountProductsRequest request, CancellationToken cancellationToken)
        {
            var query = await _dbContext.ProductStatuses
                 .Select(s => new
                     {
                         StatusId = s.Id,
                         Count = _dbContext.Products.Count(p => p.StatusId == s.Id),
                     })
                 .ToDictionaryAsync(x => x.StatusId, x => x.Count, cancellationToken);

            return new CountProductResponse
            {
                CountPerStatus = query,
            };
        }
    }
}
