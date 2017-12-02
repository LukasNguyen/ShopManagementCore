using System;
using System.Collections.Generic;
using System.Text;
using SaleShopCore.Data.Entities;
using SaleShopCore.Data.IRepositories;

namespace SaleShopCore.Data.EF.Repositories
{
    public class ProductRepository:EFRepository<Product,int>,IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
