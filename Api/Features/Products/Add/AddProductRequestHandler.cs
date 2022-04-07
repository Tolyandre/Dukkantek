using Dukkantek.Db;
using Dukkantek.Db.Models;
using MediatR;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Dukkantek.Api.Features.Products.Add
{
    public class AddProductRequestHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        private readonly DukkantekDbContext _dbContext;

        public AddProductRequestHandler(DukkantekDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            using var transaction = await _dbContext.Database
              .BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken: cancellationToken);

            var addProductResponse = await Add(request, cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return addProductResponse;
        }

        private async Task<AddProductResponse> Add(AddProductRequest request, CancellationToken cancellationToken)
        {
            var Product = Map(request);

            _dbContext.Add(Product);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new AddProductResponse
            {
                Barcode = Product.Barcode,
                Name = Product.Name
            };
        }

        private static Product Map(AddProductRequest request)
        {
            return new Product
            {
                Barcode = request.Barcode,
                Name = request.Name,
                CategoryId = request.CategoryId.Value,
                Description = request.Description,
                StatusId = request.StatusId.Value,
                Weight = request.Weight,
            };
        }
    }
}
