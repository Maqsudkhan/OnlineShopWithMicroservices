using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.CatalogCases.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers.CatalogControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogsController : ControllerBase
    {
        private readonly ICatalogDbContext _context;
        private readonly IMediator _mediator;

        public CatalogsController(ICatalogDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCatalog(CreateCatalogCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
