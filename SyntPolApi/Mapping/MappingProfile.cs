using AutoMapper;
using SyntPolApi.Core.DTOs;
using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyntPolApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Provider, ProviderDTO>();
            CreateMap<Category, CategoryDTO>();

            CreateMap<ProductDTO, Product>();
            CreateMap<ProviderDTO, Provider>();
            CreateMap<CategoryDTO, Category>();
        }
    }
}
