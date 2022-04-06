﻿using Dukkantek.Db;
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
           var query = await _dbContext.Products
                .GroupBy(p => p.StatusId)
                .ToDictionaryAsync(
                    group => group.Key,
                    group => group.Count(),
                    cancellationToken: cancellationToken);

            return new CountProductResponse
            {
                CountPerStatus = query,
            };
        }
    }
}
