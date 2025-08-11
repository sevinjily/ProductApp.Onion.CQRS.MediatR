﻿using AutoMapper;
using ProductApp.Application.Features.Commands.CreateProduct;

namespace ProductApp.Application.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Domain.Entities.Product,DTO.ProductViewDTO>().ReverseMap();
            CreateMap<Domain.Entities.Product, CreateProductCommand>().ReverseMap();

        }
    }
}
