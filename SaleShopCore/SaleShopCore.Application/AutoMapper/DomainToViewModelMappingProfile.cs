using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SaleShopCore.Application.ViewModels.Product;
using SaleShopCore.Data.Entities;

namespace SaleShopCore.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
        }
    }
}
