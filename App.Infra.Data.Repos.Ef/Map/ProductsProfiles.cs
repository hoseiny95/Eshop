using App.Domain.Core.Products.Dtos;
using App.Domain.Core.Products.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Map
{
    public class ProductsProfiles : Profile
    {
        public ProductsProfiles()
        {
            CreateMap<CustomAttributeTemplate, CustomAttributeTemplateInputDto>();
            CreateMap<CustomAttributeTemplate, CustomAttributeTemplateOutputDto>();

            CreateMap<Order, OrderInputDto>();
            CreateMap<Order, OrderOutputDto>();

            CreateMap<OrderLine, OrderLineInputDto>();
            CreateMap<OrderLine, OrderLineOutputDto>();

            CreateMap<OrderStatus, OrderStatusInputDto>();
            CreateMap<OrderStatus, OrderStatusOutputDto>();

            CreateMap<Product, ProductInputDto>();
            CreateMap<Product, ProductOutputDto>();

            CreateMap<ProductCustomAttribute, ProductCustomAttributeInputDto>();
            CreateMap<ProductCustomAttribute, ProductCustomAttributeOutputDto>();

            CreateMap<ProductInventory, ProductInventoryInputDto>();
            CreateMap<ProductInventory, ProductInventoryOutputDto>();

            CreateMap<ProductPrice, ProductPriceInputDto>();
            CreateMap<ProductPrice, ProductPriceOutputDto>();
        }
    }
}
