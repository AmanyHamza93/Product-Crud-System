using MediatR;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Plugin.Application.Common.Interfaces;
using Plugin.Domain.Models;
using Plugin.Infrastructure;

namespace Plugin.Application.Features
{
    public class GetProductLookup
    {
        public sealed record Query() : IRequest<List<Product>>;

        public sealed class Handler : IRequestHandler<Query, List<Product>>
        {
            private readonly IProductService _service;
            public Handler(IProductService service) => _service = service;
            public async Task<List<Product>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _service.ListAsync();
            }

        }
    }
}
