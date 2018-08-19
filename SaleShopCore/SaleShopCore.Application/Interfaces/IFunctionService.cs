using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SaleShopCore.Application.ViewModels.System;

namespace SaleShopCore.Application.Interfaces
{
    public interface IFunctionService:IDisposable
    {
        Task<List<FunctionViewModel>> GetAll();
        Task<List<FunctionViewModel>> GetAllByPermission(Guid userId);
    }
}
