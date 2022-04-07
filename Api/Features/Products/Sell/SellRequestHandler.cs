using Dukkantek.Db;
using MediatR;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Dukkantek.Api.Exceptions;
using Dukkantek.Db.Models;

namespace Dukkantek.Api.Features.Products.Sell
{
    public class SellRequestHandler : IRequestHandler<SellRequest>
    {
        private readonly DukkantekDbContext _dbContext;

        public SellRequestHandler(DukkantekDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(SellRequest request, CancellationToken cancellationToken)
        {
            using var transaction = await _dbContext.Database
              .BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken: cancellationToken);

            await Sell(request, cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return Unit.Value;
        }

        private async Task Sell(SellRequest request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Barcode == request.Barcode, cancellationToken: cancellationToken);

            if (product == null)
                throw new RespondNotFoundException();

            if (product.StatusId == ProductStatusId.Sold)
                throw new RespondBadRequestException("", "Sorry, this product is already sold.");

            if (product.StatusId == ProductStatusId.Damaged)
                throw new RespondBadRequestException("", "Sorry, this product is currently unavailable.");

            product.StatusId = ProductStatusId.Sold;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
