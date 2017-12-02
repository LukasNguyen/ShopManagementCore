using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using SaleShopCore.Application.Interfaces;
using SaleShopCore.Application.ViewModels.Product;
using SaleShopCore.Data.IRepositories;

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
    }
}