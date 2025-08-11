using AutoMapper;
using MediatR;
using ProductApp.Application.DTO;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;

namespace ProductApp.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<List<ProductViewDTO>>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IProductRepository productRepository,IMapper mapper)
        {
            this.productRepository = productRepository; 
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<List<ProductViewDTO>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync();
            var viewModel=mapper.Map<List<ProductViewDTO>>(products);

            //var dto= products.Select(i => new ProductViewDTO() //manuel usulla mapping prosesi
            //{
            //    Id = i.Id,
            //    Name = i.Name,
            //}).ToList();
            return new ServiceResponse<List<ProductViewDTO>>(viewModel);
        }
    }
}
