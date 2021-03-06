﻿using SaleShopCore.Application.ViewModels.Common;
using SaleShopCore.Application.ViewModels.Product;
using SaleShopCore.Utilities.Dtos;
using System;
using System.Collections.Generic;

namespace SaleShopCore.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        List<ProductViewModel> GetAll();

        PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);

        ProductViewModel Add(ProductViewModel viewModel);

        void Update(ProductViewModel viewModel);

        void Delete(int id);

        ProductViewModel GetById(int id);

        void ImportExcel(string filePath, int categoryId);

        void AddQuantity(int productId, List<ProductQuantityViewModel> quantities);

        List<ProductQuantityViewModel> GetQuantities(int productId);

        List<ProductImageViewModel> GetImages(int productId);

        void AddImages(int productId, string[] images);

        List<WholePriceViewModel> GetWholePrices(int productId);

        void AddWholePrice(int productId, List<WholePriceViewModel> wholePrices);

        List<ProductViewModel> GetLastest(int top);

        List<ProductViewModel> GetHotProducts(int top);

        List<ProductViewModel> GetRelatedProducts(int id, int top);

        List<ProductViewModel> GetUpsellProducts(int top);

        List<TagViewModel> GetProductTags(int productId);

        bool CheckAvailability(int productId, int sizeId, int colorId);

        void Save();
    }
}