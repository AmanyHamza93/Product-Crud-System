using Microsoft.AspNetCore.Mvc;
using MediatR;
using Plugin.Application.Features;
namespace Plugin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<int>> Create(CreateProduct.Command command)
        {
            var result = await mediator.Send(command);
            return result == null ? NotFound() : Ok(result);
            
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<int>> GetById(int id)
        {
            var result = await mediator.Send(new GetProduct.Query(id));
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<int>> Put(EditProduct.Command command)
        {
            var result = await mediator.Send(command);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var result = await mediator.Send(new DeleteProduct.Command(id));
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet]
        [Route("lookup")]
        public async Task<ActionResult<int>> GetLookupData([FromQuery] GetProductLookup.Query query)
        {
            var result = await mediator.Send(query);
            return result == null ? NotFound() : Ok(result);
        }

    }
}
