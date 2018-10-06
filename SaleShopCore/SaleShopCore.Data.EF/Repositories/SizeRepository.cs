using SaleShopCore.Data.Entities;
using SaleShopCore.Data.IRepositories;

namespace SaleShopCore.Data.EF.Repositories
{
    public class SizeRepository : EFRepository<Size, int>, ISizeRepository
    {
        public SizeRepository(AppDbContext context) : base(context)
        {
        }
    }
}