using Dukkantek.Api.Controllers.ChargeStations.Remove;
using Dukkantek.Api.Features.Products.Add;
using Dukkantek.Api.Features.Products.Count;
using Dukkantek.Api.Features.Products.Update;
using Dukkantek.Api.Features.Products.UpdateStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dukkantek.Api.Features.Products
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetProductResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<GetProductResponse> GetProduct(string barcode, CancellationToken cancellationToken)
        {
            return _mediator.Send(new GetProductRequest { Barcode = barcode }, cancellationToken);
        }

        [HttpPost("", Name = "AddProduct")]
        public Task<AddProductResponse> AddProduct(AddProductRequest request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }

        [HttpGet("count", Name = "Count")]
        public Task UpdateChargeStation(CountProductsRequest request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }

        [HttpPut("status", Name = "UpdateStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task UpdateStatus(UpdateStatusRequest request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }
    }
}
