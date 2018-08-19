using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SaleShopCore.Application.Interfaces;
using SaleShopCore.Application.ViewModels.System;
using SaleShopCore.Data.IRepositories;

namespace SaleShopCore.Application.Implementation
{
    public class FunctionService:IFunctionService
    {
        private IFunctionRepository _functionRepository;

        public FunctionService(IFunctionRepository functionRepository)
        {
            _functionRepository = functionRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<List<FunctionViewModel>> GetAll()
        {
            return _functionRepository.FindAll().ProjectTo<FunctionViewModel>().ToListAsync();
        }

        public Task<List<FunctionViewModel>> GetAllByPermission(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
