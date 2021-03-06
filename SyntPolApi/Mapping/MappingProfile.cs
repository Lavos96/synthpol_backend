﻿using AutoMapper;
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
            CreateMap<Product, GetProductDTO>();
            CreateMap<Provider, GetProviderDTO>();
            CreateMap<Category, GetCategoryDTO>();
            CreateMap<Invoice, GetInvoiceDTO>();

            CreateMap<GetProductDTO, Product>();
            CreateMap<GetProviderDTO, Provider>();
            CreateMap<GetCategoryDTO, Category>();

            CreateMap<Product, PostProductDTO>();
            CreateMap<Provider, PostProviderDTO>();
            CreateMap<Category, PostCategoryDTO>();

            CreateMap<PostProductDTO, Product>();
            CreateMap<PostProviderDTO, Provider>();
            CreateMap<PostCategoryDTO, Category>();
            CreateMap<PostInvoiceDTO, Invoice>();
            CreateMap<UpdateInvoiceDTO, Invoice>();

            CreateMap<OrderItem, GetOrderItemDTO>();
            CreateMap<Product, GetProductForOrderDTO>();
            CreateMap<Order, GetOrderDTO>();
            CreateMap<OrderItem, GetOrderItemForXml>();
        }
    }
}
