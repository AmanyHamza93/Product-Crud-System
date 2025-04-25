using MediatR;
using Plugin.Application.Common.Interfaces;
using Plugin.Domain.Models;

namespace Plugin.Application.Features
{
    public class CreateProduct
    {
        public sealed record Command(string Code, string Name, decimal Price) : IRequest<Product>;
        public sealed class Handler : IRequestHandler<Command, Product>
        {
            private readonly IProductService _service;
            public Handler(IProductService service) => _service = service;
            public async Task<Product> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = new Product
                {
                    Code = request.Code,
                    Name = request.Name,
                    Price = request.Price
                };
                var result = await _service.CreateAsync(entity);
                return result;
            }
        }
    }
}
