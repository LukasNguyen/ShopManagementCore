using System;
using System.Collections.Generic;
using System.Text;
using SaleShopCore.Application.ViewModels.Product;

namespace SaleShopCore.Application.Interfaces
{
    public interface IProductService:IDisposable
    {
        List<ProductViewModel> GetAll();
    }
}
