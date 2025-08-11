using MediatR;
using ProductApp.Application.DTO;
using ProductApp.Application.Wrappers;

namespace ProductApp.Application.Features.Queries.GetProductById
{
    public class GetProductByIdQuery:IRequest<ServiceResponse<ProductViewDTO>>
    {
        public Guid Id { get; set; }
    }
}
