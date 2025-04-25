using MediatR;
using Microsoft.EntityFrameworkCore;
using Plugin.Application.Common.Interfaces;
using Plugin.Domain.Models;
using Plugin.Infrastructure;

namespace Plugin.Application.Features
{
    public class GetProduct
    {
        public sealed record Query(int Id) : IRequest<Product>;

        public sealed class Handler : IRequestHandler<Query, Product>
        {
            private readonly IProductService _service;
            public Handler(IProductService service) => _service = service;
            public async Task<Product> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _service.GetAsync(request.Id);
            }
        }
    }
}
