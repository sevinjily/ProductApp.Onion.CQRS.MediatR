using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Features.Commands.CreateProduct;
using ProductApp.Application.Features.Queries.GetAllProducts;
using ProductApp.Application.Features.Queries.GetProductById;

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
            [HttpGet("[action]")]
            public async Task<IActionResult> GetAll()
            {
            var query = new GetAllProductsQuery();
                return Ok(await mediator.Send(query));
            }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand product)
        {
            return Ok(await mediator.Send(product));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery() { Id=id};
            return Ok(await mediator.Send(query));
        }
    }
    }


