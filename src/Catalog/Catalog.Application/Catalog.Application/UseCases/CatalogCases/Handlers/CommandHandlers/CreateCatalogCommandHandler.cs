using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.CatalogCases.Commands;
using Catalog.Domain;
using Catalog.Domain.Entities;
using MediatR;


namespace Catalog.Application.UseCases.CatalogCases.Handlers.CommandHandlers
{
    public class CreateCatalogCommandHandler : IRequestHandler<CreateCatalogCommand, ResponseModel>
    {
        private readonly ICatalogDbContext _context;
        public CreateCatalogCommandHandler(ICatalogDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateCatalogCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var catalog = new ProductCatalog
                {
                    Name = request.Name,
                    Description = request.Description,
                };

                await _context.Catalogs.AddAsync( catalog, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"{request.Name} created✅",
                    isSuccess = true
                };
            }
            return new ResponseModel
            {
                Message ="Catalog is maybe null❗",
                StatusCode = 400
            };
        }
    }
}
