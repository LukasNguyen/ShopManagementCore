using System;

namespace SaleShopCore.Infrastructure.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        void Commit();
    }
}