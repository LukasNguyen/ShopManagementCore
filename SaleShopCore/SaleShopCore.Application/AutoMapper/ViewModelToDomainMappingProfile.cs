using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SaleShopCore.Application.ViewModels.Product;
using SaleShopCore.Application.ViewModels.System;
using SaleShopCore.Data.Entities;

namespace SaleShopCore.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile:Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>()
                .ConstructUsing(n=>new ProductCategory(n.Name,n.Description,n.ParentId,n.HomeOrder,n.Image,n.HomeFlag,n.SortOrder,n.Status,n.SeoPageTitle,n.SeoAlias,n.SeoKeywords,n.SeoDescription));

            CreateMap<ProductViewModel, Product>()
                .ConstructUsing(c => new Product(c.Name, c.CategoryId, c.Image, c.Price, c.OriginalPrice,
                c.PromotionPrice, c.Description, c.Content, c.HomeFlag, c.HotFlag, c.Tags, c.Unit, c.Status,
                c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));

            CreateMap<AppUserViewModel, AppUser>()
                .ConstructUsing(c => new AppUser(c.Id.GetValueOrDefault(Guid.Empty), c.FullName, c.UserName,
                c.Email, c.PhoneNumber, c.Avatar, c.Status));
        }
    }
}
