using MediatR;
using Plugin.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Plugin.Application.Common.Interfaces;

namespace Plugin.Application.Features
{
    public class DeleteProduct
    {
        public sealed record Command(int Id) : IRequest<int>;

        public sealed class Handler : IRequestHandler<Command, int>
        {
            private readonly IProductService _service;
            public Handler(IProductService service) => _service = service;

            public async Task<int> Handle(Command request, CancellationToken ct)
            {
                var product = await _service.GetAsync(request.Id);
                if (product == null)
                    return 0;
                await _service.DeleteAsync(request.Id);
                return request.Id;
            }
        }
    }

}
