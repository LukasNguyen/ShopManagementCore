using SaleShopCore.Data.Entities;
using SaleShopCore.Data.IRepositories;

namespace SaleShopCore.Data.EF.Repositories
{
    public class BillRepository : EFRepository<Bill, int>, IBillRepository
    {
        public BillRepository(AppDbContext context) : base(context)
        {
        }
    }
}