﻿using Microsoft.AspNetCore.Mvc;
using SaleShopCore.Application.Interfaces;
using System.Threading.Tasks;

namespace SaleShopCore.Controllers.Components
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly IProductCategoryService _productCategoryService;

        public CategoryMenuViewComponent(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_productCategoryService.GetAll());
        }
    }
}