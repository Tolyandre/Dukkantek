using Dukkantek.Api.Exceptions;
using Dukkantek.Db;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dukkantek.Api.Features.Categories.Get
{
    public class GetCategoryRequestHandler : IRequestHandler<GetCategoryRequest, GetCategoryResponse>
    {
        private readonly DukkantekDbContext _dbContext;

        public GetCategoryRequestHandler(DukkantekDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetCategoryResponse> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = await _dbContext.Categories
                .Select(x => new GetCategoryResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return response ?? throw new RespondNotFoundException();
        }
    }
}
