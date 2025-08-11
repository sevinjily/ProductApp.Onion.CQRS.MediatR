using AutoMapper;
using MediatR;
using ProductApp.Application.DTO;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.GetProductById
{
    public class GetProductByIdQueryHandler:IRequestHandler<GetProductByIdQuery,ServiceResponse<ProductViewDTO>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        public GetProductByIdQueryHandler(IProductRepository productRepository,IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public IMapper Mapper { get; }

        public async Task<ServiceResponse<ProductViewDTO>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);
            var dto =  mapper.Map<ProductViewDTO>(product);
            return new ServiceResponse<ProductViewDTO>(dto);
        }
    }
}
