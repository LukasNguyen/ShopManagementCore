using SaleShopCore.Data.Entities;
using SaleShopCore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleShopCore.Data.IRepositories
{
    public interface IPermissionRepository : IRepository<Permission, int>
    {

    }
}
