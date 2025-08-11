using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Features.Queries.GetAllProducts;

namespace ProductApp.WebApi.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ProductController : ControllerBase
        {
        private readonly IMediator mediator;

        public ProductController( IMediator mediator)
            {
            this.mediator = mediator;
        }
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
            var query = new GetAllProductsQuery();
                return Ok(await mediator.Send(query));
            }
        }
    }


