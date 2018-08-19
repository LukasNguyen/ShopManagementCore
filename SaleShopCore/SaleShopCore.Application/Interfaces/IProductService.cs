using System;
using System.Collections.Generic;
using System.Text;
using SaleShopCore.Application.ViewModels.Product;
using SaleShopCore.Utilities.Dtos;

namespace SaleShopCore.Application.Interfaces
{
    public interface IProductService:IDisposable
    {
        List<ProductViewModel> GetAll();
        PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);
    }
}
