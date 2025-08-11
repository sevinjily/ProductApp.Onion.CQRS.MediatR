using MediatR;
using ProductApp.Application.DTO;
using ProductApp.Application.Interfaces.Repository;

namespace ProductApp.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQuery:IRequest<List<ProductViewDTO>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductViewDTO>>
        {
            private readonly IProductRepository productRepository;

            public GetAllProductsQueryHandler(IProductRepository productRepository)
            {
                this.productRepository = productRepository;
            }
            public async Task<List<ProductViewDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await productRepository.GetAllAsync();
                return products.Select(i=>new ProductViewDTO() //manuel usulla mapping prosesi
                {
                    Id = i.Id,
                    Name = i.Name,
                }).ToList();
            }
        }
    }
}
