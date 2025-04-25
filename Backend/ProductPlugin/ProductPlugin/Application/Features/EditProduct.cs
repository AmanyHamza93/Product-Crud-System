using MediatR;
using Plugin.Application.Common.Interfaces;
using Plugin.Domain.Models;
using Plugin.Infrastructure;
namespace Plugin.Application.Features
{
    public class EditProduct
    {
        public sealed record Command(int Id, string Code, string Name, decimal Price) : IRequest<Product>;
        public sealed class Handler : IRequestHandler<Command, Product>
        {
            private readonly IProductService _service;
            public Handler(IProductService service) => _service = service;
            public async Task<Product> Handle(Command request, CancellationToken ct)
            {
                var product = new Product
                {
                    Id = request.Id,
                    Code = request.Code,
                    Name = request.Name,
                    Price = request.Price
                };
                var result = await _service.UpdateAsync(product);
                return result;
            }
        }
    }
}
