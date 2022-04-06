using Dukkantek.Db;
using MediatR;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Dukkantek.Api.Exceptions;

namespace Dukkantek.Api.Features.Products.UpdateStatus
{
    public class UpdateStatusRequestHandler : IRequestHandler<UpdateStatusRequest>
    {
        private readonly DukkantekDbContext _dbContext;

        public UpdateStatusRequestHandler(DukkantekDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateStatusRequest request, CancellationToken cancellationToken)
        {
            using var transaction = await _dbContext.Database
              .BeginTransactionAsync(IsolationLevel.ReadCommitted, cancellationToken: cancellationToken);

            await Add(request, cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return Unit.Value;
        }

        private async Task Add(UpdateStatusRequest request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Barcode == request.Barcode, cancellationToken: cancellationToken);

            if (product == null)
                throw new RespondNotFoundException();

            product.StatusId = request.StatusId;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
