using SaleShopCore.Data.Entities;
using SaleShopCore.Data.IRepositories;

namespace SaleShopCore.Data.EF.Repositories
{
    public class WholePriceRepository : EFRepository<WholePrice, int>, IWholePriceRepository
    {
        public WholePriceRepository(AppDbContext context) : base(context)
        {
        }
    }
}