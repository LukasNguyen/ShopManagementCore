using SaleShopCore.Data.Entities;
using SaleShopCore.Data.IRepositories;

namespace SaleShopCore.Data.EF.Repositories
{
    public class ProductImageRepository : EFRepository<ProductImage, int>, IProductImageRepository
    {
        public ProductImageRepository(AppDbContext context) : base(context)
        {
        }
    }
}