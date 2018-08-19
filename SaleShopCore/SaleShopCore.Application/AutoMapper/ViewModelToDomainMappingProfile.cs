using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SaleShopCore.Application.ViewModels.Product;
using SaleShopCore.Data.Entities;

namespace SaleShopCore.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile:Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>().ConstructUsing(n=>new ProductCategory(n.Name,n.Description,n.ParentId,n.HomeOrder,n.Image,n.HomeFlag,n.SortOrder,n.Status,n.SeoPageTitle,n.SeoAlias,n.SeoKeywords,n.SeoDescription));
        }
    }
}
