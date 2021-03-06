﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using SaleShopCore.Application.Interfaces;
using SaleShopCore.Models.ProductViewModels;
using System.Linq;

namespace SaleShopCore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IConfiguration _configuration;
        private readonly IBillService _billService;

        public ProductController(IProductService productService,
            IConfiguration configuration,
            IProductCategoryService productCategoryService,
            IBillService billService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _configuration = configuration;
            this._billService = billService;
        }

        [Route("products.html")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("{alias}-c.{id}.html", Name = "Catalog")]
        public IActionResult Catalog(int id, int? pageSize, string sortBy, int page = 1)
        {
            ViewData["BodyClass"] = "shop_grid_full_width_page";

            var catalog = new CatalogViewModel();

            if (pageSize == null)
                pageSize = _configuration.GetValue<int>("PageSize");

            catalog.PageSize = pageSize;
            catalog.SortType = sortBy;
            catalog.Data = _productService.GetAllPaging(id, string.Empty, page, pageSize.Value);
            catalog.Category = _productCategoryService.GetById(id);

            return View(catalog);
        }

        [Route("search.html", Name = "Search")]
        public IActionResult Search(string keyword, int? pageSize, string sortBy, int page = 1)
        {
            ViewData["BodyClass"] = "shop_grid_full_width_page";

            var catalog = new SearchResultViewModel();

            if (pageSize == null)
                pageSize = _configuration.GetValue<int>("PageSize");

            catalog.PageSize = pageSize;
            catalog.SortType = sortBy;
            catalog.Data = _productService.GetAllPaging(null, keyword, page, pageSize.Value);
            catalog.Keyword = keyword;

            return View(catalog);
        }

        [Route("{alias}-p.{id}.html", Name = "ProductDetail")]
        public IActionResult Details(int id)
        {
            ViewData["BodyClass"] = "product-page";

            var model = new DetailViewModel();
            model.Product = _productService.GetById(id);
            model.Category = _productCategoryService.GetById(model.Product.CategoryId);
            model.RelatedProducts = _productService.GetRelatedProducts(id, 9);
            model.UpsellProducts = _productService.GetUpsellProducts(6);
            model.ProductImages = _productService.GetImages(id);
            model.Tags = _productService.GetProductTags(id);
            model.Colors = _billService.GetColors().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            model.Sizes = _billService.GetSizes().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

            return View(model);
        }
    }
}