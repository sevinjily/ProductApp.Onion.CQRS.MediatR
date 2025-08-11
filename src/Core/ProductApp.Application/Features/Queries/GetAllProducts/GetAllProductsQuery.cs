using MediatR;
using ProductApp.Application.DTO;
using ProductApp.Application.Wrappers;

namespace ProductApp.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQuery:IRequest<ServiceResponse<List<ProductViewDTO>>>
    {
        
        }
    }

