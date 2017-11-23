using System.Collections.Generic;
using SaleShopCore.Data.Entities;
using SaleShopCore.Infrastructure.Interfaces;

namespace SaleShopCore.Data.IRepositories
{
    public interface IProductCategoryRepository:IRepository<ProductCategory,int>
    {
        List<ProductCategory> GetByAlias(string alias);
    }
}