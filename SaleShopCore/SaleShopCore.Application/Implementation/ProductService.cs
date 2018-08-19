using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using SaleShopCore.Application.Interfaces;
using SaleShopCore.Application.ViewModels.Product;
using SaleShopCore.Data.IRepositories;
using SaleShopCore.Utilities.Dtos;
using SaleShopCore.Data.Enums;

namespace SaleShopCore.Application.Implementation
{
    public class ProductService:IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<ProductViewModel> GetAll()
        {
            return _productRepository.FindAll(n=>n.ProductCategory).ProjectTo<ProductViewModel>().ToList();
        }

        public PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            var query = _productRepository.FindAll(n => n.Status == Status.Active);

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(n => n.Name.Contains(keyword));
            if (categoryId.HasValue)
                query = query.Where(n => n.CategoryId == categoryId.Value);

            int totalRow = query.Count();

            query = query.OrderByDescending(n => n.DateCreated).Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ProjectTo<ProductViewModel>().ToList();

            var paginationSet = new PagedResult<ProductViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }
    }
}