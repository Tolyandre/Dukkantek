using Dukkantek.Api.Features.Categories.Add;
using Dukkantek.Api.Features.Categories.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dukkantek.Api.Features.Categories
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCategoryResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<GetCategoryResponse> GetGroup(int id, CancellationToken cancellationToken)
        {
            return _mediator.Send(new GetCategoryRequest { Id = id }, cancellationToken);
        }

        [HttpPost("", Name = "AddCategory")]
        public Task<AddCategoryResponse> AddGroup(AddCategoryRequest request, CancellationToken cancellationToken)
        {
            return _mediator.Send(request, cancellationToken);
        }
    }
}
