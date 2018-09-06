using SaleShopCore.Application.ViewModels.System;
using SaleShopCore.Utilities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SaleShopCore.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddAsync(AppUserViewModel userVm);

        Task DeleteAsync(string id);

        Task<List<AppUserViewModel>> GetAllAsync();

        PagedResult<AppUserViewModel> GetAllPaging(string keyword, int page, int pageSize);

        Task<AppUserViewModel> GetById(string id);

        Task UpdateAsync(AppUserViewModel userVm);
    }
}