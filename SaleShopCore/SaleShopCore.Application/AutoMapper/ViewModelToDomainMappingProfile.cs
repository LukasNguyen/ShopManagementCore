using AutoMapper;
using SaleShopCore.Application.ViewModels.Blog;
using SaleShopCore.Application.ViewModels.Product;
using SaleShopCore.Application.ViewModels.System;
using SaleShopCore.Data.Entities;
using System;

namespace SaleShopCore.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>()
                .ConstructUsing(n => new ProductCategory(n.Name, n.Description, n.ParentId, n.HomeOrder, n.Image, n.HomeFlag, n.SortOrder, n.Status, n.SeoPageTitle, n.SeoAlias, n.SeoKeywords, n.SeoDescription));

            CreateMap<ProductViewModel, Product>()
                .ConstructUsing(c => new Product(c.Name, c.CategoryId, c.Image, c.Price, c.OriginalPrice,
                c.PromotionPrice, c.Description, c.Content, c.HomeFlag, c.HotFlag, c.Tags, c.Unit, c.Status,
                c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription));

            CreateMap<AppUserViewModel, AppUser>()
                .ConstructUsing(c => new AppUser(c.Id.GetValueOrDefault(Guid.Empty), c.FullName, c.UserName,
                c.Email, c.PhoneNumber, c.Avatar, c.Status));

            CreateMap<PermissionViewModel, Permission>()
                .ConstructUsing(c => new Permission(c.RoleId, c.FunctionId, c.CanCreate, c.CanRead, c.CanUpdate, c.CanDelete));

            CreateMap<BillViewModel, Bill>()
            .ConstructUsing(c => new Bill(c.Id, c.CustomerName, c.CustomerAddress,
            c.CustomerMobile, c.CustomerMessage, c.BillStatus,
            c.PaymentMethod, c.Status, c.CustomerId));

            CreateMap<BillDetailViewModel, BillDetail>()
              .ConstructUsing(c => new BillDetail(c.Id, c.BillId, c.ProductId,
              c.Quantity, c.Price, c.ColorId, c.SizeId));

            CreateMap<BlogViewModel, Blog>();

            CreateMap<BlogTagViewModel, BlogTag>();
        }
    }
}