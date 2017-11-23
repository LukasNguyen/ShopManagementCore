using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SaleShopCore.Application.Interfaces;
using SaleShopCore.Application.ViewModels.Product;
using SaleShopCore.Data.Entities;
using SaleShopCore.Data.Enums;
using SaleShopCore.Data.IRepositories;
using SaleShopCore.Infrastructure.Interfaces;

namespace SaleShopCore.Application.Implementation
{
    public class ProductCategoryService:IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository,IUnitOfWork unitOfWork)
        {
            _productCategoryRepository = productCategoryRepository;
            _unitOfWork = unitOfWork;
        }
        public ProductCategoryViewModel Add(ProductCategoryViewModel productCategoryVm)
        {
            var productCategory = Mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm);
            _productCategoryRepository.Add(productCategory);
            return productCategoryVm;
        }

        public void Update(ProductCategoryViewModel productCategoryVm)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            _productCategoryRepository.Remove(id);
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            //extension project just used for IQueryable
            return _productCategoryRepository.FindAll().OrderBy(n => n.ParentId).ProjectTo<ProductCategoryViewModel>()
                .ToList();
        }

        public List<ProductCategoryViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _productCategoryRepository
                    .FindAll(n => n.Name.Contains(keyword) || n.Description.Contains(keyword)).OrderBy(n => n.ParentId)
                    .ProjectTo<ProductCategoryViewModel>().ToList();
            else
            {
                return _productCategoryRepository
                    .FindAll().OrderBy(n => n.ParentId)
                    .ProjectTo<ProductCategoryViewModel>().ToList();
            }
        }

        public List<ProductCategoryViewModel> GetAllByParentId(int parentId)
        {
            return _productCategoryRepository
                .FindAll(n => n.Status == Status.Active && n.ParentId == parentId )
                .ProjectTo<ProductCategoryViewModel>().ToList();
        }

        public ProductCategoryViewModel GetById(int id)
        {
            return Mapper.Map<ProductCategory, ProductCategoryViewModel>(_productCategoryRepository.FindById(id));
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            throw new NotImplementedException();
        }

        public void ReOrder(int sourceId, int targetId)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryViewModel> GetHomeCategories(int top)
        {
            var query = _productCategoryRepository.FindAll(n => n.HomeFlag == true, n => n.Products)
                .OrderBy(n => n.HomeOrder).Take(top).ProjectTo<ProductCategoryViewModel>();
            var categories = query.ToList();

            foreach (var category in categories)
            {
                //do it later    
            }
            return categories;

        }

        public void Save()
        {
           _unitOfWork.Commit();
        }
    }
}
