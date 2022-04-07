using Dukkantek.Api.Features.Products.Add;
using Dukkantek.Api.Features.Products.CountPerStatus;
using Dukkantek.Api.Features.Products.GetAll;
using Dukkantek.Api.Features.Products.Sell;
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

        [HttpGet("", Name = "GetAllProducts")]
        public Task<GetAllProductsResponse[]> GetAllProducts(CancellationToken cancellationToken)
        {
            return _mediator.Send(new GetAllProductsRequest(), cancellationToken);
        }

        [HttpPost("", Name = "AddProduct")]
        public Task<AddProductResponse> AddProduct(AddProductRequest request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }

        [HttpGet("count-per-status", Name = "CountPerStatus")]
        public Task<CountProductResponse> CountPerStatus([FromQuery]CountProductsRequest request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }

        [HttpPut("barcode/{barcode}/status", Name = "UpdateStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task UpdateStatus([FromRoute] string barcode,[FromBody] UpdateStatusRequest request, CancellationToken cancellationToken)
        {
            request.Barcode = barcode;
            return _mediator.Send(request, cancellationToken);
        }

        [HttpPut("barcode/{barcode}/sell", Name = "Sell")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task Sell([FromRoute] string barcode, [FromBody] SellRequest request, CancellationToken cancellationToken)
        {
            request.Barcode = barcode;
            return _mediator.Send(request, cancellationToken);
        }
    }
}
