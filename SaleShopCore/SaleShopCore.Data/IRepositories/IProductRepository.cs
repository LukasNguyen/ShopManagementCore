using System;
using System.Collections.Generic;
using System.Text;
using SaleShopCore.Data.Entities;
using SaleShopCore.Infrastructure.Interfaces;

namespace SaleShopCore.Data.IRepositories
{
    public interface IProductRepository:IRepository<Product,int>
    {
    }
}
