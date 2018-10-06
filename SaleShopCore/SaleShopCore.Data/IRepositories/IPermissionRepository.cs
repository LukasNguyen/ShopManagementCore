using SaleShopCore.Data.Entities;
using SaleShopCore.Infrastructure.Interfaces;

namespace SaleShopCore.Data.IRepositories
{
    public interface IPermissionRepository : IRepository<Permission, int>
    {
    }
}