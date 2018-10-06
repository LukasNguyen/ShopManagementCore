using SaleShopCore.Data.Entities;
using SaleShopCore.Data.IRepositories;

namespace SaleShopCore.Data.EF.Repositories
{
    public class ColorRepository : EFRepository<Color, int>, IColorRepository
    {
        public ColorRepository(AppDbContext context) : base(context)
        {
        }
    }
}