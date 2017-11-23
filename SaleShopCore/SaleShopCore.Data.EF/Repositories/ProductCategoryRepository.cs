using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SaleShopCore.Data.Entities;
using SaleShopCore.Data.IRepositories;

namespace SaleShopCore.Data.EF.Repositories
{
    public class ProductCategoryRepository:EFRepository<ProductCategory,int>,IProductCategoryRepository
    {
        private AppDbContext _context;
        public ProductCategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductCategory> GetByAlias(string alias)
        {
            return _context.ProductCategories.Where(n => n.SeoAlias == alias).ToList();
        }
    }
}
