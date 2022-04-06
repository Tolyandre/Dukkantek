using Dukkantek.Db;
using Dukkantek.Db.Models;
using MediatR;

namespace Dukkantek.Api.Features.Categories.Add
{
    public class AddCategoryRequestHandler : IRequestHandler<AddCategoryRequest, AddCategoryResponse>
    {
        private readonly DukkantekDbContext _dbContext;

        public AddCategoryRequestHandler(DukkantekDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddCategoryResponse> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
            };

            _dbContext.Add(category);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new AddCategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
            };
        }
    }
}
