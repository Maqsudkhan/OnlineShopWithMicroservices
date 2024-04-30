using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.CatalogCases.Commands;
using Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if(request != null) 
            {
                var user = new ProductCatalog
                {
                    Name = request.Name,
                    Description = request.Description,

                };
                
                await _context.Catalogs.AddAsync(user);
            }
        }
    }
}
